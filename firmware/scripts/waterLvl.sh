# This script sends a water level message as if from the DPI water tank sensor.
# The Thingsboard REST API is used to send the command.

# Get this from the Thingsboard device properties page.
ACCESS_TOKEN=xxxxxx

MSG_TEMPLATE=$(sed "s/z/$1/g" waterLvl.template)
echo $MSG_TEMPLATE
curl -d "$MSG_TEMPLATE" http://demo.thingsboard.io/api/v1/$ACCESS_TOKEN/telemetry \
  --header "Content-Type: application/json" \
  --header "Connection: close"
