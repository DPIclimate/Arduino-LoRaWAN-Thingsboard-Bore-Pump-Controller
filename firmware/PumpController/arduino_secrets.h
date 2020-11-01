#ifndef ARDUINO_SECRETS_H
#define ARDUINO_SECRETS_H

#include "Arduino.h"

#if defined USE_WIFI

#define SECRET_SSID "regdfsgsd"
#define SECRET_PASS "rewfrewfwefr"

// The access token for the Thingsboard pump controller device. Can be found in the Thingsboard device definition.
static const char ACCESS_TOKEN[] = "XXXXXXXXXXXXXXXXXXXX";

#elif defined USE_LORAWAN

// Get these values from The Things Network.

// These two in LSB format.
static const uint8_t PROGMEM DEVEUI[8] = { 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX };
static const uint8_t PROGMEM APPEUI[8] = { 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX };

// This one on MSB format.
static const uint8_t PROGMEM APPKEY[16] = { 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX, 0xXX };

#endif // WiFi/LoRaWAN
#endif // ARDUINO_SECRETS_H
