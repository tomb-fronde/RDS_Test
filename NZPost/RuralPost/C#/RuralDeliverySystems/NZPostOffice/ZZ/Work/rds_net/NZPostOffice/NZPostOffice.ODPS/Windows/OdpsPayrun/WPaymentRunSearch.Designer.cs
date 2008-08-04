using NZPostOffice.ODPS.DataControls.OdpsPayrun;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using System;
namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
    partial class WPaymentRunSearch
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
            this.SuspendLayout();
            this.pb_1 = new Button();
            pb_1.BringToFront();
            Controls.Add(pb_1);

            this.dw_search.DataObject = new DwPaymentRunPeriod();
            this.dw_results.DataObject = new DwPaymentRunContractors();
            this.Text = "Payment Run";
            this.Size = new System.Drawing.Size(392, 310);
            // 
            // dw_search
            // 

            dw_search.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_search.Location = new System.Drawing.Point(3, 8);
            dw_search.Size = new System.Drawing.Size(302, 64);
            dw_search.ItemChanged += new EventHandler(dw_search_itemchanged);
            dw_search.LostFocus += new EventHandler(dw_search_losefocus);

            // 
            // cb_search
            // 
            cb_search.Location = new System.Drawing.Point(323, 49);
            cb_search.Visible = false;
            // 
            // cb_open
            // 
            cb_open.TabIndex = 5;
            cb_open.Location = new System.Drawing.Point(316, 83);

            // 
            // dw_results
            // 
            dw_results.TabIndex = 4;
            dw_results.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_results.Location = new System.Drawing.Point(3, 80);
            dw_results.Size = new System.Drawing.Size(302, 188);
            dw_results.DoubleClick += new EventHandler(dw_results_doubleclicked);

            // 
            // cb_cancel
            // 
            cb_cancel.TabIndex = 6;
            cb_cancel.Location = new System.Drawing.Point(323, 125);
            cb_cancel.Visible = false;

            // 
            // pb_1
            // 
            pb_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AcceptButton = pb_1;
            pb_1.Text = "?";
            pb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_1.TabIndex = 3;
            pb_1.Location = new System.Drawing.Point(280, 46);
            pb_1.Size = new System.Drawing.Size(17, 21);
            pb_1.Click += new EventHandler(pb_1_clicked);
            this.Controls.SetChildIndex(this.pb_1, 0);

            this.ResumeLayout();
        }

        private Button pb_1;
    }
}
