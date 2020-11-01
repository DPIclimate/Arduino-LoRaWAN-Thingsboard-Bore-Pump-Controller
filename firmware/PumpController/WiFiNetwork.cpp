// config.h determines whether to use WiFi or LoRaWAN.
#include "config.h"

#ifdef USE_WIFI

#include <WiFi101.h>
#include <PubSubClient.h>
#include <ArduinoJson.h>
#include "arduino_secrets.h"

static constexpr char ssid[] = SECRET_SSID;
static constexpr char pass[] = SECRET_PASS;

static int status = WL_IDLE_STATUS;

static constexpr char firmwareVersion[] = FIRMWARE_VERSION;

// The MQTT broker connection details.
static constexpr char server[] = MQTT_HOST;
static constexpr int port = MQTT_PORT;

// The id of the previous RPC command processed. Used so a duplicate request can be ignored.
static long lastMqttRpcId = -1;

static WiFiClient wifi;
static PubSubClient mqtt(wifi);

static StaticJsonDocument<256> doc;

static constexpr unsigned int RPC_CONTENT_MAX = 127;
static char rpcContent[RPC_CONTENT_MAX + 1];

/** True if a new command has been received since the last uplink. */
static boolean newCommand = false;

/** The most recent downlink command. */
static uint8_t lastCommand[3];
static size_t lastCommandLength;

/**
 * Attempt to connect to the Thingsboard MQTT broker if not already connected.
 *
 * Does not return until a connection is made.
 */
void WiFiNetwork::connectToMQTT() {
    while (!mqtt.connected()) {
        log("Attempting MQTT connection.");
        if (mqtt.connect("pumpController", ACCESS_TOKEN, NULL)) {
            log("Connected.");

            // Get RPC requests from this topic.
            mqtt.subscribe("v1/devices/me/rpc/request/+");

            // Update client attributes each time we connect.
            char attrMsg[64];
            snprintf(attrMsg, sizeof(attrMsg), "{\"firmware\":\"%s\"}", firmwareVersion);
            if (!mqtt.publish("v1/devices/me/attributes", attrMsg)) {
                log("Publish attributes failed");
            }
        } else {
            String msg("MQTT connection failed, rc = ");
            msg += mqtt.state();
            msg += ". Try again in 5 seconds.";
            log(msg);
            delay(5000);
        }
    }
}

/**
 * Set up the WiFi stack and the MQTT client.
 */
void WiFiNetwork::setup() {
    log(firmwareVersion);

    // Configure pins for Adafruit ATWINC1500 Feather
    WiFi.setPins(8, 7, 4, 2);
    WiFi.maxLowPowerMode();

    // check for the presence of the shield:
    if (WiFi.status() == WL_NO_SHIELD) {
        log("WiFi not present");
        // don't continue:
        while (true)
            ;
    }

    // attempt to connect to WiFi network:
    while (status != WL_CONNECTED) {
        log("Attempting to connect to WiFi");
        // Connect to WPA/WPA2 network. Change this line if using open or WEP network:
        status = WiFi.begin(ssid, pass);
        // wait 10 seconds for connection:
        delay(10000);
    }

    log("Connected to wifi");

    mqtt.setServer(server, port);
    mqtt.setCallback(WiFiNetwork::rpcRequest);

    connectToMQTT();
}

/**
 * Maintain the MQTT connection and poll for downlinks.
 */
void WiFiNetwork::loop() {
    if (!mqtt.connected()) {
        connectToMQTT();
    }

    mqtt.loop();
}

inline boolean WiFiNetwork::readyToSend() {
    return status == WL_CONNECTED && mqtt.connected();
}

/**
 * Send a status message to Thingsboard.
 *
 * The status parameter will be transformed to the necessary
 * format for sending via MQTT.
 *
 * In order to simulate the LoRaWAN class A delayed delivery of a downlink
 * this method calls the sketch's processCommand function to deliver the
 * most recently received downlink.
 *
 * @param status the content to send in the status message.
 */
