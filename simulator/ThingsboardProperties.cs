namespace Pump_Sim {
    class ThingsboardProperties {
        private static ThingsboardProperties instance = new ThingsboardProperties();

        public string ThingsboardHost { get; set; }
        public int ThingsboardPort { get; set; }
        public string LevelSensorAccessToken { get; set; }
        public string PumpControllerAccessToken { get; set; }

        public static ThingsboardProperties getInstance() {
            return instance;
        }
        private ThingsboardProperties() {
            ThingsboardHost = Properties.Settings.Default.TBHost;
            ThingsboardPort = Properties.Settings.Default.TBPort;
            LevelSensorAccessToken = Properties.Settings.Default.LevelSensorAccessToken;
            PumpControllerAccessToken = Properties.Settings.Default.PumpControllerAccessToken;
        }

        public void Save() {
            Properties.Settings.Default.TBHost = ThingsboardHost;
            Properties.Settings.Default.TBPort = ThingsboardPort;
            Properties.Settings.Default.LevelSensorAccessToken = LevelSensorAccessToken;
            Properties.Settings.Default.PumpControllerAccessToken = PumpControllerAccessToken;

            Properties.Settings.Default.Save();
        }
    }
}
