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
    public class Struct__ConfigurationPWMPin
    {
        private const byte ASPECT_COUNT = 4;
        public const byte BYTE_DATA_LEN = (1 + 15 + (2 * ASPECT_COUNT * (6 + 2 + 8 + 8)) + 16) / 8;

        public enum PIN_ASPECT_INSTRUCTION : byte //6bit 0 t/m 63
        {
            None = 0,
            AspectMultibit = 1,
            MultibitOff = 2,
            MultibitOn = 3,
            SetPWMValue = 4,
            RedViaYellow = 10, 
            Blink = 12,
            BlinkInvert = 13,
            RandomLedBlink = 14,
            SetServo = 20,
            SetServoNoDisconnect = 21,
            //DetachServo = 22,
        };       
        
        public struct struct__ConfigurationAspectsForPin
        {
            //[BitfieldLength(6)]
            internal PIN_ASPECT_INSTRUCTION instruction;
            //[BitfieldLength(2)]
            internal byte reserved;
            //[BitfieldLength(8)]
            public byte Data0;
            //[BitfieldLength(8)]
            public byte Data1;

            public void SetPinAspect(object input, string strData0, string strData1)
            {
                if (input == null)
                    Instruction = PIN_ASPECT_INSTRUCTION.None;
                else if (input.GetType() == typeof(PIN_ASPECT_INSTRUCTION))
                    Instruction = (PIN_ASPECT_INSTRUCTION)input;
                else
                    throw new InvalidCastException();

                if (string.IsNullOrEmpty(strData0))
                    this.Data0 = 0;
                else
                    this.Data0 = byte.Parse(strData0);

                if (string.IsNullOrEmpty(strData1))
                    this.Data1 = 0;
                else
                    this.Data1 = byte.Parse(strData1);
            }

            public PIN_ASPECT_INSTRUCTION Instruction { get => instruction;
                set
                {
                    if (((byte)value) > 0x3F)
                        throw new Exception("Instruction exceeds 6bits value");
                    instruction = value;
                }
            }

            public byte Reserved { get => reserved; 
                set
                {
                    if (value > 0x03)
                        throw new Exception("Reserved value exceeds 2bits value");
                    reserved = value;
                }
            }
        }

        public bool ImportNotWrittenToDevice = false;

        //[BitfieldLength(1)]
        internal byte usePreviousPin;
        //[BitfieldLength(1)]
        internal byte invertPowerOutput;        
        //[BitfieldLength(14)]
        internal UInt16 dccAddress;

        public struct__ConfigurationAspectsForPin[] pinAspectsRed = new struct__ConfigurationAspectsForPin[ASPECT_COUNT];
        public struct__ConfigurationAspectsForPin[] pinAspectsGreen = new struct__ConfigurationAspectsForPin[ASPECT_COUNT];

        #pragma warning disable CS0649
        internal UInt16 reserved;
        #pragma warning restore CS0649

        //[BitfieldLength(1)]
        public byte UsePreviousPin
        { 
            get => usePreviousPin; 
            set
            {
                if (value > 1)
                    usePreviousPin = 1;
                else
                    usePreviousPin = value; 
            }
        }

        //[BitfieldLength(1)]
        public byte InvertPowerOutput
        {
            get => invertPowerOutput;
            set
            {
                if (value > 1)
                    invertPowerOutput = 1;
                else
                    invertPowerOutput = value;
            }
        }

        public UInt16 DccAddress { get => dccAddress;
            set
            {
                if (value > 0x27FF)
                    throw new Exception("Unsupported DCC address: " + value);
                else
                    dccAddress = value;
            }
        }

        public Struct__ConfigurationPWMPin() { }

        public Struct__ConfigurationPWMPin(byte[] inputByteData)
        {
            if (inputByteData.Length != BYTE_DATA_LEN)
                throw new DataMisalignedException("Lenght does not match expected size");

            UInt16 val = BitConverter.ToUInt16(inputByteData, 0);
            usePreviousPin = (byte)(val & 0x01);
            InvertPowerOutput = (byte)((val & 0x02) >> 1);
            dccAddress = (ushort)(val >> 2);
            byte dataPos = 2;

            for (int i = 0; i < ASPECT_COUNT; i++)
            {
                pinAspectsGreen[i].Instruction = (PIN_ASPECT_INSTRUCTION)(inputByteData[dataPos] & 0x3F);
                pinAspectsGreen[i].reserved = (byte)(inputByteData[dataPos++] >> 6);
                pinAspectsGreen[i].Data0 = inputByteData[dataPos++];
                pinAspectsGreen[i].Data1 = inputByteData[dataPos++];
            }
            for (int i = 0; i < ASPECT_COUNT; i++)
            {
                pinAspectsRed[i].Instruction = (PIN_ASPECT_INSTRUCTION)(inputByteData[dataPos] & 0x3F);
                pinAspectsRed[i].reserved = (byte)(inputByteData[dataPos++] >> 6);
                pinAspectsRed[i].Data0 = inputByteData[dataPos++];
                pinAspectsRed[i].Data1 = inputByteData[dataPos++];
            }
        }

        public static Struct__ConfigurationPWMPin FromByteArray(byte[] inputByteData)
        {
            return new Struct__ConfigurationPWMPin(inputByteData);
        }

        public byte[] ToByteArray()
        {
            byte[] ExportDataArray = new byte[BYTE_DATA_LEN];

            BitConverter.GetBytes((UsePreviousPin & 0x01) + ((invertPowerOutput & 0x01) <<1) + (DccAddress << 2)).CopyTo(ExportDataArray, 0);
            int i = 2;

            foreach (var pinAspGreen in pinAspectsGreen)
            {
                ExportDataArray[i++] = (byte)(((byte)pinAspGreen.Instruction & 0x3F) + (pinAspGreen.Reserved << 6));
                ExportDataArray[i++] = pinAspGreen.Data0;
                ExportDataArray[i++] = pinAspGreen.Data1;
            }

            foreach (var pinAspRed in pinAspectsRed)
            {
                ExportDataArray[i++] = (byte)(((byte)pinAspRed.Instruction & 0x3F) + (pinAspRed.Reserved << 6));
                ExportDataArray[i++] = pinAspRed.Data0;
                ExportDataArray[i++] = pinAspRed.Data1;
            }

            return ExportDataArray;
        }

    }
}
