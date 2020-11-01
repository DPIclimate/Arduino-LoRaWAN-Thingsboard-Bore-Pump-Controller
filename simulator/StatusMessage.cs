using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace Pump_Sim {
    class StatusMessage : INotifyPropertyChanged {
        //Bit flags for the status message sent to the pump

        private bool pumpRunning = false;

        // All of this bumpf is just to have the checkbox on the UI update automatically
        // when the PumpRunning property is changed behind the scenes.
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Boolean PumpRunning {
            get {
                return pumpRunning;
            }

            set {
                if (value != pumpRunning) {
                    pumpRunning = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Boolean BoreLowLevel { get; set; }
        public Boolean SoftStartFail { get; set; }
        public Boolean PumpOverLoad { get; set; }
        public Boolean HighPressure { get; set; }
        public Boolean NoFlow { get; set; }
        public Boolean ControllerRestart { get; set; }


        // Constructor
        public StatusMessage(Boolean _pumpRunning, Boolean _boreLowLevel, Boolean _pumpOverload, Boolean _highPressure, Boolean _noFlow, Boolean _restart) {
            //set these flags to 0 by default
            SoftStartFail = false;

            //set to passed values
            PumpRunning = _pumpRunning;
            BoreLowLevel = _boreLowLevel;
            PumpOverLoad = _pumpOverload;
            HighPressure = _highPressure;
            NoFlow = _noFlow;
            ControllerRestart = _restart;
        }

        // Method to post a status message to thingsboard
        public string PostToTB() {
            string jsonString = this.ToJSON();

            ThingsboardProperties tbp = ThingsboardProperties.getInstance();
            string url = $"https://{tbp.ThingsboardHost}:{tbp.ThingsboardPort}/api/v1/{tbp.PumpControllerAccessToken}/telemetry";
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = Program.httpClient.PostAsync(url, content).Result;

            if (response.StatusCode != HttpStatusCode.OK) {
                Console.WriteLine(response.ToString());
                System.Diagnostics.Debug.WriteLine(response.ToString());
            }

            return jsonString;
        }

        // Method to create a JSON String from out StatusMessage Object.
        private string ToJSON() {
            String result = string.Format("{{'pumpRunning':{0},'boreLowLevel':{1},'softStartFail':{2},'pumpOverload':{3},'controllerRestart':{4},'highPressure':{5},'noFlow':{6}}}",
                PumpRunning ? 1 : 0,
                BoreLowLevel ? 1 : 0,
                SoftStartFail ? 1 : 0,
                PumpOverLoad ? 1 : 0,
                ControllerRestart ? 1 : 0,
                HighPressure ? 1 : 0,
                NoFlow ? 1 : 0);

            return result;
        }
    }
}
