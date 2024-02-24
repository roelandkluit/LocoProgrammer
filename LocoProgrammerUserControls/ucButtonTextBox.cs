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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocoProgrammerUserControls
{
    public partial class ucButtonTextBox : TextBox
    {
        public event EventHandler ButtonClick;
        private Button buttonSave;
        private string originalText = "";

        private bool mustBeNumeric = false;
        [Description("Sets if the input value should be numeric"), Category("Behavior")]
        public bool MustBeNumeric { get => mustBeNumeric; set => mustBeNumeric = value; }

        public bool isDirty
        {
            get
            {
                return buttonSave.Visible;
            }
        }

        [Description("Sets the original text to check if showing the save button is required"), Category("Appearance")]
        public String OriginalText
        {
            get
            {
                return originalText;
            }
            set
            {
                value = Regex.Replace(value, @"\p{C}+", String.Empty);
                originalText = value;
                Text = value;
                buttonSave.Visible = originalText != Text;
            }
        }



        public ucButtonTextBox()
        {
            InitializeComponent();
            buttonSave = new Button();
            buttonSave.Text = "S";
            buttonSave.Visible = false;
            buttonSave.Click += ButtonSave_Click;
            this.Controls.Add(buttonSave);
            updatePos();
        }

        public void Save()
        {
            if(isDirty)
            {
                ButtonClick?.Invoke(this, null);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(this, e);
        }

        private void uControlEditBox_Load(object sender, EventArgs e)
        {
            this.Controls.Add(buttonSave);
        }

        private void uControlEditBox_SizeChanged(object sender, EventArgs e)
        {
            updatePos();
        }

        private void updatePos()
        {
            buttonSave.Top = 0;
            buttonSave.Width = 25;
            buttonSave.Height = this.Height - 4 ;
            buttonSave.Left = this.Width - buttonSave.Width - 4 ;
        }

        private void uControlEditBox_TextChanged(object sender, EventArgs e)
        {
            if (MustBeNumeric)
            {
                UInt16 result;
                if (UInt16.TryParse(this.Text, out result))
                {
                    buttonSave.Visible = false;                    
                }
            }                    
            buttonSave.Visible = originalText != Text;
        }
    }
}
