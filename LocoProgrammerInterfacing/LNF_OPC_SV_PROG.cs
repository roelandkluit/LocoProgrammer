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

namespace LocoProgrammerInterfacing
{
    public class LNF_OPC_SV_PROG: LoconetFrame
    {
		//BYTE1 == 0x10;
		//SVX1 == 0x10; + 4 bits
		//SVX2 == 0x10; + 4 bits
		//SVTYPE == 0x02;

		public enum SVCMD : byte
        {
			//Write and action commands
			SV_WRITE = 0x01, //SV write: write 1 byte of data from D1
			SV_READ = 0x02, //SV read: initiate read 1 byte of data into D1
			SV_MASK_WRITE = 0x03, //SV masked write: write 1 byte of masked data from D1. D2 contains the mask to be used; a 1 bit in D2 means that the corresponding bit should be written.
			SV_WRITE4B = 0x05,//SV write 4 bytes: write 4 bytes of data from D1..D4
			SV_READ4B = 0x06, //SV read 4 bytes: initiate read 4 bytes of data into D1..D4
			DISCOVER = 0x07, //Discover: causes all devices to identify themselves by their MANUFACTURER_ID,DEVELOPER_ID, PRODUCT_ID and Serial Number.
			IDENTIFY = 0x08, //Identify: causes an individual device to identify itself by its MANUFACTURER_ID,DEVELOPER_ID, PRODUCT_ID and Serial Number.
			CHANGEADDR = 0x09, //Change Address: Changes the device address to the values specified in <DST_L> + <DST_H> in the device that matches the values specified in <SV_ADRL> + <SV_ADRH> + <D1>..<D4> that we in the reply to the Discover or Identify command issued previously.
			RECONFIG = 0x0F, //Reconfigure: initiates a device reconfiguration or reset so that any new device configuration becomes active.
			//read response messages, sent in response to a read command:
			RPL_WRITE = 0x41, //REPLY SV write: transfers a write response in D1
			RPL_READ = 0x42, //REPLY SV read: transfers a read response in D1
			RPL_MASK_WRITE = 0x43, //REPLY SV masked write: transfers a masked write response in D1
			RPL_WRITE4B = 0x45, //REPLY SV 4 byte write: transfers a write response in D1..D4
			RPL_READ4B = 0x46, //REPLY SV 4 byte read: transfers a read response in D1..D4
			RPL_DISCOVER = 0x47, //REPLY Discover: transfers an Discover response containing the MANUFACTURER_ID, DEVELOPER_ID, PRODUCT_ID and Serial Number
			RPL_IDENTIFY = 0x48, //REPLY Identify: transfers an Identify response containing the MANUFACTURER_ID,DEVELOPER_ID, PRODUCT_ID and Serial Number
			RPL_CHANGEADDR = 0x49, //Change Address: transfers a Change Address response.
			RPL_RECONFIG = 0x4F, //REPLY Reconfigure: Acknowledgement immediately prior to a device reconfiguration or reset.
		}

		public LNF_OPC_SV_PROG(SVCMD sVCMD, byte Src = 0, UInt16 DeviceAddres = 0, UInt16 ValueAddres = 0)
        {
			LoconetBytes = new byte[15];
			LoconetBytes[0] = (byte)LNopcodes.OPCODE.OPC_SV_PROG;			
			LoconetBytes[1] = 0x10;			
			LoconetBytes[3] = (byte)sVCMD;
			LoconetBytes[4] = 0x02;
			LoconetBytes[5] = 0x10;
			LoconetBytes[10] = 0x10;
			checksumIncluded = false;
			this.src = Src;
			this.DeviceAddress = DeviceAddres;
			this.ValueAddress = ValueAddres;
		}

		public static bool isSupportedFrameType(LoconetFrame loconetMsg)
		{
			if (loconetMsg.GetOpcode() != LNopcodes.OPCODE.OPC_SV_PROG || loconetMsg.LoconetBytes.Length != 16 || loconetMsg.LoconetBytes[1] != 0x10 || loconetMsg.LoconetBytes[4] != 0x02)
			{
				return false;
			}
			return true;
		}

		public LNF_OPC_SV_PROG(LoconetFrame loconetMsg)
        {
			if (!isSupportedFrameType(loconetMsg))
            {
				throw new Exception("Invalid message type for cast");
            }
			this.LoconetBytes = loconetMsg.LoconetBytes;
		}

		public byte src
        {
            get
            {
				return (byte)(LoconetBytes[2] & 0x7F);
			}
            set
            {
				LoconetBytes[2] = (byte)(value & 0x7F);

			}
        }

