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
    public partial class FileDialogControlOpenLocoProgAspect : FileDialogControlBase
    {
        private DCC_RESTORE_OPTION _usedDCCasSaved = DCC_RESTORE_OPTION.Restore_DCC_value_as_saved;
        private ushort _DCCBaseAddress = 0;
        public DCC_RESTORE_OPTION usedDCCasSaved { get => _usedDCCasSaved; private set => _usedDCCasSaved = value; }
        public ushort DCCBaseAddress { get => _DCCBaseAddress; private set => _DCCBaseAddress = value; }

        public enum DCC_RESTORE_OPTION
        {
            Restore_DCC_value_as_saved,
            Do_not_use_DCC_value,
            DCC_based_with_reference_to_new_value
        }

        #region Constructors
        public FileDialogControlOpenLocoProgAspect()
        {
            InitializeComponent();
        }
        #endregion

        #region Overrides
        protected override void OnPrepareMSDialog()
        {
            cmbDccAddr.Items.Clear();
            foreach (var val in Enum.GetValues(typeof(DCC_RESTORE_OPTION)))
            {
                cmbDccAddr.Items.Add(val.ToString().Replace('_', ' '));
            }
            cmbDccAddr.SelectedIndex = 0;
            base.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (Environment.OSVersion.Version.Major < 6)
                MSDialog.SetPlaces( new object[] { @"c:\", (int)Places.MyDocuments, (int)Places.All_Users_Documents, (int)Places.UserName_Desktop});
            base.OnPrepareMSDialog();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1807:AvoidUnnecessaryStringCreation", MessageId = "filePath")]
        private void MyOpenFileDialogControl_FileNameChanged(IWin32Window sender, string filePath)
        {
            if (filePath.ToLower().EndsWith(".lpa"))
            {
                try
                {
                    string lines = File.ReadAllText(filePath);
                    AspectData data = (AspectData)JsonConvert.DeserializeObject(lines, typeof(AspectData));
                    if(data.version !=1)
                    {
                        lblName.Text = ("Incompatible version");
                        lblAspectCount.Text = "";
                        FileDlgEnableOkBtn = false;
                    }
                    lblName.Text = data.Description;
                    lblAspectCount.Text = data.aspectEntries.Count.ToString();
                    switch(data.importBehavour)
                    {
                        case LocoProgrammerDevices.clExportAspectDataStruct.AspectImportBehavour.DefaultImportUsingSetDCC:
                            this.cmbDccAddr.SelectedIndex = 0;
                            break;
                        case LocoProgrammerDevices.clExportAspectDataStruct.AspectImportBehavour.DefaultImportUsingIncrementedDCC:
                            this.cmbDccAddr.SelectedIndex = 1;
                            break;
                        case LocoProgrammerDevices.clExportAspectDataStruct.AspectImportBehavour.DefaultImportUsingNoDCC:
                            this.cmbDccAddr.SelectedIndex = 2;
                            break;
                        default:
                            break;
                    }
                    if (data.aspectEntries[0].dccAddress == 0)
                    {
                        cmbDccAddr.SelectedIndex = 2;
                    }
                    FileDlgEnableOkBtn = true;
                }
                catch (Exception) { FileDlgEnableOkBtn = false; }
            }
            else
            {
                lblName.Text = "";
                lblAspectCount.Text = "";
            }
        }

        #endregion

        private void MyOpenFileDialogControl_ClosingDialog(object sender, CancelEventArgs e)
        {
            usedDCCasSaved = (DCC_RESTORE_OPTION)cmbDccAddr.SelectedIndex;
            try
            {
                DCCBaseAddress = ushort.Parse(txtBaseDCC.Text);
            }
            catch
            {
            }
            e.Cancel = false;
        }

        private void MyOpenFileDialogControl_FolderNameChanged(IWin32Window sender, string filePath)
        {
            lblName.Text = "";
            lblAspectCount.Text = "";
        }

        private void MyOpenFileDialogControl_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
        }

        private void OpenLocoProgAspectFileDialogControl_Load(object sender, EventArgs e)
        {

        }

        private void cmbDccAddr_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBaseDCC.Enabled = cmbDccAddr.SelectedIndex == 2;           
        }
    }
}