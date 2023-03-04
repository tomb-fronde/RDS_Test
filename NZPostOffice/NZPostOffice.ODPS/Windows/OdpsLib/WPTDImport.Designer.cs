using NZPostOffice.Shared.VisualComponents;
using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataControls.OdpsLib;
using Metex.Windows;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    partial class WPTDImport
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
            this.st_1 = new System.Windows.Forms.Label();
            this.dw_import = new NZPostOffice.ODPS.Controls.URdsDw();
            this.sle_filename = new System.Windows.Forms.TextBox();
            this.cb_close = new System.Windows.Forms.Button();
            this.cb_browse = new System.Windows.Forms.Button();
            this.cb_insert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // st_1
            // 
            this.st_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.st_1.BackColor = System.Drawing.SystemColors.Control;
            this.st_1.Font = new System.Drawing.Font("Arial", 8F);
            this.st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_1.Location = new System.Drawing.Point(8, 458);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(80, 14);
            this.st_1.TabIndex = 1;
            this.st_1.Text = "w_PTD_import";
            // 
            // dw_import
            // 
            this.dw_import.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_import.DataObject = null;
            this.dw_import.FireConstructor = true;
            this.dw_import.Location = new System.Drawing.Point(11, 35);
            this.dw_import.Name = "dw_import";
            this.dw_import.Size = new System.Drawing.Size(394, 410);
            this.dw_import.TabIndex = 5;
            // 
            // sle_filename
            // 
            this.sle_filename.Font = new System.Drawing.Font("Arial", 8F);
            this.sle_filename.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sle_filename.Location = new System.Drawing.Point(9, 7);
            this.sle_filename.Name = "sle_filename";
            this.sle_filename.Size = new System.Drawing.Size(247, 20);
            this.sle_filename.TabIndex = 1;
            // 
            // cb_close
            // 
            this.cb_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_close.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_close.Location = new System.Drawing.Point(338, 452);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(65, 26);
            this.cb_close.TabIndex = 4;
            this.cb_close.Text = "&Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // cb_browse
            // 
            this.cb_browse.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_browse.Location = new System.Drawing.Point(260, 5);
            this.cb_browse.Name = "cb_browse";
            this.cb_browse.Size = new System.Drawing.Size(65, 26);
            this.cb_browse.TabIndex = 2;
            this.cb_browse.Text = "&Browse...";
            this.cb_browse.Click += new System.EventHandler(this.cb_browse_clicked);
            // 
            // cb_insert
            // 
            this.cb_insert.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_insert.Location = new System.Drawing.Point(338, 4);
            this.cb_insert.Name = "cb_insert";
            this.cb_insert.Size = new System.Drawing.Size(65, 26);
            this.cb_insert.TabIndex = 6;
            this.cb_insert.Text = "&Import";
            this.cb_insert.Click += new System.EventHandler(this.cb_insert_Click);
            // 
            // WPTDImport
            // 
            this.AcceptButton = this.cb_close;
            this.ClientSize = new System.Drawing.Size(415, 483);
            this.Controls.Add(this.cb_insert);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.dw_import);
            this.Controls.Add(this.sle_filename);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.cb_browse);
            this.Location = new System.Drawing.Point(231, 121);
            this.Name = "WPTDImport";
            this.Text = "Post-Tax Deductions Import";
            this.Controls.SetChildIndex(this.cb_browse, 0);
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.Controls.SetChildIndex(this.sle_filename, 0);
            this.Controls.SetChildIndex(this.dw_import, 0);
            this.Controls.SetChildIndex(this.st_1, 0);
            this.Controls.SetChildIndex(this.cb_insert, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //public DataStore id_import;
        public URdsDw id_import;
        public Label st_1;
        public URdsDw dw_import;
        public TextBox sle_filename;
        public Button cb_close;
        public Button cb_browse;
        public Button cb_insert;
    }
}