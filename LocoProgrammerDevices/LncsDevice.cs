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
using System.Text;
using System.Threading.Tasks;
using LocoProgrammerInterfacing;

namespace LocoProgrammerDevices
{
    public class LncsDevice
    {
        public delegate void LoconetDeviceCVValueRecieved(object sender, UInt16 CV);
        public event LoconetDeviceCVValueRecieved onCVValueCVValueRecieved;

        internal LNcsDeviceManager parent;

        public class CVvalue
        {
            private UInt16 value = 0;
            private bool modified = false;

            public override string ToString()
            {
                if (modified)
                    return "! 0x" + value.ToString("X");
                else
                    return "0x" + value.ToString("X");
            }

            public byte[] AsByteArray
            {
                get
                {
                    byte[] ret = new byte[2];
                    ret[0] = (byte)(value);
                    ret[1] = (byte)(value >> 8);
                    return ret;
                }
                /*set
                {
                    if (value.Length == 2)
                        Value = (ushort)((value[1] << 8) + value[0]);
                    else
                        throw new InvalidOperationException("Expecting array size of 2");
                }*/
            }

            public ushort Value
            {
                get => value;
                set
                {
                    if(this.value != value)
                        modified = true;
                    this.value = value;
                }
            }

            public bool Modified { get => modified; internal set => modified = value; }

            private CVvalue() { }

            public CVvalue(UInt16 val, bool markAsModified = false)
            {
                this.value = val;
                this.Modified = markAsModified;
            }

            public static CVvalue newCV(UInt16 val, bool markAsModified = false)
            {
                return new CVvalue(val, markAsModified);
            }
        }
        internal initLevel InitLevel = initLevel.INIT_NONE;
        private string deviceName = "";
        internal ushort InitSubLevel = 0;
        private UInt16 deviceAddres = 0;
        private UInt16 serialNumber = 0;
        private UInt16 deviceID = 0;
        private UInt16 vendorID = 0;
        private UInt16 freeMemory = 0;
        //byte value read 1-4
        internal byte eepromsize = 0;
        private byte hardwareVersion = 0;
        private byte softwareBuildVersion = 0;
        private byte softwareVersion = 0;
        //internal UInt16 NodeID = 0;
        internal Dictionary<UInt16, CVvalue> cvValues = new Dictionary<ushort, CVvalue>();

        public LNcsDeviceManager Parent { get => parent; }

        public byte SoftwareVersion { get => softwareVersion; internal set => softwareVersion = value; }
        public string DeviceName { get => deviceName; internal set => deviceName = value; }
        public ushort DeviceAddres { get => deviceAddres; internal set => deviceAddres = value; }
        public ushort SerialNumber { get => serialNumber; internal set => serialNumber = value; }
        public ushort DeviceID { get => deviceID; internal set => deviceID = value; }
        public ushort VendorID { get => vendorID; internal set => vendorID = value; }
        public byte HardwareVersion { get => hardwareVersion; internal set => hardwareVersion = value; }
        public byte SoftwareBuildVersion { get => softwareBuildVersion; internal set => softwareBuildVersion = value; }
        public ushort FreeMemory { get => freeMemory; internal set => freeMemory = value; }

        public bool isSupportedDevice
        {
            get
            {
                return InitLevel != initLevel.INIT_UNSUPPORTED;
            }
        }

        public byte[] GetCVBytes(ushort CV_Start, UInt16 BytesCount)
        {
            if ((BytesCount % 2) != 0)
                throw new Exception("Expecting multiple of bytecount");
            //A CV consists of 2 SV values (8 bit vs 16 bit)

            byte[] outb = new byte[BytesCount];
            for (ushort i = 0; i < (BytesCount / 2); i++)
            {
                if (cvValues.ContainsKey((ushort)(CV_Start + i)))
                {
                    cvValues[(ushort)(CV_Start + i)].AsByteArray.CopyTo(outb, i * 2);
                }
                else
                {
                    throw new KeyNotFoundException("Retrieved CV Values do not contain the requested value");
                }
            }
            return outb;
        }

        public UInt16 GetCV(ushort CV)
        {
            if (cvValues.ContainsKey((ushort)(CV)))
            {
                return cvValues[CV].Value;
            }
            throw new Exception("CV " + CV + "not found in local cache");
        }

        public string GetSoftwareVersion()
        {
            return (SoftwareVersion >> 5).ToString() + "." + (SoftwareVersion & 0x1F).ToString() + "." + softwareBuildVersion.ToString();
        }

        private void OnNewCVValueRecieved(ushort CVIndex)
        {
            if (Parent.Owner != null && Parent.Owner.InvokeRequired)
            {
                if (onCVValueCVValueRecieved != null)
                    Parent.Owner.Invoke(onCVValueCVValueRecieved, new object[] { this, CVIndex });
            }
            else
                onCVValueCVValueRecieved?.Invoke(this, CVIndex);
        }

        public void ResetDevice()
        {
            LNF_OPC_SV_PROG pkg = new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.RECONFIG, 0, deviceAddres, 0);
            Parent.LnComsLayer.Send(pkg);
        }