		public SVCMD SV_Command
        {
            get
            {
				return (SVCMD)(LoconetBytes[3]);
			}
            set
            {
				LoconetBytes[3] = (byte)(value);

			}
        }

		public UInt16 DeviceAddress
        {
            get
            {
				UInt16 usDst = (ushort)((LoconetBytes[7] << 8) + LoconetBytes[6]);
				if ((LoconetBytes[5] & 1) == 1) usDst |= 0x0080;
				if ((LoconetBytes[5] & 2) == 2) usDst |= 0x8000;
				return usDst;
			}
			set
			{
				byte[] byteArray = BitConverter.GetBytes(value);
				LoconetBytes[6] = (byte)(byteArray[0] & 0x7F);
				LoconetBytes[7] = (byte)(byteArray[1] & 0x7F);

				LoconetBytes[5] = SetByteBitValue(LoconetBytes[5], 0x01, (byte)((value & 0x0080) >> 7));
				LoconetBytes[5] = SetByteBitValue(LoconetBytes[5], 0x02, (byte)((value & 0x8000) >> 14));
			}
        }

		private static byte SetByteBitValue(byte CurrentByteValue, byte BitMask, byte ValueToBitOr)
		{
			//Clear any existing value by inverting the mask
			byte clearedexistingvalues = (byte)(CurrentByteValue & (0xFF - BitMask));
			return (byte)(clearedexistingvalues | ValueToBitOr);
		}

		public UInt16 ValueAddress
		{
			get
			{
				UInt16 usVad = (ushort)((LoconetBytes[9] << 8) + LoconetBytes[8]);
				if ((LoconetBytes[5] & 4) == 4) usVad |= 0x0080;
				if ((LoconetBytes[5] & 8) == 8) usVad |= 0x8000;
				return usVad;
			}
			set
			{
				byte[] byteArray = BitConverter.GetBytes(value);
				LoconetBytes[8] = (byte)(byteArray[0] & 0x7F);
				LoconetBytes[9] = (byte)(byteArray[1] & 0x7F);

				LoconetBytes[5] = SetByteBitValue(LoconetBytes[5], 0x04, (byte)((value & 0x0080) >> 5));
				LoconetBytes[5] = SetByteBitValue(LoconetBytes[5], 0x08, (byte)((value & 0x8000) >> 12));
			}
		}

		public byte Data0
		{
			get
			{
				byte usVad = LoconetBytes[11];
				if ((LoconetBytes[10] & 1) == 1) usVad |= 0x0080;
				return usVad;			
			}
            set
            {
				LoconetBytes[11] = (byte)(value & 0x7F);
				LoconetBytes[10] = SetByteBitValue(LoconetBytes[10], 0x01, (byte)((value & 0x0080) >> 7));
			}
		}

		public byte Data1
		{
			get
			{
				byte usVad = LoconetBytes[12];
				if ((LoconetBytes[10] & 2) == 2) usVad |= 0x0080;
				return usVad;
			}
			set
			{
				LoconetBytes[12] = (byte)(value & 0x7F);
				LoconetBytes[10] = SetByteBitValue(LoconetBytes[10], 0x02, (byte)((value & 0x0080) >> 6));
			}
		}

		public byte Data2
		{
			get
			{
				byte usVad = LoconetBytes[13];
				if ((LoconetBytes[10] & 4) == 4) usVad |= 0x0080;
				return usVad;
			}
			set
			{
				LoconetBytes[13] = (byte)(value & 0x7F);
				LoconetBytes[10] = SetByteBitValue(LoconetBytes[10], 0x04, (byte)((value & 0x0080) >> 5));
			}
		}

		public byte Data3
		{
			get
			{
				byte usVad = LoconetBytes[14];
				if ((LoconetBytes[10] & 8) == 8) usVad |= 0x0080;
				return usVad;
			}
			set
			{
				LoconetBytes[14] = (byte)(value & 0x7F);
				LoconetBytes[10] = SetByteBitValue(LoconetBytes[10], 0x08, (byte)((value & 0x0080) >> 4));
			}
		}

		public void SetByteValue(byte[] values)
		{
			try
			{
				this.Data0 = values[0];
				this.Data1 = values[1];
				this.Data2 = values[2];
				this.Data3 = values[3];

			}
			catch { }
		}

		public UInt32 Data
        {
            get
            {
				return (UInt32)((Data0 << 24) + (Data1 << 16) + (Data2 << 8) + Data3);
			}
            set
            {
				Data0 = (byte)(value >> 24);
				Data1 = (byte)(value >> 16);
				Data2 = (byte)(value >> 8);
				Data3 = (byte)(value);
			}
        }

