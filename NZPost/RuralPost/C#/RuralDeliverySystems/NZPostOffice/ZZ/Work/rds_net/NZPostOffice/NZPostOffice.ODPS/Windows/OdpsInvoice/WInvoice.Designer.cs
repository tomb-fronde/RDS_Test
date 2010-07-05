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
            this.cb_export = new System.Windows.Forms.Button();
            this.dw_1 = new NZPostOffice.ODPS.Controls.URdsDw();
            this.cb_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_export
            // 
            this.cb_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_export.Enabled = false;
            this.cb_export.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_export.Location = new System.Drawing.Point(704, 332);
            this.cb_export.Name = "cb_export";
            this.cb_export.Size = new System.Drawing.Size(75, 20);
            this.cb_export.TabIndex = 3;
            this.cb_export.Text = "&Export";
            this.cb_export.Visible = false;
            this.cb_export.Click += new System.EventHandler(this.cb_export_clicked);
            // 
            // dw_1
            // 
            this.dw_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_1.DataObject = null;
            this.dw_1.FireConstructor = true;
            this.dw_1.Location = new System.Drawing.Point(5, 5);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(866, 298);
            this.dw_1.TabIndex = 1;
            // 
            // cb_save
            // 
            this.cb_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_save.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_save.Location = new System.Drawing.Point(788, 332);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(73, 20);
            this.cb_save.TabIndex = 2;
            this.cb_save.Text = "&Save(PSR)";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);
            // 
            // WInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 315);
            this.Controls.Add(this.cb_export);
            this.Controls.Add(this.dw_1);
            this.Controls.Add(this.cb_save);
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "WInvoice";
            this.Text = "WInvoice";
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.dw_1, 0);
            this.Controls.SetChildIndex(this.cb_export, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public Button cb_export;
        public URdsDw dw_1;
        public Button cb_save;
        #endregion
    }
}