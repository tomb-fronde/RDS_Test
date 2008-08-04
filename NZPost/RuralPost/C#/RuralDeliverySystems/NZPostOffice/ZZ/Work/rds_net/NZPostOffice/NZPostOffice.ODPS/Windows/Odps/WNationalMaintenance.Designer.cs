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
            this.SuspendLayout();

            this.dw_single = new URdsDw();
            this.cb_1 = new UCb();
            this.cb_2 = new UCb();
            Controls.Add(dw_single);
            Controls.Add(cb_1);
            Controls.Add(cb_2);
            Controls.Add(dw_1);
            this.MaximizeBox = false;
            this.Tag = "color=window;";
            this.Text = "National Maintenance";
            this.ControlBox = true;
            this.Location = new System.Drawing.Point(114, 128);
            this.Size = new System.Drawing.Size(810, 520);
           
            // 
            // dw_single
            // 
            dw_single.DataObject = new DwNationalDetail();
            dw_single.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_single.Tag = "resize=scale;color=window;";
            dw_single.TabIndex = 1;
            dw_single.Location = new System.Drawing.Point(3, 4);
            dw_single.Size = new System.Drawing.Size(795, 455);
           
            // 
            // cb_1
            //
            this.AcceptButton = cb_1;
            cb_1.Text = "&Ok";
            cb_1.TabIndex = 2;
            cb_1.Location = new System.Drawing.Point(8, 460);
            cb_1.Size = new System.Drawing.Size(60, 23);
            cb_1.Click += new EventHandler(cb_1_clicked);
           
            // 
            // cb_2
            // 
            cb_2.Text = "Ca&ncel";
            cb_2.TabIndex = 3;
            cb_2.Location = new System.Drawing.Point(76, 460);
            cb_2.Size = new System.Drawing.Size(60, 23);
            cb_2.Click += new EventHandler(cb_2_clicked);
           
            // 
            // dw_1
            // 
            dw_1 = new URdsDw();
            dw_1.DataObject = new DwNationalDetail();
            dw_1.Visible = false;
            dw_1.TabIndex = 0;
            dw_1.Location = new System.Drawing.Point(338, 443);
       
            this.ResumeLayout();
        }

        #endregion

        public URdsDw dw_single;
        public UCb cb_1;
        public UCb cb_2;
        public URdsDw dw_1;
    }
}