void WiFiNetwork::sendStatus(const StatusMsgBody &status) {
    snprintf(statusMsgBuffer, sizeof(statusMsgBuffer), statusMsgJsonFormat, status.flags.pumpRunning, status.flags.boreLowLevel,
            status.flags.softStartFail, status.flags.pumpOverload, status.flags.controllerRestart, status.flags.highPressure,
            status.flags.noFlow);
    String msg("Sending status: ");
    msg += statusMsgBuffer;
    log(msg);

    // Have to use the beginPublish/write... sequence because the json is
    // to long to for a single publish call.
    size_t len = strlen(statusMsgBuffer);
    if (!mqtt.beginPublish("v1/devices/me/telemetry", len, false)) {
        log("beginPublish failed.");
        return;
    }

    if (!mqtt.write((const uint8_t*) statusMsgBuffer, 64)) {
        log("First write failed.");
        return;
    }

    if (!mqtt.write((const uint8_t*) &statusMsgBuffer[64], len - 64)) {
        log("Second write failed.");
        return;
    }

    if (!mqtt.endPublish()) {
        log("endPublish failed.");
    }

    if (newCommand) {
        // Simulate the delayed delivery of the downlink by giving it to the
        // sketch after the next uplink.
        log("Delivering downlink command.");
        processCommand(&lastCommand[0], lastCommandLength);
        newCommand = false;
    }
}

/**
 * Process RPC commands from Thingsboard.
 *
 * This static method is called by the PubSubClient MQTT library when an
 * RPC request is received from Thingsboard.
 *
 * @param topic a c-style null terminated string...
 * @param payload a byte buffer owned by the caller that may be overwritten
 * when this method returns.
 * @param length the number of bytes in payload that contain valid data.
 */
void WiFiNetwork::rpcRequest(char *topic, byte *payload, unsigned int length) {
    if (length > RPC_CONTENT_MAX) {
        log("RPC content too long");
        return;
    }

    strncpy(rpcContent, (const char*) payload, length);
    // strncpy does not add a trailing null because it is not finding one
    // in the source string - the MQTT library does not null terminate the
    // payload.
    rpcContent[length] = 0x00;

    String msg("rpcRequest: ");
    msg += topic;
    msg += " - ";
    msg += length;
    msg += " - ";
    msg += rpcContent;
    log(msg.c_str());

    String topicStr(topic);
    auto idx = topicStr.lastIndexOf("/");
    if (idx < 1) {
        // The URI seems to be malformed so we can't get the request id from it.
        log("Invalid topic URI, ignoring RPC request.");
        return;
    }

    String idStr = topicStr.substring(idx + 1);
    long id = strtol(idStr.c_str(), NULL, 10);
    if (id == lastMqttRpcId) {
        log("Duplicate RPC id, igorning RPC request.");
        return;
    }

    // Set this now, if the parsing fails then it will probably
    // always fail for a given message so no point trying to
    // parse the same message if it comes back.
    lastMqttRpcId = id;

    DeserializationError err = deserializeJson(doc, rpcContent);
    if (err) {
        log("Error deserializing:");
        log(err.c_str());
        return;
    }

    // The message we get from Thingsboard switch control.
    // {"method":"ignored","params":{"runPump":1,"timerOn":true,"timer":"110"}}
    // {"method":"ignored","params":{"runPump":0}}

    const char *op = doc["method"];

    const bool running = doc["params"]["runPump"];

    uint16_t timeout = 0;
    const bool timerFlag = doc["params"]["timerOn"];
    if (timerFlag) {
      timeout = doc["params"]["timer"];
    }

    String logMsg("Received op = ");
    logMsg += op;
    logMsg += ", running = ";
    logMsg += running;
    logMsg += ", timerFlag = ";
    logMsg += timerFlag;
    logMsg += ", timeout = ";
    logMsg += timeout;
    log(logMsg);

    // Transform the request into whatever standard we decide to use
    // in the main pump controller sketch, then store it until the
    // sketch asks to send a status request. The command may be
    // overwritten to simulate new downlinks being scheduled to replace
    // an existing one in TTN.
    lastCommand[0] = 0;
    lastCommandLength = 1;
    if (running) {
        lastCommand[0] = 1;
        if (timerFlag) {
          lastCommand[0] = 3;
          lastCommand[1] = (timeout >> 8) & 0xff;
          lastCommand[2] = timeout & 0xff;
          lastCommandLength = 3;
        }
    }

    log("Encoded command:");
    for (int i = 0; i < lastCommandLength; i++) {
        if (lastCommand[i] < 0x10) {
            Serial.print("0");
        }
        Serial.print(lastCommand[i], HEX);
        Serial.print(" ");
    }
    Serial.println();
    log("Withholding until next uplink.");
            
    newCommand = true;
}

#endif
