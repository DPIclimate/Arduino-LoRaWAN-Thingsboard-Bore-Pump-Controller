#ifdef USE_WIFI

#ifndef WIFI_NETWORK
#define WIFI_NETWORK

#include "NetworkAccess.h"

class WiFiNetwork : public NetworkAccess {
  private:
    /**
     * Connect to the Thingsboard MQTT broker if not already connected.
     */
    void connectToMQTT();

    /**
     * Process downlink RPC requests from Thingsboard. Must be static so
     * a function pointer to it can be passed to the PubSubClient library.
     */
    static void rpcRequest(char* topic, byte* payload, unsigned int length);

  public:
    /**
     * Initialise the WiFi library and set the MQTT callback function pointer.
     */
    void setup();

    /**
     * Call the WiFi library loop function to keep the stack operating.
     */
    void loop();

    /**
     * Returns true if the network stack is ready to send a message.
     */
    boolean readyToSend();

    /**
     * Translate the StatusMsgBody into a json encoded object and publish it
     * to the Thingsboard MQTT broker.
     */
    void sendStatus(const StatusMsgBody& status);
};

#endif
#endif
