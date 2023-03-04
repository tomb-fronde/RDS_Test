namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class DCustCountExport
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  o_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  circulars;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contract_no;
		private System.Windows.Forms.DataGridViewTextBoxColumn  business;
		private System.Windows.Forms.DataGridViewTextBoxColumn  farmer;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cmb;
		private System.Windows.Forms.DataGridViewTextBoxColumn  resident;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rgn_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  con_title;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.CustCountExport);

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

			//
			// rgn_name
			//
			rgn_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rgn_name.DataPropertyName = "RgnName";
			this.rgn_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rgn_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rgn_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.rgn_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rgn_name.HeaderText = "Region";
			this.rgn_name.Name = "rgn_name";
			this.rgn_name.ReadOnly = true;
			this.rgn_name.Width = 64;
			this.grid.Columns.Add(rgn_name);


			//
			// o_name
			//
			o_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.o_name.DataPropertyName = "OName";
			this.o_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.o_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.o_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.o_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.o_name.HeaderText = "Outlet";
			this.o_name.Name = "o_name";
			this.o_name.ReadOnly = true;
			this.o_name.Width = 56;
			this.grid.Columns.Add(o_name);


			//
			// contract_no
			//
			contract_no= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contract_no.DataPropertyName = "ContractNo";
			this.contract_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.contract_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contract_no.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.contract_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.contract_no.HeaderText = "Contract No";
			this.contract_no.Name = "contract_no";
			this.contract_no.ReadOnly = true;
			this.contract_no.Width = 70;
			this.grid.Columns.Add(contract_no);


			//
			// con_title
			//
			con_title= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.con_title.DataPropertyName = "ConTitle";
			this.con_title.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.con_title.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.con_title.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.con_title.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.con_title.HeaderText = "Con Title";
			this.con_title.Name = "con_title";
			this.con_title.ReadOnly = true;
			this.con_title.Width = 57;
			this.grid.Columns.Add(con_title);


			//
			// resident
			//
			resident= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.resident.DataPropertyName = "Resident";
			this.resident.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.resident.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.resident.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.resident.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.resident.HeaderText = "Resident";
			this.resident.Name = "resident";
			this.resident.ReadOnly = true;
			this.resident.Width = 52;
			this.grid.Columns.Add(resident);

            //
            // business
            //
            business = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.business.DataPropertyName = "Business";
            this.business.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.business.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.business.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.business.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.business.HeaderText = "Business";
            this.business.Name = "business";
            this.business.ReadOnly = true;
            this.business.Width = 55;
            this.grid.Columns.Add(business);


            //
            // farmer
            //
            farmer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.farmer.DataPropertyName = "Farmer";
            this.farmer.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.farmer.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.farmer.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.farmer.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.farmer.HeaderText = "Farmer";
            this.farmer.Name = "farmer";
            this.farmer.ReadOnly = true;
            this.farmer.Width = 45;
            this.grid.Columns.Add(farmer);


			//
			// circulars
			//
			circulars= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.circulars.DataPropertyName = "Circulars";
			this.circulars.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.circulars.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.circulars.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.circulars.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.circulars.HeaderText = "Circulars";
			this.circulars.Name = "circulars";
			this.circulars.ReadOnly = true;
			this.circulars.Width = 60;
			this.grid.Columns.Add(circulars);


			//
			// cmb
			//
			cmb= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cmb.DataPropertyName = "Cmb";
			this.cmb.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cmb.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cmb.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmb.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cmb.HeaderText = "Cmb";
			this.cmb.Name = "cmb";
			this.cmb.ReadOnly = true;
			this.cmb.Width = 35;
			this.grid.Columns.Add(cmb);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(grid);
		}
		#endregion

	}
}
