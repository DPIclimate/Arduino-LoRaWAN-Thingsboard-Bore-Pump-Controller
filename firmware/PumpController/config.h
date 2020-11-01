#ifndef CONFIG_H
#define CONFIG_H

#define USE_LORAWAN

#include "PumpIO.h"

const int LOW_BORE_PIN = 0;
const int SOFT_START_PIN = 1;
const int PUMP_OVERLOAD_PIN = 11;
const int HIGH_PRESSURE_PIN = 12;
const int NO_FLOW_PIN = 10;
const int PUMP_CONTROL_PIN = 13; // Use built-in LED while testing.

/**
 * Write a message to Serial.
 *
 * @param msg the message to write.
 */
inline void log(const char *msg) {
    Serial.println(msg);
}

/**
 * Write a message to Serial.
 *
 * @param msg the message to write.
 */
inline void log(const String &msg) {
    log(msg.c_str());
}

#if defined USE_WIFI
#include "WiFiNetwork.h"
#define FIRMWARE_VERSION "0.1.wifi"

#define MQTT_HOST "thingsboard-staging.farmdecisiontech.net.au"
#define MQTT_PORT 1883

#elif defined USE_LORAWAN
#include "LoRaWAN.h"
#define FIRMWARE_VERSION "0.1.lora"

#endif  // WiFi / LoRaWAN

#endif  // CONFIG_H
