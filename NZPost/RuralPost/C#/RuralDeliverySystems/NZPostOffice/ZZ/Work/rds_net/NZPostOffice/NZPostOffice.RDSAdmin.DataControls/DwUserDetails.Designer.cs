using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;
using NZPostOffice.Shared;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DwUserDetails
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

		private Metex.Windows.DataEntityCombo   rds_user_region_id;
		private System.Windows.Forms.Label   rds_user_u_location_t;
		private System.Windows.Forms.TextBox   rds_user_u_location;
		private System.Windows.Forms.Label   rds_user_region_id_t;
		private System.Windows.Forms.Label   rds_user_u_mobile_t;
		private System.Windows.Forms.TextBox   rds_user_u_mobile;
		private System.Windows.Forms.Label   rds_user_id_ui_password_t;
		private System.Windows.Forms.Label   rds_user_id_ui_userid_t;
		private System.Windows.Forms.TextBox   rds_user_id_ui_password;
		private System.Windows.Forms.TextBox   rds_user_u_name;
		private System.Windows.Forms.TextBox   rds_user_u_phone;
		private System.Windows.Forms.Label   rds_user_u_phone_t;
		private System.Windows.Forms.TextBox   rds_user_id_ui_userid;
		private System.Windows.Forms.Label   rds_user_u_name_t;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
            this.rds_user_region_id_t = new System.Windows.Forms.Label();
            this.rds_user_u_mobile_t = new System.Windows.Forms.Label();
            this.rds_user_region_id = new Metex.Windows.DataEntityCombo();
            this.rds_user_u_mobile = new System.Windows.Forms.TextBox();
            this.rds_user_u_name_t = new System.Windows.Forms.Label();
            this.rds_user_u_name = new System.Windows.Forms.TextBox();
            this.rds_user_id_ui_userid_t = new System.Windows.Forms.Label();
            this.rds_user_id_ui_userid = new System.Windows.Forms.TextBox();
            this.rds_user_id_ui_password_t = new System.Windows.Forms.Label();
            this.rds_user_id_ui_password = new System.Windows.Forms.TextBox();
            this.rds_user_u_location_t = new System.Windows.Forms.Label();
            this.rds_user_u_location = new System.Windows.Forms.TextBox();
            this.rds_user_u_phone_t = new System.Windows.Forms.Label();
            this.rds_user_u_phone = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.UserDetails);
            // 
            // rds_user_region_id_t
            // 
            this.rds_user_region_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rds_user_region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_region_id_t.ForeColor = System.Drawing.Color.Black;
            this.rds_user_region_id_t.Location = new System.Drawing.Point(1, 63);
            this.rds_user_region_id_t.Name = "rds_user_region_id_t";
            this.rds_user_region_id_t.Size = new System.Drawing.Size(83, 13);
            this.rds_user_region_id_t.TabIndex = 0;
            this.rds_user_region_id_t.Text = "Default Region:";
            this.rds_user_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rds_user_u_mobile_t
            // 
            this.rds_user_u_mobile_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rds_user_u_mobile_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_u_mobile_t.ForeColor = System.Drawing.Color.Black;
            this.rds_user_u_mobile_t.Location = new System.Drawing.Point(1, 157);
            this.rds_user_u_mobile_t.Name = "rds_user_u_mobile_t";
            this.rds_user_u_mobile_t.Size = new System.Drawing.Size(48, 13);
            this.rds_user_u_mobile_t.TabIndex = 1;
            this.rds_user_u_mobile_t.Text = "Mobile:";
            this.rds_user_u_mobile_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rds_user_region_id
            // 
            this.rds_user_region_id.AutoRetrieve = true;
            this.rds_user_region_id.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.rds_user_region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RdsUserRegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rds_user_region_id.DisplayMember = "RgnName";
            this.rds_user_region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rds_user_region_id.DropDownWidth = 125;
            this.rds_user_region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_region_id.ForeColor = System.Drawing.Color.Black;
            this.rds_user_region_id.Location = new System.Drawing.Point(89, 63);
            this.rds_user_region_id.Name = "rds_user_region_id";
            this.rds_user_region_id.Size = new System.Drawing.Size(125, 21);
            this.rds_user_region_id.TabIndex = 40;
            this.rds_user_region_id.Value = null;
            this.rds_user_region_id.ValueMember = "RegionId";
            // 
            // rds_user_u_mobile
            // 
            this.rds_user_u_mobile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.rds_user_u_mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RdsUserUMobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rds_user_u_mobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_u_mobile.ForeColor = System.Drawing.Color.Black;
            this.rds_user_u_mobile.Location = new System.Drawing.Point(89, 157);
            this.rds_user_u_mobile.MaxLength = 25;
            this.rds_user_u_mobile.Name = "rds_user_u_mobile";
            this.rds_user_u_mobile.Size = new System.Drawing.Size(125, 20);
            this.rds_user_u_mobile.TabIndex = 70;
            // 
            // rds_user_u_name_t
            // 
            this.rds_user_u_name_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rds_user_u_name_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_u_name_t.ForeColor = System.Drawing.Color.Black;
            this.rds_user_u_name_t.Location = new System.Drawing.Point(1, 3);
            this.rds_user_u_name_t.Name = "rds_user_u_name_t";
            this.rds_user_u_name_t.Size = new System.Drawing.Size(42, 13);
            this.rds_user_u_name_t.TabIndex = 71;
            this.rds_user_u_name_t.Text = "Name:";
            this.rds_user_u_name_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rds_user_u_name
            // 
            this.rds_user_u_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.rds_user_u_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RdsUserUName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rds_user_u_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_u_name.ForeColor = System.Drawing.Color.Black;
            this.rds_user_u_name.Location = new System.Drawing.Point(89, 3);
            this.rds_user_u_name.MaxLength = 50;
            this.rds_user_u_name.Name = "rds_user_u_name";
            this.rds_user_u_name.Size = new System.Drawing.Size(125, 20);
            this.rds_user_u_name.TabIndex = 10;
            // 
            // rds_user_id_ui_userid_t
            // 
            this.rds_user_id_ui_userid_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rds_user_id_ui_userid_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_id_ui_userid_t.ForeColor = System.Drawing.Color.Black;
            this.rds_user_id_ui_userid_t.Location = new System.Drawing.Point(1, 23);
            this.rds_user_id_ui_userid_t.Name = "rds_user_id_ui_userid_t";
            this.rds_user_id_ui_userid_t.Size = new System.Drawing.Size(53, 13);
            this.rds_user_id_ui_userid_t.TabIndex = 72;
            this.rds_user_id_ui_userid_t.Text = "User ID:";
            this.rds_user_id_ui_userid_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rds_user_id_ui_userid
            // 
            this.rds_user_id_ui_userid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.rds_user_id_ui_userid.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RdsUserIdUiUserid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rds_user_id_ui_userid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_id_ui_userid.ForeColor = System.Drawing.Color.Black;
            this.rds_user_id_ui_userid.Location = new System.Drawing.Point(89, 23);
            this.rds_user_id_ui_userid.MaxLength = 20;
            this.rds_user_id_ui_userid.Name = "rds_user_id_ui_userid";
            this.rds_user_id_ui_userid.Size = new System.Drawing.Size(125, 20);
            this.rds_user_id_ui_userid.TabIndex = 20;
            // 
            // rds_user_id_ui_password_t
            // 
            this.rds_user_id_ui_password_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rds_user_id_ui_password_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_id_ui_password_t.ForeColor = System.Drawing.Color.Black;
            this.rds_user_id_ui_password_t.Location = new System.Drawing.Point(1, 43);
            this.rds_user_id_ui_password_t.Name = "rds_user_id_ui_password_t";
            this.rds_user_id_ui_password_t.Size = new System.Drawing.Size(68, 13);
            this.rds_user_id_ui_password_t.TabIndex = 73;
            this.rds_user_id_ui_password_t.Text = "Password:";
            this.rds_user_id_ui_password_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rds_user_id_ui_password
            // 
            this.rds_user_id_ui_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.rds_user_id_ui_password.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RdsUserIdUiPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rds_user_id_ui_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_id_ui_password.ForeColor = System.Drawing.Color.Black;
            this.rds_user_id_ui_password.Location = new System.Drawing.Point(89, 43);
            this.rds_user_id_ui_password.MaxLength = 0;
            this.rds_user_id_ui_password.Name = "rds_user_id_ui_password";
            this.rds_user_id_ui_password.PasswordChar = '*';
            this.rds_user_id_ui_password.Size = new System.Drawing.Size(125, 20);
            this.rds_user_id_ui_password.TabIndex = 30;
            this.rds_user_id_ui_password.KeyDown += new KeyEventHandler(rds_user_id_ui_password_KeyDown);
            this.rds_user_id_ui_password.MouseDoubleClick += new MouseEventHandler(rds_user_id_ui_password_MouseDoubleClick);
            // 
            // rds_user_u_location_t
            // 
            this.rds_user_u_location_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rds_user_u_location_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_u_location_t.ForeColor = System.Drawing.Color.Black;
            this.rds_user_u_location_t.Location = new System.Drawing.Point(1, 82);
            this.rds_user_u_location_t.Name = "rds_user_u_location_t";
            this.rds_user_u_location_t.Size = new System.Drawing.Size(59, 13);
            this.rds_user_u_location_t.TabIndex = 74;
            this.rds_user_u_location_t.Text = "Location:";
            this.rds_user_u_location_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rds_user_u_location
            // 
            this.rds_user_u_location.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.rds_user_u_location.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RdsUserULocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rds_user_u_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_u_location.ForeColor = System.Drawing.Color.Black;
            this.rds_user_u_location.Location = new System.Drawing.Point(89, 85);
            this.rds_user_u_location.MaxLength = 255;
            this.rds_user_u_location.Multiline = true;
            this.rds_user_u_location.Name = "rds_user_u_location";
            this.rds_user_u_location.Size = new System.Drawing.Size(125, 48);
            this.rds_user_u_location.TabIndex = 50;
            // 
            // rds_user_u_phone_t
            // 
            this.rds_user_u_phone_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rds_user_u_phone_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_u_phone_t.ForeColor = System.Drawing.Color.Black;
            this.rds_user_u_phone_t.Location = new System.Drawing.Point(1, 137);
            this.rds_user_u_phone_t.Name = "rds_user_u_phone_t";
            this.rds_user_u_phone_t.Size = new System.Drawing.Size(45, 13);
            this.rds_user_u_phone_t.TabIndex = 75;
            this.rds_user_u_phone_t.Text = "Phone:";
            this.rds_user_u_phone_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rds_user_u_phone
            // 
            this.rds_user_u_phone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.rds_user_u_phone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RdsUserUPhone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rds_user_u_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rds_user_u_phone.ForeColor = System.Drawing.Color.Black;
            this.rds_user_u_phone.Location = new System.Drawing.Point(89, 137);
            this.rds_user_u_phone.MaxLength = 25;
            this.rds_user_u_phone.Name = "rds_user_u_phone";
            this.rds_user_u_phone.Size = new System.Drawing.Size(125, 20);
            this.rds_user_u_phone.TabIndex = 60;
            // 
            // DwUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.rds_user_region_id_t);
            this.Controls.Add(this.rds_user_u_mobile_t);
            this.Controls.Add(this.rds_user_region_id);
            this.Controls.Add(this.rds_user_u_mobile);
            this.Controls.Add(this.rds_user_u_name_t);
            this.Controls.Add(this.rds_user_u_name);
            this.Controls.Add(this.rds_user_id_ui_userid_t);
            this.Controls.Add(this.rds_user_id_ui_userid);
            this.Controls.Add(this.rds_user_id_ui_password_t);
            this.Controls.Add(this.rds_user_id_ui_password);
            this.Controls.Add(this.rds_user_u_location_t);
            this.Controls.Add(this.rds_user_u_location);
            this.Controls.Add(this.rds_user_u_phone_t);
            this.Controls.Add(this.rds_user_u_phone);
            this.Name = "DwUserDetails";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        void rds_user_id_ui_password_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys.Shift & e.Modifiers) > 0 && (Keys.Control & e.Modifiers) > 0)
                keyPress = true;
            else
                keyPress = false;
        }
 

        void rds_user_id_ui_password_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && keyPress )
            {
                MessageBox.Show(StaticFunctions.f_decrypt(rds_user_id_ui_password.Text), "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    keyPress = false;
            }
        }
		#endregion
        private bool keyPress = false;

	}
}
