using LocoProgrammerDevices;
using LocoProgrammerUserControls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static LocoProgrammerDevices.clExportAspectDataStruct;
using static LocoProgrammerDevices.LNcDeviceLocoReader;

namespace LocoProgrammer
{
    internal static class AspectImportExport
    {
        public static bool ImportAspectFromFile(Form parent, LNcDeviceLocoReader lncLocoReader, byte startPin)
        {
            using (FileDialogControlOpenLocoProgAspect fod = new FileDialogControlOpenLocoProgAspect())
            {
                fod.FileDlgFilter = "Loco Programmer Aspect Configuration|*.lpa";
                fod.FileDlgDefaultExt = "lpa";
                fod.FileDlgCaption = "Import Pin aspects [" + (startPin + 1) + "] from file";
                fod.FileDlgStartLocation = FileDialogExtenders.AddonWindowLocation.Bottom;
                if (fod.ShowDialog(parent) == DialogResult.OK)
                {
                    Console.WriteLine(fod.usedDCCasSaved);
                    try
                    {
                        string lines = File.ReadAllText(fod.FileDlgFileName);
                        AspectData data = (AspectData)JsonConvert.DeserializeObject(lines, typeof(AspectData));
                        ushort baseDCCforCalculation = 0;
                        if (data.version == 1)
                        {
                            if (startPin + data.aspectEntries.Count > lncLocoReader.GetCurrentActiveMaxPins())
                            {
                                MessageBox.Show("Aspects do not fit inside remaining pins");
                                return false;
                            }

                            for (int i = 0; i < data.aspectEntries.Count; i++)
                            {
                                if (lncLocoReader.PinConfigurations[startPin + i] == null)
                                {
                                    lncLocoReader.PinConfigurations[startPin + i] = new Struct__ConfigurationPWMPin();
                                }
                                lncLocoReader.PinConfigurations[startPin + i].ImportNotWrittenToDevice = true;
                                lncLocoReader.PinConfigurations[startPin + i].pinAspectsGreen = data.aspectEntries[i].pinAspectsGreen;
                                lncLocoReader.PinConfigurations[startPin + i].pinAspectsRed = data.aspectEntries[i].pinAspectsRed;
                                lncLocoReader.PinConfigurations[startPin + i].UsePreviousPin = data.aspectEntries[i].usePreviousPin;
                                lncLocoReader.PinConfigurations[startPin + i].InvertPowerOutput = data.aspectEntries[i].invertPowerOutput;
                                ushort dccaddr = data.aspectEntries[i].dccAddress;
                                switch (fod.usedDCCasSaved)
                                {
                                    case FileDialogControlOpenLocoProgAspect.DCC_RESTORE_OPTION.Restore_DCC_value_as_saved:
                                        lncLocoReader.PinConfigurations[startPin + i].DccAddress = dccaddr;
                                        break;
                                    case FileDialogControlOpenLocoProgAspect.DCC_RESTORE_OPTION.Do_not_use_DCC_value:
                                        break;
                                    case FileDialogControlOpenLocoProgAspect.DCC_RESTORE_OPTION.DCC_based_with_reference_to_new_value:
                                        if(i == 0)
                                        {
                                            baseDCCforCalculation = dccaddr;
                                            lncLocoReader.PinConfigurations[startPin + i].DccAddress = fod.DCCBaseAddress;
                                        }
                                        else
                                        {
                                            if(baseDCCforCalculation < dccaddr) //if pin has lower of same dcc address as base ignore it
                                                lncLocoReader.PinConfigurations[startPin + i].DccAddress = (ushort)((dccaddr - baseDCCforCalculation) + fod.DCCBaseAddress);
                                        }
                                        break;
                                    default:
                                        MessageBox.Show("NotImplemented");
                                        break;
                                }
                            }
                            MessageBox.Show(parent, "Imported " + data.aspectEntries.Count + " pin aspect configurations", "Import completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(parent, "Unable to import: " + e, "Import error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return false;
        }

        public static void ExportAspectToFile(Form parent, LNcDeviceLocoReader lncLocoReader, byte startPin, bool ExportAll = false)
        {
            if (ExportAll && startPin != 0)
                throw new Exception("Startpin should be 0 when doing full export");

            bool foundEndOfAspect = false;
            byte pinIndex = startPin;
            if (lncLocoReader.PinConfigurations[startPin] == null)
            {
                MessageBox.Show(parent, "No pin configuration loaded or set to export", "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (lncLocoReader.PinConfigurations[startPin].UsePreviousPin == 1)
                {
                    MessageBox.Show(parent, "Pin is linked to previous pin, select base pin for export", "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
            while (lncLocoReader.PinConfigurations[pinIndex] != null)
            {
                if (ExportAll)
                {
                    if (pinIndex == lncLocoReader.GetCurrentActiveMaxPins() - 1)
                    {
                        pinIndex = (byte)lncLocoReader.GetCurrentActiveMaxPins(); //Otherwise last pin will be skipped, TODO check with export of last aspect
                        foundEndOfAspect = true;
                        break;
                    }
                }
                else
                {
                    if (lncLocoReader.PinConfigurations[pinIndex].UsePreviousPin != 1)
                    {
                        if (pinIndex != startPin)
                        {
                            //Pin not linked to base pin of current aspect we are looking to export
                            foundEndOfAspect = true;
                            break;
                        }
                    }
                    if (pinIndex == lncLocoReader.PinConfigurations.Length - 1)
                        break; //End of array();
                }
                pinIndex++;
            }
            if (foundEndOfAspect || MessageBox.Show(parent, "Warning: Not all pins might have been read. Export config for Pins [" + (startPin + 1) + "] to [" + pinIndex + "]?", "Export pin Config", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (FileDialogControlSaveLocoProgAspect fsd = new FileDialogControlSaveLocoProgAspect())
                {
                    fsd.FileDlgFilter = "Loco Programmer Aspect Configuration|*.lpa";
                    fsd.FileDlgDefaultExt = "lpa";
                    fsd.FileDlgCaption = "Export Pin aspects [" + (startPin + 1) + "] to [" + pinIndex + "] to file";
                    fsd.AspectPinCount = pinIndex - startPin;
                    fsd.FileDlgCheckFileExists = false;                   
                    fsd.FileDlgStartLocation = FileDialogExtenders.AddonWindowLocation.Bottom;
                    if (fsd.ShowDialog(parent) == DialogResult.OK)
                    {
                        Console.WriteLine(fsd.FileDlgFileName);
                        AspectData data = new AspectData();
                        data.Description = fsd.Description;
                        data.version = 1;
                        for (byte i = startPin; i < pinIndex; i++)
                        {
                            AspectEntry aspect = new AspectEntry();
                            aspect.pinAspectsGreen = lncLocoReader.PinConfigurations[i].pinAspectsGreen;
                            aspect.pinAspectsRed = lncLocoReader.PinConfigurations[i].pinAspectsRed;
                            aspect.dccAddress = lncLocoReader.PinConfigurations[i].DccAddress;
                            aspect.invertPowerOutput = lncLocoReader.PinConfigurations[i].InvertPowerOutput;
                            aspect.usePreviousPin = lncLocoReader.PinConfigurations[i].UsePreviousPin;
                            data.aspectEntries.Add(aspect);
                        }

                        string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
                        File.WriteAllText(fsd.FileDlgFileName, jsonString);
                    }
                }
            }
        }
    }
}
