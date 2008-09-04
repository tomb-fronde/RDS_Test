using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.DataControls.Odps;
using Metex.Windows;

namespace NZPostOffice.ODPS.Windows.Odps
{
    partial class WExportCriteria
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
            this.cb_ok = new UCb();
            this.cb_cancel = new UCb();
            
            this.dw_1 = new URdsDw();
            //!this.dw_1.DataObject = new DwReportCriteria();

            this.dw_primary = new URdsDw();
            this.dw_secondary = new URdsDw();

            this.cb_1 = new Button();
            this.dw_tertiary = new URdsDw();

            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            Controls.Add(dw_1);
            Controls.Add(dw_primary);
            Controls.Add(dw_secondary);
            Controls.Add(cb_1);
            Controls.Add(dw_tertiary);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Text = "Payment";
            this.Location = new System.Drawing.Point(31, 116);
            this.Size = new System.Drawing.Size(264, 131);
          
            // 
            // cb_ok
            // 
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&Ok";
            cb_ok.TabIndex = 2;
            cb_ok.Location = new System.Drawing.Point(50, 72);
            cb_ok.Size = new System.Drawing.Size(60, 23);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
     
            // 
            // cb_cancel
            // 
            cb_cancel.Text = "Ca&ncel";
            cb_cancel.TabIndex = 7;
            cb_cancel.Location = new System.Drawing.Point(130, 72);
            cb_cancel.Size = new System.Drawing.Size(60, 23);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
           
            // 
            // dw_1
            // 
            dw_1.TabIndex = 1;
            dw_1.Location = new System.Drawing.Point(3, 4);
            dw_1.Size = new System.Drawing.Size(250, 65);
            dw_1.ItemChanged += new EventHandler(dw_1_itemchanged);
           
            // 
            // dw_primary
            // 
            dw_primary.TabIndex = 6;
            dw_primary.Location = new System.Drawing.Point(5, 115);
            dw_primary.Size = new System.Drawing.Size(151, 397);
            dw_primary.Visible = false;
           
            // 
            // dw_secondary
            // 
            dw_secondary.TabIndex = 4;
            dw_secondary.Location = new System.Drawing.Point(171, 117);
            dw_secondary.Size = new System.Drawing.Size(197, 394);
            dw_secondary.Visible = false;
            // 
            // cb_1
            // 
            cb_1.Text = "Copy rows";
            cb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_1.TabIndex = 3;
            cb_1.Location = new System.Drawing.Point(195, 71);
            cb_1.Size = new System.Drawing.Size(62, 27);
            cb_1.Visible = false;
            cb_1.Click += new EventHandler(cb_1_clicked);
            
            // 
            // dw_tertiary
            // 
            dw_tertiary.TabIndex = 5;
            dw_tertiary.Location = new System.Drawing.Point(380, 119);
            dw_tertiary.Size = new System.Drawing.Size(403, 390);
            dw_tertiary.Visible = false;

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ResumeLayout();
        }

        #endregion

        public string is_datawindow_object = String.Empty;
        //  boolean ib_netpayvariance 
        public string ls_report_name = String.Empty;

        public UCb cb_ok;
        public UCb cb_cancel;
        public URdsDw dw_1;
        public URdsDw dw_primary;
        public URdsDw dw_secondary;
        public Button cb_1;
        public URdsDw dw_tertiary;
    }
}