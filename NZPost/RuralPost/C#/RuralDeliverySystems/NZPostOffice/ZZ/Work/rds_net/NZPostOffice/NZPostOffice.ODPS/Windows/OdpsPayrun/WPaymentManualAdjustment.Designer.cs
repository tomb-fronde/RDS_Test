using NZPostOffice.ODPS.Controls;
using System.Windows.Forms;
using System;
using NZPostOffice.ODPS.DataControls.OdpsPayrun;
namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
    partial class WPaymentManualAdjustment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WPaymentManualAdjustment));
            this.dw_1 = new NZPostOffice.ODPS.Controls.URdsDw();
            this.cb_ok = new System.Windows.Forms.Button();
            this.cb_print = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dw_1
            // 
            this.dw_1.DataObject = null;
            this.dw_1.FireConstructor = false;
            this.dw_1.Location = new System.Drawing.Point(5, 5);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(530, 310);
            this.dw_1.TabIndex = 2;
            // 
            // cb_ok
            // 
            this.cb_ok.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_ok.Location = new System.Drawing.Point(481, 321);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(54, 25);
            this.cb_ok.TabIndex = 3;
            this.cb_ok.Text = "&OK";
            this.cb_ok.Click += new System.EventHandler(this.cb_ok_clicked);
            // 
            // cb_print
            // 
            this.cb_print.Enabled = false;
            this.cb_print.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_print.Location = new System.Drawing.Point(421, 321);
            this.cb_print.Name = "cb_print";
            this.cb_print.Size = new System.Drawing.Size(54, 25);
            this.cb_print.TabIndex = 1;
            this.cb_print.TabStop = false;
            this.cb_print.Text = "&Print";
            this.cb_print.Visible = false;
            this.cb_print.Click += new System.EventHandler(this.cb_print_clicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(2, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "WPaymentManualAdjustment";
            // 
            // WPaymentManualAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 346);
            this.Controls.Add(this.dw_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.cb_print);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WPaymentManualAdjustment";
            this.Text = "Automatic Deductions Not Applied";
            this.Controls.SetChildIndex(this.cb_print, 0);
            this.Controls.SetChildIndex(this.cb_ok, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dw_1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public URdsDw dw_1;
        public Button cb_ok;
        public Button cb_print;
        private Label label1;
    }
}