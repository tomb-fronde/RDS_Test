using System;
using System.Windows.Forms;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB Allowances 9-Mar-2021: New

    partial class DMaintainDistanceAllowance
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label st_title;
        private System.Windows.Forms.Label st_protect_confirm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Metex.Windows.DataEntityGrid grid;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.st_title = new System.Windows.Forms.Label();
            this.st_protect_confirm = new System.Windows.Forms.Label();
            this.alt_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_effective_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.ca_var1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_dist_day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_hrs_wk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_rate = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn();
            this.var_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_costs_covered = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ca_annual_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.net_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_approved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ca_paid_to_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.ca_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_doc_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_row_changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_wks_yr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_fuel_use_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_fuel_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_ruc_rate_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_carrier_pa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_repairs_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_licence_pa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_tyres_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_allowance_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_insurance_pa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_ror_pa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calc_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initial_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initial_net_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.MaintainAllowanceV2);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alt_key,
            this.ca_effective_date,
            this.ca_var1,
            this.ca_dist_day,
            this.ca_hrs_wk,
            this.alt_rate,
            this.var_id,
            this.ca_costs_covered,
            this.ca_annual_amount,
            this.net_amount,
            this.ca_approved,
            this.ca_paid_to_date,
            this.ca_notes,
            this.ca_doc_description,
            this.ca_row_changed,
            this.alt_wks_yr,
            this.alt_acc,
            this.var_fuel_use_pk,
            this.var_fuel_rate,
            this.var_ruc_rate_pk,
            this.var_carrier_pa,
            this.var_repairs_pk,
            this.var_licence_pa,
            this.var_tyres_pk,
            this.var_allowance_pk,
            this.var_insurance_pa,
            this.var_ror_pa,
            this.calc_amount,
            this.initial_amount,
            this.initial_net_amount});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(833, 251);
            this.grid.TabIndex = 0;
            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(this.grid_CurrentCellDirtyStateChanged);
            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // st_title
            // 
            this.st_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_title.Location = new System.Drawing.Point(0, 0);
            this.st_title.Name = "st_title";
            this.st_title.Size = new System.Drawing.Size(638, 14);
            this.st_title.TabIndex = 1;
            this.st_title.Text = "Renewal:";
            // 
            // st_protect_confirm
            // 
            this.st_protect_confirm.Location = new System.Drawing.Point(0, 0);
            this.st_protect_confirm.Name = "st_protect_confirm";
            this.st_protect_confirm.Size = new System.Drawing.Size(10, 14);
            this.st_protect_confirm.TabIndex = 2;
            this.st_protect_confirm.Text = "N";
            this.st_protect_confirm.Visible = false;
            // 
            // alt_key
            // 
            this.alt_key.DataPropertyName = "AltDescription";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.alt_key.DefaultCellStyle = dataGridViewCellStyle2;
            this.alt_key.HeaderText = "Allowance";
            this.alt_key.Name = "alt_key";
            this.alt_key.ReadOnly = true;
            this.alt_key.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.alt_key.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ca_effective_date
            // 
            this.ca_effective_date.DataPropertyName = "EffectiveDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            dataGridViewCellStyle3.NullValue = "00/00/0000";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_effective_date.DefaultCellStyle = dataGridViewCellStyle3;
            this.ca_effective_date.HeaderText = "Effective Date";
            this.ca_effective_date.IncludeLiterals = false;
            this.ca_effective_date.IncludePrompt = false;
            this.ca_effective_date.Mask = null;
            this.ca_effective_date.Name = "ca_effective_date";
            this.ca_effective_date.PromptChar = '\0';
            this.ca_effective_date.ValidatingType = null;
            this.ca_effective_date.Width = 70;
            // 
            // ca_var1
            // 
            this.ca_var1.DataPropertyName = "CaVar1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ca_var1.DefaultCellStyle = dataGridViewCellStyle4;
            this.ca_var1.HeaderText = "Days per yr";
            this.ca_var1.Name = "ca_var1";
            this.ca_var1.Width = 50;
            // 
            // ca_dist_day
            // 
            this.ca_dist_day.DataPropertyName = "CaDistDay";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ca_dist_day.DefaultCellStyle = dataGridViewCellStyle5;
            this.ca_dist_day.HeaderText = "Distance per Day";
            this.ca_dist_day.Name = "ca_dist_day";
            this.ca_dist_day.Width = 50;
            // 
            // ca_hrs_wk
            // 
            this.ca_hrs_wk.DataPropertyName = "CaHrsWk";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ca_hrs_wk.DefaultCellStyle = dataGridViewCellStyle6;
            this.ca_hrs_wk.HeaderText = "Hours per Wk";
            this.ca_hrs_wk.Name = "ca_hrs_wk";
            this.ca_hrs_wk.Width = 50;
            // 
            // alt_rate
            // 
            this.alt_rate.DataPropertyName = "AltRate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.alt_rate.DefaultCellStyle = dataGridViewCellStyle7;
            this.alt_rate.HeaderText = "Hourly Rate";
            this.alt_rate.IncludeLiterals = false;
            this.alt_rate.IncludePrompt = false;
            this.alt_rate.Mask = null;
            this.alt_rate.Name = "alt_rate";
            this.alt_rate.PromptChar = '\0';
            this.alt_rate.ReadOnly = true;
            this.alt_rate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.alt_rate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.alt_rate.ValidatingType = null;
            this.alt_rate.Width = 50;
            // 
            // var_id
            // 
            this.var_id.DataPropertyName = "VarDescription";
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_id.DefaultCellStyle = dataGridViewCellStyle8;
            this.var_id.HeaderText = "Vehicle Type";
            this.var_id.Name = "var_id";
            this.var_id.ReadOnly = true;
            this.var_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.var_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ca_costs_covered
            // 
            this.ca_costs_covered.DataPropertyName = "CaCostsCovered";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.NullValue = false;
            this.ca_costs_covered.DefaultCellStyle = dataGridViewCellStyle9;
            this.ca_costs_covered.FalseValue = "N";
            this.ca_costs_covered.HeaderText = "Costs Covered";
            this.ca_costs_covered.Name = "ca_costs_covered";
            this.ca_costs_covered.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_costs_covered.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ca_costs_covered.TrueValue = "Y";
            this.ca_costs_covered.Width = 30;
            // 
            // ca_annual_amount
            // 
            this.ca_annual_amount.DataPropertyName = "AnnualAmount";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.Format = "$#,##0.00;$-#,##0.00";
            this.ca_annual_amount.DefaultCellStyle = dataGridViewCellStyle10;
            this.ca_annual_amount.HeaderText = "Annual   Amount";
            this.ca_annual_amount.Name = "ca_annual_amount";
            this.ca_annual_amount.ReadOnly = true;
            this.ca_annual_amount.Width = 73;
            // 
            // net_amount
            // 
            this.net_amount.DataPropertyName = "NetAmount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.Format = "$#,##0.00;$-#,##0.00";
            this.net_amount.DefaultCellStyle = dataGridViewCellStyle11;
            this.net_amount.HeaderText = "   Net   Amount";
            this.net_amount.Name = "net_amount";
            this.net_amount.ReadOnly = true;
            this.net_amount.Width = 73;
            // 
            // ca_approved
            // 
            this.ca_approved.DataPropertyName = "Approved";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.NullValue = false;
            this.ca_approved.DefaultCellStyle = dataGridViewCellStyle12;
            this.ca_approved.FalseValue = "N";
            this.ca_approved.HeaderText = "Approved";
            this.ca_approved.Name = "ca_approved";
            this.ca_approved.TrueValue = "Y";
            this.ca_approved.Width = 60;
            // 
            // ca_paid_to_date
            // 
            this.ca_paid_to_date.DataPropertyName = "PaidToDate";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.Format = "dd/MM/yyyy";
            dataGridViewCellStyle13.NullValue = "00/00/0000";
            this.ca_paid_to_date.DefaultCellStyle = dataGridViewCellStyle13;
            this.ca_paid_to_date.HeaderText = "Paid to Date";
            this.ca_paid_to_date.IncludeLiterals = false;
            this.ca_paid_to_date.IncludePrompt = false;
            this.ca_paid_to_date.Mask = null;
            this.ca_paid_to_date.Name = "ca_paid_to_date";
            this.ca_paid_to_date.PromptChar = '\0';
            this.ca_paid_to_date.ReadOnly = true;
            this.ca_paid_to_date.ValidatingType = null;
            this.ca_paid_to_date.Width = 70;
            // 
            // ca_notes
            // 
            this.ca_notes.DataPropertyName = "Notes";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_notes.DefaultCellStyle = dataGridViewCellStyle14;
            this.ca_notes.HeaderText = "Notes";
            this.ca_notes.Name = "ca_notes";
            // 
            // ca_doc_description
            // 
            this.ca_doc_description.DataPropertyName = "DocDescription";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ca_doc_description.DefaultCellStyle = dataGridViewCellStyle15;
            this.ca_doc_description.HeaderText = "Doc Description";
            this.ca_doc_description.Name = "ca_doc_description";
            this.ca_doc_description.Width = 120;
            // 
            // ca_row_changed
            // 
            this.ca_row_changed.DataPropertyName = "RowChanged";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_row_changed.DefaultCellStyle = dataGridViewCellStyle16;
            this.ca_row_changed.HeaderText = "Row Changed";
            this.ca_row_changed.Name = "ca_row_changed";
            this.ca_row_changed.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ca_row_changed.Visible = false;
            this.ca_row_changed.Width = 20;
            // 
            // alt_wks_yr
            // 
            this.alt_wks_yr.DataPropertyName = "AltWksYr";
            this.alt_wks_yr.HeaderText = "WksYr";
            this.alt_wks_yr.Name = "alt_wks_yr";
            this.alt_wks_yr.Visible = false;
            this.alt_wks_yr.Width = 30;
            // 
            // alt_acc
            // 
            this.alt_acc.DataPropertyName = "AltAcc";
            this.alt_acc.HeaderText = "Acc%";
            this.alt_acc.Name = "alt_acc";
            this.alt_acc.Visible = false;
            this.alt_acc.Width = 30;
            // 
            // var_fuel_use_pk
            // 
            this.var_fuel_use_pk.DataPropertyName = "VarFuelUsePk";
            this.var_fuel_use_pk.HeaderText = "FuelUsePk";
            this.var_fuel_use_pk.Name = "var_fuel_use_pk";
            this.var_fuel_use_pk.Visible = false;
            this.var_fuel_use_pk.Width = 30;
            // 
            // var_fuel_rate
            // 
            this.var_fuel_rate.DataPropertyName = "VarFuelRate";
            this.var_fuel_rate.HeaderText = "FuelRate";
            this.var_fuel_rate.Name = "var_fuel_rate";
            this.var_fuel_rate.Visible = false;
            // 
            // var_ruc_rate_pk
            // 
            this.var_ruc_rate_pk.DataPropertyName = "VarRucRatePk";
            this.var_ruc_rate_pk.HeaderText = "RucRatePk";
            this.var_ruc_rate_pk.Name = "var_ruc_rate_pk";
            this.var_ruc_rate_pk.Visible = false;
            // 
            // var_carrier_pa
            // 
            this.var_carrier_pa.DataPropertyName = "VarCarrierPa";
            this.var_carrier_pa.HeaderText = "Carrier";
            this.var_carrier_pa.Name = "var_carrier_pa";
            this.var_carrier_pa.Visible = false;
            this.var_carrier_pa.Width = 30;
            // 
            // var_repairs_pk
            // 
            this.var_repairs_pk.DataPropertyName = "VarRepairsPk";
            this.var_repairs_pk.HeaderText = "Repairs";
            this.var_repairs_pk.Name = "var_repairs_pk";
            this.var_repairs_pk.Visible = false;
            this.var_repairs_pk.Width = 30;
            // 
            // var_licence_pa
            // 
            this.var_licence_pa.DataPropertyName = "VarLicencePa";
            this.var_licence_pa.HeaderText = "Licence";
            this.var_licence_pa.Name = "var_licence_pa";
            this.var_licence_pa.Visible = false;
            this.var_licence_pa.Width = 30;
            // 
            // var_tyres_pk
            // 
            this.var_tyres_pk.DataPropertyName = "VarTyresPk";
            this.var_tyres_pk.HeaderText = "Tyres";
            this.var_tyres_pk.Name = "var_tyres_pk";
            this.var_tyres_pk.Visible = false;
            this.var_tyres_pk.Width = 30;
            // 
            // var_allowance_pk
            // 
            this.var_allowance_pk.DataPropertyName = "VarAllowancePk";
            this.var_allowance_pk.HeaderText = "Allowance";
            this.var_allowance_pk.Name = "var_allowance_pk";
            this.var_allowance_pk.Visible = false;
            this.var_allowance_pk.Width = 30;
            // 
            // var_insurance_pa
            // 
            this.var_insurance_pa.DataPropertyName = "VarInsurancePa";
            this.var_insurance_pa.HeaderText = "Insurance";
            this.var_insurance_pa.Name = "var_insurance_pa";
            this.var_insurance_pa.Visible = false;
            this.var_insurance_pa.Width = 30;
            // 
            // var_ror_pa
            // 
            this.var_ror_pa.DataPropertyName = "VarRorPa";
            this.var_ror_pa.HeaderText = "Ror";
            this.var_ror_pa.Name = "var_ror_pa";
            this.var_ror_pa.Visible = false;
            this.var_ror_pa.Width = 30;
            // 
            // calc_amount
            // 
            this.calc_amount.DataPropertyName = "CalcAmount";
            this.calc_amount.HeaderText = "CalcAmount";
            this.calc_amount.Name = "calc_amount";
            this.calc_amount.Visible = false;
            this.calc_amount.Width = 50;
            // 
            // initial_amount
            // 
            this.initial_amount.DataPropertyName = "InitialAmount";
            this.initial_amount.HeaderText = "InitialAmount";
            this.initial_amount.Name = "initial_amount";
            this.initial_amount.ReadOnly = true;
            this.initial_amount.Visible = false;
            // 
            // initial_net_amount
            // 
            this.initial_net_amount.DataPropertyName = "InitialNetAmount";
            this.initial_net_amount.HeaderText = "InitialNetAmount";
            this.initial_net_amount.Name = "initial_net_amount";
            this.initial_net_amount.ReadOnly = true;
            this.initial_net_amount.Visible = false;
            // 
            // DMaintainDistanceAllowance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.st_title);
            this.Controls.Add(this.st_protect_confirm);
            this.Name = "DMaintainDistanceAllowance";
            this.Size = new System.Drawing.Size(833, 251);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        // TJB 19-June-2021: Disabled; may want to t5ab over "required" fields without
        // being told to provide a value, especially during transition to calculated
        // annual amounts.
        void grid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // This gets around a problem where the user has entered one of the
            // fields then cleared it and wants to move on.  Without this,
            // the focus would stay in the field without 'saying' anything about why.
            string column;
            column = this.grid.CurrentColumnName;
            int nRow = this.grid.CurrentCell.RowIndex;
            string row_changed = (string)this.grid.Rows[nRow].Cells["ca_row_changed"].Value;
            if (column == "alt_key" || column == "ca_effective_date" || column == "ca_var1"
                || column == "ca_hrs_wk" || column == "ca_dist_day")
            {
                object alt_key = this.grid.Rows[nRow].Cells["alt_key"].Value;
                object value1 = this.grid.CurrentCell.EditedFormattedValue;
                if ((value1 == null || (string)value1 == "") && (alt_key != null))
                {
                    // When a new record is created, row_changed for the row it was 
                    // generated from is set to 'Y' (it is set to 'X' in the new row itself)
                    // grid_validating is called twice - once for the new row and once for 
                    // the row the new one was generated from.  That row may be from the 
                    // time when allowance calculations were done offline and it may not 
                    // (legitimately) have any calculation factors (ca_var1 in particular).
                    // This check here avoids a warning message in those cases.
                    if (row_changed != "Y")
                    {
                        string column_type = "";
                        if (column == "alt_key") column_type = "an allowance type";
                        else if (column == "ca_effective_date") column_type = "effective date";
                        else if (column == "ca_var1") column_type = "a days per year";
                        else if (column == "ca_hrs_wk") column_type = "an hours per week";
                        else if (column == "ca_dist_day") column_type = "a distance per day";
                        MessageBox.Show("    Please enter " + column_type + " value.    ", ""
                                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // SetGridCellFocus(int pRow, string pColumnName, bool pValue
                        SetGridCellFocus(nRow, column, true);
                    }
                }
            }
            // row_changed set to 'Y' is used here to set the previous row readonly
            // It is placed here because the column identified may not be one of those
            // identified above.
            if (row_changed == "Y")
            {
                // Put row_changed back to the default 'not changed' ('X')
                this.grid.Rows[nRow].Cells["ca_row_changed"].Value = "X";
                if (!(this.grid.Rows[nRow].Cells["ca_effective_date"].ReadOnly))
                    set_row_readonly(nRow, true);
            }
        }

        public void set_row_readonly(int pRow, bool pValue)
        {
            System.Drawing.Color ReadonlyColour, ReadWriteColour;
            ReadonlyColour = System.Drawing.SystemColors.Control;
            ReadWriteColour = System.Drawing.SystemColors.Window;
            DateTime? paid;

            // These are not modifiable
            this.grid.Rows[pRow].Cells["alt_key"].ReadOnly = true;
            this.grid.Rows[pRow].Cells["alt_key"].Style.BackColor = ReadonlyColour;
            this.grid.Rows[pRow].Cells["alt_rate"].ReadOnly = true;
            this.grid.Rows[pRow].Cells["alt_rate"].Style.BackColor = ReadonlyColour;
            this.grid.Rows[pRow].Cells["var_id"].ReadOnly = true;
            this.grid.Rows[pRow].Cells["var_id"].Style.BackColor = ReadonlyColour;
            this.grid.Rows[pRow].Cells["ca_annual_amount"].ReadOnly = true;
            this.grid.Rows[pRow].Cells["ca_annual_amount"].Style.BackColor = ReadonlyColour;
            this.grid.Rows[pRow].Cells["net_amount"].ReadOnly = true;
            this.grid.Rows[pRow].Cells["net_amount"].Style.BackColor = ReadonlyColour;
            this.grid.Rows[pRow].Cells["ca_paid_to_date"].ReadOnly = true;
            this.grid.Rows[pRow].Cells["ca_paid_to_date"].Style.BackColor = ReadonlyColour;

            // These may be if set not readonly
            if (pValue == true)
            {
                //for (int i = 0; i < this.grid.ColumnCount; i++)
                //{
                //    this.grid.Rows[pRow].Cells[i].ReadOnly = pValue;
                //    this.grid.Rows[pRow].Cells[i].Style.BackColor = ReadonlyColour;
                //}
                this.grid.Rows[pRow].Cells["ca_effective_date"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["ca_effective_date"].Style.BackColor = ReadonlyColour;
                this.grid.Rows[pRow].Cells["ca_var1"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["ca_var1"].Style.BackColor = ReadonlyColour;
                this.grid.Rows[pRow].Cells["ca_hrs_wk"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["ca_hrs_wk"].Style.BackColor = ReadonlyColour;
                this.grid.Rows[pRow].Cells["ca_dist_day"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["ca_dist_day"].Style.BackColor = ReadonlyColour;
                this.grid.Rows[pRow].Cells["ca_costs_covered"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["ca_costs_covered"].Style.BackColor = ReadonlyColour;
                this.grid.Rows[pRow].Cells["ca_notes"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["ca_notes"].Style.BackColor = ReadonlyColour;
                this.grid.Rows[pRow].Cells["ca_doc_description"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["ca_doc_description"].Style.BackColor = ReadonlyColour;
                this.grid.Rows[pRow].Cells["ca_approved"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["ca_approved"].Style.BackColor = ReadonlyColour;

            }
            if (pValue == false)
            {
                this.grid.Rows[pRow].Cells["ca_effective_date"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_effective_date"].Style.BackColor = ReadWriteColour;
                this.grid.Rows[pRow].Cells["ca_var1"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_var1"].Style.BackColor = ReadWriteColour;
                this.grid.Rows[pRow].Cells["ca_hrs_wk"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_hrs_wk"].Style.BackColor = ReadWriteColour;
                this.grid.Rows[pRow].Cells["ca_dist_day"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_dist_day"].Style.BackColor = ReadWriteColour;
                this.grid.Rows[pRow].Cells["ca_costs_covered"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_costs_covered"].Style.BackColor = ReadWriteColour;
                this.grid.Rows[pRow].Cells["ca_notes"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_notes"].Style.BackColor = ReadWriteColour;
                this.grid.Rows[pRow].Cells["ca_doc_description"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_doc_description"].Style.BackColor = ReadWriteColour;
                this.grid.Rows[pRow].Cells["ca_approved"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_approved"].Style.BackColor = ReadWriteColour;

                // A paid allowance's Approved may not be changed
                paid = (DateTime?)this.grid.Rows[pRow].Cells["ca_paid_to_date"].Value;
                if (paid != null && paid > DateTime.MinValue)
                {
                    this.grid.Rows[pRow].Cells["ca_approved"].ReadOnly = true;
                    this.grid.Rows[pRow].Cells["ca_approved"].Style.BackColor = ReadonlyColour;
                }
            }
        }

        void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.grid.CurrentColumnName == "ca_paid_to_date")
            {
                //this.grid.EndEdit();
            }
        }

        private string stringValue(string value)
        {
            if (value == null)
                return "null";
            else if (value == "")
                return "empty";
            return value;
        }

        // TJB RPCR_017 July-2010
        // alt_key_err_count is a hack.  If the user sets the allowance type on the new record
        // then removes it, the 'syste,' still shows it as having the value (presumably the
        // error is that it isn't supposed to have a null value).  This code (grid_DataError)
        // is executed repeatedly waiting for the user to select an acceptable valu - the net
        // effect being that the user cannot tab away from the allowance type field (on the new
        // record).  This hack counts the number of times the user tries to tab away, and when 
        // that number is reached, forces the value to NULL and the 'error' doesn't recur, 
        // allowing the user to change focus away from the field.
        // There may be a better way to do this ...
        //
        // NOTE:
        //   1.  This code assumes the record at row 0 is the new record.  If this is changed
        //       eg the new record is added at the end of the list) the test of the nRow will 
        //       need to be changed.
        //   2.  It is important that the allowance type be set to null.  The system sometimes 
        //       tries to save the added record even when told to delete it.  The insert (of the
        //       new record) fails when the allowance type is null, and this failure is ignored 
        //       the code.  If the Allowance type is non-null, an invalid record may be saved 
        //       to the database.
        private int alt_key_err_count = 0;
        void grid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
        }
        void grid_DataError_Buggy(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            //   0    this.alt_key,
            //   1    this.ca_effective_date,
            //   2    this.ca_var1                  days_per_wk,
            //   3    this.ca_dist_day              distance,
            //   4    this.ca_hrs_wk                hrs_per_week,
            //   5    this.alt_rate                 hourly_rate,
            //   6    this.var_id                   Vehicle tye ID,
            //   7    this.ca_costs_covered
            //   8    this.ca_annual_amount,
            //   9    this.ca_approved,
            //  10    this.ca_paid_to_date,
            //  11    this.ca_doc_description
            //  12    this.ca_notes
            //  13    this.ca_row_changed,
            //  14    this.alt_wks_yr,
            //  15    this.alt_acc,
            //  16    this.alt_fuel_pk,
            //  17    this.alt_ruc_pk,
            //  18    this.var_carrier_pa,
            //  19    this.var_repairs_pk,
            //  20    this.var_licence_pa,
            //  21    this.var_tyres_pk,
            //  22    this.var_allowance_pk,
            //  23    this.var_insurance_pa,
            //  24    this.var_ror_pa});

            int nRow = e.RowIndex;
            int nCol = e.ColumnIndex;
            string column = grid.CurrentColumnName;
            string sAllowance = (string)grid.Rows[nRow].Cells["alt_key"].EditedFormattedValue;
            string sValue = (string)((DataGridView)sender).CurrentCell.EditedFormattedValue;
            sAllowance = stringValue(sAllowance);
            sValue = stringValue(sValue);
            
            if (grid.Rows[nRow].Cells["ca_paid_to_date"].Value != null)
            {
                e.Cancel = true;
            }
            if (column == "alt_key")
            {
                if (nRow == 0)
                {
                    alt_key_err_count++;
                    if (grid.Rows[nRow].Cells["alt_key"].Value == null
                        || alt_key_err_count >= 3)
                    {
                        grid.Rows[nRow].Cells["alt_key"].Value = null;
                        //this.grid.CancelEdit();
                        alt_key_err_count = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Allowance type '" + sAllowance + "' does not pass validation.\n"
                            + "Please enter a valid Allowance."
                            , "Distance Allowance Validation Error"
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
            else if (column == "ca_effective_date")
            {
                MessageBox.Show("The Effective Date does not pass validation.\n"
                        + "Allowance type '" + sAllowance + "'\n"
                        + "Value " + sValue + "\n"
                        + "Please enter a valid date."
                        , "Distance Allowance Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (column == "ca_var1")
            {
                MessageBox.Show("Days/week does not pass validation.\n"
                        + "Allowance type '" + sAllowance + "'\n"
                        + "Value " + sValue + "\n"
                        + "Please enter a valid numeric value."
                        , "Distance Allowance Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (column == "ca_dist_day")
            {
                MessageBox.Show("Distance/day does not pass validation.\n"
                        + "Allowance type '" + sAllowance + "'\n"
                        + "Value " + sValue + "\n"
                        + "Please enter a valid numeric value."
                        , "Distance Allowance Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (column == "ca_hrs_wk")
            {
                MessageBox.Show("Hours/week does not pass validation.\n"
                        + "Allowance type '" + sAllowance + "'\n"
                        + "Value " + sValue + "\n"
                        + "Please enter a valid numeric value."
                        , "Distance Allowance Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (column == "ca_annual_amount")
            {
                MessageBox.Show("Annual Amount does not pass validation.\n"
                        + "Allowance type '" + sAllowance + "'\n"
                        + "Value " + sValue + "\n"
                        + "Please correct."
                        , "Distance Allowance Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
        #endregion

        private DataGridViewTextBoxColumn alt_key;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn ca_effective_date;
        private DataGridViewTextBoxColumn ca_var1;
        private DataGridViewTextBoxColumn ca_dist_day;
        private DataGridViewTextBoxColumn ca_hrs_wk;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn alt_rate;
        private DataGridViewTextBoxColumn var_id;
        private DataGridViewCheckBoxColumn ca_costs_covered;
        private DataGridViewTextBoxColumn ca_annual_amount;
        private DataGridViewTextBoxColumn net_amount;
        private DataGridViewCheckBoxColumn ca_approved;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn ca_paid_to_date;
        private DataGridViewTextBoxColumn ca_notes;
        private DataGridViewTextBoxColumn ca_doc_description;
        private DataGridViewTextBoxColumn ca_row_changed;
        private DataGridViewTextBoxColumn alt_wks_yr;
        private DataGridViewTextBoxColumn alt_acc;
        private DataGridViewTextBoxColumn var_fuel_use_pk;
        private DataGridViewTextBoxColumn var_fuel_rate;
        private DataGridViewTextBoxColumn var_ruc_rate_pk;
        private DataGridViewTextBoxColumn var_carrier_pa;
        private DataGridViewTextBoxColumn var_repairs_pk;
        private DataGridViewTextBoxColumn var_licence_pa;
        private DataGridViewTextBoxColumn var_tyres_pk;
        private DataGridViewTextBoxColumn var_allowance_pk;
        private DataGridViewTextBoxColumn var_insurance_pa;
        private DataGridViewTextBoxColumn var_ror_pa;
        private DataGridViewTextBoxColumn calc_amount;
        private DataGridViewTextBoxColumn initial_amount;
        private DataGridViewTextBoxColumn initial_net_amount;
    }
}
