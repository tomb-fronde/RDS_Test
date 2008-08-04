using NZPostOffice.ODPS.Menus;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.DataControls.OdpsInvoice;
using System;
using NZPostOffice.ODPS.Controls;
namespace NZPostOffice.ODPS.Windows.OdpsInvoice
{
    partial class WInvoice
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "WInvoice";
            this.SuspendLayout();
            this.cb_export = new Button();
            this.dw_1 = new URdsDw();
            this.cb_save = new Button();
            Controls.Add(cb_export);
            Controls.Add(dw_1);
            Controls.Add(cb_save);
            //?this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(660, 400);
            this.Location = new System.Drawing.Point(10, 10);
            
            // 
            // cb_export
            // 
            cb_export.Text = "&Export";
            cb_export.Enabled = false;
            cb_export.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_export.TabIndex = 3;
            cb_export.Location = new System.Drawing.Point(473, 379);
            cb_export.Size = new System.Drawing.Size(75, 20);
            cb_export.Visible = false;
            cb_export.Click += new EventHandler(cb_export_clicked);
            
            // 
            // dw_1
            // 
            this.dw_1.DataObject = new DwInvoiceHeaderv5();
            dw_1.TabIndex = 1;
            dw_1.Location = new System.Drawing.Point(16, 3);
            dw_1.Size = new System.Drawing.Size(629, 368);
            //?dw_1.RetrieveEnd += new EventHandler(dw_1_retrieveend);
           
            // 
            // cb_save
            // 
            cb_save.Text = "&Save( PSR)";
            cb_save.Location = new System.Drawing.Point(557, 379);
            cb_save.Size = new System.Drawing.Size(73, 20);
            cb_save.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_save.TabIndex = 2;
            cb_save.Click += new EventHandler(cb_save_clicked);
            this.ResumeLayout();
        }

        public Button cb_export;
        public URdsDw dw_1;
        public Button cb_save;
        #endregion
    }
}