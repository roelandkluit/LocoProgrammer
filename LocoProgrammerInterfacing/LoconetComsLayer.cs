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

namespace LocoProgrammerInterfacing
{
    public class LoconetComsLayer: IDisposable
    {
        public delegate void LoconetMessageDataRecieved(object sender, LoconetFrame data);
        public delegate void ConnectionClosedEvent(object sender);

        public event LoconetMessageDataRecieved LoconetFrameRecieved;
        public event ConnectionClosedEvent LoconetConnectionClosed;

        internal Control owner;

        public LoconetComsLayer(Control Owner)
        {
            owner = Owner;
        }

        internal protected virtual void OnLoconetFrameRecieved(LoconetFrame data)
        {
            try
            {
                if (owner != null && owner.InvokeRequired)
                {
                    if (LoconetFrameRecieved != null)
                        owner.Invoke(LoconetFrameRecieved, new object[] { this, data });
                }
                else
                    LoconetFrameRecieved?.Invoke(this, data);
            }
            catch { }
        }

        internal protected virtual void OnLoconetConnectionClosed()
        {
            try
            {
                if (owner == null)
                {
                    return;
                }
                else if (owner.InvokeRequired)
                {
                    if (LoconetFrameRecieved != null)
                        owner.Invoke(LoconetConnectionClosed, new object[] { this });
                }
                else
                {
                    LoconetConnectionClosed?.Invoke(this);
                }
            }
            catch
            {
            }
        }

        public virtual void Send(LoconetFrame data)
        {
        }

        public virtual void Disconnect()
        {
        }

        public virtual void Connect()
        {
        }

        public void SendGo()
        {
            Send(LoconetFrame.fromString("83", false));
        }

        public void SendStop()
        {
            Send(LoconetFrame.fromString("82", false));
        }

        public virtual void Dispose()
        {
            Disconnect();
        }

        public virtual bool Connected
        {
            get
            {
                return false;
            }
        }
    }
}
