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

namespace LocoProgrammerDevices
{
    public static class CustDefines
    {
        //#define VAL_LOCONET_MANUFACTURER 0x0D //13
        //#define VAL_LOCONET_PRODUCTID 0xF0  //Makes F00D
        //#define VAL_LOCONET_ARTNR 2051
        public const UInt16 SUPPORTED_VENDOR_ID = 0xF00D;
        public const UInt16 SUPPORTED_DEVICE_ID1 = 2051;
        public const UInt16 SUPPORTED_DEVICE_ID2 = 2052;

        public enum CV_ACCESSORY_BUILDFLAGS_MASK : byte
        {
            NATIVE_S88_ENABLED = 1,
            PCA9685_I2C_ENABLED = 2,
            PCF8574_I2C_ENABLED = 4,
            AT24CXX_I2C_ENABLED = 8,
            VL53L0X_I2C_ENABLED = 16,
            LOCAL_S88_ENABLED = 32,
        }

        public enum CVADDRESS : UInt16
        {
            SV_BASE_EEPROMSIZE_SW_VERSION = 0x0001,
            SV_DEV_FUNCTION_HARDWARE_VER = 0x8000, //Hardware version
            SV_DEV_FUNCTION_SOFTWARE_VER = 0x8001, //Hardware version            
            SV_MEM_STRING_NAME = 0x0030,
            SV_MEM_STRING_END = 0x0047,

            SV_FREEMEM_L = 0x8002,
            SV_FREEMEM_H = 0x8003,
            SV_EXTPWM_I2C = 0x8004,
            SV_NVRAM_I2C = 0x8005,
            SV_ACCESSORY_BUILDFLAGS = 0x8006,

            CV_VL53L0X_SENSORREADING_START = 0x4028,
            SV_VL53L0X_SENSORREADING_START = CV_VL53L0X_SENSORREADING_START * 2,

            CV_VL53L0X_SENSORREADING_END = 0x402B,
            SV_VL53L0X_SENSORREADING_END = CV_VL53L0X_SENSORREADING_END * 2,

            CV_ACCESSORY_DECODER_S88_START_ADDRES = 0x0004,
            CV_ACCESSORY_DECODER_S88_ADDRES_COUNT = 0x0005,
            CV_ACCESSORY_DECODER_S88_CH2_START_ADDRES = 0x0006,
            CV_ACCESSORY_DECODER_S88_CH2_ADDRES_COUNT = 0x0007,
            CV_ACCESSORY_DECODER_S88_I2C_START_ADDRES = 0x0008,
            CV_ACCESSORY_DECODER_S88_I2C_ADDRES_COUNT = 0x0009,

            CV_ACCESSORY_DECODER_LOCAL_START_ADDRES = 0x000A,
            CV_ACCESSORY_DECODER_LOCAL_READ_COUNT = 0x000B,

            CV_ACCESSORY_DECODER_STOPGO_DEFAULTNC = 0x000C,
            CV_ACCESSORY_DECODER_REPORT_BEHAVIOUR = 0x000D,

            CV_ACCESSORY_VL53L0X_START_ADDRES = 0x000F,
            SV_ACCESSORY_VL53L0X_START_ADDRES = CV_ACCESSORY_VL53L0X_START_ADDRES * 2,

            CV_ACCESSORY_VL53L0X_SENSORVAL_1 = 0x0010,
            SV_ACCESSORY_VL53L0X_SENSORVAL_1 = CV_ACCESSORY_VL53L0X_SENSORVAL_START * 2,

            CV_ACCESSORY_VL53L0X_SENSORVAL_START = CV_ACCESSORY_VL53L0X_SENSORVAL_1,
            SV_ACCESSORY_VL53L0X_SENSORVAL_START = SV_ACCESSORY_VL53L0X_SENSORVAL_1,

            CV_ACCESSORY_VL53L0X_SENSORVAL_2 = CV_ACCESSORY_VL53L0X_SENSORVAL_1 + 1,
            SV_ACCESSORY_VL53L0X_SENSORVAL_2 = CV_ACCESSORY_VL53L0X_SENSORVAL_2 * 2,