        public LncsDevice(LNcsDeviceManager Owner)
        {
            this.parent = Owner;
        }

        public bool Match(UInt16 VendorID, UInt16 DeviceID, UInt16 SerialNumber)
        {
            if (VendorID == this.VendorID && DeviceID == this.DeviceID && SerialNumber == this.SerialNumber)
                return true;
            return false;
        }

        internal virtual UInt16 StartRetrieveDeviceSpecific(uint lastRecievedAddr)
        {
            return 0;
        }

        public void RecieveDeviceInformationFromAddress(UInt16 memaddr)
        {
            Parent.LnComsLayer.Send(new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_READ4B, 0, deviceAddres, memaddr));
        }

        public void RecieveDeviceInformationFromSingleAddress(UInt16 memaddr)
        {
            Parent.LnComsLayer.Send(new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_READ, 0, deviceAddres, memaddr));
        }

        public void RebootDevice()
        {
            Parent.LnComsLayer.Send(new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_READ, 0, deviceAddres, (ushort)CustDefines.CVADDRESS.SV_REBOOT_DEVICE));
        }


        public void ChangeAddress(UInt16 newAddress)
        {
            LNF_OPC_SV_PROG pkg = new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.CHANGEADDR, 0, newAddress, VendorID);
            pkg.Data0Uint16 = DeviceID;
            pkg.Data2Uint16 = serialNumber;
            Parent.LnComsLayer.Send(pkg);
            this.deviceAddres = newAddress;
        }

        public void RenameDevice(string newName)
        {
            byte[] arrName = Encoding.UTF8.GetBytes(newName);
            Array.Resize(ref arrName, CustDefines.CVADDRESS.SV_MEM_STRING_END - CustDefines.CVADDRESS.SV_MEM_STRING_NAME);

            for (UInt16 i = 0; i < arrName.Length; i += 4)
            {
                LNF_OPC_SV_PROG pkg = new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_WRITE4B, 0, deviceAddres, (UInt16)(CustDefines.CVADDRESS.SV_MEM_STRING_NAME + i));
                pkg.SetByteValue(arrName.Skip(i).ToArray());
                Parent.LnComsLayer.Send(pkg);
            }
        }

        public virtual bool ChangeCV(UInt16 CVIndex, byte newValue0, byte newValue1, bool commit = true)
        {
            return ChangeCV(CVIndex, (ushort)((newValue1 << 8) + newValue0), commit);
        }

        public virtual bool CommitCV(UInt16 StartCVIndex, UInt16 CVCount)
        {
            bool succes = false;

            for (ushort i = StartCVIndex; i < StartCVIndex + CVCount; i+=2)
            {
                if (StartCVIndex > (UInt16)CustDefines.CVADDRESS.CV_ACCESSORY_DECODER_S88_START_ADDRES)
                {
                    if (StartCVIndex + CVCount - i == 1)
                    {
                        Console.WriteLine("CV-4bytefix");
                        i--;
                    }
                }

                if (cvValues[i].Modified || cvValues[(ushort)(i + 1)].Modified)
                {
                    LNF_OPC_SV_PROG pkg = new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_WRITE4B, 0, deviceAddres, (UInt16)(i * 2));
                    pkg.Data0Uint16 = cvValues[i].Value;
                    pkg.Data2Uint16 = cvValues[(ushort)(i + 1)].Value;
                    Parent.LnComsLayer.Send(pkg);
                    cvValues[i].Modified = false;
                    cvValues[(ushort)(i + 1)].Modified = false;
                    Console.WriteLine(i + "-->" + cvValues[i].Value);
                    succes = true;
                }
            }
            /*if (t == StartCVIndex && cvValues[t].Modified)
            {
                LNF_OPC_SV_PROG pkg = new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_WRITE4B, 0, deviceAddres, (UInt16)(StartCVIndex * 2));
                pkg.Data0Uint16 = cvValues[t].Value;
                pkg.Data2Uint16 = cvValues[(ushort)(t + 1)].Value;
                Parent.LnComsLayer.Send(pkg);
                Console.WriteLine(t + "-->" + cvValues[t].Value);
                succes = true;
            }*/            
            return succes;
        }

        public virtual bool ChangeCVByte(UInt16 CVIndex, byte newValue, bool isHighBitPart, bool commit = true)
        {
            UInt16 modValue = 0;
            if (cvValues.ContainsKey(CVIndex))
                modValue = cvValues[CVIndex].Value;
            else
                cvValues.Add(CVIndex, CVvalue.newCV(0, true));

            if (isHighBitPart)
                modValue = (UInt16)((modValue & 0xFF00) + newValue);
            else                
                modValue = (UInt16)((modValue & 0xFF) + ((UInt16)newValue << 8));

            return ChangeCV(CVIndex, modValue, commit);
        }

        public virtual bool ChangeCV(UInt16 CVIndex, UInt16 newValue, bool commit = true)
        {
            bool succes = false;

            if(cvValues.ContainsKey(CVIndex))
                cvValues[CVIndex].Value = newValue;
            else
                cvValues.Add(CVIndex, new CVvalue(newValue, true));

            if (commit)
            {
                succes = CommitCV(CVIndex, 1);
            }
            return succes;
        }

        private void AddCVtoList(UInt16 Addr, UInt16 value)
        {
            if (cvValues.ContainsKey(Addr))
            {
                cvValues[Addr] = CVvalue.newCV(value);
            }
            else
            {
                cvValues.Add(Addr, CVvalue.newCV(value));
            }
            OnNewCVValueRecieved(Addr);
        }

        internal virtual UInt16 NotifyDeviceSpecific(LNF_OPC_SV_PROG package)
        {
            if (package.SV_Command == LNF_OPC_SV_PROG.SVCMD.RPL_READ4B)
            {
                AddCVtoList((UInt16)(package.ValueAddress / 2), package.Data0Uint16);
                AddCVtoList((UInt16)((package.ValueAddress / 2) + 1), package.Data2Uint16);
            }
            return 0;
        }

        public static string DeviceTypeForI2Caddress(uint address)
        {
            switch (address)
            {
                case 0x0:
                    return "LConnect I2C Host\t[ID: H-00]";
                case uint n when (n <= 0x0D && n >= 0x05):
                    return "VL530\t[ID: U-" + (address).ToString("D2") + "]";
                case 0x29:
                    return "VL53L0X Reporter\t[ID: O-VL53M]";
                case uint n when (n <= 0x28 && n >= 0x20):
                    return "Occupation reporter T\t[ID: O-" + (address - 0x20 + 1).ToString("D2") + "]";
                case 0x50:
                    return "AT24CXX NVRAM\t[ID: NVRAM]";
                case 0x58:
                    return "AT24CXX ADDR2\t[ID: NVRAM]";
                case uint n when (n <= 0x40 && n >= 0x38):
                    return "Occupation reporter AT\t[ID: O-" + (address - 0x38 + 1).ToString("D2") + "]";
                case 0x60:
                case 0x61:
                case 0x62:
                case 0x63:
                    return "Servo & Led controller\t[ID: C-" + (address - 0x60 + 1).ToString("D2") + "]";
                case 0x74:
                    return "PCA9548A for VL53L0x\t[ID: O-PC95]";
                default:
                    return "Unknown\t";
            }
        }

        public static LncsDevice newDevice(LNcsDeviceManager deviceManager, UInt16 VendorID, UInt16 DeviceID, UInt16 SerialNumber, UInt16 DeviceAddres)
        {
            LncsDevice n;
            if (VendorID == CustDefines.SUPPORTED_VENDOR_ID && DeviceID == CustDefines.SUPPORTED_DEVICE_ID1)
            {
                n = new LNcDeviceLocoReader(deviceManager);
                n.InitLevel = initLevel.INIT_DISCOVERED;
            }
            else
            {
                n = new LncsDevice(deviceManager);
                n.InitLevel = initLevel.INIT_UNSUPPORTED;
                n.DeviceName = "[Unsupported]";
            }
            n.VendorID = VendorID;
            n.DeviceID = DeviceID;
            n.DeviceAddres = DeviceAddres;
            n.SerialNumber = SerialNumber;
            return n;
        }
    }

    public class LncsDevices
    {
        private List<LncsDevice> lncsDevices = new List<LncsDevice>();
        private LNcsDeviceManager Owner;

        public LncsDevices(LNcsDeviceManager Parent)
        {
            this.Owner = Parent;
        }

        public LncsDevice GetDevice(UInt16 VendorID, UInt16 DeviceID, UInt16 SerialNumber)
        {
            foreach (LncsDevice dev in lncsDevices)
            {
                if (dev.Match(VendorID, DeviceID, SerialNumber))
                {
                    return dev;
                }
            }
            return null;
        }

        public void Clear()
        {
            lncsDevices.Clear();
        }

        public LncsDevice GetDevice(UInt16 DeviceAddress)
        {
            if (DeviceAddress != 0)
            {

                foreach (LncsDevice dev in lncsDevices)
                {
                    if (dev.DeviceAddres == DeviceAddress)
                        return dev;
                }
            }
            return null;
        }

        public LncsDevice AddDevice(LNF_OPC_SV_PROG DiscoverResult)
        {
            return AddDevice(DiscoverResult.ValueAddress, DiscoverResult.Data0Uint16, DiscoverResult.Data2Uint16, DiscoverResult.DeviceAddress);
        }

        public LncsDevice AddDevice(UInt16 VendorID, UInt16 DeviceID, UInt16 SerialNumber, UInt16 DeviceAddres)
        {
            LncsDevice dev;
            if ((dev = GetDevice(VendorID, DeviceID, SerialNumber)) != null)
            {
                if (DeviceAddres != dev.DeviceAddres)
                {
                    //address changed
                    dev.DeviceAddres = DeviceAddres;
                }
                return dev;
            }
            LncsDevice lncs = LncsDevice.newDevice(this.Owner, VendorID, DeviceID, SerialNumber, DeviceAddres);
            lncsDevices.Add(lncs);
            return lncs;
        }
    }
}
