using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading;

namespace Pump_Sim {
    /// <summary>
    /// This class runs a background thread to poll Thingsboard for RPC requests.
    /// </summary>
    class DownlinkCommandPoll {
        // The polling thread sets this. When it has bene read it should
        // be set back to null so the same command isn't seen twice. The
        // form should process the command after it sends a status update
        // to simulate the way commands only come down after a telemetry
        // uplink.
        private JObject rpcCommand = null;
        public MainForm form;

        public JObject Command {
            get {
                lock (this) {
                    var tmp = rpcCommand;
                    rpcCommand = null;
                    return tmp;
                }
            }
        }

        /// <summary>
        /// Start the polling thread as a background thread. The thread will be
        /// automatically terminated when the application exits.
        /// </summary>
        public void Start() {
            // Start a background thread to poll for RPC calls from Thingsboard.
            Thread t = new Thread(new ThreadStart(rpcListenerProc));
            t.IsBackground = true;
            t.Start();
            Console.WriteLine("Started downlink command poll thread.");
        }

        /// <summary>
        /// This method runs in a separate thread and continually polls Thingsboard for
        /// RPC calls.
        /// </summary>
        private async void rpcListenerProc() {
            ThingsboardProperties tbp = ThingsboardProperties.getInstance();

            while (true) {
                try {
                    string url = $"https://{tbp.ThingsboardHost}:{tbp.ThingsboardPort}/api/v1/{tbp.PumpControllerAccessToken}/rpc?timeout=20000";
                    HttpResponseMessage response = await Program.httpClient.GetAsync(url);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode) {
                        // Synchronise access to the RpcCommand field due to two
                        // different threads working with it.
                        lock (this) {
                            rpcCommand = JObject.Parse(responseBody);
                            form.AddToLog("Downlink received but not yet delivered: " + responseBody);
                            if ((Boolean)rpcCommand["params"]["timerOn"])
                            {
                                form.SetTimer((String)rpcCommand["params"]["timer"]);
                            }
                            else
                            {
                                form.SetTimer("0");
                            }
                        }
                    }
                } catch (HttpRequestException e) {
                    form.AddToLog("Exception Caught!");
                    form.AddToLog($"Message :{e.Message}");
                }
            }
        }
    }
}
