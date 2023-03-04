using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  RPCR_026  June-2011: New
    // Adapted from DDddwRenewalgroup.designer

    partial class DDddwStripHeight
    {
        private System.ComponentModel.IContainer components = null;
        private Metex.Windows.DataEntityListBox listBox;
        //private System.Windows.Forms.DataGridViewTextBoxColumn sh_height;
        private TextBox sh_height;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Metex.Windows.DataEntityGrid grid;
        
        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.listBox = new Metex.Windows.DataEntityListBox();
            this.Name = "DDddwStripHeight";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwStripHeight);

            // 
            // listBox
            // 
            this.listBox.DataSource = this.bindingSource;
            this.listBox.DisplayMember = "ShHeight";
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(199, 173);
            this.listBox.TabIndex = 0;

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //?this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
        }
        #endregion
    }
}
