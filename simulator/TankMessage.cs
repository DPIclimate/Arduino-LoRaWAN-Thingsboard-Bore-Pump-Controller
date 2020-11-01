using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Pump_Sim {
    class TankMessage {
        public float Depth { get; set; }

        public float Temperature { get; set; }

        public float Battery { get; set; }

        public TankMessage(float depth, float temperature, float battery) {
            Depth = depth;
            Temperature = temperature;
            Battery = battery;
        }

        // Method to post a tank message to Thingsboard.
        public string PostToTB() {
            string jsonString = this.ToJSON();

            ThingsboardProperties tbp = ThingsboardProperties.getInstance();
            string url = $"https://{tbp.ThingsboardHost}:{tbp.ThingsboardPort}/api/v1/{tbp.LevelSensorAccessToken}/telemetry";
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = Program.httpClient.PostAsync(url, content).Result;

            if (response.StatusCode != HttpStatusCode.OK) {
                Console.WriteLine(response.ToString());
                System.Diagnostics.Debug.WriteLine(response.ToString());
            }

            return jsonString;
        }

        private String ToJSON() {
            string json = string.Format("{{'Depth (m)':{0},'Temperature (degC)':{1},'Battery (v)':{2}}}", Depth, Temperature, Battery);
            return json;
        }
    }
}
