namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DFuelRates2001
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		//private System.Windows.Forms.DataGridViewTextBoxColumn  fr_fuel_rate;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn fr_fuel_rate;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ft_description;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rr_rates_effective_date;
		//private System.Windows.Forms.DataGridViewTextBoxColumn  fr_fuel_consumtion_rate;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn fr_fuel_consumtion_rate;
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.FuelRates2001);

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
			this.grid.ColumnHeadersHeight = 35;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.grid.DataSource = this.bindingSource;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(120, 0);
            //this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
			this.grid.TabIndex = 0;
            
			//
			// rg_code
			//
			rg_code= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rg_code.DataPropertyName = "RgCode";
			this.rg_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rg_code.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.ColorTranslator.FromWin32(553648127);
			this.rg_code.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rg_code.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rg_code.HeaderText = "N";
			this.rg_code.Name = "rg_code";
			this.rg_code.ReadOnly = true;
			this.rg_code.Width = 56;
            this.rg_code.Visible = false;
			this.grid.Columns.Add(rg_code);


			//
			// ft_key
			//
			ft_key= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ft_key.DataPropertyName = "FtKey";
			this.ft_key.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ft_key.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.ColorTranslator.FromWin32(553648127);
			this.ft_key.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ft_key.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.ft_key.HeaderText = "N";
			this.ft_key.Name = "ft_key";
			this.ft_key.ReadOnly = true;
			this.ft_key.Width = 56;
            this.ft_key.Visible = false;
			this.grid.Columns.Add(ft_key);


			//
			// rr_rates_effective_date
			//
			rr_rates_effective_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rr_rates_effective_date.DataPropertyName = "RrRatesEffectiveDate";
			this.rr_rates_effective_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.rr_rates_effective_date.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rr_rates_effective_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rr_rates_effective_date.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			this.rr_rates_effective_date.HeaderText = "N";
			this.rr_rates_effective_date.Name = "rr_rates_effective_date";
			this.rr_rates_effective_date.ReadOnly = true;
			this.rr_rates_effective_date.Width = 84;
            this.rr_rates_effective_date.Visible = false;
			this.grid.Columns.Add(rr_rates_effective_date);


			//
			// ft_description
			//
			ft_description= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ft_description.DataPropertyName = "FtDescription";
			this.ft_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ft_description.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ft_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ft_description.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.ft_description.HeaderText = "Fuel Type";
			this.ft_description.Name = "ft_description";
			this.ft_description.ReadOnly = true;
			this.ft_description.Width = 92;
			this.grid.Columns.Add(ft_description);


			//
			// fr_fuel_rate
			//
			//fr_fuel_rate= new System.Windows.Forms.DataGridViewTextBoxColumn();
            fr_fuel_rate = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn();
			this.fr_fuel_rate.DataPropertyName = "FrFuelRate";
			this.fr_fuel_rate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.fr_fuel_rate.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.ColorTranslator.FromWin32(1087955144);
			//?this.fr_fuel_rate.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif ( isnull(    fr_fuel_rate ),rgb(128,128,128) , rgb(0,0,0) ));
			this.fr_fuel_rate.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.fr_fuel_rate.DefaultCellStyle.Format = "###0.00";//;-###0.00;###0.00";
			this.fr_fuel_rate.HeaderText = "Fuel Rate (cents/litre)";
			this.fr_fuel_rate.Name = "fr_fuel_rate";
			this.fr_fuel_rate.Width = 65;
            this.fr_fuel_rate.Mask = "###0.00";
			this.grid.Columns.Add(fr_fuel_rate);


			//
			// fr_fuel_consumtion_rate
			//
			//fr_fuel_consumtion_rate= new System.Windows.Forms.DataGridViewTextBoxColumn();
            fr_fuel_consumtion_rate = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn();
			this.fr_fuel_consumtion_rate.DataPropertyName = "FrFuelConsumtionRate";
			this.fr_fuel_consumtion_rate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.fr_fuel_consumtion_rate.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.ColorTranslator.FromWin32(1087955144);
            //?this.fr_fuel_consumtion_rate.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif ( isnull(    fr_fuel_consumtion_rate ),rgb(128,128,128) , rgb(0,0,0) ));
			this.fr_fuel_consumtion_rate.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fr_fuel_consumtion_rate.DefaultCellStyle.Format = "###0.00";//;-###0.00;###0.00";
            this.fr_fuel_consumtion_rate.Mask = "###0.00";
			this.fr_fuel_consumtion_rate.HeaderText = "Consumption \n(litre/100k)";
			this.fr_fuel_consumtion_rate.Name = "fr_fuel_consumtion_rate";
			this.fr_fuel_consumtion_rate.Width = 85;
            //this.fr_fuel_consumtion_rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.grid.Columns.Add(fr_fuel_consumtion_rate);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.SystemColors.ButtonFace;//?.ColorTranslator.FromWin32(80269524);
			this.Controls.Add(grid);
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SizeChanged += new System.EventHandler(DFuelRates2001_SizeChanged);
		}

        void DFuelRates2001_SizeChanged(object sender, System.EventArgs e)
        {
            this.grid.Width = this.Width - 120;
            this.grid.Height = this.Height;
        }
		#endregion

	}
}
