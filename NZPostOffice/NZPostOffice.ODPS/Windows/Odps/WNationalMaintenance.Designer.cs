using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataControls.Odps;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.Menus;

namespace NZPostOffice.ODPS.Windows.Odps
{
    // TJB  RPCR_128  July-2019
    // Minor tweaks: changed button names (cb_1 -> cb_ok, cb_2 -> cb_cancel)
    // Changed size

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
            this.cb_ok = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_cancel = new NZPostOffice.Shared.VisualComponents.UCb();
            this.dw_1 = new NZPostOffice.ODPS.Controls.URdsDw();
            this.SuspendLayout();
            // 
            // dw_single
            // 
            this.dw_single.DataObject = null;
            this.dw_single.FireConstructor = true;
            this.dw_single.Location = new System.Drawing.Point(3, 4);
            this.dw_single.Name = "dw_single";
            this.dw_single.Size = new System.Drawing.Size(795, 553);
            this.dw_single.TabIndex = 1;
            this.dw_single.Tag = "resize=scale;color=window;";
            // 
            // cb_ok
            // 
            this.cb_ok.Location = new System.Drawing.Point(10, 563);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(60, 23);
            this.cb_ok.TabIndex = 2;
            this.cb_ok.Text = "&Ok";
            this.cb_ok.Click += new System.EventHandler(this.cb_ok_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.Location = new System.Drawing.Point(78, 563);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(60, 23);
            this.cb_cancel.TabIndex = 3;
            this.cb_cancel.Text = "Ca&ncel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // dw_1
            // 
            this.dw_1.DataObject = null;
            this.dw_1.FireConstructor = true;
            this.dw_1.Location = new System.Drawing.Point(338, 443);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(162, 139);
            this.dw_1.TabIndex = 0;
            this.dw_1.Visible = false;
            // 
            // WNationalMaintenance
            // 
            this.AcceptButton = this.cb_ok;
            this.ClientSize = new System.Drawing.Size(802, 591);
            this.Controls.Add(this.dw_single);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.cb_cancel);
            this.Controls.Add(this.dw_1);
            this.Location = new System.Drawing.Point(114, 128);
            this.MaximizeBox = false;
            this.Name = "WNationalMaintenance";
            this.Tag = "color=window;";
            this.Text = "National Maintenance";
            this.Controls.SetChildIndex(this.dw_1, 0);
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.cb_ok, 0);
            this.Controls.SetChildIndex(this.dw_single, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public URdsDw dw_single;
        public UCb cb_ok;
        public UCb cb_cancel;
        public URdsDw dw_1;
    }
}