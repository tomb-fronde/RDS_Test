using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using System;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WVExpirySearch
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

        public int ii_report_type = 1;

        public RadioButton rb_region;

        public RadioButton rb_renewal;

        public Label st_1;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.rb_region = new RadioButton();
            this.rb_renewal = new RadioButton();
            this.st_1 = new Label();
            
            this.MaximizeBox = false;
            this.Name = "w_v_expiry_search";
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "Vehicle Expiry Report";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(405, 165);
            // 
            // st_label
            // 
            st_label.BackColor = System.Drawing.SystemColors.Control;
            st_label.Text = "RDRPTVES";
            st_label.Location = new System.Drawing.Point(7, 114);
            // 
            // dw_criteria
            // 
            //!dw_criteria.DataObject = new DVehicleExpCriteria();
            dw_criteria.TabIndex = 4;
            dw_criteria.Size = new System.Drawing.Size(274, 81);
            dw_criteria.Location = new System.Drawing.Point(38, 20);
            //dw_criteria.Constructor += new UserEventDelegate(dw_criteria_constructor);
            // 
            // dw_results
            // 
            //!dw_results.DataObject = new DReportGenericResults();
            dw_results.Tag = "ComponentName=Disabled;";
            dw_results.Visible = false;
            dw_results.TabIndex = 6;
            dw_results.Location = new System.Drawing.Point(3, 79);
            dw_results.Size = new System.Drawing.Size(293, 259);
            // 
            // pb_search
            // 
            pb_search.Tag = "ComponentName=Disabled;";
            pb_search.Visible = false;
            pb_search.Location = new System.Drawing.Point(300, 93);
            // 
            // pb_open
            // 
            this.AcceptButton = pb_open;
            pb_open.TabIndex = 5;
            pb_open.Location = new System.Drawing.Point(330, 7);
            // 
            // rb_region
            // 
            rb_region.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_region.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_region.Checked = true;
            rb_region.Tag = "Region selector";
            rb_region.TabIndex = 1;
            rb_region.Location = new System.Drawing.Point(19, 42);
            rb_region.Size = new System.Drawing.Size(12, 19);
            rb_region.Click += new EventHandler(rb_region_clicked);
            // 
            // rb_renewal
            // 
            rb_renewal.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_renewal.BackColor = System.Drawing.SystemColors.Control;
            rb_renewal.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_renewal.Tag = "renewal selector";
            rb_renewal.TabIndex = 3;
            rb_renewal.Location = new System.Drawing.Point(19, 68);
            rb_renewal.Size = new System.Drawing.Size(15, 17);
            rb_renewal.Click += new EventHandler(rb_renewal_clicked);
            // 
            // st_1
            // 
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_1.BackColor = System.Drawing.SystemColors.Control;
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.TabStop = false;
            st_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            st_1.Location = new System.Drawing.Point(7, 7);
            st_1.Size = new System.Drawing.Size(313, 100);
            Controls.Add(rb_region);
            Controls.Add(rb_renewal);
            Controls.Add(st_1);
            this.ResumeLayout();
        }

        #endregion
    }
}