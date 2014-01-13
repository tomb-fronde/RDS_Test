using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  RPCR_060  Jan-2014: NEW
    // Datacontrol for Driver 'personal' info

    partial class DDriverInfo
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

        private System.Windows.Forms.Label title_t;
        private System.Windows.Forms.Label first_names_t;
        private System.Windows.Forms.Label surname_t;
        private System.Windows.Forms.Label phone_day_t;
        private System.Windows.Forms.Label phone_night_t;
        private System.Windows.Forms.Label mobile_t;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.TextBox first_names;
        private System.Windows.Forms.TextBox surname;
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
            this.title_t = new System.Windows.Forms.Label();
            this.first_names_t = new System.Windows.Forms.Label();
            this.surname_t = new System.Windows.Forms.Label();
            this.phone_day_t = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.TextBox();
            this.first_names = new System.Windows.Forms.TextBox();
            this.surname = new System.Windows.Forms.TextBox();
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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.DriverInfo);
            // 
            // title_t
            // 
            this.title_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.title_t.Font = new System.Drawing.Font("Arial", 8F);
            this.title_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.title_t.Location = new System.Drawing.Point(50, 28);
            this.title_t.Name = "title_t";
            this.title_t.Size = new System.Drawing.Size(59, 14);
            this.title_t.TabIndex = 0;
            this.title_t.Text = "Title";
            this.title_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // first_names_t
            // 
            this.first_names_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.first_names_t.Font = new System.Drawing.Font("Arial", 8F);
            this.first_names_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.first_names_t.Location = new System.Drawing.Point(115, 28);
            this.first_names_t.Name = "first_names_t";
            this.first_names_t.Size = new System.Drawing.Size(95, 14);
            this.first_names_t.TabIndex = 1;
            this.first_names_t.Text = "First names";
            this.first_names_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // surname_t
            // 
            this.surname_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.surname_t.Font = new System.Drawing.Font("Arial", 8F);
            this.surname_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.surname_t.Location = new System.Drawing.Point(351, 28);
            this.surname_t.Name = "surname_t";
            this.surname_t.Size = new System.Drawing.Size(96, 14);
            this.surname_t.TabIndex = 2;
            this.surname_t.Text = "Surname";
            this.surname_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phone_day_t
            // 
            this.phone_day_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.phone_day_t.Font = new System.Drawing.Font("Arial", 8F);
            this.phone_day_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.phone_day_t.Location = new System.Drawing.Point(36, 80);
            this.phone_day_t.Name = "phone_day_t";
            this.phone_day_t.Size = new System.Drawing.Size(73, 14);
            this.phone_day_t.TabIndex = 3;
            this.phone_day_t.Text = "Phone - day";
            this.phone_day_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.White;
            this.title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.title.Font = new System.Drawing.Font("Arial", 8F);
            this.title.ForeColor = System.Drawing.SystemColors.WindowText;
            this.title.Location = new System.Drawing.Point(50, 45);
            this.title.MaxLength = 0;
            this.title.Name = "title";
            this.title.ReadOnly = true;
            this.title.Size = new System.Drawing.Size(59, 20);
            this.title.TabIndex = 5;
            // 
            // first_names
            // 
            this.first_names.BackColor = System.Drawing.Color.White;
            this.first_names.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DFirstNames", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.first_names.Font = new System.Drawing.Font("Arial", 8F);
            this.first_names.ForeColor = System.Drawing.SystemColors.WindowText;
            this.first_names.Location = new System.Drawing.Point(115, 45);
            this.first_names.MaxLength = 30;
            this.first_names.Name = "first_names";
            this.first_names.Size = new System.Drawing.Size(230, 20);
            this.first_names.TabIndex = 50;
            // 
            // surname
            // 
            this.surname.BackColor = System.Drawing.Color.White;
            this.surname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DSurname", true));
            this.surname.Font = new System.Drawing.Font("Arial", 8F);
            this.surname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.surname.Location = new System.Drawing.Point(351, 45);
            this.surname.MaxLength = 45;
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(230, 20);
            this.surname.TabIndex = 40;
            // 
            // phone_day
            // 
            this.phone_day.BackColor = System.Drawing.Color.White;
            this.phone_day.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DPhoneDay", true));
            this.phone_day.Font = new System.Drawing.Font("Arial", 8F);
            this.phone_day.ForeColor = System.Drawing.SystemColors.WindowText;
            this.phone_day.Location = new System.Drawing.Point(115, 75);
            this.phone_day.MaxLength = 0;
            this.phone_day.Name = "phone_day";
            this.phone_day.Size = new System.Drawing.Size(114, 20);
            this.phone_day.TabIndex = 10;
            // 
            // phone_night
            // 
            this.phone_night.BackColor = System.Drawing.Color.White;
            this.phone_night.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DPhoneNight", true));
            this.phone_night.Font = new System.Drawing.Font("Arial", 8F);
            this.phone_night.ForeColor = System.Drawing.SystemColors.WindowText;
            this.phone_night.Location = new System.Drawing.Point(311, 73);
            this.phone_night.MaxLength = 0;
            this.phone_night.Name = "phone_night";
            this.phone_night.ReadOnly = true;
            this.phone_night.Size = new System.Drawing.Size(118, 20);
            this.phone_night.TabIndex = 51;
            // 
            // phone_night_t
            // 
            this.phone_night_t.AutoSize = true;
            this.phone_night_t.Location = new System.Drawing.Point(235, 78);
            this.phone_night_t.Name = "phone_night_t";
            this.phone_night_t.Size = new System.Drawing.Size(70, 13);
            this.phone_night_t.TabIndex = 52;
            this.phone_night_t.Text = "Phone - night";
            // 
            // mobile_t
            // 
            this.mobile_t.AutoSize = true;
            this.mobile_t.Location = new System.Drawing.Point(69, 110);
            this.mobile_t.Name = "mobile_t";
            this.mobile_t.Size = new System.Drawing.Size(38, 13);
            this.mobile_t.TabIndex = 53;
            this.mobile_t.Text = "Mobile";
            this.mobile_t.UseWaitCursor = true;
            // 
            // mobile
            // 
            this.mobile.BackColor = System.Drawing.Color.White;
            this.mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DMobile", true));
            this.mobile.Font = new System.Drawing.Font("Arial", 8F);
            this.mobile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mobile.Location = new System.Drawing.Point(115, 107);
            this.mobile.MaxLength = 0;
            this.mobile.Name = "mobile";
            this.mobile.Size = new System.Drawing.Size(114, 20);
            this.mobile.TabIndex = 54;
            // 
            // DDriverInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.mobile);
            this.Controls.Add(this.mobile_t);
            this.Controls.Add(this.phone_night_t);
            this.Controls.Add(this.title_t);
            this.Controls.Add(this.first_names_t);
            this.Controls.Add(this.surname_t);
            this.Controls.Add(this.phone_day_t);
            this.Controls.Add(this.title);
            this.Controls.Add(this.first_names);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.phone_day);
            this.Controls.Add(this.phone_night);
            this.Name = "DDriverInfo";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion


    }
}
