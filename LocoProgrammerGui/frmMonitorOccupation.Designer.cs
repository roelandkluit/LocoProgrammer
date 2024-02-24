
namespace LocoProgrammer
{
    partial class frmMonitorOccupation
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
            this.components = new System.ComponentModel.Container();
            this.tmrBoldtoNormal = new System.Windows.Forms.Timer(this.components);
            this.chkSound = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tmrBoldtoNormal
            // 
            this.tmrBoldtoNormal.Interval = 250;
            this.tmrBoldtoNormal.Tick += new System.EventHandler(this.tmrBoldtoNormal_Tick);
            // 
            // chkSound
            // 
            this.chkSound.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSound.AutoSize = true;
            this.chkSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chkSound.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSound.Image = global::LocoProgrammer.Properties.Resources.volume_off;
            this.chkSound.Location = new System.Drawing.Point(763, 3);
            this.chkSound.Name = "chkSound";
            this.chkSound.Size = new System.Drawing.Size(22, 22);
            this.chkSound.TabIndex = 0;
            this.chkSound.UseMnemonic = false;
            this.chkSound.UseVisualStyleBackColor = false;
            this.chkSound.CheckedChanged += new System.EventHandler(this.chkSound_CheckedChanged);
            // 
            // frmMonitorOccupation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 473);
            this.Controls.Add(this.chkSound);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMonitorOccupation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "S88 Occupation Monitor";
            this.Load += new System.EventHandler(this.frmMonitorOccupation_Load);
            this.Shown += new System.EventHandler(this.frmMonitorOccupation_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrBoldtoNormal;
        private System.Windows.Forms.CheckBox chkSound;
    }
}