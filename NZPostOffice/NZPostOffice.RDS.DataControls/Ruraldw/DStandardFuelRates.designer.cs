namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DStandardFuelRates
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  fr_fuel_rate;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rr_rates_effective_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  fr_fuel_consumtion_rate;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ft_key;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rg_code;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.StandardFuelRates);

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
			// ft_key
			//
			ft_key= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ft_key.DataPropertyName = "FtKey";
			this.ft_key.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ft_key.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ft_key.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ft_key.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.ft_key.HeaderText = "Ft Key";
			this.ft_key.Name = "ft_key";
			this.ft_key.Width = 60;
			this.grid.Columns.Add(ft_key);


			//
			// rg_code
			//
			rg_code= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rg_code.DataPropertyName = "RgCode";
			this.rg_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rg_code.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rg_code.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rg_code.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rg_code.HeaderText = "Rg Code";
			this.rg_code.Name = "rg_code";
			this.rg_code.Width = 60;
			this.grid.Columns.Add(rg_code);


			//
			// rr_rates_effective_date
			//
			rr_rates_effective_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rr_rates_effective_date.DataPropertyName = "RrRatesEffectiveDate";
			this.rr_rates_effective_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rr_rates_effective_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rr_rates_effective_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rr_rates_effective_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rr_rates_effective_date.HeaderText = "Rr Rates Effective Date";
			this.rr_rates_effective_date.Name = "rr_rates_effective_date";
			this.rr_rates_effective_date.Width = 130;
			this.grid.Columns.Add(rr_rates_effective_date);


			//
			// fr_fuel_rate
			//
			fr_fuel_rate= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fr_fuel_rate.DataPropertyName = "FrFuelRate";
			this.fr_fuel_rate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.fr_fuel_rate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.fr_fuel_rate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.fr_fuel_rate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.fr_fuel_rate.HeaderText = "Fr Fuel Rate";
			this.fr_fuel_rate.Name = "fr_fuel_rate";
			this.fr_fuel_rate.Width = 80;
			this.grid.Columns.Add(fr_fuel_rate);


			//
			// fr_fuel_consumtion_rate
			//
			fr_fuel_consumtion_rate= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fr_fuel_consumtion_rate.DataPropertyName = "FrFuelConsumtionRate";
			this.fr_fuel_consumtion_rate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.fr_fuel_consumtion_rate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.fr_fuel_consumtion_rate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.fr_fuel_consumtion_rate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.fr_fuel_consumtion_rate.HeaderText = "Fr Fuel Consumtion Rate";
			this.fr_fuel_consumtion_rate.Name = "fr_fuel_consumtion_rate";
			this.fr_fuel_consumtion_rate.Width = 137;
			this.grid.Columns.Add(fr_fuel_consumtion_rate);

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
