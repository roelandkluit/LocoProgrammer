using System.ComponentModel;
namespace LocoProgrammerUserControls
{
    partial class FileDialogControlSaveLocoProgAspect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblAspectCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDccAddr = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description:";
            // 
            // lblAspectCount
            // 
            this.lblAspectCount.AutoSize = true;
            this.lblAspectCount.Location = new System.Drawing.Point(112, 29);
            this.lblAspectCount.Name = "lblAspectCount";
            this.lblAspectCount.Size = new System.Drawing.Size(10, 13);
            this.lblAspectCount.TabIndex = 3;
            this.lblAspectCount.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Aspect Pin Count:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(115, 3);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(386, 20);
            this.txtDescription.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "DCC Address:";
            this.label2.Visible = false;
            // 
            // cmbDccAddr
            // 
            this.cmbDccAddr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDccAddr.FormattingEnabled = true;
            this.cmbDccAddr.Location = new System.Drawing.Point(115, 49);
            this.cmbDccAddr.Name = "cmbDccAddr";
            this.cmbDccAddr.Size = new System.Drawing.Size(386, 21);
            this.cmbDccAddr.TabIndex = 5;
            this.cmbDccAddr.Visible = false;
            // 
            // FileDialogControlSaveLocoProgAspect
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmbDccAddr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAspectCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FileDlgCaption = "";
            this.FileDlgDefaultExt = "";
            this.FileDlgEnableOkBtn = false;
            this.FileDlgOkCaption = "&Save";
            this.FileDlgType = Win32Types.FileDialogType.SaveFileDlg;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "FileDialogControlSaveLocoProgAspect";
            this.Size = new System.Drawing.Size(513, 75);
            this.EventClosingDialog += new System.ComponentModel.CancelEventHandler(this.FileDialogControlSaveLocoProgAspect_ClosingDialog);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAspectCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDccAddr;
    }
}