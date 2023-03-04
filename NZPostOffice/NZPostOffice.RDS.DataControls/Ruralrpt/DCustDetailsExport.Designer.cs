namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class DCustDetailsExport
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_address;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_phone_day;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_contract;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_surname_company;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_phone_mobile;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_title;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_recipients;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_mail_category;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_initials;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_phone_night;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.CustDetailsExport);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
			this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.ColumnHeadersHeight = 28;
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
            this.grid.BackgroundColor = System.Drawing.Color.White;
			//
			// cust_id
			//
			cust_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_id.DataPropertyName = "CustId";
			this.cust_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_id.HeaderText = "Cust Id";
			this.cust_id.Name = "cust_id";
			this.cust_id.ReadOnly = true;
			this.cust_id.Width = 54;
			this.grid.Columns.Add(cust_id);


			//
			// cust_title
			//
			cust_title= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_title.DataPropertyName = "CustTitle";
			this.cust_title.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_title.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_title.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_title.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_title.HeaderText = "Cust Title";
			this.cust_title.Name = "cust_title";
			this.cust_title.ReadOnly = true;
			this.cust_title.Width = 64;
			this.grid.Columns.Add(cust_title);


			//
			// cust_initials
			//
			cust_initials= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_initials.DataPropertyName = "CustInitials";
			this.cust_initials.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_initials.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_initials.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_initials.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_initials.HeaderText = "Cust Initials";
			this.cust_initials.Name = "cust_initials";
			this.cust_initials.ReadOnly = true;
			this.cust_initials.Width = 255;
			this.grid.Columns.Add(cust_initials);


			//
			// cust_surname_company
			//
			cust_surname_company= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_surname_company.DataPropertyName = "CustSurnameCompany";
			this.cust_surname_company.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_surname_company.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_surname_company.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_surname_company.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_surname_company.HeaderText = "Cust Surname Company";
			this.cust_surname_company.Name = "cust_surname_company";
			this.cust_surname_company.ReadOnly = true;
			this.cust_surname_company.Width = 255;
			this.grid.Columns.Add(cust_surname_company);


			//
			// cust_phone_day
			//
			cust_phone_day= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_phone_day.DataPropertyName = "CustPhoneDay";
			this.cust_phone_day.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_phone_day.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_phone_day.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_phone_day.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_phone_day.HeaderText = "Cust Phone Day";
			this.cust_phone_day.Name = "cust_phone_day";
			this.cust_phone_day.ReadOnly = true;
			this.cust_phone_day.Width = 105;
			this.grid.Columns.Add(cust_phone_day);


			//
			// cust_phone_night
			//
			cust_phone_night= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_phone_night.DataPropertyName = "CustPhoneNight";
			this.cust_phone_night.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_phone_night.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_phone_night.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_phone_night.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_phone_night.HeaderText = "Cust Phone Night";
			this.cust_phone_night.Name = "cust_phone_night";
			this.cust_phone_night.ReadOnly = true;
			this.cust_phone_night.Width = 105;
			this.grid.Columns.Add(cust_phone_night);


			//
			// cust_phone_mobile
			//
			cust_phone_mobile= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_phone_mobile.DataPropertyName = "CustPhoneMobile";
			this.cust_phone_mobile.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_phone_mobile.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_phone_mobile.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_phone_mobile.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_phone_mobile.DefaultCellStyle.Format = "@@@) @@@-@@@@@~tif(isnumber(cust_phone_mobile),'(@@@) @@@-@@@@@',''";
			this.cust_phone_mobile.HeaderText = "Cust Phone Mobile";
			this.cust_phone_mobile.Name = "cust_phone_mobile";
			this.cust_phone_mobile.ReadOnly = true;
			this.cust_phone_mobile.Width = 105;
			this.grid.Columns.Add(cust_phone_mobile);


			//
			// cust_address
			//
			cust_address= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_address.DataPropertyName = "CustAddress";
			this.cust_address.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_address.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_address.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_address.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_address.HeaderText = "F Getcustomeraddresses(rds Customer.cust Id)";
			this.cust_address.Name = "cust_address";
			this.cust_address.ReadOnly = true;
			this.cust_address.Width = 864;
			this.grid.Columns.Add(cust_address);


			//
			// cust_mail_category
			//
			cust_mail_category= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_mail_category.DataPropertyName = "CustMailCategory";
			this.cust_mail_category.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_mail_category.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_mail_category.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_mail_category.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_mail_category.HeaderText = "F Getmailcategory(rds Customer.cust Id)";
			this.cust_mail_category.Name = "cust_mail_category";
			this.cust_mail_category.ReadOnly = true;
			this.cust_mail_category.Width = 864;
			this.grid.Columns.Add(cust_mail_category);


			//
			// cust_recipients
			//
			cust_recipients= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_recipients.DataPropertyName = "CustRecipients";
			this.cust_recipients.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_recipients.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_recipients.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_recipients.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_recipients.HeaderText = "F Getrecipients(rds Customer.cust Id)";
			this.cust_recipients.Name = "cust_recipients";
			this.cust_recipients.ReadOnly = true;
			this.cust_recipients.Width = 864;
			this.grid.Columns.Add(cust_recipients);


			//
			// cust_contract
			//
			cust_contract= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_contract.DataPropertyName = "CustContract";
			this.cust_contract.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_contract.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_contract.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_contract.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_contract.HeaderText = "Rd.f Getcontractno(rds Customer.cust Id)";
			this.cust_contract.Name = "cust_contract";
			this.cust_contract.ReadOnly = true;
			this.cust_contract.Width = 864;
			this.grid.Columns.Add(cust_contract);

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
