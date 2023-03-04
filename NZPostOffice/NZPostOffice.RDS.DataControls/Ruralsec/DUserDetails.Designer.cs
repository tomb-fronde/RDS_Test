namespace NZPostOffice.RDS.DataControls.Ruralsec
{
	partial class DUserDetails
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  modified_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  created_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  region_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  locked_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  created_by;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ui_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  location;
		private System.Windows.Forms.DataGridViewTextBoxColumn  last_login_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  modified_by;
		private System.Windows.Forms.DataGridViewTextBoxColumn  name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  region_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  can_change_password;
		private System.Windows.Forms.DataGridViewTextBoxColumn  password;
		private System.Windows.Forms.DataGridViewTextBoxColumn  password_expiry;
		private System.Windows.Forms.DataGridViewTextBoxColumn  mobile;
		private System.Windows.Forms.DataGridViewTextBoxColumn  phone;
		private System.Windows.Forms.DataGridViewTextBoxColumn  user_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  grace_logins;
		private System.Windows.Forms.DataGridViewTextBoxColumn  last_login_time;

	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private Metex.Windows.DataEntityGrid grid;
		#region Component Designer generated code
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			grid = new Metex.Windows.DataEntityGrid();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralsec.UserDetails);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
			this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.ColumnHeadersHeight = 35;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.grid.DataSource = this.bindingSource;
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(638, 252);
			this.grid.TabIndex = 0;

			//
			// id
			//
			id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.id.DataPropertyName = "Id";
			this.id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.id.HeaderText = "Id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Width = 21;
			this.grid.Columns.Add(id);


			//
			// name
			//
			name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.name.DataPropertyName = "Name";
			this.name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.name.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.name.HeaderText = "name";
			this.name.Name = "name";
			this.name.ReadOnly = true;
			this.name.Width = 32;
			this.grid.Columns.Add(name);


			//
			// location
			//
			location= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.location.DataPropertyName = "Location";
			this.location.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.location.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.location.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.location.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.location.HeaderText = "Loc";
			this.location.Name = "location";
			this.location.ReadOnly = true;
			this.location.Width = 39;
			this.grid.Columns.Add(location);


			//
			// phone
			//
			phone= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.phone.DataPropertyName = "Phone";
			this.phone.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.phone.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.phone.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.phone.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.phone.HeaderText = "Phone";
			this.phone.Name = "phone";
			this.phone.ReadOnly = true;
			this.phone.Width = 38;
			this.grid.Columns.Add(phone);


			//
			// mobile
			//
			mobile= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mobile.DataPropertyName = "Mobile";
			this.mobile.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.mobile.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.mobile.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.mobile.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.mobile.HeaderText = "Mobile";
			this.mobile.Name = "mobile";
			this.mobile.ReadOnly = true;
			this.mobile.Width = 33;
			this.grid.Columns.Add(mobile);


			//
			// region_id
			//
			region_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.region_id.DataPropertyName = "RegionId";
			this.region_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.region_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.region_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.region_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.region_id.HeaderText = "Region";
			this.region_id.Name = "region_id";
			this.region_id.ReadOnly = true;
			this.region_id.Width = 40;
			this.grid.Columns.Add(region_id);


			//
			// region_name
			//
			region_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.region_name.DataPropertyName = "RegionName";
			this.region_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.region_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.region_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.region_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.region_name.HeaderText = "Reg name";
			this.region_name.Name = "region_name";
			this.region_name.ReadOnly = true;
			this.region_name.Width = 53;
			this.grid.Columns.Add(region_name);


			//
			// user_id
			//
			user_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.user_id.DataPropertyName = "UserId";
			this.user_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.user_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.user_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.user_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.user_id.HeaderText = "suer id";
			this.user_id.Name = "user_id";
			this.user_id.ReadOnly = true;
			this.user_id.Width = 32;
			this.grid.Columns.Add(user_id);


			//
			// password
			//
			password= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.password.DataPropertyName = "Password";
			this.password.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.password.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.password.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.password.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.password.HeaderText = "pwd";
			this.password.Name = "password";
			this.password.ReadOnly = true;
			this.password.Width = 43;
			this.grid.Columns.Add(password);


			//
			// last_login_date
			//
			last_login_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.last_login_date.DataPropertyName = "LastLoginDate";
			this.last_login_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.last_login_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.last_login_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.last_login_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.last_login_date.HeaderText = "last login";
			this.last_login_date.Name = "last_login_date";
			this.last_login_date.ReadOnly = true;
			this.last_login_date.Width = 64;
			this.grid.Columns.Add(last_login_date);


			//
			// last_login_time
			//
			last_login_time= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.last_login_time.DataPropertyName = "LastLoginTime";
			this.last_login_time.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.last_login_time.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.last_login_time.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.last_login_time.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.last_login_time.DefaultCellStyle.Format = "[time]";
			this.last_login_time.HeaderText = "last login time";
			this.last_login_time.Name = "last_login_time";
			this.last_login_time.ReadOnly = true;
			this.last_login_time.Width = 67;
			this.grid.Columns.Add(last_login_time);


			//
			// created_date
			//
			created_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.created_date.DataPropertyName = "CreatedDate";
			this.created_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.created_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.created_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.created_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.created_date.HeaderText = "created date";
			this.created_date.Name = "created_date";
			this.created_date.ReadOnly = true;
			this.created_date.Width = 60;
			this.grid.Columns.Add(created_date);


			//
			// created_by
			//
			created_by= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.created_by.DataPropertyName = "CreatedBy";
			this.created_by.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.created_by.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.created_by.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.created_by.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.created_by.HeaderText = "created by";
			this.created_by.Name = "created_by";
			this.created_by.ReadOnly = true;
			this.created_by.Width = 50;
			this.grid.Columns.Add(created_by);


			//
			// modified_date
			//
			modified_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.modified_date.DataPropertyName = "ModifiedDate";
			this.modified_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.modified_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.modified_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.modified_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.modified_date.HeaderText = "last modified";
			this.modified_date.Name = "modified_date";
			this.modified_date.ReadOnly = true;
			this.modified_date.Width = 59;
			this.grid.Columns.Add(modified_date);


			//
			// modified_by
			//
			modified_by= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.modified_by.DataPropertyName = "ModifiedBy";
			this.modified_by.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.modified_by.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.modified_by.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.modified_by.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.modified_by.HeaderText = "modified by";
			this.modified_by.Name = "modified_by";
			this.modified_by.ReadOnly = true;
			this.modified_by.Width = 54;
			this.grid.Columns.Add(modified_by);


			//
			// password_expiry
			//
			password_expiry= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.password_expiry.DataPropertyName = "PasswordExpiry";
			this.password_expiry.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.password_expiry.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.password_expiry.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.password_expiry.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.password_expiry.HeaderText = "pawd expiry";
			this.password_expiry.Name = "password_expiry";
			this.password_expiry.ReadOnly = true;
			this.password_expiry.Width = 75;
			this.grid.Columns.Add(password_expiry);


			//
			// grace_logins
			//
			grace_logins= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.grace_logins.DataPropertyName = "GraceLogins";
			this.grace_logins.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.grace_logins.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.grace_logins.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.grace_logins.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.grace_logins.HeaderText = "grace log";
			this.grace_logins.Name = "grace_logins";
			this.grace_logins.ReadOnly = true;
			this.grace_logins.Width = 64;
			this.grid.Columns.Add(grace_logins);


			//
			// locked_date
			//
			locked_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.locked_date.DataPropertyName = "LockedDate";
			this.locked_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.locked_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.locked_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.locked_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.locked_date.HeaderText = "locked date";
			this.locked_date.Name = "locked_date";
			this.locked_date.ReadOnly = true;
			this.locked_date.Width = 61;
			this.grid.Columns.Add(locked_date);


			//
			// can_change_password
			//
			can_change_password= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.can_change_password.DataPropertyName = "CanChangePassword";
			this.can_change_password.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.can_change_password.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.can_change_password.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.can_change_password.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.can_change_password.HeaderText = "can changed pwd";
			this.can_change_password.Name = "can_change_password";
			this.can_change_password.ReadOnly = true;
			this.can_change_password.Width = 109;
			this.grid.Columns.Add(can_change_password);


			//
			// ui_id
			//
			ui_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ui_id.DataPropertyName = "UiId";
			this.ui_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ui_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.ui_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ui_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.ui_id.HeaderText = "Rds User Id Ui Id";
			this.ui_id.Name = "ui_id";
			this.ui_id.ReadOnly = true;
			this.ui_id.Width = 47;
			this.grid.Columns.Add(ui_id);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(grid);
		}
		#endregion

	}
}
