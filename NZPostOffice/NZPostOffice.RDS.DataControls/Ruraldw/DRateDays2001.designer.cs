namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DRateDays2001
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rate_days_rr_rates_effective_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rate_days_rg_code;
		//private System.Windows.Forms.DataGridViewTextBoxColumn  rate_days_rtd_days_per_annum;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn rate_days_rtd_days_per_annum;
		private System.Windows.Forms.DataGridViewTextBoxColumn  standard_frequency_sf_description;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rate_days_sf_key;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RateDays2001);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
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
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(120, 0);
            //this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grid.Size = new System.Drawing.Size(638, 252);
			this.grid.TabIndex = 0;

			//
			// rate_days_rr_rates_effective_date
			//
			rate_days_rr_rates_effective_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate_days_rr_rates_effective_date.DataPropertyName = "RateDaysRrRatesEffectiveDate";
			this.rate_days_rr_rates_effective_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rate_days_rr_rates_effective_date.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.rate_days_rr_rates_effective_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rate_days_rr_rates_effective_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rate_days_rr_rates_effective_date.HeaderText = "N";
			this.rate_days_rr_rates_effective_date.Name = "rate_days_rr_rates_effective_date";
			this.rate_days_rr_rates_effective_date.ReadOnly = true;
			this.rate_days_rr_rates_effective_date.Width = 60;
            this.rate_days_rr_rates_effective_date.Visible = false;
			this.grid.Columns.Add(rate_days_rr_rates_effective_date);


			//
			// rate_days_rg_code
			//
			rate_days_rg_code= new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate_days_rg_code.DataPropertyName = "RgCode";
			this.rate_days_rg_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.rate_days_rg_code.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.rate_days_rg_code.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rate_days_rg_code.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rate_days_rg_code.HeaderText = "N";
			this.rate_days_rg_code.Name = "rate_days_rg_code";
			this.rate_days_rg_code.ReadOnly = true;
			this.rate_days_rg_code.Width = 28;
            this.rate_days_rg_code.Visible = false;
			this.grid.Columns.Add(rate_days_rg_code);


			//
			// rate_days_sf_key
			//
			rate_days_sf_key= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rate_days_sf_key.DataPropertyName = "RateDaysSfKey";
			this.rate_days_sf_key.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.rate_days_sf_key.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rate_days_sf_key.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
			this.rate_days_sf_key.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rate_days_sf_key.DefaultCellStyle.Format = "[currency]";
			this.rate_days_sf_key.HeaderText = "N";
			this.rate_days_sf_key.Name = "rate_days_sf_key";
			this.rate_days_sf_key.ReadOnly = true;
			this.rate_days_sf_key.Width = 19;
            this.rate_days_sf_key.Visible = false;
			this.grid.Columns.Add(rate_days_sf_key);


			//
			// standard_frequency_sf_description
			//
			standard_frequency_sf_description= new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.standard_frequency_sf_description.DataPropertyName = "SfDescription";
			this.standard_frequency_sf_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.standard_frequency_sf_description.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.standard_frequency_sf_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.standard_frequency_sf_description.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.standard_frequency_sf_description.HeaderText = "Standard Frequency";
			this.standard_frequency_sf_description.Name = "standard_frequency_sf_description";
			this.standard_frequency_sf_description.ReadOnly = true;
			this.standard_frequency_sf_description.Width = 119;
			this.grid.Columns.Add(standard_frequency_sf_description);


			//
			// rate_days_rtd_days_per_annum
			//
			//rate_days_rtd_days_per_annum= new System.Windows.Forms.DataGridViewTextBoxColumn();
            rate_days_rtd_days_per_annum = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn();
			this.rate_days_rtd_days_per_annum.DataPropertyName = "RtdDaysPerAnnum";
			this.rate_days_rtd_days_per_annum.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.rate_days_rtd_days_per_annum.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
            //?this.rate_days_rtd_days_per_annum.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif ( isnull(    rtd_days_per_annum ),rgb(128,128,128) , rgb(0,0,0) ));
			this.rate_days_rtd_days_per_annum.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rate_days_rtd_days_per_annum.DefaultCellStyle.Format = "##0";//;-##0;##0";
            this.rate_days_rtd_days_per_annum.Mask = "##0";
			this.rate_days_rtd_days_per_annum.HeaderText = "Days/annum";
			this.rate_days_rtd_days_per_annum.Name = "rate_days_rtd_days_per_annum";
			this.rate_days_rtd_days_per_annum.Width = 82;
            //this.rate_days_rtd_days_per_annum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.grid.Columns.Add(rate_days_rtd_days_per_annum);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.SystemColors.ButtonFace;//.ColorTranslator.FromWin32(80269524);
			this.Controls.Add(grid);
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SizeChanged += new System.EventHandler(DRateDays2001_SizeChanged);
		}

        void DRateDays2001_SizeChanged(object sender, System.EventArgs e)
        {
            this.grid.Width = this.Width - 120;
            this.grid.Height = this.Height;
        }
		#endregion

	}
}
