using NZPostOffice.Shared.VisualComponents;
using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataControls.OdpsLib;
using Metex.Windows;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    partial class WShellImport
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
            this.st_1 = new Label();
            this.dw_import = new URdsDw();
            //!this.dw_import.DataObject = new DShellImport();
            
            this.sle_filename = new TextBox();
            this.cb_import = new Button();
            this.cb_close = new Button();
            this.cb_browse = new Button();

            Controls.Add(st_1);
            Controls.Add(dw_import);
            Controls.Add(sle_filename);
            Controls.Add(cb_import);
            Controls.Add(cb_close);
            Controls.Add(cb_browse);

            this.Text = "Shell Import";
            this.Location = new System.Drawing.Point(231, 121);
            this.Size = new System.Drawing.Size(420, 510);

            // 
            // st_1
            // 
            st_1.TabStop = false;
            st_1.Text = "w_shell_import";
            st_1.BackColor = System.Drawing.SystemColors.Control;
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_1.Location = new System.Drawing.Point(8, 458);
            st_1.Size = new System.Drawing.Size(80, 14);

            // 
            // dw_import
            // 
            //!dw_import.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dw_import.TabIndex = 5;
            dw_import.Location = new System.Drawing.Point(5, 35);
            dw_import.Size = new System.Drawing.Size(400, 410);

            // 
            // sle_filename
            // 
            sle_filename.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_filename.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            sle_filename.TabIndex = 1;
            sle_filename.Location = new System.Drawing.Point(5, 7);
            sle_filename.Size=new System.Drawing.Size(247,23);

            // 
            // cb_import
            // 
            cb_import.Text = "&Import";
            cb_import.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_import.TabIndex = 3;
            cb_import.Location = new System.Drawing.Point(338, 5);
            cb_import.Size = new System.Drawing.Size(65, 26);
            cb_import.Click += new EventHandler(cb_import_clicked);

            // 
            // cb_close
            // 
            this.AcceptButton = cb_close;
            cb_close.Text = "&Close";
            cb_close.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_close.TabIndex = 4;
            cb_close.Location = new System.Drawing.Point(338, 448);
            cb_close.Size=new System.Drawing.Size(65,26);
            cb_close.Click += new EventHandler(cb_close_clicked);

            // 
            // cb_browse
            // 
            cb_browse.Text = "&Browse...";
            cb_browse.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_browse.TabIndex = 2;
            cb_browse.Location = new System.Drawing.Point(256, 5);
            cb_browse.Size=new System.Drawing.Size(65,26);
            cb_browse.Click += new EventHandler(cb_browse_clicked);
            this.ResumeLayout();
        }

        #endregion

        //public DataStore id_import;
        public URdsDw id_import;
        public Label st_1;
        public URdsDw dw_import;
        public TextBox sle_filename;
        public Button cb_import;
        public Button cb_close;
        public Button cb_browse;
    }
}