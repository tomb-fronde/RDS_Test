using NZPostOffice.ODPS.Menus;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.DataControls.OdpsPayrun;
using System;
using NZPostOffice.ODPS.Controls;

namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
    partial class WNegativePayReport
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
            this.cb_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dw_1
            // 
            this.dw_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_1.DataObject = null;
            this.dw_1.FireConstructor = true;
            this.dw_1.Location = new System.Drawing.Point(0, 1);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(884, 312);
            this.dw_1.TabIndex = 1;
            // 
            // cb_close
            // 
            this.cb_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_close.Location = new System.Drawing.Point(803, 319);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 2;
            this.cb_close.Text = "Close";
            this.cb_close.UseVisualStyleBackColor = true;
            this.cb_close.Click += new System.EventHandler(this.cb_close_Click);
            // 
            // WNegativePayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 344);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.dw_1);
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "WNegativePayReport";
            this.Text = "Negative Pay Report";
            this.Controls.SetChildIndex(this.dw_1, 0);
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public URdsDw dw_1;
        #endregion
        private Button cb_close;

    }
}