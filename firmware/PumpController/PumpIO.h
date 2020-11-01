#ifndef PUMPIO_H
#define PUMPIO_H

#include <Arduino.h>

/**
 * The status message is one byte. Use the flags member of the union to set
 * the individual status flags and the byte member to get the combined flag
 * values for the message body.
 */
typedef union {
  /** Use these struct members to set or clear a flag. */
  struct {
    uint8_t pumpRunning : 1;
    uint8_t boreLowLevel : 1;
    uint8_t softStartFail : 1;
    uint8_t pumpOverload : 1;
    uint8_t controllerRestart : 1;
    uint8_t highPressure : 1;
    uint8_t noFlow : 1;
  } flags;

  /** The combined bit flags as a byte value. */
  uint8_t byte;
} StatusMsgBody;

/**
 * This class hides the electrical details of switching the pump on and off, and reading the status flags.
 */
class PumpIO {
  public:
    /**
     * Construct an instance of the PumpIO class using the provided IO pins.
     *
     * All input pins are high when the condition is false, and held low when the condition is in effect. However, the
     * bit flags in the StatusMsgBody are set so they are true when the condition in in effect, and false otherwise.
     *
     * @param boreLoveLevelPin the pin number to read the bore low level signal (input pin).
     * @param softStartFailPin the pin number to read the soft start fail signal (input pin).
     * @param pumpOverloadPin the pin number to read the pump overload signal (input pin).
     * @param highPressurePin the pin number to read the high pressure signal (input pin).
     * @param noFlowPin the pin number to read the no flow signal (input pin).
     * @param pumpControlPin the pin used to control the pump relay (output pin).
     */
    PumpIO(uint32_t boreLoveLevelPin, uint32_t softStartFailPin, uint32_t pumpOverloadPin, uint32_t highPressurePin, uint32_t noFlowPin, uint32_t pumpControlPin);
    /**
     * Set the flags in the StatusMsgBody object to reflect the current state of the input pins and the pump running flag.
     *
     * @param StatusMsgBody A reference to the StatusMsgBody object to update.
     */
    void getStatus(StatusMsgBody& pumpStatus);

    /**
     * Start the pump, hold a high signal on the output pin.
     */
    void startPump();

    /**
     * Stop the pump, set the output pin to low.
     */
    void stopPump();

  private:
    // Pin ID's
    uint32_t _boreLoveLevelPI;
    uint32_t _softStartFailPI;
    uint32_t _pumpOverloadPI;
    uint32_t _highPressurePI;
    uint32_t _noFlowPI;
    uint32_t _pumpControlPI;

    /** This field is set by startPump and stopPump to track whether the pump is meant to be running. */
    bool _pumpRunning = false;
};

#endif
