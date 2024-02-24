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
using Control = System.Windows.Forms.Control;
using LocoProgrammerInterfacing;

namespace LocoProgrammerDevices
{
    internal enum initLevel : byte
    {
        INIT_UNSUPPORTED = 255,
        INIT_NONE = 0,
        INIT_DISCOVERED = 10,
        INIT_BASEDATA = 20,
        INIT_DEVICESTRING = 30,
        INIT_BASE_COMPLETED = 40,
        INIT_DEV_SPECIFIC = 50,
        INIT_DEV_SPECIFIC_DONE = 60,
        INIT_DEV_EXT_FUNCTIONS = 70,
    }

    public class LNcsDeviceManager
    {
        public delegate void LoconetDeviceDiscovered(object sender, LncsDevice device, bool DetailDiscovery);
        //public delegate void ConnectionClosedEvent(object sender);

        public event LoconetDeviceDiscovered onLoconetDeviceDiscovered;
        //public event ConnectionClosedEvent LoconetConnectionClosed;

        private LoconetComsLayer lnComsLayer;
        private LncsDevices lnDevices;
        private Control owner;

        public Control Owner { get => owner; private set => owner = value; }
        public LoconetComsLayer LnComsLayer { get => lnComsLayer; private set => lnComsLayer = value; }

        public void ChangeDeviceSetting(UInt16 Addr, string newName)
        {
            byte[] arrName = Encoding.UTF8.GetBytes(newName);
            Array.Resize(ref arrName, CustDefines.CVADDRESS.SV_MEM_STRING_END - CustDefines.CVADDRESS.SV_MEM_STRING_NAME);

            for (UInt16 i = 0; i < arrName.Length; i += 4)
            {
                LNF_OPC_SV_PROG pkg = new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_WRITE4B, 0, Addr, (UInt16)(CustDefines.CVADDRESS.SV_MEM_STRING_NAME + i));
                pkg.SetByteValue(arrName.Skip(i).ToArray());
                LnComsLayer.Send(pkg);
            }
        }

        public LNcsDeviceManager(LoconetComsLayer comsLayer, Control owner = null, bool sendDiscovery = true)
        {
            LnComsLayer = comsLayer;
            LnComsLayer.LoconetFrameRecieved += layer_LoconetFrameRecieved;
            lnDevices = new LncsDevices(this);
            this.Owner = owner;
            if (sendDiscovery)
            {
                SendDiscovery();
            }
        }

