# This script schedules a downlink message to the device.

MQTT_HOST=thethings.meshed.com.au
APP_ID=dt_test_app
ACCESS_KEY=ttn-account-v2.xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
DEVICE_ID=pumpctrl-m0

mosquitto_pub -h $MQTT_HOST -t $APP_ID/devices/$DEVICE_ID/down -u $APP_ID -P "$ACCESS_KEY" -m '{"payload_raw":"Ef=="}'