            CV_ACCESSORY_VL53L0X_SENSORVAL_3 = CV_ACCESSORY_VL53L0X_SENSORVAL_2 + 1,
            SV_ACCESSORY_VL53L0X_SENSORVAL_3 = CV_ACCESSORY_VL53L0X_SENSORVAL_3 * 2,

            CV_ACCESSORY_VL53L0X_SENSORVAL_4 = CV_ACCESSORY_VL53L0X_SENSORVAL_3 + 1,
            SV_ACCESSORY_VL53L0X_SENSORVAL_4 = CV_ACCESSORY_VL53L0X_SENSORVAL_4 * 2,

            CV_ACCESSORY_VL53L0X_SENSORVAL_5 = CV_ACCESSORY_VL53L0X_SENSORVAL_4 + 1,
            SV_ACCESSORY_VL53L0X_SENSORVAL_5 = CV_ACCESSORY_VL53L0X_SENSORVAL_5 * 2,

            CV_ACCESSORY_VL53L0X_SENSORVAL_6 = CV_ACCESSORY_VL53L0X_SENSORVAL_5 + 1,
            SV_ACCESSORY_VL53L0X_SENSORVAL_6 = CV_ACCESSORY_VL53L0X_SENSORVAL_6 * 2,

            CV_ACCESSORY_VL53L0X_SENSORVAL_7 = CV_ACCESSORY_VL53L0X_SENSORVAL_6 + 1,
            SV_ACCESSORY_VL53L0X_SENSORVAL_7 = CV_ACCESSORY_VL53L0X_SENSORVAL_7 * 2,

            CV_ACCESSORY_VL53L0X_SENSORVAL_8 = CV_ACCESSORY_VL53L0X_SENSORVAL_7 + 1,
            SV_ACCESSORY_VL53L0X_SENSORVAL_8 = CV_ACCESSORY_VL53L0X_SENSORVAL_8 * 2,

            CV_ACCESSORY_LAST_BASE_COLLECTION = CV_ACCESSORY_VL53L0X_SENSORVAL_8,

            CV_ACCESSORY_BOOTLOADER_VERSION = 0x0017,

            CV_ACCESSORY_DECODER_ASPECT_DATA_START = 0x0028, //(CV 28 start ==> 0x4F byte pos)
            SV_ACCESSORY_DECODER_ASPECT_START = CV_ACCESSORY_DECODER_ASPECT_DATA_START * 2, //(CV 48 start ==> 96 byte pos)

            CV_ACCESSORY_DECODER_ASPECT_PIN_COUNT_NO_EXTNVRAM = 32, //32 PINS
            CV_ACCESSORY_DECODER_ASPECT_PIN_COUNT_EXTNVRAM = 64,
            SIZE_ACCESSORY_DECODER_ASPECTSCVS_PER_PIN = 14, //14 CVs for each pin ascpect config (28 bytes)
            //CV_ACCESSORY_DECODER_ASPECT_END = CV_ACCESSORY_DECODER_ASPECT_DATA_START + (CV_ACCESSORY_DECODER_ASPECT_PIN_COUNT_EXTNVRAM * SIZE_ACCESSORY_DECODER_ASPECTSCVS_PER_PIN),
            //
            SIZE_ACCESSORY_DECODER_I2C_BYTES_CONFIG = SIZE_ACCESSORY_DECODER_ASPECTSCVS_PER_PIN * 2, //26 bytes per pin / aspect config
            //SV_ACCESSORY_DECODER_ASPECT_END = CV_ACCESSORY_DECODER_ASPECT_END * 2,
            
            CV_I2C_SCAN_START = 0x4020,
            SV_I2C_SCAN_START = CV_I2C_SCAN_START * 2,
            CV_I2C_SCAN_END = CV_I2C_SCAN_START + 7,
            SV_I2C_SCAN_END = CV_I2C_SCAN_END * 2,

            SV_REPORTALL = 0x8030, //CV-->0x4018
            SV_REBOOT_DEVICE = 0x8034
        }
    }
}
