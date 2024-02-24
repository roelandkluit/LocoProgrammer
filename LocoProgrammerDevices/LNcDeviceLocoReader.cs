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
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LocoProgrammerInterfacing;

namespace LocoProgrammerDevices
{
    public class LNcDeviceLocoReader : LncsDevice
    {
        public delegate void LocoReaderAspectRecieved(object sender, byte pinIndex, bool isEndofAspectChain);
        public delegate void LocoReaderSettingRecieved(object sender, UInt16 CV_Index);
        public event LocoReaderAspectRecieved onAspectRecieved;
        public event LocoReaderSettingRecieved onDeviceSettingOrEnviromentRecieved;
        private byte readAllNextAddr = 0;
        private bool isConfigRead = false;
        private AspectReading untilEndOfAspect = AspectReading.FirstAspect;

        public Struct__ConfigurationPWMPin[] PinConfigurations = new Struct__ConfigurationPWMPin[(int)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_ASPECT_PIN_COUNT_EXTNVRAM];

        //Each CV address is 2 bytes

        private ushort PinAspectReadStartAddr = 0;
        private ushort PinAspectReadUntilAddr = 0;
        private byte pinReadCompleted = 0;
        private byte bExternalNVRAM = 0;
        private byte bBuildFlags = 0;
        private byte bitMaskPWMModulesOnline = 0;

        public byte PinReadCompleted { get => pinReadCompleted; private set => pinReadCompleted = value; }
        public byte hasExternalNVRAM { get => bExternalNVRAM; internal set => bExternalNVRAM = value; }
        public byte DeviceBuildFlags { get => bBuildFlags; internal set => bBuildFlags = value; }

        private enum AspectReading:byte
        {
            FirstAspect = 0,
            SecondAspect,
            SameAspectGroup,
            AllAspects,
            OtherAspect
        }

        public bool hasDeviceBuildFlag(CustDefines.CV_ACCESSORY_BUILDFLAGS_MASK flag)
        {
            return ((byte)(DeviceBuildFlags & (byte)flag) == (byte)flag);
        }

        public string GetOnlinePWMmodules() 
        {
            string ret = "";
            var bits = new System.Collections.BitArray(new byte[] { bitMaskPWMModulesOnline });
            for (int i = bits.Length - 1; i != 0; i--)
            {
                if (bits[i])
                {
                    ret += ((7 - i)+1).ToString() + ", ";
                }
            }
            if (ret == "")
                return "None";
            else
                return ret.Substring(0, ret.Length - 2);
        }

        public UInt16 GetCVValue(CustDefines.CVADDRESS vADDRESS)
        {            
            return (base.cvValues[(UInt16)vADDRESS]).Value;
        }
        public byte GetSVValueFromCV(CustDefines.CVADDRESS vADDRESS, bool FirstByte)
        {
            int index = 0;
            if (!FirstByte)
                index = 1;

            return (base.cvValues[(UInt16)vADDRESS]).AsByteArray[index];
        }

        public LNcDeviceLocoReader(LNcsDeviceManager manager) : base(manager)
        {
            /*for(int i=0;i< PinConfigurations.Length; i++)
            {
                PinConfigurations[i] = new Struct__ConfigurationPWMPin();
            }*/
        }

        public override bool ChangeCV(UInt16 CVIndex, ushort newValue, bool commit = true)
        {
            if(!Enum.IsDefined(typeof(CustDefines.CVADDRESS), CVIndex))
            {
                if(CVIndex < (ushort)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_ASPECT_DATA_START)
                    return false;
            }
            return base.ChangeCV(CVIndex, newValue, commit);
        }

        public void ReadVL53Settings()
        {
            ushort PinAspectReadStartAddr = (ushort)(CustDefines.CVADDRESS.SV_VL53L0X_SENSORREADING_START);
            InitLevel = initLevel.INIT_DEV_SPECIFIC;
            base.RecieveDeviceInformationFromAddress(PinAspectReadStartAddr);
        }

        public void ReadMemfree()
        {
            isConfigRead = true;
            Parent.LnComsLayer.Send(new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_READ4B, 0, DeviceAddres, 0x500));
        }

