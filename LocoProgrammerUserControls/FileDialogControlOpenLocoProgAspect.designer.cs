using System.ComponentModel;
namespace LocoProgrammerUserControls
{
    partial class FileDialogControlOpenLocoProgAspect
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblAspectCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDccAddr = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBaseDCC = new System.Windows.Forms.TextBox();
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
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(116, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(10, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "-";
            // 
            // lblAspectCount
            // 
            this.lblAspectCount.AutoSize = true;
            this.lblAspectCount.Location = new System.Drawing.Point(116, 28);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "DCC Address:";
            // 
            // cmbDccAddr
            // 
            this.cmbDccAddr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDccAddr.FormattingEnabled = true;
            this.cmbDccAddr.Location = new System.Drawing.Point(115, 49);
            this.cmbDccAddr.Name = "cmbDccAddr";
            this.cmbDccAddr.Size = new System.Drawing.Size(386, 21);
            this.cmbDccAddr.TabIndex = 5;
            this.cmbDccAddr.SelectedIndexChanged += new System.EventHandler(this.cmbDccAddr_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "DCC Base Address:";
            // 
            // txtBaseDCC
            // 
            this.txtBaseDCC.Location = new System.Drawing.Point(115, 74);
            this.txtBaseDCC.Name = "txtBaseDCC";
            this.txtBaseDCC.Size = new System.Drawing.Size(100, 20);
            this.txtBaseDCC.TabIndex = 7;
            this.txtBaseDCC.Text = "1";
            // 
            // FileDialogControlOpenLocoProgAspect
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.txtBaseDCC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDccAddr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAspectCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.FileDlgCaption = "";
            this.FileDlgEnableOkBtn = false;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "FileDialogControlOpenLocoProgAspect";
            this.Size = new System.Drawing.Size(514, 106);
            this.EventFileNameChanged += new FileDialogExtenders.FileDialogControlBase.PathChangedEventHandler(this.MyOpenFileDialogControl_FileNameChanged);
            this.EventFolderNameChanged += new FileDialogExtenders.FileDialogControlBase.PathChangedEventHandler(this.MyOpenFileDialogControl_FolderNameChanged);
            this.EventClosingDialog += new System.ComponentModel.CancelEventHandler(this.MyOpenFileDialogControl_ClosingDialog);
            this.Load += new System.EventHandler(this.OpenLocoProgAspectFileDialogControl_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.MyOpenFileDialogControl_HelpRequested);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAspectCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDccAddr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBaseDCC;
    }
}