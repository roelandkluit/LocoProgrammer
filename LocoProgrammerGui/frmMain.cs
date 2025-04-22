/*
"Commons Clause" License Condition v1.0

The Software is provided to you by the Licensor under the License, as defined below, subject to the following condition.

Without limiting other conditions in the License, the grant of rights under the License will not include, and the License does not grant to you, the right to Sell the Software.

For purposes of the foregoing, "Sell" means practicing any or all of the rights granted to you under the License to provide to third parties,
for a fee or other consideration (including without limitation fees for hosting or consulting/ support services related to the Software),
a product or service whose value derives, entirely or substantially, from the functionality of the Software.
Any license notice or attribution required by the License must also include this Commons Clause License Condition notice.

Software: LocoConnect
License: GPLv3
Licensor: Roeland Kluit

Copyright (C) 2024 Roeland Kluit - v0.6 Februari 2024 - All rights reserved -

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

The Software is provided to you by the Licensor under the License,
as defined, subject to the following condition.

Without limiting other conditions in the License, the grant of rights
under the License will not include, and the License does not grant to
you, the right to Sell the Software.

For purposes of the foregoing, "Sell" means practicing any or all of
the rights granted to you under the License to provide to third
parties, for a fee or other consideration (including without
limitation fees for hosting or consulting/ support services related
to the Software), a product or service whose value derives, entirely
or substantially, from the functionality of the Software.
Any license notice or attribution required by the License must also
include this Commons Clause License Condition notice.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using net.sf.loconetovertcp;
using LocoProgrammerUserControls;
using LocoProgrammerInterfacing;
using LocoProgrammerDevices;
using System.Reflection;
using System.IO;
using System.Threading;
using Microsoft.Win32;

namespace LocoProgrammer
{
    public partial class frmMain : Form
    {
        LoconetComsLayer LoconetComs;
        LNcsDeviceManager lnDeviceList;
        LncsDevice selectedLncsDevice;

        private int previousSelectedIndexAspect = -1;
        private bool currentPinAspectIsChanged = false;

        private void ShowErrorMessage(String Message, String Title = "Unable to perform action")
        {
            MessageBox.Show(this, Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public LncsDevice SelectedLncsDevice
        {
            get => selectedLncsDevice;
            set
            {
                if (SelectedLncsDevice != value)
                {
                    CurrentAspectIsDirty = false;
                    previousSelectedIndexAspect = -1;
                    lstBoxI2CDevices.Items.Clear();
                    if (value == null)
                    {
                        if (selectedLncsDevice != null)
                        {
                            if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
                            {
                                ((LNcDeviceLocoReader)selectedLncsDevice).onAspectRecieved -= selectedLncsDevice_onAspectRecieved;
                                ((LNcDeviceLocoReader)selectedLncsDevice).onDeviceSettingOrEnviromentRecieved -= selectedLncsDevice_onDeviceSettingOrEnviromentRecieved;
                            }

                            selectedLncsDevice.onCVValueCVValueRecieved -= SelectedLncsDevice_onCVValueCVValueRecieved;
                            selectedLncsDevice = null;
                            lvDevices.SelectedItems.Clear();
                            tabDeviceConfig.Enabled = false;
                        }
                    }
                    else
                    {
                        selectedLncsDevice = value;
                        if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
                        {
                            ((LNcDeviceLocoReader)SelectedLncsDevice).onAspectRecieved += selectedLncsDevice_onAspectRecieved;
                            ((LNcDeviceLocoReader)selectedLncsDevice).onDeviceSettingOrEnviromentRecieved += selectedLncsDevice_onDeviceSettingOrEnviromentRecieved;
                        }
                        selectedLncsDevice.onCVValueCVValueRecieved += SelectedLncsDevice_onCVValueCVValueRecieved;
                    }
                }
                else
                {
                    //Not changed
                }
            }
        }

        private void selectedLncsDevice_onDeviceSettingOrEnviromentRecieved(object sender, ushort CV_Index)
        {
            if (CV_Index == (ushort)CustDefines.CVADDRESS.CV_I2C_SCAN_START)
            {
                uint devAddr = 0;
                while (CV_Index <= (ushort)CustDefines.CVADDRESS.CV_I2C_SCAN_END)
                {
                    uint val = selectedLncsDevice.GetCV(CV_Index);
                    byte hval = (byte)(val & 0xFF);
                    byte lval = (byte)(val >> 8);

                    //Loop trough each bit of the value to see if we have a device on this address
                    for (int i = 0; i < 8; i++)
                    {
                        if ((hval & (1 << 7 - i)) != 0)
                        {
                            lstBoxI2CDevices.Items.Add("0x" + devAddr.ToString("X2") + " " + LNcDeviceLocoReader.DeviceTypeForI2Caddress(devAddr));
                        }
                        devAddr++;
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        if ((lval & (1 << 7 - i)) != 0)
                        {
                            lstBoxI2CDevices.Items.Add("0x" + devAddr.ToString("X2") + " " + LNcDeviceLocoReader.DeviceTypeForI2Caddress(devAddr));
                        }
                        devAddr++;
                    }
                    CV_Index++;
                }
            }
            if (CV_Index == (ushort)CustDefines.CVADDRESS.CV_VL53L0X_SENSORREADING_START)
            {
                if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
                {
                    try
                    {
                        LNcDeviceLocoReader lncLocoVL530 = (LNcDeviceLocoReader)selectedLncsDevice;
                        txtLastValSensor6.Text = lncLocoVL530.GetSVValueFromCV(CustDefines.CVADDRESS.CV_VL53L0X_SENSORREADING_START + 3, true).ToString();
                        txtLastValSensor7.Text = lncLocoVL530.GetSVValueFromCV(CustDefines.CVADDRESS.CV_VL53L0X_SENSORREADING_START + 3, false).ToString();
                        txtLastValSensor4.Text = lncLocoVL530.GetSVValueFromCV(CustDefines.CVADDRESS.CV_VL53L0X_SENSORREADING_START + 2, true).ToString();
                        txtLastValSensor5.Text = lncLocoVL530.GetSVValueFromCV(CustDefines.CVADDRESS.CV_VL53L0X_SENSORREADING_START + 2, false).ToString();
                        txtLastValSensor2.Text = lncLocoVL530.GetSVValueFromCV(CustDefines.CVADDRESS.CV_VL53L0X_SENSORREADING_START + 1, true).ToString();
                        txtLastValSensor3.Text = lncLocoVL530.GetSVValueFromCV(CustDefines.CVADDRESS.CV_VL53L0X_SENSORREADING_START + 1, false).ToString();
                        txtLastValSensor0.Text = lncLocoVL530.GetSVValueFromCV(CustDefines.CVADDRESS.CV_VL53L0X_SENSORREADING_START, true).ToString();
                        txtLastValSensor1.Text = lncLocoVL530.GetSVValueFromCV(CustDefines.CVADDRESS.CV_VL53L0X_SENSORREADING_START, false).ToString();
                    }
                    catch
                    {
                        //Due to overlap when requesting I2C scan, some CV_VL53L0X_SENSORREADING values might have been already read.
                        //ignore update when missing
                    }
                }
            }
        }
        private void selectedLncsDevice_onAspectRecieved(object sender, byte pinIndex, bool isEndOfAspectChain)
        {
            Console.WriteLine("Aspect Read: " + pinIndex + " end of aspectchain: " + isEndOfAspectChain);
            if ((pinIndex + 1).ToString() == cmbPWMPin.Text)
            {
                SetConfigToFields(pinIndex);
                btnReadPin.BackColor = Color.Transparent;
                CurrentAspectIsDirty = false;
            }
        }

        private void SetConfigToFields(byte pinIndex)
        {
            if (selectedLncsDevice == null)
                return;
            if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                if (lncLocoReader.PinConfigurations[pinIndex] == null)
                {
                    btnReadPin.BackColor = Color.Red;
                    if (chkReadOnPinSelect.Checked)
                        btnReadPin_Click(null, null);
                }
                else
                {
                    btnReadPin.BackColor = Color.Transparent;
                    var t = lncLocoReader.PinConfigurations[pinIndex];
                    {
                        byte[] data = t.ToByteArray();
                        txtPinConfig.Text = Convert.ToBase64String(data);

                        txtPinDCCAddress.Text = t.DccAddress.ToString();
                        chkUsePreviousPin.Checked = t.UsePreviousPin == 1;
                        chkPinInvertOutput.Checked = t.InvertPowerOutput == 1;

                        cmbInstrRed0.SelectedItem = t.pinAspectsRed[0].Instruction;
                        cmbInstrRed1.SelectedItem = t.pinAspectsRed[1].Instruction;
                        cmbInstrRed2.SelectedItem = t.pinAspectsRed[2].Instruction;
                        cmbInstrRed3.SelectedItem = t.pinAspectsRed[3].Instruction;
                        txtData0Red0.Text = t.pinAspectsRed[0].Data0.ToString();
                        txtData0Red1.Text = t.pinAspectsRed[1].Data0.ToString();
                        txtData0Red2.Text = t.pinAspectsRed[2].Data0.ToString();
                        txtData0Red3.Text = t.pinAspectsRed[3].Data0.ToString();
                        txtData1Red0.Text = t.pinAspectsRed[0].Data1.ToString();
                        txtData1Red1.Text = t.pinAspectsRed[1].Data1.ToString();
                        txtData1Red2.Text = t.pinAspectsRed[2].Data1.ToString();
                        txtData1Red3.Text = t.pinAspectsRed[3].Data1.ToString();

                        cmbInstrGreen0.SelectedItem = t.pinAspectsGreen[0].Instruction;
                        cmbInstrGreen1.SelectedItem = t.pinAspectsGreen[1].Instruction;
                        cmbInstrGreen2.SelectedItem = t.pinAspectsGreen[2].Instruction;
                        cmbInstrGreen3.SelectedItem = t.pinAspectsGreen[3].Instruction;
                        txtData0Green0.Text = t.pinAspectsGreen[0].Data0.ToString();
                        txtData0Green1.Text = t.pinAspectsGreen[1].Data0.ToString();
                        txtData0Green2.Text = t.pinAspectsGreen[2].Data0.ToString();
                        txtData0Green3.Text = t.pinAspectsGreen[3].Data0.ToString();
                        txtData1Green0.Text = t.pinAspectsGreen[0].Data1.ToString();
                        txtData1Green1.Text = t.pinAspectsGreen[1].Data1.ToString();
                        txtData1Green2.Text = t.pinAspectsGreen[2].Data1.ToString();
                        txtData1Green3.Text = t.pinAspectsGreen[3].Data1.ToString();
                    }
                }
                CurrentAspectIsDirty = false;
            }
        }

        private void AddBoxItems(ComboBox box)
        {
            foreach (var i in Enum.GetValues(typeof(Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION)))
            {
                box.Items.Add(i);
            }
            box.SelectedIndex = 0;
        }

        private void SelectedLncsDevice_onCVValueCVValueRecieved(object sender, ushort CV)
        {
            //Console.WriteLine("Changed CV:" + CV);
        }

        public frmMain()
        {
            InitializeComponent();
            AddBoxItems(cmbInstrRed0);
            AddBoxItems(cmbInstrRed1);
            AddBoxItems(cmbInstrRed2);
            AddBoxItems(cmbInstrRed3);
            AddBoxItems(cmbInstrGreen0);
            AddBoxItems(cmbInstrGreen1);
            AddBoxItems(cmbInstrGreen2);
            AddBoxItems(cmbInstrGreen3);
            cmbPWMPin.Items.Add("1");
            cmbPWMPin.SelectedIndex = 0;
        }

        private void LnDiscover_onLoconetDeviceDiscovered(object sender, LncsDevice device, bool isDetailed)
        {
            if (!isDetailed)
            {
                var lvi = lvDevices.Items.Add("0x" + device.DeviceAddres.ToString("X2"));
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "0x" + device.DeviceID.ToString("X2")));
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, device.DeviceName));
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "0x" + device.VendorID.ToString("X2")));
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "0x" + device.SerialNumber.ToString("X2")));
                if (device.isSupportedDevice)
                {
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, device.GetSoftwareVersion()));
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, device.HardwareVersion.ToString()));
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, device.FreeMemory.ToString()));

                }
                else
                {
                    lvi.BackColor = Color.LightGray;
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "n/a"));
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "n/a"));
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "n/a"));
                }
            }
            else
            {
                if (SelectedLncsDevice != null)
                {
                    if (device.DeviceAddres == SelectedLncsDevice.DeviceAddres)
                    {
                        UpdatePanel();
                    }
                }
            }
            UpdateStatus();
        }

        private void UpdatePanel()
        {
            if (SelectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                tabDeviceConfig.Enabled = true;

                if (!tabDeviceConfig.TabPages.Contains(tabLNS88Config))
                {
                    tabDeviceConfig.TabPages.Add(tabLNS88Config);
                }

                if (!tabDeviceConfig.TabPages.Contains(tabVL530L0))
                {
                    tabDeviceConfig.TabPages.Add(tabVL530L0);
                }

                LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                if (lncLocoReader.HardwareVersion <= 2)
                {
                    tabDeviceConfig.TabPages.Remove(tabLNI2CConfig);
                    tabDeviceConfig.TabPages.Remove(tabPWMpinConfig);
                    tabDeviceConfig.TabPages.Remove(tabVL530L0);
                }
                else
                {
                    if (!tabDeviceConfig.TabPages.Contains(tabLNI2CConfig))
                    {
                        tabDeviceConfig.TabPages.Add(tabLNI2CConfig);
                    }
                    if (!tabDeviceConfig.TabPages.Contains(tabPWMpinConfig))
                    {
                        tabDeviceConfig.TabPages.Add(tabPWMpinConfig);
                    }                    

                    int iSel = cmbPWMPin.SelectedIndex;
                    cmbPWMPin.Items.Clear();

                    int pincount = (int)lncLocoReader.GetCurrentActiveMaxPins();
                    for (int i = 0; i < pincount; i++)
                    {
                        
                        cmbPWMPin.Items.Add((i + 1).ToString());
                        if (i == iSel)
                            cmbPWMPin.SelectedIndex = i;
                    }

                    //lstBoxI2CDevices.Items.Clear(); //Don't clear at this time. Discovery notification clears results
                }

                //Todo check for other buildflags in CustDefines.CV_ACCESSORY_BUILDFLAGS_MASK.*
                if (!lncLocoReader.hasDeviceBuildFlag(CustDefines.CV_ACCESSORY_BUILDFLAGS_MASK.VL53L0X_I2C_ENABLED))
                {
                    tabDeviceConfig.TabPages.Remove(tabVL530L0);
                }

                CustDefines.CV_ACCESSORY_BUILDFLAGS_MASK[] items = (CustDefines.CV_ACCESSORY_BUILDFLAGS_MASK[])Enum.GetValues(typeof(CustDefines.CV_ACCESSORY_BUILDFLAGS_MASK));
                lstCompileFlags.Items.Clear();

                foreach (var itm in items)
                {
                    if (lncLocoReader.hasDeviceBuildFlag(itm))
                    {
                        lstCompileFlags.Items.Add(itm.ToString());
                    }
                }

                txtDeviceName.OriginalText = lncLocoReader.DeviceName;
                txtModuleAddress.OriginalText = lncLocoReader.GetCVValue(CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_S88_START_ADDRES).ToString();
                txtModuleCount.OriginalText = lncLocoReader.GetCVValue(CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_S88_ADDRES_COUNT).ToString();
                txtModuleAddress_I2C.OriginalText = lncLocoReader.GetCVValue(CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_S88_I2C_START_ADDRES).ToString();
                ushort valI2C = lncLocoReader.GetCVValue(CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_S88_I2C_ADDRES_COUNT);
                txtModuleCount_I2C.OriginalText = (valI2C & 0xFF).ToString();
                if((valI2C >> 8) != 0)
                {
                    chkUsePCF8574T.Checked = true;
                }
                else
                {
                    chkUsePCF8574T.Checked = false;
                }
                txtDeviceAddr.OriginalText = lncLocoReader.DeviceAddres.ToString();
                txtPins_Local.OriginalText = lncLocoReader.GetCVValue(CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_LOCAL_READ_COUNT).ToString();
                txtModuleAddress_Local.OriginalText = lncLocoReader.GetCVValue(CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_LOCAL_START_ADDRES).ToString();
                lblExternalNVRAM.Text = (lncLocoReader.hasExternalNVRAM) + " KBytes";
                lblPWMModulesOnline.Text = lncLocoReader.GetOnlinePWMmodules();

                uint val = lncLocoReader.GetCVValue(CustDefines.CVADDRESS.CV_ACCESSORY_BOOTLOADER_VERSION);
                if (val != 0 && val != 0xFFFF)
                {
                    lblBootloaderVersion.Text = (val >> 4).ToString() + "." + (val & 0xF).ToString();
                }
                else
                {
                    lblBootloaderVersion.Text = "Unkown";
                }

                txtVL53Sensor0val.OriginalText = lncLocoReader.GetSVValueFromCV(CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START, true).ToString();
                txtVL53Sensor1val.OriginalText = lncLocoReader.GetSVValueFromCV(CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START, false).ToString();
                txtVL53Sensor2val.OriginalText = lncLocoReader.GetSVValueFromCV(CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START + 1, true).ToString();
                txtVL53Sensor3val.OriginalText = lncLocoReader.GetSVValueFromCV(CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START + 1, false).ToString();
                txtVL53Sensor4val.OriginalText = lncLocoReader.GetSVValueFromCV(CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START + 2, true).ToString();
                txtVL53Sensor5val.OriginalText = lncLocoReader.GetSVValueFromCV(CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START + 2, false).ToString();
                txtVL53Sensor6val.OriginalText = lncLocoReader.GetSVValueFromCV(CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START + 3, true).ToString();
                txtVL53Sensor7val.OriginalText = lncLocoReader.GetSVValueFromCV(CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START + 3, false).ToString();

                txtLastValSensor0.Text = "";
                txtLastValSensor1.Text = "";
                txtLastValSensor2.Text = "";
                txtLastValSensor3.Text = "";
                txtLastValSensor4.Text = "";
                txtLastValSensor5.Text = "";
                txtLastValSensor6.Text = "";
                txtLastValSensor7.Text = "";

                txtModuleAddress_VL53.OriginalText = lncLocoReader.GetCVValue(CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_START_ADDRES).ToString();
                if (lncLocoReader.GetCVValue(CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_STOPGO_DEFAULTNC) == 0)
                    cmbButtonBehavior.SelectedIndex = 0;
                else
                    cmbButtonBehavior.SelectedIndex = 1;

                try
                {
                    cmbS88Reporting.SelectedIndex = lncLocoReader.GetCVValue(CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_REPORT_BEHAVIOUR);
                }
                catch
                {
                    cmbS88Reporting.SelectedIndex = 0;
                }
            }
        }

        private void LoconetComs_LoconetConnectionClosed(object sender)
        {
            if (LoconetComs != null)
            {
                btnDisconnect_Click(null, null);
                Console.WriteLine("Closed");
            }
        }
        private void LoconetComs_LoconetFrameRecieved(object sender, LoconetFrame msg2)
        {
            if (msg2.GetOpcode() == LNopcodes.OPCODE.OPC_SV_PROG && LNF_OPC_SV_PROG.isSupportedFrameType(msg2))
            {
                LNF_OPC_SV_PROG lpx = new LNF_OPC_SV_PROG(msg2);
                txtLog.Text += msg2.GetOpcode() + "->CMD: " + lpx.SV_Command + "\t>>\t0x" + lpx.ValueAddress.ToString("X4") + "@0x" + lpx.DeviceAddress.ToString("X4") + "\t=> D0: " + lpx.Data0Uint16.ToString("X4") + ", D1: " + lpx.Data2Uint16.ToString("X4") + "\t(" + lpx.Data + ")\r\n";
            }
            else if (msg2.GetOpcode() == LNopcodes.OPCODE.OPC_INPUT_REP && LNF_OPC_INPUT_REP.isSupportedFrameType(msg2))
            {
                LNF_OPC_INPUT_REP lpx = new LNF_OPC_INPUT_REP(msg2);
                txtLog.Text += lpx.ToString() + "\r\n";
            }
            else if (msg2.GetOpcode() == LNopcodes.OPCODE.OPC_SW_REQ && LNF_OPC_SW_REQ.isSupportedFrameType(msg2))
            {
                LNF_OPC_SW_REQ lpx = new LNF_OPC_SW_REQ(msg2);
                txtLog.Text += lpx.ToString() + "\r\n";
            }
            else if (msg2.GetOpcode() == LNopcodes.OPCODE.OPC_GPON)
            {
                txtLog.Text += msg2.GetOpcode() + "->GO\r\n";
                btnGo.BackColor = Color.Green;
                btnStop.BackColor = Color.Transparent;
            }
            else if (msg2.GetOpcode() == LNopcodes.OPCODE.OPC_GPOFF)
            {
                txtLog.Text += msg2.GetOpcode() + "->STOP\r\n";
                btnGo.BackColor = Color.Transparent;
                btnStop.BackColor = Color.Red;
            }
            else
            {
                txtLog.Text += msg2.GetOpcode() + "->" + msg2.ToHexString() + "\r\n";
            }
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }
        private void LoadSettings()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\LocoProgrammer");

                if (key != null)
                {
                    chkHandshake.Checked = Convert.ToBoolean(key.GetValue("Handshake", false));
                    rbLocoSerial.Checked = Convert.ToBoolean(key.GetValue("LocoSerial", false));
                    rbLocoTCP.Checked = Convert.ToBoolean(key.GetValue("LocoTCP", false));
                    cmbSerialPorts.SelectedItem = key.GetValue("SerialPorts", "").ToString();
                    cmbSerialSpeed.SelectedItem = key.GetValue("SerialSpeed", "").ToString();
                    txtServer.Text = key.GetValue("Server", "").ToString();
                    txtPort.Text = key.GetValue("Port", "").ToString();
                    chkReadOnPinSelect.Checked = Convert.ToBoolean(key.GetValue("ReadOnSelect", false));
                    frmMonitorOccupation.enableSound = Convert.ToBoolean(key.GetValue("EnableSound", false));

                    key.Close();
                }
            }
            catch
            {
                MessageBox.Show(this, "Unable to load settings from registry", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettings(bool isOnClose)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\LocoProgrammer");

            if (isOnClose)
            {
                key.SetValue("ReadOnSelect", chkReadOnPinSelect.Checked);
                key.SetValue("EnableSound", frmMonitorOccupation.enableSound);
            }
            else
            { 
                key.SetValue("Handshake", chkHandshake.Checked);
                key.SetValue("LocoSerial", rbLocoSerial.Checked);
                key.SetValue("LocoTCP", rbLocoTCP.Checked);
                key.SetValue("SerialPorts", cmbSerialPorts.SelectedItem?.ToString() ?? "");
                key.SetValue("SerialSpeed", cmbSerialSpeed.SelectedItem?.ToString() ?? "");
                key.SetValue("Server", txtServer.Text);
                key.SetValue("Port", txtPort.Text);
            }

            key.Close();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            rbLocoSerial.Checked = true;
            cmbSerialSpeed.SelectedIndex = 0;
            cmbSerialPorts.Text = "COM7";
            this.Text = this.Text + " [" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "] - " + Assembly.GetExecutingAssembly().GetLinkerTime();
            LoadSettings();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            try
            {
                if (rbLocoSerial.Checked)
                {
                    LoconetComs = new SerialPortLoconetCommunication(cmbSerialPorts.Text, Int32.Parse(cmbSerialSpeed.Text), chkHandshake.Checked, this);
                    LoconetComs.LoconetFrameRecieved += LoconetComs_LoconetFrameRecieved;
                    LoconetComs.LoconetConnectionClosed += LoconetComs_LoconetConnectionClosed;
                    LoconetComs.Connect();
                    lnDeviceList = new LNcsDeviceManager(LoconetComs, this);
                    lnDeviceList.onLoconetDeviceDiscovered += LnDiscover_onLoconetDeviceDiscovered;

                }
                if (rbLocoTCP.Checked)
                {
                    LoconetComs = new LoconetOverTcpClient(txtServer.Text, ushort.Parse(txtPort.Text), this);
                    LoconetComs.LoconetFrameRecieved += LoconetComs_LoconetFrameRecieved;
                    LoconetComs.LoconetConnectionClosed += LoconetComs_LoconetConnectionClosed;
                    LoconetComs.Connect();
                    lnDeviceList = new LNcsDeviceManager(LoconetComs, this);
                    lnDeviceList.onLoconetDeviceDiscovered += LnDiscover_onLoconetDeviceDiscovered;
                }
                SaveSettings(false);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Unable to connect:\n\n" + ex.ToString());
                LoconetComs = null;
                lnDeviceList = null;
                btnConnect.Enabled = true;
                return;
            }

            btnConnect.Visible = false;
            btnConnect.Enabled = true;
            btnDisconnect.Visible = true;
            btnDisconnect.Location = btnConnect.Location;
            rbLocoSerial.Enabled = false;
            cmbSerialSpeed.Enabled = false;
            rbLocoTCP.Enabled = false;
            cmbSerialPorts.Enabled = false;
            chkHandshake.Enabled = false;
            txtPort.Enabled = false;
            txtServer.Enabled = false;
            btnRescan.Enabled = true;
            btnGo.Enabled = true;
            btnStop.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LoconetComs != null)
            {
                if (LoconetComs.Connected)
                {
                    LoconetComs.Disconnect();
                }
            }
            SaveSettings(true);
        }

        private void cmbSerialPorts_Enter(object sender, EventArgs e)
        {
            bool hasSelect = false;
            string text = cmbSerialPorts.Text;
            cmbSerialPorts.Items.Clear();
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cmbSerialPorts.Items.Add(port);
                if (port == text)
                {
                    cmbSerialPorts.SelectedIndex = cmbSerialPorts.Items.Count - 1;
                    hasSelect = true;
                }
            }
            if (!hasSelect && cmbSerialPorts.Items.Count > 0)
            {
                cmbSerialPorts.SelectedIndex = 0;
            }
        }

        private void rbLocoMethod_CheckedChanged(object sender, EventArgs e)
        {
            bool se = false;
            bool tcp = false;

            if (rbLocoSerial.Checked)
            {
                se = true;
                cmbSerialPorts_Enter(sender, null);
            }
            if (rbLocoTCP.Checked)
            {
                tcp = true;
            }

            cmbSerialPorts.Enabled = se;
            cmbSerialSpeed.Enabled = se;
            chkHandshake.Enabled = se;
            txtPort.Enabled = tcp;
            txtServer.Enabled = tcp;

        }

        private void UpdateStatus()
        {
            toolStripStatusLabel.Text = "Found " + lvDevices.Items.Count + " devices";
            if (selectedLncsDevice != null)
            {
                toolStripStatusLabel.Text += ", Selected: 0x" + selectedLncsDevice.DeviceAddres.ToString("X");
            }           
        }

        private void lvDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatus();
            if (lvDevices.SelectedItems.Count == 0)
            {
                SelectedLncsDevice = null;
                return;
            }

            UInt16 SelectedDeviceAddr = Convert.ToUInt16(lvDevices.SelectedItems[0].SubItems[0].Text, 16);
            if (selectedLncsDevice == null || selectedLncsDevice.DeviceAddres != SelectedDeviceAddr)
            {
                SelectedLncsDevice = lnDeviceList.GetDeviceByAddress(SelectedDeviceAddr, true);
            }            
        }

        private void txtDeviceName_ButtonClick(object sender, EventArgs e)
        {
            SelectedLncsDevice.RenameDevice(txtDeviceName.Text);
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            SelectedLncsDevice = null;
            lvDevices.Items.Clear();
            lnDeviceList.SendDiscovery();
        }

        private void txtModuleAddress_ButtonClick(object sender, EventArgs e)
        {
            selectedLncsDevice.ChangeCV((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_S88_START_ADDRES, ushort.Parse(txtModuleAddress.Text));
            txtModuleAddress.OriginalText = txtModuleAddress.Text;
        }

        private void txtModuleCount_ButtonClick(object sender, EventArgs e)
        {
            selectedLncsDevice.ChangeCV((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_S88_ADDRES_COUNT, ushort.Parse(txtModuleCount.Text));
            txtModuleCount.OriginalText = txtModuleCount.Text;
        }

        private void txtModuleAddress_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int modadrr = int.Parse(txtModuleAddress.Text);
                int modHigh = ((modadrr - 1) / 16) + 1;
                int modIndex = modadrr - ((modHigh - 1) * 16);
                txtModuleHigh.Text = modHigh.ToString();
                txtModuleLow.Text = modIndex.ToString();
                UpdateLastModuleLabel(txtModuleAddress.Text, txtModuleCount.Text, lblLastAddr);
            }
            catch { }
        }

        private void btnUseDotted_Click(object sender, EventArgs e)
        {
            try
            {

                uint modHigh = uint.Parse(txtModuleHigh.Text);
                uint modLow = uint.Parse(txtModuleLow.Text);
                uint modadrr = ((modHigh - 1) * 16) + modLow;
                txtModuleAddress.Text = modadrr.ToString();
            }
            catch { }
        }

        private void UpdateLastModuleLabel(String strModStart, String strModCount, Label lastAddrLabel)
        {
            int modcount = (int)uint.Parse(strModCount);
            int lastPin = (int)uint.Parse(strModStart) + (modcount * 8) - 1;
            int modHigh = ((lastPin - 1) / 16) + 1;
            int modIndex = lastPin - ((modHigh - 1) * 16);
            lastAddrLabel.Text = "Last Address: " + modHigh.ToString() + "." + modIndex.ToString();
        }

        private void txtModuleCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int modcount = (int)uint.Parse(txtModuleCount.Text);
                txtPins.Text = (modcount * 8).ToString();
                //Last address calc
                UpdateLastModuleLabel(txtModuleAddress.Text, txtModuleCount.Text, lblLastAddr);
            }
            catch { }
        }

        private void txtDeviceAddr_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                UInt16 val = UInt16.Parse(txtDeviceAddr.Text);
                if (val == 0)
                {
                    ShowErrorMessage("Value not supported");
                    //if (MessageBox.Show(this, "When Device Address is set to 0, the device will be changed to factory defaults after a restart.\nContinue?", "Change Address", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                }
                selectedLncsDevice.ChangeAddress(val);
                btnRescan_Click(sender, e);
            }
            catch(Exception er)
            {
                ShowErrorMessage("Cannot process: " + er.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure to reset to defaults?\n\nThis will reset the configuration and all outputs to default values.\n\n !! This operation cannot be reverted !!", "Reset device", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                selectedLncsDevice.ResetDevice();
                lvDevices.Items.Clear();
                SelectedLncsDevice = null;
                System.Threading.Thread.Sleep(2500);
                btnRescan_Click(sender, e);
            }
        }

        private void cmbButtonBehavior_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLncsDevice.ChangeCV((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_STOPGO_DEFAULTNC, (ushort)cmbButtonBehavior.SelectedIndex);
        }

        private void btnUseDottedLoc_Click(object sender, EventArgs e)
        {
            try
            {

                uint modHigh = uint.Parse(txtLocModuleHigh.Text);
                uint modLow = uint.Parse(txtLocModuleLow.Text);
                uint modadrr = ((modHigh - 1) * 16) + modLow;
                txtModuleAddress_Local.Text = modadrr.ToString();
            }
            catch { }
        }

        private void txtModLocAddress_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int modadrr = int.Parse(txtModuleAddress_Local.Text);
                int modHigh = ((modadrr - 1) / 16) + 1;
                int modIndex = modadrr - ((modHigh - 1) * 16);
                txtLocModuleHigh.Text = modHigh.ToString();
                txtLocModuleLow.Text = modIndex.ToString();
            }
            catch { }

        }

        private void txtModLocAddress_ButtonClick(object sender, EventArgs e)
        {
            selectedLncsDevice.ChangeCV((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_LOCAL_START_ADDRES, ushort.Parse(txtModuleAddress_Local.Text));
            txtModuleAddress_Local.OriginalText = txtModuleAddress_Local.Text;
        }

        private void txtLocModuleCount_ButtonClick(object sender, EventArgs e)
        {
            ushort count = ushort.Parse(txtPins_Local.Text);
            if (count > 4)
                count = 4;

            selectedLncsDevice.ChangeCV((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_LOCAL_READ_COUNT, count);
            txtPins_Local.OriginalText = count.ToString();
        }

        private void cmbS88Reporting_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLncsDevice.ChangeCV((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_REPORT_BEHAVIOUR, (ushort)cmbS88Reporting.SelectedIndex);
        }

        private void btnReadPin_Click(object sender, EventArgs e)
        {
            if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                byte pin = 0;
                if (byte.TryParse(cmbPWMPin.Text, out pin))
                {
                    LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                    lncLocoReader.ReadSinglePinAspect((byte)(pin - 1));
                }
                else
                {
                    ShowErrorMessage("Please select an output", "Invalid Selection");
                }
            }
        }

        private void btnWritePin_Click(object sender, EventArgs e)
        {
            if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                try
                {
                    byte pin = 0;
                    if (byte.TryParse(cmbPWMPin.Text, out pin))
                    {
                        LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                        if (lncLocoReader.PinConfigurations[pin - 1] == null)
                            lncLocoReader.PinConfigurations[pin - 1] = new Struct__ConfigurationPWMPin();
                        var t = lncLocoReader.PinConfigurations[pin - 1];
                        t.DccAddress = ushort.Parse(txtPinDCCAddress.Text);
                        t.InvertPowerOutput = (byte)(chkPinInvertOutput.Checked ? 1 : 0);
                        t.UsePreviousPin = (byte)(chkUsePreviousPin.Checked ? 1 : 0);
                        t.pinAspectsRed[0].SetPinAspect(cmbInstrRed0.SelectedItem, txtData0Red0.Text, txtData1Red0.Text);
                        t.pinAspectsRed[1].SetPinAspect(cmbInstrRed1.SelectedItem, txtData0Red1.Text, txtData1Red1.Text);
                        t.pinAspectsRed[2].SetPinAspect(cmbInstrRed2.SelectedItem, txtData0Red2.Text, txtData1Red2.Text);
                        t.pinAspectsRed[3].SetPinAspect(cmbInstrRed3.SelectedItem, txtData0Red3.Text, txtData1Red3.Text);

                        t.pinAspectsGreen[0].SetPinAspect(cmbInstrGreen0.SelectedItem, txtData0Green0.Text, txtData1Green0.Text);
                        t.pinAspectsGreen[1].SetPinAspect(cmbInstrGreen1.SelectedItem, txtData0Green1.Text, txtData1Green1.Text);
                        t.pinAspectsGreen[2].SetPinAspect(cmbInstrGreen2.SelectedItem, txtData0Green2.Text, txtData1Green2.Text);
                        t.pinAspectsGreen[3].SetPinAspect(cmbInstrGreen3.SelectedItem, txtData0Green3.Text, txtData1Green3.Text);

                        byte[] data = t.ToByteArray();
                        txtPinConfig.Text = Convert.ToBase64String(data);

                        lncLocoReader.WritePinAspect((byte)(pin - 1));
                        CurrentAspectNotWrittenAfterImport = false;
                        //btnReadAspect.BackColor = Color.Transparent;
                        //btnWriteAspect.BackColor = Color.Transparent;
                        CurrentAspectIsDirty = false;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Invalid Pin address??");
                    }
                }
                catch (Exception err)
                {
                    ShowErrorMessage("Unable to write: " + err);
                }
            }
        }


        private void cmbPWMPin_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkUsePreviousPin.Enabled = (cmbPWMPin.SelectedIndex != 0); //Disable use previous for first pin

            if (previousSelectedIndexAspect != cmbPWMPin.SelectedIndex)
            {
                if (CurrentAspectIsDirty && previousSelectedIndexAspect != -1)
                {
                    if (MessageBox.Show(this, "The settings for this aspect have changed. Are you sure to discard these changes?", "Aspect changed", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    {
                        cmbPWMPin.SelectedIndex = previousSelectedIndexAspect;
                        return;
                    }
                }
                int pinID = int.Parse(cmbPWMPin.Text) - 1;
                int board = ((pinID / 16) + 1);
                try
                {
                    if (SelectedLncsDevice != null)
                    {
                        string online = ((LNcDeviceLocoReader)SelectedLncsDevice).GetOnlinePWMmodules();
                        if (online.Contains(board.ToString()))
                        {
                            lblBoard.ForeColor = this.ForeColor;
                            lblBoard.Font = new Font(lblBoard.Font, FontStyle.Regular); ;
                        }
                        else
                        {
                            lblBoard.Font = new Font(lblBoard.Font, FontStyle.Bold);
                            lblBoard.ForeColor = Color.Red;
                        }
                    }
                }
                catch { }
                lblBoard.Text = "Board: " + board.ToString() + ", Pin: " + (pinID % 16).ToString();
                previousSelectedIndexAspect = cmbPWMPin.SelectedIndex;
                SetConfigToFields((byte)(pinID));
            }
        }

        private void tabControlConfig_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == this.tabPWMpinConfig)
            {
                cmbPWMPin_SelectedIndexChanged(null, null);
            }
        }

        private void btnClearConfig_Click(object sender, EventArgs e)
        {
            if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
                {
                    try
                    {

                        byte pin = 0;
                        if (byte.TryParse(cmbPWMPin.Text, out pin))
                        {
                            pin--;
                            LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                            lncLocoReader.PinConfigurations[pin] = new Struct__ConfigurationPWMPin();
                            //lncLocoReader.WritePinAspect((byte)(pin), false);
                            SetConfigToFields(pin);
                            cmbPWMPin_SelectedIndexChanged(null, null);
                        }
                    }
                    catch (Exception err)
                    {
                        ShowErrorMessage("Unable to clear config: " + err);
                    }
                }
            }
        }

        private void btnReadAll_Click(object sender, EventArgs e)
        {
            if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                lncLocoReader.ReadAllPinAspect();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                try
                {
                    byte pin = 0;
                    if (txtPinConfig.Text.Length == 0)
                    {
                        throw new Exception("Empty string provided");
                    }
                    else
                    {
                        if (byte.TryParse(cmbPWMPin.Text, out pin))
                        {
                            pin--;
                            LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                            byte[] data = Convert.FromBase64String(txtPinConfig.Text);
                            lncLocoReader.PinConfigurations[pin] = Struct__ConfigurationPWMPin.FromByteArray(data);
                            lncLocoReader.PinConfigurations[pin].ImportNotWrittenToDevice = true;
                            SetConfigToFields(pin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Cannot use configuration string: " + ex.Message, "Cannot use input string");
                }
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoconetComs != null && sender != null)
                {
                    LoconetComs.Disconnect();
                }
                LoconetComs.LoconetFrameRecieved -= LoconetComs_LoconetFrameRecieved;
                LoconetComs.LoconetConnectionClosed -= LoconetComs_LoconetConnectionClosed;

            }
            catch { }
            LoconetComs = null;
            lnDeviceList = null;
            btnConnect.Visible = true;
            btnDisconnect.Visible = false;
            rbLocoSerial.Enabled = true;
            cmbSerialSpeed.Enabled = true;
            rbLocoTCP.Enabled = true;
            cmbSerialPorts.Enabled = true;
            chkHandshake.Enabled = true;
            txtPort.Enabled = true;
            txtServer.Enabled = true;
            btnRescan.Enabled = false;
            btnGo.Enabled = false;
            btnStop.Enabled = false;
            SelectedLncsDevice = null;
            lvDevices.Items.Clear();
            UpdateStatus();
            rbLocoMethod_CheckedChanged(null, null);
        }

        private void btnI2CScan_Click(object sender, EventArgs e)
        {
            if (selectedLncsDevice.HardwareVersion <= 2)
            {
                ShowErrorMessage("No I2C interface on Hardware versions prior v2");
            }
            else
            {
                if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
                {
                    lstBoxI2CDevices.Items.Clear();
                    LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                    lncLocoReader.ReadI2CDevices();
                }
            }
        }

        private void txtModuleCountI2C_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int modcount = int.Parse(txtModuleCount_I2C.Text);
                txtPins_I2C.Text = (modcount * 8).ToString();
                UpdateLastModuleLabel(txtModuleAddress_I2C.Text, txtModuleCount_I2C.Text, lblLastAddrI2C);
            }
            catch { }

        }

        private void btnUseDottedI2C_Click(object sender, EventArgs e)
        {
            try
            {
                uint modHigh = uint.Parse(txtModuleHighI2C.Text);
                uint modLow = uint.Parse(txtModuleLowI2C.Text);
                uint modadrr = ((modHigh - 1) * 16) + modLow;
                txtModuleAddress_I2C.Text = modadrr.ToString();
            }
            catch { }
        }

        private void txtModuleAddress_I2C_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int modadrr = int.Parse(txtModuleAddress_I2C.Text);
                int modHigh = ((modadrr - 1) / 16) + 1;
                int modIndex = modadrr - ((modHigh - 1) * 16);
                txtModuleHighI2C.Text = modHigh.ToString();
                txtModuleLowI2C.Text = modIndex.ToString();
                UpdateLastModuleLabel(txtModuleAddress_I2C.Text, txtModuleCount_I2C.Text, lblLastAddrI2C);
            }
            catch { }
        }

        private void txtModuleAddress_I2C_ButtonClick(object sender, EventArgs e)
        {
            selectedLncsDevice.ChangeCV((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_S88_I2C_START_ADDRES, ushort.Parse(txtModuleAddress_I2C.Text));
            txtModuleAddress_I2C.OriginalText = txtModuleAddress_I2C.Text;
        }

        private void txtModuleCount_I2C_ButtonClick(object sender, EventArgs e)
        {
            ushort val = (ushort)(ushort.Parse(txtModuleCount_I2C.Text) & 0x1F);
            if (chkUsePCF8574T.Checked)
            {
                //Set bit 9 to high, indicating T instead of AT chips
                val += 1 << 8;
            }
            selectedLncsDevice.ChangeCV((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_S88_I2C_ADDRES_COUNT, val);
            txtModuleCount_I2C.OriginalText = txtModuleCount_I2C.Text;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoconetComs.SendGo();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            LoconetComs.SendStop();
        }

        private void ShowAspectEditor(TextBox data0, TextBox data1, ComboBox cmb, string AspectName)
        {
            frmPinAspect frmPinAsp = new frmPinAspect();
            if (frmPinAsp.AttachWindow(AspectName, data0, data1, (Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION)cmb.SelectedItem))
            {
                frmPinAsp.ShowDialog(this);
            }
            else
            {
                ShowErrorMessage("Invalid Aspect type selection:" + cmb.SelectedItem);
            }

        }

        private void lblAspectR0_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAspectEditor(txtData0Red0, txtData1Red0, cmbInstrRed0, "Red\\Thrown Aspect 1");
        }

        private void lblAspectR1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAspectEditor(txtData0Red1, txtData1Red1, cmbInstrRed1, "Red\\Thrown Aspect 2");
        }

        private void lblAspectR2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAspectEditor(txtData0Red2, txtData1Red2, cmbInstrRed2, "Red\\Thrown Aspect 3");
        }

        private void lblAspectR3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAspectEditor(txtData0Red3, txtData1Red3, cmbInstrRed3, "Red\\Thrown Aspect 4");
        }

        private void lblAspectG0_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAspectEditor(txtData0Green0, txtData1Green0, cmbInstrGreen0, "Green\\Closed Aspect 1");
        }

        private void lblAspectG1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAspectEditor(txtData0Green1, txtData1Green1, cmbInstrGreen1, "Green\\Closed Aspect 2");
        }

        private void lblAspectG2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAspectEditor(txtData0Green2, txtData1Green2, cmbInstrGreen2, "Green\\Closed Aspect 3");
        }

        private void lblAspectG3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAspectEditor(txtData0Green3, txtData1Green3, cmbInstrGreen3, "Green\\Closed Aspect 4");
        }

        private void btnCalcPinCount_Click(object sender, EventArgs e)
        {
            try
            {
                double count = double.Parse(txtPins.Text);
                uint ret = (uint)Math.Ceiling(count / 8);
                txtModuleCount.Text = ret.ToString();
            }
            catch
            {

            }
        }

        private void btnCalcPinCount_I2C_Click(object sender, EventArgs e)
        {
            try
            {
                double count = double.Parse(txtPins_I2C.Text);
                uint ret = (uint)Math.Ceiling(count / 8);
                txtModuleCount_I2C.Text = ret.ToString();
            }
            catch
            {

            }

        }

        private void btnWatchS88_Click(object sender, EventArgs e)
        {
            try
            {

                frmMonitorOccupation frm = new frmMonitorOccupation(this.SelectedLncsDevice, uint.Parse(txtModuleAddress.Text), uint.Parse(txtPins.Text));
                frm.Show(this);
            }
            catch { }
        }

        private void btnWatchS88_I2C_Click(object sender, EventArgs e)
        {
            try
            {
                frmMonitorOccupation frm = new frmMonitorOccupation(this.SelectedLncsDevice, uint.Parse(txtModuleAddress_I2C.Text), uint.Parse(txtPins_I2C.Text));
                frm.Show(this);
            }
            catch { }
        }

        private void btnWatchS88_LN_Click(object sender, EventArgs e)
        {
            try
            {
                frmMonitorOccupation frm = new frmMonitorOccupation(this.SelectedLncsDevice, uint.Parse(txtModuleAddress_Local.Text), uint.Parse(txtPins_Local.Text));
                frm.Show(this);
            }
            catch { }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                AspectImportExport.ExportAspectToFile(this, lncLocoReader, CurrentSelectedAspectPinID);
            }
        }

        private byte CurrentSelectedAspectPinID
        {
            get
            {
                return (byte)(int.Parse(cmbPWMPin.Text) - 1);
            }

        }

        private bool CurrentAspectNotWrittenAfterImport
        {
            get
            {
                if (selectedLncsDevice != null && selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
                {
                    LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                    if (lncLocoReader.PinConfigurations[CurrentSelectedAspectPinID] != null)
                        return lncLocoReader.PinConfigurations[CurrentSelectedAspectPinID].ImportNotWrittenToDevice;
                }
                return false;
            }
            set
            {
                if (selectedLncsDevice != null && selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
                {
                    LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                    if (lncLocoReader.PinConfigurations[CurrentSelectedAspectPinID] != null)
                        lncLocoReader.PinConfigurations[CurrentSelectedAspectPinID].ImportNotWrittenToDevice = value;
                }
            }
        }

        private bool CurrentAspectIsDirty
        {
            get
            {
                return currentPinAspectIsChanged;
            }
            set
            {
                currentPinAspectIsChanged = value;
                if (value || CurrentAspectNotWrittenAfterImport)
                    this.btnWritePin.BackColor = Color.Red;
                else
                {
                    CurrentAspectNotWrittenAfterImport = false;
                    this.btnWritePin.BackColor = Color.Transparent;
                }
            }
        }

        private void AspectSettingOrValueChanged(object sender, EventArgs e)
        {
            CurrentAspectIsDirty = true;
        }

        private void btnImportConfig_Click(object sender, EventArgs e)
        {
            if (selectedLncsDevice != null && selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                if (AspectImportExport.ImportAspectFromFile(this, lncLocoReader, CurrentSelectedAspectPinID))
                {
                    SetConfigToFields((byte)(int.Parse(cmbPWMPin.Text) - 1));
                    if(MessageBox.Show(this, "Do you want to write the imported data to the device?", "Write changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //frmWriteConfig frmWrite = new frmWriteConfig();
                        //frmWrite.Show(this);
                        //frmWrite.ShowStatus("Write changes", "Writing pin Configuration");
                        lncLocoReader.WriteImportedDataToDevice(CurrentSelectedAspectPinID);
                        //frmWrite.Close();
                    }
                }
            }
        }

        private void btnReadAspectChain_Click(object sender, EventArgs e)
        {
            if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                lncLocoReader.ReadAllPinAspectTillNextChain(CurrentSelectedAspectPinID);
            }
        }

        private void btnThrownOrClose_Click(object sender, EventArgs e)
        {
            LNF_OPC_SW_REQ.enumDirection direction;
            if (sender == btnThrownRed)
                direction = LNF_OPC_SW_REQ.enumDirection.DirectionThrownRed;
            else if (sender == btnClosedGreen)
                direction = LNF_OPC_SW_REQ.enumDirection.DirectionClosedGreen;
            else
                return;

            try
            {
                uint addr;
                if (uint.TryParse(txtPinDCCAddress.Text, out addr))
                {
                    LNF_OPC_SW_REQ opcSWreq1 = LNF_OPC_SW_REQ.CreateNew(addr, direction, LNF_OPC_SW_REQ.enumPower.PowerOn);
                    LoconetComs.Send(opcSWreq1);
                    Thread.Sleep(25);
                    LNF_OPC_SW_REQ opcSWreq2 = LNF_OPC_SW_REQ.CreateNew(addr, direction, LNF_OPC_SW_REQ.enumPower.PowerOff);
                    LoconetComs.Send(opcSWreq2);
                }
            }
            catch(Exception ex)
            {
                ShowErrorMessage("Unable to send command: " + ex.Message.ToString());
            }
        }

        private void txtPinConfig_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnToggleAspects_Click(object sender, EventArgs e)
        {
            if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                try
                {
                    byte pin = 0;
                    if (byte.TryParse(cmbPWMPin.Text, out pin))
                    {
                        pin--;
                        LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                        var backupGreen = lncLocoReader.PinConfigurations[pin].pinAspectsGreen;
                        var backupRed = lncLocoReader.PinConfigurations[pin].pinAspectsRed;
                        lncLocoReader.PinConfigurations[pin].pinAspectsGreen = backupRed;
                        lncLocoReader.PinConfigurations[pin].pinAspectsRed = backupGreen;
                        lncLocoReader.PinConfigurations[pin].ImportNotWrittenToDevice = true;
                        SetConfigToFields(pin);                        
                    }
                }
                catch { }
            }
        }

        private void btnExportConfig_Click(object sender, EventArgs e)
        {
            if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                AspectImportExport.ExportAspectToFile(this, lncLocoReader, 0, true);
            }
        }

        private void lblPWMModulesOnline_Click(object sender, EventArgs e)
        {

        }

        private void lblExternalNVRAM_Click(object sender, EventArgs e)
        {

        }

        private void txtDeviceAddr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblHexDevice.Text = "0x" + Convert.ToInt32(txtDeviceAddr.Text).ToString("X2");
            }
            catch
            {
            }
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            if (SelectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {

                LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                lncLocoReader.RebootDevice();
                SelectedLncsDevice = null;
            }
        }

        private void chkAllowFactoryDefaults_CheckedChanged(object sender, EventArgs e)
        {
            btnReset.Enabled = true;
            chkAllowFactoryDefaults.Visible = false;
        }

        private void btnWriteAspectChain_Click(object sender, EventArgs e)
        {
            if (selectedLncsDevice.GetType() == typeof(LNcDeviceLocoReader))
            {
                LNcDeviceLocoReader lncLocoReader = (LNcDeviceLocoReader)SelectedLncsDevice;
                lncLocoReader.WritePinAspectChainToDevice(CurrentSelectedAspectPinID);
                CurrentAspectIsDirty = false;
            }
        }

        private void btnUseDottedVL53_Click(object sender, EventArgs e)
        {
            try
            {
                uint modHigh = uint.Parse(txtVL53ModuleHigh.Text);
                uint modLow = uint.Parse(txtVL53ModuleLow.Text);
                uint modadrr = ((modHigh - 1) * 16) + modLow;
                txtModuleAddress_VL53.Text = modadrr.ToString();
            }
            catch { }
        }

        private void txtModuleAddress_VL53_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int modadrr = int.Parse(txtModuleAddress_VL53.Text);
                int modHigh = ((modadrr - 1) / 16) + 1;
                int modIndex = modadrr - ((modHigh - 1) * 16);
                txtVL53ModuleHigh.Text = modHigh.ToString();
                txtVL53ModuleLow.Text = modIndex.ToString();
            }
            catch { }
        }

        private void txtModuleAddress_VL53_ButtonClick(object sender, EventArgs e)
        {
            selectedLncsDevice.ChangeCV((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_START_ADDRES, ushort.Parse(txtModuleAddress_VL53.Text));
            txtModuleAddress_VL53.OriginalText = txtModuleAddress_VL53.Text;
        }

        private void btnWatchVL53_Click(object sender, EventArgs e)
        {
            try
            {
                frmMonitorOccupation frm = new frmMonitorOccupation(this.SelectedLncsDevice, uint.Parse(txtModuleAddress_VL53.Text), 8);
                frm.Show(this);
            }
            catch { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((LNcDeviceLocoReader)selectedLncsDevice).ReadVL53Settings();
        }

        private void txtVL53Sensor0val_ButtonClick(object sender, EventArgs e)
        {
            if (selectedLncsDevice.ChangeCVByte((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START, byte.Parse(txtVL53Sensor0val.Text), true))
                txtVL53Sensor0val.OriginalText = txtVL53Sensor0val.Text;
        }

        private void txtVL53Sensor1val_ButtonClick(object sender, EventArgs e)
        {
            if (selectedLncsDevice.ChangeCVByte((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START, byte.Parse(txtVL53Sensor1val.Text), false))
                txtVL53Sensor1val.OriginalText = txtVL53Sensor1val.Text;
        }

        private void txtVL53Sensor2val_ButtonClick(object sender, EventArgs e)
        {
            if(selectedLncsDevice.ChangeCVByte((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START + 1, byte.Parse(txtVL53Sensor2val.Text), true))
                txtVL53Sensor2val.OriginalText = txtVL53Sensor2val.Text;
        }

        private void txtVL53Sensor3val_ButtonClick(object sender, EventArgs e)
        {
            if (selectedLncsDevice.ChangeCVByte((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START + 1, byte.Parse(txtVL53Sensor3val.Text), false))
                txtVL53Sensor3val.OriginalText = txtVL53Sensor3val.Text;
        }

        private void txtVL53Sensor4val_ButtonClick(object sender, EventArgs e)
        {
            selectedLncsDevice.ChangeCVByte((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START + 2, byte.Parse(txtVL53Sensor4val.Text), true);
            txtVL53Sensor4val.OriginalText = txtVL53Sensor4val.Text;
        }

        private void txtVL53Sensor5val_ButtonClick(object sender, EventArgs e)
        {
            selectedLncsDevice.ChangeCVByte((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START + 2, byte.Parse(txtVL53Sensor5val.Text), false);
            txtVL53Sensor5val.OriginalText = txtVL53Sensor5val.Text;
        }

        private void txtVL53Sensor6val_ButtonClick(object sender, EventArgs e)
        {
            selectedLncsDevice.ChangeCVByte((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START + 3, byte.Parse(txtVL53Sensor6val.Text), true);
            txtVL53Sensor6val.OriginalText = txtVL53Sensor6val.Text;

        }

        private void txtVL53Sensor7val_ButtonClick(object sender, EventArgs e)
        {
            selectedLncsDevice.ChangeCVByte((ushort)CustDefines.CVADDRESS.CV_ACCESSORY_VL53L0X_SENSORVAL_START + 3, byte.Parse(txtVL53Sensor7val.Text), false);
            txtVL53Sensor7val.OriginalText = txtVL53Sensor7val.Text;
        }

        private void lvDevices_DoubleClick(object sender, EventArgs e)
        {
            selectedLncsDevice = null;
            lvDevices_SelectedIndexChanged(null, null);
        }

        private void toolStripCopyright_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "LocoConnect and LocoProgrammer\r\n\r\nCopyright 2024, Roeland Kluit.\r\n\r\n" +
                                "File Dialog extender:  Copyright (c) 2006, Gustavo Franco, Decebal Mihailescu 2015.\r\n" +
                                "Loconet over TCP: Copyright (c) 2020, by Martin Pischky and Stefan Bormann.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
