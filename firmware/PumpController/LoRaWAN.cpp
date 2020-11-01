// config.h determines whether to use WiFi or LoRaWAN.
#include "config.h"

#ifdef USE_LORAWAN

// This is required to make the LMIC library honour the LMIC_setClockError call.
#define LMIC_ENABLE_arbitrary_clock_error 1

#include <lmic.h>
#include <hal/hal.h>
#include <SPI.h>
#include <math.h>

#include "arduino_secrets.h"

// Pin mapping - AdaFruit M0. Taken from the MCCI examples.
const lmic_pinmap lmic_pins = {
    .nss = 8,
    .rxtx = LMIC_UNUSED_PIN,
    .rst = 4,
    .dio = {3, 6, LMIC_UNUSED_PIN},
    .rxtx_rx_active = 0,
    .rssi_cal = 8,              // LBT cal for the Adafruit Feather M0 LoRa, in dB
    .spi_freq = 8000000,
    .pConfig = NULL
};

static constexpr char firmwareVersion[] = FIRMWARE_VERSION;

void os_getArtEui(uint8_t *buf) {
    memcpy_P(buf, APPEUI, 8);
}
void os_getDevEui(uint8_t *buf) {
    memcpy_P(buf, DEVEUI, 8);
}
void os_getDevKey(uint8_t *buf) {
    memcpy_P(buf, APPKEY, 16);
}

/**
 * Handle events from the LMIC library. The LMIC library requires this
 * to be a function with this name and signature so it cannot even be
 * a static method.
 */
void onEvent(ev_t ev) {
    switch (ev) {
    case EV_JOINING:
        log("EV_JOINING");
        break;
    case EV_JOINED:
        log("EV_JOINED");
        break;
    case EV_JOIN_FAILED:
        log("EV_JOIN_FAILED");
        break;
    case EV_TXCOMPLETE:
        log("EV_TXCOMPLETE (includes waiting for RX windows)");
        if (LMIC.dataLen) {
            snprintf(statusMsgBuffer, sizeof(statusMsgBuffer), "Received reply with %u bytes:", LMIC.dataLen);
            log(statusMsgBuffer);
            for (int i = 0; i < LMIC.dataLen; i++) {
                if (LMIC.frame[LMIC.dataBeg + i] < 0x10) {
                    Serial.print("0");
                }
                Serial.print(LMIC.frame[LMIC.dataBeg + i], HEX);
                Serial.print(" ");
            }
            Serial.println();

            processCommand(&LMIC.frame[LMIC.dataBeg], LMIC.dataLen);
        }

        //log("End EV_TXCOMPLETE handler");
        break;
    case EV_TXSTART:
        //log("EV_TXSTART");
        break;
    case EV_TXCANCELED:
        log("EV_TXCANCELED");
        break;
    case EV_JOIN_TXCOMPLETE:
        //log("EV_JOIN_TXCOMPLETE");
        break;

    default:
        log("Unknown event");
        break;
    }
}

void LoRaWAN::setup() {
    log(firmwareVersion);

    os_init();
    LMIC_reset();
    LMIC_setClockError((MAX_CLOCK_ERROR * 10) / 100);

    // Not supported by TTN.
    LMIC_setLinkCheckMode(0);

    LMIC_startJoining();
}

inline void LoRaWAN::loop() {
    os_runloop_once();
}

/**
 * Returns true if the network stack is ready to send a message.
 */
inline boolean LoRaWAN::readyToSend() {
    // Don't try to send a message if we haven't joined yet, or a message
    // still waiting to be sent, or the reception window is still open.
    return LMIC.opmode & (OP_JOINING | OP_TXRXPEND | OP_SHUTDOWN) ? false : true;
}


// Send a message.
void LoRaWAN::sendStatus(const StatusMsgBody &status) {
    // Log the message in a readable format.
    snprintf(statusMsgBuffer, sizeof(statusMsgBuffer), statusMsgJsonFormat, status.flags.pumpRunning, status.flags.boreLowLevel, status.flags.softStartFail, status.flags.pumpOverload, status.flags.controllerRestart, status.flags.highPressure, status.flags.noFlow);
    String msg("LoRaWAN will encode and send this message: ");
    msg += statusMsgBuffer;
    log(msg);

    snprintf(statusMsgBuffer, sizeof(statusMsgBuffer), "Sending status byte: %02X", status.byte);
    log(statusMsgBuffer);
    LMIC_setTxData2(1, (uint8_t*) &status.byte, 1, 0);
}

#endif
