namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DVehicleAllowanceRatesHistory
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

		private Metex.Windows.DataEntityGrid grid;
        public Metex.Windows.DataEntityGrid Grid
        {
            get
            {
                return grid;
            }
        }
		#region Component Designer generated code
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.var_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_fuel_use_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_fuel_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carrier_pa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repairs_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.licence_pa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tyres_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowance_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurance_pa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ror_pa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_ruc_rate_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_effective_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.var_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sQLCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sQLErrText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.VehicleAllowanceRatesHistory);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 40;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.var_id,
            this.var_description,
            this.var_fuel_use_pk,
            this.var_fuel_rate,
            this.carrier_pa,
            this.repairs_pk,
            this.licence_pa,
            this.tyres_pk,
            this.allowance_pk,
            this.insurance_pa,
            this.ror_pa,
            this.var_ruc_rate_pk,
            this.var_effective_date,
            this.var_notes,
            this.sQLCode,
            this.sQLErrText});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(1070, 252);
            this.grid.TabIndex = 0;
            // 
            // var_id
            // 
            this.var_id.DataPropertyName = "VarId";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.var_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.var_id.HeaderText = "ID";
            this.var_id.Name = "var_id";
            this.var_id.ReadOnly = true;
            this.var_id.Visible = false;
            this.var_id.Width = 36;
            // 
            // var_description
            // 
            this.var_description.DataPropertyName = "VarDescription";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.var_description.DefaultCellStyle = dataGridViewCellStyle3;
            this.var_description.HeaderText = "Description";
            this.var_description.Name = "var_description";
            this.var_description.ReadOnly = true;
            this.var_description.Width = 140;
            // 
            // var_fuel_use_pk
            // 
            this.var_fuel_use_pk.DataPropertyName = "VarFuelUsePk";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.var_fuel_use_pk.DefaultCellStyle = dataGridViewCellStyle4;
            this.var_fuel_use_pk.HeaderText = "Fuel Use 1000Km";
            this.var_fuel_use_pk.Name = "var_fuel_use_pk";
            this.var_fuel_use_pk.ReadOnly = true;
            this.var_fuel_use_pk.Width = 60;
            // 
            // var_fuel_rate
            // 
            this.var_fuel_rate.DataPropertyName = "VarFuelRate";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.var_fuel_rate.DefaultCellStyle = dataGridViewCellStyle5;
            this.var_fuel_rate.HeaderText = "Fuel Rate";
            this.var_fuel_rate.Name = "var_fuel_rate";
            this.var_fuel_rate.ReadOnly = true;
            this.var_fuel_rate.Width = 60;
            // 
            // carrier_pa
            // 
            this.carrier_pa.DataPropertyName = "VarCarrierPa";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.carrier_pa.DefaultCellStyle = dataGridViewCellStyle6;
            this.carrier_pa.HeaderText = "Carrier $ per Yr";
            this.carrier_pa.Name = "carrier_pa";
            this.carrier_pa.ReadOnly = true;
            this.carrier_pa.Width = 60;
            // 
            // repairs_pk
            // 
            this.repairs_pk.DataPropertyName = "VarRepairsPk";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.repairs_pk.DefaultCellStyle = dataGridViewCellStyle7;
            this.repairs_pk.HeaderText = "Repairs 1000Km";
            this.repairs_pk.Name = "repairs_pk";
            this.repairs_pk.ReadOnly = true;
            this.repairs_pk.Width = 60;
            // 
            // licence_pa
            // 
            this.licence_pa.DataPropertyName = "VarLicencePa";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.licence_pa.DefaultCellStyle = dataGridViewCellStyle8;
            this.licence_pa.HeaderText = "Licence $ per Yr";
            this.licence_pa.Name = "licence_pa";
            this.licence_pa.ReadOnly = true;
            this.licence_pa.Width = 60;
            // 
            // tyres_pk
            // 
            this.tyres_pk.DataPropertyName = "VarTyresPk";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.tyres_pk.DefaultCellStyle = dataGridViewCellStyle9;
            this.tyres_pk.HeaderText = "Tyres 1000Km";
            this.tyres_pk.Name = "tyres_pk";
            this.tyres_pk.ReadOnly = true;
            this.tyres_pk.Width = 60;
            // 
            // allowance_pk
            // 
            this.allowance_pk.DataPropertyName = "VarAllowancePk";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.allowance_pk.DefaultCellStyle = dataGridViewCellStyle10;
            this.allowance_pk.HeaderText = "Allowance 1000Km";
            this.allowance_pk.Name = "allowance_pk";
            this.allowance_pk.ReadOnly = true;
            this.allowance_pk.Width = 60;
            // 
            // insurance_pa
            // 
            this.insurance_pa.DataPropertyName = "VarInsurancePa";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.insurance_pa.DefaultCellStyle = dataGridViewCellStyle11;
            this.insurance_pa.HeaderText = "Insurance $ per Yr";
            this.insurance_pa.Name = "insurance_pa";
            this.insurance_pa.ReadOnly = true;
            this.insurance_pa.Width = 60;
            // 
            // ror_pa
            // 
            this.ror_pa.DataPropertyName = "VarRorPa";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.ror_pa.DefaultCellStyle = dataGridViewCellStyle12;
            this.ror_pa.HeaderText = "  ROR    $ per Yr";
            this.ror_pa.Name = "ror_pa";
            this.ror_pa.ReadOnly = true;
            this.ror_pa.Width = 60;
            // 
            // var_ruc_rate_pk
            // 
            this.var_ruc_rate_pk.DataPropertyName = "VarRucRatePk";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.var_ruc_rate_pk.DefaultCellStyle = dataGridViewCellStyle13;
            this.var_ruc_rate_pk.HeaderText = "Ruc Rate 1000Km";
            this.var_ruc_rate_pk.Name = "var_ruc_rate_pk";
            this.var_ruc_rate_pk.ReadOnly = true;
            this.var_ruc_rate_pk.Width = 60;
            // 
            // var_effective_date
            // 
            this.var_effective_date.DataPropertyName = "VarEffectiveDate";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.Format = "d";
            dataGridViewCellStyle14.NullValue = null;
            this.var_effective_date.DefaultCellStyle = dataGridViewCellStyle14;
            this.var_effective_date.HeaderText = "Effective Date";
            this.var_effective_date.IncludeLiterals = false;
            this.var_effective_date.IncludePrompt = false;
            this.var_effective_date.Mask = null;
            this.var_effective_date.Name = "var_effective_date";
            this.var_effective_date.PromptChar = '\0';
            this.var_effective_date.ReadOnly = true;
            this.var_effective_date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.var_effective_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.var_effective_date.ValidatingType = null;
            this.var_effective_date.Width = 70;
            // 
            // var_notes
            // 
            this.var_notes.DataPropertyName = "VarNotes";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            this.var_notes.DefaultCellStyle = dataGridViewCellStyle15;
            this.var_notes.HeaderText = "Notes";
            this.var_notes.Name = "var_notes";
            this.var_notes.ReadOnly = true;
            this.var_notes.Width = 220;
            // 
            // sQLCode
            // 
            this.sQLCode.DataPropertyName = "SQLCode";
            this.sQLCode.HeaderText = "SQLCode";
            this.sQLCode.Name = "sQLCode";
            this.sQLCode.ReadOnly = true;
            this.sQLCode.Visible = false;
            // 
            // sQLErrText
            // 
            this.sQLErrText.DataPropertyName = "SQLErrText";
            this.sQLErrText.HeaderText = "SQLErrText";
            this.sQLErrText.Name = "sQLErrText";
            this.sQLErrText.ReadOnly = true;
            this.sQLErrText.Visible = false;
            // 
            // DVehicleAllowanceRatesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.grid);
            this.Name = "DVehicleAllowanceRatesHistory";
            this.Size = new System.Drawing.Size(1070, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn alt_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_repairs_pk;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_licence_pa;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_tyres_pk;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_allowance_pk;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_insurance_pa;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_ror_pa;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_fuel_use_pk;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_fuel_rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn carrier_pa;
        private System.Windows.Forms.DataGridViewTextBoxColumn repairs_pk;
        private System.Windows.Forms.DataGridViewTextBoxColumn licence_pa;
        private System.Windows.Forms.DataGridViewTextBoxColumn tyres_pk;
        private System.Windows.Forms.DataGridViewTextBoxColumn allowance_pk;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurance_pa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ror_pa;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_ruc_rate_pk;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn var_effective_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn var_notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn sQLCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn sQLErrText;



    }
}
