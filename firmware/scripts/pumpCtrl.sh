JWT_TOKEN=xxxxxxxx

DEVICE_ID=xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

MSG_TEMPLATE=$(sed "s/z/$1/g" pumpCtrl.template)
echo $MSG_TEMPLATE

curl -d "$MSG_TEMPLATE" http://demo.thingsboard.io/api/plugins/rpc/oneway/$DEVICE_ID \
--header "Content-Type:application/json" \
--header "X-Authorization: Bearer $JWT_TOKEN"
