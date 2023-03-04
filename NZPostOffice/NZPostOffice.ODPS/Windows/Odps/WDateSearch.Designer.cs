using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataControls.Odps;

namespace NZPostOffice.ODPS.Windows.Odps
{
    partial class WDateSearch
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
            this.dw_search = new NZPostOffice.ODPS.Controls.URdsDw();
            this.cb_ok = new System.Windows.Forms.Button();
            this.cb_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dw_search
            // 
            this.dw_search.FireConstructor = true;
            this.dw_search.Location = new System.Drawing.Point(3, 5);
            this.dw_search.Name = "dw_search";
            this.dw_search.Size = new System.Drawing.Size(160, 52);
            this.dw_search.TabIndex = 1;
            // 
            // cb_ok
            // 
            this.cb_ok.Location = new System.Drawing.Point(180, 6);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(60, 23);
            this.cb_ok.TabIndex = 2;
            this.cb_ok.Text = "&Ok";
            // 
            // cb_cancel
            // 
            this.cb_cancel.Location = new System.Drawing.Point(180, 36);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(60, 23);
            this.cb_cancel.TabIndex = 3;
            this.cb_cancel.Text = "&Cancel";
            // 
            // WDateSearch
            // 
            this.ClientSize = new System.Drawing.Size(246, 67);
            this.Controls.Add(this.dw_search);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.cb_cancel);
            this.Name = "WDateSearch";
            this.Text = "Search";
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.cb_ok, 0);
            this.Controls.SetChildIndex(this.dw_search, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button cb_ok;
        private Button cb_cancel;
        private URdsDw dw_search;

        #endregion
    }
}