        public void SendDiscovery()
        {
            lnDevices.Clear();
            LoconetFrame msg = new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.DISCOVER);
            LnComsLayer.Send(msg);
        }

        public LncsDevice GetDeviceByAddress(ushort addr, bool requestConfig)
        {
            LncsDevice lncsDevice = lnDevices.GetDevice(addr);
            if(lncsDevice!=null)
            {
                UInt16 i = lncsDevice.StartRetrieveDeviceSpecific(0);
                if(i!=0)
                {
                    LnComsLayer.Send(new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_READ4B, 0, lncsDevice.DeviceAddres, i));
                }
            }
            return lncsDevice;
        }

        internal void OnNewDiscoverdDevice(LncsDevice device, bool DetailedDiscovery)
        {
            if (Owner != null && Owner.InvokeRequired)
            {
                if (onLoconetDeviceDiscovered != null)
                    Owner.Invoke(onLoconetDeviceDiscovered, new object[] { this, device, DetailedDiscovery });
            }
            else
                onLoconetDeviceDiscovered?.Invoke(this, device, DetailedDiscovery);
        }

        private void layer_LoconetFrameRecieved(object sender, LoconetFrame msg)
        {
            if (msg.GetOpcode() == LNopcodes.OPCODE.OPC_SV_PROG && LNF_OPC_SV_PROG.isSupportedFrameType(msg))
            {
                LncsDevice dev;
                LNF_OPC_SV_PROG lpx = new LNF_OPC_SV_PROG(msg);
                switch (lpx.SV_Command)
                {
                    case LNF_OPC_SV_PROG.SVCMD.RPL_DISCOVER:
                        dev = lnDevices.AddDevice(lpx);
                        if (dev.InitLevel == initLevel.INIT_DISCOVERED)
                        {
                            LnComsLayer.Send(new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_READ4B, 0, dev.DeviceAddres, (ushort)CustDefines.CVADDRESS.SV_BASE_EEPROMSIZE_SW_VERSION));
                        }
                        else if (dev.InitLevel == initLevel.INIT_UNSUPPORTED)
                        {
                            onLoconetDeviceDiscovered?.Invoke(this, dev, false);
                        }
                        break;
                    case LNF_OPC_SV_PROG.SVCMD.RPL_READ4B:
                        dev = lnDevices.GetDevice(lpx.DeviceAddress);
                        if(dev != null)
                        {
                            switch(lpx.ValueAddress)
                            {
                                case (ushort)CustDefines.CVADDRESS.SV_BASE_EEPROMSIZE_SW_VERSION:
                                    if (dev.InitLevel == initLevel.INIT_DISCOVERED)
                                        dev.InitLevel = initLevel.INIT_BASEDATA;
                                    dev.eepromsize = lpx.Data0;
                                    dev.SoftwareVersion = lpx.Data1;
                                    //dev.NodeID = lpx.Data2Uint16;

                                    LnComsLayer.Send(new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_READ4B, 0, dev.DeviceAddres, (ushort)CustDefines.CVADDRESS.SV_DEV_FUNCTION_HARDWARE_VER));
                                    break;

                                case (ushort)CustDefines.CVADDRESS.SV_DEV_FUNCTION_HARDWARE_VER:
                                    if (dev.InitLevel == initLevel.INIT_DISCOVERED)
                                        dev.InitLevel = initLevel.INIT_BASEDATA;
                                    dev.SoftwareBuildVersion = lpx.Data0;
                                    dev.HardwareVersion = lpx.Data1;
                                    dev.FreeMemory = lpx.Data2Uint16;

                                    LnComsLayer.Send(new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_READ4B, 0, dev.DeviceAddres, (ushort)CustDefines.CVADDRESS.SV_MEM_STRING_NAME));
                                    break;


                                case ushort n when (n >= (ushort)CustDefines.CVADDRESS.SV_MEM_STRING_NAME && n < (ushort)CustDefines.CVADDRESS.SV_MEM_STRING_END):
                                    //Console.WriteLine("stringindex: " + dev.InitSubLevel);
                                    if(dev.InitLevel == initLevel.INIT_BASEDATA)
                                    {
                                        dev.InitLevel = initLevel.INIT_DEVICESTRING;
                                        dev.InitSubLevel = 0;
                                        dev.DeviceName = "";
                                    }

                                    char[] chars = { (char)lpx.Data0, (char)lpx.Data1, (char)lpx.Data2, (char)lpx.Data3 };
                                    dev.DeviceName += new string(chars).Replace('ÿ', (char)0x0);

                                    if (dev.DeviceName.Contains("\0"))
                                    {
                                        dev.InitLevel = initLevel.INIT_BASE_COMPLETED;
                                        OnNewDiscoverdDevice(dev, false);
                                    }
                                    else
                                    {
                                        dev.InitSubLevel = (ushort)(lpx.ValueAddress - CustDefines.CVADDRESS.SV_MEM_STRING_NAME + 4);
                                        ushort nextAddr = (ushort)(CustDefines.CVADDRESS.SV_MEM_STRING_NAME + dev.InitSubLevel);
                                        if (nextAddr < (ushort)CustDefines.CVADDRESS.SV_MEM_STRING_END)
                                        {
                                            LnComsLayer.Send(new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_READ4B, 0, dev.DeviceAddres, nextAddr));
                                        }
                                        else
                                        {
                                            dev.InitLevel = initLevel.INIT_BASE_COMPLETED;
                                            OnNewDiscoverdDevice(dev, false);
                                        }
                                    }
                                    break;
                                default:
                                    UInt16 ret = dev.NotifyDeviceSpecific(lpx);
                                    if(ret!=0)
                                    {
                                        LnComsLayer.Send(new LNF_OPC_SV_PROG(LNF_OPC_SV_PROG.SVCMD.SV_READ4B, 0, dev.DeviceAddres, ret));
                                    }
                                    else
                                    {
                                        if(dev.InitLevel == initLevel.INIT_DEV_SPECIFIC_DONE)
                                        {
                                            OnNewDiscoverdDevice(dev, true);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
