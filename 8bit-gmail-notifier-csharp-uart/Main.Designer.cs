namespace eightBitGmailNotifierCsharpUart
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.grpSerialPort = new System.Windows.Forms.GroupBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.lblParity = new System.Windows.Forms.Label();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblPortName = new System.Windows.Forms.Label();
            this.btnSerialStop = new System.Windows.Forms.Button();
            this.btnSerialStart = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.stsGmail = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripGmail = new System.Windows.Forms.StatusStrip();
            this.stsPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpLogging = new System.Windows.Forms.GroupBox();
            this.txtLogger = new System.Windows.Forms.TextBox();
            this.grpGmail = new System.Windows.Forms.GroupBox();
            this.cmbAutoTime = new System.Windows.Forms.ComboBox();
            this.lblAutoTime = new System.Windows.Forms.Label();
            this.cbAuto = new System.Windows.Forms.CheckBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.BtnLogin = new System.Windows.Forms.Button();
            this.grpSerialPort.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.statusStripGmail.SuspendLayout();
            this.grpLogging.SuspendLayout();
            this.grpGmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 2400;
            this.serialPort.Parity = System.IO.Ports.Parity.Odd;
            this.serialPort.StopBits = System.IO.Ports.StopBits.Two;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // grpSerialPort
            // 
            this.grpSerialPort.Controls.Add(this.cmbParity);
            this.grpSerialPort.Controls.Add(this.cmbStopBits);
            this.grpSerialPort.Controls.Add(this.cmbDataBits);
            this.grpSerialPort.Controls.Add(this.cmbBaudRate);
            this.grpSerialPort.Controls.Add(this.cmbPort);
            this.grpSerialPort.Controls.Add(this.lblParity);
            this.grpSerialPort.Controls.Add(this.lblStopBits);
            this.grpSerialPort.Controls.Add(this.lblDataBits);
            this.grpSerialPort.Controls.Add(this.lblBaudRate);
            this.grpSerialPort.Controls.Add(this.lblPortName);
            this.grpSerialPort.Controls.Add(this.btnSerialStop);
            this.grpSerialPort.Controls.Add(this.btnSerialStart);
            this.grpSerialPort.Location = new System.Drawing.Point(294, 12);
            this.grpSerialPort.Name = "grpSerialPort";
            this.grpSerialPort.Size = new System.Drawing.Size(170, 205);
            this.grpSerialPort.TabIndex = 3;
            this.grpSerialPort.TabStop = false;
            this.grpSerialPort.Text = "Serial port";
            // 
            // cmbParity
            // 
            this.cmbParity.CausesValidation = false;
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.Items.AddRange(new object[] {
            "Odd",
            "Even",
            "Mark",
            "Space",
            "None"});
            this.cmbParity.Location = new System.Drawing.Point(86, 134);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(76, 21);
            this.cmbParity.TabIndex = 12;
            this.cmbParity.TabStop = false;
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.CausesValidation = false;
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cmbStopBits.Location = new System.Drawing.Point(86, 107);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(76, 21);
            this.cmbStopBits.TabIndex = 11;
            this.cmbStopBits.TabStop = false;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.CausesValidation = false;
            this.cmbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cmbDataBits.Location = new System.Drawing.Point(86, 80);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(76, 21);
            this.cmbDataBits.TabIndex = 10;
            this.cmbDataBits.TabStop = false;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.CausesValidation = false;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.cmbBaudRate.Location = new System.Drawing.Point(86, 53);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(76, 21);
            this.cmbBaudRate.TabIndex = 9;
            this.cmbBaudRate.TabStop = false;
            // 
            // cmbPort
            // 
            this.cmbPort.CausesValidation = false;
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.Location = new System.Drawing.Point(86, 26);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(76, 21);
            this.cmbPort.TabIndex = 8;
            this.cmbPort.TabStop = false;
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(15, 137);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(36, 13);
            this.lblParity.TabIndex = 7;
            this.lblParity.Text = "Parity:";
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(15, 110);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(51, 13);
            this.lblStopBits.TabIndex = 6;
            this.lblStopBits.Text = "Stop bits:";
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(15, 83);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(52, 13);
            this.lblDataBits.TabIndex = 5;
            this.lblDataBits.Text = "Data bits:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(15, 56);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(56, 13);
            this.lblBaudRate.TabIndex = 4;
            this.lblBaudRate.Text = "Baud rate:";
            // 
            // lblPortName
            // 
            this.lblPortName.AutoSize = true;
            this.lblPortName.Location = new System.Drawing.Point(15, 29);
            this.lblPortName.Name = "lblPortName";
            this.lblPortName.Size = new System.Drawing.Size(29, 13);
            this.lblPortName.TabIndex = 3;
            this.lblPortName.Text = "Port:";
            // 
            // btnSerialStop
            // 
            this.btnSerialStop.Enabled = false;
            this.btnSerialStop.Location = new System.Drawing.Point(87, 173);
            this.btnSerialStop.Name = "btnSerialStop";
            this.btnSerialStop.Size = new System.Drawing.Size(75, 23);
            this.btnSerialStop.TabIndex = 2;
            this.btnSerialStop.Text = "Stop";
            this.btnSerialStop.UseVisualStyleBackColor = true;
            this.btnSerialStop.Click += new System.EventHandler(this.BtnSerialStop_Click);
            // 
            // btnSerialStart
            // 
            this.btnSerialStart.Location = new System.Drawing.Point(6, 173);
            this.btnSerialStart.Name = "btnSerialStart";
            this.btnSerialStart.Size = new System.Drawing.Size(75, 23);
            this.btnSerialStart.TabIndex = 1;
            this.btnSerialStart.Text = "Start";
            this.btnSerialStart.UseVisualStyleBackColor = true;
            this.btnSerialStart.Click += new System.EventHandler(this.BtnSerialStart_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsGmail});
            this.statusStrip.Location = new System.Drawing.Point(0, 267);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(684, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            this.statusStrip.Visible = false;
            // 
            // stsGmail
            // 
            this.stsGmail.Name = "stsGmail";
            this.stsGmail.Size = new System.Drawing.Size(150, 17);
            this.stsGmail.Text = "Gmail status: Disconnected";
            // 
            // statusStripGmail
            // 
            this.statusStripGmail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsPort});
            this.statusStripGmail.Location = new System.Drawing.Point(0, 366);
            this.statusStripGmail.Name = "statusStripGmail";
            this.statusStripGmail.Size = new System.Drawing.Size(471, 22);
            this.statusStripGmail.SizingGrip = false;
            this.statusStripGmail.TabIndex = 5;
            this.statusStripGmail.Text = "statusStripGmail";
            // 
            // stsPort
            // 
            this.stsPort.Name = "stsPort";
            this.stsPort.Size = new System.Drawing.Size(105, 17);
            this.stsPort.Text = "Port status: Closed";
            // 
            // grpLogging
            // 
            this.grpLogging.Controls.Add(this.txtLogger);
            this.grpLogging.Location = new System.Drawing.Point(12, 12);
            this.grpLogging.Name = "grpLogging";
            this.grpLogging.Size = new System.Drawing.Size(276, 351);
            this.grpLogging.TabIndex = 6;
            this.grpLogging.TabStop = false;
            this.grpLogging.Text = "Logger";
            // 
            // txtLogger
            // 
            this.txtLogger.Location = new System.Drawing.Point(6, 19);
            this.txtLogger.Multiline = true;
            this.txtLogger.Name = "txtLogger";
            this.txtLogger.ReadOnly = true;
            this.txtLogger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogger.Size = new System.Drawing.Size(262, 326);
            this.txtLogger.TabIndex = 3;
            // 
            // grpGmail
            // 
            this.grpGmail.Controls.Add(this.BtnLogin);
            this.grpGmail.Controls.Add(this.cmbAutoTime);
            this.grpGmail.Controls.Add(this.lblAutoTime);
            this.grpGmail.Controls.Add(this.cbAuto);
            this.grpGmail.Controls.Add(this.btnCheck);
            this.grpGmail.Location = new System.Drawing.Point(294, 223);
            this.grpGmail.Name = "grpGmail";
            this.grpGmail.Size = new System.Drawing.Size(170, 140);
            this.grpGmail.TabIndex = 7;
            this.grpGmail.TabStop = false;
            this.grpGmail.Text = "Gmail";
            // 
            // cmbAutoTime
            // 
            this.cmbAutoTime.CausesValidation = false;
            this.cmbAutoTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutoTime.Enabled = false;
            this.cmbAutoTime.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "15",
            "30",
            "60"});
            this.cmbAutoTime.Location = new System.Drawing.Point(115, 79);
            this.cmbAutoTime.Name = "cmbAutoTime";
            this.cmbAutoTime.Size = new System.Drawing.Size(47, 21);
            this.cmbAutoTime.TabIndex = 13;
            this.cmbAutoTime.TabStop = false;
            // 
            // lblAutoTime
            // 
            this.lblAutoTime.AutoSize = true;
            this.lblAutoTime.Location = new System.Drawing.Point(6, 82);
            this.lblAutoTime.Name = "lblAutoTime";
            this.lblAutoTime.Size = new System.Drawing.Size(68, 13);
            this.lblAutoTime.TabIndex = 9;
            this.lblAutoTime.Text = "Auto-time (s):";
            // 
            // cbAuto
            // 
            this.cbAuto.AutoSize = true;
            this.cbAuto.Enabled = false;
            this.cbAuto.Location = new System.Drawing.Point(115, 115);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.Size = new System.Drawing.Size(47, 17);
            this.cbAuto.TabIndex = 8;
            this.cbAuto.Text = "auto";
            this.cbAuto.UseVisualStyleBackColor = true;
            this.cbAuto.CheckedChanged += new System.EventHandler(this.CbAuto_CheckedChanged);
            // 
            // btnCheck
            // 
            this.btnCheck.Enabled = false;
            this.btnCheck.Location = new System.Drawing.Point(9, 111);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(9, 31);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(153, 23);
            this.BtnLogin.TabIndex = 14;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 388);
            this.Controls.Add(this.grpGmail);
            this.Controls.Add(this.grpLogging);
            this.Controls.Add(this.statusStripGmail);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.grpSerialPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Serial Communication with AVR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.grpSerialPort.ResumeLayout(false);
            this.grpSerialPort.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.statusStripGmail.ResumeLayout(false);
            this.statusStripGmail.PerformLayout();
            this.grpLogging.ResumeLayout(false);
            this.grpLogging.PerformLayout();
            this.grpGmail.ResumeLayout(false);
            this.grpGmail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.GroupBox grpSerialPort;
        private System.Windows.Forms.Button btnSerialStop;
        private System.Windows.Forms.Button btnSerialStart;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblPortName;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.StatusStrip statusStripGmail;
        private System.Windows.Forms.ToolStripStatusLabel stsGmail;
        private System.Windows.Forms.ToolStripStatusLabel stsPort;
        private System.Windows.Forms.GroupBox grpLogging;
        private System.Windows.Forms.TextBox txtLogger;
        private System.Windows.Forms.GroupBox grpGmail;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.CheckBox cbAuto;
        private System.Windows.Forms.Label lblAutoTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox cmbAutoTime;
        private System.Windows.Forms.Button BtnLogin;
    }
}

