using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Pump_Sim {
    public partial class MainForm : Form {
        private StatusMessage statusMessage = new StatusMessage(false, false, false, false, false, false);
        private TankMessage tankMessage = new TankMessage(1.8f, 18.2f, 3.6f);

        private DownlinkCommandPoll commandPoller = new DownlinkCommandPoll();
        

        private BindingSource statusMessageBindingSource;
        private BindingSource tankMessageBindingSource;
        private BindingSource tbPropsBindingSource;

        delegate void SetTextCallback(string text);

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            commandPoller.form = this;
            // When binding a control property to a data source based upon a simple object, the args to the X.DataBindings.Add method are:
            // 1. The name of the control's property being bound, eg "Text" or "Checked".
            // 2. A reference to the binding source.
            // 3. The property of the object used to get the value for the control's property.
            // 4. Something about the value being reformatted.
            // 5. A flag to push changes made to the control's property back to the object so if the user changes the text or checks/unchecks a 
            //    box, this is reflected in the bound object's properties.

            // This binds the Thingsboard properties fields to the ThingsboardProperties singleton instance. The initial values of the text boxes
            // are set from the singletons properties but after that the bindings are from the text boxes to the singleton.
            tbPropsBindingSource = new BindingSource();
            tbPropsBindingSource.DataSource = ThingsboardProperties.getInstance();
            txtThingsboardHost.DataBindings.Add("Text", tbPropsBindingSource, "ThingsboardHost", false, DataSourceUpdateMode.OnPropertyChanged);
            txtThingsboardPort.DataBindings.Add("Text", tbPropsBindingSource, "ThingsboardPort", false, DataSourceUpdateMode.OnPropertyChanged);
            txtLevelSensorAccessCode.DataBindings.Add("Text", tbPropsBindingSource, "LevelSensorAccessToken", false, DataSourceUpdateMode.OnPropertyChanged);
            txtPumpControllerAccessCode.DataBindings.Add("Text", tbPropsBindingSource, "PumpControllerAccessToken", false, DataSourceUpdateMode.OnPropertyChanged);

            // Bind the level sensor text fields to the tankMessage properties. This is a one-way binding for now.
            // Update on validation is important here because we're working with floats. If the value doesn't parse
            // correctly, like when you've typed 1. the cursor jumps to the wrong place and you can't keep typing the
            // value you want. Only doing the update when the field has been validated avoids this problem.
            tankMessageBindingSource = new BindingSource();
            tankMessageBindingSource.DataSource = tankMessage;
            txtDepth.DataBindings.Add("Text", tankMessageBindingSource, "Depth", false, DataSourceUpdateMode.OnValidation);
            txtTemperature.DataBindings.Add("Text", tankMessageBindingSource, "Temperature", false, DataSourceUpdateMode.OnValidation);
            txtBattery.DataBindings.Add("Text", tankMessageBindingSource, "Battery", false, DataSourceUpdateMode.OnValidation);

            // Bind the checkboxes to the statusMessage properties. These statements make changes to the text boxes propogate to the statusMessage object.
            // The binding going the other way is coded in the StatusMessage class and is only done for the PumpRunning property because that is the only
            // one that will be changed by control messages.
            // Updating the data source when the property changes is ok here because they're boolean values so there's no invalid inputs.
            statusMessageBindingSource = new BindingSource();
            statusMessageBindingSource.DataSource = statusMessage;
            chkbxPumpRunning.DataBindings.Add("Checked", statusMessageBindingSource, "PumpRunning", false, DataSourceUpdateMode.OnPropertyChanged);
            chkbxLowLevel.DataBindings.Add("Checked", statusMessageBindingSource, "BoreLowLevel", false, DataSourceUpdateMode.OnPropertyChanged);
            chkbxSoftStartFail.DataBindings.Add("Checked", statusMessageBindingSource, "SoftStartFail", false, DataSourceUpdateMode.OnPropertyChanged);
            chkbxOverload.DataBindings.Add("Checked", statusMessageBindingSource, "PumpOverLoad", false, DataSourceUpdateMode.OnPropertyChanged);
            chkbxHighPressure.DataBindings.Add("Checked", statusMessageBindingSource, "HighPressure", false, DataSourceUpdateMode.OnPropertyChanged);
            chkbxNoFlow.DataBindings.Add("Checked", statusMessageBindingSource, "NoFlow", false, DataSourceUpdateMode.OnPropertyChanged);
            chkbxRestart.DataBindings.Add("Checked", statusMessageBindingSource, "ControllerRestart", false, DataSourceUpdateMode.OnPropertyChanged);

            commandPoller.Start();

            this.AddToLog("Pump Simulator Started"); 
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            ThingsboardProperties.getInstance().Save();
        }

        private void tank_Click(object sender, EventArgs e) {
            AddToLog("Tank Message Sent: " + tankMessage.PostToTB());
        }

        private void controller_Click(object sender, EventArgs e) {
            String msg = statusMessage.PostToTB();
            AddToLog("Status Message Sent: " + msg);
            JObject command = commandPoller.Command;
            if (command != null) {
                AddToLog(string.Format("Latest downlink command: {0}", command.ToString()));
                JObject x = command.Value<JObject>("params");
                int v = x.Value<int>("runPump");
                statusMessage.PumpRunning = (v == 1);
                AddToLog(string.Format("Switched pump {0} due to downlink command.", v == 1 ? "on" : "off"));
            }
        }
        // Function that adds lines to the log, keeps the log to 50 lines.
        public void AddToLog(String message)
        {
            if (!pauseLog.Checked)
            {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (this.logList.InvokeRequired)
                {
                    // Calls this function again from the correct thread
                    SetTextCallback d = new SetTextCallback(AddToLog);
                    this.Invoke(d, new object[] { message });
                }
                else
                {
                    // add this line at the top of the log
                    logList.Items.Insert(0, DateTime.Now.ToString("hh:mm tt") + ": " + message);
                    
                    // keep only a few lines in the log
                    while (logList.Items.Count > 50)
                    {
                        logList.Items.RemoveAt(logList.Items.Count - 1);
                    }
                }
            }
            Console.WriteLine(message);
        }

        // Sets the value of the timer box
        public void SetTimer(String msgTimer)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.timerBox.InvokeRequired)
            {
                // Calls this function again from the correct thread
                SetTextCallback d = new SetTextCallback(SetTimer);
                this.Invoke(d, new object[] { msgTimer });
            }
            else
            {
                // set the timer box
                timerBox.Text = msgTimer;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logList.Items.Clear();
        }
    }
}
