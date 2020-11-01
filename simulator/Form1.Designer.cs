using System;
using System.Windows.Forms;

namespace Pump_Sim
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pumpTimerInterval = new System.Windows.Forms.MaskedTextBox();
            this.statusOnIntervalSwtich = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tankTimerInterval = new System.Windows.Forms.MaskedTextBox();
            this.tankLevelBox = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.pumpOnCheck = new System.Windows.Forms.CheckBox();
            this.boreLowCheck = new System.Windows.Forms.CheckBox();
            this.pumpOverloadCheck = new System.Windows.Forms.CheckBox();
            this.highPressureCheck = new System.Windows.Forms.CheckBox();
            this.noFlowCheck = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lastStatusBox = new System.Windows.Forms.TextBox();
            this.lastMessageReceived = new System.Windows.Forms.TextBox();
            this.lastTankMessageBox = new System.Windows.Forms.TextBox();
            this.nextMessageTime = new System.Windows.Forms.TextBox();
            this.nextTankMessageTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pumpTimerInterval
            // 
            this.pumpTimerInterval.Location = new System.Drawing.Point(200, 85);
            this.pumpTimerInterval.Mask = "00000";
            this.pumpTimerInterval.Name = "pumpTimerInterval";
            this.pumpTimerInterval.Size = new System.Drawing.Size(34, 20);
            this.pumpTimerInterval.TabIndex = 0;
            this.pumpTimerInterval.ValidatingType = typeof(int);
            this.pumpTimerInterval.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // statusOnIntervalSwtich
            // 
            this.statusOnIntervalSwtich.AutoSize = true;
            this.statusOnIntervalSwtich.Location = new System.Drawing.Point(250, 87);
            this.statusOnIntervalSwtich.Name = "statusOnIntervalSwtich";
            this.statusOnIntervalSwtich.Size = new System.Drawing.Size(106, 17);
            this.statusOnIntervalSwtich.TabIndex = 1;
            this.statusOnIntervalSwtich.Text = "Send On Interval";
            this.statusOnIntervalSwtich.UseVisualStyleBackColor = true;
            this.statusOnIntervalSwtich.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Interval (Sec)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(335, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bore Pump";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(573, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Send Now";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(324, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tank Sensor";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(633, 303);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Send Now";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Interval (Sec)";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(521, 307);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(106, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Send On Interval";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // tankTimerInterval
            // 
            this.tankTimerInterval.Location = new System.Drawing.Point(480, 304);
            this.tankTimerInterval.Mask = "00000";
            this.tankTimerInterval.Name = "tankTimerInterval";
            this.tankTimerInterval.Size = new System.Drawing.Size(35, 20);
            this.tankTimerInterval.TabIndex = 7;
            this.tankTimerInterval.ValidatingType = typeof(int);
            // 
            // tankLevelBox
            // 
            this.tankLevelBox.Location = new System.Drawing.Point(136, 303);
            this.tankLevelBox.Name = "tankLevelBox";
            this.tankLevelBox.Size = new System.Drawing.Size(35, 20);
            this.tankLevelBox.TabIndex = 11;
            this.tankLevelBox.TextChanged += new System.EventHandler(this.MaskedTextBox3_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Starting Level";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Location = new System.Drawing.Point(191, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 40);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Level Changes";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(135, 16);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(71, 17);
            this.radioButton5.TabIndex = 7;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Simulated";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(64, 16);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 17);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Random";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 16);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(52, 17);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Static";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(124, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Last Message Sent:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(325, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Last Message Sent:";
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(-5, 252);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(810, 2);
            this.label11.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(394, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Last Message Received:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(636, 394);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 44);
            this.button4.TabIndex = 25;
            this.button4.Text = "Send All Now";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // pumpOnCheck
            // 
            this.pumpOnCheck.AutoSize = true;
            this.pumpOnCheck.Location = new System.Drawing.Point(174, 57);
            this.pumpOnCheck.Name = "pumpOnCheck";
            this.pumpOnCheck.Size = new System.Drawing.Size(70, 17);
            this.pumpOnCheck.TabIndex = 26;
            this.pumpOnCheck.Tag = "statusFlags";
            this.pumpOnCheck.Text = "Pump On";
            this.pumpOnCheck.UseVisualStyleBackColor = true;
            this.pumpOnCheck.CheckedChanged += new System.EventHandler(this.PumpOnCheck_CheckedChanged);
            // 
            // boreLowCheck
            // 
            this.boreLowCheck.AutoSize = true;
            this.boreLowCheck.Location = new System.Drawing.Point(250, 57);
            this.boreLowCheck.Name = "boreLowCheck";
            this.boreLowCheck.Size = new System.Drawing.Size(71, 17);
            this.boreLowCheck.TabIndex = 27;
            this.boreLowCheck.Tag = "statusFlags";
            this.boreLowCheck.Text = "Bore Low";
            this.boreLowCheck.UseVisualStyleBackColor = true;
            this.boreLowCheck.CheckedChanged += new System.EventHandler(this.BoreLowCheck_CheckedChanged);
            // 
            // pumpOverloadCheck
            // 
            this.pumpOverloadCheck.AutoSize = true;
            this.pumpOverloadCheck.Location = new System.Drawing.Point(327, 57);
            this.pumpOverloadCheck.Name = "pumpOverloadCheck";
            this.pumpOverloadCheck.Size = new System.Drawing.Size(99, 17);
            this.pumpOverloadCheck.TabIndex = 29;
            this.pumpOverloadCheck.Tag = "statusFlags";
            this.pumpOverloadCheck.Text = "Pump Overload";
            this.pumpOverloadCheck.UseVisualStyleBackColor = true;
            this.pumpOverloadCheck.CheckedChanged += new System.EventHandler(this.PumpOverloadCheck_CheckedChanged);
            // 
            // highPressureCheck
            // 
            this.highPressureCheck.AutoSize = true;
            this.highPressureCheck.Location = new System.Drawing.Point(432, 57);
            this.highPressureCheck.Name = "highPressureCheck";
            this.highPressureCheck.Size = new System.Drawing.Size(92, 17);
            this.highPressureCheck.TabIndex = 31;
            this.highPressureCheck.Tag = "statusFlags";
            this.highPressureCheck.Text = "High Pressure";
            this.highPressureCheck.UseVisualStyleBackColor = true;
            this.highPressureCheck.CheckedChanged += new System.EventHandler(this.HighPressureCheck_CheckedChanged);
            // 
            // noFlowCheck
            // 
            this.noFlowCheck.AutoSize = true;
            this.noFlowCheck.Location = new System.Drawing.Point(530, 57);
            this.noFlowCheck.Name = "noFlowCheck";
            this.noFlowCheck.Size = new System.Drawing.Size(65, 17);
            this.noFlowCheck.TabIndex = 32;
            this.noFlowCheck.Tag = "statusFlags";
            this.noFlowCheck.Text = "No Flow";
            this.noFlowCheck.UseVisualStyleBackColor = true;
            this.noFlowCheck.CheckedChanged += new System.EventHandler(this.NoFlowCheck_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Next Message: ";
            // 
            // lastStatusBox
            // 
            this.lastStatusBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lastStatusBox.Location = new System.Drawing.Point(127, 134);
            this.lastStatusBox.Multiline = true;
            this.lastStatusBox.Name = "lastStatusBox";
            this.lastStatusBox.ReadOnly = true;
            this.lastStatusBox.Size = new System.Drawing.Size(253, 105);
            this.lastStatusBox.TabIndex = 35;
            // 
            // lastMessageReceived
            // 
            this.lastMessageReceived.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lastMessageReceived.Location = new System.Drawing.Point(397, 134);
            this.lastMessageReceived.Multiline = true;
            this.lastMessageReceived.Name = "lastMessageReceived";
            this.lastMessageReceived.ReadOnly = true;
            this.lastMessageReceived.Size = new System.Drawing.Size(268, 105);
            this.lastMessageReceived.TabIndex = 36;
            // 
            // lastTankMessageBox
            // 
            this.lastTankMessageBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lastTankMessageBox.Location = new System.Drawing.Point(432, 344);
            this.lastTankMessageBox.Name = "lastTankMessageBox";
            this.lastTankMessageBox.Size = new System.Drawing.Size(263, 20);
            this.lastTankMessageBox.TabIndex = 37;
            // 
            // nextMessageTime
            // 
            this.nextMessageTime.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.nextMessageTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nextMessageTime.Location = new System.Drawing.Point(458, 83);
            this.nextMessageTime.Name = "nextMessageTime";
            this.nextMessageTime.ReadOnly = true;
            this.nextMessageTime.Size = new System.Drawing.Size(81, 20);
            this.nextMessageTime.TabIndex = 38;
            // 
            // nextTankMessageTime
            // 
            this.nextTankMessageTime.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.nextTankMessageTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nextTankMessageTime.Location = new System.Drawing.Point(207, 345);
            this.nextTankMessageTime.Name = "nextTankMessageTime";
            this.nextTankMessageTime.ReadOnly = true;
            this.nextTankMessageTime.Size = new System.Drawing.Size(81, 20);
            this.nextTankMessageTime.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Next Message: ";
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(21, 18);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(75, 23);
            this.settingsButton.TabIndex = 41;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 474);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.nextTankMessageTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nextMessageTime);
            this.Controls.Add(this.lastTankMessageBox);
            this.Controls.Add(this.lastMessageReceived);
            this.Controls.Add(this.lastStatusBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.noFlowCheck);
            this.Controls.Add(this.highPressureCheck);
            this.Controls.Add(this.pumpOverloadCheck);
            this.Controls.Add(this.boreLowCheck);
            this.Controls.Add(this.pumpOnCheck);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tankLevelBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.tankTimerInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusOnIntervalSwtich);
            this.Controls.Add(this.pumpTimerInterval);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.MaskedTextBox pumpTimerInterval;
        private System.Windows.Forms.CheckBox statusOnIntervalSwtich;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.MaskedTextBox tankTimerInterval;
        private System.Windows.Forms.MaskedTextBox tankLevelBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox pumpOnCheck;
        private System.Windows.Forms.CheckBox boreLowCheck;
        private System.Windows.Forms.CheckBox pumpOverloadCheck;
        private System.Windows.Forms.CheckBox highPressureCheck;
        private System.Windows.Forms.CheckBox noFlowCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox lastStatusBox;
        private System.Windows.Forms.TextBox lastMessageReceived;
        private System.Windows.Forms.TextBox lastTankMessageBox;
        private TextBox nextMessageTime;
        private TextBox nextTankMessageTime;
        private Label label7;
        private Button settingsButton;
    }
}

