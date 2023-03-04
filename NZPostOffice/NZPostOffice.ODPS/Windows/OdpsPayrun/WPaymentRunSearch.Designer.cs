using NZPostOffice.ODPS.DataControls.OdpsPayrun;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using System;
using NZPostOffice.Shared.VisualComponents;

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
            this.pb_1 = new System.Windows.Forms.Button();
            this.cb_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dw_search
            // 
            this.dw_search.FireConstructor = true;
            this.dw_search.Location = new System.Drawing.Point(3, 8);
            this.dw_search.Size = new System.Drawing.Size(302, 126);
            this.dw_search.ItemChanged += new System.EventHandler(this.dw_search_itemchanged);
            this.dw_search.LostFocus += new System.EventHandler(this.dw_search_losefocus);
            // 
            // cb_search
            // 
            this.cb_search.Location = new System.Drawing.Point(319, 49);
            this.cb_search.Click += new System.EventHandler(this.cb_search_Click);
            // 
            // cb_open
            // 
            this.cb_open.Location = new System.Drawing.Point(319, 87);
            this.cb_open.TabIndex = 5;
            // 
            // dw_results
            // 
            this.dw_results.FireConstructor = true;
            this.dw_results.Location = new System.Drawing.Point(3, 140);
            this.dw_results.Size = new System.Drawing.Size(302, 201);
            this.dw_results.TabIndex = 4;
            this.dw_results.DoubleClick += new System.EventHandler(this.dw_results_doubleclicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.Location = new System.Drawing.Point(319, 125);
            this.cb_cancel.TabIndex = 6;
            this.cb_cancel.Visible = false;
            // 
            // pb_1
            // 
            this.pb_1.Enabled = false;
            this.pb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pb_1.Location = new System.Drawing.Point(280, 46);
            this.pb_1.Name = "pb_1";
            this.pb_1.Size = new System.Drawing.Size(17, 21);
            this.pb_1.TabIndex = 3;
            this.pb_1.Text = "?";
            this.pb_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pb_1.Visible = false;
            this.pb_1.Click += new System.EventHandler(this.pb_1_clicked);
            // 
            // cb_clear
            // 
            this.cb_clear.Location = new System.Drawing.Point(321, 155);
            this.cb_clear.Name = "cb_clear";
            this.cb_clear.Size = new System.Drawing.Size(56, 23);
            this.cb_clear.TabIndex = 7;
            this.cb_clear.Text = "Clear";
            this.cb_clear.UseVisualStyleBackColor = true;
            this.cb_clear.Click += new System.EventHandler(this.cb_clear_Click);
            // 
            // WPaymentRunSearch
            // 
            this.AcceptButton = this.pb_1;
            this.ClientSize = new System.Drawing.Size(384, 344);
            this.Controls.Add(this.cb_clear);
            this.Controls.Add(this.pb_1);
            this.Name = "WPaymentRunSearch";
            this.Text = "Payment Run";
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.dw_results, 0);
            this.Controls.SetChildIndex(this.cb_open, 0);
            this.Controls.SetChildIndex(this.cb_search, 0);
            this.Controls.SetChildIndex(this.dw_search, 0);
            this.Controls.SetChildIndex(this.pb_1, 0);
            this.Controls.SetChildIndex(this.cb_clear, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Button pb_1;
        private Button cb_clear;
    }
}
