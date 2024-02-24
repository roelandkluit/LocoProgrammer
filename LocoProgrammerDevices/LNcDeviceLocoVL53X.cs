/*
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
    public class LNcDeviceLocoVL53X : LncsDevice
    {
        public delegate void LocoReaderAspectRecieved(object sender, byte pinIndex, bool isEndofAspectChain);
        public delegate void LocoReaderSettingRecieved(object sender, UInt16 CV_Index);
        public event LocoReaderSettingRecieved onDeviceSettingOrEnviromentRecieved;        

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

        public LNcDeviceLocoVL53X(LNcsDeviceManager manager) : base(manager)
        {
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

        public void ReadI2CDevices()
        {
            ushort PinAspectReadStartAddr = (ushort)CustDefines.CVADDRESS.CV_I2C_SCAN_START * 2;
            InitLevel = initLevel.INIT_DEV_EXT_FUNCTIONS;
            //readAllNextAddr = 255;
            base.RecieveDeviceInformationFromAddress(PinAspectReadStartAddr);
        }

        public void ReadVL53Settings()
        {
            ushort PinAspectReadStartAddr = (ushort)(CustDefines.CVADDRESS.SV_VL53L0X_SENSORREADING_START);
            InitLevel = initLevel.INIT_DEV_SPECIFIC;
            base.RecieveDeviceInformationFromAddress(PinAspectReadStartAddr);
        }

        internal override ushort NotifyDeviceSpecific(LNF_OPC_SV_PROG package)
        {
            try
            {
                base.NotifyDeviceSpecific(package);
                if (InitLevel == initLevel.INIT_DEV_EXT_FUNCTIONS)
                {
                    InitLevel = initLevel.INIT_DEV_SPECIFIC_DONE;
                    return (UInt16)(package.ValueAddress + 4);
                }
                else
                {
                    if ((package.ValueAddress + 4) < ((ushort)CustDefines.CVADDRESS.SV_VL53L0X_SENSORREADING_END) && package.ValueAddress >= ((ushort)CustDefines.CVADDRESS.SV_VL53L0X_SENSORREADING_START))
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
*/