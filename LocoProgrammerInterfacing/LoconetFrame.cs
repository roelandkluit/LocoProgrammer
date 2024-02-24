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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LocoProgrammerInterfacing.LNopcodes;

namespace LocoProgrammerInterfacing
{  
    public class LoconetFrame
    {
        private const int MAX_MSG_LEN = 127;
        private byte[] loconetBytes;
        protected internal bool checksumIncluded = false;

        public byte[] LoconetBytes { get => loconetBytes; protected internal set => loconetBytes = value; }

        /// <summary>
        /// Calculate checksum over bytes 0 to (len-1).
        /// </summary>
        /// <param name="bytes">the array of bytes</param>
        /// <param name="len">number of bytes to use for calculation</param>
        /// <returns>the claculated checksum</returns>
        public static byte calcCheckSum(byte[] bytes, int len)
        {
            int chk = 0xFF; // need int for xor operation
            for (int i = 0; i < len; i++)
            {
                chk = chk ^ bytes[i];
            }
            return (byte)chk;
        }

        internal void AddOrUpdateCheckSum()
        {
            if(!checksumIncluded)
            {
                byte checksum = calcCheckSum(LoconetBytes, LoconetBytes.Length);
                LoconetBytes = LoconetBytes.Append(checksum).ToArray();
                checksumIncluded = true;
            }
            else
            {
                byte checksum = calcCheckSum(LoconetBytes, LoconetBytes.Length - 1);
                LoconetBytes[LoconetBytes.Length - 1] = checksum;
                checksumIncluded = true;
            }
        }

        public byte[] GetBytes()
        {
            AddOrUpdateCheckSum();
            Validate(true);
            return LoconetBytes;
        }

        public string ToHexString()
        {
            AddOrUpdateCheckSum();
            Validate(true);

            string ret = "";

            foreach(byte b in LoconetBytes)
            {
                ret += b.ToString("X2") + " ";
            }
            return ret.Trim();
        }

        public OPCODE GetOpcode()
        {
            return (OPCODE)LoconetBytes[0];
        }

        public static LoconetFrame fromArray(byte[] Message, bool checkSumIncluded = true)
        {
            LoconetFrame LnM = new LoconetFrame();
            LnM.LoconetBytes = Message;
            LnM.checksumIncluded = checkSumIncluded;
            if (!checkSumIncluded)
            {
                LnM.AddOrUpdateCheckSum();
            }
            LnM.Validate(true);

            return LnM;
        }

        public static LoconetFrame fromString(string Message, bool checkSumIncluded = true)
        {
            LoconetFrame LnM = new LoconetFrame();

            Message = Message.Replace(" ", "");//.Replace("/t", "");
            if (Message == null) throw new ArgumentNullException();
            if (Message.Length % 2 != 0) throw new InvalidCastException();
           
            LnM.LoconetBytes = new byte[(Message.Length / 2)];
            LnM.checksumIncluded = checkSumIncluded;

            for (int i = 0; i < Message.Length / 2; i++)
            {
                try
                {
                    LnM.LoconetBytes[i] = byte.Parse(Message.Substring(i * 2, 2), NumberStyles.HexNumber);
                }
                catch (Exception ex)
                {
                    throw new Exception("could not parse byte " + (i + 1) + ": " + Message.Substring(i, 2) + ": " + ex);
                }
            }

            if (!checkSumIncluded)
            {
                LnM.AddOrUpdateCheckSum();
            }
            LnM.Validate(true);

            return LnM;
        }

        private bool checkChecksum()
        {
            if (!checksumIncluded)
                throw new Exception("No checksum in message");

            byte checksum = calcCheckSum(LoconetBytes, LoconetBytes.Length - 1);
            if (checksum != LoconetBytes[LoconetBytes.Length - 1])
                return false;
            return true;
        }

        public static int GetLengthFromLNHeader(ref byte[] loconetData)
        {
            switch (loconetData[0] & 0x60)
            {
                case 0x00:
                    return 2;
                case 0x20:
                    return 4;
                case 0x40:
                    return 6;
                case 0x60:
                    byte pDataLen = loconetData[1];
                    if (pDataLen < 3)
                        return -1;
                    else if (pDataLen > 0x7F)
                        return -1;
                    else
                        return pDataLen;
            }
            return -1;
        }

        public bool Validate(bool throwError = false)
        {
            int len = GetLengthFromLNHeader(ref loconetBytes);
            if (len == 0 || len == -1)
            {
                if(throwError)
                    throw new InvalidOperationException("Invalid lenght in header");
                return false;
            }

            // -- check length ---------------------------------------------
            if (len != LoconetBytes.Length + (this.checksumIncluded ? 0 : 1))
            {
                if (throwError)
                    throw new Exception("invalid length of message (" + len + " bytes expected)");
                return false;
            }
            // -- check high bit -------------------------------------------
            if (LoconetBytes[0] < 0x80)
            {
                if (throwError)
                    throw new Exception("high bit of first byte should be set");
                return false;
            }
            for (int i = 1; i < LoconetBytes.Length; i++)
            {
                if (LoconetBytes[i] >= 0x80)
                {
                    if (throwError)
                        throw new Exception("high bit of byte " + (i + 1) + " should not be set");
                    return false;
                }
            }

            if(checksumIncluded)
            {
                if (!checkChecksum())
                { 
                    if (throwError)
                        throw new Exception("CRC checksum invalid");
                    return false;
                }
            }
            return true;
        }             
    }
}
