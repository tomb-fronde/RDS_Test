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
        private System.Windows.Forms.Label mobile2_t;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.TextBox first_names;
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.TextBox phone_day;
        private System.Windows.Forms.TextBox phone_night;
        private System.Windows.Forms.TextBox mobile;
        private System.Windows.Forms.TextBox mobile2;

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
            this.phone_night_t = new System.Windows.Forms.Label();
            this.mobile_t = new System.Windows.Forms.Label();
            this.mobile2_t = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.TextBox();
            this.first_names = new System.Windows.Forms.TextBox();
            this.surname = new System.Windows.Forms.TextBox();
            this.phone_day = new System.Windows.Forms.TextBox();
            this.phone_night = new System.Windows.Forms.TextBox();
            this.mobile = new System.Windows.Forms.TextBox();
            this.mobile2 = new System.Windows.Forms.TextBox();
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
            this.title_t.Location = new System.Drawing.Point(19, 2);
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
            this.first_names_t.Location = new System.Drawing.Point(84, 2);
            this.first_names_t.Name = "first_names_t";
            this.first_names_t.Size = new System.Drawing.Size(95, 14);
            this.first_names_t.TabIndex = 0;
            this.first_names_t.Text = "First names";
            this.first_names_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // surname_t
            // 
            this.surname_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.surname_t.Font = new System.Drawing.Font("Arial", 8F);
            this.surname_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.surname_t.Location = new System.Drawing.Point(320, 2);
            this.surname_t.Name = "surname_t";
            this.surname_t.Size = new System.Drawing.Size(96, 14);
            this.surname_t.TabIndex = 0;
            this.surname_t.Text = "Surname";
            this.surname_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phone_day_t
            // 
            this.phone_day_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.phone_day_t.Font = new System.Drawing.Font("Arial", 8F);
            this.phone_day_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.phone_day_t.Location = new System.Drawing.Point(3, 54);
            this.phone_day_t.Name = "phone_day_t";
            this.phone_day_t.Size = new System.Drawing.Size(75, 14);
            this.phone_day_t.TabIndex = 0;
            this.phone_day_t.Text = "Phone:   Day";
            this.phone_day_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phone_night_t
            // 
            this.phone_night_t.AutoSize = true;
            this.phone_night_t.Location = new System.Drawing.Point(185, 52);
            this.phone_night_t.Name = "phone_night_t";
            this.phone_night_t.Size = new System.Drawing.Size(32, 13);
            this.phone_night_t.TabIndex = 0;
            this.phone_night_t.Text = "Night";
            // 
            // mobile_t
            // 
            this.mobile_t.AutoSize = true;
            this.mobile_t.Location = new System.Drawing.Point(329, 50);
            this.mobile_t.Name = "mobile_t";
            this.mobile_t.Size = new System.Drawing.Size(38, 13);
            this.mobile_t.TabIndex = 0;
            this.mobile_t.Text = "Mobile";
            this.mobile_t.UseWaitCursor = true;
            // 
            // mobile2_t
            // 
            this.mobile2_t.AutoSize = true;
            this.mobile2_t.Location = new System.Drawing.Point(476, 50);
            this.mobile2_t.Name = "mobile2_t";
            this.mobile2_t.Size = new System.Drawing.Size(44, 13);
            this.mobile2_t.TabIndex = 0;
            this.mobile2_t.Text = "Mobile2";
            this.mobile2_t.UseWaitCursor = true;
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.White;
            this.title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.title.Font = new System.Drawing.Font("Arial", 8F);
            this.title.ForeColor = System.Drawing.SystemColors.WindowText;
            this.title.Location = new System.Drawing.Point(19, 19);
            this.title.MaxLength = 0;
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(59, 20);
            this.title.TabIndex = 5;
            // 
            // first_names
            // 
            this.first_names.BackColor = System.Drawing.Color.White;
            this.first_names.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DFirstNames", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.first_names.Font = new System.Drawing.Font("Arial", 8F);
            this.first_names.ForeColor = System.Drawing.SystemColors.WindowText;
            this.first_names.Location = new System.Drawing.Point(84, 19);
            this.first_names.MaxLength = 30;
            this.first_names.Name = "first_names";
            this.first_names.Size = new System.Drawing.Size(230, 20);
            this.first_names.TabIndex = 10;
            // 
            // surname
            // 
            this.surname.BackColor = System.Drawing.Color.White;
            this.surname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DSurname", true));
            this.surname.Font = new System.Drawing.Font("Arial", 8F);
            this.surname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.surname.Location = new System.Drawing.Point(320, 19);
            this.surname.MaxLength = 45;
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(296, 20);
            this.surname.TabIndex = 15;
            // 
            // phone_day
            // 
            this.phone_day.BackColor = System.Drawing.Color.White;
            this.phone_day.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DPhoneDay", true));
            this.phone_day.Font = new System.Drawing.Font("Arial", 8F);
            this.phone_day.ForeColor = System.Drawing.SystemColors.WindowText;
            this.phone_day.Location = new System.Drawing.Point(80, 49);
            this.phone_day.MaxLength = 0;
            this.phone_day.Name = "phone_day";
            this.phone_day.Size = new System.Drawing.Size(95, 20);
            this.phone_day.TabIndex = 20;
            // 
            // phone_night
            // 
            this.phone_night.BackColor = System.Drawing.Color.White;
            this.phone_night.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DPhoneNight", true));
            this.phone_night.Font = new System.Drawing.Font("Arial", 8F);
            this.phone_night.ForeColor = System.Drawing.SystemColors.WindowText;
            this.phone_night.Location = new System.Drawing.Point(220, 47);
            this.phone_night.MaxLength = 0;
            this.phone_night.Name = "phone_night";
            this.phone_night.Size = new System.Drawing.Size(99, 20);
            this.phone_night.TabIndex = 25;
            // 
            // mobile
            // 
            this.mobile.BackColor = System.Drawing.Color.White;
            this.mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DMobile", true));
            this.mobile.Font = new System.Drawing.Font("Arial", 8F);
            this.mobile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mobile.Location = new System.Drawing.Point(371, 47);
            this.mobile.MaxLength = 0;
            this.mobile.Name = "mobile";
            this.mobile.Size = new System.Drawing.Size(94, 20);
            this.mobile.TabIndex = 30;
            // 
            // mobile2
            // 
            this.mobile2.BackColor = System.Drawing.Color.White;
            this.mobile2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DMobile2", true));
            this.mobile2.Font = new System.Drawing.Font("Arial", 8F);
            this.mobile2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mobile2.Location = new System.Drawing.Point(522, 48);
            this.mobile2.MaxLength = 0;
            this.mobile2.Name = "mobile2";
            this.mobile2.Size = new System.Drawing.Size(94, 20);
            this.mobile2.TabIndex = 35;
            // 
            // DDriverInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.title_t);
            this.Controls.Add(this.first_names_t);
            this.Controls.Add(this.surname_t);
            this.Controls.Add(this.phone_day_t);
            this.Controls.Add(this.phone_night_t);
            this.Controls.Add(this.mobile_t);
            this.Controls.Add(this.mobile2_t);
            this.Controls.Add(this.title);
            this.Controls.Add(this.first_names);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.phone_day);
            this.Controls.Add(this.phone_night);
            this.Controls.Add(this.mobile);
            this.Controls.Add(this.mobile2);
            this.Name = "DDriverInfo";
            this.Size = new System.Drawing.Size(650, 79);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion



    }
}
