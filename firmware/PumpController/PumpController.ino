/**@file*/

#include <ZeroTC45.h>

// config.h determines whether to use WiFi or LoRaWAN and includes the correct headers.
#include "config.h"
#include "PumpIO.h"

/** The interval to send status messages to Thingsboard, in seconds. */
static constexpr unsigned long statusInterval = 10 * 60;

// Command message bit-flags.
constexpr uint8_t RUN_FLAG = 0x01;
constexpr uint8_t TIMER_FLAG = 0x02;

static ZeroTC45 timer;

#if defined USE_WIFI
/** Use the WiFi NetworkAccess class. */
static WiFiNetwork network;
#elif defined USE_LORAWAN
/** Use the LoRaWAN NetworkAccess class. */
static LoRaWAN network;
#endif

// These are used by both network stacks but rather than declare in both and use double the memory
// declare them here and reference them as extern from NetworkAccess.h.
char statusMsgBuffer[132];
const char* statusMsgJsonFormat = "{'pumpRunning':%d,'boreLowLevel':%d,'softStartFail':%d,'pumpOverload':%d,'controllerRestart':%d,'highPressure':%d,'noFlow':%d}";

/** The most recent status read from the pump I/O board. */
static StatusMsgBody pumpStatus;

/** This is for checking for pin changes to send an uplink when something changes. */
static StatusMsgBody prevStatus;

/** A flag to indicate no status message has been sent since a restart, so set the restart bit in the message. */
static bool firstMessage = true;

/**
 * The logical interface to controlling the pump and reading its status.
 */
static PumpIO pumpIO(LOW_BORE_PIN, SOFT_START_PIN, PUMP_OVERLOAD_PIN, HIGH_PRESSURE_PIN, NO_FLOW_PIN, PUMP_CONTROL_PIN);

/**
 * Set to true when a status message should be sent. This could be due to the timer going off or
 * the pump state changing.
 */
static volatile boolean sendStatus = false;

// Forward decl so pumpTimerCallback can call this method.
static void stopPump();

/** This function is called when the status message timer triggers. Set a flag to tell loop() to send a status message. */
static void statusCallback() {
    log("Request scheduled status message to be sent.");
    sendStatus = true;
}

/** This function is called when the auto-switch-off pump timer triggers. */
static void pumpTimerCallback(){
    log("Pump run timer has expired. Turning pump off.");
    stopPump();
}

/** 
 * Starts the auto-switch-off pump timer. This function assumes pumpStartData is at least 3 bytes long
 * and that the timer value is a 16-bit unsigned int in bytes 1 and 2.
 */
static void startPumpTimer(const uint8_t *pumpStartData) {
    uint16_t minutes = (pumpStartData[1] << 8) | pumpStartData[2];
    log("Starting one-shot timer.");
    Serial.print("Timer in minutes: ");
    Serial.println(minutes);
    uint16_t seconds = minutes * 60;
    timer.startTc5(seconds, true);
}

/**
 * Usual Arduino setup code - initialize all peripherals and globals.
 */
void setup() {
    pumpIO.stopPump();

    pumpIO.getStatus(pumpStatus);
    prevStatus.byte = pumpStatus.byte;

    timer.begin();
    timer.setTc4Callback(statusCallback);
    timer.startTc4(statusInterval);

    timer.setTc5Callback(pumpTimerCallback);

    Serial.begin(115200);
    delay(10000); // Simply to give time to get to the serial monitor and clear it.

    network.setup();

    log("setup() complete.");
}

/**
 * This function is called continuously by the Arduino core code. It is important
 * this function is called regularly so the network classes can keep their stacks
 * running.
 */
void loop() {
    network.loop();

    pumpIO.getStatus(pumpStatus);
    if (pumpStatus.byte != prevStatus.byte) {
        log("Sending status due to state change.");
        sendStatus = true;
        prevStatus.byte = pumpStatus.byte;
    }

    // The pump controller should not try to run the pump if any
    // alarm signals are asserted. The change
    // of state will be picked up next time through the loop.
    if (pumpStatus.flags.pumpRunning && pumpStatus.flags.highPressure) {
        log("Stopping pump due to high pressure signal.");
        stopPump();
        return; // Return now to get new pump status at the top of loop before sending the status message.
    }

    if (pumpStatus.flags.pumpRunning && pumpStatus.flags.softStartFail) {
        log("Stopping pump due to soft start fail signal.");
        stopPump();
        return; // Return now to get new pump status at the top of loop before sending the status message.
    }

    if (pumpStatus.flags.pumpRunning && pumpStatus.flags.boreLowLevel) {
        log("Stopping pump due to low bore level");
        stopPump();
        return; //Return now to get new pump status at the top of the tloop before sending the status message.
    }

    if (pumpStatus.flags.pumpRunning && pumpStatus.flags.pumpOverload) {
        log("Stopping pump due to pump overload");
        stopPump();
        return; //Return now to get new pump status at the top of the tloop before sending the status message.
    }

    if (pumpStatus.flags.pumpRunning && pumpStatus.flags.noFlow) {
        log("Stopping pump due to no flow");
        stopPump();
        return; //Return now to get new pump status at the top of the tloop before sending the status message.
    }

    // Send a status message as soon as the network stack is ready.
    // firstMessage is cleared in sendMessage when the message has
    // actually been sent. This means we'll keep trying until the
    // network stack is up and the message has been sent.
    if (firstMessage && network.readyToSend()) {
        log("Send initial status message.");
        sendStatus = true;
    }

    // Check for a command entered at via the serial port.
    checkSerialForCommand();

    // Send the status message if any condition has requested one to be sent.
    if (sendStatus) {
        sendStatus = false;
        sendStatusMsg();
    }
}

