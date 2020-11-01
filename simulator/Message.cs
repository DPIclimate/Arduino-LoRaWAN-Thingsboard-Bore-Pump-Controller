using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pump_Sim
{
    class Message
    {        
        [JsonIgnore]// Ignored when converting to JSON
        public String tbUrl { get; set; }
        [JsonIgnore]// Ignored when converting to JSON
        public String tbKey { get; set; }

        //Method to post message to thingsboard
        public string PostToTB()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.tbUrl + this.tbKey + "/telemetry");
            client.DefaultRequestHeaders.Accept.Clear();
            string jsonString = this.ToJSON();
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress, content).Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                //do something about this error
            }
            return jsonString;
        }

        // Convert Object to JSON
        private String ToJSON()
        {
            return JsonSerializer.Serialize<object>(this);
        }
        
        // Print method for debugging
        public void ToPrint()
        {
            System.Diagnostics.Debug.WriteLine(JsonSerializer.Serialize<object>(this));
        }
    }
}
