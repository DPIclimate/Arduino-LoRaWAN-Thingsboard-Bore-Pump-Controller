#ifdef USE_LORAWAN

#ifndef BPC_LORAWAN
#define BPC_LORAWAN

#include "NetworkAccess.h"

class LoRaWAN : public NetworkAccess {
  public:
    // NetworkAccess overrides.
    void setup();
    void loop();

    /**
     * Returns true if the network stack is ready to send a message.
     */
    boolean readyToSend();

    void sendStatus(const StatusMsgBody& status);
};

#endif
#endif
