namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DNonVehicleRates2001
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nvr_rates_effective_date = new System.Windows.Forms.TextBox();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.nvr_contract_start = new System.Windows.Forms.MaskedTextBox();
            this.nvr_wage_hourly_rate = new System.Windows.Forms.MaskedTextBox();
            this.nvr_vehicle_insurance_base_premium = new System.Windows.Forms.MaskedTextBox();
            this.nvr_public_liability_rate = new System.Windows.Forms.MaskedTextBox();
            this.nvr_carrier_risk_rate = new System.Windows.Forms.MaskedTextBox();
            this.nvr_acc_rate = new System.Windows.Forms.MaskedTextBox();
            this.nvr_acc_rate_amount = new System.Windows.Forms.MaskedTextBox();
            this.nvr_item_proc_rate_per_hr = new System.Windows.Forms.MaskedTextBox();
            this.nvr_accounting = new System.Windows.Forms.MaskedTextBox();
            this.nvr_telephone = new System.Windows.Forms.MaskedTextBox();
            this.nvr_sundries = new System.Windows.Forms.MaskedTextBox();
            this.nvr_uniform = new System.Windows.Forms.MaskedTextBox();
            this.nvr_frozen_indicator = new System.Windows.Forms.CheckBox();
            this.nvr_carrier_risk_rate_t = new System.Windows.Forms.Label();
            this.nvr_acc_rate_t = new System.Windows.Forms.Label();
            this.n_48089211 = new System.Windows.Forms.Label();
            this.nvr_item_proc_rate_per_hr_t = new System.Windows.Forms.Label();
            this.nvr_accounting_t = new System.Windows.Forms.Label();
            this.nvr_telephone_t = new System.Windows.Forms.Label();
            this.nvr_sundries_t = new System.Windows.Forms.Label();
            this.n_30149715 = new System.Windows.Forms.Label();
            this.nvr_frozen_indicator_t = new System.Windows.Forms.Label();
            this.rg_code_t = new System.Windows.Forms.Label();
            this.nvr_contract_start_t = new System.Windows.Forms.Label();
            this.nvr_wage_hourly_rate_t = new System.Windows.Forms.Label();
            this.nvr_vehicle_insurance_base_premium_t = new System.Windows.Forms.Label();
            this.nvr_public_liability_rate_t = new System.Windows.Forms.Label();
            this.n_2911981 = new System.Windows.Forms.Label();
            this.nvr_contract_end = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.NonVehicleRates2001);
            // 
            // nvr_rates_effective_date
            // 
            this.nvr_rates_effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrRatesEffectiveDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_rates_effective_date.Enabled = false;
            this.nvr_rates_effective_date.Font = new System.Drawing.Font("Arial", 8F);
            this.nvr_rates_effective_date.Location = new System.Drawing.Point(297, 432);
            this.nvr_rates_effective_date.Name = "nvr_rates_effective_date";
            this.nvr_rates_effective_date.Size = new System.Drawing.Size(96, 20);
            this.nvr_rates_effective_date.TabIndex = 0;
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.Location = new System.Drawing.Point(177, 8);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(161, 21);
            this.rg_code.TabIndex = 10;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            // 
            // nvr_contract_start
            // 
            this.nvr_contract_start.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrContractStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_contract_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_contract_start.Location = new System.Drawing.Point(177, 36);
            this.nvr_contract_start.Mask = "00/00/0000";
            this.nvr_contract_start.Name = "nvr_contract_start";
            this.nvr_contract_start.Size = new System.Drawing.Size(69, 20);
            this.nvr_contract_start.TabIndex = 20;
            // 
            // nvr_wage_hourly_rate
            // 
            this.nvr_wage_hourly_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrWageHourlyRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_wage_hourly_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_wage_hourly_rate.Location = new System.Drawing.Point(177, 64);
            this.nvr_wage_hourly_rate.Mask = "#,##0.00";
            this.nvr_wage_hourly_rate.Name = "nvr_wage_hourly_rate";
            this.nvr_wage_hourly_rate.Size = new System.Drawing.Size(60, 20);
            this.nvr_wage_hourly_rate.TabIndex = 40;
            this.nvr_wage_hourly_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_vehicle_insurance_base_premium
            // 
            this.nvr_vehicle_insurance_base_premium.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrVehicleInsuranceBasePremium", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_vehicle_insurance_base_premium.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_vehicle_insurance_base_premium.Location = new System.Drawing.Point(177, 90);
            this.nvr_vehicle_insurance_base_premium.Mask = "#,##0.00";
            this.nvr_vehicle_insurance_base_premium.Name = "nvr_vehicle_insurance_base_premium";
            this.nvr_vehicle_insurance_base_premium.Size = new System.Drawing.Size(60, 20);
            this.nvr_vehicle_insurance_base_premium.TabIndex = 50;
            this.nvr_vehicle_insurance_base_premium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_public_liability_rate
            // 
            this.nvr_public_liability_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrPublicLiabilityRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_public_liability_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_public_liability_rate.Location = new System.Drawing.Point(177, 117);
            this.nvr_public_liability_rate.Mask = "#,##0.00";
            this.nvr_public_liability_rate.Name = "nvr_public_liability_rate";
            this.nvr_public_liability_rate.Size = new System.Drawing.Size(60, 20);
            this.nvr_public_liability_rate.TabIndex = 60;
            this.nvr_public_liability_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_carrier_risk_rate
            // 
            this.nvr_carrier_risk_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrCarrierRiskRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_carrier_risk_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_carrier_risk_rate.Location = new System.Drawing.Point(177, 144);
            this.nvr_carrier_risk_rate.Mask = "#,##0.00";
            this.nvr_carrier_risk_rate.Name = "nvr_carrier_risk_rate";
            this.nvr_carrier_risk_rate.Size = new System.Drawing.Size(60, 20);
            this.nvr_carrier_risk_rate.TabIndex = 70;
            this.nvr_carrier_risk_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_acc_rate
            // 
            this.nvr_acc_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrAccRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_acc_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_acc_rate.Location = new System.Drawing.Point(177, 170);
            this.nvr_acc_rate.Mask = "###0.00";
            this.nvr_acc_rate.Name = "nvr_acc_rate";
            this.nvr_acc_rate.Size = new System.Drawing.Size(38, 20);
            this.nvr_acc_rate.TabIndex = 80;
            this.nvr_acc_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_acc_rate_amount
            // 
            this.nvr_acc_rate_amount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrAccRateAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_acc_rate_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_acc_rate_amount.Location = new System.Drawing.Point(177, 198);
            this.nvr_acc_rate_amount.Mask = "###,##0.00";
            this.nvr_acc_rate_amount.Name = "nvr_acc_rate_amount";
            this.nvr_acc_rate_amount.Size = new System.Drawing.Size(60, 20);
            this.nvr_acc_rate_amount.TabIndex = 90;
            this.nvr_acc_rate_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_item_proc_rate_per_hr
            // 
            this.nvr_item_proc_rate_per_hr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrItemProcRatePerHr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_item_proc_rate_per_hr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_item_proc_rate_per_hr.Location = new System.Drawing.Point(177, 226);
            this.nvr_item_proc_rate_per_hr.Mask = "####0";
            this.nvr_item_proc_rate_per_hr.Name = "nvr_item_proc_rate_per_hr";
            this.nvr_item_proc_rate_per_hr.Size = new System.Drawing.Size(46, 20);
            this.nvr_item_proc_rate_per_hr.TabIndex = 100;
            this.nvr_item_proc_rate_per_hr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_accounting
            // 
            this.nvr_accounting.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrAccounting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_accounting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_accounting.Location = new System.Drawing.Point(177, 253);
            this.nvr_accounting.Mask = "#,##0.00";
            this.nvr_accounting.Name = "nvr_accounting";
            this.nvr_accounting.Size = new System.Drawing.Size(60, 20);
            this.nvr_accounting.TabIndex = 110;
            this.nvr_accounting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_telephone
            // 
            this.nvr_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_telephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_telephone.Location = new System.Drawing.Point(177, 280);
            this.nvr_telephone.Mask = "#,##0.00";
            this.nvr_telephone.Name = "nvr_telephone";
            this.nvr_telephone.Size = new System.Drawing.Size(60, 20);
            this.nvr_telephone.TabIndex = 120;
            this.nvr_telephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_sundries
            // 
            this.nvr_sundries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrSundries", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_sundries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_sundries.Location = new System.Drawing.Point(177, 306);
            this.nvr_sundries.Mask = "#,##0.00";
            this.nvr_sundries.Name = "nvr_sundries";
            this.nvr_sundries.Size = new System.Drawing.Size(60, 20);
            this.nvr_sundries.TabIndex = 130;
            this.nvr_sundries.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_uniform
            // 
            this.nvr_uniform.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrUniform", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_uniform.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_uniform.Location = new System.Drawing.Point(177, 333);
            this.nvr_uniform.Mask = "###,##0.00";
            this.nvr_uniform.Name = "nvr_uniform";
            this.nvr_uniform.Size = new System.Drawing.Size(60, 20);
            this.nvr_uniform.TabIndex = 150;
            this.nvr_uniform.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_frozen_indicator
            // 
            this.nvr_frozen_indicator.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvr_frozen_indicator.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_frozen_indicator.Enabled = false;
            this.nvr_frozen_indicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_frozen_indicator.Location = new System.Drawing.Point(173, 373);
            this.nvr_frozen_indicator.Name = "nvr_frozen_indicator";
            this.nvr_frozen_indicator.Size = new System.Drawing.Size(17, 15);
            this.nvr_frozen_indicator.TabIndex = 0;
            this.nvr_frozen_indicator.ThreeState = true;
            // 
            // nvr_carrier_risk_rate_t
            // 
            this.nvr_carrier_risk_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_carrier_risk_rate_t.Location = new System.Drawing.Point(34, 144);
            this.nvr_carrier_risk_rate_t.Name = "nvr_carrier_risk_rate_t";
            this.nvr_carrier_risk_rate_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_carrier_risk_rate_t.TabIndex = 0;
            this.nvr_carrier_risk_rate_t.Text = "Carrier Risk ($ pa)";
            this.nvr_carrier_risk_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_acc_rate_t
            // 
            this.nvr_acc_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_acc_rate_t.Location = new System.Drawing.Point(34, 170);
            this.nvr_acc_rate_t.Name = "nvr_acc_rate_t";
            this.nvr_acc_rate_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_acc_rate_t.TabIndex = 0;
            this.nvr_acc_rate_t.Text = "ACC (%)";
            this.nvr_acc_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_48089211
            // 
            this.n_48089211.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_48089211.Location = new System.Drawing.Point(34, 197);
            this.n_48089211.Name = "n_48089211";
            this.n_48089211.Size = new System.Drawing.Size(133, 13);
            this.n_48089211.TabIndex = 0;
            this.n_48089211.Text = "ACC ($ pa)";
            this.n_48089211.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_item_proc_rate_per_hr_t
            // 
            this.nvr_item_proc_rate_per_hr_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_item_proc_rate_per_hr_t.Location = new System.Drawing.Point(21, 226);
            this.nvr_item_proc_rate_per_hr_t.Name = "nvr_item_proc_rate_per_hr_t";
            this.nvr_item_proc_rate_per_hr_t.Size = new System.Drawing.Size(146, 13);
            this.nvr_item_proc_rate_per_hr_t.TabIndex = 0;
            this.nvr_item_proc_rate_per_hr_t.Text = "Item Processing Rate/Hr";
            this.nvr_item_proc_rate_per_hr_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_accounting_t
            // 
            this.nvr_accounting_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_accounting_t.Location = new System.Drawing.Point(34, 253);
            this.nvr_accounting_t.Name = "nvr_accounting_t";
            this.nvr_accounting_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_accounting_t.TabIndex = 0;
            this.nvr_accounting_t.Text = "Accounting ($ pa)";
            this.nvr_accounting_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_telephone_t
            // 
            this.nvr_telephone_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_telephone_t.Location = new System.Drawing.Point(34, 280);
            this.nvr_telephone_t.Name = "nvr_telephone_t";
            this.nvr_telephone_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_telephone_t.TabIndex = 0;
            this.nvr_telephone_t.Text = "Telephone ($ pa)";
            this.nvr_telephone_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_sundries_t
            // 
            this.nvr_sundries_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_sundries_t.Location = new System.Drawing.Point(34, 306);
            this.nvr_sundries_t.Name = "nvr_sundries_t";
            this.nvr_sundries_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_sundries_t.TabIndex = 0;
            this.nvr_sundries_t.Text = "Sundries ($ pa)";
            this.nvr_sundries_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_30149715
            // 
            this.n_30149715.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_30149715.Location = new System.Drawing.Point(34, 333);
            this.n_30149715.Name = "n_30149715";
            this.n_30149715.Size = new System.Drawing.Size(133, 13);
            this.n_30149715.TabIndex = 0;
            this.n_30149715.Text = "Wardrobe ($ pa)";
            this.n_30149715.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_frozen_indicator_t
            // 
            this.nvr_frozen_indicator_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_frozen_indicator_t.Location = new System.Drawing.Point(34, 372);
            this.nvr_frozen_indicator_t.Name = "nvr_frozen_indicator_t";
            this.nvr_frozen_indicator_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_frozen_indicator_t.TabIndex = 0;
            this.nvr_frozen_indicator_t.Text = "Frozen";
            this.nvr_frozen_indicator_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code_t
            // 
            this.rg_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code_t.Location = new System.Drawing.Point(34, 8);
            this.rg_code_t.Name = "rg_code_t";
            this.rg_code_t.Size = new System.Drawing.Size(133, 13);
            this.rg_code_t.TabIndex = 0;
            this.rg_code_t.Text = "Renewal Group";
            this.rg_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_contract_start_t
            // 
            this.nvr_contract_start_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_contract_start_t.Location = new System.Drawing.Point(1, 36);
            this.nvr_contract_start_t.Name = "nvr_contract_start_t";
            this.nvr_contract_start_t.Size = new System.Drawing.Size(166, 13);
            this.nvr_contract_start_t.TabIndex = 0;
            this.nvr_contract_start_t.Text = "Default Contract Term:  From";
            this.nvr_contract_start_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_wage_hourly_rate_t
            // 
            this.nvr_wage_hourly_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_wage_hourly_rate_t.Location = new System.Drawing.Point(34, 64);
            this.nvr_wage_hourly_rate_t.Name = "nvr_wage_hourly_rate_t";
            this.nvr_wage_hourly_rate_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_wage_hourly_rate_t.TabIndex = 0;
            this.nvr_wage_hourly_rate_t.Text = "Minimum Hourly Rate ($)";
            this.nvr_wage_hourly_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_vehicle_insurance_base_premium_t
            // 
            this.nvr_vehicle_insurance_base_premium_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_vehicle_insurance_base_premium_t.Location = new System.Drawing.Point(34, 90);
            this.nvr_vehicle_insurance_base_premium_t.Name = "nvr_vehicle_insurance_base_premium_t";
            this.nvr_vehicle_insurance_base_premium_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_vehicle_insurance_base_premium_t.TabIndex = 0;
            this.nvr_vehicle_insurance_base_premium_t.Text = "Vehicle Insurance ($ pa)";
            this.nvr_vehicle_insurance_base_premium_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_public_liability_rate_t
            // 
            this.nvr_public_liability_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_public_liability_rate_t.Location = new System.Drawing.Point(34, 117);
            this.nvr_public_liability_rate_t.Name = "nvr_public_liability_rate_t";
            this.nvr_public_liability_rate_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_public_liability_rate_t.TabIndex = 0;
            this.nvr_public_liability_rate_t.Text = "Public Liability ($ pa)";
            this.nvr_public_liability_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_2911981
            // 
            this.n_2911981.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_2911981.Location = new System.Drawing.Point(253, 40);
            this.n_2911981.Name = "n_2911981";
            this.n_2911981.Size = new System.Drawing.Size(18, 13);
            this.n_2911981.TabIndex = 0;
            this.n_2911981.Text = "to";
            this.n_2911981.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nvr_contract_end
            // 
            this.nvr_contract_end.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvrContractEnd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_contract_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_contract_end.Location = new System.Drawing.Point(274, 36);
            this.nvr_contract_end.Mask = "00/00/0000";
            this.nvr_contract_end.Name = "nvr_contract_end";
            this.nvr_contract_end.Size = new System.Drawing.Size(69, 20);
            this.nvr_contract_end.TabIndex = 30;
            // 
            // DNonVehicleRates2001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nvr_rates_effective_date);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.nvr_contract_start);
            this.Controls.Add(this.nvr_wage_hourly_rate);
            this.Controls.Add(this.nvr_vehicle_insurance_base_premium);
            this.Controls.Add(this.nvr_public_liability_rate);
            this.Controls.Add(this.nvr_carrier_risk_rate);
            this.Controls.Add(this.nvr_acc_rate);
            this.Controls.Add(this.nvr_acc_rate_amount);
            this.Controls.Add(this.nvr_item_proc_rate_per_hr);
            this.Controls.Add(this.nvr_accounting);
            this.Controls.Add(this.nvr_telephone);
            this.Controls.Add(this.nvr_sundries);
            this.Controls.Add(this.nvr_uniform);
            this.Controls.Add(this.nvr_frozen_indicator);
            this.Controls.Add(this.nvr_carrier_risk_rate_t);
            this.Controls.Add(this.nvr_acc_rate_t);
            this.Controls.Add(this.n_48089211);
            this.Controls.Add(this.nvr_item_proc_rate_per_hr_t);
            this.Controls.Add(this.nvr_accounting_t);
            this.Controls.Add(this.nvr_telephone_t);
            this.Controls.Add(this.nvr_sundries_t);
            this.Controls.Add(this.n_30149715);
            this.Controls.Add(this.nvr_frozen_indicator_t);
            this.Controls.Add(this.rg_code_t);
            this.Controls.Add(this.nvr_contract_start_t);
            this.Controls.Add(this.nvr_wage_hourly_rate_t);
            this.Controls.Add(this.nvr_vehicle_insurance_base_premium_t);
            this.Controls.Add(this.nvr_public_liability_rate_t);
            this.Controls.Add(this.n_2911981);
            this.Controls.Add(this.nvr_contract_end);
            this.Name = "DNonVehicleRates2001";
            this.Size = new System.Drawing.Size(650, 399);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nvr_rates_effective_date;
        private Metex.Windows.DataEntityCombo rg_code;
        private System.Windows.Forms.MaskedTextBox nvr_contract_start;
        private System.Windows.Forms.MaskedTextBox nvr_wage_hourly_rate;
        private System.Windows.Forms.MaskedTextBox nvr_vehicle_insurance_base_premium;
        private System.Windows.Forms.MaskedTextBox nvr_public_liability_rate;
        private System.Windows.Forms.MaskedTextBox nvr_carrier_risk_rate;
        private System.Windows.Forms.MaskedTextBox nvr_acc_rate;
        private System.Windows.Forms.MaskedTextBox nvr_acc_rate_amount;
        private System.Windows.Forms.MaskedTextBox nvr_item_proc_rate_per_hr;
        private System.Windows.Forms.MaskedTextBox nvr_accounting;
        private System.Windows.Forms.MaskedTextBox nvr_telephone;
        private System.Windows.Forms.MaskedTextBox nvr_sundries;
        private System.Windows.Forms.MaskedTextBox nvr_uniform;
        private System.Windows.Forms.CheckBox nvr_frozen_indicator;
        private System.Windows.Forms.Label nvr_carrier_risk_rate_t;
        private System.Windows.Forms.Label nvr_acc_rate_t;
        private System.Windows.Forms.Label n_48089211;
        private System.Windows.Forms.Label nvr_item_proc_rate_per_hr_t;
        private System.Windows.Forms.Label nvr_accounting_t;
        private System.Windows.Forms.Label nvr_telephone_t;
        private System.Windows.Forms.Label nvr_sundries_t;
        private System.Windows.Forms.Label n_30149715;
        private System.Windows.Forms.Label nvr_frozen_indicator_t;
        private System.Windows.Forms.Label rg_code_t;
        private System.Windows.Forms.Label nvr_contract_start_t;
        private System.Windows.Forms.Label nvr_wage_hourly_rate_t;
        private System.Windows.Forms.Label nvr_vehicle_insurance_base_premium_t;
        private System.Windows.Forms.Label nvr_public_liability_rate_t;
        private System.Windows.Forms.Label n_2911981;
        private System.Windows.Forms.MaskedTextBox nvr_contract_end;
    }
}
