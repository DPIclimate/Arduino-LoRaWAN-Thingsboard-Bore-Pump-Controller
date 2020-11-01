#include "config.h"
#include "PumpIO.h"

/*** These are the values that will be given to callers in getStatus. */
static StatusMsgBody currentPins;

/** These are the newly read values from the input pins, used to see if a debounce cycle is required for any of them. */
static StatusMsgBody newPins;

/** These are the pins currently being debounced. */
static StatusMsgBody debounceMask;

// These vars hold the time a debouncing operation started for a given pin. */
static unsigned long boreLowLevelMs = 0;
static unsigned long softStartFailMs = 0;
static unsigned long pumpOverloadMs = 0;
static unsigned long highPressureMs = 0;
static unsigned long noFlowMs = 0;

/** Give half a second for an input line to settle down after it has changed before using it's value. */
static unsigned long debounceMs = 500;

PumpIO::PumpIO(uint32_t boreLoveLevelPI, uint32_t softStartFailPI, uint32_t pumpOverloadPI, uint32_t highPressurePI, uint32_t noFlowPI, uint32_t pumpControlPI) {
    // Set pin ID's
    _boreLoveLevelPI = boreLoveLevelPI;
    _softStartFailPI = softStartFailPI;
    _pumpOverloadPI = pumpOverloadPI;
    _highPressurePI = highPressurePI;
    _noFlowPI = noFlowPI;
    _pumpControlPI = pumpControlPI;

    // Setup the pinmode for each pin
    pinMode(boreLoveLevelPI, INPUT_PULLUP);
    pinMode(softStartFailPI, INPUT_PULLUP);
    pinMode(pumpOverloadPI, INPUT_PULLUP);
    pinMode(highPressurePI, INPUT_PULLUP);
    pinMode(noFlowPI, INPUT_PULLUP);
    pinMode(pumpControlPI, OUTPUT);

    getStatus(currentPins);
    newPins.byte = currentPins.byte;
    debounceMask.byte = 0;
}

// Polls the pins and writes the status of the pump to a StatusMsgBody object
void PumpIO::getStatus(StatusMsgBody &pumpStatus) {

    pumpStatus.flags.pumpRunning = _pumpRunning ? 1 : 0;

    // Input pins are high when 'off' and grounded when the condition is 'true'.
    newPins.flags.boreLowLevel = digitalRead(_boreLoveLevelPI) == LOW;
    newPins.flags.softStartFail = digitalRead(_softStartFailPI) == LOW;
    newPins.flags.pumpOverload = digitalRead(_pumpOverloadPI) == LOW;
    newPins.flags.highPressure = digitalRead(_highPressurePI) == LOW;
    newPins.flags.noFlow = digitalRead(_noFlowPI) == LOW;

    unsigned long now = millis();

    if ( ! debounceMask.flags.boreLowLevel) {
        if (currentPins.flags.boreLowLevel != newPins.flags.boreLowLevel) {
            debounceMask.flags.boreLowLevel = 1;
            boreLowLevelMs = now;
        }
    } else {
        if ((now - boreLowLevelMs) > debounceMs) {
            currentPins.flags.boreLowLevel = newPins.flags.boreLowLevel;
            debounceMask.flags.boreLowLevel = 0;
        }
    }

    if ( ! debounceMask.flags.softStartFail) {
        if (currentPins.flags.softStartFail != newPins.flags.softStartFail) {
            debounceMask.flags.softStartFail = 1;
            softStartFailMs = now;
        }
    } else {
        if ((now - softStartFailMs) > debounceMs) {
            currentPins.flags.softStartFail = newPins.flags.softStartFail;
            debounceMask.flags.softStartFail = 0;
        }
    }

    if ( ! debounceMask.flags.pumpOverload) {
        if (currentPins.flags.pumpOverload != newPins.flags.pumpOverload) {
            debounceMask.flags.pumpOverload = 1;
            pumpOverloadMs = now;
        }
    } else {
        if ((now - pumpOverloadMs) > debounceMs) {
            currentPins.flags.pumpOverload = newPins.flags.pumpOverload;
            debounceMask.flags.pumpOverload = 0;
        }
    }

    if ( ! debounceMask.flags.highPressure) {
        if (currentPins.flags.highPressure != newPins.flags.highPressure) {
            debounceMask.flags.highPressure = 1;
            highPressureMs = now;
        }
    } else {
        if ((now - highPressureMs) > debounceMs) {
            currentPins.flags.highPressure = newPins.flags.highPressure;
            debounceMask.flags.highPressure = 0;
        }
    }

    if ( ! debounceMask.flags.noFlow) {
        if (currentPins.flags.noFlow != newPins.flags.noFlow) {
            debounceMask.flags.noFlow = 1;
            noFlowMs = now;
        }
    } else {
        if ((now - noFlowMs) > debounceMs) {
            currentPins.flags.noFlow = newPins.flags.noFlow;
            debounceMask.flags.noFlow = 0;
        }
    }

    pumpStatus.flags.boreLowLevel = currentPins.flags.boreLowLevel;
    pumpStatus.flags.softStartFail = currentPins.flags.softStartFail;
    pumpStatus.flags.pumpOverload = currentPins.flags.pumpOverload;
    pumpStatus.flags.highPressure = currentPins.flags.highPressure;
    pumpStatus.flags.noFlow = currentPins.flags.noFlow;
    pumpStatus.flags.controllerRestart = 0;
}

// Sends high to pump control pin
void PumpIO::startPump() {
    _pumpRunning = true;
    digitalWrite(_pumpControlPI, HIGH);
    log("Switched pump on.");
}

// Sends low to pump control pin
void PumpIO::stopPump() {
    _pumpRunning = false;
    digitalWrite(_pumpControlPI, LOW);
    log("Switched pump off.");
}
