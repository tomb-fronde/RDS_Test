using NZPostOffice.Shared.VisualComponents;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DNonVehicleRates2005
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
            this.nvr_contract_start = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.rg_code_t = new System.Windows.Forms.Label();
            this.nvr_contract_start_t = new System.Windows.Forms.Label();
            this.nvr_processing_wage_rate_t = new System.Windows.Forms.Label();
            this.t_3 = new System.Windows.Forms.Label();
            this.nvr_public_liability_rate = new NumericalMaskedTextBox();
            this.nvr_carrier_risk_rate = new NumericalMaskedTextBox();
            this.nvr_acc_rate = new NumericalMaskedTextBox();
            this.nvr_acc_rate_amount = new NumericalMaskedTextBox();
            this.nvr_item_proc_rate_per_hr = new NumericalMaskedTextBox();
            this.nvr_accounting = new NumericalMaskedTextBox();
            this.nvr_telephone = new NumericalMaskedTextBox();
            this.nvr_sundries = new NumericalMaskedTextBox();
            this.nvr_uniform = new NumericalMaskedTextBox();
            this.nvr_carrier_risk_rate_t = new System.Windows.Forms.Label();
            this.nvr_acc_rate_t = new System.Windows.Forms.Label();
            this.t_1 = new System.Windows.Forms.Label();
            this.nvr_item_proc_rate_per_hr_t = new System.Windows.Forms.Label();
            this.nvr_accounting_t = new System.Windows.Forms.Label();
            this.nvr_telephone_t = new System.Windows.Forms.Label();
            this.nvr_sundries_t = new System.Windows.Forms.Label();
            this.t_2 = new System.Windows.Forms.Label();
            this.nvr_vehicle_insurance_base_premium_t = new System.Windows.Forms.Label();
            this.nvr_public_liability_rate_t = new System.Windows.Forms.Label();
            this.nvr_vehicle_insurance_base_premium = new NumericalMaskedTextBox();
            this.t_4 = new System.Windows.Forms.Label();
            this.nvr_frozen_indicator_t = new System.Windows.Forms.Label();
            this.nvr_contract_end = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.nvr_frozen_indicator = new System.Windows.Forms.CheckBox();
            this.nvr_processing_wage_rate = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.nvr_delivery_wage_rate = new NumericalMaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.NonVehicleRates2005);
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
            this.nvr_contract_start.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrContractStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_contract_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_contract_start.Location = new System.Drawing.Point(177, 31);
            this.nvr_contract_start.Mask = "00/00/0000";
            this.nvr_contract_start.DataBindings[0].FormatString = "dd/MM/yyyy";
            //this.nvr_contract_start.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            //this.nvr_contract_start.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_contract_start.DataBindings[0].DataSourceNullValue = null;
            //this.nvr_contract_start.PromptChar = '0';
            //this.nvr_contract_start.ValidatingType = typeof(System.DateTime);
            this.nvr_contract_start.Name = "nvr_contract_start";
            this.nvr_contract_start.Size = new System.Drawing.Size(69, 20);
            this.nvr_contract_start.TabIndex = 20;
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
            this.nvr_contract_start_t.Location = new System.Drawing.Point(1, 31);
            this.nvr_contract_start_t.Name = "nvr_contract_start_t";
            this.nvr_contract_start_t.Size = new System.Drawing.Size(166, 13);
            this.nvr_contract_start_t.TabIndex = 0;
            this.nvr_contract_start_t.Text = "Default Contract Term:  From";
            this.nvr_contract_start_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_processing_wage_rate_t
            // 
            this.nvr_processing_wage_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_processing_wage_rate_t.Location = new System.Drawing.Point(25, 53);
            this.nvr_processing_wage_rate_t.Name = "nvr_processing_wage_rate_t";
            this.nvr_processing_wage_rate_t.Size = new System.Drawing.Size(142, 13);
            this.nvr_processing_wage_rate_t.TabIndex = 0;
            this.nvr_processing_wage_rate_t.Text = "Processing Wage Rate ($)";
            this.nvr_processing_wage_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_3
            // 
            this.t_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_3.Location = new System.Drawing.Point(253, 35);
            this.t_3.Name = "t_3";
            this.t_3.Size = new System.Drawing.Size(17, 13);
            this.t_3.TabIndex = 0;
            this.t_3.Text = "to";
            this.t_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nvr_public_liability_rate
            // 
            this.nvr_public_liability_rate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrPublicLiabilityRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_public_liability_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_public_liability_rate.Location = new System.Drawing.Point(177, 119);
            this.nvr_public_liability_rate.EditMask = "#,##0.00";
            this.nvr_public_liability_rate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nvr_public_liability_rate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_public_liability_rate.PromptChar = ' ';
            this.nvr_public_liability_rate.DataBindings[0].FormatString = "#,##0.00";
            this.nvr_public_liability_rate.Name = "nvr_public_liability_rate";
            this.nvr_public_liability_rate.Size = new System.Drawing.Size(60, 20);
            this.nvr_public_liability_rate.TabIndex = 70;
            this.nvr_public_liability_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_carrier_risk_rate
            // 
            this.nvr_carrier_risk_rate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrCarrierRiskRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_carrier_risk_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_carrier_risk_rate.Location = new System.Drawing.Point(177, 141);
            this.nvr_carrier_risk_rate.EditMask = "#,##0.00";
            this.nvr_carrier_risk_rate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nvr_carrier_risk_rate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_carrier_risk_rate.PromptChar = ' ';
            this.nvr_carrier_risk_rate.DataBindings[0].FormatString = "#,##0.00";
            this.nvr_carrier_risk_rate.Name = "nvr_carrier_risk_rate";
            this.nvr_carrier_risk_rate.Size = new System.Drawing.Size(60, 20);
            this.nvr_carrier_risk_rate.TabIndex = 80;
            this.nvr_carrier_risk_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_acc_rate
            // 
            this.nvr_acc_rate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrAccRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_acc_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_acc_rate.Location = new System.Drawing.Point(177, 162);
            this.nvr_acc_rate.EditMask = "###0.00";
            this.nvr_acc_rate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nvr_acc_rate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_acc_rate.PromptChar = ' ';
            this.nvr_acc_rate.DataBindings[0].FormatString = "###0.00";
            this.nvr_acc_rate.Name = "nvr_acc_rate";
            this.nvr_acc_rate.Size = new System.Drawing.Size(38, 20);
            this.nvr_acc_rate.TabIndex = 90;
            this.nvr_acc_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_acc_rate_amount
            // 
            this.nvr_acc_rate_amount.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrAccRateAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_acc_rate_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_acc_rate_amount.Location = new System.Drawing.Point(177, 184);
            this.nvr_acc_rate_amount.EditMask = "###,##0.00";
            this.nvr_acc_rate_amount.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nvr_acc_rate_amount.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_acc_rate_amount.PromptChar = ' ';
            this.nvr_acc_rate_amount.DataBindings[0].FormatString = "###,##0.00";
            this.nvr_acc_rate_amount.Name = "nvr_acc_rate_amount";
            this.nvr_acc_rate_amount.Size = new System.Drawing.Size(60, 20);
            this.nvr_acc_rate_amount.TabIndex = 100;
            this.nvr_acc_rate_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_item_proc_rate_per_hr
            // 
            this.nvr_item_proc_rate_per_hr.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrItemProcRatePerHr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_item_proc_rate_per_hr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_item_proc_rate_per_hr.Location = new System.Drawing.Point(177, 206);
            this.nvr_item_proc_rate_per_hr.EditMask = "####0";
            this.nvr_item_proc_rate_per_hr.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nvr_item_proc_rate_per_hr.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_item_proc_rate_per_hr.PromptChar = ' ';
            this.nvr_item_proc_rate_per_hr.DataBindings[0].FormatString = "####0";
            this.nvr_item_proc_rate_per_hr.Name = "nvr_item_proc_rate_per_hr";
            this.nvr_item_proc_rate_per_hr.Size = new System.Drawing.Size(46, 20);
            this.nvr_item_proc_rate_per_hr.TabIndex = 110;
            this.nvr_item_proc_rate_per_hr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_accounting
            // 
            this.nvr_accounting.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrAccounting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_accounting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_accounting.Location = new System.Drawing.Point(177, 227);
            this.nvr_accounting.EditMask = "#,##0.00";
            this.nvr_accounting.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nvr_accounting.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_accounting.PromptChar = ' ';
            this.nvr_accounting.DataBindings[0].FormatString = "#,##0.00";
            this.nvr_accounting.Name = "nvr_accounting";
            this.nvr_accounting.Size = new System.Drawing.Size(60, 20);
            this.nvr_accounting.TabIndex = 120;
            this.nvr_accounting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_telephone
            // 
            this.nvr_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_telephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_telephone.Location = new System.Drawing.Point(177, 248);
            this.nvr_telephone.EditMask = "#,##0.00";
            this.nvr_telephone.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nvr_telephone.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_telephone.PromptChar = ' ';
            this.nvr_telephone.DataBindings[0].FormatString = "#,##0.00";
            this.nvr_telephone.Name = "nvr_telephone";
            this.nvr_telephone.Size = new System.Drawing.Size(60, 20);
            this.nvr_telephone.TabIndex = 130;
            this.nvr_telephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_sundries
            // 
            this.nvr_sundries.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrSundries", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_sundries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_sundries.Location = new System.Drawing.Point(177, 268);
            this.nvr_sundries.EditMask = "#,##0.00";
            this.nvr_sundries.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nvr_sundries.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_sundries.PromptChar = ' ';
            this.nvr_sundries.DataBindings[0].FormatString = "#,##0.00";
            this.nvr_sundries.Name = "nvr_sundries";
            this.nvr_sundries.Size = new System.Drawing.Size(60, 20);
            this.nvr_sundries.TabIndex = 140;
            this.nvr_sundries.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_uniform
            // 
            this.nvr_uniform.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrUniform", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_uniform.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_uniform.Location = new System.Drawing.Point(177, 290);
            this.nvr_uniform.EditMask = "###,##0.00";
            this.nvr_uniform.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nvr_uniform.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_uniform.PromptChar = ' ';
            this.nvr_uniform.DataBindings[0].FormatString = "###,##0.00";
            this.nvr_uniform.Name = "nvr_uniform";
            this.nvr_uniform.Size = new System.Drawing.Size(60, 20);
            this.nvr_uniform.TabIndex = 150;
            this.nvr_uniform.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_carrier_risk_rate_t
            // 
            this.nvr_carrier_risk_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_carrier_risk_rate_t.Location = new System.Drawing.Point(34, 141);
            this.nvr_carrier_risk_rate_t.Name = "nvr_carrier_risk_rate_t";
            this.nvr_carrier_risk_rate_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_carrier_risk_rate_t.TabIndex = 0;
            this.nvr_carrier_risk_rate_t.Text = "Carrier Risk ($ pa)";
            this.nvr_carrier_risk_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_acc_rate_t
            // 
            this.nvr_acc_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_acc_rate_t.Location = new System.Drawing.Point(34, 162);
            this.nvr_acc_rate_t.Name = "nvr_acc_rate_t";
            this.nvr_acc_rate_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_acc_rate_t.TabIndex = 0;
            this.nvr_acc_rate_t.Text = "ACC (%)";
            this.nvr_acc_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.Location = new System.Drawing.Point(34, 183);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(133, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "ACC ($ pa)";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_item_proc_rate_per_hr_t
            // 
            this.nvr_item_proc_rate_per_hr_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_item_proc_rate_per_hr_t.Location = new System.Drawing.Point(21, 206);
            this.nvr_item_proc_rate_per_hr_t.Name = "nvr_item_proc_rate_per_hr_t";
            this.nvr_item_proc_rate_per_hr_t.Size = new System.Drawing.Size(146, 13);
            this.nvr_item_proc_rate_per_hr_t.TabIndex = 0;
            this.nvr_item_proc_rate_per_hr_t.Text = "Item Processing Rate/Hr";
            this.nvr_item_proc_rate_per_hr_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_accounting_t
            // 
            this.nvr_accounting_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_accounting_t.Location = new System.Drawing.Point(34, 227);
            this.nvr_accounting_t.Name = "nvr_accounting_t";
            this.nvr_accounting_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_accounting_t.TabIndex = 0;
            this.nvr_accounting_t.Text = "Accounting ($ pa)";
            this.nvr_accounting_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_telephone_t
            // 
            this.nvr_telephone_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_telephone_t.Location = new System.Drawing.Point(34, 248);
            this.nvr_telephone_t.Name = "nvr_telephone_t";
            this.nvr_telephone_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_telephone_t.TabIndex = 0;
            this.nvr_telephone_t.Text = "Telephone ($ pa)";
            this.nvr_telephone_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_sundries_t
            // 
            this.nvr_sundries_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_sundries_t.Location = new System.Drawing.Point(34, 269);
            this.nvr_sundries_t.Name = "nvr_sundries_t";
            this.nvr_sundries_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_sundries_t.TabIndex = 0;
            this.nvr_sundries_t.Text = "Sundries ($ pa)";
            this.nvr_sundries_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_2
            // 
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.Location = new System.Drawing.Point(34, 290);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(133, 13);
            this.t_2.TabIndex = 0;
            this.t_2.Text = "Wardrobe ($ pa)";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_vehicle_insurance_base_premium_t
            // 
            this.nvr_vehicle_insurance_base_premium_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_vehicle_insurance_base_premium_t.Location = new System.Drawing.Point(34, 97);
            this.nvr_vehicle_insurance_base_premium_t.Name = "nvr_vehicle_insurance_base_premium_t";
            this.nvr_vehicle_insurance_base_premium_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_vehicle_insurance_base_premium_t.TabIndex = 0;
            this.nvr_vehicle_insurance_base_premium_t.Text = "Vehicle Insurance ($ pa)";
            this.nvr_vehicle_insurance_base_premium_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_public_liability_rate_t
            // 
            this.nvr_public_liability_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_public_liability_rate_t.Location = new System.Drawing.Point(34, 119);
            this.nvr_public_liability_rate_t.Name = "nvr_public_liability_rate_t";
            this.nvr_public_liability_rate_t.Size = new System.Drawing.Size(133, 13);
            this.nvr_public_liability_rate_t.TabIndex = 0;
            this.nvr_public_liability_rate_t.Text = "Public Liability ($ pa)";
            this.nvr_public_liability_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_vehicle_insurance_base_premium
            // 
            this.nvr_vehicle_insurance_base_premium.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrVehicleInsuranceBasePremium", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_vehicle_insurance_base_premium.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_vehicle_insurance_base_premium.Location = new System.Drawing.Point(177, 97);
            this.nvr_vehicle_insurance_base_premium.EditMask = "#,##0.00";
            this.nvr_vehicle_insurance_base_premium.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nvr_vehicle_insurance_base_premium.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_vehicle_insurance_base_premium.PromptChar = ' ';
            this.nvr_vehicle_insurance_base_premium.DataBindings[0].FormatString = "#,##0.00";
            this.nvr_vehicle_insurance_base_premium.Name = "nvr_vehicle_insurance_base_premium";
            this.nvr_vehicle_insurance_base_premium.Size = new System.Drawing.Size(60, 20);
            this.nvr_vehicle_insurance_base_premium.TabIndex = 60;
            this.nvr_vehicle_insurance_base_premium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_4
            // 
            this.t_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_4.Location = new System.Drawing.Point(25, 75);
            this.t_4.Name = "t_4";
            this.t_4.Size = new System.Drawing.Size(142, 13);
            this.t_4.TabIndex = 0;
            this.t_4.Text = "Delivery Wage Rate ($)";
            this.t_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_frozen_indicator_t
            // 
            this.nvr_frozen_indicator_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_frozen_indicator_t.Location = new System.Drawing.Point(256, 303);
            this.nvr_frozen_indicator_t.Name = "nvr_frozen_indicator_t";
            this.nvr_frozen_indicator_t.Size = new System.Drawing.Size(66, 13);
            this.nvr_frozen_indicator_t.TabIndex = 0;
            this.nvr_frozen_indicator_t.Text = "Frozen";
            this.nvr_frozen_indicator_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvr_contract_end
            // 
            this.nvr_contract_end.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrContractEnd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_contract_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_contract_end.Location = new System.Drawing.Point(274, 31);
            this.nvr_contract_end.Mask = "00/00/0000";
            this.nvr_contract_end.DataBindings[0].FormatString = "dd/MM/yyyy";
            //this.nvr_contract_end.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            //this.nvr_contract_end.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_contract_end.DataBindings[0].DataSourceNullValue = null;
            //this.nvr_contract_end.PromptChar = '0';
            //this.nvr_contract_end.ValidatingType = typeof(System.DateTime);
            this.nvr_contract_end.Name = "nvr_contract_end";
            this.nvr_contract_end.Size = new System.Drawing.Size(69, 20);
            this.nvr_contract_end.TabIndex = 30;
            // 
            // nvr_frozen_indicator
            // 
            this.nvr_frozen_indicator.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvr_frozen_indicator.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "NvrFrozenIndicator", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_frozen_indicator.Enabled = false;
            this.nvr_frozen_indicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_frozen_indicator.Location = new System.Drawing.Point(326, 304);
            this.nvr_frozen_indicator.Name = "nvr_frozen_indicator";
            this.nvr_frozen_indicator.Size = new System.Drawing.Size(17, 15);
            this.nvr_frozen_indicator.TabIndex = 0;
            this.nvr_frozen_indicator.ThreeState = true;
            // 
            // nvr_processing_wage_rate
            // 
            this.nvr_processing_wage_rate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrProcessingWageRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_processing_wage_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_processing_wage_rate.Location = new System.Drawing.Point(177, 53);
            this.nvr_processing_wage_rate.EditMask = "#,##0.00";
            this.nvr_processing_wage_rate.DataBindings[0].FormatString = "#,##0.00";
            this.nvr_processing_wage_rate.PromptChar = ' ';
            this.nvr_processing_wage_rate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nvr_processing_wage_rate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_processing_wage_rate.Name = "nvr_processing_wage_rate";
            this.nvr_processing_wage_rate.Size = new System.Drawing.Size(60, 20);
            this.nvr_processing_wage_rate.TabIndex = 40;
            this.nvr_processing_wage_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvr_delivery_wage_rate
            // 
            this.nvr_delivery_wage_rate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NvrDeliveryWageRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvr_delivery_wage_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvr_delivery_wage_rate.Location = new System.Drawing.Point(177, 75);
            this.nvr_delivery_wage_rate.EditMask = "#,##0.00";
            this.nvr_delivery_wage_rate.DataBindings[0].FormatString = "#,##0.00";
            this.nvr_delivery_wage_rate.PromptChar = ' ';
            this.nvr_delivery_wage_rate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nvr_delivery_wage_rate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.nvr_delivery_wage_rate.Name = "nvr_delivery_wage_rate";
            this.nvr_delivery_wage_rate.Size = new System.Drawing.Size(60, 20);
            this.nvr_delivery_wage_rate.TabIndex = 50;
            this.nvr_delivery_wage_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DNonVehicleRates2005
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nvr_rates_effective_date);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.nvr_contract_start);
            this.Controls.Add(this.rg_code_t);
            this.Controls.Add(this.nvr_contract_start_t);
            this.Controls.Add(this.nvr_processing_wage_rate_t);
            this.Controls.Add(this.t_3);
            this.Controls.Add(this.nvr_public_liability_rate);
            this.Controls.Add(this.nvr_carrier_risk_rate);
            this.Controls.Add(this.nvr_acc_rate);
            this.Controls.Add(this.nvr_acc_rate_amount);
            this.Controls.Add(this.nvr_item_proc_rate_per_hr);
            this.Controls.Add(this.nvr_accounting);
            this.Controls.Add(this.nvr_telephone);
            this.Controls.Add(this.nvr_sundries);
            this.Controls.Add(this.nvr_uniform);
            this.Controls.Add(this.nvr_carrier_risk_rate_t);
            this.Controls.Add(this.nvr_acc_rate_t);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.nvr_item_proc_rate_per_hr_t);
            this.Controls.Add(this.nvr_accounting_t);
            this.Controls.Add(this.nvr_telephone_t);
            this.Controls.Add(this.nvr_sundries_t);
            this.Controls.Add(this.t_2);
            this.Controls.Add(this.nvr_vehicle_insurance_base_premium_t);
            this.Controls.Add(this.nvr_public_liability_rate_t);
            this.Controls.Add(this.nvr_vehicle_insurance_base_premium);
            this.Controls.Add(this.t_4);
            this.Controls.Add(this.nvr_frozen_indicator_t);
            this.Controls.Add(this.nvr_contract_end);
            this.Controls.Add(this.nvr_frozen_indicator);
            this.Controls.Add(this.nvr_processing_wage_rate);
            this.Controls.Add(this.nvr_delivery_wage_rate);
            this.Name = "DNonVehicleRates2005";
            this.Size = new System.Drawing.Size(650, 332);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nvr_rates_effective_date;
        private Metex.Windows.DataEntityCombo rg_code;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox nvr_contract_start;
        private System.Windows.Forms.Label rg_code_t;
        private System.Windows.Forms.Label nvr_contract_start_t;
        private System.Windows.Forms.Label nvr_processing_wage_rate_t;
        private System.Windows.Forms.Label t_3;
        private NumericalMaskedTextBox nvr_public_liability_rate;
        private NumericalMaskedTextBox nvr_carrier_risk_rate;
        private NumericalMaskedTextBox nvr_acc_rate;
        private NumericalMaskedTextBox nvr_acc_rate_amount;
        private NumericalMaskedTextBox nvr_item_proc_rate_per_hr;
        private NumericalMaskedTextBox nvr_accounting;
        private NumericalMaskedTextBox nvr_telephone;
        private NumericalMaskedTextBox nvr_sundries;
        private NumericalMaskedTextBox nvr_uniform;
        private System.Windows.Forms.Label nvr_carrier_risk_rate_t;
        private System.Windows.Forms.Label nvr_acc_rate_t;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label nvr_item_proc_rate_per_hr_t;
        private System.Windows.Forms.Label nvr_accounting_t;
        private System.Windows.Forms.Label nvr_telephone_t;
        private System.Windows.Forms.Label nvr_sundries_t;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label nvr_vehicle_insurance_base_premium_t;
        private System.Windows.Forms.Label nvr_public_liability_rate_t;
        private NumericalMaskedTextBox nvr_vehicle_insurance_base_premium;
        private System.Windows.Forms.Label t_4;
        private System.Windows.Forms.Label nvr_frozen_indicator_t;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox nvr_contract_end;
        private System.Windows.Forms.CheckBox nvr_frozen_indicator;
        private NumericalMaskedTextBox nvr_processing_wage_rate;
        private NumericalMaskedTextBox nvr_delivery_wage_rate;
    }
}