/**
 * Start the pump if there are no asserted alarm signals.
 * 
 * Returns true if the pump was started, otherwise false.
 */
static bool startPump() {
    if (pumpStatus.flags.highPressure) {
        log("Not starting pump due to high pressure signal.");
        return false;
    }

    if (pumpStatus.flags.softStartFail) {
        log("Not starting pump due to soft start fail signal.");
        return false;
    }

    if (pumpStatus.flags.pumpOverload) {
        log("Not starting pump due to pump overload signal.");
        return false;
    }

    if (pumpStatus.flags.boreLowLevel) {
        log("Not starting pump due to bore low level.");
        return false;
    }

    if (pumpStatus.flags.noFlow) {
        log("Not starting pump due to no flow.");
        return false;
    }

    pumpIO.startPump();
    return true;
}

/**
 * Stop the pump and cancel the pump run timer.
 */
static void stopPump() {
     pumpIO.stopPump();
     timer.stopTc5();
}

/**
 * This function processes commands sent from Thingsboard, eg switch the
 * pump on or off. The protocol-specific callback functions must reformat
 * the command they get from Thingsboard into a standard format this function
 * can understand.
 *
 * TODO: Change the signature to take a standard command format rather than
 * raw bytes.
 */
void processCommand(const uint8_t *data, const size_t length) {
    char msg[32];
    if (data != NULL) {
        snprintf(msg, sizeof(msg), "callback got data %d", data[0]);
        log(msg);

        if (data[0] & RUN_FLAG) {
            if (startPump()) {
                // Only look for timer info if the pump was started - ie no
                // alarms are active.
                if (data[0] & TIMER_FLAG) {
                    if (length == 3) {
                        startPumpTimer(data);
                    }
                }
            }
        } else {
            stopPump();
        }
    } else {
        snprintf(msg, sizeof(msg), "callback got NULL for data.");
        log(msg);
    }
}

/**
 * Sends the current pumpStatus value if the network stack is in a position to send a message.
 *
 * If the network stack is not ready the message is not queued. There is no point sending old
 * status messages.
 *
 * The very first message sent after the pump controller starts will have the restart bit set.
 * This flag is best-effort because there is no way for the controller to know the message was
 * received. It will be set on the first attempt to send a message and then switched off.
 */
static void sendStatusMsg() {
    if (!network.readyToSend()) {
        log("Not ready to send.");
        return;
    }

    pumpStatus.flags.controllerRestart = firstMessage;
    firstMessage = false;

    network.sendStatus(pumpStatus);
}

/**
 * Check the serial port for testing/debugging commands.
 */
static void checkSerialForCommand() {
    boolean gotChar = false;
    int ch;
    while (Serial.available() > 0) {
        gotChar = true;
        ch = Serial.read();
    }

    uint8_t cmdByte = 0;
    if (gotChar) {
        switch (ch) {
        // Send a status message on demand.
        case 'm':
            log("Send operator requested status message.");
            sendStatus = true;
            break;

        // Simulate a pump on downlink command.
        case 'n':
            cmdByte = 1;
            processCommand(&cmdByte, 1);
            break;

        // Simulate a pump off downlink command.
        case 'f':
            cmdByte = 0;
            processCommand(&cmdByte, 1);
            break;

        // Force the pump to start.
        case 'N':
            pumpIO.startPump();
            break;

        // Force the pump to stop.
        case 'F':
            stopPump();
            break;

        // Attempt to force a message replacement in the LoRaWAN stack.
        case 'W':
            cmdByte = pumpStatus.byte;
            pumpStatus.byte = 0x21; // Value is not significant, just different from the next one being sent.
            sendStatusMsg();
            pumpStatus.byte = 0x00;
            sendStatusMsg();
            pumpStatus.byte = cmdByte;
            break;
        

        // Timer functionality
        case 'T':
            log("Issuing a pump on message with timer value.");
            const uint8_t pumpTimerData[] = { 0x03, 0x00, 0x02 };
            processCommand(pumpTimerData, 3);
            break;
        }
    }
}
