using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  RPCR_060  Jan-2014: NEW
    // Datacontrol for Driver Health & Safety info

    partial class DDriverHSInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private System.Windows.Forms.Label first_names_t;
        private System.Windows.Forms.Label phone_day_t;
        private System.Windows.Forms.Label phone_night_t;
        private System.Windows.Forms.Label mobile_t;
        private System.Windows.Forms.TextBox first_names;
        private System.Windows.Forms.TextBox phone_day;
        private System.Windows.Forms.TextBox phone_night;
        private System.Windows.Forms.TextBox mobile;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
		{
            this.first_names_t = new System.Windows.Forms.Label();
            this.phone_day_t = new System.Windows.Forms.Label();
            this.first_names = new System.Windows.Forms.TextBox();
            this.phone_day = new System.Windows.Forms.TextBox();
            this.phone_night = new System.Windows.Forms.TextBox();
            this.phone_night_t = new System.Windows.Forms.Label();
            this.mobile_t = new System.Windows.Forms.Label();
            this.mobile = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.DriverHSInfo);
            // 
            // first_names_t
            // 
            this.first_names_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.first_names_t.Font = new System.Drawing.Font("Arial", 8F);
            this.first_names_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.first_names_t.Location = new System.Drawing.Point(5, 9);
            this.first_names_t.Name = "first_names_t";
            this.first_names_t.Size = new System.Drawing.Size(73, 14);
            this.first_names_t.TabIndex = 1;
            this.first_names_t.Text = "Check Type";
            this.first_names_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phone_day_t
            // 
            this.phone_day_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.phone_day_t.Font = new System.Drawing.Font("Arial", 8F);
            this.phone_day_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.phone_day_t.Location = new System.Drawing.Point(209, 12);
            this.phone_day_t.Name = "phone_day_t";
            this.phone_day_t.Size = new System.Drawing.Size(73, 14);
            this.phone_day_t.TabIndex = 3;
            this.phone_day_t.Text = "Last Checked";
            this.phone_day_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // first_names
            // 
            this.first_names.BackColor = System.Drawing.Color.White;
            this.first_names.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "HstName", true));
            this.first_names.Font = new System.Drawing.Font("Arial", 8F);
            this.first_names.ForeColor = System.Drawing.SystemColors.WindowText;
            this.first_names.Location = new System.Drawing.Point(86, 9);
            this.first_names.MaxLength = 30;
            this.first_names.Name = "first_names";
            this.first_names.Size = new System.Drawing.Size(114, 20);
            this.first_names.TabIndex = 50;
            // 
            // phone_day
            // 
            this.phone_day.BackColor = System.Drawing.Color.White;
            this.phone_day.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "HsiDateChecked", true));
            this.phone_day.Font = new System.Drawing.Font("Arial", 8F);
            this.phone_day.ForeColor = System.Drawing.SystemColors.WindowText;
            this.phone_day.Location = new System.Drawing.Point(285, 7);
            this.phone_day.MaxLength = 0;
            this.phone_day.Name = "phone_day";
            this.phone_day.Size = new System.Drawing.Size(114, 20);
            this.phone_day.TabIndex = 10;
            // 
            // phone_night
            // 
            this.phone_night.BackColor = System.Drawing.Color.White;
            this.phone_night.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "HsiPassfailInd", true));
            this.phone_night.Font = new System.Drawing.Font("Arial", 8F);
            this.phone_night.ForeColor = System.Drawing.SystemColors.WindowText;
            this.phone_night.Location = new System.Drawing.Point(462, 7);
            this.phone_night.MaxLength = 0;
            this.phone_night.Name = "phone_night";
            this.phone_night.ReadOnly = true;
            this.phone_night.Size = new System.Drawing.Size(34, 20);
            this.phone_night.TabIndex = 51;
            // 
            // phone_night_t
            // 
            this.phone_night_t.AutoSize = true;
            this.phone_night_t.Location = new System.Drawing.Point(405, 11);
            this.phone_night_t.Name = "phone_night_t";
            this.phone_night_t.Size = new System.Drawing.Size(51, 13);
            this.phone_night_t.TabIndex = 52;
            this.phone_night_t.Text = "Pass/Fail";
            // 
            // mobile_t
            // 
            this.mobile_t.AutoSize = true;
            this.mobile_t.Location = new System.Drawing.Point(43, 37);
            this.mobile_t.Name = "mobile_t";
            this.mobile_t.Size = new System.Drawing.Size(35, 13);
            this.mobile_t.TabIndex = 53;
            this.mobile_t.Text = "Notes";
            this.mobile_t.UseWaitCursor = true;
            // 
            // mobile
            // 
            this.mobile.AcceptsReturn = true;
            this.mobile.BackColor = System.Drawing.Color.White;
            this.mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "HsiNotes", true));
            this.mobile.Font = new System.Drawing.Font("Arial", 8F);
            this.mobile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mobile.Location = new System.Drawing.Point(86, 33);
            this.mobile.MaxLength = 0;
            this.mobile.Multiline = true;
            this.mobile.Name = "mobile";
            this.mobile.Size = new System.Drawing.Size(410, 67);
            this.mobile.TabIndex = 54;
            // 
            // DDriverHSInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.mobile);
            this.Controls.Add(this.mobile_t);
            this.Controls.Add(this.phone_night_t);
            this.Controls.Add(this.first_names_t);
            this.Controls.Add(this.phone_day_t);
            this.Controls.Add(this.first_names);
            this.Controls.Add(this.phone_day);
            this.Controls.Add(this.phone_night);
            this.Name = "DDriverHSInfo";
            this.Size = new System.Drawing.Size(574, 110);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion


    }
}
