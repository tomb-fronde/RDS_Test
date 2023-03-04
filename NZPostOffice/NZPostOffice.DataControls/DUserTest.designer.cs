using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.Entity;

namespace NZPostOffice.DataControls
{
	partial class DUserTest
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

		private System.Windows.Forms.TextBox   rds_user_region_id;
		private System.Windows.Forms.Label   rds_user_u_location_t;
		private System.Windows.Forms.TextBox   rds_user_u_location;
		private System.Windows.Forms.Label   rds_user_region_id_t;
		private System.Windows.Forms.TextBox   rds_user_id_ui_grace_logins;
		private System.Windows.Forms.Label   rds_user_u_mobile_t;
		private System.Windows.Forms.TextBox   rds_user_id_ui_can_change_password;
		private System.Windows.Forms.TextBox   rds_user_id_ui_last_login_date;
		private System.Windows.Forms.TextBox   rds_user_id_ui_created_date;
		private System.Windows.Forms.Label   rds_user_id_ui_created_date_t;
		private System.Windows.Forms.Label   rds_user_id_ui_modified_date_t;
		private System.Windows.Forms.TextBox   rds_user_u_mobile;
		private System.Windows.Forms.Label   region_rgn_name_t;
		private System.Windows.Forms.Label   rds_user_id_ui_password_t;
		private System.Windows.Forms.TextBox   rds_user_id_ui_id;
		private System.Windows.Forms.Label   rds_user_id_ui_userid_t;
		private System.Windows.Forms.Label   rds_user_id_ui_created_by_t;
		private System.Windows.Forms.TextBox   rds_user_id_ui_modified_by;
		private System.Windows.Forms.TextBox   rds_user_id_ui_password;
		private System.Windows.Forms.TextBox   rds_user_u_name;
		private System.Windows.Forms.Label   rds_user_id_ui_can_change_password_t;
		private System.Windows.Forms.Label   rds_user_id_ui_last_login_date_t;
		private System.Windows.Forms.TextBox   rds_user_u_phone;
		private System.Windows.Forms.TextBox   rds_user_u_id;
		private System.Windows.Forms.Label   rds_user_id_ui_locked_date_t;
		private System.Windows.Forms.TextBox   rds_user_id_ui_last_login_time;
		private System.Windows.Forms.Label   rds_user_u_phone_t;
		private System.Windows.Forms.TextBox   rds_user_id_ui_created_by;
		private System.Windows.Forms.TextBox   rds_user_id_ui_modified_date;
		private System.Windows.Forms.Label   rds_user_id_ui_grace_logins_t;
		private System.Windows.Forms.Label   rds_user_u_id_t;
		private System.Windows.Forms.Label   rds_user_id_ui_password_expiry_t;
		private System.Windows.Forms.Label   rds_user_id_ui_modified_by_t;
		private System.Windows.Forms.TextBox   rds_user_id_ui_password_expiry;
		private System.Windows.Forms.Label   rds_user_id_ui_last_login_time_t;
		private System.Windows.Forms.TextBox   rds_user_id_ui_locked_date;
		private System.Windows.Forms.Label   rds_user_id_ui_id_t;
		private System.Windows.Forms.TextBox   rds_user_id_ui_userid;
		private System.Windows.Forms.TextBox   region_rgn_name;
		private System.Windows.Forms.Label   rds_user_u_name_t;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DUserTest";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.Entity.UserTest);
			//
			// rds_user_u_id_t
			//
			this.rds_user_u_id_t = new System.Windows.Forms.Label();
			this.rds_user_u_id_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_u_id_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_u_id_t.Location = new System.Drawing.Point(3, 6);
			this.rds_user_u_id_t.Name = "rds_user_u_id_t";
			this.rds_user_u_id_t.Size = new System.Drawing.Size(26, 14);
			this.rds_user_u_id_t.Text = "U id";
			this.rds_user_u_id_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_u_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_u_id_t);

			//
			// rds_user_u_name_t
			//
			this.rds_user_u_name_t = new System.Windows.Forms.Label();
			this.rds_user_u_name_t.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.rds_user_u_name_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_u_name_t.Location = new System.Drawing.Point(102, 5);
			this.rds_user_u_name_t.Name = "rds_user_u_name_t";
			this.rds_user_u_name_t.Size = new System.Drawing.Size(38, 15);
			this.rds_user_u_name_t.Text = "Name";
			this.rds_user_u_name_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_u_name_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_u_name_t);

			//
			// rds_user_u_location_t
			//
			this.rds_user_u_location_t = new System.Windows.Forms.Label();
			this.rds_user_u_location_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_u_location_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_u_location_t.Location = new System.Drawing.Point(207, 7);
			this.rds_user_u_location_t.Name = "rds_user_u_location_t";
			this.rds_user_u_location_t.Size = new System.Drawing.Size(23, 14);
			this.rds_user_u_location_t.Text = "Loc";
			this.rds_user_u_location_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_u_location_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_u_location_t);

			//
			// rds_user_u_id
			//
			rds_user_u_id = new System.Windows.Forms.TextBox();
			this.rds_user_u_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_u_id.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_u_id.ForeColor = System.Drawing.Color.Black;
			this.rds_user_u_id.Location = new System.Drawing.Point(3, 24);
			this.rds_user_u_id.MaxLength = 0;
			this.rds_user_u_id.Name = "rds_user_u_id";
			this.rds_user_u_id.Size = new System.Drawing.Size(60, 17);
			this.rds_user_u_id.TextAlign = HorizontalAlignment.Left;
			this.rds_user_u_id.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_u_id.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserUId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_u_id.ReadOnly=true;
			this.Controls.Add(rds_user_u_id);

			//
			// rds_user_u_name
			//
			rds_user_u_name = new System.Windows.Forms.TextBox();
			this.rds_user_u_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_u_name.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_u_name.ForeColor = System.Drawing.Color.Black;
			this.rds_user_u_name.Location = new System.Drawing.Point(102, 24);
			this.rds_user_u_name.MaxLength = 50;
			this.rds_user_u_name.Name = "rds_user_u_name";
			this.rds_user_u_name.Size = new System.Drawing.Size(92, 17);
			this.rds_user_u_name.TextAlign = HorizontalAlignment.Left;
			this.rds_user_u_name.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_u_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserUName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_u_name.ReadOnly=true;
			this.Controls.Add(rds_user_u_name);

			//
			// rds_user_u_location
			//
			rds_user_u_location = new System.Windows.Forms.TextBox();
			this.rds_user_u_location.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_u_location.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_u_location.ForeColor = System.Drawing.Color.Black;
			this.rds_user_u_location.Location = new System.Drawing.Point(207, 24);
			this.rds_user_u_location.MaxLength = 255;
			this.rds_user_u_location.Name = "rds_user_u_location";
			this.rds_user_u_location.Size = new System.Drawing.Size(124, 17);
			this.rds_user_u_location.TextAlign = HorizontalAlignment.Left;
			this.rds_user_u_location.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_u_location.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserULocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_u_location.ReadOnly=true;
			this.Controls.Add(rds_user_u_location);

			//
			// rds_user_u_phone_t
			//
			this.rds_user_u_phone_t = new System.Windows.Forms.Label();
			this.rds_user_u_phone_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_u_phone_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_u_phone_t.Location = new System.Drawing.Point(3, 47);
			this.rds_user_u_phone_t.Name = "rds_user_u_phone_t";
			this.rds_user_u_phone_t.Size = new System.Drawing.Size(41, 14);
			this.rds_user_u_phone_t.Text = "Phone";
			this.rds_user_u_phone_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_u_phone_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_u_phone_t);

			//
			// rds_user_u_mobile_t
			//
			this.rds_user_u_mobile_t = new System.Windows.Forms.Label();
			this.rds_user_u_mobile_t.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.rds_user_u_mobile_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_u_mobile_t.Location = new System.Drawing.Point(102, 47);
			this.rds_user_u_mobile_t.Name = "rds_user_u_mobile_t";
			this.rds_user_u_mobile_t.Size = new System.Drawing.Size(44, 15);
			this.rds_user_u_mobile_t.Text = "Mobile";
			this.rds_user_u_mobile_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_u_mobile_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_u_mobile_t);

			//
			// rds_user_region_id_t
			//
			this.rds_user_region_id_t = new System.Windows.Forms.Label();
			this.rds_user_region_id_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_region_id_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_region_id_t.Location = new System.Drawing.Point(207, 47);
			this.rds_user_region_id_t.Name = "rds_user_region_id_t";
			this.rds_user_region_id_t.Size = new System.Drawing.Size(62, 14);
			this.rds_user_region_id_t.Text = "Region id";
			this.rds_user_region_id_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_region_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_region_id_t);

			//
			// region_rgn_name_t
			//
			this.region_rgn_name_t = new System.Windows.Forms.Label();
			this.region_rgn_name_t.Font = new System.Drawing.Font("Arial", 8F);
			this.region_rgn_name_t.ForeColor = System.Drawing.Color.Black;
			this.region_rgn_name_t.Location = new System.Drawing.Point(303, 47);
			this.region_rgn_name_t.Name = "region_rgn_name_t";
			this.region_rgn_name_t.Size = new System.Drawing.Size(86, 14);
			this.region_rgn_name_t.Text = "Region name";
			this.region_rgn_name_t.TextAlign = ContentAlignment.MiddleRight;
			this.region_rgn_name_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(region_rgn_name_t);

			//
			// rds_user_u_phone
			//
			rds_user_u_phone = new System.Windows.Forms.TextBox();
			this.rds_user_u_phone.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_u_phone.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_u_phone.ForeColor = System.Drawing.Color.Black;
			this.rds_user_u_phone.Location = new System.Drawing.Point(3, 64);
			this.rds_user_u_phone.MaxLength = 25;
			this.rds_user_u_phone.Name = "rds_user_u_phone";
			this.rds_user_u_phone.Size = new System.Drawing.Size(92, 17);
			this.rds_user_u_phone.TextAlign = HorizontalAlignment.Left;
			this.rds_user_u_phone.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_u_phone.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserUPhone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_u_phone.ReadOnly=true;
			this.Controls.Add(rds_user_u_phone);

			//
			// rds_user_u_mobile
			//
			rds_user_u_mobile = new System.Windows.Forms.TextBox();
			this.rds_user_u_mobile.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_u_mobile.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_u_mobile.ForeColor = System.Drawing.Color.Black;
			this.rds_user_u_mobile.Location = new System.Drawing.Point(102, 64);
			this.rds_user_u_mobile.MaxLength = 25;
			this.rds_user_u_mobile.Name = "rds_user_u_mobile";
			this.rds_user_u_mobile.Size = new System.Drawing.Size(92, 17);
			this.rds_user_u_mobile.TextAlign = HorizontalAlignment.Left;
			this.rds_user_u_mobile.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_u_mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserUMobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_u_mobile.ReadOnly=true;
			this.Controls.Add(rds_user_u_mobile);

			//
			// rds_user_region_id
			//
			rds_user_region_id = new System.Windows.Forms.TextBox();
			this.rds_user_region_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_region_id.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_region_id.ForeColor = System.Drawing.Color.Black;
			this.rds_user_region_id.Location = new System.Drawing.Point(207, 64);
			this.rds_user_region_id.MaxLength = 0;
			this.rds_user_region_id.Name = "rds_user_region_id";
			this.rds_user_region_id.Size = new System.Drawing.Size(60, 17);
			this.rds_user_region_id.TextAlign = HorizontalAlignment.Left;
			this.rds_user_region_id.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_region_id.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserRegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_region_id.ReadOnly=true;
			this.Controls.Add(rds_user_region_id);

			//
			// region_rgn_name
			//
			region_rgn_name = new System.Windows.Forms.TextBox();
			this.region_rgn_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.region_rgn_name.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.region_rgn_name.ForeColor = System.Drawing.Color.Black;
			this.region_rgn_name.Location = new System.Drawing.Point(303, 64);
			this.region_rgn_name.MaxLength = 40;
			this.region_rgn_name.Name = "region_rgn_name";
			this.region_rgn_name.Size = new System.Drawing.Size(129, 17);
			this.region_rgn_name.TextAlign = HorizontalAlignment.Left;
			this.region_rgn_name.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.region_rgn_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RegionRgnName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.region_rgn_name.ReadOnly=true;
			this.Controls.Add(region_rgn_name);

			//
			// rds_user_id_ui_userid_t
			//
			this.rds_user_id_ui_userid_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_userid_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_id_ui_userid_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_userid_t.Location = new System.Drawing.Point(3, 92);
			this.rds_user_id_ui_userid_t.Name = "rds_user_id_ui_userid_t";
			this.rds_user_id_ui_userid_t.Size = new System.Drawing.Size(32, 14);
			this.rds_user_id_ui_userid_t.Text = "UI ID";
			this.rds_user_id_ui_userid_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_userid_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_userid_t);

			//
			// rds_user_id_ui_password_t
			//
			this.rds_user_id_ui_password_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_password_t.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.rds_user_id_ui_password_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_password_t.Location = new System.Drawing.Point(102, 88);
			this.rds_user_id_ui_password_t.Name = "rds_user_id_ui_password_t";
			this.rds_user_id_ui_password_t.Size = new System.Drawing.Size(26, 15);
			this.rds_user_id_ui_password_t.Text = "pwd";
			this.rds_user_id_ui_password_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_password_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_password_t);

			//
			// rds_user_id_ui_last_login_date_t
			//
			this.rds_user_id_ui_last_login_date_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_last_login_date_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_id_ui_last_login_date_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_last_login_date_t.Location = new System.Drawing.Point(207, 88);
			this.rds_user_id_ui_last_login_date_t.Name = "rds_user_id_ui_last_login_date_t";
			this.rds_user_id_ui_last_login_date_t.Size = new System.Drawing.Size(68, 14);
			this.rds_user_id_ui_last_login_date_t.Text = "Last Login";
			this.rds_user_id_ui_last_login_date_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_last_login_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_last_login_date_t);

			//
			// rds_user_id_ui_last_login_time_t
			//
			this.rds_user_id_ui_last_login_time_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_last_login_time_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_id_ui_last_login_time_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_last_login_time_t.Location = new System.Drawing.Point(303, 88);
			this.rds_user_id_ui_last_login_time_t.Name = "rds_user_id_ui_last_login_time_t";
			this.rds_user_id_ui_last_login_time_t.Size = new System.Drawing.Size(100, 14);
			this.rds_user_id_ui_last_login_time_t.Text = "Last Login time";
			this.rds_user_id_ui_last_login_time_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_last_login_time_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_last_login_time_t);

			//
			// rds_user_id_ui_userid
			//
			rds_user_id_ui_userid = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_userid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_userid.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_userid.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_userid.Location = new System.Drawing.Point(3, 105);
			this.rds_user_id_ui_userid.MaxLength = 20;
			this.rds_user_id_ui_userid.Name = "rds_user_id_ui_userid";
			this.rds_user_id_ui_userid.Size = new System.Drawing.Size(92, 17);
			this.rds_user_id_ui_userid.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_userid.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_userid.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiUserid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_userid.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_userid);

			//
			// rds_user_id_ui_password
			//
			rds_user_id_ui_password = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_password.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_password.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_password.Location = new System.Drawing.Point(102, 105);
			this.rds_user_id_ui_password.MaxLength = 20;
			this.rds_user_id_ui_password.Name = "rds_user_id_ui_password";
			this.rds_user_id_ui_password.Size = new System.Drawing.Size(92, 17);
			this.rds_user_id_ui_password.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_password.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_password.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_password.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_password);

			//
			// rds_user_id_ui_last_login_date
			//
			rds_user_id_ui_last_login_date = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_last_login_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_last_login_date.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_last_login_date.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_last_login_date.Location = new System.Drawing.Point(207, 105);
			this.rds_user_id_ui_last_login_date.MaxLength = 0;
			this.rds_user_id_ui_last_login_date.Name = "rds_user_id_ui_last_login_date";
			this.rds_user_id_ui_last_login_date.Size = new System.Drawing.Size(59, 17);
			this.rds_user_id_ui_last_login_date.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_last_login_date.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_last_login_date.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiLastLoginDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_last_login_date.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_last_login_date);

			//
			// rds_user_id_ui_last_login_time
			//
			rds_user_id_ui_last_login_time = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_last_login_time.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_last_login_time.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_last_login_time.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_last_login_time.Location = new System.Drawing.Point(303, 105);
			this.rds_user_id_ui_last_login_time.MaxLength = 0;
			this.rds_user_id_ui_last_login_time.Name = "rds_user_id_ui_last_login_time";
			this.rds_user_id_ui_last_login_time.Size = new System.Drawing.Size(50, 17);
			this.rds_user_id_ui_last_login_time.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_last_login_time.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_last_login_time.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiLastLoginTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_last_login_time.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_last_login_time);

			//
			// rds_user_id_ui_created_date_t
			//
			this.rds_user_id_ui_created_date_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_created_date_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_id_ui_created_date_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_created_date_t.Location = new System.Drawing.Point(3, 131);
			this.rds_user_id_ui_created_date_t.Name = "rds_user_id_ui_created_date_t";
			this.rds_user_id_ui_created_date_t.Size = new System.Drawing.Size(84, 14);
			this.rds_user_id_ui_created_date_t.Text = "Created Date";
			this.rds_user_id_ui_created_date_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_created_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_created_date_t);

			//
			// rds_user_id_ui_created_by_t
			//
			this.rds_user_id_ui_created_by_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_created_by_t.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.rds_user_id_ui_created_by_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_created_by_t.Location = new System.Drawing.Point(102, 131);
			this.rds_user_id_ui_created_by_t.Name = "rds_user_id_ui_created_by_t";
			this.rds_user_id_ui_created_by_t.Size = new System.Drawing.Size(70, 15);
			this.rds_user_id_ui_created_by_t.Text = "Created by";
			this.rds_user_id_ui_created_by_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_created_by_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_created_by_t);

			//
			// rds_user_id_ui_modified_date_t
			//
			this.rds_user_id_ui_modified_date_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_modified_date_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_id_ui_modified_date_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_modified_date_t.Location = new System.Drawing.Point(207, 131);
			this.rds_user_id_ui_modified_date_t.Name = "rds_user_id_ui_modified_date_t";
			this.rds_user_id_ui_modified_date_t.Size = new System.Drawing.Size(88, 14);
			this.rds_user_id_ui_modified_date_t.Text = "Lastmod date";
			this.rds_user_id_ui_modified_date_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_modified_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_modified_date_t);

			//
			// rds_user_id_ui_modified_by_t
			//
			this.rds_user_id_ui_modified_by_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_modified_by_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_id_ui_modified_by_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_modified_by_t.Location = new System.Drawing.Point(303, 131);
			this.rds_user_id_ui_modified_by_t.Name = "rds_user_id_ui_modified_by_t";
			this.rds_user_id_ui_modified_by_t.Size = new System.Drawing.Size(48, 14);
			this.rds_user_id_ui_modified_by_t.Text = "Mod by";
			this.rds_user_id_ui_modified_by_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_modified_by_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_modified_by_t);

			//
			// rds_user_id_ui_created_date
			//
			rds_user_id_ui_created_date = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_created_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_created_date.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_created_date.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_created_date.Location = new System.Drawing.Point(3, 148);
			this.rds_user_id_ui_created_date.MaxLength = 0;
			this.rds_user_id_ui_created_date.Name = "rds_user_id_ui_created_date";
			this.rds_user_id_ui_created_date.Size = new System.Drawing.Size(60, 17);
			this.rds_user_id_ui_created_date.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_created_date.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_created_date.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiCreatedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_created_date.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_created_date);

			//
			// rds_user_id_ui_created_by
			//
			rds_user_id_ui_created_by = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_created_by.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_created_by.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_created_by.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_created_by.Location = new System.Drawing.Point(102, 148);
			this.rds_user_id_ui_created_by.MaxLength = 20;
			this.rds_user_id_ui_created_by.Name = "rds_user_id_ui_created_by";
			this.rds_user_id_ui_created_by.Size = new System.Drawing.Size(92, 17);
			this.rds_user_id_ui_created_by.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_created_by.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_created_by.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiCreatedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_created_by.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_created_by);

			//
			// rds_user_id_ui_modified_date
			//
			rds_user_id_ui_modified_date = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_modified_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_modified_date.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_modified_date.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_modified_date.Location = new System.Drawing.Point(207, 148);
			this.rds_user_id_ui_modified_date.MaxLength = 0;
			this.rds_user_id_ui_modified_date.Name = "rds_user_id_ui_modified_date";
			this.rds_user_id_ui_modified_date.Size = new System.Drawing.Size(60, 17);
			this.rds_user_id_ui_modified_date.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_modified_date.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_modified_date.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_modified_date.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_modified_date);

			//
			// rds_user_id_ui_modified_by
			//
			rds_user_id_ui_modified_by = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_modified_by.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_modified_by.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_modified_by.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_modified_by.Location = new System.Drawing.Point(303, 148);
			this.rds_user_id_ui_modified_by.MaxLength = 20;
			this.rds_user_id_ui_modified_by.Name = "rds_user_id_ui_modified_by";
			this.rds_user_id_ui_modified_by.Size = new System.Drawing.Size(105, 17);
			this.rds_user_id_ui_modified_by.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_modified_by.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_modified_by.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiModifiedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_modified_by.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_modified_by);

			//
			// rds_user_id_ui_password_expiry_t
			//
			this.rds_user_id_ui_password_expiry_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_password_expiry_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_id_ui_password_expiry_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_password_expiry_t.Location = new System.Drawing.Point(3, 173);
			this.rds_user_id_ui_password_expiry_t.Name = "rds_user_id_ui_password_expiry_t";
			this.rds_user_id_ui_password_expiry_t.Size = new System.Drawing.Size(71, 14);
			this.rds_user_id_ui_password_expiry_t.Text = "pwd expiry";
			this.rds_user_id_ui_password_expiry_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_password_expiry_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_password_expiry_t);

			//
			// rds_user_id_ui_grace_logins_t
			//
			this.rds_user_id_ui_grace_logins_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_grace_logins_t.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.rds_user_id_ui_grace_logins_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_grace_logins_t.Location = new System.Drawing.Point(102, 173);
			this.rds_user_id_ui_grace_logins_t.Name = "rds_user_id_ui_grace_logins_t";
			this.rds_user_id_ui_grace_logins_t.Size = new System.Drawing.Size(82, 15);
			this.rds_user_id_ui_grace_logins_t.Text = "Grace logins";
			this.rds_user_id_ui_grace_logins_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_grace_logins_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_grace_logins_t);

			//
			// rds_user_id_ui_locked_date_t
			//
			this.rds_user_id_ui_locked_date_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_locked_date_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_id_ui_locked_date_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_locked_date_t.Location = new System.Drawing.Point(207, 173);
			this.rds_user_id_ui_locked_date_t.Name = "rds_user_id_ui_locked_date_t";
			this.rds_user_id_ui_locked_date_t.Size = new System.Drawing.Size(78, 14);
			this.rds_user_id_ui_locked_date_t.Text = "Locked date";
			this.rds_user_id_ui_locked_date_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_locked_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_locked_date_t);

			//
			// rds_user_id_ui_can_change_password_t
			//
			this.rds_user_id_ui_can_change_password_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_can_change_password_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_id_ui_can_change_password_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_can_change_password_t.Location = new System.Drawing.Point(303, 173);
			this.rds_user_id_ui_can_change_password_t.Name = "rds_user_id_ui_can_change_password_t";
			this.rds_user_id_ui_can_change_password_t.Size = new System.Drawing.Size(76, 14);
			this.rds_user_id_ui_can_change_password_t.Text = "Can change";
			this.rds_user_id_ui_can_change_password_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_can_change_password_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_can_change_password_t);

			//
			// rds_user_id_ui_id_t
			//
			this.rds_user_id_ui_id_t = new System.Windows.Forms.Label();
			this.rds_user_id_ui_id_t.Font = new System.Drawing.Font("Arial", 8F);
			this.rds_user_id_ui_id_t.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_id_t.Location = new System.Drawing.Point(394, 173);
			this.rds_user_id_ui_id_t.Name = "rds_user_id_ui_id_t";
			this.rds_user_id_ui_id_t.Size = new System.Drawing.Size(28, 14);
			this.rds_user_id_ui_id_t.Text = "ui id";
			this.rds_user_id_ui_id_t.TextAlign = ContentAlignment.MiddleRight;
			this.rds_user_id_ui_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(rds_user_id_ui_id_t);

			//
			// rds_user_id_ui_password_expiry
			//
			rds_user_id_ui_password_expiry = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_password_expiry.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_password_expiry.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_password_expiry.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_password_expiry.Location = new System.Drawing.Point(3, 190);
			this.rds_user_id_ui_password_expiry.MaxLength = 0;
			this.rds_user_id_ui_password_expiry.Name = "rds_user_id_ui_password_expiry";
			this.rds_user_id_ui_password_expiry.Size = new System.Drawing.Size(60, 17);
			this.rds_user_id_ui_password_expiry.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_password_expiry.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_password_expiry.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiPasswordExpiry", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_password_expiry.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_password_expiry);

			//
			// rds_user_id_ui_grace_logins
			//
			rds_user_id_ui_grace_logins = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_grace_logins.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_grace_logins.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_grace_logins.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_grace_logins.Location = new System.Drawing.Point(102, 190);
			this.rds_user_id_ui_grace_logins.MaxLength = 0;
			this.rds_user_id_ui_grace_logins.Name = "rds_user_id_ui_grace_logins";
			this.rds_user_id_ui_grace_logins.Size = new System.Drawing.Size(60, 17);
			this.rds_user_id_ui_grace_logins.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_grace_logins.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_grace_logins.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiGraceLogins", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_grace_logins.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_grace_logins);

			//
			// rds_user_id_ui_locked_date
			//
			rds_user_id_ui_locked_date = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_locked_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_locked_date.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_locked_date.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_locked_date.Location = new System.Drawing.Point(207, 190);
			this.rds_user_id_ui_locked_date.MaxLength = 0;
			this.rds_user_id_ui_locked_date.Name = "rds_user_id_ui_locked_date";
			this.rds_user_id_ui_locked_date.Size = new System.Drawing.Size(60, 17);
			this.rds_user_id_ui_locked_date.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_locked_date.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_locked_date.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiLockedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_locked_date.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_locked_date);

			//
			// rds_user_id_ui_can_change_password
			//
			rds_user_id_ui_can_change_password = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_can_change_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_can_change_password.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_can_change_password.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_can_change_password.Location = new System.Drawing.Point(303, 190);
			this.rds_user_id_ui_can_change_password.MaxLength = 1;
			this.rds_user_id_ui_can_change_password.Name = "rds_user_id_ui_can_change_password";
			this.rds_user_id_ui_can_change_password.Size = new System.Drawing.Size(10, 17);
			this.rds_user_id_ui_can_change_password.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_can_change_password.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_can_change_password.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiCanChangePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_can_change_password.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_can_change_password);

			//
			// rds_user_id_ui_id
			//
			rds_user_id_ui_id = new System.Windows.Forms.TextBox();
			this.rds_user_id_ui_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rds_user_id_ui_id.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rds_user_id_ui_id.ForeColor = System.Drawing.Color.Black;
			this.rds_user_id_ui_id.Location = new System.Drawing.Point(394, 190);
			this.rds_user_id_ui_id.MaxLength = 0;
			this.rds_user_id_ui_id.Name = "rds_user_id_ui_id";
			this.rds_user_id_ui_id.Size = new System.Drawing.Size(60, 17);
			this.rds_user_id_ui_id.TextAlign = HorizontalAlignment.Left;
			this.rds_user_id_ui_id.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rds_user_id_ui_id.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "RdsUserIdUiId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rds_user_id_ui_id.ReadOnly=true;
			this.Controls.Add(rds_user_id_ui_id);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
		}
		#endregion

	}
}
