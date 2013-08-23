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
            this.dw_1 = new NZPostOffice.ODPS.Controls.URdsDw();
            this.SuspendLayout();
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
            // WInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 315);
            this.Controls.Add(this.dw_1);
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "WInvoice";
            this.Text = "WInvoice";
            this.Controls.SetChildIndex(this.dw_1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public URdsDw dw_1;
        #endregion
    }
}