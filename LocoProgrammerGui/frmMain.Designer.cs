namespace LocoProgrammer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.chkHandshake = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnRescan = new System.Windows.Forms.Button();
            this.cmbSerialSpeed = new System.Windows.Forms.ComboBox();
            this.cmbSerialPorts = new System.Windows.Forms.ComboBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.rbLocoTCP = new System.Windows.Forms.RadioButton();
            this.rbLocoSerial = new System.Windows.Forms.RadioButton();
            this.grpDevices = new System.Windows.Forms.GroupBox();
            this.lvDevices = new System.Windows.Forms.ListView();
            this.columnDeviceAddr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDeviceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDeviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDeviceMnfg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDeviceNodeID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSWVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHWVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFreeMem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabDeviceConfig = new System.Windows.Forms.TabControl();
            this.tabGenConfig = new System.Windows.Forms.TabPage();
            this.lblBootloaderVersion = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.lstCompileFlags = new System.Windows.Forms.ListBox();
            this.chkAllowFactoryDefaults = new System.Windows.Forms.CheckBox();
            this.btnReboot = new System.Windows.Forms.Button();
            this.lblHexDevice = new System.Windows.Forms.Label();
            this.lblPWMModulesOnline = new System.Windows.Forms.Label();
            this.lblExternalNVRAM = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbS88Reporting = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbButtonBehavior = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtDeviceAddr = new LocoProgrammerUserControls.ucButtonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeviceName = new LocoProgrammerUserControls.ucButtonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstBoxI2CDevices = new System.Windows.Forms.ListBox();
            this.btnI2CScan = new System.Windows.Forms.Button();
            this.tabLNS88Config = new System.Windows.Forms.TabPage();
            this.grpDevConfig = new System.Windows.Forms.GroupBox();
            this.lblLastAddr = new System.Windows.Forms.Label();
            this.btnWatchS88_LN = new System.Windows.Forms.Button();
            this.btnWatchS88 = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUseDottedLoc = new System.Windows.Forms.Button();
            this.txtLocModuleLow = new System.Windows.Forms.TextBox();
            this.txtLocModuleHigh = new System.Windows.Forms.TextBox();
            this.txtPins_Local = new LocoProgrammerUserControls.ucButtonTextBox();
            this.txtModuleAddress_Local = new LocoProgrammerUserControls.ucButtonTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCalcPinCount = new System.Windows.Forms.Button();
            this.txtPins = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUseDotted = new System.Windows.Forms.Button();
            this.txtModuleLow = new System.Windows.Forms.TextBox();
            this.txtModuleHigh = new System.Windows.Forms.TextBox();
            this.txtModuleCount = new LocoProgrammerUserControls.ucButtonTextBox();
            this.txtModuleAddress = new LocoProgrammerUserControls.ucButtonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabLNI2CConfig = new System.Windows.Forms.TabPage();
            this.chkUsePCF8574T = new System.Windows.Forms.CheckBox();
            this.lblLastAddrI2C = new System.Windows.Forms.Label();
            this.btnWatchS88_I2C = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.btnCalcPinCount_I2C = new System.Windows.Forms.Button();
            this.txtPins_I2C = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.btnUseDottedI2C = new System.Windows.Forms.Button();
            this.txtModuleLowI2C = new System.Windows.Forms.TextBox();
            this.txtModuleHighI2C = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtModuleCount_I2C = new LocoProgrammerUserControls.ucButtonTextBox();
            this.txtModuleAddress_I2C = new LocoProgrammerUserControls.ucButtonTextBox();
            this.tabPWMpinConfig = new System.Windows.Forms.TabPage();
            this.grpPWMOutput = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnWriteAspectChain = new System.Windows.Forms.Button();
            this.lblBoard = new System.Windows.Forms.Label();
            this.btnExportConfig = new System.Windows.Forms.Button();
            this.btnToggleAspects = new System.Windows.Forms.Button();
            this.btnClosedGreen = new System.Windows.Forms.Button();
            this.btnThrownRed = new System.Windows.Forms.Button();
            this.btnReadAspectChain = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImportConfig = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.txtPinConfig = new System.Windows.Forms.TextBox();
            this.btnReadAll = new System.Windows.Forms.Button();
            this.btnClearConfig = new System.Windows.Forms.Button();
            this.chkReadOnPinSelect = new System.Windows.Forms.CheckBox();
            this.grpAspectGreen = new System.Windows.Forms.GroupBox();
            this.lblAspectG3 = new System.Windows.Forms.LinkLabel();
            this.txtData1Green3 = new System.Windows.Forms.TextBox();
            this.txtData0Green3 = new System.Windows.Forms.TextBox();
            this.cmbInstrGreen3 = new System.Windows.Forms.ComboBox();
            this.lblAspectG2 = new System.Windows.Forms.LinkLabel();
            this.txtData1Green2 = new System.Windows.Forms.TextBox();
            this.txtData0Green2 = new System.Windows.Forms.TextBox();
            this.cmbInstrGreen2 = new System.Windows.Forms.ComboBox();
            this.lblAspectG1 = new System.Windows.Forms.LinkLabel();
            this.txtData1Green1 = new System.Windows.Forms.TextBox();
            this.txtData0Green1 = new System.Windows.Forms.TextBox();
            this.cmbInstrGreen1 = new System.Windows.Forms.ComboBox();
            this.lblAspectG0 = new System.Windows.Forms.LinkLabel();
            this.txtData1Green0 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtData0Green0 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbInstrGreen0 = new System.Windows.Forms.ComboBox();
            this.btnWritePin = new System.Windows.Forms.Button();
            this.btnReadPin = new System.Windows.Forms.Button();
            this.chkPinInvertOutput = new System.Windows.Forms.CheckBox();
            this.chkUsePreviousPin = new System.Windows.Forms.CheckBox();
            this.txtPinDCCAddress = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.grpAspectRed = new System.Windows.Forms.GroupBox();
            this.lblAspectR3 = new System.Windows.Forms.LinkLabel();
            this.txtData1Red3 = new System.Windows.Forms.TextBox();
            this.txtData0Red3 = new System.Windows.Forms.TextBox();
            this.cmbInstrRed3 = new System.Windows.Forms.ComboBox();
            this.lblAspectR2 = new System.Windows.Forms.LinkLabel();
            this.txtData1Red2 = new System.Windows.Forms.TextBox();
            this.txtData0Red2 = new System.Windows.Forms.TextBox();
            this.cmbInstrRed2 = new System.Windows.Forms.ComboBox();
            this.lblAspectR1 = new System.Windows.Forms.LinkLabel();
            this.txtData1Red1 = new System.Windows.Forms.TextBox();
            this.txtData0Red1 = new System.Windows.Forms.TextBox();
            this.cmbInstrRed1 = new System.Windows.Forms.ComboBox();
            this.lblAspectR0 = new System.Windows.Forms.LinkLabel();
            this.txtData1Red0 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtData0Red0 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbInstrRed0 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbPWMPin = new System.Windows.Forms.ComboBox();
            this.tabVL530L0 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLastValSensor7 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtVL53Sensor7val = new LocoProgrammerUserControls.ucButtonTextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txtLastValSensor6 = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtVL53Sensor6val = new LocoProgrammerUserControls.ucButtonTextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtLastValSensor5 = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtVL53Sensor5val = new LocoProgrammerUserControls.ucButtonTextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txtLastValSensor4 = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.txtVL53Sensor4val = new LocoProgrammerUserControls.ucButtonTextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtLastValSensor3 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtVL53Sensor3val = new LocoProgrammerUserControls.ucButtonTextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtLastValSensor2 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtVL53Sensor2val = new LocoProgrammerUserControls.ucButtonTextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtLastValSensor1 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtVL53Sensor1val = new LocoProgrammerUserControls.ucButtonTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtLastValSensor0 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtVL53Sensor0val = new LocoProgrammerUserControls.ucButtonTextBox();
            this.lblSensor0 = new System.Windows.Forms.Label();
            this.btnRefreshVL530values = new System.Windows.Forms.Button();
            this.btnWatchVL53 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnUseDottedVL53 = new System.Windows.Forms.Button();
            this.txtVL53ModuleLow = new System.Windows.Forms.TextBox();
            this.txtVL53ModuleHigh = new System.Windows.Forms.TextBox();
            this.txtModuleAddress_VL53 = new LocoProgrammerUserControls.ucButtonTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripCopyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.grpConnection.SuspendLayout();
            this.grpDevices.SuspendLayout();
            this.tabDeviceConfig.SuspendLayout();
            this.tabGenConfig.SuspendLayout();
            this.tabLNS88Config.SuspendLayout();
            this.grpDevConfig.SuspendLayout();
            this.tabLNI2CConfig.SuspendLayout();
            this.tabPWMpinConfig.SuspendLayout();
            this.grpPWMOutput.SuspendLayout();
            this.grpAspectGreen.SuspendLayout();
            this.grpAspectRed.SuspendLayout();
            this.tabVL530L0.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.chkHandshake);
            this.grpConnection.Controls.Add(this.btnStop);
            this.grpConnection.Controls.Add(this.btnGo);
            this.grpConnection.Controls.Add(this.btnDisconnect);
            this.grpConnection.Controls.Add(this.btnRescan);
            this.grpConnection.Controls.Add(this.cmbSerialSpeed);
            this.grpConnection.Controls.Add(this.cmbSerialPorts);
            this.grpConnection.Controls.Add(this.txtPort);
            this.grpConnection.Controls.Add(this.txtServer);
            this.grpConnection.Controls.Add(this.btnConnect);
            this.grpConnection.Controls.Add(this.rbLocoTCP);
            this.grpConnection.Controls.Add(this.rbLocoSerial);
            this.grpConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConnection.Location = new System.Drawing.Point(0, 0);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(919, 77);
            this.grpConnection.TabIndex = 8;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Loconet Connection";
            // 
            // chkHandshake
            // 
            this.chkHandshake.AutoSize = true;
            this.chkHandshake.Location = new System.Drawing.Point(340, 18);
            this.chkHandshake.Name = "chkHandshake";
            this.chkHandshake.Size = new System.Drawing.Size(175, 17);
            this.chkHandshake.TabIndex = 12;
            this.chkHandshake.Text = "No Handshake (For Intellibox 2)";
            this.chkHandshake.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(828, 43);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(828, 20);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(438, 20);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(116, 22);
            this.btnDisconnect.TabIndex = 9;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Visible = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnRescan
            // 
            this.btnRescan.Enabled = false;
            this.btnRescan.Location = new System.Drawing.Point(560, 43);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(116, 22);
            this.btnRescan.TabIndex = 8;
            this.btnRescan.Text = "Rescan";
            this.btnRescan.UseVisualStyleBackColor = true;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // cmbSerialSpeed
            // 
            this.cmbSerialSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialSpeed.FormattingEnabled = true;
            this.cmbSerialSpeed.Items.AddRange(new object[] {
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbSerialSpeed.Location = new System.Drawing.Point(247, 15);
            this.cmbSerialSpeed.Name = "cmbSerialSpeed";
            this.cmbSerialSpeed.Size = new System.Drawing.Size(88, 21);
            this.cmbSerialSpeed.TabIndex = 7;
            // 
            // cmbSerialPorts
            // 
            this.cmbSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialPorts.FormattingEnabled = true;
            this.cmbSerialPorts.Location = new System.Drawing.Point(130, 15);
            this.cmbSerialPorts.Name = "cmbSerialPorts";
            this.cmbSerialPorts.Size = new System.Drawing.Size(113, 21);
            this.cmbSerialPorts.TabIndex = 6;
            this.cmbSerialPorts.Enter += new System.EventHandler(this.cmbSerialPorts_Enter);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(305, 42);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(60, 20);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "5550";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(130, 42);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(169, 20);
            this.txtServer.TabIndex = 4;
            this.txtServer.Text = "raspitrain";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(438, 43);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(116, 22);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // rbLocoTCP
            // 
            this.rbLocoTCP.AutoSize = true;
            this.rbLocoTCP.Location = new System.Drawing.Point(13, 43);
            this.rbLocoTCP.Name = "rbLocoTCP";
            this.rbLocoTCP.Size = new System.Drawing.Size(112, 17);
            this.rbLocoTCP.TabIndex = 1;
            this.rbLocoTCP.Text = "Loconet over TCP";
            this.rbLocoTCP.UseVisualStyleBackColor = true;
            this.rbLocoTCP.CheckedChanged += new System.EventHandler(this.rbLocoMethod_CheckedChanged);
            // 
            // rbLocoSerial
            // 
            this.rbLocoSerial.AutoSize = true;
            this.rbLocoSerial.Location = new System.Drawing.Point(13, 20);
            this.rbLocoSerial.Name = "rbLocoSerial";
            this.rbLocoSerial.Size = new System.Drawing.Size(93, 17);
            this.rbLocoSerial.TabIndex = 0;
            this.rbLocoSerial.Text = "Loconet Serial";
            this.rbLocoSerial.UseVisualStyleBackColor = true;
            this.rbLocoSerial.CheckedChanged += new System.EventHandler(this.rbLocoMethod_CheckedChanged);
            // 
            // grpDevices
            // 
            this.grpDevices.Controls.Add(this.lvDevices);
            this.grpDevices.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDevices.Location = new System.Drawing.Point(0, 77);
            this.grpDevices.Name = "grpDevices";
            this.grpDevices.Size = new System.Drawing.Size(919, 153);
            this.grpDevices.TabIndex = 9;
            this.grpDevices.TabStop = false;
            this.grpDevices.Text = "Devices";
            // 
            // lvDevices
            // 
            this.lvDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDeviceAddr,
            this.columnDeviceType,
            this.columnDeviceName,
            this.columnDeviceMnfg,
            this.columnDeviceNodeID,
            this.columnSWVersion,
            this.columnHWVersion,
            this.columnFreeMem});
            this.lvDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDevices.FullRowSelect = true;
            this.lvDevices.HideSelection = false;
            this.lvDevices.Location = new System.Drawing.Point(3, 16);
            this.lvDevices.MultiSelect = false;
            this.lvDevices.Name = "lvDevices";
            this.lvDevices.Size = new System.Drawing.Size(913, 134);
            this.lvDevices.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvDevices.TabIndex = 9;
            this.lvDevices.UseCompatibleStateImageBehavior = false;
            this.lvDevices.View = System.Windows.Forms.View.Details;
            this.lvDevices.SelectedIndexChanged += new System.EventHandler(this.lvDevices_SelectedIndexChanged);
            this.lvDevices.DoubleClick += new System.EventHandler(this.lvDevices_DoubleClick);
            // 
            // columnDeviceAddr
            // 
            this.columnDeviceAddr.Text = "Device Addres";
            this.columnDeviceAddr.Width = 90;
            // 
            // columnDeviceType
            // 
            this.columnDeviceType.Text = "Type";
            this.columnDeviceType.Width = 50;
            // 
            // columnDeviceName
            // 
            this.columnDeviceName.Text = "Name";
            this.columnDeviceName.Width = 100;
            // 
            // columnDeviceMnfg
            // 
            this.columnDeviceMnfg.Text = "Vendor";
            this.columnDeviceMnfg.Width = 100;
            // 
            // columnDeviceNodeID
            // 
            this.columnDeviceNodeID.Text = "Node ID Number";
            this.columnDeviceNodeID.Width = 100;
            // 
            // columnSWVersion
            // 
            this.columnSWVersion.Text = "SW Version";
            this.columnSWVersion.Width = 70;
            // 
            // columnHWVersion
            // 
            this.columnHWVersion.Text = "HW Version";
            this.columnHWVersion.Width = 70;
            // 
            // columnFreeMem
            // 
            this.columnFreeMem.Text = "Free Memory";
            this.columnFreeMem.Width = 80;
            // 
            // tabDeviceConfig
            // 
            this.tabDeviceConfig.Controls.Add(this.tabGenConfig);
            this.tabDeviceConfig.Controls.Add(this.tabLNS88Config);
            this.tabDeviceConfig.Controls.Add(this.tabLNI2CConfig);
            this.tabDeviceConfig.Controls.Add(this.tabPWMpinConfig);
            this.tabDeviceConfig.Controls.Add(this.tabVL530L0);
            this.tabDeviceConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDeviceConfig.Enabled = false;
            this.tabDeviceConfig.Location = new System.Drawing.Point(0, 230);
            this.tabDeviceConfig.Name = "tabDeviceConfig";
            this.tabDeviceConfig.SelectedIndex = 0;
            this.tabDeviceConfig.Size = new System.Drawing.Size(919, 386);
            this.tabDeviceConfig.TabIndex = 11;
            this.tabDeviceConfig.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlConfig_Selecting);
            // 
            // tabGenConfig
            // 
            this.tabGenConfig.Controls.Add(this.lblBootloaderVersion);
            this.tabGenConfig.Controls.Add(this.label52);
            this.tabGenConfig.Controls.Add(this.label51);
            this.tabGenConfig.Controls.Add(this.lstCompileFlags);
            this.tabGenConfig.Controls.Add(this.chkAllowFactoryDefaults);
            this.tabGenConfig.Controls.Add(this.btnReboot);
            this.tabGenConfig.Controls.Add(this.lblHexDevice);
            this.tabGenConfig.Controls.Add(this.lblPWMModulesOnline);
            this.tabGenConfig.Controls.Add(this.lblExternalNVRAM);
            this.tabGenConfig.Controls.Add(this.label19);
            this.tabGenConfig.Controls.Add(this.label18);
            this.tabGenConfig.Controls.Add(this.label10);
            this.tabGenConfig.Controls.Add(this.cmbS88Reporting);
            this.tabGenConfig.Controls.Add(this.label6);
            this.tabGenConfig.Controls.Add(this.cmbButtonBehavior);
            this.tabGenConfig.Controls.Add(this.btnReset);
            this.tabGenConfig.Controls.Add(this.txtDeviceAddr);
            this.tabGenConfig.Controls.Add(this.label4);
            this.tabGenConfig.Controls.Add(this.txtDeviceName);
            this.tabGenConfig.Controls.Add(this.label3);
            this.tabGenConfig.Controls.Add(this.lstBoxI2CDevices);
            this.tabGenConfig.Controls.Add(this.btnI2CScan);
            this.tabGenConfig.Location = new System.Drawing.Point(4, 22);
            this.tabGenConfig.Name = "tabGenConfig";
            this.tabGenConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenConfig.Size = new System.Drawing.Size(911, 360);
            this.tabGenConfig.TabIndex = 2;
            this.tabGenConfig.Text = "Device Settings";
            this.tabGenConfig.UseVisualStyleBackColor = true;
            // 
            // lblBootloaderVersion
            // 
            this.lblBootloaderVersion.AutoSize = true;
            this.lblBootloaderVersion.Location = new System.Drawing.Point(495, 187);
            this.lblBootloaderVersion.Name = "lblBootloaderVersion";
            this.lblBootloaderVersion.Size = new System.Drawing.Size(13, 13);
            this.lblBootloaderVersion.TabIndex = 51;
            this.lblBootloaderVersion.Text = "?";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(377, 187);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(99, 13);
            this.label52.TabIndex = 50;
            this.label52.Text = "Bootloader Version:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(379, 138);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(80, 13);
            this.label51.TabIndex = 49;
            this.label51.Text = "Firmware Flags:";
            // 
            // lstCompileFlags
            // 
            this.lstCompileFlags.FormattingEnabled = true;
            this.lstCompileFlags.Location = new System.Drawing.Point(495, 133);
            this.lstCompileFlags.Name = "lstCompileFlags";
            this.lstCompileFlags.ScrollAlwaysVisible = true;
            this.lstCompileFlags.Size = new System.Drawing.Size(165, 43);
            this.lstCompileFlags.TabIndex = 48;
            // 
            // chkAllowFactoryDefaults
            // 
            this.chkAllowFactoryDefaults.AutoSize = true;
            this.chkAllowFactoryDefaults.Location = new System.Drawing.Point(379, 20);
            this.chkAllowFactoryDefaults.Name = "chkAllowFactoryDefaults";
            this.chkAllowFactoryDefaults.Size = new System.Drawing.Size(129, 17);
            this.chkAllowFactoryDefaults.TabIndex = 47;
            this.chkAllowFactoryDefaults.Text = "Allow reset to defaults";
            this.chkAllowFactoryDefaults.UseVisualStyleBackColor = true;
            this.chkAllowFactoryDefaults.CheckedChanged += new System.EventHandler(this.chkAllowFactoryDefaults_CheckedChanged);
            // 
            // btnReboot
            // 
            this.btnReboot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReboot.Location = new System.Drawing.Point(507, 41);
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.Size = new System.Drawing.Size(175, 23);
            this.btnReboot.TabIndex = 46;
            this.btnReboot.Text = "&Reboot device";
            this.btnReboot.UseVisualStyleBackColor = true;
            this.btnReboot.Click += new System.EventHandler(this.btnReboot_Click);
            // 
            // lblHexDevice
            // 
            this.lblHexDevice.AutoSize = true;
            this.lblHexDevice.Location = new System.Drawing.Point(224, 46);
            this.lblHexDevice.Name = "lblHexDevice";
            this.lblHexDevice.Size = new System.Drawing.Size(10, 13);
            this.lblHexDevice.TabIndex = 45;
            this.lblHexDevice.Text = "-";
            // 
            // lblPWMModulesOnline
            // 
            this.lblPWMModulesOnline.AutoSize = true;
            this.lblPWMModulesOnline.Location = new System.Drawing.Point(492, 101);
            this.lblPWMModulesOnline.Name = "lblPWMModulesOnline";
            this.lblPWMModulesOnline.Size = new System.Drawing.Size(53, 13);
            this.lblPWMModulesOnline.TabIndex = 44;
            this.lblPWMModulesOnline.Text = "Unknown";
            this.lblPWMModulesOnline.Click += new System.EventHandler(this.lblPWMModulesOnline_Click);
            // 
            // lblExternalNVRAM
            // 
            this.lblExternalNVRAM.AutoSize = true;
            this.lblExternalNVRAM.Location = new System.Drawing.Point(492, 71);
            this.lblExternalNVRAM.Name = "lblExternalNVRAM";
            this.lblExternalNVRAM.Size = new System.Drawing.Size(53, 13);
            this.lblExternalNVRAM.TabIndex = 43;
            this.lblExternalNVRAM.Text = "Unknown";
            this.lblExternalNVRAM.Click += new System.EventHandler(this.lblExternalNVRAM_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(379, 101);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 13);
            this.label19.TabIndex = 42;
            this.label19.Text = "PWM modules found:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(379, 71);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "eNVRAM > 1KB:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "S88 Report:";
            // 
            // cmbS88Reporting
            // 
            this.cmbS88Reporting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbS88Reporting.FormattingEnabled = true;
            this.cmbS88Reporting.Items.AddRange(new object[] {
            "ONLY_WHEN_GO",
            "ALWAYS",
            "ALWAYS_AND_REFRESH_ON_GO"});
            this.cmbS88Reporting.Location = new System.Drawing.Point(117, 98);
            this.cmbS88Reporting.Name = "cmbS88Reporting";
            this.cmbS88Reporting.Size = new System.Drawing.Size(210, 21);
            this.cmbS88Reporting.TabIndex = 39;
            this.cmbS88Reporting.SelectedIndexChanged += new System.EventHandler(this.cmbS88Reporting_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Stop/Go Button:";
            // 
            // cmbButtonBehavior
            // 
            this.cmbButtonBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbButtonBehavior.FormattingEnabled = true;
            this.cmbButtonBehavior.Items.AddRange(new object[] {
            "NORMAL_DISCONNECTED",
            "NORMAL_CONNECTED"});
            this.cmbButtonBehavior.Location = new System.Drawing.Point(117, 68);
            this.cmbButtonBehavior.Name = "cmbButtonBehavior";
            this.cmbButtonBehavior.Size = new System.Drawing.Size(210, 21);
            this.cmbButtonBehavior.TabIndex = 37;
            this.cmbButtonBehavior.SelectedIndexChanged += new System.EventHandler(this.cmbButtonBehavior_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(507, 16);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(175, 23);
            this.btnReset.TabIndex = 36;
            this.btnReset.Text = "Reset to defaults";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtDeviceAddr
            // 
            this.txtDeviceAddr.Location = new System.Drawing.Point(117, 42);
            this.txtDeviceAddr.MustBeNumeric = true;
            this.txtDeviceAddr.Name = "txtDeviceAddr";
            this.txtDeviceAddr.OriginalText = "";
            this.txtDeviceAddr.Size = new System.Drawing.Size(100, 20);
            this.txtDeviceAddr.TabIndex = 35;
            this.txtDeviceAddr.ButtonClick += new System.EventHandler(this.txtDeviceAddr_ButtonClick);
            this.txtDeviceAddr.TextChanged += new System.EventHandler(this.txtDeviceAddr_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Device Addres:";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(117, 16);
            this.txtDeviceName.MustBeNumeric = false;
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.OriginalText = "";
            this.txtDeviceName.Size = new System.Drawing.Size(210, 20);
            this.txtDeviceName.TabIndex = 33;
            this.txtDeviceName.ButtonClick += new System.EventHandler(this.txtDeviceName_ButtonClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Name:";
            // 
            // lstBoxI2CDevices
            // 
            this.lstBoxI2CDevices.FormattingEnabled = true;
            this.lstBoxI2CDevices.Location = new System.Drawing.Point(9, 162);
            this.lstBoxI2CDevices.Name = "lstBoxI2CDevices";
            this.lstBoxI2CDevices.ScrollAlwaysVisible = true;
            this.lstBoxI2CDevices.Size = new System.Drawing.Size(313, 95);
            this.lstBoxI2CDevices.TabIndex = 1;
            // 
            // btnI2CScan
            // 
            this.btnI2CScan.Location = new System.Drawing.Point(9, 133);
            this.btnI2CScan.Name = "btnI2CScan";
            this.btnI2CScan.Size = new System.Drawing.Size(172, 23);
            this.btnI2CScan.TabIndex = 0;
            this.btnI2CScan.Text = "List connected I2C devices";
            this.btnI2CScan.UseVisualStyleBackColor = true;
            this.btnI2CScan.Click += new System.EventHandler(this.btnI2CScan_Click);
            // 
            // tabLNS88Config
            // 
            this.tabLNS88Config.Controls.Add(this.grpDevConfig);
            this.tabLNS88Config.Location = new System.Drawing.Point(4, 22);
            this.tabLNS88Config.Name = "tabLNS88Config";
            this.tabLNS88Config.Padding = new System.Windows.Forms.Padding(3);
            this.tabLNS88Config.Size = new System.Drawing.Size(911, 360);
            this.tabLNS88Config.TabIndex = 0;
            this.tabLNS88Config.Text = "Loconet S88 Configuration";
            this.tabLNS88Config.UseVisualStyleBackColor = true;
            // 
            // grpDevConfig
            // 
            this.grpDevConfig.Controls.Add(this.lblLastAddr);
            this.grpDevConfig.Controls.Add(this.btnWatchS88_LN);
            this.grpDevConfig.Controls.Add(this.btnWatchS88);
            this.grpDevConfig.Controls.Add(this.label36);
            this.grpDevConfig.Controls.Add(this.label35);
            this.grpDevConfig.Controls.Add(this.label13);
            this.grpDevConfig.Controls.Add(this.label12);
            this.grpDevConfig.Controls.Add(this.label11);
            this.grpDevConfig.Controls.Add(this.label7);
            this.grpDevConfig.Controls.Add(this.btnUseDottedLoc);
            this.grpDevConfig.Controls.Add(this.txtLocModuleLow);
            this.grpDevConfig.Controls.Add(this.txtLocModuleHigh);
            this.grpDevConfig.Controls.Add(this.txtPins_Local);
            this.grpDevConfig.Controls.Add(this.txtModuleAddress_Local);
            this.grpDevConfig.Controls.Add(this.label8);
            this.grpDevConfig.Controls.Add(this.label9);
            this.grpDevConfig.Controls.Add(this.btnCalcPinCount);
            this.grpDevConfig.Controls.Add(this.txtPins);
            this.grpDevConfig.Controls.Add(this.label5);
            this.grpDevConfig.Controls.Add(this.btnUseDotted);
            this.grpDevConfig.Controls.Add(this.txtModuleLow);
            this.grpDevConfig.Controls.Add(this.txtModuleHigh);
            this.grpDevConfig.Controls.Add(this.txtModuleCount);
            this.grpDevConfig.Controls.Add(this.txtModuleAddress);
            this.grpDevConfig.Controls.Add(this.label2);
            this.grpDevConfig.Controls.Add(this.label1);
            this.grpDevConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDevConfig.Location = new System.Drawing.Point(3, 3);
            this.grpDevConfig.Name = "grpDevConfig";
            this.grpDevConfig.Size = new System.Drawing.Size(905, 261);
            this.grpDevConfig.TabIndex = 11;
            this.grpDevConfig.TabStop = false;
            this.grpDevConfig.Text = "S88 Device Configuration";
            // 
            // lblLastAddr
            // 
            this.lblLastAddr.AutoSize = true;
            this.lblLastAddr.Location = new System.Drawing.Point(377, 70);
            this.lblLastAddr.Name = "lblLastAddr";
            this.lblLastAddr.Size = new System.Drawing.Size(70, 13);
            this.lblLastAddr.TabIndex = 39;
            this.lblLastAddr.Text = "Last address:";
            // 
            // btnWatchS88_LN
            // 
            this.btnWatchS88_LN.Location = new System.Drawing.Point(429, 128);
            this.btnWatchS88_LN.Name = "btnWatchS88_LN";
            this.btnWatchS88_LN.Size = new System.Drawing.Size(75, 23);
            this.btnWatchS88_LN.TabIndex = 38;
            this.btnWatchS88_LN.Text = "Watch";
            this.btnWatchS88_LN.UseVisualStyleBackColor = true;
            this.btnWatchS88_LN.Click += new System.EventHandler(this.btnWatchS88_LN_Click);
            // 
            // btnWatchS88
            // 
            this.btnWatchS88.Location = new System.Drawing.Point(429, 39);
            this.btnWatchS88.Name = "btnWatchS88";
            this.btnWatchS88.Size = new System.Drawing.Size(75, 23);
            this.btnWatchS88.TabIndex = 37;
            this.btnWatchS88.Text = "Watch";
            this.btnWatchS88.UseVisualStyleBackColor = true;
            this.btnWatchS88.Click += new System.EventHandler(this.btnWatchS88_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(9, 111);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(245, 13);
            this.label36.TabIndex = 36;
            this.label36.Text = "Local aux pin feedback connection (AUX1-AUX4):";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(9, 20);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(235, 13);
            this.label35.TabIndex = 35;
            this.label35.Text = "S88 devices connected to the S88 or S88n bus:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(237, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Pin Count (8bits):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(238, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Dotted Format:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(238, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Dotted Format:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(370, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = ".";
            // 
            // btnUseDottedLoc
            // 
            this.btnUseDottedLoc.Location = new System.Drawing.Point(175, 128);
            this.btnUseDottedLoc.Name = "btnUseDottedLoc";
            this.btnUseDottedLoc.Size = new System.Drawing.Size(58, 23);
            this.btnUseDottedLoc.TabIndex = 28;
            this.btnUseDottedLoc.Text = "< Calc";
            this.btnUseDottedLoc.UseVisualStyleBackColor = true;
            this.btnUseDottedLoc.Click += new System.EventHandler(this.btnUseDottedLoc_Click);
            // 
            // txtLocModuleLow
            // 
            this.txtLocModuleLow.Location = new System.Drawing.Point(380, 129);
            this.txtLocModuleLow.Name = "txtLocModuleLow";
            this.txtLocModuleLow.Size = new System.Drawing.Size(43, 20);
            this.txtLocModuleLow.TabIndex = 27;
            // 
            // txtLocModuleHigh
            // 
            this.txtLocModuleHigh.Location = new System.Drawing.Point(327, 129);
            this.txtLocModuleHigh.Name = "txtLocModuleHigh";
            this.txtLocModuleHigh.Size = new System.Drawing.Size(43, 20);
            this.txtLocModuleHigh.TabIndex = 26;
            // 
            // txtPins_Local
            // 
            this.txtPins_Local.Location = new System.Drawing.Point(117, 155);
            this.txtPins_Local.MustBeNumeric = true;
            this.txtPins_Local.Name = "txtPins_Local";
            this.txtPins_Local.OriginalText = "";
            this.txtPins_Local.Size = new System.Drawing.Size(54, 20);
            this.txtPins_Local.TabIndex = 25;
            this.txtPins_Local.ButtonClick += new System.EventHandler(this.txtLocModuleCount_ButtonClick);
            // 
            // txtModuleAddress_Local
            // 
            this.txtModuleAddress_Local.Location = new System.Drawing.Point(117, 129);
            this.txtModuleAddress_Local.MustBeNumeric = true;
            this.txtModuleAddress_Local.Name = "txtModuleAddress_Local";
            this.txtModuleAddress_Local.OriginalText = "";
            this.txtModuleAddress_Local.Size = new System.Drawing.Size(54, 20);
            this.txtModuleAddress_Local.TabIndex = 24;
            this.txtModuleAddress_Local.ButtonClick += new System.EventHandler(this.txtModLocAddress_ButtonClick);
            this.txtModuleAddress_Local.TextChanged += new System.EventHandler(this.txtModLocAddress_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "LC S88 pin Count:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "LC S88 Address:";
            // 
            // btnCalcPinCount
            // 
            this.btnCalcPinCount.Location = new System.Drawing.Point(174, 65);
            this.btnCalcPinCount.Name = "btnCalcPinCount";
            this.btnCalcPinCount.Size = new System.Drawing.Size(58, 23);
            this.btnCalcPinCount.TabIndex = 16;
            this.btnCalcPinCount.Text = "< Calc";
            this.btnCalcPinCount.UseVisualStyleBackColor = true;
            this.btnCalcPinCount.Click += new System.EventHandler(this.btnCalcPinCount_Click);
            // 
            // txtPins
            // 
            this.txtPins.Location = new System.Drawing.Point(326, 65);
            this.txtPins.Name = "txtPins";
            this.txtPins.Size = new System.Drawing.Size(43, 20);
            this.txtPins.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(369, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = ".";
            // 
            // btnUseDotted
            // 
            this.btnUseDotted.Location = new System.Drawing.Point(174, 38);
            this.btnUseDotted.Name = "btnUseDotted";
            this.btnUseDotted.Size = new System.Drawing.Size(58, 23);
            this.btnUseDotted.TabIndex = 12;
            this.btnUseDotted.Text = "< Calc";
            this.btnUseDotted.UseVisualStyleBackColor = true;
            this.btnUseDotted.Click += new System.EventHandler(this.btnUseDotted_Click);
            // 
            // txtModuleLow
            // 
            this.txtModuleLow.Location = new System.Drawing.Point(379, 39);
            this.txtModuleLow.Name = "txtModuleLow";
            this.txtModuleLow.Size = new System.Drawing.Size(43, 20);
            this.txtModuleLow.TabIndex = 11;
            // 
            // txtModuleHigh
            // 
            this.txtModuleHigh.Location = new System.Drawing.Point(326, 39);
            this.txtModuleHigh.Name = "txtModuleHigh";
            this.txtModuleHigh.Size = new System.Drawing.Size(43, 20);
            this.txtModuleHigh.TabIndex = 10;
            // 
            // txtModuleCount
            // 
            this.txtModuleCount.Location = new System.Drawing.Point(116, 65);
            this.txtModuleCount.MustBeNumeric = true;
            this.txtModuleCount.Name = "txtModuleCount";
            this.txtModuleCount.OriginalText = "";
            this.txtModuleCount.Size = new System.Drawing.Size(54, 20);
            this.txtModuleCount.TabIndex = 9;
            this.txtModuleCount.ButtonClick += new System.EventHandler(this.txtModuleCount_ButtonClick);
            this.txtModuleCount.TextChanged += new System.EventHandler(this.txtModuleCount_TextChanged);
            // 
            // txtModuleAddress
            // 
            this.txtModuleAddress.Location = new System.Drawing.Point(116, 39);
            this.txtModuleAddress.MustBeNumeric = true;
            this.txtModuleAddress.Name = "txtModuleAddress";
            this.txtModuleAddress.OriginalText = "";
            this.txtModuleAddress.Size = new System.Drawing.Size(54, 20);
            this.txtModuleAddress.TabIndex = 8;
            this.txtModuleAddress.ButtonClick += new System.EventHandler(this.txtModuleAddress_ButtonClick);
            this.txtModuleAddress.TextChanged += new System.EventHandler(this.txtModuleAddress_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "S88 Module Count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "S88 Address:";
            // 
            // tabLNI2CConfig
            // 
            this.tabLNI2CConfig.Controls.Add(this.chkUsePCF8574T);
            this.tabLNI2CConfig.Controls.Add(this.lblLastAddrI2C);
            this.tabLNI2CConfig.Controls.Add(this.btnWatchS88_I2C);
            this.tabLNI2CConfig.Controls.Add(this.label37);
            this.tabLNI2CConfig.Controls.Add(this.label32);
            this.tabLNI2CConfig.Controls.Add(this.btnCalcPinCount_I2C);
            this.tabLNI2CConfig.Controls.Add(this.txtPins_I2C);
            this.tabLNI2CConfig.Controls.Add(this.label34);
            this.tabLNI2CConfig.Controls.Add(this.label31);
            this.tabLNI2CConfig.Controls.Add(this.btnUseDottedI2C);
            this.tabLNI2CConfig.Controls.Add(this.txtModuleLowI2C);
            this.tabLNI2CConfig.Controls.Add(this.txtModuleHighI2C);
            this.tabLNI2CConfig.Controls.Add(this.label33);
            this.tabLNI2CConfig.Controls.Add(this.txtModuleCount_I2C);
            this.tabLNI2CConfig.Controls.Add(this.txtModuleAddress_I2C);
            this.tabLNI2CConfig.Location = new System.Drawing.Point(4, 22);
            this.tabLNI2CConfig.Name = "tabLNI2CConfig";
            this.tabLNI2CConfig.Size = new System.Drawing.Size(911, 360);
            this.tabLNI2CConfig.TabIndex = 3;
            this.tabLNI2CConfig.Text = "I2C Feedback Monitor Configuration";
            this.tabLNI2CConfig.UseVisualStyleBackColor = true;
            // 
            // chkUsePCF8574T
            // 
            this.chkUsePCF8574T.AutoSize = true;
            this.chkUsePCF8574T.Location = new System.Drawing.Point(17, 102);
            this.chkUsePCF8574T.Name = "chkUsePCF8574T";
            this.chkUsePCF8574T.Size = new System.Drawing.Size(346, 17);
            this.chkUsePCF8574T.TabIndex = 62;
            this.chkUsePCF8574T.Text = "Use PCF8574T I2C addressing (0x20) instead of PCF8574AT (0x38)";
            this.chkUsePCF8574T.UseVisualStyleBackColor = true;
            this.chkUsePCF8574T.Click += new System.EventHandler(this.txtModuleCount_I2C_ButtonClick);
            // 
            // lblLastAddrI2C
            // 
            this.lblLastAddrI2C.AutoSize = true;
            this.lblLastAddrI2C.Location = new System.Drawing.Point(377, 76);
            this.lblLastAddrI2C.Name = "lblLastAddrI2C";
            this.lblLastAddrI2C.Size = new System.Drawing.Size(70, 13);
            this.lblLastAddrI2C.TabIndex = 61;
            this.lblLastAddrI2C.Text = "Last address:";
            // 
            // btnWatchS88_I2C
            // 
            this.btnWatchS88_I2C.Location = new System.Drawing.Point(444, 44);
            this.btnWatchS88_I2C.Name = "btnWatchS88_I2C";
            this.btnWatchS88_I2C.Size = new System.Drawing.Size(75, 23);
            this.btnWatchS88_I2C.TabIndex = 60;
            this.btnWatchS88_I2C.Text = "Watch";
            this.btnWatchS88_I2C.UseVisualStyleBackColor = true;
            this.btnWatchS88_I2C.Click += new System.EventHandler(this.btnWatchS88_I2C_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(13, 15);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(243, 13);
            this.label37.TabIndex = 59;
            this.label37.Text = "Feedback modules (PCF8574) connected via I2C:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(239, 76);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(87, 13);
            this.label32.TabIndex = 58;
            this.label32.Text = "Pin Count (8bits):";
            // 
            // btnCalcPinCount_I2C
            // 
            this.btnCalcPinCount_I2C.Location = new System.Drawing.Point(176, 73);
            this.btnCalcPinCount_I2C.Name = "btnCalcPinCount_I2C";
            this.btnCalcPinCount_I2C.Size = new System.Drawing.Size(58, 23);
            this.btnCalcPinCount_I2C.TabIndex = 57;
            this.btnCalcPinCount_I2C.Text = "< Calc";
            this.btnCalcPinCount_I2C.UseVisualStyleBackColor = true;
            this.btnCalcPinCount_I2C.Click += new System.EventHandler(this.btnCalcPinCount_I2C_Click);
            // 
            // txtPins_I2C
            // 
            this.txtPins_I2C.Location = new System.Drawing.Point(328, 73);
            this.txtPins_I2C.Name = "txtPins_I2C";
            this.txtPins_I2C.Size = new System.Drawing.Size(43, 20);
            this.txtPins_I2C.TabIndex = 56;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(14, 73);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(95, 13);
            this.label34.TabIndex = 54;
            this.label34.Text = "I2C Module Count:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(238, 44);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(77, 13);
            this.label31.TabIndex = 53;
            this.label31.Text = "Dotted Format:";
            // 
            // btnUseDottedI2C
            // 
            this.btnUseDottedI2C.Location = new System.Drawing.Point(175, 43);
            this.btnUseDottedI2C.Name = "btnUseDottedI2C";
            this.btnUseDottedI2C.Size = new System.Drawing.Size(58, 23);
            this.btnUseDottedI2C.TabIndex = 52;
            this.btnUseDottedI2C.Text = "< Calc";
            this.btnUseDottedI2C.UseVisualStyleBackColor = true;
            this.btnUseDottedI2C.Click += new System.EventHandler(this.btnUseDottedI2C_Click);
            // 
            // txtModuleLowI2C
            // 
            this.txtModuleLowI2C.Location = new System.Drawing.Point(380, 44);
            this.txtModuleLowI2C.Name = "txtModuleLowI2C";
            this.txtModuleLowI2C.Size = new System.Drawing.Size(43, 20);
            this.txtModuleLowI2C.TabIndex = 51;
            // 
            // txtModuleHighI2C
            // 
            this.txtModuleHighI2C.Location = new System.Drawing.Point(327, 44);
            this.txtModuleHighI2C.Name = "txtModuleHighI2C";
            this.txtModuleHighI2C.Size = new System.Drawing.Size(43, 20);
            this.txtModuleHighI2C.TabIndex = 50;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(13, 44);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(89, 13);
            this.label33.TabIndex = 48;
            this.label33.Text = "I2C S88 Address:";
            // 
            // txtModuleCount_I2C
            // 
            this.txtModuleCount_I2C.Location = new System.Drawing.Point(118, 73);
            this.txtModuleCount_I2C.MustBeNumeric = true;
            this.txtModuleCount_I2C.Name = "txtModuleCount_I2C";
            this.txtModuleCount_I2C.OriginalText = "";
            this.txtModuleCount_I2C.Size = new System.Drawing.Size(54, 20);
            this.txtModuleCount_I2C.TabIndex = 55;
            this.txtModuleCount_I2C.ButtonClick += new System.EventHandler(this.txtModuleCount_I2C_ButtonClick);
            this.txtModuleCount_I2C.TextChanged += new System.EventHandler(this.txtModuleCountI2C_TextChanged);
            // 
            // txtModuleAddress_I2C
            // 
            this.txtModuleAddress_I2C.Location = new System.Drawing.Point(117, 44);
            this.txtModuleAddress_I2C.MustBeNumeric = true;
            this.txtModuleAddress_I2C.Name = "txtModuleAddress_I2C";
            this.txtModuleAddress_I2C.OriginalText = "";
            this.txtModuleAddress_I2C.Size = new System.Drawing.Size(54, 20);
            this.txtModuleAddress_I2C.TabIndex = 49;
            this.txtModuleAddress_I2C.ButtonClick += new System.EventHandler(this.txtModuleAddress_I2C_ButtonClick);
            this.txtModuleAddress_I2C.TextChanged += new System.EventHandler(this.txtModuleAddress_I2C_TextChanged);
            // 
            // tabPWMpinConfig
            // 
            this.tabPWMpinConfig.Controls.Add(this.grpPWMOutput);
            this.tabPWMpinConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPWMpinConfig.Name = "tabPWMpinConfig";
            this.tabPWMpinConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPWMpinConfig.Size = new System.Drawing.Size(911, 360);
            this.tabPWMpinConfig.TabIndex = 1;
            this.tabPWMpinConfig.Text = "Outputs Configuration";
            this.tabPWMpinConfig.UseVisualStyleBackColor = true;
            // 
            // grpPWMOutput
            // 
            this.grpPWMOutput.Controls.Add(this.txtDescription);
            this.grpPWMOutput.Controls.Add(this.btnWriteAspectChain);
            this.grpPWMOutput.Controls.Add(this.lblBoard);
            this.grpPWMOutput.Controls.Add(this.btnExportConfig);
            this.grpPWMOutput.Controls.Add(this.btnToggleAspects);
            this.grpPWMOutput.Controls.Add(this.btnClosedGreen);
            this.grpPWMOutput.Controls.Add(this.btnThrownRed);
            this.grpPWMOutput.Controls.Add(this.btnReadAspectChain);
            this.grpPWMOutput.Controls.Add(this.btnExport);
            this.grpPWMOutput.Controls.Add(this.btnImportConfig);
            this.grpPWMOutput.Controls.Add(this.btnApply);
            this.grpPWMOutput.Controls.Add(this.label30);
            this.grpPWMOutput.Controls.Add(this.txtPinConfig);
            this.grpPWMOutput.Controls.Add(this.btnReadAll);
            this.grpPWMOutput.Controls.Add(this.btnClearConfig);
            this.grpPWMOutput.Controls.Add(this.chkReadOnPinSelect);
            this.grpPWMOutput.Controls.Add(this.grpAspectGreen);
            this.grpPWMOutput.Controls.Add(this.btnWritePin);
            this.grpPWMOutput.Controls.Add(this.btnReadPin);
            this.grpPWMOutput.Controls.Add(this.chkPinInvertOutput);
            this.grpPWMOutput.Controls.Add(this.chkUsePreviousPin);
            this.grpPWMOutput.Controls.Add(this.txtPinDCCAddress);
            this.grpPWMOutput.Controls.Add(this.label22);
            this.grpPWMOutput.Controls.Add(this.grpAspectRed);
            this.grpPWMOutput.Controls.Add(this.label14);
            this.grpPWMOutput.Controls.Add(this.cmbPWMPin);
            this.grpPWMOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPWMOutput.Location = new System.Drawing.Point(3, 3);
            this.grpPWMOutput.Name = "grpPWMOutput";
            this.grpPWMOutput.Size = new System.Drawing.Size(905, 354);
            this.grpPWMOutput.TabIndex = 0;
            this.grpPWMOutput.TabStop = false;
            this.grpPWMOutput.Text = "Output PWM Pin Configuration (PCA9685 - I2C 0x60, 0x61, 0x62 && 0x63)";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(347, 43);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(421, 20);
            this.txtDescription.TabIndex = 25;
            // 
            // btnWriteAspectChain
            // 
            this.btnWriteAspectChain.Location = new System.Drawing.Point(7, 187);
            this.btnWriteAspectChain.Name = "btnWriteAspectChain";
            this.btnWriteAspectChain.Size = new System.Drawing.Size(112, 23);
            this.btnWriteAspectChain.TabIndex = 24;
            this.btnWriteAspectChain.Text = "&Write Aspect Chain";
            this.btnWriteAspectChain.UseVisualStyleBackColor = true;
            this.btnWriteAspectChain.Click += new System.EventHandler(this.btnWriteAspectChain_Click);
            // 
            // lblBoard
            // 
            this.lblBoard.AutoSize = true;
            this.lblBoard.Location = new System.Drawing.Point(7, 44);
            this.lblBoard.Name = "lblBoard";
            this.lblBoard.Size = new System.Drawing.Size(74, 13);
            this.lblBoard.TabIndex = 23;
            this.lblBoard.Text = "Board 0, Pin 0";
            // 
            // btnExportConfig
            // 
            this.btnExportConfig.Location = new System.Drawing.Point(787, 230);
            this.btnExportConfig.Name = "btnExportConfig";
            this.btnExportConfig.Size = new System.Drawing.Size(112, 29);
            this.btnExportConfig.TabIndex = 22;
            this.btnExportConfig.Text = "&Export All Outputs";
            this.btnExportConfig.UseVisualStyleBackColor = true;
            this.btnExportConfig.Click += new System.EventHandler(this.btnExportConfig_Click);
            // 
            // btnToggleAspects
            // 
            this.btnToggleAspects.Location = new System.Drawing.Point(675, 228);
            this.btnToggleAspects.Name = "btnToggleAspects";
            this.btnToggleAspects.Size = new System.Drawing.Size(93, 23);
            this.btnToggleAspects.TabIndex = 21;
            this.btnToggleAspects.Text = "Toggle Aspects";
            this.btnToggleAspects.UseVisualStyleBackColor = true;
            this.btnToggleAspects.Click += new System.EventHandler(this.btnToggleAspects_Click);
            // 
            // btnClosedGreen
            // 
            this.btnClosedGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnClosedGreen.Location = new System.Drawing.Point(318, 41);
            this.btnClosedGreen.Name = "btnClosedGreen";
            this.btnClosedGreen.Size = new System.Drawing.Size(22, 23);
            this.btnClosedGreen.TabIndex = 20;
            this.btnClosedGreen.Text = "C";
            this.btnClosedGreen.UseVisualStyleBackColor = false;
            this.btnClosedGreen.Click += new System.EventHandler(this.btnThrownOrClose_Click);
            // 
            // btnThrownRed
            // 
            this.btnThrownRed.BackColor = System.Drawing.Color.Red;
            this.btnThrownRed.Location = new System.Drawing.Point(297, 41);
            this.btnThrownRed.Name = "btnThrownRed";
            this.btnThrownRed.Size = new System.Drawing.Size(22, 23);
            this.btnThrownRed.TabIndex = 19;
            this.btnThrownRed.Text = "T";
            this.btnThrownRed.UseVisualStyleBackColor = false;
            this.btnThrownRed.Click += new System.EventHandler(this.btnThrownOrClose_Click);
            // 
            // btnReadAspectChain
            // 
            this.btnReadAspectChain.Location = new System.Drawing.Point(7, 90);
            this.btnReadAspectChain.Name = "btnReadAspectChain";
            this.btnReadAspectChain.Size = new System.Drawing.Size(112, 23);
            this.btnReadAspectChain.TabIndex = 18;
            this.btnReadAspectChain.Text = "&Read Aspect Chain";
            this.btnReadAspectChain.UseVisualStyleBackColor = true;
            this.btnReadAspectChain.Click += new System.EventHandler(this.btnReadAspectChain_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::LocoProgrammer.Properties.Resources.export_icon;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(787, 13);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(112, 29);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "Export Aspect";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImportConfig
            // 
            this.btnImportConfig.Image = global::LocoProgrammer.Properties.Resources.import_icon;
            this.btnImportConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportConfig.Location = new System.Drawing.Point(787, 48);
            this.btnImportConfig.Name = "btnImportConfig";
            this.btnImportConfig.Size = new System.Drawing.Size(112, 29);
            this.btnImportConfig.TabIndex = 16;
            this.btnImportConfig.Text = "Import Aspect";
            this.btnImportConfig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportConfig.UseVisualStyleBackColor = true;
            this.btnImportConfig.Click += new System.EventHandler(this.btnImportConfig_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(516, 228);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 15;
            this.btnApply.Text = "&Use String";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(130, 235);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(88, 13);
            this.label30.TabIndex = 14;
            this.label30.Text = "Pin Config String:";
            // 
            // txtPinConfig
            // 
            this.txtPinConfig.Location = new System.Drawing.Point(224, 231);
            this.txtPinConfig.Name = "txtPinConfig";
            this.txtPinConfig.Size = new System.Drawing.Size(286, 20);
            this.txtPinConfig.TabIndex = 13;
            this.txtPinConfig.TextChanged += new System.EventHandler(this.txtPinConfig_TextChanged);
            // 
            // btnReadAll
            // 
            this.btnReadAll.Location = new System.Drawing.Point(7, 118);
            this.btnReadAll.Name = "btnReadAll";
            this.btnReadAll.Size = new System.Drawing.Size(112, 23);
            this.btnReadAll.TabIndex = 12;
            this.btnReadAll.Text = "&Read all";
            this.btnReadAll.UseVisualStyleBackColor = true;
            this.btnReadAll.Click += new System.EventHandler(this.btnReadAll_Click);
            // 
            // btnClearConfig
            // 
            this.btnClearConfig.Location = new System.Drawing.Point(7, 230);
            this.btnClearConfig.Name = "btnClearConfig";
            this.btnClearConfig.Size = new System.Drawing.Size(112, 23);
            this.btnClearConfig.TabIndex = 11;
            this.btnClearConfig.Text = "&Clear Pin Config";
            this.btnClearConfig.UseVisualStyleBackColor = true;
            this.btnClearConfig.Click += new System.EventHandler(this.btnClearConfig_Click);
            // 
            // chkReadOnPinSelect
            // 
            this.chkReadOnPinSelect.AutoSize = true;
            this.chkReadOnPinSelect.Location = new System.Drawing.Point(120, 19);
            this.chkReadOnPinSelect.Name = "chkReadOnPinSelect";
            this.chkReadOnPinSelect.Size = new System.Drawing.Size(131, 17);
            this.chkReadOnPinSelect.TabIndex = 10;
            this.chkReadOnPinSelect.Text = "Read on output select";
            this.chkReadOnPinSelect.UseVisualStyleBackColor = true;
            // 
            // grpAspectGreen
            // 
            this.grpAspectGreen.Controls.Add(this.lblAspectG3);
            this.grpAspectGreen.Controls.Add(this.txtData1Green3);
            this.grpAspectGreen.Controls.Add(this.txtData0Green3);
            this.grpAspectGreen.Controls.Add(this.cmbInstrGreen3);
            this.grpAspectGreen.Controls.Add(this.lblAspectG2);
            this.grpAspectGreen.Controls.Add(this.txtData1Green2);
            this.grpAspectGreen.Controls.Add(this.txtData0Green2);
            this.grpAspectGreen.Controls.Add(this.cmbInstrGreen2);
            this.grpAspectGreen.Controls.Add(this.lblAspectG1);
            this.grpAspectGreen.Controls.Add(this.txtData1Green1);
            this.grpAspectGreen.Controls.Add(this.txtData0Green1);
            this.grpAspectGreen.Controls.Add(this.cmbInstrGreen1);
            this.grpAspectGreen.Controls.Add(this.lblAspectG0);
            this.grpAspectGreen.Controls.Add(this.txtData1Green0);
            this.grpAspectGreen.Controls.Add(this.label27);
            this.grpAspectGreen.Controls.Add(this.txtData0Green0);
            this.grpAspectGreen.Controls.Add(this.label28);
            this.grpAspectGreen.Controls.Add(this.label29);
            this.grpAspectGreen.Controls.Add(this.cmbInstrGreen0);
            this.grpAspectGreen.Location = new System.Drawing.Point(452, 74);
            this.grpAspectGreen.Name = "grpAspectGreen";
            this.grpAspectGreen.Size = new System.Drawing.Size(316, 148);
            this.grpAspectGreen.TabIndex = 9;
            this.grpAspectGreen.TabStop = false;
            this.grpAspectGreen.Text = "Aspects Green (Closed):";
            // 
            // lblAspectG3
            // 
            this.lblAspectG3.AutoSize = true;
            this.lblAspectG3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAspectG3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAspectG3.Location = new System.Drawing.Point(12, 111);
            this.lblAspectG3.Name = "lblAspectG3";
            this.lblAspectG3.Size = new System.Drawing.Size(52, 13);
            this.lblAspectG3.TabIndex = 27;
            this.lblAspectG3.TabStop = true;
            this.lblAspectG3.Text = "Aspect 4:";
            this.lblAspectG3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAspectG3_LinkClicked);
            // 
            // txtData1Green3
            // 
            this.txtData1Green3.Location = new System.Drawing.Point(236, 111);
            this.txtData1Green3.Name = "txtData1Green3";
            this.txtData1Green3.Size = new System.Drawing.Size(68, 20);
            this.txtData1Green3.TabIndex = 26;
            this.txtData1Green3.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // txtData0Green3
            // 
            this.txtData0Green3.Location = new System.Drawing.Point(161, 111);
            this.txtData0Green3.Name = "txtData0Green3";
            this.txtData0Green3.Size = new System.Drawing.Size(68, 20);
            this.txtData0Green3.TabIndex = 25;
            this.txtData0Green3.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // cmbInstrGreen3
            // 
            this.cmbInstrGreen3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrGreen3.DropDownWidth = 120;
            this.cmbInstrGreen3.FormattingEnabled = true;
            this.cmbInstrGreen3.Location = new System.Drawing.Point(71, 111);
            this.cmbInstrGreen3.Name = "cmbInstrGreen3";
            this.cmbInstrGreen3.Size = new System.Drawing.Size(84, 21);
            this.cmbInstrGreen3.TabIndex = 24;
            this.cmbInstrGreen3.SelectedIndexChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // lblAspectG2
            // 
            this.lblAspectG2.AutoSize = true;
            this.lblAspectG2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAspectG2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAspectG2.Location = new System.Drawing.Point(12, 85);
            this.lblAspectG2.Name = "lblAspectG2";
            this.lblAspectG2.Size = new System.Drawing.Size(52, 13);
            this.lblAspectG2.TabIndex = 23;
            this.lblAspectG2.TabStop = true;
            this.lblAspectG2.Text = "Aspect 3:";
            this.lblAspectG2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAspectG2_LinkClicked);
            // 
            // txtData1Green2
            // 
            this.txtData1Green2.Location = new System.Drawing.Point(236, 85);
            this.txtData1Green2.Name = "txtData1Green2";
            this.txtData1Green2.Size = new System.Drawing.Size(68, 20);
            this.txtData1Green2.TabIndex = 22;
            this.txtData1Green2.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // txtData0Green2
            // 
            this.txtData0Green2.Location = new System.Drawing.Point(161, 85);
            this.txtData0Green2.Name = "txtData0Green2";
            this.txtData0Green2.Size = new System.Drawing.Size(68, 20);
            this.txtData0Green2.TabIndex = 21;
            this.txtData0Green2.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // cmbInstrGreen2
            // 
            this.cmbInstrGreen2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrGreen2.DropDownWidth = 120;
            this.cmbInstrGreen2.FormattingEnabled = true;
            this.cmbInstrGreen2.Location = new System.Drawing.Point(71, 85);
            this.cmbInstrGreen2.Name = "cmbInstrGreen2";
            this.cmbInstrGreen2.Size = new System.Drawing.Size(84, 21);
            this.cmbInstrGreen2.TabIndex = 20;
            this.cmbInstrGreen2.SelectedIndexChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // lblAspectG1
            // 
            this.lblAspectG1.AutoSize = true;
            this.lblAspectG1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAspectG1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAspectG1.Location = new System.Drawing.Point(12, 59);
            this.lblAspectG1.Name = "lblAspectG1";
            this.lblAspectG1.Size = new System.Drawing.Size(52, 13);
            this.lblAspectG1.TabIndex = 19;
            this.lblAspectG1.TabStop = true;
            this.lblAspectG1.Text = "Aspect 2:";
            this.lblAspectG1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAspectG1_LinkClicked);
            // 
            // txtData1Green1
            // 
            this.txtData1Green1.Location = new System.Drawing.Point(236, 59);
            this.txtData1Green1.Name = "txtData1Green1";
            this.txtData1Green1.Size = new System.Drawing.Size(68, 20);
            this.txtData1Green1.TabIndex = 18;
            this.txtData1Green1.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // txtData0Green1
            // 
            this.txtData0Green1.Location = new System.Drawing.Point(161, 59);
            this.txtData0Green1.Name = "txtData0Green1";
            this.txtData0Green1.Size = new System.Drawing.Size(68, 20);
            this.txtData0Green1.TabIndex = 17;
            this.txtData0Green1.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // cmbInstrGreen1
            // 
            this.cmbInstrGreen1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrGreen1.DropDownWidth = 120;
            this.cmbInstrGreen1.FormattingEnabled = true;
            this.cmbInstrGreen1.Location = new System.Drawing.Point(71, 59);
            this.cmbInstrGreen1.Name = "cmbInstrGreen1";
            this.cmbInstrGreen1.Size = new System.Drawing.Size(84, 21);
            this.cmbInstrGreen1.TabIndex = 16;
            this.cmbInstrGreen1.SelectedIndexChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // lblAspectG0
            // 
            this.lblAspectG0.AutoSize = true;
            this.lblAspectG0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAspectG0.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAspectG0.Location = new System.Drawing.Point(12, 33);
            this.lblAspectG0.Name = "lblAspectG0";
            this.lblAspectG0.Size = new System.Drawing.Size(52, 13);
            this.lblAspectG0.TabIndex = 15;
            this.lblAspectG0.TabStop = true;
            this.lblAspectG0.Text = "Aspect 1:";
            this.lblAspectG0.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAspectG0_LinkClicked);
            // 
            // txtData1Green0
            // 
            this.txtData1Green0.Location = new System.Drawing.Point(236, 33);
            this.txtData1Green0.Name = "txtData1Green0";
            this.txtData1Green0.Size = new System.Drawing.Size(68, 20);
            this.txtData1Green0.TabIndex = 14;
            this.txtData1Green0.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(233, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(39, 13);
            this.label27.TabIndex = 13;
            this.label27.Text = "Data1:";
            // 
            // txtData0Green0
            // 
            this.txtData0Green0.Location = new System.Drawing.Point(161, 33);
            this.txtData0Green0.Name = "txtData0Green0";
            this.txtData0Green0.Size = new System.Drawing.Size(68, 20);
            this.txtData0Green0.TabIndex = 12;
            this.txtData0Green0.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(158, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(39, 13);
            this.label28.TabIndex = 11;
            this.label28.Text = "Data0:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(68, 17);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(59, 13);
            this.label29.TabIndex = 10;
            this.label29.Text = "Instruction:";
            // 
            // cmbInstrGreen0
            // 
            this.cmbInstrGreen0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrGreen0.DropDownWidth = 120;
            this.cmbInstrGreen0.FormattingEnabled = true;
            this.cmbInstrGreen0.Location = new System.Drawing.Point(71, 33);
            this.cmbInstrGreen0.Name = "cmbInstrGreen0";
            this.cmbInstrGreen0.Size = new System.Drawing.Size(84, 21);
            this.cmbInstrGreen0.TabIndex = 9;
            this.cmbInstrGreen0.SelectedIndexChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // btnWritePin
            // 
            this.btnWritePin.Location = new System.Drawing.Point(7, 159);
            this.btnWritePin.Name = "btnWritePin";
            this.btnWritePin.Size = new System.Drawing.Size(113, 23);
            this.btnWritePin.TabIndex = 8;
            this.btnWritePin.Text = "&Write";
            this.btnWritePin.UseVisualStyleBackColor = true;
            this.btnWritePin.Click += new System.EventHandler(this.btnWritePin_Click);
            // 
            // btnReadPin
            // 
            this.btnReadPin.Location = new System.Drawing.Point(7, 62);
            this.btnReadPin.Name = "btnReadPin";
            this.btnReadPin.Size = new System.Drawing.Size(113, 23);
            this.btnReadPin.TabIndex = 7;
            this.btnReadPin.Text = "&Read";
            this.btnReadPin.UseVisualStyleBackColor = true;
            this.btnReadPin.Click += new System.EventHandler(this.btnReadPin_Click);
            // 
            // chkPinInvertOutput
            // 
            this.chkPinInvertOutput.AutoSize = true;
            this.chkPinInvertOutput.Location = new System.Drawing.Point(575, 20);
            this.chkPinInvertOutput.Name = "chkPinInvertOutput";
            this.chkPinInvertOutput.Size = new System.Drawing.Size(192, 17);
            this.chkPinInvertOutput.TabIndex = 6;
            this.chkPinInvertOutput.Text = "Invert Pin Output (common Source)";
            this.chkPinInvertOutput.UseVisualStyleBackColor = true;
            this.chkPinInvertOutput.CheckedChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // chkUsePreviousPin
            // 
            this.chkUsePreviousPin.AutoSize = true;
            this.chkUsePreviousPin.Location = new System.Drawing.Point(405, 20);
            this.chkUsePreviousPin.Name = "chkUsePreviousPin";
            this.chkUsePreviousPin.Size = new System.Drawing.Size(162, 17);
            this.chkUsePreviousPin.TabIndex = 5;
            this.chkUsePreviousPin.Text = "Pin linked to previous aspect";
            this.chkUsePreviousPin.UseVisualStyleBackColor = true;
            this.chkUsePreviousPin.CheckedChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // txtPinDCCAddress
            // 
            this.txtPinDCCAddress.Location = new System.Drawing.Point(210, 43);
            this.txtPinDCCAddress.Name = "txtPinDCCAddress";
            this.txtPinDCCAddress.Size = new System.Drawing.Size(82, 20);
            this.txtPinDCCAddress.TabIndex = 4;
            this.txtPinDCCAddress.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(134, 45);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 13);
            this.label22.TabIndex = 3;
            this.label22.Text = "DCC Address:";
            // 
            // grpAspectRed
            // 
            this.grpAspectRed.Controls.Add(this.lblAspectR3);
            this.grpAspectRed.Controls.Add(this.txtData1Red3);
            this.grpAspectRed.Controls.Add(this.txtData0Red3);
            this.grpAspectRed.Controls.Add(this.cmbInstrRed3);
            this.grpAspectRed.Controls.Add(this.lblAspectR2);
            this.grpAspectRed.Controls.Add(this.txtData1Red2);
            this.grpAspectRed.Controls.Add(this.txtData0Red2);
            this.grpAspectRed.Controls.Add(this.cmbInstrRed2);
            this.grpAspectRed.Controls.Add(this.lblAspectR1);
            this.grpAspectRed.Controls.Add(this.txtData1Red1);
            this.grpAspectRed.Controls.Add(this.txtData0Red1);
            this.grpAspectRed.Controls.Add(this.cmbInstrRed1);
            this.grpAspectRed.Controls.Add(this.lblAspectR0);
            this.grpAspectRed.Controls.Add(this.txtData1Red0);
            this.grpAspectRed.Controls.Add(this.label17);
            this.grpAspectRed.Controls.Add(this.txtData0Red0);
            this.grpAspectRed.Controls.Add(this.label16);
            this.grpAspectRed.Controls.Add(this.label15);
            this.grpAspectRed.Controls.Add(this.cmbInstrRed0);
            this.grpAspectRed.Location = new System.Drawing.Point(130, 74);
            this.grpAspectRed.Name = "grpAspectRed";
            this.grpAspectRed.Size = new System.Drawing.Size(316, 148);
            this.grpAspectRed.TabIndex = 2;
            this.grpAspectRed.TabStop = false;
            this.grpAspectRed.Text = "Aspects Red (Thrown):";
            // 
            // lblAspectR3
            // 
            this.lblAspectR3.AutoSize = true;
            this.lblAspectR3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAspectR3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAspectR3.Location = new System.Drawing.Point(12, 111);
            this.lblAspectR3.Name = "lblAspectR3";
            this.lblAspectR3.Size = new System.Drawing.Size(52, 13);
            this.lblAspectR3.TabIndex = 27;
            this.lblAspectR3.TabStop = true;
            this.lblAspectR3.Text = "Aspect 4:";
            this.lblAspectR3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAspectR3_LinkClicked);
            // 
            // txtData1Red3
            // 
            this.txtData1Red3.Location = new System.Drawing.Point(236, 111);
            this.txtData1Red3.Name = "txtData1Red3";
            this.txtData1Red3.Size = new System.Drawing.Size(68, 20);
            this.txtData1Red3.TabIndex = 26;
            this.txtData1Red3.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // txtData0Red3
            // 
            this.txtData0Red3.Location = new System.Drawing.Point(161, 111);
            this.txtData0Red3.Name = "txtData0Red3";
            this.txtData0Red3.Size = new System.Drawing.Size(68, 20);
            this.txtData0Red3.TabIndex = 25;
            this.txtData0Red3.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // cmbInstrRed3
            // 
            this.cmbInstrRed3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrRed3.DropDownWidth = 120;
            this.cmbInstrRed3.FormattingEnabled = true;
            this.cmbInstrRed3.Location = new System.Drawing.Point(71, 111);
            this.cmbInstrRed3.Name = "cmbInstrRed3";
            this.cmbInstrRed3.Size = new System.Drawing.Size(84, 21);
            this.cmbInstrRed3.TabIndex = 24;
            this.cmbInstrRed3.SelectedIndexChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // lblAspectR2
            // 
            this.lblAspectR2.AutoSize = true;
            this.lblAspectR2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAspectR2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAspectR2.Location = new System.Drawing.Point(12, 85);
            this.lblAspectR2.Name = "lblAspectR2";
            this.lblAspectR2.Size = new System.Drawing.Size(52, 13);
            this.lblAspectR2.TabIndex = 23;
            this.lblAspectR2.TabStop = true;
            this.lblAspectR2.Text = "Aspect 3:";
            this.lblAspectR2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAspectR2_LinkClicked);
            // 
            // txtData1Red2
            // 
            this.txtData1Red2.Location = new System.Drawing.Point(236, 85);
            this.txtData1Red2.Name = "txtData1Red2";
            this.txtData1Red2.Size = new System.Drawing.Size(68, 20);
            this.txtData1Red2.TabIndex = 22;
            this.txtData1Red2.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // txtData0Red2
            // 
            this.txtData0Red2.Location = new System.Drawing.Point(161, 85);
            this.txtData0Red2.Name = "txtData0Red2";
            this.txtData0Red2.Size = new System.Drawing.Size(68, 20);
            this.txtData0Red2.TabIndex = 21;
            this.txtData0Red2.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // cmbInstrRed2
            // 
            this.cmbInstrRed2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrRed2.DropDownWidth = 120;
            this.cmbInstrRed2.FormattingEnabled = true;
            this.cmbInstrRed2.Location = new System.Drawing.Point(71, 85);
            this.cmbInstrRed2.Name = "cmbInstrRed2";
            this.cmbInstrRed2.Size = new System.Drawing.Size(84, 21);
            this.cmbInstrRed2.TabIndex = 20;
            this.cmbInstrRed2.SelectedIndexChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // lblAspectR1
            // 
            this.lblAspectR1.AutoSize = true;
            this.lblAspectR1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAspectR1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAspectR1.Location = new System.Drawing.Point(12, 59);
            this.lblAspectR1.Name = "lblAspectR1";
            this.lblAspectR1.Size = new System.Drawing.Size(52, 13);
            this.lblAspectR1.TabIndex = 19;
            this.lblAspectR1.TabStop = true;
            this.lblAspectR1.Text = "Aspect 2:";
            this.lblAspectR1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAspectR1_LinkClicked);
            // 
            // txtData1Red1
            // 
            this.txtData1Red1.Location = new System.Drawing.Point(236, 59);
            this.txtData1Red1.Name = "txtData1Red1";
            this.txtData1Red1.Size = new System.Drawing.Size(68, 20);
            this.txtData1Red1.TabIndex = 18;
            this.txtData1Red1.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // txtData0Red1
            // 
            this.txtData0Red1.Location = new System.Drawing.Point(161, 59);
            this.txtData0Red1.Name = "txtData0Red1";
            this.txtData0Red1.Size = new System.Drawing.Size(68, 20);
            this.txtData0Red1.TabIndex = 17;
            this.txtData0Red1.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // cmbInstrRed1
            // 
            this.cmbInstrRed1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrRed1.DropDownWidth = 120;
            this.cmbInstrRed1.FormattingEnabled = true;
            this.cmbInstrRed1.Location = new System.Drawing.Point(71, 59);
            this.cmbInstrRed1.Name = "cmbInstrRed1";
            this.cmbInstrRed1.Size = new System.Drawing.Size(84, 21);
            this.cmbInstrRed1.TabIndex = 16;
            this.cmbInstrRed1.SelectedIndexChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // lblAspectR0
            // 
            this.lblAspectR0.AutoSize = true;
            this.lblAspectR0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAspectR0.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAspectR0.Location = new System.Drawing.Point(12, 33);
            this.lblAspectR0.Name = "lblAspectR0";
            this.lblAspectR0.Size = new System.Drawing.Size(52, 13);
            this.lblAspectR0.TabIndex = 15;
            this.lblAspectR0.TabStop = true;
            this.lblAspectR0.Text = "Aspect 1:";
            this.lblAspectR0.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAspectR0_LinkClicked);
            // 
            // txtData1Red0
            // 
            this.txtData1Red0.Location = new System.Drawing.Point(236, 33);
            this.txtData1Red0.Name = "txtData1Red0";
            this.txtData1Red0.Size = new System.Drawing.Size(68, 20);
            this.txtData1Red0.TabIndex = 14;
            this.txtData1Red0.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(233, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Data1:";
            // 
            // txtData0Red0
            // 
            this.txtData0Red0.Location = new System.Drawing.Point(161, 33);
            this.txtData0Red0.Name = "txtData0Red0";
            this.txtData0Red0.Size = new System.Drawing.Size(68, 20);
            this.txtData0Red0.TabIndex = 12;
            this.txtData0Red0.TextChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(158, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Data0:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(68, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Instruction:";
            // 
            // cmbInstrRed0
            // 
            this.cmbInstrRed0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrRed0.DropDownWidth = 120;
            this.cmbInstrRed0.FormattingEnabled = true;
            this.cmbInstrRed0.Location = new System.Drawing.Point(71, 33);
            this.cmbInstrRed0.Name = "cmbInstrRed0";
            this.cmbInstrRed0.Size = new System.Drawing.Size(84, 21);
            this.cmbInstrRed0.TabIndex = 9;
            this.cmbInstrRed0.SelectedIndexChanged += new System.EventHandler(this.AspectSettingOrValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Output:";
            // 
            // cmbPWMPin
            // 
            this.cmbPWMPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPWMPin.FormattingEnabled = true;
            this.cmbPWMPin.Location = new System.Drawing.Point(53, 17);
            this.cmbPWMPin.Name = "cmbPWMPin";
            this.cmbPWMPin.Size = new System.Drawing.Size(61, 21);
            this.cmbPWMPin.TabIndex = 0;
            this.cmbPWMPin.SelectedIndexChanged += new System.EventHandler(this.cmbPWMPin_SelectedIndexChanged);
            // 
            // tabVL530L0
            // 
            this.tabVL530L0.Controls.Add(this.groupBox1);
            this.tabVL530L0.Location = new System.Drawing.Point(4, 22);
            this.tabVL530L0.Name = "tabVL530L0";
            this.tabVL530L0.Padding = new System.Windows.Forms.Padding(3);
            this.tabVL530L0.Size = new System.Drawing.Size(911, 360);
            this.tabVL530L0.TabIndex = 4;
            this.tabVL530L0.Text = "VL53L0x Configuration";
            this.tabVL530L0.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLastValSensor7);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.txtVL53Sensor7val);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.txtLastValSensor6);
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.Controls.Add(this.txtVL53Sensor6val);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.txtLastValSensor5);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.txtVL53Sensor5val);
            this.groupBox1.Controls.Add(this.label48);
            this.groupBox1.Controls.Add(this.txtLastValSensor4);
            this.groupBox1.Controls.Add(this.label49);
            this.groupBox1.Controls.Add(this.txtVL53Sensor4val);
            this.groupBox1.Controls.Add(this.label50);
            this.groupBox1.Controls.Add(this.txtLastValSensor3);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.txtVL53Sensor3val);
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.txtLastValSensor2);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.txtVL53Sensor2val);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.txtLastValSensor1);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.txtVL53Sensor1val);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.txtLastValSensor0);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.txtVL53Sensor0val);
            this.groupBox1.Controls.Add(this.lblSensor0);
            this.groupBox1.Controls.Add(this.btnRefreshVL530values);
            this.groupBox1.Controls.Add(this.btnWatchVL53);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.btnUseDottedVL53);
            this.groupBox1.Controls.Add(this.txtVL53ModuleLow);
            this.groupBox1.Controls.Add(this.txtVL53ModuleHigh);
            this.groupBox1.Controls.Add(this.txtModuleAddress_VL53);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 257);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VL53L0x Config";
            // 
            // txtLastValSensor7
            // 
            this.txtLastValSensor7.Location = new System.Drawing.Point(504, 163);
            this.txtLastValSensor7.Name = "txtLastValSensor7";
            this.txtLastValSensor7.ReadOnly = true;
            this.txtLastValSensor7.Size = new System.Drawing.Size(61, 20);
            this.txtLastValSensor7.TabIndex = 80;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(439, 166);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(59, 13);
            this.label43.TabIndex = 79;
            this.label43.Text = "Last value:";
            // 
            // txtVL53Sensor7val
            // 
            this.txtVL53Sensor7val.Location = new System.Drawing.Point(367, 163);
            this.txtVL53Sensor7val.MustBeNumeric = true;
            this.txtVL53Sensor7val.Name = "txtVL53Sensor7val";
            this.txtVL53Sensor7val.OriginalText = "";
            this.txtVL53Sensor7val.Size = new System.Drawing.Size(65, 20);
            this.txtVL53Sensor7val.TabIndex = 78;
            this.txtVL53Sensor7val.ButtonClick += new System.EventHandler(this.txtVL53Sensor7val_ButtonClick);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(309, 166);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(52, 13);
            this.label44.TabIndex = 77;
            this.label44.Text = "Sensor 8:";
            // 
            // txtLastValSensor6
            // 
            this.txtLastValSensor6.Location = new System.Drawing.Point(504, 134);
            this.txtLastValSensor6.Name = "txtLastValSensor6";
            this.txtLastValSensor6.ReadOnly = true;
            this.txtLastValSensor6.Size = new System.Drawing.Size(61, 20);
            this.txtLastValSensor6.TabIndex = 76;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(439, 137);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(59, 13);
            this.label45.TabIndex = 75;
            this.label45.Text = "Last value:";
            // 
            // txtVL53Sensor6val
            // 
            this.txtVL53Sensor6val.Location = new System.Drawing.Point(367, 134);
            this.txtVL53Sensor6val.MustBeNumeric = true;
            this.txtVL53Sensor6val.Name = "txtVL53Sensor6val";
            this.txtVL53Sensor6val.OriginalText = "";
            this.txtVL53Sensor6val.Size = new System.Drawing.Size(65, 20);
            this.txtVL53Sensor6val.TabIndex = 74;
            this.txtVL53Sensor6val.ButtonClick += new System.EventHandler(this.txtVL53Sensor6val_ButtonClick);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(309, 137);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(52, 13);
            this.label46.TabIndex = 73;
            this.label46.Text = "Sensor 7:";
            // 
            // txtLastValSensor5
            // 
            this.txtLastValSensor5.Location = new System.Drawing.Point(504, 108);
            this.txtLastValSensor5.Name = "txtLastValSensor5";
            this.txtLastValSensor5.ReadOnly = true;
            this.txtLastValSensor5.Size = new System.Drawing.Size(61, 20);
            this.txtLastValSensor5.TabIndex = 72;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(439, 111);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(59, 13);
            this.label47.TabIndex = 71;
            this.label47.Text = "Last value:";
            // 
            // txtVL53Sensor5val
            // 
            this.txtVL53Sensor5val.Location = new System.Drawing.Point(367, 108);
            this.txtVL53Sensor5val.MustBeNumeric = true;
            this.txtVL53Sensor5val.Name = "txtVL53Sensor5val";
            this.txtVL53Sensor5val.OriginalText = "";
            this.txtVL53Sensor5val.Size = new System.Drawing.Size(65, 20);
            this.txtVL53Sensor5val.TabIndex = 70;
            this.txtVL53Sensor5val.ButtonClick += new System.EventHandler(this.txtVL53Sensor5val_ButtonClick);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(309, 111);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(52, 13);
            this.label48.TabIndex = 69;
            this.label48.Text = "Sensor 6:";
            // 
            // txtLastValSensor4
            // 
            this.txtLastValSensor4.Location = new System.Drawing.Point(504, 79);
            this.txtLastValSensor4.Name = "txtLastValSensor4";
            this.txtLastValSensor4.ReadOnly = true;
            this.txtLastValSensor4.Size = new System.Drawing.Size(61, 20);
            this.txtLastValSensor4.TabIndex = 68;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(439, 82);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(59, 13);
            this.label49.TabIndex = 67;
            this.label49.Text = "Last value:";
            // 
            // txtVL53Sensor4val
            // 
            this.txtVL53Sensor4val.Location = new System.Drawing.Point(367, 79);
            this.txtVL53Sensor4val.MustBeNumeric = true;
            this.txtVL53Sensor4val.Name = "txtVL53Sensor4val";
            this.txtVL53Sensor4val.OriginalText = "";
            this.txtVL53Sensor4val.Size = new System.Drawing.Size(65, 20);
            this.txtVL53Sensor4val.TabIndex = 66;
            this.txtVL53Sensor4val.ButtonClick += new System.EventHandler(this.txtVL53Sensor4val_ButtonClick);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(309, 82);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(52, 13);
            this.label50.TabIndex = 65;
            this.label50.Text = "Sensor 5:";
            // 
            // txtLastValSensor3
            // 
            this.txtLastValSensor3.Location = new System.Drawing.Point(211, 163);
            this.txtLastValSensor3.Name = "txtLastValSensor3";
            this.txtLastValSensor3.ReadOnly = true;
            this.txtLastValSensor3.Size = new System.Drawing.Size(61, 20);
            this.txtLastValSensor3.TabIndex = 64;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(146, 166);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(59, 13);
            this.label41.TabIndex = 63;
            this.label41.Text = "Last value:";
            // 
            // txtVL53Sensor3val
            // 
            this.txtVL53Sensor3val.Location = new System.Drawing.Point(74, 163);
            this.txtVL53Sensor3val.MustBeNumeric = true;
            this.txtVL53Sensor3val.Name = "txtVL53Sensor3val";
            this.txtVL53Sensor3val.OriginalText = "";
            this.txtVL53Sensor3val.Size = new System.Drawing.Size(65, 20);
            this.txtVL53Sensor3val.TabIndex = 62;
            this.txtVL53Sensor3val.ButtonClick += new System.EventHandler(this.txtVL53Sensor3val_ButtonClick);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(16, 166);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(52, 13);
            this.label42.TabIndex = 61;
            this.label42.Text = "Sensor 4:";
            // 
            // txtLastValSensor2
            // 
            this.txtLastValSensor2.Location = new System.Drawing.Point(211, 134);
            this.txtLastValSensor2.Name = "txtLastValSensor2";
            this.txtLastValSensor2.ReadOnly = true;
            this.txtLastValSensor2.Size = new System.Drawing.Size(61, 20);
            this.txtLastValSensor2.TabIndex = 60;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(146, 137);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(59, 13);
            this.label39.TabIndex = 59;
            this.label39.Text = "Last value:";
            // 
            // txtVL53Sensor2val
            // 
            this.txtVL53Sensor2val.Location = new System.Drawing.Point(74, 134);
            this.txtVL53Sensor2val.MustBeNumeric = true;
            this.txtVL53Sensor2val.Name = "txtVL53Sensor2val";
            this.txtVL53Sensor2val.OriginalText = "";
            this.txtVL53Sensor2val.Size = new System.Drawing.Size(65, 20);
            this.txtVL53Sensor2val.TabIndex = 58;
            this.txtVL53Sensor2val.ButtonClick += new System.EventHandler(this.txtVL53Sensor2val_ButtonClick);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(16, 137);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(52, 13);
            this.label40.TabIndex = 57;
            this.label40.Text = "Sensor 3:";
            // 
            // txtLastValSensor1
            // 
            this.txtLastValSensor1.Location = new System.Drawing.Point(211, 108);
            this.txtLastValSensor1.Name = "txtLastValSensor1";
            this.txtLastValSensor1.ReadOnly = true;
            this.txtLastValSensor1.Size = new System.Drawing.Size(61, 20);
            this.txtLastValSensor1.TabIndex = 56;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(146, 111);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(59, 13);
            this.label26.TabIndex = 55;
            this.label26.Text = "Last value:";
            // 
            // txtVL53Sensor1val
            // 
            this.txtVL53Sensor1val.Location = new System.Drawing.Point(74, 108);
            this.txtVL53Sensor1val.MustBeNumeric = true;
            this.txtVL53Sensor1val.Name = "txtVL53Sensor1val";
            this.txtVL53Sensor1val.OriginalText = "";
            this.txtVL53Sensor1val.Size = new System.Drawing.Size(65, 20);
            this.txtVL53Sensor1val.TabIndex = 54;
            this.txtVL53Sensor1val.ButtonClick += new System.EventHandler(this.txtVL53Sensor1val_ButtonClick);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(16, 111);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(52, 13);
            this.label38.TabIndex = 53;
            this.label38.Text = "Sensor 2:";
            // 
            // txtLastValSensor0
            // 
            this.txtLastValSensor0.Location = new System.Drawing.Point(211, 79);
            this.txtLastValSensor0.Name = "txtLastValSensor0";
            this.txtLastValSensor0.ReadOnly = true;
            this.txtLastValSensor0.Size = new System.Drawing.Size(61, 20);
            this.txtLastValSensor0.TabIndex = 52;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(146, 82);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 13);
            this.label25.TabIndex = 51;
            this.label25.Text = "Last value:";
            // 
            // txtVL53Sensor0val
            // 
            this.txtVL53Sensor0val.Location = new System.Drawing.Point(74, 79);
            this.txtVL53Sensor0val.MustBeNumeric = true;
            this.txtVL53Sensor0val.Name = "txtVL53Sensor0val";
            this.txtVL53Sensor0val.OriginalText = "";
            this.txtVL53Sensor0val.Size = new System.Drawing.Size(65, 20);
            this.txtVL53Sensor0val.TabIndex = 50;
            this.txtVL53Sensor0val.ButtonClick += new System.EventHandler(this.txtVL53Sensor0val_ButtonClick);
            // 
            // lblSensor0
            // 
            this.lblSensor0.AutoSize = true;
            this.lblSensor0.Location = new System.Drawing.Point(16, 82);
            this.lblSensor0.Name = "lblSensor0";
            this.lblSensor0.Size = new System.Drawing.Size(52, 13);
            this.lblSensor0.TabIndex = 49;
            this.lblSensor0.Text = "Sensor 1:";
            // 
            // btnRefreshVL530values
            // 
            this.btnRefreshVL530values.Location = new System.Drawing.Point(19, 204);
            this.btnRefreshVL530values.Name = "btnRefreshVL530values";
            this.btnRefreshVL530values.Size = new System.Drawing.Size(211, 23);
            this.btnRefreshVL530values.TabIndex = 48;
            this.btnRefreshVL530values.Text = "Refresh readings";
            this.btnRefreshVL530values.UseVisualStyleBackColor = true;
            this.btnRefreshVL530values.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnWatchVL53
            // 
            this.btnWatchVL53.Location = new System.Drawing.Point(438, 40);
            this.btnWatchVL53.Name = "btnWatchVL53";
            this.btnWatchVL53.Size = new System.Drawing.Size(75, 23);
            this.btnWatchVL53.TabIndex = 47;
            this.btnWatchVL53.Text = "Watch";
            this.btnWatchVL53.UseVisualStyleBackColor = true;
            this.btnWatchVL53.Click += new System.EventHandler(this.btnWatchVL53_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(234, 13);
            this.label20.TabIndex = 46;
            this.label20.Text = "VL53L0x feedback connection (via PCA9548A):";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(247, 41);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 13);
            this.label21.TabIndex = 45;
            this.label21.Text = "Dotted Format:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(379, 46);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(10, 13);
            this.label23.TabIndex = 44;
            this.label23.Text = ".";
            // 
            // btnUseDottedVL53
            // 
            this.btnUseDottedVL53.Location = new System.Drawing.Point(184, 40);
            this.btnUseDottedVL53.Name = "btnUseDottedVL53";
            this.btnUseDottedVL53.Size = new System.Drawing.Size(58, 23);
            this.btnUseDottedVL53.TabIndex = 43;
            this.btnUseDottedVL53.Text = "< Calc";
            this.btnUseDottedVL53.UseVisualStyleBackColor = true;
            this.btnUseDottedVL53.Click += new System.EventHandler(this.btnUseDottedVL53_Click);
            // 
            // txtVL53ModuleLow
            // 
            this.txtVL53ModuleLow.Location = new System.Drawing.Point(389, 41);
            this.txtVL53ModuleLow.Name = "txtVL53ModuleLow";
            this.txtVL53ModuleLow.Size = new System.Drawing.Size(43, 20);
            this.txtVL53ModuleLow.TabIndex = 42;
            // 
            // txtVL53ModuleHigh
            // 
            this.txtVL53ModuleHigh.Location = new System.Drawing.Point(336, 41);
            this.txtVL53ModuleHigh.Name = "txtVL53ModuleHigh";
            this.txtVL53ModuleHigh.Size = new System.Drawing.Size(43, 20);
            this.txtVL53ModuleHigh.TabIndex = 41;
            // 
            // txtModuleAddress_VL53
            // 
            this.txtModuleAddress_VL53.Location = new System.Drawing.Point(126, 41);
            this.txtModuleAddress_VL53.MustBeNumeric = true;
            this.txtModuleAddress_VL53.Name = "txtModuleAddress_VL53";
            this.txtModuleAddress_VL53.OriginalText = "";
            this.txtModuleAddress_VL53.Size = new System.Drawing.Size(54, 20);
            this.txtModuleAddress_VL53.TabIndex = 40;
            this.txtModuleAddress_VL53.ButtonClick += new System.EventHandler(this.txtModuleAddress_VL53_ButtonClick);
            this.txtModuleAddress_VL53.TextChanged += new System.EventHandler(this.txtModuleAddress_VL53_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(13, 41);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(110, 13);
            this.label24.TabIndex = 39;
            this.label24.Text = "VL53L0 S88 Address:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCopyright,
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 594);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(919, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripCopyright
            // 
            this.toolStripCopyright.Name = "toolStripCopyright";
            this.toolStripCopyright.Size = new System.Drawing.Size(115, 17);
            this.toolStripCopyright.Text = "©2024 Roeland Kluit";
            this.toolStripCopyright.Click += new System.EventHandler(this.toolStripCopyright_Click);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.AutoSize = false;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(789, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "-";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Location = new System.Drawing.Point(0, 520);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(919, 74);
            this.txtLog.TabIndex = 13;
            this.txtLog.WordWrap = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 616);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabDeviceConfig);
            this.Controls.Add(this.grpDevices);
            this.Controls.Add(this.grpConnection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(808, 655);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LocoConnect Programmer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.grpDevices.ResumeLayout(false);
            this.tabDeviceConfig.ResumeLayout(false);
            this.tabGenConfig.ResumeLayout(false);
            this.tabGenConfig.PerformLayout();
            this.tabLNS88Config.ResumeLayout(false);
            this.grpDevConfig.ResumeLayout(false);
            this.grpDevConfig.PerformLayout();
            this.tabLNI2CConfig.ResumeLayout(false);
            this.tabLNI2CConfig.PerformLayout();
            this.tabPWMpinConfig.ResumeLayout(false);
            this.grpPWMOutput.ResumeLayout(false);
            this.grpPWMOutput.PerformLayout();
            this.grpAspectGreen.ResumeLayout(false);
            this.grpAspectGreen.PerformLayout();
            this.grpAspectRed.ResumeLayout(false);
            this.grpAspectRed.PerformLayout();
            this.tabVL530L0.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.ComboBox cmbSerialPorts;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RadioButton rbLocoTCP;
        private System.Windows.Forms.RadioButton rbLocoSerial;
        private System.Windows.Forms.ComboBox cmbSerialSpeed;
        private System.Windows.Forms.GroupBox grpDevices;
        private System.Windows.Forms.ListView lvDevices;
        private System.Windows.Forms.ColumnHeader columnDeviceAddr;
        private System.Windows.Forms.ColumnHeader columnDeviceType;
        private System.Windows.Forms.ColumnHeader columnDeviceName;
        private System.Windows.Forms.ColumnHeader columnDeviceMnfg;
        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.ColumnHeader columnDeviceNodeID;
        private System.Windows.Forms.ColumnHeader columnSWVersion;
        private System.Windows.Forms.TabControl tabDeviceConfig;
        private System.Windows.Forms.TabPage tabLNS88Config;
        private System.Windows.Forms.GroupBox grpDevConfig;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUseDottedLoc;
        private System.Windows.Forms.TextBox txtLocModuleLow;
        private System.Windows.Forms.TextBox txtLocModuleHigh;
        private LocoProgrammerUserControls.ucButtonTextBox txtPins_Local;
        private LocoProgrammerUserControls.ucButtonTextBox txtModuleAddress_Local;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCalcPinCount;
        private System.Windows.Forms.TextBox txtPins;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUseDotted;
        private System.Windows.Forms.TextBox txtModuleLow;
        private System.Windows.Forms.TextBox txtModuleHigh;
        private LocoProgrammerUserControls.ucButtonTextBox txtModuleCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPWMpinConfig;
        private System.Windows.Forms.TabPage tabGenConfig;
        private System.Windows.Forms.GroupBox grpPWMOutput;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbPWMPin;
        private System.Windows.Forms.CheckBox chkPinInvertOutput;
        private System.Windows.Forms.CheckBox chkUsePreviousPin;
        private System.Windows.Forms.TextBox txtPinDCCAddress;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox grpAspectRed;
        private System.Windows.Forms.LinkLabel lblAspectR3;
        private System.Windows.Forms.TextBox txtData1Red3;
        private System.Windows.Forms.TextBox txtData0Red3;
        private System.Windows.Forms.ComboBox cmbInstrRed3;
        private System.Windows.Forms.LinkLabel lblAspectR2;
        private System.Windows.Forms.TextBox txtData1Red2;
        private System.Windows.Forms.TextBox txtData0Red2;
        private System.Windows.Forms.ComboBox cmbInstrRed2;
        private System.Windows.Forms.LinkLabel lblAspectR1;
        private System.Windows.Forms.TextBox txtData1Red1;
        private System.Windows.Forms.TextBox txtData0Red1;
        private System.Windows.Forms.ComboBox cmbInstrRed1;
        private System.Windows.Forms.LinkLabel lblAspectR0;
        private System.Windows.Forms.TextBox txtData1Red0;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtData0Red0;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbInstrRed0;
        private System.Windows.Forms.Button btnReadPin;
        private System.Windows.Forms.Button btnWritePin;
        private System.Windows.Forms.GroupBox grpAspectGreen;
        private System.Windows.Forms.LinkLabel lblAspectG3;
        private System.Windows.Forms.TextBox txtData1Green3;
        private System.Windows.Forms.TextBox txtData0Green3;
        private System.Windows.Forms.ComboBox cmbInstrGreen3;
        private System.Windows.Forms.LinkLabel lblAspectG2;
        private System.Windows.Forms.TextBox txtData1Green2;
        private System.Windows.Forms.TextBox txtData0Green2;
        private System.Windows.Forms.ComboBox cmbInstrGreen2;
        private System.Windows.Forms.LinkLabel lblAspectG1;
        private System.Windows.Forms.TextBox txtData1Green1;
        private System.Windows.Forms.TextBox txtData0Green1;
        private System.Windows.Forms.ComboBox cmbInstrGreen1;
        private System.Windows.Forms.LinkLabel lblAspectG0;
        private System.Windows.Forms.TextBox txtData1Green0;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtData0Green0;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cmbInstrGreen0;
        private System.Windows.Forms.CheckBox chkReadOnPinSelect;
        private System.Windows.Forms.Button btnClearConfig;
        private System.Windows.Forms.Button btnReadAll;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtPinConfig;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnI2CScan;
        private System.Windows.Forms.ListBox lstBoxI2CDevices;
        private LocoProgrammerUserControls.ucButtonTextBox txtModuleAddress;
        private System.Windows.Forms.ColumnHeader columnHWVersion;
        private System.Windows.Forms.TabPage tabLNI2CConfig;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnCalcPinCount_I2C;
        private System.Windows.Forms.TextBox txtPins_I2C;
        private LocoProgrammerUserControls.ucButtonTextBox txtModuleCount_I2C;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btnUseDottedI2C;
        private System.Windows.Forms.TextBox txtModuleLowI2C;
        private System.Windows.Forms.TextBox txtModuleHighI2C;
        private LocoProgrammerUserControls.ucButtonTextBox txtModuleAddress_I2C;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbS88Reporting;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbButtonBehavior;
        private System.Windows.Forms.Button btnReset;
        private LocoProgrammerUserControls.ucButtonTextBox txtDeviceAddr;
        private System.Windows.Forms.Label label4;
        private LocoProgrammerUserControls.ucButtonTextBox txtDeviceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.ColumnHeader columnFreeMem;
        private System.Windows.Forms.Button btnWatchS88;
        private System.Windows.Forms.Button btnWatchS88_I2C;
        private System.Windows.Forms.Button btnWatchS88_LN;
        private System.Windows.Forms.Button btnImportConfig;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnReadAspectChain;
        private System.Windows.Forms.Button btnThrownRed;
        private System.Windows.Forms.Button btnClosedGreen;
        private System.Windows.Forms.CheckBox chkHandshake;
        private System.Windows.Forms.Button btnToggleAspects;
        private System.Windows.Forms.Button btnExportConfig;
        private System.Windows.Forms.Label lblPWMModulesOnline;
        private System.Windows.Forms.Label lblExternalNVRAM;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblBoard;
        private System.Windows.Forms.Label lblHexDevice;
        private System.Windows.Forms.Button btnReboot;
        private System.Windows.Forms.CheckBox chkAllowFactoryDefaults;
        private System.Windows.Forms.Button btnWriteAspectChain;
        private System.Windows.Forms.TabPage tabVL530L0;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnWatchVL53;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnUseDottedVL53;
        private System.Windows.Forms.TextBox txtVL53ModuleLow;
        private System.Windows.Forms.TextBox txtVL53ModuleHigh;
        private LocoProgrammerUserControls.ucButtonTextBox txtModuleAddress_VL53;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnRefreshVL530values;
        private System.Windows.Forms.TextBox txtLastValSensor3;
        private System.Windows.Forms.Label label41;
        private LocoProgrammerUserControls.ucButtonTextBox txtVL53Sensor3val;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtLastValSensor2;
        private System.Windows.Forms.Label label39;
        private LocoProgrammerUserControls.ucButtonTextBox txtVL53Sensor2val;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtLastValSensor1;
        private System.Windows.Forms.Label label26;
        private LocoProgrammerUserControls.ucButtonTextBox txtVL53Sensor1val;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtLastValSensor0;
        private System.Windows.Forms.Label label25;
        private LocoProgrammerUserControls.ucButtonTextBox txtVL53Sensor0val;
        private System.Windows.Forms.Label lblSensor0;
        private System.Windows.Forms.TextBox txtLastValSensor7;
        private System.Windows.Forms.Label label43;
        private LocoProgrammerUserControls.ucButtonTextBox txtVL53Sensor7val;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtLastValSensor6;
        private System.Windows.Forms.Label label45;
        private LocoProgrammerUserControls.ucButtonTextBox txtVL53Sensor6val;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox txtLastValSensor5;
        private System.Windows.Forms.Label label47;
        private LocoProgrammerUserControls.ucButtonTextBox txtVL53Sensor5val;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtLastValSensor4;
        private System.Windows.Forms.Label label49;
        private LocoProgrammerUserControls.ucButtonTextBox txtVL53Sensor4val;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCopyright;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label lblLastAddr;
        private System.Windows.Forms.Label lblLastAddrI2C;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.ListBox lstCompileFlags;
        private System.Windows.Forms.Label lblBootloaderVersion;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.CheckBox chkUsePCF8574T;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtLog;
    }
}

