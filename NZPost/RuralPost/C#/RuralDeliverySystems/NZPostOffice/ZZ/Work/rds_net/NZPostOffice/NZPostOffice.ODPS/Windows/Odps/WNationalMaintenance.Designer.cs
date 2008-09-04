using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataControls.Odps;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.Menus;

namespace NZPostOffice.ODPS.Windows.Odps
{
    partial class WNationalMaintenance
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
            this.dw_single = new NZPostOffice.ODPS.Controls.URdsDw();
            this.cb_1 = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_2 = new NZPostOffice.Shared.VisualComponents.UCb();
            this.dw_1 = new NZPostOffice.ODPS.Controls.URdsDw();
            this.SuspendLayout();
            // 
            // dw_single
            // 
            //!this.dw_single.DataObject = new DwNationalDetail();
            //!this.dw_single.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dw_single.FireConstructor = true;
            this.dw_single.Location = new System.Drawing.Point(3, 4);
            this.dw_single.Name = "dw_single";
            this.dw_single.Size = new System.Drawing.Size(795, 492);
            this.dw_single.TabIndex = 1;
            this.dw_single.Tag = "resize=scale;color=window;";
            // 
            // cb_1
            // 
            this.cb_1.Location = new System.Drawing.Point(11, 499);
            this.cb_1.Name = "cb_1";
            this.cb_1.Size = new System.Drawing.Size(60, 23);
            this.cb_1.TabIndex = 2;
            this.cb_1.Text = "&Ok";
            this.cb_1.Click += new System.EventHandler(this.cb_1_clicked);
            // 
            // cb_2
            // 
            this.cb_2.Location = new System.Drawing.Point(79, 499);
            this.cb_2.Name = "cb_2";
            this.cb_2.Size = new System.Drawing.Size(60, 23);
            this.cb_2.TabIndex = 3;
            this.cb_2.Text = "Ca&ncel";
            this.cb_2.Click += new System.EventHandler(this.cb_2_clicked);
            // 
            // dw_1
            // 
            //!this.dw_1.DataObject = new DwNationalDetail();
            this.dw_1.FireConstructor = true;
            this.dw_1.Location = new System.Drawing.Point(338, 443);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(162, 139);
            this.dw_1.TabIndex = 0;
            this.dw_1.Visible = false;
            // 
            // WNationalMaintenance
            // 
            this.AcceptButton = this.cb_1;
            this.ClientSize = new System.Drawing.Size(802, 528);
            this.Controls.Add(this.dw_single);
            this.Controls.Add(this.cb_1);
            this.Controls.Add(this.cb_2);
            this.Controls.Add(this.dw_1);
            this.Location = new System.Drawing.Point(114, 128);
            this.MaximizeBox = false;
            this.Name = "WNationalMaintenance";
            this.Tag = "color=window;";
            this.Text = "National Maintenance";
            this.Controls.SetChildIndex(this.dw_1, 0);
            this.Controls.SetChildIndex(this.cb_2, 0);
            this.Controls.SetChildIndex(this.cb_1, 0);
            this.Controls.SetChildIndex(this.dw_single, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public URdsDw dw_single;
        public UCb cb_1;
        public UCb cb_2;
        public URdsDw dw_1;
    }
}