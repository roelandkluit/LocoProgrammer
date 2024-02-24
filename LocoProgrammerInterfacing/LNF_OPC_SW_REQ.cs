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
    public class LNF_OPC_SW_REQ : LoconetFrame
    {
        public enum enumDirection:byte
        {
            DirectionThrownRed = 0,
            DirectionClosedGreen = 1
        }

        public enum enumPower : byte
        {
            PowerOff = 0,
            PowerOn = 1
        }

        public static bool isSupportedFrameType(LoconetFrame loconetMsg)
        {
            //TODO
            /*			OPC_SW_REQ = 0xB0,  //REQ SWITCH function				NO
								//<0xB0>,<SW1>,<SW2>,<CHK> REQ SWITCH function 
								//<SW1>	=<0,A6,A5,A4- A3,A2,A1,A0>, 7 ls adr bits.
								//  A1,A0 select 1 of 4 input pairs in a DS54
								//<SW2>	=<0,0,DIR,ON- A10,A9,A8,A7>, Control bits and 4 MS adr bits.
								//DIR=1 for Closed,/GREEN, =0 for Thrown/RED
								//ON=1 for Output ON, =0 FOR output OFF
								//
								//Note-,Immediate response of <0xB4><30><00> if command failed,
								//otherwise no response
            */

            if (loconetMsg.GetOpcode() != LNopcodes.OPCODE.OPC_SW_REQ || loconetMsg.LoconetBytes.Length != 4)
            {
                return false;
            }
            return true;
        }

        public enumDirection Direction
        {
            get
            {
                return (enumDirection)((this.LoconetBytes[2] & 0x20) >> 5);
            }
            set
            {
                //
            }
        }
        public enumPower Power
        {
            get
            {
                return (enumPower)((this.LoconetBytes[2] & 0x10) >> 4);
            }
        }

        public override string ToString()
        {
            return GetOpcode() + " [" + Address + "]\tDirection: " + (Direction == enumDirection.DirectionThrownRed ? "Thrown" : "Closed") + "\tPower: " + (Power == enumPower.PowerOff ? "Off" : "On");
        }
        public uint Address
        {
            get
            {
                return (uint)(LoconetBytes[1] | ((LoconetBytes[2] & 0x0F) << 7)) + 1;
            }
        }

        public bool Active
        {
            get
            {
                return (LoconetBytes[2] & 0x10) != 0; 
            }
        }
        private LNF_OPC_SW_REQ()
        {
        }
        public static LNF_OPC_SW_REQ CreateNew(uint address, enumDirection Direction, enumPower Power)
        {
            if (address == 0 || address > 2048)
                throw new ArgumentOutOfRangeException("Address out of range");
            LNF_OPC_SW_REQ lnf = new LNF_OPC_SW_REQ();
            lnf.LoconetBytes = new byte[3];
            lnf.LoconetBytes[0] = (byte)LNopcodes.OPCODE.OPC_SW_REQ;
            lnf.LoconetBytes[1] = (byte)((address - 1) & 0x7F);
            lnf.LoconetBytes[2] = (byte)((((address - 1) >> 7) & 0x0F) + (((byte)Direction & 0x01) << 5) + (((byte)Power & 0x01) << 4));
            lnf.AddOrUpdateCheckSum();
            return lnf;
        }

        public LNF_OPC_SW_REQ(LoconetFrame loconetMsg)
        {
            if (!isSupportedFrameType(loconetMsg))
            {
                throw new Exception("Invalid message type for cast");
            }
            this.LoconetBytes = loconetMsg.LoconetBytes;
        }
    }
}
