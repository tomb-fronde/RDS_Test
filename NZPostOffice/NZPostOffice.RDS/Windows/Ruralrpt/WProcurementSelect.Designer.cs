using System.Windows.Forms;
using System;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WProcurementSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Label st_1;

        public Button cb_detail;

        public Button cb_summary;

        public Button cb_cancel;
        
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

            this.SuspendLayout();
            this.st_1 = new Label();
            this.cb_detail = new Button();
            this.cb_summary = new Button();
            this.cb_cancel = new Button();
            Controls.Add(st_1);
            Controls.Add(cb_detail);
            Controls.Add(cb_summary);
            Controls.Add(cb_cancel);
            this.Text = "Contractor Procurements Report";
            this.Name = "w_procurement_select";
            this.Height = 149;
            this.Width = 320;
            // 
            // st_label
            // 
            st_label.Text = "w_procurement_select";
            st_label.Width = 120;
            st_label.Top = 96;
            st_label.Left = 8;
            // 
            // st_1
            // 
            st_1.TabStop = false;
            st_1.Text = "Select the type of report required:";
           
            // st_1.BackColor = 80269524;
            st_1.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_1.Height = 16;
            st_1.Width = 208;
            st_1.Top = 8;
            st_1.Left = 8;
            // 
            // cb_detail
            // 
            cb_detail.Text = "Detail";
            cb_detail.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_detail.TabIndex = 4;
            cb_detail.Height = 23;
            cb_detail.Width = 75;
            cb_detail.Top = 40;
            cb_detail.Left = 128;
            cb_detail.Click += new EventHandler(cb_detail_clicked);
            // 
            // cb_summary
            // 
            cb_summary.Text = "Summary";
            cb_summary.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_summary.TabIndex = 5;
            cb_summary.Height = 23;
            cb_summary.Width = 75;
            cb_summary.Top = 40;
            cb_summary.Left = 40;
            cb_summary.Click += new EventHandler(cb_summary_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Text = "Cancel";
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_cancel.TabIndex = 5;
            cb_cancel.Height = 23;
            cb_cancel.Width = 75;
            cb_cancel.Top = 40;
            cb_cancel.Left = 216;
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            this.ResumeLayout();
        }

        #endregion
    }
}