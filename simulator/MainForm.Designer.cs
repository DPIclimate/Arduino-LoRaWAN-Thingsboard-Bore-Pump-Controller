namespace Pump_Sim {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.formRows = new System.Windows.Forms.TableLayoutPanel();
            this.thingsboardGroup = new System.Windows.Forms.GroupBox();
            this.connDetailsTable = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtThingsboardHost = new System.Windows.Forms.TextBox();
            this.txtThingsboardPort = new System.Windows.Forms.TextBox();
            this.txtLevelSensorAccessCode = new System.Windows.Forms.TextBox();
            this.txtPumpControllerAccessCode = new System.Windows.Forms.TextBox();
            this.levelSensorGroup = new System.Windows.Forms.GroupBox();
            this.levelFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBattery = new System.Windows.Forms.TextBox();
            this.btnSendTankMessage = new System.Windows.Forms.Button();
            this.pumpCtrlGroup = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.chkbxPumpRunning = new System.Windows.Forms.CheckBox();
            this.chkbxLowLevel = new System.Windows.Forms.CheckBox();
            this.chkbxSoftStartFail = new System.Windows.Forms.CheckBox();
            this.chkbxOverload = new System.Windows.Forms.CheckBox();
            this.chkbxHighPressure = new System.Windows.Forms.CheckBox();
            this.chkbxNoFlow = new System.Windows.Forms.CheckBox();
            this.chkbxRestart = new System.Windows.Forms.CheckBox();
            this.btnSendPumpControllerMessage = new System.Windows.Forms.Button();
            this.pumpCtrlTable = new System.Windows.Forms.TableLayoutPanel();
            this.eventLog = new System.Windows.Forms.GroupBox();
            this.pauseLog = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.logList = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.timerBox = new System.Windows.Forms.Label();
            this.statusMessageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formRows.SuspendLayout();
            this.thingsboardGroup.SuspendLayout();
            this.connDetailsTable.SuspendLayout();
            this.levelSensorGroup.SuspendLayout();
            this.levelFlow.SuspendLayout();
            this.pumpCtrlGroup.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.eventLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusMessageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // formRows
            // 
            this.formRows.ColumnCount = 1;
            this.formRows.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formRows.Controls.Add(this.thingsboardGroup, 0, 0);
            this.formRows.Controls.Add(this.levelSensorGroup, 0, 1);
            this.formRows.Controls.Add(this.pumpCtrlGroup, 0, 2);
            this.formRows.Controls.Add(this.eventLog, 0, 3);
            this.formRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formRows.Location = new System.Drawing.Point(0, 0);
            this.formRows.Name = "formRows";
            this.formRows.Padding = new System.Windows.Forms.Padding(6);
            this.formRows.RowCount = 4;
            this.formRows.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formRows.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formRows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formRows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.formRows.Size = new System.Drawing.Size(946, 543);
            this.formRows.TabIndex = 0;
            // 
            // thingsboardGroup
            // 
            this.thingsboardGroup.Controls.Add(this.connDetailsTable);
            this.thingsboardGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.thingsboardGroup.Location = new System.Drawing.Point(9, 9);
            this.thingsboardGroup.Name = "thingsboardGroup";
            this.thingsboardGroup.Padding = new System.Windows.Forms.Padding(6);
            this.thingsboardGroup.Size = new System.Drawing.Size(928, 139);
            this.thingsboardGroup.TabIndex = 1;
            this.thingsboardGroup.TabStop = false;
            this.thingsboardGroup.Text = "Connection Details";
            // 
            // connDetailsTable
            // 
            this.connDetailsTable.ColumnCount = 2;
            this.connDetailsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.connDetailsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.connDetailsTable.Controls.Add(this.label1, 0, 0);
            this.connDetailsTable.Controls.Add(this.label2, 0, 1);
            this.connDetailsTable.Controls.Add(this.label3, 0, 2);
            this.connDetailsTable.Controls.Add(this.label4, 0, 3);
            this.connDetailsTable.Controls.Add(this.txtThingsboardHost, 1, 0);
            this.connDetailsTable.Controls.Add(this.txtThingsboardPort, 1, 1);
            this.connDetailsTable.Controls.Add(this.txtLevelSensorAccessCode, 1, 2);
            this.connDetailsTable.Controls.Add(this.txtPumpControllerAccessCode, 1, 3);
            this.connDetailsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connDetailsTable.Location = new System.Drawing.Point(6, 19);
            this.connDetailsTable.Name = "connDetailsTable";
            this.connDetailsTable.RowCount = 4;
            this.connDetailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connDetailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connDetailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connDetailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connDetailsTable.Size = new System.Drawing.Size(916, 114);
            this.connDetailsTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(6);
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thingsboard Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(6);
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thingsboard Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(6);
            this.label3.Size = new System.Drawing.Size(147, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Level Sensor Access Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(6);
            this.label4.Size = new System.Drawing.Size(159, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pump Controller Access Code";
            // 
            // txtThingsboardHost
            // 
            this.txtThingsboardHost.AllowDrop = true;
            this.txtThingsboardHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThingsboardHost.Location = new System.Drawing.Point(169, 4);
            this.txtThingsboardHost.Margin = new System.Windows.Forms.Padding(4);
            this.txtThingsboardHost.Name = "txtThingsboardHost";
            this.txtThingsboardHost.Size = new System.Drawing.Size(743, 20);
            this.txtThingsboardHost.TabIndex = 4;
            // 
            // txtThingsboardPort
            // 
            this.txtThingsboardPort.Location = new System.Drawing.Point(169, 32);
            this.txtThingsboardPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtThingsboardPort.Name = "txtThingsboardPort";
            this.txtThingsboardPort.Size = new System.Drawing.Size(100, 20);
            this.txtThingsboardPort.TabIndex = 5;
            // 
            // txtLevelSensorAccessCode
            // 
            this.txtLevelSensorAccessCode.Location = new System.Drawing.Point(169, 60);
            this.txtLevelSensorAccessCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtLevelSensorAccessCode.Name = "txtLevelSensorAccessCode";
            this.txtLevelSensorAccessCode.Size = new System.Drawing.Size(215, 20);
            this.txtLevelSensorAccessCode.TabIndex = 6;
            this.txtLevelSensorAccessCode.UseSystemPasswordChar = true;
            // 
            // txtPumpControllerAccessCode
            // 
            this.txtPumpControllerAccessCode.Location = new System.Drawing.Point(169, 88);
            this.txtPumpControllerAccessCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtPumpControllerAccessCode.Name = "txtPumpControllerAccessCode";
            this.txtPumpControllerAccessCode.Size = new System.Drawing.Size(215, 20);
            this.txtPumpControllerAccessCode.TabIndex = 7;
            this.txtPumpControllerAccessCode.UseSystemPasswordChar = true;
            // 
            // levelSensorGroup
            // 
            this.levelSensorGroup.AutoSize = true;
            this.levelSensorGroup.Controls.Add(this.levelFlow);
            this.levelSensorGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelSensorGroup.Location = new System.Drawing.Point(9, 163);
            this.levelSensorGroup.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.levelSensorGroup.Name = "levelSensorGroup";
            this.levelSensorGroup.Padding = new System.Windows.Forms.Padding(6);
            this.levelSensorGroup.Size = new System.Drawing.Size(928, 73);
            this.levelSensorGroup.TabIndex = 2;
            this.levelSensorGroup.TabStop = false;
            this.levelSensorGroup.Text = "Level Sensor";
            // 
            // levelFlow
            // 
            this.levelFlow.AutoSize = true;
            this.levelFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.levelFlow.Controls.Add(this.label5);
            this.levelFlow.Controls.Add(this.txtDepth);
            this.levelFlow.Controls.Add(this.label6);
            this.levelFlow.Controls.Add(this.txtTemperature);
            this.levelFlow.Controls.Add(this.label7);
            this.levelFlow.Controls.Add(this.txtBattery);
            this.levelFlow.Controls.Add(this.btnSendTankMessage);
            this.levelFlow.Location = new System.Drawing.Point(9, 22);
            this.levelFlow.Name = "levelFlow";
            this.levelFlow.Size = new System.Drawing.Size(475, 29);
            this.levelFlow.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label5.Size = new System.Drawing.Size(53, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Depth (m)";
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(62, 3);
            this.txtDepth.MaxLength = 5;
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(48, 20);
            this.txtDepth.TabIndex = 1;
            this.txtDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(12, 6, 0, 0);
            this.label6.Size = new System.Drawing.Size(94, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "Temperature (c)";
            // 
            // txtTemperature
            // 
            this.txtTemperature.Location = new System.Drawing.Point(216, 3);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(48, 20);
            this.txtTemperature.TabIndex = 3;
            this.txtTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(12, 6, 0, 0);
            this.label7.Size = new System.Drawing.Size(67, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "Battery (v)";
            // 
            // txtBattery
            // 
            this.txtBattery.Location = new System.Drawing.Point(343, 3);
            this.txtBattery.Name = "txtBattery";
            this.txtBattery.Size = new System.Drawing.Size(48, 20);
            this.txtBattery.TabIndex = 5;
            this.txtBattery.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSendTankMessage
            // 
            this.btnSendTankMessage.Location = new System.Drawing.Point(397, 3);
            this.btnSendTankMessage.Name = "btnSendTankMessage";
            this.btnSendTankMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendTankMessage.TabIndex = 6;
            this.btnSendTankMessage.Text = "Send";
            this.btnSendTankMessage.UseVisualStyleBackColor = true;
            this.btnSendTankMessage.Click += new System.EventHandler(this.tank_Click);
            // 
            // pumpCtrlGroup
            // 
            this.pumpCtrlGroup.AutoSize = true;
            this.pumpCtrlGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pumpCtrlGroup.Controls.Add(this.timerBox);
            this.pumpCtrlGroup.Controls.Add(this.label10);
            this.pumpCtrlGroup.Controls.Add(this.label9);
            this.pumpCtrlGroup.Controls.Add(this.flowLayoutPanel1);
            this.pumpCtrlGroup.Controls.Add(this.pumpCtrlTable);
            this.pumpCtrlGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pumpCtrlGroup.Location = new System.Drawing.Point(9, 251);
            this.pumpCtrlGroup.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.pumpCtrlGroup.Name = "pumpCtrlGroup";
            this.pumpCtrlGroup.Padding = new System.Windows.Forms.Padding(6);
            this.pumpCtrlGroup.Size = new System.Drawing.Size(928, 80);
            this.pumpCtrlGroup.TabIndex = 3;
            this.pumpCtrlGroup.TabStop = false;
            this.pumpCtrlGroup.Text = "Pump Controller";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(378, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Timer:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.chkbxPumpRunning);
            this.flowLayoutPanel1.Controls.Add(this.chkbxLowLevel);
            this.flowLayoutPanel1.Controls.Add(this.chkbxSoftStartFail);
            this.flowLayoutPanel1.Controls.Add(this.chkbxOverload);
            this.flowLayoutPanel1.Controls.Add(this.chkbxHighPressure);
            this.flowLayoutPanel1.Controls.Add(this.chkbxNoFlow);
            this.flowLayoutPanel1.Controls.Add(this.chkbxRestart);
            this.flowLayoutPanel1.Controls.Add(this.btnSendPumpControllerMessage);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(61, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label8.Size = new System.Drawing.Size(57, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Status Bits";
            // 
            // chkbxPumpRunning
            // 
            this.chkbxPumpRunning.AutoSize = true;
            this.chkbxPumpRunning.Location = new System.Drawing.Point(66, 3);
            this.chkbxPumpRunning.Name = "chkbxPumpRunning";
            this.chkbxPumpRunning.Size = new System.Drawing.Size(66, 17);
            this.chkbxPumpRunning.TabIndex = 1;
            this.chkbxPumpRunning.Text = "Running";
            this.chkbxPumpRunning.UseVisualStyleBackColor = true;
            // 
            // chkbxLowLevel
            // 
            this.chkbxLowLevel.AutoSize = true;
            this.chkbxLowLevel.Location = new System.Drawing.Point(138, 3);
            this.chkbxLowLevel.Name = "chkbxLowLevel";
            this.chkbxLowLevel.Size = new System.Drawing.Size(100, 17);
            this.chkbxLowLevel.TabIndex = 2;
            this.chkbxLowLevel.Text = "Bore Low Level";
            this.chkbxLowLevel.UseVisualStyleBackColor = true;
            // 
            // chkbxSoftStartFail
            // 
            this.chkbxSoftStartFail.AutoSize = true;
            this.chkbxSoftStartFail.Location = new System.Drawing.Point(244, 3);
            this.chkbxSoftStartFail.Name = "chkbxSoftStartFail";
            this.chkbxSoftStartFail.Size = new System.Drawing.Size(104, 17);
            this.chkbxSoftStartFail.TabIndex = 3;
            this.chkbxSoftStartFail.Text = "Soft Start Failure";
            this.chkbxSoftStartFail.UseVisualStyleBackColor = true;
            // 
            // chkbxOverload
            // 
            this.chkbxOverload.AutoSize = true;
            this.chkbxOverload.Location = new System.Drawing.Point(354, 3);
            this.chkbxOverload.Name = "chkbxOverload";
            this.chkbxOverload.Size = new System.Drawing.Size(99, 17);
            this.chkbxOverload.TabIndex = 4;
            this.chkbxOverload.Text = "Pump Overload";
            this.chkbxOverload.UseVisualStyleBackColor = true;
            // 
            // chkbxHighPressure
            // 
            this.chkbxHighPressure.AutoSize = true;
            this.chkbxHighPressure.Location = new System.Drawing.Point(459, 3);
            this.chkbxHighPressure.Name = "chkbxHighPressure";
            this.chkbxHighPressure.Size = new System.Drawing.Size(92, 17);
            this.chkbxHighPressure.TabIndex = 5;
            this.chkbxHighPressure.Text = "High Pressure";
            this.chkbxHighPressure.UseVisualStyleBackColor = true;
            // 
            // chkbxNoFlow
            // 
            this.chkbxNoFlow.AutoSize = true;
            this.chkbxNoFlow.Location = new System.Drawing.Point(557, 3);
            this.chkbxNoFlow.Name = "chkbxNoFlow";
            this.chkbxNoFlow.Size = new System.Drawing.Size(65, 17);
            this.chkbxNoFlow.TabIndex = 6;
            this.chkbxNoFlow.Text = "No Flow";
            this.chkbxNoFlow.UseVisualStyleBackColor = true;
            // 
            // chkbxRestart
            // 
            this.chkbxRestart.AutoSize = true;
            this.chkbxRestart.Location = new System.Drawing.Point(628, 3);
            this.chkbxRestart.Name = "chkbxRestart";
            this.chkbxRestart.Size = new System.Drawing.Size(83, 17);
            this.chkbxRestart.TabIndex = 8;
            this.chkbxRestart.Text = "Restart Flag";
            this.chkbxRestart.UseVisualStyleBackColor = true;
            // 
            // btnSendPumpControllerMessage
            // 
            this.btnSendPumpControllerMessage.Location = new System.Drawing.Point(717, 3);
            this.btnSendPumpControllerMessage.Name = "btnSendPumpControllerMessage";
            this.btnSendPumpControllerMessage.Size = new System.Drawing.Size(80, 23);
            this.btnSendPumpControllerMessage.TabIndex = 7;
            this.btnSendPumpControllerMessage.Text = "Send";
            this.btnSendPumpControllerMessage.UseVisualStyleBackColor = true;
            this.btnSendPumpControllerMessage.Click += new System.EventHandler(this.controller_Click);
            // 
            // pumpCtrlTable
            // 
            this.pumpCtrlTable.AutoSize = true;
            this.pumpCtrlTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pumpCtrlTable.ColumnCount = 1;
            this.pumpCtrlTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pumpCtrlTable.Location = new System.Drawing.Point(-9, 22);
            this.pumpCtrlTable.Name = "pumpCtrlTable";
            this.pumpCtrlTable.RowCount = 1;
            this.pumpCtrlTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pumpCtrlTable.Size = new System.Drawing.Size(0, 0);
            this.pumpCtrlTable.TabIndex = 0;
            // 
            // eventLog
            // 
            this.eventLog.Controls.Add(this.pauseLog);
            this.eventLog.Controls.Add(this.button1);
            this.eventLog.Controls.Add(this.logList);
            this.eventLog.Location = new System.Drawing.Point(9, 337);
            this.eventLog.Name = "eventLog";
            this.eventLog.Size = new System.Drawing.Size(928, 197);
            this.eventLog.TabIndex = 4;
            this.eventLog.TabStop = false;
            this.eventLog.Text = "EventL Log";
            // 
            // pauseLog
            // 
            this.pauseLog.AutoSize = true;
            this.pauseLog.Location = new System.Drawing.Point(736, 11);
            this.pauseLog.Name = "pauseLog";
            this.pauseLog.Size = new System.Drawing.Size(77, 17);
            this.pauseLog.TabIndex = 2;
            this.pauseLog.Text = "Pause Log";
            this.pauseLog.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(819, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Delete Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logList
            // 
            this.logList.FormattingEnabled = true;
            this.logList.Location = new System.Drawing.Point(6, 31);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(912, 160);
            this.logList.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(455, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Mins";
            // 
            // timerBox
            // 
            this.timerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timerBox.AutoSize = true;
            this.timerBox.Location = new System.Drawing.Point(420, 57);
            this.timerBox.Name = "timerBox";
            this.timerBox.Size = new System.Drawing.Size(13, 13);
            this.timerBox.TabIndex = 4;
            this.timerBox.Text = "0";
            this.timerBox.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // statusMessageBindingSource
            // 
            this.statusMessageBindingSource.DataSource = typeof(Pump_Sim.StatusMessage);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 543);
            this.Controls.Add(this.formRows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Bore Pump Project Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.formRows.ResumeLayout(false);
            this.formRows.PerformLayout();
            this.thingsboardGroup.ResumeLayout(false);
            this.connDetailsTable.ResumeLayout(false);
            this.connDetailsTable.PerformLayout();
            this.levelSensorGroup.ResumeLayout(false);
            this.levelSensorGroup.PerformLayout();
            this.levelFlow.ResumeLayout(false);
            this.levelFlow.PerformLayout();
            this.pumpCtrlGroup.ResumeLayout(false);
            this.pumpCtrlGroup.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.eventLog.ResumeLayout(false);
            this.eventLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusMessageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel formRows;
        private System.Windows.Forms.GroupBox thingsboardGroup;
        private System.Windows.Forms.TableLayoutPanel connDetailsTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtThingsboardHost;
        private System.Windows.Forms.TextBox txtThingsboardPort;
        private System.Windows.Forms.TextBox txtLevelSensorAccessCode;
        private System.Windows.Forms.TextBox txtPumpControllerAccessCode;
        private System.Windows.Forms.GroupBox levelSensorGroup;
        private System.Windows.Forms.FlowLayoutPanel levelFlow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBattery;
        private System.Windows.Forms.Button btnSendTankMessage;
        private System.Windows.Forms.GroupBox pumpCtrlGroup;
        private System.Windows.Forms.TableLayoutPanel pumpCtrlTable;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkbxPumpRunning;
        private System.Windows.Forms.CheckBox chkbxLowLevel;
        private System.Windows.Forms.CheckBox chkbxSoftStartFail;
        private System.Windows.Forms.CheckBox chkbxOverload;
        private System.Windows.Forms.CheckBox chkbxHighPressure;
        private System.Windows.Forms.CheckBox chkbxNoFlow;
        private System.Windows.Forms.Button btnSendPumpControllerMessage;
        protected System.Windows.Forms.TextBox txtDepth;
        private System.Windows.Forms.GroupBox eventLog;
        private System.Windows.Forms.ListBox logList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkbxRestart;
        private System.Windows.Forms.CheckBox pauseLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label timerBox;
    }
}