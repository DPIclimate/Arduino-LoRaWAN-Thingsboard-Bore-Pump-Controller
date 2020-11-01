#ifndef NETWORK_ACCESS_H
#define NETWORK_ACCESS_H

#include <Arduino.h>

// These are used by the WiFi stack to send the json message and by
// the LoRaWAN stack to log a json version of the message being sent.
extern char statusMsgBuffer[132];
extern const char *statusMsgJsonFormat;

// This is a reference to the callback function in the main sketch file.
// Subclasses must call this function when they receive a command from
// Thingsboard.
extern void processCommand(const uint8_t *data, const size_t length);

/**
 * The interface for both WiFi and LoRaWAN communications to Thingsboard.
 *
 * The sketch uses this interface to talk to whichever network
 * stack is compiled in.
 */
class NetworkAccess {
public:

    /**
     * This method should be called from the sketch setup() function.
     */
    virtual void setup() = 0;

    /**
     * This method should be called every time the sketch loop() function is called.
     */
    virtual void loop() = 0;

    /**
     * Returns true if the network stack is ready to send a message.
     */
    virtual boolean readyToSend() = 0;

    /**
     * Send the status bit flags to Thingsboard.
     */
    virtual void sendStatus(const StatusMsgBody &status);
};

#endif
