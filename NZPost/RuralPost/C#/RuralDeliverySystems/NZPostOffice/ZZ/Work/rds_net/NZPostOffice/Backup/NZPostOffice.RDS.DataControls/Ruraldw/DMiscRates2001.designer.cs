namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DMiscRates2001
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  mr_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  mr_effective_date;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  mr_annual_flag;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  mr_km_flag;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rg_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn  mr_value;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.MiscRates2001);

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
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
			this.grid.TabIndex = 0;

			//
			// mr_name
			//
			mr_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mr_name.DataPropertyName = "MrName";
			this.mr_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.mr_name.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.mr_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.mr_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.mr_name.HeaderText = "Name:";
			this.mr_name.Name = "mr_name";
			this.mr_name.Width = 132;
			this.grid.Columns.Add(mr_name);

			//
			// mr_value
			//
			mr_value= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mr_value.DataPropertyName = "MrValue";
			this.mr_value.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			//this.mr_value.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.mr_value.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.mr_value.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.mr_value.HeaderText = "Value:";
			this.mr_value.Name = "mr_value";
			this.mr_value.Width = 71;
			this.grid.Columns.Add(mr_value);


			//
			// mr_km_flag
			//
			mr_km_flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.mr_km_flag.DataPropertyName = "MrKmFlag";
			this.mr_km_flag.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.mr_km_flag.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.mr_km_flag.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.mr_km_flag.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.mr_km_flag.DefaultCellStyle.NullValue = false;
            this.mr_km_flag.HeaderText = "Km Flag: ";
			this.mr_km_flag.Name = "mr_km_flag";
			this.mr_km_flag.TrueValue = "Y";
			this.mr_km_flag.FalseValue = "N";
			this.mr_km_flag.Width = 96;
			this.grid.Columns.Add(mr_km_flag);


			//
			// mr_annual_flag
			//
			mr_annual_flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.mr_annual_flag.DataPropertyName = "MrAnnualFlag";
			this.mr_annual_flag.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.mr_annual_flag.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.mr_annual_flag.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.mr_annual_flag.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.mr_annual_flag.DefaultCellStyle.NullValue = false;
            this.mr_annual_flag.HeaderText = "Annual Flag: ";
			this.mr_annual_flag.Name = "mr_annual_flag";
			this.mr_annual_flag.TrueValue = "Y";
			this.mr_annual_flag.FalseValue = "N";
			this.mr_annual_flag.Width = 101;
			this.grid.Columns.Add(mr_annual_flag);


			//
			// rg_code
			//
			rg_code= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rg_code.DataPropertyName = "RgCode";
			this.rg_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			//this.rg_code.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rg_code.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rg_code.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rg_code.HeaderText = "";
			this.rg_code.Name = "rg_code";
			this.rg_code.ReadOnly = true;
			this.rg_code.Width = 71;
            this.rg_code.Visible = false;
			this.grid.Columns.Add(rg_code);


			//
			// mr_effective_date
			//
			mr_effective_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mr_effective_date.DataPropertyName = "MrEffectiveDate";
			this.mr_effective_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.mr_effective_date.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.mr_effective_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.mr_effective_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.mr_effective_date.HeaderText = "";
			this.mr_effective_date.Name = "mr_effective_date";
			this.mr_effective_date.ReadOnly = true;
			this.mr_effective_date.Width = 71;
            this.mr_effective_date.Visible = false;
			this.grid.Columns.Add(mr_effective_date);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			//this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.Controls.Add(grid);
		}
		#endregion

	}
}
