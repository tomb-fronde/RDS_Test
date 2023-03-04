namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DRateDays
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rate_days_rtd_days_per_annum;
		private System.Windows.Forms.DataGridViewTextBoxColumn  standard_frequency_sf_description;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RateDays);

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
			// standard_frequency_sf_description
			//
			standard_frequency_sf_description= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.standard_frequency_sf_description.DataPropertyName = "StandardFrequencySfDescription";
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
			rate_days_rtd_days_per_annum= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rate_days_rtd_days_per_annum.DataPropertyName = "RateDaysRtdDaysPerAnnum";
			this.rate_days_rtd_days_per_annum.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            //?this.rate_days_rtd_days_per_annum.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144~tif(describe('st_readonly.text')='N',16777215,12632256));
			this.rate_days_rtd_days_per_annum.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rate_days_rtd_days_per_annum.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rate_days_rtd_days_per_annum.HeaderText = "Days/annum";
			this.rate_days_rtd_days_per_annum.Name = "rate_days_rtd_days_per_annum";
			this.rate_days_rtd_days_per_annum.Width = 70;
			this.grid.Columns.Add(rate_days_rtd_days_per_annum);

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
