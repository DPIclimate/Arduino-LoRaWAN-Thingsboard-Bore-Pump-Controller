# This script subscribes to the uplink messages topic and prints them out.

MQTT_HOST=thethings.meshed.com.au
APP_ID=dt_test_app
ACCESS_KEY=ttn-account-v2.xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
mosquitto_sub -h $MQTT_HOST -t '+/devices/+/up' -u $APP_ID -P "$ACCESS_KEY" -v
