using System;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pump_Sim
{
    public partial class Form1 : Form
    {

        //Create a blank status message.
        private StatusMessage pumpStatus = new StatusMessage(false, false, false, false, false);
        //Setup object to hold status message timer
        private System.Timers.Timer statusTimer;
        //variable to hold when the next status message will be sent
        private DateTime nextStatusTime;
        // minimum statusInterval between status messages
        private int minimumStatusInterval = 15;

        private string statusUrl = "https://demo.thingsboard.io/api/v1/";
        private string statusKey = "DPuxkRH9z4mEpkKskFkE";

        int statusInterval;

        //Create a tank level message
        private TankMessage tankLevel = new TankMessage(0);
        //Object to hold the tank timer
        private System.Timers.Timer tankTimer;
        //variable to hold the time of the next tank message
        private DateTime nextTankTime;
        //minimum status interval for tank messages
        private int minTankInterval;
        private int tankInterval;

        

        public Form1()
        {
            InitializeComponent();

            pumpStatus.tbUrl = statusUrl;
            pumpStatus.tbKey = statusKey;
            System.Diagnostics.Debug.WriteLine("initialising");
            pumpStatus.GetInstructionMessage(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Toggles whether the program sends a message to TB on interval.  If interval is blank, minimum interval value is used.
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (statusOnIntervalSwtich.Checked)
            {
                String pumpInterval = pumpTimerInterval.Text;
                if(!String.IsNullOrEmpty(pumpInterval))             
                {
                    if (Int16.Parse(pumpInterval) < minimumStatusInterval)
                    {
                        statusInterval = minimumStatusInterval;
                    }
                    else
                    {
                        statusInterval = Int16.Parse(pumpInterval);
                    }                   
                }
                else
                {
                    statusInterval = minimumStatusInterval;
                }
                
                SendAtInterval();
            }
            else
            {
                statusTimer.Stop();
            }          
        }

        //Toggles pumprunning flag on status message
        private void PumpOnCheck_CheckedChanged(object sender, EventArgs e)
        {
            pumpStatus.pumpRunning = pumpOnCheck.Checked;
        }

        //Toggles boreLow flag on status message
        private void BoreLowCheck_CheckedChanged(object sender, EventArgs e)
        {
            pumpStatus.boreLowLevel = boreLowCheck.Checked;
        }

        //Toggles pumpoverload flag on status message
        private void PumpOverloadCheck_CheckedChanged(object sender, EventArgs e)
        {
            pumpStatus.pumpOverLoad = pumpOverloadCheck.Checked;
        }

        //Toggles highPressure flag on status message
        private void HighPressureCheck_CheckedChanged(object sender, EventArgs e)
        {
            pumpStatus.highPressure = highPressureCheck.Checked;
        }

        //Toggles noFlow flag on status message
        private void NoFlowCheck_CheckedChanged(object sender, EventArgs e)
        {
            pumpStatus.noFlow = noFlowCheck.Checked;
        }

        //Sends status message to TB immediately.
        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Sending Message");
            SendStatusToTB();
        }
        
        //Function that calls pumpStatus Post to TB
        private void SendStatusToTB()
        {
            SetLastMessageBox(pumpStatus.PostToTB());
        }

        //sets the interval, and enables the timer
        private void SendAtInterval()
        {
            statusTimer = new System.Timers.Timer(statusInterval * 1000);
            statusTimer.Elapsed += OnTimedEvent;
            nextStatusTime = DateTime.Now.AddSeconds(statusInterval);
            SetStatusTimerBox(nextStatusTime.ToString("h:mm:ss tt"));
            statusTimer.Enabled = true;            
        }

        //function that runs every status message interval
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            SendStatusToTB();
            nextStatusTime = DateTime.Now.AddSeconds(statusInterval);
            SetStatusTimerBox(nextStatusTime.ToString("h:mm:ss tt"));
        }

        //helper for accessing textbox text from multiple threads
        delegate void SetTextCallback(string text);

        //sets the status timer box.  Handles multiple threads
        private void SetStatusTimerBox(string text)
        {
            if (this.nextMessageTime.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatusTimerBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.nextMessageTime.Text = text;
            }
        }

        //sets the last message box.  Handles multiple threads
        private void SetLastMessageBox(string text)
        {
            if (this.lastStatusBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetLastMessageBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lastStatusBox.Text = text;
            }
        }

        public void SetLastMessageReceivedBox(string text)
        {
            if (this.lastMessageReceived.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetLastMessageReceivedBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lastMessageReceived.Text = text;
            }
        }

        //
        //*********************TANK CONTROLS************************
        //

        //tank messsage send now button clicked
        private void Button2_Click(object sender, EventArgs e)
        {
            SendTankToTB();
        }

        private void SendTankToTB()
        {
            tankLevel.tbUrl = "https://demo.thingsboard.io/api/v1/";
            tankLevel.tbKey = "cN6NyM2KKUxDIKA36qez";
            tankLevel.PostToTB();
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (statusOnIntervalSwtich.Checked)
            {
                String tankIntervalText = tankTimerInterval.Text;
                if (!String.IsNullOrEmpty(tankIntervalText))
                {
                    if (Int16.Parse(tankIntervalText) < minTankInterval)
                    {
                        tankInterval = minTankInterval;
                    }
                    else
                    {
                        tankInterval = Int16.Parse(tankIntervalText);
                    }
                }
                else
                {
                    tankInterval = minimumStatusInterval;
                }

                SendAtTankInterval();
            }
            else
            {
                tankTimer.Stop();
            }
        }

        //sets the interval, and enables the timer
        private void SendAtTankInterval()
        {
            tankTimer = new System.Timers.Timer(tankInterval * 1000);
            tankTimer.Elapsed += OnTimedTankEvent;
            nextTankTime = DateTime.Now.AddSeconds(tankInterval);
            SetTankTimerBox(nextStatusTime.ToString("h:mm:ss tt"));
            tankTimer.Enabled = true;
        }

        //function that runs every tank message interval
        private void OnTimedTankEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            SendTankToTB();
            nextTankTime = DateTime.Now.AddSeconds(tankInterval);
            SetTankTimerBox(nextTankTime.ToString("h:mm:ss tt"));
        }

        //sets the tank timer box.  Handles multiple threads
        private void SetTankTimerBox(string text)
        {
            if (this.nextTankMessageTime.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTankTimerBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.nextTankMessageTime.Text = text;
            }
        }

        //sets the last message box.  Handles multiple threads
        private void SetLastTankMessageBox(string text)
        {
            if (this.lastTankMessageBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetLastTankMessageBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lastTankMessageBox.Text = text;
            }
        }

        private void MaskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            tankLevel.depthM = Convert.ToDouble(tankLevelBox.Text);
        }

    }
}