		public UInt16 Data0Uint16
		{
            get
            {
				return (ushort)((Data1 << 8) + Data0);
			}
            set
            {
				Data0 = (byte)(value);
				Data1 = (byte)(value >> 8);
            }
		}

		public UInt16 Data2Uint16
		{
			get
			{
				return (ushort)((Data3 << 8) + Data2);
			}
			set
			{
				Data2 = (byte)(value);
				Data3 = (byte)(value >> 8);
			}
		}

		/*
		public void SetData(byte index, byte value)
		{
			if (index < 4)
			{
				//index 0 - 3
				loconetBytes[index + 11] = value;
			}
			throw new IndexOutOfRangeException();
		}*/

		/*
		 * 0		1		2		3			4			5		6		7		8			9			10		11		12		13		14		15
		 * <0xE5>	<0x10>	<SRC>	<SV_CMD>	<SV_TYPE>	<SVX1>	<DST_L>	<DST_H> <SV_ADRL>	<SV_ADRH>	<SVX2>	<D1>	<D2>	<D3>	<D4>	<CHK>
		 *
		OPC_SV_PROG = 0xE5,   //								NO
			<SRC> 7bit source address for the device issuing the programming command.
				0x0 to 0xF: typically PCs
				0x10 to 0x7F: other LocoNet devices

				<SV_CMD> Specifies the SV access type
				0x01 = SV write: write 1 byte of data from D1
				0x02 = SV read: initiate read 1 byte of data into D1
				0x03 = SV masked write: write 1 byte of masked data from D1. D2 contains the mask to be used; a 1 bit in D2 means that the corresponding bit should be written.
				0x05 = SV write 4 bytes: write 4 bytes of data from D1..D4
				0x06 = SV read 4 bytes: initiate read 4 bytes of data into D1..D4
				0x07 = Discover: causes all devices to identify themselves by their MANUFACTURER_ID,DEVELOPER_ID, PRODUCT_ID and Serial Number.
				0x08 = Identify: causes an individual device to identify itself by its MANUFACTURER_ID,	DEVELOPER_ID, PRODUCT_ID and Serial Number.
				0x09 = Change Address: Changes the device address to the values specified in <DST_L> + <DST_H> in the device that matches the values specified in <SV_ADRL> + <SV_ADRH> + <D1>..<D4> that we in the reply to the Discover or Identify command issued previously.
				0x0F = Reconfigure: initiates a device reconfiguration or reset so that any new device configuration becomes active.

				read response messages, sent in response to a read command:
				0x41 = REPLY SV write: transfers a write response in D1
				0x42 = REPLY SV read: transfers a read response in D1
				0x43 = REPLY SV masked write: transfers a masked write response in D1
				0x45 = REPLY SV 4 byte write: transfers a write response in D1..D4
				0x46 = REPLY SV 4 byte read: transfers a read response in D1..D4
				0x47 = REPLY Discover: transfers an Discover response containing the MANUFACTURER_ID, DEVELOPER_ID, PRODUCT_ID and Serial Number
				0x48 = REPLY Identify: transfers an Identify response containing the MANUFACTURER_ID,DEVELOPER_ID, PRODUCT_ID and Serial Number
				0x49 = Change Address: transfers a Change Address response.
				0x4F = REPLY Reconfigure: Acknowledgement immediately prior to a device reconfiguration or reset.

				<SV_TYPE> This field determines the usage of the other fields. A value of 0x02 is required for this format.
				All other values reserved
				<SVX1> <0 0 0 1 D3 D2 D1 D0> These bits provide the top bits of the next 4 bytes
				D3: bit 7 of <SV_ADRH>
				D2: bit 7 of <SV_ADRL>
				D1: bit 7 of <DST_H>
				D0: bit 7 of <DST_L>
				<DST_L>,
				<DST_H>
				16bit destination address of the device being programmed. The <SV_TYPE> = 0x02 message format
				does not have a broadcast address (<DST_L> = 0 <DST_H> = 0) like other message. The Discover
				command <SV_CMD> = 0x07 performs a broadcast for all devices to report their identity.
				<SV_ADRL>,
				<SV_ADRH>
				16bit destination EEPROM address for read/write. For multi-byte operations this specifies the D1
				address: the other bytes go to <Addr+1>, <Addr+2>, <Addr+3>
				<SVX2> <0 0 0 1 D3 D2 D1 D0> These bits provide the top bits of the next 4 bytes
				D3: bit 7 of <D4> byte
				D2: bit 7 of <D3> byte
				D1: bit 7 of <D2> byte
				D0: bit 7 of <D1> byte
				<D1>…<D4> Data payload bytes. D1 is used for single byte operations; D1 is LSB for multi-byte operations
		*/
	}
}
