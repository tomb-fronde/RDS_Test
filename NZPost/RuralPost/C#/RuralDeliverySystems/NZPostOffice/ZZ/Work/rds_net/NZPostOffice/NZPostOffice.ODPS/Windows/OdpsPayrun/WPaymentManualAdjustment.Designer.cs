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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.Size = new System.Drawing.Size(550, 373);

            this.SuspendLayout();
            this.dw_1 = new URdsDw();
            this.dw_1.DataObject = new DwPaymentManualAdjustment();

            this.cb_ok = new Button();
            this.cb_print = new Button();
          
            Controls.Add(dw_1);
            Controls.Add(cb_ok);
            Controls.Add(cb_print);
            this.Text = "Automatic Deductions Not Applied";
            this.ControlBox = true;
           
            // 
            // dw_1
            // 
            dw_1.TabIndex = 2;
            dw_1.Location = new System.Drawing.Point(5, 5);
            dw_1.Size = new System.Drawing.Size(530, 310);
           
            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 3;
            cb_ok.Location = new System.Drawing.Point(405, 319);
            cb_ok.Size = new System.Drawing.Size(54, 25);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
          
            // 
            // cb_print
            // 
            cb_print.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_print.Text = "&Print";
            cb_print.TabIndex = 1;
            cb_print.Location = new System.Drawing.Point(481, 319);
            cb_print.Size = new System.Drawing.Size(54, 25);
            cb_print.Click += new EventHandler(cb_print_clicked);
            this.Icon = global::NZPostOffice.Shared.Properties.Resources.SAFE02;
            this.ResumeLayout();
        }

        public URdsDw dw_1;
        public Button cb_ok;
        public Button cb_print;
    }
}