        internal override UInt16 StartRetrieveDeviceSpecific(uint lastRecievedAddr)
        {
            if (lastRecievedAddr == 0)
            {
                InitLevel = initLevel.INIT_DEV_SPECIFIC;
                return ((UInt16)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_S88_START_ADDRES * 2);
            }
            return 0;
        }

        public void WritePinAspectChainToDevice(byte PinIndexStart, bool showDialog = true)
        {
            LocoProgrammerDevicesForms.frmWriteConfig frmWrite = null;
            if (showDialog)
            {
                frmWrite = new LocoProgrammerDevicesForms.frmWriteConfig();
                frmWrite.ShowStatus("Write changes", "Writing pin Configuration");
            }

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                for (int index = PinIndexStart; index < GetCurrentActiveMaxPins(); index++)
                {
                    if (showDialog && frmWrite.GetStopStatus())
                    {
                        break;
                    }
                    else if (PinConfigurations[index] == null)
                    {
                        break;
                    }
                    //First pin does not have UsePreviousPin set
                    else if (index == PinIndexStart || PinConfigurations[index].UsePreviousPin == 1)
                    {
                        WritePinAspect((byte)index, true);
                        PinConfigurations[index].ImportNotWrittenToDevice = false;
                        if (showDialog)
                        {
                            frmWrite.UpdateStatus("Writing pin: " + index);
                        }
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        break;
                    }
                }
                if (showDialog)
                {
                    frmWrite.CloseForm();
                }
            }).Start();
        }

        public void WriteImportedDataToDevice(byte PinIndexStart, bool showDialog = true)
        {
            LocoProgrammerDevicesForms.frmWriteConfig frmWrite = null;
            if (showDialog)
            {
                frmWrite = new LocoProgrammerDevicesForms.frmWriteConfig();
                frmWrite.ShowStatus("Write changes", "Writing pin Configuration");
            }

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                for (int index = PinIndexStart; index < GetCurrentActiveMaxPins(); index++)
                {
                    if (showDialog && frmWrite.GetStopStatus())
                    {
                        break;
                    }
                    else if (PinConfigurations[index] == null)
                    {
                        break;
                    }
                    //First pin does not have UsePreviousPin set
                    else if (PinConfigurations[index].ImportNotWrittenToDevice)
                    {
                        WritePinAspect((byte)index, true);
                        PinConfigurations[index].ImportNotWrittenToDevice = false;
                        if (showDialog)
                        {
                            frmWrite.UpdateStatus("Writing pin: " + index);
                        }
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        break;
                    }
                }
                if (showDialog)
                {
                    frmWrite.CloseForm();
                }
            }).Start();
        }

        public void WritePinAspect(byte PinIndex, bool commitToDevice=true)
        {
            byte[] data = PinConfigurations[PinIndex].ToByteArray();
            for (int i = 0; i < data.Length; i += 2)
            {
                int writepos = ((((int)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_ASPECT_DATA_START) + (((PinIndex * Struct__ConfigurationPWMPin.BYTE_DATA_LEN) + i) / 2)));
                base.ChangeCV((ushort)(writepos), data[i], data[i + 1], false);
            }
            if(commitToDevice)
                CommitCV((ushort)(((int)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_ASPECT_DATA_START) + (((PinIndex * Struct__ConfigurationPWMPin.BYTE_DATA_LEN)) / 2)), 14);
        }

        public void ReadI2CDevices()
        {
            isConfigRead = true;
            PinReadCompleted = 0;
            PinAspectReadStartAddr = (ushort)CustDefines.CVADDRESS.CV_I2C_SCAN_START * 2;
            PinAspectReadUntilAddr = (ushort)CustDefines.CVADDRESS.CV_I2C_SCAN_END * 2;
            InitLevel = initLevel.INIT_DEV_EXT_FUNCTIONS;
            readAllNextAddr = 255;
            base.RecieveDeviceInformationFromAddress(PinAspectReadStartAddr);
        }

        public void ReadSinglePinAspect(byte PinIndex)
        {
            readAllNextAddr = 255;
            ReadPinAspect(PinIndex);
        }

        internal void ReadPinAspect(byte PinIndex)
        {
            isConfigRead = false;
            PinReadCompleted = 0;
            PinAspectReadStartAddr = (ushort)(((ushort)CustDefines.CVADDRESS.SV_ACCESSORY_DECODER_ASPECT_START) + (PinIndex * Struct__ConfigurationPWMPin.BYTE_DATA_LEN));
            PinAspectReadUntilAddr = (ushort)(((ushort)CustDefines.CVADDRESS.SV_ACCESSORY_DECODER_ASPECT_START) + ((PinIndex + 1) * Struct__ConfigurationPWMPin.BYTE_DATA_LEN) - 4);
            InitLevel = initLevel.INIT_DEV_SPECIFIC;
            base.RecieveDeviceInformationFromAddress(PinAspectReadStartAddr);
        }

        public void ReadAllPinAspect()
        {
            isConfigRead = false;
            untilEndOfAspect = AspectReading.AllAspects;
            readAllNextAddr = 0;
            ReadPinAspect(0);
        }

        public void ReadAllPinAspectTillNextChain(byte startIndex)
        {
            isConfigRead = false;
            untilEndOfAspect = AspectReading.FirstAspect;
            readAllNextAddr = startIndex;
            ReadPinAspect(startIndex);
        }

        public ushort GetCurrentActiveMaxPins()
        {
            if (this.bExternalNVRAM > 0)
                return (ushort)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_ASPECT_PIN_COUNT_EXTNVRAM;
            else
                return (ushort)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_ASPECT_PIN_COUNT_NO_EXTNVRAM;
        }

        public ushort GetLastAspectSV()
        {
            return (ushort)((ushort)CustDefines.CVADDRESS.SV_ACCESSORY_DECODER_ASPECT_START + (GetCurrentActiveMaxPins() * (ushort)CustDefines.CVADDRESS.SIZE_ACCESSORY_DECODER_I2C_BYTES_CONFIG));
        }

        public void OnReadPinAspectOrConfigCompleted()
        {
            if (isConfigRead)
            {
                if (Parent.Owner != null && Parent.Owner.InvokeRequired)
                {
                    if (onAspectRecieved != null)
                        Parent.Owner.Invoke(onDeviceSettingOrEnviromentRecieved, new object[] { this, PinAspectReadStartAddr / 2});
                }
                else
                    onDeviceSettingOrEnviromentRecieved?.Invoke(this, (ushort)(PinAspectReadStartAddr / 2));
            }
            else
            {
                bool isEndOfAspect = false;
                PinReadCompleted = (byte)((PinAspectReadStartAddr - ((ushort)CustDefines.CVADDRESS.SV_ACCESSORY_DECODER_ASPECT_START)) / Struct__ConfigurationPWMPin.BYTE_DATA_LEN);
                if (pinReadCompleted > GetCurrentActiveMaxPins())
                    throw new Exception("Unexpected pin index: " + PinReadCompleted);

                byte[] data = base.GetCVBytes((ushort)(PinAspectReadStartAddr / 2), Struct__ConfigurationPWMPin.BYTE_DATA_LEN);
                PinConfigurations[pinReadCompleted] = Struct__ConfigurationPWMPin.FromByteArray(data);

                if (untilEndOfAspect == AspectReading.FirstAspect)
                {
                    untilEndOfAspect = AspectReading.SecondAspect;
                }
                else if(untilEndOfAspect == AspectReading.AllAspects)
                {
                    //Continue
                }
                else
                {
                    if (pinReadCompleted != 0 && PinConfigurations[pinReadCompleted].usePreviousPin == 0)
                    {
                        untilEndOfAspect = AspectReading.OtherAspect;
                    }
                    else
                    {
                        untilEndOfAspect = AspectReading.SameAspectGroup;
                    }
                }

                if (untilEndOfAspect == AspectReading.OtherAspect)
                {
                    //End of aspect chain stop reading
                    readAllNextAddr = 255;
                }

                if (Parent.Owner != null && Parent.Owner.InvokeRequired)
                {
                    if (onAspectRecieved != null)
                        Parent.Owner.Invoke(onAspectRecieved, new object[] { this, pinReadCompleted, isEndOfAspect });
                }
                else
                    onAspectRecieved?.Invoke(this, pinReadCompleted, isEndOfAspect);
            }
        }

        internal override ushort NotifyDeviceSpecific(LNF_OPC_SV_PROG package)
        {
            try
            {
                base.NotifyDeviceSpecific(package);
                if (InitLevel == initLevel.INIT_DEV_EXT_FUNCTIONS || (package.ValueAddress >= (ushort)CustDefines.CVADDRESS.SV_ACCESSORY_DECODER_ASPECT_START) && package.ValueAddress <= GetLastAspectSV())
                {
                    if (package.ValueAddress >= PinAspectReadUntilAddr)
                    {
                        InitLevel = initLevel.INIT_DEV_SPECIFIC_DONE;
                        if (PinAspectReadUntilAddr > 0)
                        {
                            OnReadPinAspectOrConfigCompleted();
                            PinAspectReadUntilAddr = 0;
                            PinAspectReadStartAddr = 0;
                            if(readAllNextAddr!=255)
                            {
                                readAllNextAddr++;
                                if(readAllNextAddr < (byte)GetCurrentActiveMaxPins())
                                { 
                                    ReadPinAspect(readAllNextAddr);
                                }
                                else
                                {
                                    readAllNextAddr = 255;
                                }
                            }
                        }
                        return 0;
                    }
                    else
                    {
                        return (UInt16)(package.ValueAddress + 4);
                    }
                }
                else
                {
                    if (package.ValueAddress == ((ushort)CustDefines.CVADDRESS.SV_EXTPWM_I2C))
                    {
                        this.bitMaskPWMModulesOnline = package.Data0;
                        this.bExternalNVRAM = package.Data1;
                        this.bBuildFlags = package.Data2;
                        InitLevel = initLevel.INIT_DEV_SPECIFIC_DONE;
                        this.parent.OnNewDiscoverdDevice(this, true);
                        return 0;
                    }
                    else if ((package.ValueAddress + 2 >= (UInt16)(CustDefines.CVADDRESS.CV_ACCESSORY_LAST_BASE_COLLECTION) * 2 ) && (package.ValueAddress <= (ushort)(CustDefines.CVADDRESS.SV_EXTPWM_I2C)+4))
                    {
                        //CV base collection done, get SV_EXTPWM_I2C
                        return (ushort)CustDefines.CVADDRESS.SV_EXTPWM_I2C;
                    }
                    else if ((package.ValueAddress + 4) < ((ushort)CustDefines.CVADDRESS.SV_VL53L0X_SENSORREADING_END) && package.ValueAddress >= ((ushort)CustDefines.CVADDRESS.SV_VL53L0X_SENSORREADING_START))
                    {
                        return (UInt16)(package.ValueAddress + 4);
                    }
                    else if ((package.ValueAddress + 4) >= ((ushort)CustDefines.CVADDRESS.SV_VL53L0X_SENSORREADING_END))
                    {
                        this.onDeviceSettingOrEnviromentRecieved(this, (ushort)CustDefines.CVADDRESS.CV_VL53L0X_SENSORREADING_START);
                        return 0;
                    }
                    else if ((package.ValueAddress) < ((ushort)CustDefines.CVADDRESS.SV_I2C_SCAN_END) && package.ValueAddress >= ((ushort)CustDefines.CVADDRESS.SV_I2C_SCAN_START))
                    {
                        return (UInt16)(package.ValueAddress + 4);
                    }
                    else if ((package.ValueAddress) >= ((ushort)CustDefines.CVADDRESS.SV_I2C_SCAN_END))
                    {
                        this.onDeviceSettingOrEnviromentRecieved(this, (ushort)CustDefines.CVADDRESS.CV_I2C_SCAN_START);
                        return 0;
                    }
                    else if ((package.ValueAddress + 2 >= (UInt16)(CustDefines.CVADDRESS.SV_ACCESSORY_VL53L0X_SENSORVAL_8)) && (package.ValueAddress < ((ushort)CustDefines.CVADDRESS.SV_VL53L0X_SENSORREADING_START)))
                    {
                        InitLevel = initLevel.INIT_DEV_SPECIFIC_DONE;
                        this.parent.OnNewDiscoverdDevice(this, true);
                        return (ushort)CustDefines.CVADDRESS.SV_VL53L0X_SENSORREADING_START;
                    }
                    else
                    {
                        return (UInt16)(package.ValueAddress + 4);
                    }
                }
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Exception during processing of data: " + e.Message, "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return 0;
            }
            finally
            {                
            }            
        }
    }
}
