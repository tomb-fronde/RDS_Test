using NZPostOffice.Shared.VisualComponents;
using System;
using NZPostOffice.ODPS.Controls;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    partial class WSimpleSearch
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_search = new URdsDw(); 
            this.cb_ok = new UCb();
            this.cb_cancel = new UCb();
            Controls.Add(dw_search);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Tag = "color=window;";
            this.Text = "Search";
            this.ControlBox = true;
            this.Location = new System.Drawing.Point(318, 313);
            this.Size = new System.Drawing.Size(346, 140);
            // 
            // dw_search
            // 
            dw_search.TabIndex = 1;
            dw_search.Location = new System.Drawing.Point(8, 8);
            dw_search.Size = new System.Drawing.Size(252, 96);
            // 
            // cb_ok
            // 
            cb_ok.Text = "&Ok";
            cb_ok.TabIndex = 2;
            cb_ok.Location = new System.Drawing.Point(268, 8);
            cb_ok.Size = new System.Drawing.Size(60, 23);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 3;
            cb_cancel.Location = new System.Drawing.Point(268, 39);
            cb_cancel.Size = new System.Drawing.Size(60, 23);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            this.ResumeLayout();
        }

        public URdsDw dw_search;
        public UCb cb_ok;
        public UCb cb_cancel;
    }
}