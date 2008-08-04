using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    partial class WContractAdjustmentsImport
    {
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_import;

        public URdsDw dw_import;

        public TextBox sle_filename;

        public Button cb_browse;

        public Button cb_close;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cb_import = new Button();
            this.dw_import = new URdsDw();
            this.dw_import.DataObject = new DContractAdjustmentsImport();
            this.sle_filename = new TextBox();
            this.cb_browse = new Button();
            this.cb_close = new Button();
            Controls.Add(cb_import);
            Controls.Add(dw_import);
            Controls.Add(sle_filename);
            Controls.Add(cb_browse);
            Controls.Add(cb_close);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Text = "Contract Adjustments Import";
            this.Size = new System.Drawing.Size(392, 426);
            // 
            // st_label
            // 
            st_label.Location = new System.Drawing.Point(12, 361);
            st_label.Size = new System.Drawing.Size(173, 23);
            st_label.Visible = false;
            // 
            // cb_import
            // 
            cb_import.Text = "&Import";
            cb_import.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_import.TabIndex = 2;
            cb_import.Location = new System.Drawing.Point(315, 4);
            cb_import.Size = new System.Drawing.Size(70, 21);
            cb_import.Click += new EventHandler(cb_import_clicked);
            // 
            // dw_import
            // 
            dw_import.Location = new System.Drawing.Point(3, 30);
            dw_import.Size = new System.Drawing.Size(380, 325);
            // 
            // sle_filename
            // 
            sle_filename.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_filename.Font = new System.Drawing.Font("MS Sans Serif", 10, System.Drawing.FontStyle.Regular);
            sle_filename.TabIndex = 1;
            sle_filename.Location = new System.Drawing.Point(3, 4);
            sle_filename.Size = new System.Drawing.Size(219, 24);
            // 
            // cb_browse
            // 
            cb_browse.Text = "&Browse ...";
            cb_browse.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_browse.TabIndex = 3;
            cb_browse.Location = new System.Drawing.Point(233, 4);
            cb_browse.Size = new System.Drawing.Size(70, 21);
            cb_browse.Click += new EventHandler(cb_browse_clicked);
            // 
            // cb_close
            // 
            cb_close.Text = "&Close";
            cb_close.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_close.TabIndex = 6;
            cb_close.Location = new System.Drawing.Point(331, 361);
            cb_close.Size = new System.Drawing.Size(52, 21);
            cb_close.Click += new EventHandler(cb_close_clicked);
            this.ResumeLayout();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
