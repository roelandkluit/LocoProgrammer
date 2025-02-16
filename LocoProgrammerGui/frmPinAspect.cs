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
using LocoProgrammerUserControls;
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
    public partial class frmPinAspect : Form
    {
        Dictionary<int, ucButtonTextBox> AllTextBoxes = new Dictionary<int, ucButtonTextBox>();
        Dictionary<int, Label> AllLabels = new Dictionary<int, Label>();
        Dictionary<int, Label> AllMaxValLabels = new Dictionary<int, Label>();

        //private TextBox pt0;
        //private TextBox pt1;

        private class tagConnect
        {
            public TextBox source;
            public string mask;
            public int maxnumber;
        }

        public frmPinAspect()
        {
            InitializeComponent();
        }

        private bool AddControl(int txtindex, string line, TextBox srcTextboxRef)
        {
            try
            {
                int index = AllLabels.Count;
                int maxValue = 0;
                string[] data = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string entry in data)
                {
                    string[] entryData = entry.Split('~');

                    ucButtonTextBox tNewTextboxEntry = new ucButtonTextBox();
                    Label lNewLabelCaption = new Label();
                    Label lNewMaxValLabel = new Label();

                    AllTextBoxes.Add(index, tNewTextboxEntry);
                    AllLabels.Add(index, lNewLabelCaption);
                    AllMaxValLabels.Add(index, lNewMaxValLabel);

                    lNewLabelCaption.Text = entryData[0];                    
                    lNewLabelCaption.Name = "Label" + index;
                    lNewLabelCaption.Left = 10;
                    lNewLabelCaption.AutoSize = true;
                    lNewLabelCaption.Top = 10 + ((lNewLabelCaption.Height + 5) * index);

                    tNewTextboxEntry.Name = "TextBox" + index;
                    tNewTextboxEntry.Width = 75;
                    tNewTextboxEntry.TextAlign = HorizontalAlignment.Left;
                    tNewTextboxEntry.OriginalText = GetValueFromSource(srcTextboxRef, entryData[1], out maxValue).ToString();

                    tagConnect txtTag = new tagConnect() { mask = entryData[1], source = srcTextboxRef, maxnumber = maxValue };

                    tNewTextboxEntry.Top = lNewLabelCaption.Top;
                    tNewTextboxEntry.Left = lNewLabelCaption.Left + lNewLabelCaption.Width + 25;
                    tNewTextboxEntry.Tag = txtTag;
                    tNewTextboxEntry.ButtonClick += TextboxEntry_ButtonClick;

                    lNewMaxValLabel.Text = "Value: 0.." + maxValue;
                    lNewMaxValLabel.Name = "LabelMax" + index;
                    lNewMaxValLabel.Left = tNewTextboxEntry.Left + tNewTextboxEntry.Width + 5;
                    lNewMaxValLabel.AutoSize = true;
                    lNewMaxValLabel.Top = 10 + ((lNewLabelCaption.Height + 5) * index);

                    this.Controls.Add(tNewTextboxEntry);
                    this.Controls.Add(lNewLabelCaption);
                    this.Controls.Add(lNewMaxValLabel);
                    index++;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;   
            }
            return true;
        }
        private void TextboxEntry_ButtonClick(object sender, EventArgs e)
        {
            uint outnr = 0;
            ucButtonTextBox t = (ucButtonTextBox)sender;
            tagConnect connectionTag = (tagConnect)t.Tag;
            if(!uint.TryParse(t.Text, out outnr))
            {
                MessageBox.Show("Unable to process: " + t.Text);
                return;
            }
            if (connectionTag.mask.StartsWith("b"))
            {
                if (t.Text.Length > connectionTag.maxnumber)
                {
                    MessageBox.Show("Exceeds maximum number of bits: " + connectionTag.maxnumber);
                    return;
                }
            }
            else
            {
                if (outnr > connectionTag.maxnumber)
                {
                    MessageBox.Show("Exceeds maximum value: " + connectionTag.maxnumber);
                    return;
                }
            }
            SetValueToSource(connectionTag.source, connectionTag.mask, outnr);
            t.OriginalText = t.Text;
        }

        private void SetValueToSource(TextBox srcTextboxRef, string mask, uint newVal)
        {
            int val = int.Parse(srcTextboxRef.Text);
            int imask = 255;

            //Bitmask
            if (mask.StartsWith("b"))
            {
                int index = 0;
                int outval = 0;
                string[] items = mask.Substring(1).Split(':');
                int sBit = int.Parse(items[0]);
                int eBit = int.Parse(items[1]);
                int maxBits = (eBit + 1 - sBit);
                string bitVal = Reverse(newVal.ToString().PadLeft(maxBits, '0'));
                foreach(char t in bitVal.ToCharArray())
                {
                    if (t != '0')
                    {
                        outval |= 1 << 7 - index;
                    }
                    index++;
                }
                outval = outval >> sBit;
                //Bits have been converted to number, now process them as integer
                SetValueToSource(srcTextboxRef, sBit + ":" + eBit, (uint)outval);
            }
            //Bitvalue-range
            else if (mask.Contains(":"))
            {
                string[] items = mask.Split(':');
                int sBit = int.Parse(items[0]);
                int eBit = int.Parse(items[1]);
                for (int i = sBit; i <= eBit; i++)
                {                    
                    imask &= ~(1 << 7 - i);
                }
                uint baseVal = (uint)(val & imask);
                newVal = newVal << (7 - eBit);
                srcTextboxRef.Text = (baseVal + newVal).ToString();
                return;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private string GetValueFromSource(TextBox srcTextboxRef, string mask, out int maxIntVal)
        {
            try
            {
                if (string.IsNullOrEmpty(srcTextboxRef.Text))
                    srcTextboxRef.Text = "0";

                int val = int.Parse(srcTextboxRef.Text);
                int imask = 0;

                //Bitmask
                if (mask.StartsWith("b"))
                {
                    string[] items = mask.Substring(1).Split(':');
                    int sBit = int.Parse(items[0]);
                    int eBit = int.Parse(items[1]);
                    for (int i = sBit; i <= eBit; i++)
                    {
                        imask |= 1 << 7 - i;
                    }
                    int retval = val & imask;
                    maxIntVal = (eBit + 1 - sBit);
                    retval = retval >> (7 - eBit);
                    string bitValue = Convert.ToString(retval, 2).PadLeft(maxIntVal, '0');
                    return Reverse(bitValue);
                }
                //Bitvalue-range
                else if (mask.Contains(":"))
                {
                    string[] items = mask.Split(':');
                    int sBit = int.Parse(items[0]);
                    int eBit = int.Parse(items[1]);
                    for (int i = sBit; i <= eBit; i++)
                    {
                        imask |= 1 << 7 - i;
                    }
                    int retval = val & imask;
                    maxIntVal = (int)Math.Pow(2, (double)(eBit + 1 - sBit)) - 1;
                    retval = retval >> (7 - eBit);
                    return retval.ToString();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            catch
            {
                throw new Exception("Invalid value in source text field: " + srcTextboxRef.Text);
            }
        }

        //public void AttachWindow(string Caption, TextBox txt0, TextBox txt1, string Data0Mask, string Data1Mask)
        public bool AttachWindow(string Caption, TextBox txt0, TextBox txt1, LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION PinAspect)
        {
            //pt0 = txt0;
            //pt1 = txt1;
            string Data0Mask;
            string Data1Mask;
            if (AspectToMask(PinAspect, out Data0Mask, out Data1Mask))
            {
                this.Text = PinAspect.ToString() + " - " + Caption;
                AddControl(0, Data0Mask, txt0);
                AddControl(1, Data1Mask, txt1);
                this.Width = AllMaxValLabels[AllMaxValLabels.Count - 1].Width + AllMaxValLabels[AllMaxValLabels.Count - 1].Left + 25;
                btnClose.Top = AllLabels[AllLabels.Count - 1].Height + AllLabels[AllLabels.Count - 1].Top + 10;
                this.Height = btnClose.Top + btnClose.Height + 50;
                return true;
            }
            return false;
        }

        private void frmPinAspect_Load(object sender, EventArgs e)
        {

        }
        private bool AspectToMask(LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION PinAspect, out string Mask0, out string Mask1)
        {
            Mask0 = "";
            Mask1 = "";

            switch (PinAspect)
            {
                case LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION.None:
                    return false;
                case LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION.Blink:
                case LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION.BlinkInvert:
                case LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION.RedViaYellow:
                    Mask0 = "PinIndex~3:7"; //Max pins is 0-31
                    Mask1 = "Fade Time~0:3|Hold Time~4:7"; //Todo check if reverse order
                    return true;
                case LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION.MultibitOff:
                case LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION.MultibitOn:
                case LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION.AspectMultibit:
                case LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION.RandomLedBlink:
                    Mask0 = "BitMask~b0:7";
                    Mask1 = "Fade Time~0:7";
                    return true;
                case LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION.SetServo:
                case LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION.SetServoNoDisconnect:
                    Mask0 = "Servo Pin Index~0:2|Servo Movement Time~3:7";
                    Mask1 = "Servo Position~0:7";
                    return true;
                case LocoProgrammerDevices.Struct__ConfigurationPWMPin.PIN_ASPECT_INSTRUCTION.SetPWMValue:
                    Mask0 = "PWM Pin Index~0:2|PWM Dim Time~3:7";
                    Mask1 = "PWM Value~0:7";
                    return true;
            }
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPinAspect_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool hasChanges = false;
            foreach (ucButtonTextBox t in AllTextBoxes.Values)
            {
                if (t.isDirty)
                {
                    hasChanges = true;
                    break;
                }
            }
            if (hasChanges)
            {
                var ret = MessageBox.Show(this, "Edits have been made, process these?", "Process changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (ret == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (ret == DialogResult.No)
                {
                    e.Cancel = false;
                }
                else
                {
                    foreach (ucButtonTextBox t in AllTextBoxes.Values)
                    {
                        if (t.isDirty)
                        {
                            t.Save();
                        }
                    }
                }
            }
        }
    }
}
