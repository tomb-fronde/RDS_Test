using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DUiIdDetails
	{

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private System.Windows.Forms.TextBox   ui_last_login_date;
		private System.Windows.Forms.Label   ui_grace_logins_t;
		private System.Windows.Forms.Label   ui_modified_date_t;
		private System.Windows.Forms.Label   ui_last_login_date_t;
		private System.Windows.Forms.TextBox   ui_created_by;
		private System.Windows.Forms.TextBox   ui_last_login_time;
		private System.Windows.Forms.Label   ui_password_expiry_t;
		private System.Windows.Forms.Label   ui_locked_date_t;
		private System.Windows.Forms.TextBox   ui_modified_by;
		private System.Windows.Forms.Label   ui_last_login_time_t;
		private System.Windows.Forms.TextBox   ui_modified_date;
		private System.Windows.Forms.Label   ui_created_date_t;
		private System.Windows.Forms.TextBox   ui_password_expiry;
		private System.Windows.Forms.TextBox   ui_grace_logins;
		private System.Windows.Forms.TextBox   ui_created_date;
		private System.Windows.Forms.Label   ui_modified_by_t;
		private System.Windows.Forms.Label   ui_created_by_t;
		private System.Windows.Forms.TextBox   ui_locked_date;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
            this.ui_last_login_date_t = new System.Windows.Forms.Label();
            this.ui_last_login_date = new System.Windows.Forms.TextBox();
            this.ui_last_login_time_t = new System.Windows.Forms.Label();
            this.ui_last_login_time = new System.Windows.Forms.TextBox();
            this.ui_created_date_t = new System.Windows.Forms.Label();
            this.ui_created_date = new System.Windows.Forms.TextBox();
            this.ui_created_by_t = new System.Windows.Forms.Label();
            this.ui_created_by = new System.Windows.Forms.TextBox();
            this.ui_modified_date_t = new System.Windows.Forms.Label();
            this.ui_modified_date = new System.Windows.Forms.TextBox();
            this.ui_modified_by_t = new System.Windows.Forms.Label();
            this.ui_modified_by = new System.Windows.Forms.TextBox();
            this.ui_password_expiry_t = new System.Windows.Forms.Label();
            this.ui_password_expiry = new System.Windows.Forms.TextBox();
            this.ui_grace_logins_t = new System.Windows.Forms.Label();
            this.ui_grace_logins = new System.Windows.Forms.TextBox();
            this.ui_locked_date_t = new System.Windows.Forms.Label();
            this.ui_locked_date = new System.Windows.Forms.TextBox();
            this.unlock_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.UiIdDetails);
            // 
            // ui_last_login_date_t
            // 
            this.ui_last_login_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ui_last_login_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_last_login_date_t.ForeColor = System.Drawing.Color.Black;
            this.ui_last_login_date_t.Location = new System.Drawing.Point(1, 4);
            this.ui_last_login_date_t.Name = "ui_last_login_date_t";
            this.ui_last_login_date_t.Size = new System.Drawing.Size(87, 13);
            this.ui_last_login_date_t.TabIndex = 0;
            this.ui_last_login_date_t.Text = "Last Login Date:";
            this.ui_last_login_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_last_login_date
            // 
            this.ui_last_login_date.BackColor = System.Drawing.SystemColors.Control;
            this.ui_last_login_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "UiLastLoginDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ui_last_login_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_last_login_date.ForeColor = System.Drawing.Color.Black;
            this.ui_last_login_date.Location = new System.Drawing.Point(89, 4);
            this.ui_last_login_date.MaxLength = 0;
            this.ui_last_login_date.Name = "ui_last_login_date";
            this.ui_last_login_date.ReadOnly = true;
            this.ui_last_login_date.Size = new System.Drawing.Size(72, 20);
            this.ui_last_login_date.TabIndex = 1;
            // 
            // ui_last_login_time_t
            // 
            this.ui_last_login_time_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ui_last_login_time_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_last_login_time_t.ForeColor = System.Drawing.Color.Black;
            this.ui_last_login_time_t.Location = new System.Drawing.Point(1, 24);
            this.ui_last_login_time_t.Name = "ui_last_login_time_t";
            this.ui_last_login_time_t.Size = new System.Drawing.Size(87, 13);
            this.ui_last_login_time_t.TabIndex = 2;
            this.ui_last_login_time_t.Text = "Last Login Time:";
            this.ui_last_login_time_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_last_login_time
            // 
            this.ui_last_login_time.BackColor = System.Drawing.SystemColors.Control;
            this.ui_last_login_time.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "UiLastLoginTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ui_last_login_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_last_login_time.ForeColor = System.Drawing.Color.Black;
            this.ui_last_login_time.Location = new System.Drawing.Point(89, 24);
            this.ui_last_login_time.MaxLength = 0;
            this.ui_last_login_time.Name = "ui_last_login_time";
            this.ui_last_login_time.ReadOnly = true;
            this.ui_last_login_time.Size = new System.Drawing.Size(72, 20);
            this.ui_last_login_time.TabIndex = 3;
            // 
            // ui_created_date_t
            // 
            this.ui_created_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ui_created_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_created_date_t.ForeColor = System.Drawing.Color.Black;
            this.ui_created_date_t.Location = new System.Drawing.Point(1, 44);
            this.ui_created_date_t.Name = "ui_created_date_t";
            this.ui_created_date_t.Size = new System.Drawing.Size(75, 13);
            this.ui_created_date_t.TabIndex = 4;
            this.ui_created_date_t.Text = "Created Date:";
            this.ui_created_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_created_date
            // 
            this.ui_created_date.BackColor = System.Drawing.SystemColors.Control;
            this.ui_created_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "UiCreatedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ui_created_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_created_date.ForeColor = System.Drawing.Color.Black;
            this.ui_created_date.Location = new System.Drawing.Point(89, 44);
            this.ui_created_date.MaxLength = 0;
            this.ui_created_date.Name = "ui_created_date";
            this.ui_created_date.ReadOnly = true;
            this.ui_created_date.Size = new System.Drawing.Size(72, 20);
            this.ui_created_date.TabIndex = 5;
            // 
            // ui_created_by_t
            // 
            this.ui_created_by_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ui_created_by_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_created_by_t.ForeColor = System.Drawing.Color.Black;
            this.ui_created_by_t.Location = new System.Drawing.Point(1, 64);
            this.ui_created_by_t.Name = "ui_created_by_t";
            this.ui_created_by_t.Size = new System.Drawing.Size(63, 13);
            this.ui_created_by_t.TabIndex = 6;
            this.ui_created_by_t.Text = "Created By:";
            this.ui_created_by_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_created_by
            // 
            this.ui_created_by.BackColor = System.Drawing.SystemColors.Control;
            this.ui_created_by.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "UiCreatedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ui_created_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_created_by.ForeColor = System.Drawing.Color.Black;
            this.ui_created_by.Location = new System.Drawing.Point(89, 64);
            this.ui_created_by.MaxLength = 20;
            this.ui_created_by.Name = "ui_created_by";
            this.ui_created_by.ReadOnly = true;
            this.ui_created_by.Size = new System.Drawing.Size(126, 20);
            this.ui_created_by.TabIndex = 7;
            // 
            // ui_modified_date_t
            // 
            this.ui_modified_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ui_modified_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_modified_date_t.ForeColor = System.Drawing.Color.Black;
            this.ui_modified_date_t.Location = new System.Drawing.Point(1, 84);
            this.ui_modified_date_t.Name = "ui_modified_date_t";
            this.ui_modified_date_t.Size = new System.Drawing.Size(82, 13);
            this.ui_modified_date_t.TabIndex = 8;
            this.ui_modified_date_t.Text = "Modified Date:";
            this.ui_modified_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_modified_date
            // 
            this.ui_modified_date.BackColor = System.Drawing.SystemColors.Control;
            this.ui_modified_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "UiModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ui_modified_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_modified_date.ForeColor = System.Drawing.Color.Black;
            this.ui_modified_date.Location = new System.Drawing.Point(89, 84);
            this.ui_modified_date.MaxLength = 0;
            this.ui_modified_date.Name = "ui_modified_date";
            this.ui_modified_date.ReadOnly = true;
            this.ui_modified_date.Size = new System.Drawing.Size(72, 20);
            this.ui_modified_date.TabIndex = 9;
            // 
            // ui_modified_by_t
            // 
            this.ui_modified_by_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ui_modified_by_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_modified_by_t.ForeColor = System.Drawing.Color.Black;
            this.ui_modified_by_t.Location = new System.Drawing.Point(1, 104);
            this.ui_modified_by_t.Name = "ui_modified_by_t";
            this.ui_modified_by_t.Size = new System.Drawing.Size(71, 13);
            this.ui_modified_by_t.TabIndex = 10;
            this.ui_modified_by_t.Text = "Modified By:";
            this.ui_modified_by_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_modified_by
            // 
            this.ui_modified_by.BackColor = System.Drawing.SystemColors.Control;
            this.ui_modified_by.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "UiModifiedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ui_modified_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_modified_by.ForeColor = System.Drawing.Color.Black;
            this.ui_modified_by.Location = new System.Drawing.Point(89, 104);
            this.ui_modified_by.MaxLength = 20;
            this.ui_modified_by.Name = "ui_modified_by";
            this.ui_modified_by.ReadOnly = true;
            this.ui_modified_by.Size = new System.Drawing.Size(126, 20);
            this.ui_modified_by.TabIndex = 11;
            // 
            // ui_password_expiry_t
            // 
            this.ui_password_expiry_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ui_password_expiry_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_password_expiry_t.ForeColor = System.Drawing.Color.Black;
            this.ui_password_expiry_t.Location = new System.Drawing.Point(1, 124);
            this.ui_password_expiry_t.Name = "ui_password_expiry_t";
            this.ui_password_expiry_t.Size = new System.Drawing.Size(87, 13);
            this.ui_password_expiry_t.TabIndex = 12;
            this.ui_password_expiry_t.Text = "Password Expiry:";
            this.ui_password_expiry_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_password_expiry
            // 
            this.ui_password_expiry.BackColor = System.Drawing.SystemColors.Control;
            this.ui_password_expiry.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "UiPasswordExpiry", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ui_password_expiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_password_expiry.ForeColor = System.Drawing.Color.Black;
            this.ui_password_expiry.Location = new System.Drawing.Point(89, 124);
            this.ui_password_expiry.MaxLength = 0;
            this.ui_password_expiry.Name = "ui_password_expiry";
            this.ui_password_expiry.ReadOnly = true;
            this.ui_password_expiry.Size = new System.Drawing.Size(72, 20);
            this.ui_password_expiry.TabIndex = 13;
            // 
            // ui_grace_logins_t
            // 
            this.ui_grace_logins_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ui_grace_logins_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_grace_logins_t.ForeColor = System.Drawing.Color.Black;
            this.ui_grace_logins_t.Location = new System.Drawing.Point(1, 144);
            this.ui_grace_logins_t.Name = "ui_grace_logins_t";
            this.ui_grace_logins_t.Size = new System.Drawing.Size(75, 13);
            this.ui_grace_logins_t.TabIndex = 14;
            this.ui_grace_logins_t.Text = "Grace Logins:";
            this.ui_grace_logins_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_grace_logins
            // 
            this.ui_grace_logins.BackColor = System.Drawing.SystemColors.Control;
            this.ui_grace_logins.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "UiGraceLogins", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ui_grace_logins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_grace_logins.ForeColor = System.Drawing.Color.Black;
            this.ui_grace_logins.Location = new System.Drawing.Point(89, 144);
            this.ui_grace_logins.MaxLength = 0;
            this.ui_grace_logins.Name = "ui_grace_logins";
            this.ui_grace_logins.ReadOnly = true;
            this.ui_grace_logins.Size = new System.Drawing.Size(72, 20);
            this.ui_grace_logins.TabIndex = 15;
            this.ui_grace_logins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ui_locked_date_t
            // 
            this.ui_locked_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ui_locked_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_locked_date_t.ForeColor = System.Drawing.Color.Black;
            this.ui_locked_date_t.Location = new System.Drawing.Point(1, 164);
            this.ui_locked_date_t.Name = "ui_locked_date_t";
            this.ui_locked_date_t.Size = new System.Drawing.Size(75, 13);
            this.ui_locked_date_t.TabIndex = 16;
            this.ui_locked_date_t.Text = "Locked Date:";
            this.ui_locked_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_locked_date
            // 
            this.ui_locked_date.BackColor = System.Drawing.SystemColors.Control;
            this.ui_locked_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "UiLockedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ui_locked_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ui_locked_date.ForeColor = System.Drawing.Color.Black;
            this.ui_locked_date.Location = new System.Drawing.Point(89, 164);
            this.ui_locked_date.MaxLength = 0;
            this.ui_locked_date.Name = "ui_locked_date";
            this.ui_locked_date.ReadOnly = true;
            this.ui_locked_date.Size = new System.Drawing.Size(72, 20);
            this.ui_locked_date.TabIndex = 17;
            // 
            // unlock_button
            // 
            this.unlock_button.Location = new System.Drawing.Point(175, 164);
            this.unlock_button.Name = "unlock_button";
            this.unlock_button.Size = new System.Drawing.Size(54, 20);
            this.unlock_button.TabIndex = 18;
            this.unlock_button.Text = "Unlock";
            this.unlock_button.UseVisualStyleBackColor = true;
            this.unlock_button.Click += new System.EventHandler(this.unlock_button_Click);
            // 
            // DUiIdDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.unlock_button);
            this.Controls.Add(this.ui_last_login_date_t);
            this.Controls.Add(this.ui_last_login_date);
            this.Controls.Add(this.ui_last_login_time_t);
            this.Controls.Add(this.ui_last_login_time);
            this.Controls.Add(this.ui_created_date_t);
            this.Controls.Add(this.ui_created_date);
            this.Controls.Add(this.ui_created_by_t);
            this.Controls.Add(this.ui_created_by);
            this.Controls.Add(this.ui_modified_date_t);
            this.Controls.Add(this.ui_modified_date);
            this.Controls.Add(this.ui_modified_by_t);
            this.Controls.Add(this.ui_modified_by);
            this.Controls.Add(this.ui_password_expiry_t);
            this.Controls.Add(this.ui_password_expiry);
            this.Controls.Add(this.ui_grace_logins_t);
            this.Controls.Add(this.ui_grace_logins);
            this.Controls.Add(this.ui_locked_date_t);
            this.Controls.Add(this.ui_locked_date);
            this.Name = "DUiIdDetails";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private Button unlock_button;

	}
}
