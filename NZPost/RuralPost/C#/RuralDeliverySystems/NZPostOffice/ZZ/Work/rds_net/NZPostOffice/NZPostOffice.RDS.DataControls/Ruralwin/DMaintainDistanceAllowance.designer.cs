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
            this.alt_key = new Metex.Windows.DataGridViewEntityComboColumn();
            this.ca_effective_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.ca_var1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_dist_day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_hrs_wk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_rate = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn();
            this.var_id = new Metex.Windows.DataGridViewEntityComboColumn();
            this.ca_costs_covered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_annual_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_approved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ca_paid_to_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.ca_doc_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_row_changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_wks_yr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_fuel_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_ruc_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_carrier_pa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_repairs_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_licence_pa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_tyres_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_allowance_pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_insurance_pa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var_ror_pa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.MaintainVehAllowance);
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
            this.total_amount,
            this.ca_approved,
            this.ca_paid_to_date,
            this.ca_doc_description,
            this.ca_notes,
            this.ca_row_changed,
            this.alt_wks_yr,
            this.alt_acc,
            this.alt_fuel_pk,
            this.alt_ruc_pk,
            this.var_carrier_pa,
            this.var_repairs_pk,
            this.var_licence_pa,
            this.var_tyres_pk,
            this.var_allowance_pk,
            this.var_insurance_pa,
            this.var_ror_pa});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(833, 251);
            this.grid.TabIndex = 0;
            this.grid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_Validating);
            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(this.grid_CurrentCellDirtyStateChanged);
            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
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
            this.alt_key.DataPropertyName = "AltKey";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = null;
            this.alt_key.DefaultCellStyle = dataGridViewCellStyle2;
            this.alt_key.DropDownWidth = 210;
            this.alt_key.HeaderText = "Allowance";
            this.alt_key.Name = "alt_key";
            this.alt_key.ReadOnly = true;
            // 
            // ca_effective_date
            // 
            this.ca_effective_date.DataPropertyName = "EffectiveDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ca_var1.DefaultCellStyle = dataGridViewCellStyle4;
            this.ca_var1.HeaderText = "Days per wk";
            this.ca_var1.Name = "ca_var1";
            this.ca_var1.Width = 50;
            // 
            // ca_dist_day
            // 
            this.ca_dist_day.DataPropertyName = "CaDistDay";
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
            this.var_id.DataPropertyName = "VarId";
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_id.DefaultCellStyle = dataGridViewCellStyle8;
            this.var_id.DropDownWidth = 210;
            this.var_id.HeaderText = "Vehicle Type";
            this.var_id.Name = "var_id";
            this.var_id.ReadOnly = true;
            this.var_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ca_costs_covered
            // 
            this.ca_costs_covered.DataPropertyName = "CaCostsCovered";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ca_costs_covered.DefaultCellStyle = dataGridViewCellStyle9;
            this.ca_costs_covered.HeaderText = "Costs";
            this.ca_costs_covered.Name = "ca_costs_covered";
            this.ca_costs_covered.Width = 30;
            // 
            // ca_annual_amount
            // 
            this.ca_annual_amount.DataPropertyName = "AnnualAmount";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.Format = "##,###.00";
            dataGridViewCellStyle10.NullValue = "0.00";
            this.ca_annual_amount.DefaultCellStyle = dataGridViewCellStyle10;
            this.ca_annual_amount.HeaderText = "Annual Amount";
            this.ca_annual_amount.Name = "ca_annual_amount";
            this.ca_annual_amount.Width = 73;
            // 
            // total_amount
            // 
            this.total_amount.DataPropertyName = "TotalAmount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.Format = "##,###.00";
            dataGridViewCellStyle11.NullValue = "0.00";
            this.total_amount.DefaultCellStyle = dataGridViewCellStyle11;
            this.total_amount.HeaderText = "Total Amount";
            this.total_amount.Name = "total_amount";
            this.total_amount.ReadOnly = true;
            this.total_amount.Width = 73;
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
            dataGridViewCellStyle13.Format = "dd/MM/yy";
            dataGridViewCellStyle13.NullValue = "00/00/00";
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
            // ca_doc_description
            // 
            this.ca_doc_description.DataPropertyName = "DocDescription";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ca_doc_description.DefaultCellStyle = dataGridViewCellStyle14;
            this.ca_doc_description.HeaderText = "Document Description";
            this.ca_doc_description.Name = "ca_doc_description";
            this.ca_doc_description.Width = 120;
            // 
            // ca_notes
            // 
            this.ca_notes.DataPropertyName = "Notes";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_notes.DefaultCellStyle = dataGridViewCellStyle15;
            this.ca_notes.HeaderText = "Notes";
            this.ca_notes.Name = "ca_notes";
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
            // alt_fuel_pk
            // 
            this.alt_fuel_pk.DataPropertyName = "AltFuelPk";
            this.alt_fuel_pk.HeaderText = "FuelPk";
            this.alt_fuel_pk.Name = "alt_fuel_pk";
            this.alt_fuel_pk.Visible = false;
            this.alt_fuel_pk.Width = 30;
            // 
            // alt_ruc_pk
            // 
            this.alt_ruc_pk.DataPropertyName = "AltRucPk";
            this.alt_ruc_pk.HeaderText = "RucPk";
            this.alt_ruc_pk.Name = "alt_ruc_pk";
            this.alt_ruc_pk.Visible = false;
            this.alt_ruc_pk.Width = 30;
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

        void grid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // This gets around a problem where the user has entered one of the
            // fields then cleared it and wants to move on.  Without this,
            // the focus would stay in the field without 'saying' anything about why.
            string column;
            column = this.grid.CurrentColumnName;
            if (column == "alt_key" || column == "ca_effective_date" || column == "ca_var1"
                || column == "ca_hrs_wk" || column == "ca_dist_day")
            {
                object value1 = this.grid.CurrentCell.EditedFormattedValue;
                if (value1 == null || (string)value1 == "")
                    MessageBox.Show("        Please enter a value.        ", ""
                                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        void set_row_readability()
        {
            int nRows = grid.RowCount;
            for (int i = 0; i < nRows; i++)
            {
                //if(isNull( ca_paid_to_date ) ,0,1)
                if (grid.Rows[i].Cells["ca_paid_to_date"].Value == null)
                {
                    grid.Rows[i].Cells["ca_effective_date"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_notes"].ReadOnly = false;
                    grid.Rows[i].Cells["alt_key"].ReadOnly = true;

                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = false;
                    //grid.Rows[i].Cells["ca_paid_to_date"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_paid_to_date"].ReadOnly = true;

                }
                else
                {
                    grid.Rows[i].Cells["ca_effective_date"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_notes"].ReadOnly = true;
                    grid.Rows[i].Cells["alt_key"].ReadOnly = true;

                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_paid_to_date"].ReadOnly = true;
                }
            }
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (grid.RowCount <= 0)
                return;

            for (int i = 0; i < grid.RowCount; i++)
            {
                //if(isNull( ca_paid_to_date ) ,0,1)
                if (grid.Rows[i].Cells["ca_paid_to_date"].Value == null)
                {
                    grid.Rows[i].Cells["ca_effective_date"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_notes"].ReadOnly = false;
                    grid.Rows[i].Cells["alt_key"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_paid_to_date"].ReadOnly = true;

                }
                else
                {
                    grid.Rows[i].Cells["ca_effective_date"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_notes"].ReadOnly = true;
                    grid.Rows[i].Cells["alt_key"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_paid_to_date"].ReadOnly = true;
                }

                //if(ca_approved = "Y",1,0)
                if (grid.Rows[i].Cells["ca_approved"].Value != null
                    && grid.Rows[i].Cells["ca_approved"].Value.ToString() == "Y")
                {
                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_annual_amount"].Style.BackColor = System.Drawing.SystemColors.Control;
                }
                else
                {
                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_annual_amount"].Style.BackColor = System.Drawing.Color.White;
                }

                //if(DESCRIBE("st_protect_confirm.text")="Y", 1, if( isnull(ca_paid_to_date ),0,if(ca_approved = "Y",1,0))) 
                if (this.st_protect_confirm.Text == "Y")
                {
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = true;
                }
                else if (grid.Rows[i].Cells["ca_paid_to_date"].Value == null)
                {
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = false;
                }
                else if (grid.Rows[i].Cells["ca_approved"].Value != null 
                         && grid.Rows[i].Cells["ca_approved"].Value.ToString() == "Y")
                {
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = true;
                }
                else
                {
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = false;
                }
            }
        }
        #endregion

        private Metex.Windows.DataGridViewEntityComboColumn alt_key;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn ca_effective_date;
        private DataGridViewTextBoxColumn ca_var1;
        private DataGridViewTextBoxColumn ca_dist_day;
        private DataGridViewTextBoxColumn ca_hrs_wk;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn alt_rate;
        private Metex.Windows.DataGridViewEntityComboColumn var_id;
        private DataGridViewTextBoxColumn ca_costs_covered;
        private DataGridViewTextBoxColumn ca_annual_amount;
        private DataGridViewTextBoxColumn total_amount;
        private DataGridViewCheckBoxColumn ca_approved;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn ca_paid_to_date;
        private DataGridViewTextBoxColumn ca_doc_description;
        private DataGridViewTextBoxColumn ca_notes;
        private DataGridViewTextBoxColumn ca_row_changed;
        private DataGridViewTextBoxColumn alt_wks_yr;
        private DataGridViewTextBoxColumn alt_acc;
        private DataGridViewTextBoxColumn alt_fuel_pk;
        private DataGridViewTextBoxColumn alt_ruc_pk;
        private DataGridViewTextBoxColumn var_carrier_pa;
        private DataGridViewTextBoxColumn var_repairs_pk;
        private DataGridViewTextBoxColumn var_licence_pa;
        private DataGridViewTextBoxColumn var_tyres_pk;
        private DataGridViewTextBoxColumn var_allowance_pk;
        private DataGridViewTextBoxColumn var_insurance_pa;
        private DataGridViewTextBoxColumn var_ror_pa;







    }
}
