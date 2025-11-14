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
using LocoProgrammerDevices;
using LocoProgrammerInterfacing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocoProgrammer
{
    public partial class frmMonitorOccupation : Form
    {
        public static bool enableSound = false;

        LncsDevice lnDevice;
        public frmMonitorOccupation(LncsDevice lnDevice, uint S88Start, uint S88Count)
        {
            if (S88Start == 0 || S88Count == 0)
            {
                MessageBox.Show(this, "Cannot watch when count or start address is 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                throw new ArgumentOutOfRangeException();
            }

            InitializeComponent();
            for (uint i = 0; i < S88Count; i++)
            {
                uint contact = (S88Start + i);
                uint pos = i % 16;
                uint line = i / 16;

                Label l = new Label();
                l.Name = "L" + contact;
                l.Tag = null;
                l.Text = LNF_OPC_INPUT_REP.ToDottedContact(contact);

                l.Left = 10 + (int)(pos * 45);
                l.Top = 20 + (int)(line * 40);
                l.AutoSize = true;
                this.Controls.Add(l);

                PictureBox p = new PictureBox();
                p.Name = "C" + contact;
                p.BorderStyle = BorderStyle.FixedSingle;
                p.BackColor = Color.White;
                p.Top = 10 + (int)(line * 40);
                p.Width = 10;
                p.Height = 5;
                p.Left = l.Left + ((l.Width - p.Width) / 2);

                this.Controls.Add(p);
            }
            this.lnDevice = lnDevice;
            lnDevice.Parent.LnComsLayer.LoconetFrameRecieved += ComsLayer_LoconetFrameRecieved;
        }

        private void ComsLayer_LoconetFrameRecieved(object sender, LoconetFrame data)
        {
            if(data.GetOpcode() == LNopcodes.OPCODE.OPC_INPUT_REP && LNF_OPC_INPUT_REP.isSupportedFrameType(data))
            {
                LNF_OPC_INPUT_REP status = new LNF_OPC_INPUT_REP(data);
                if(this.Controls.ContainsKey("C" + status.Contact))
                {
                    PictureBox p = (PictureBox)this.Controls["C" + status.Contact];
                    Label l = (Label)this.Controls["L" + status.Contact];
                    l.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                    l.Tag = DateTime.Now;
                    tmrBoldtoNormal.Enabled = true;
                    if (status.Active)
                    {
                        if (p.BackColor != Color.Red)
                        {
                            playSound(true);
                            p.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        if (p.BackColor != Color.White)
                        {
                            playSound(false);
                            p.BackColor = Color.White;
                        }
                    }
                }
                //status.Contact
            }
            
        }

        private void playSound(bool isActivating)
        {
            if (chkSound.Checked)
            {

                System.IO.UnmanagedMemoryStream sound;                
                if (isActivating)
                    sound = Properties.Resources.beep_07a;
                else
                    sound = Properties.Resources.beep_08b;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(sound);
                player.Play();
            }
        }
        private void tmrBoldtoNormal_Tick(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {
                if (c.GetType() == typeof(Label))
                {
                    Label l = (Label)c;
                    if(l.Tag != null)
                    {
                        DateTime time = (DateTime)l.Tag;
                        if((DateTime.Now - time).TotalSeconds > 5)
                        {
                            l.Font = Label.DefaultFont;
                            l.Tag = null;
                        }
                    }
                }
            }    

        }

        private void frmMonitorOccupation_Shown(object sender, EventArgs e)
        {
            lnDevice.RecieveDeviceInformationFromSingleAddress((ushort)CustDefines.CVADDRESS.SV_REPORTALL);
        }

        private void frmMonitorOccupation_Load(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2);
            }

            if (frmMonitorOccupation.enableSound)
            {
                chkSound.Checked = true;
            }
        }

        private void chkSound_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSound.Checked)
            {
                frmMonitorOccupation.enableSound = true;
                chkSound.Image = Properties.Resources.volume_on;
            }
            else
            {
                frmMonitorOccupation.enableSound = false;
                chkSound.Image = Properties.Resources.volume_off;
            }
        }
    }
}
