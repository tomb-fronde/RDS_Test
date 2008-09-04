using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataControls.Odps;

namespace NZPostOffice.ODPS.Windows.Odps
{
    partial class WYearSearch
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
            this.Size = new System.Drawing.Size(201, 94);
            this.Text = "Search";
            
            // 
            // dw_search
            // 
            dw_search = new URdsDw();
            //!dw_search.DataObject = new DwYearSearch();
            //!dw_search.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_search.Location = new System.Drawing.Point(3, 6);
            dw_search.Size = new System.Drawing.Size(112, 52);
            
            // 
            // cb_ok
            // 
            cb_ok = new Button();
            cb_ok.Location = new System.Drawing.Point(128, 6);
            cb_ok.Size = new System.Drawing.Size(60, 23);
            cb_ok.Text = "&Ok";
         
            // 
            // cb_cancel
            // 
            cb_cancel = new Button();
            cb_cancel.Location = new System.Drawing.Point(128, 36);
            cb_cancel.Size = new System.Drawing.Size(60, 23);
            cb_cancel.Text = "&Cancel";
            this.Controls.Add(dw_search);
            this.Controls.Add(cb_ok);
            this.Controls.Add(cb_cancel);
            this.ResumeLayout();
        }

        private Button cb_ok;
        private Button cb_cancel;
        private URdsDw dw_search;
        #endregion
    }
}