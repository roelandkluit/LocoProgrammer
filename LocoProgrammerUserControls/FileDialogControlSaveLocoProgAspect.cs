//  Copyright (c) 2006, Gustavo Franco
//  Copyright © Decebal Mihailescu 2007-2015

//  Email:  gustavo_franco@hotmail.com
//  All rights reserved.

//  Redistribution and use in source and binary forms, with or without modification, 
//  are permitted provided that the following conditions are met:

//  Redistributions of source code must retain the above copyright notice, 
//  this list of conditions and the following disclaimer. 
//  Redistributions in binary form must reproduce the above copyright notice, 
//  this list of conditions and the following disclaimer in the documentation 
//  and/or other materials provided with the distribution. 

//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
//  REMAINS UNCHANGED.

using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;

using FileDialogExtenders;
using Newtonsoft.Json;
using static LocoProgrammerDevices.clExportAspectDataStruct;

namespace LocoProgrammerUserControls
{    
    public partial class FileDialogControlSaveLocoProgAspect : FileDialogControlBase
    {
        public string Description { get => _Description; private set => _Description = value; }
        private string _Description = "";

        public int AspectPinCount = 0;
        
        #region Constructors
        public FileDialogControlSaveLocoProgAspect()
        {
            InitializeComponent();
        }
        #endregion

        #region Overrides
        protected override void OnPrepareMSDialog()
        {
            base.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (Environment.OSVersion.Version.Major < 6)
                MSDialog.SetPlaces( new object[] { @"c:\", (int)Places.MyDocuments, (int)Places.All_Users_Documents, (int)Places.UserName_Desktop});
            base.OnPrepareMSDialog();
            lblAspectCount.Text = AspectPinCount.ToString();
        }
        #endregion

        private void FileDialogControlSaveLocoProgAspect_ClosingDialog(object sender, CancelEventArgs e)
        {
            Description = txtDescription.Text;
            e.Cancel = false;
        }
    }
}