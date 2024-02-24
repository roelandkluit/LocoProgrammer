﻿/*
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
    public class LNF_OPC_INPUT_REP : LoconetFrame
    {
        public static bool isSupportedFrameType(LoconetFrame loconetMsg)
        {
            if (loconetMsg.GetOpcode() != LNopcodes.OPCODE.OPC_INPUT_REP || loconetMsg.LoconetBytes.Length != 4)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return GetOpcode() + " [" + DottedContact + "]\t(" + Contact.ToString("000") + ")\t" + (Active ? "Active" : "Inactive");
        }

        public uint Contact
        {
            get
            {
                int uiAddress = LoconetBytes[1] | ((LoconetBytes[2] & 0x0F) << 7);
                int bI = ((LoconetBytes[2] & 0x20) != 0 ? 1 : 0);
                return (uint)((uiAddress << 1) + 1 + bI);
            }
        }

        public bool Active
        {
            get
            {
                return (LoconetBytes[2] & 0x10) != 0; 
            }
        }

        public static string ToDottedContact(uint value)
        {
            int uiContact = (int)value;
            int modHigh = ((uiContact - 1) / 16) + 1;
            int modIndex = uiContact - ((modHigh - 1) * 16);
            return modHigh.ToString() + "." + modIndex.ToString("00");
        }

        public string DottedContact
        {
            get
            {
                return ToDottedContact(Contact);
            }
        }
        public LNF_OPC_INPUT_REP(LoconetFrame loconetMsg)
        {
            if (!isSupportedFrameType(loconetMsg))
            {
                throw new Exception("Invalid message type for cast");
            }
            this.LoconetBytes = loconetMsg.LoconetBytes;
        }
    }
}
