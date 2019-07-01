using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.DataControls.Odps;
using Metex.Windows;

namespace NZPostOffice.ODPS.Windows.Odps
{
    // TJB  RPCR_128  June-2019
    // Added checkbox1
    // Changed anchors for buttons to lower right

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
            this.cb_ok = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_cancel = new NZPostOffice.Shared.VisualComponents.UCb();
            this.dw_1 = new NZPostOffice.ODPS.Controls.URdsDw();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dw_gl07records = new NZPostOffice.ODPS.Controls.URdsDw();
            this.dw_primary = new NZPostOffice.ODPS.Controls.URdsDw();
            this.dw_secondary = new NZPostOffice.ODPS.Controls.URdsDw();
            this.cb_1 = new System.Windows.Forms.Button();
            this.dw_tertiary = new NZPostOffice.ODPS.Controls.URdsDw();
            this.SuspendLayout();
            // 
            // cb_ok
            // 
            this.cb_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_ok.Location = new System.Drawing.Point(50, 90);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(60, 23);
            this.cb_ok.TabIndex = 2;
            this.cb_ok.Text = "&Ok";
            this.cb_ok.Click += new System.EventHandler(this.cb_ok_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_cancel.Location = new System.Drawing.Point(126, 90);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(60, 23);
            this.cb_cancel.TabIndex = 7;
            this.cb_cancel.Text = "Ca&ncel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // dw_1
            // 
            this.dw_1.DataObject = null;
            this.dw_1.FireConstructor = true;
            this.dw_1.Location = new System.Drawing.Point(3, 4);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(250, 65);
            this.dw_1.TabIndex = 1;
            this.dw_1.ItemChanged += new System.EventHandler(this.dw_1_itemchanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(50, 67);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(142, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Include Column Headers";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dw_gl07records
            // 
            this.dw_gl07records.DataObject = null;
            this.dw_gl07records.FireConstructor = false;
            this.dw_gl07records.Location = new System.Drawing.Point(0, 0);
            this.dw_gl07records.Name = "dw_gl07records";
            this.dw_gl07records.Size = new System.Drawing.Size(162, 139);
            this.dw_gl07records.TabIndex = 0;
            // 
            // dw_primary
            // 
            this.dw_primary.DataObject = null;
            this.dw_primary.FireConstructor = true;
            this.dw_primary.Location = new System.Drawing.Point(5, 115);
            this.dw_primary.Name = "dw_primary";
            this.dw_primary.Size = new System.Drawing.Size(151, 397);
            this.dw_primary.TabIndex = 6;
            this.dw_primary.Visible = false;
            // 
            // dw_secondary
            // 
            this.dw_secondary.DataObject = null;
            this.dw_secondary.FireConstructor = true;
            this.dw_secondary.Location = new System.Drawing.Point(171, 117);
            this.dw_secondary.Name = "dw_secondary";
            this.dw_secondary.Size = new System.Drawing.Size(197, 394);
            this.dw_secondary.TabIndex = 4;
            this.dw_secondary.Visible = false;
            // 
            // cb_1
            // 
            this.cb_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_1.Location = new System.Drawing.Point(195, 89);
            this.cb_1.Name = "cb_1";
            this.cb_1.Size = new System.Drawing.Size(60, 23);
            this.cb_1.TabIndex = 3;
            this.cb_1.Text = "Copy rows";
            this.cb_1.Visible = false;
            this.cb_1.Click += new System.EventHandler(this.cb_1_clicked);
            // 
            // dw_tertiary
            // 
            this.dw_tertiary.DataObject = null;
            this.dw_tertiary.FireConstructor = true;
            this.dw_tertiary.Location = new System.Drawing.Point(380, 119);
            this.dw_tertiary.Name = "dw_tertiary";
            this.dw_tertiary.Size = new System.Drawing.Size(403, 390);
            this.dw_tertiary.TabIndex = 5;
            this.dw_tertiary.Visible = false;
            // 
            // WExportCriteria
            // 
            this.AcceptButton = this.cb_ok;
            this.ClientSize = new System.Drawing.Size(263, 117);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cb_1);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.cb_cancel);
            this.Controls.Add(this.dw_1);
            this.Controls.Add(this.dw_primary);
            this.Controls.Add(this.dw_secondary);
            this.Controls.Add(this.dw_tertiary);
            this.Location = new System.Drawing.Point(31, 116);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WExportCriteria";
            this.Text = "Payment";
            this.Controls.SetChildIndex(this.dw_tertiary, 0);
            this.Controls.SetChildIndex(this.dw_secondary, 0);
            this.Controls.SetChildIndex(this.dw_primary, 0);
            this.Controls.SetChildIndex(this.dw_1, 0);
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.cb_ok, 0);
            this.Controls.SetChildIndex(this.cb_1, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public string is_datawindow_object = String.Empty;
        //  boolean ib_netpayvariance 
        public string ls_report_name = String.Empty;

        public UCb cb_ok;
        public UCb cb_cancel;
        public URdsDw dw_1;
        public URdsDw dw_gl07records;
        public URdsDw dw_primary;
        public URdsDw dw_secondary;
        public Button cb_1;
        public URdsDw dw_tertiary;
        private CheckBox checkBox1;
    }
}