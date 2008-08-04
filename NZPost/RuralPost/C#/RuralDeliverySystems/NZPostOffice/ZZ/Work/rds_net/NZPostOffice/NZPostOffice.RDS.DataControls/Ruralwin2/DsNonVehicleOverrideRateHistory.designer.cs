namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
    partial class DsNonVehicleOverrideRateHistory
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
            components = new System.ComponentModel.Container();
            this.Name = "DsNonVehicleOverrideRateHistory";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin2.NonVehicleOverrideRateHistory);
            #region contract_no_t define
            this.contract_no_t = new System.Windows.Forms.Label();
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Location = new System.Drawing.Point(9, 3);
            this.contract_no_t.Size = new System.Drawing.Size(163, 14);
            this.contract_no_t.TabIndex = 0;
            this.contract_no_t.Font = new System.Drawing.Font("Arial", 8);
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.contract_no_t.Text = "Contract No:";
            #endregion
            this.Controls.Add(contract_no_t);
            #region contract_no define
            this.contract_no = new System.Windows.Forms.TextBox();
            this.contract_no.Name = "contract_no";
            this.contract_no.Location = new System.Drawing.Point(177, 1);
            this.contract_no.Size = new System.Drawing.Size(68, 20);
            this.contract_no.TabIndex = 10;
            this.contract_no.Font = new System.Drawing.Font("Arial", 8);
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(contract_no);
            #region nvor_wage_hourly_rate_t define
            this.nvor_wage_hourly_rate_t = new System.Windows.Forms.Label();
            this.nvor_wage_hourly_rate_t.Name = "nvor_wage_hourly_rate_t";
            this.nvor_wage_hourly_rate_t.Location = new System.Drawing.Point(9, 64);
            this.nvor_wage_hourly_rate_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_wage_hourly_rate_t.TabIndex = 0;
            this.nvor_wage_hourly_rate_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_wage_hourly_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_wage_hourly_rate_t.Text = "Nvor Wage Hourly Rate:";
            #endregion
            this.Controls.Add(nvor_wage_hourly_rate_t);
            #region nvor_wage_hourly_rate define
            this.nvor_wage_hourly_rate = new System.Windows.Forms.TextBox();
            this.nvor_wage_hourly_rate.Name = "nvor_wage_hourly_rate";
            this.nvor_wage_hourly_rate.Location = new System.Drawing.Point(177, 61);
            this.nvor_wage_hourly_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_wage_hourly_rate.TabIndex = 40;
            this.nvor_wage_hourly_rate.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_wage_hourly_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nvor_wage_hourly_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorWageHourlyRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_wage_hourly_rate);
            #region nvor_public_liability_rate_2_t define
            this.nvor_public_liability_rate_2_t = new System.Windows.Forms.Label();
            this.nvor_public_liability_rate_2_t.Name = "nvor_public_liability_rate_2_t";
            this.nvor_public_liability_rate_2_t.Location = new System.Drawing.Point(9, 84);
            this.nvor_public_liability_rate_2_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_public_liability_rate_2_t.TabIndex = 0;
            this.nvor_public_liability_rate_2_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_public_liability_rate_2_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_public_liability_rate_2_t.Text = "Nvor Public Liability Rate 2:";
            #endregion
            this.Controls.Add(nvor_public_liability_rate_2_t);
            #region nvor_public_liability_rate_2 define
            this.nvor_public_liability_rate_2 = new System.Windows.Forms.TextBox();
            this.nvor_public_liability_rate_2.Name = "nvor_public_liability_rate_2";
            this.nvor_public_liability_rate_2.Location = new System.Drawing.Point(177, 81);
            this.nvor_public_liability_rate_2.Size = new System.Drawing.Size(68, 20);
            this.nvor_public_liability_rate_2.TabIndex = 50;
            this.nvor_public_liability_rate_2.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_public_liability_rate_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nvor_public_liability_rate_2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorPublicLiabilityRate2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_public_liability_rate_2);
            #region nvor_carrier_risk_rate_t define
            this.nvor_carrier_risk_rate_t = new System.Windows.Forms.Label();
            this.nvor_carrier_risk_rate_t.Name = "nvor_carrier_risk_rate_t";
            this.nvor_carrier_risk_rate_t.Location = new System.Drawing.Point(9, 104);
            this.nvor_carrier_risk_rate_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_carrier_risk_rate_t.TabIndex = 0;
            this.nvor_carrier_risk_rate_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_carrier_risk_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_carrier_risk_rate_t.Text = "Nvor Carrier Risk Rate:";
            #endregion
            this.Controls.Add(nvor_carrier_risk_rate_t);
            #region nvor_carrier_risk_rate define
            this.nvor_carrier_risk_rate = new System.Windows.Forms.TextBox();
            this.nvor_carrier_risk_rate.Name = "nvor_carrier_risk_rate";
            this.nvor_carrier_risk_rate.Location = new System.Drawing.Point(177, 101);
            this.nvor_carrier_risk_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_carrier_risk_rate.TabIndex = 60;
            this.nvor_carrier_risk_rate.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_carrier_risk_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nvor_carrier_risk_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorCarrierRiskRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_carrier_risk_rate);
            #region nvor_acc_rate_t define
            this.nvor_acc_rate_t = new System.Windows.Forms.Label();
            this.nvor_acc_rate_t.Name = "nvor_acc_rate_t";
            this.nvor_acc_rate_t.Location = new System.Drawing.Point(9, 124);
            this.nvor_acc_rate_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_acc_rate_t.TabIndex = 0;
            this.nvor_acc_rate_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_acc_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_acc_rate_t.Text = "Nvor Acc Rate:";
            #endregion
            this.Controls.Add(nvor_acc_rate_t);
            #region nvor_acc_rate define
            this.nvor_acc_rate = new System.Windows.Forms.TextBox();
            this.nvor_acc_rate.Name = "nvor_acc_rate";
            this.nvor_acc_rate.Location = new System.Drawing.Point(177, 121);
            this.nvor_acc_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_acc_rate.TabIndex = 70;
            this.nvor_acc_rate.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_acc_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nvor_acc_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorAccRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_acc_rate);
            #region nvor_item_proc_rate_per_hour_t define
            this.nvor_item_proc_rate_per_hour_t = new System.Windows.Forms.Label();
            this.nvor_item_proc_rate_per_hour_t.Name = "nvor_item_proc_rate_per_hour_t";
            this.nvor_item_proc_rate_per_hour_t.Location = new System.Drawing.Point(9, 144);
            this.nvor_item_proc_rate_per_hour_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_item_proc_rate_per_hour_t.TabIndex = 0;
            this.nvor_item_proc_rate_per_hour_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_item_proc_rate_per_hour_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_item_proc_rate_per_hour_t.Text = "Nvor Item Proc Rate Per Hour:";
            #endregion
            this.Controls.Add(nvor_item_proc_rate_per_hour_t);
            #region nvor_item_proc_rate_per_hour define
            this.nvor_item_proc_rate_per_hour = new System.Windows.Forms.TextBox();
            this.nvor_item_proc_rate_per_hour.Name = "nvor_item_proc_rate_per_hour";
            this.nvor_item_proc_rate_per_hour.Location = new System.Drawing.Point(177, 141);
            this.nvor_item_proc_rate_per_hour.Size = new System.Drawing.Size(68, 20);
            this.nvor_item_proc_rate_per_hour.TabIndex = 80;
            this.nvor_item_proc_rate_per_hour.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_item_proc_rate_per_hour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nvor_item_proc_rate_per_hour.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorItemProcRatePerHour", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_item_proc_rate_per_hour);
            #region nvor_frozen_t define
            this.nvor_frozen_t = new System.Windows.Forms.Label();
            this.nvor_frozen_t.Name = "nvor_frozen_t";
            this.nvor_frozen_t.Location = new System.Drawing.Point(9, 164);
            this.nvor_frozen_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_frozen_t.TabIndex = 0;
            this.nvor_frozen_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_frozen_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_frozen_t.Text = "Nvor Frozen:";
            #endregion
            this.Controls.Add(nvor_frozen_t);
            #region nvor_accounting_t define
            this.nvor_accounting_t = new System.Windows.Forms.Label();
            this.nvor_accounting_t.Name = "nvor_accounting_t";
            this.nvor_accounting_t.Location = new System.Drawing.Point(9, 184);
            this.nvor_accounting_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_accounting_t.TabIndex = 0;
            this.nvor_accounting_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_accounting_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_accounting_t.Text = "Nvor Accounting:";
            #endregion
            this.Controls.Add(nvor_accounting_t);
            #region nvor_telephone_t define
            this.nvor_telephone_t = new System.Windows.Forms.Label();
            this.nvor_telephone_t.Name = "nvor_telephone_t";
            this.nvor_telephone_t.Location = new System.Drawing.Point(9, 204);
            this.nvor_telephone_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_telephone_t.TabIndex = 0;
            this.nvor_telephone_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_telephone_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_telephone_t.Text = "Nvor Telephone:";
            #endregion
            this.Controls.Add(nvor_telephone_t);
            #region nvor_telephone define
            this.nvor_telephone = new System.Windows.Forms.TextBox();
            this.nvor_telephone.Name = "nvor_telephone";
            this.nvor_telephone.Location = new System.Drawing.Point(177, 201);
            this.nvor_telephone.Size = new System.Drawing.Size(68, 20);
            this.nvor_telephone.TabIndex = 110;
            this.nvor_telephone.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_telephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nvor_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_telephone);
            #region nvor_sundries_t define
            this.nvor_sundries_t = new System.Windows.Forms.Label();
            this.nvor_sundries_t.Name = "nvor_sundries_t";
            this.nvor_sundries_t.Location = new System.Drawing.Point(9, 224);
            this.nvor_sundries_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_sundries_t.TabIndex = 0;
            this.nvor_sundries_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_sundries_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_sundries_t.Text = "Nvor Sundries:";
            #endregion
            this.Controls.Add(nvor_sundries_t);
            #region nvor_sundries define
            this.nvor_sundries = new System.Windows.Forms.TextBox();
            this.nvor_sundries.Name = "nvor_sundries";
            this.nvor_sundries.Location = new System.Drawing.Point(177, 221);
            this.nvor_sundries.Size = new System.Drawing.Size(68, 20);
            this.nvor_sundries.TabIndex = 120;
            this.nvor_sundries.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_sundries.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nvor_sundries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorSundries", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_sundries);
            #region nvor_acc_rate_amount_t define
            this.nvor_acc_rate_amount_t = new System.Windows.Forms.Label();
            this.nvor_acc_rate_amount_t.Name = "nvor_acc_rate_amount_t";
            this.nvor_acc_rate_amount_t.Location = new System.Drawing.Point(9, 243);
            this.nvor_acc_rate_amount_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_acc_rate_amount_t.TabIndex = 0;
            this.nvor_acc_rate_amount_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_acc_rate_amount_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_acc_rate_amount_t.Text = "Nvor Acc Rate Amount:";
            #endregion
            this.Controls.Add(nvor_acc_rate_amount_t);
            #region nvor_acc_rate_amount define
            this.nvor_acc_rate_amount = new System.Windows.Forms.TextBox();
            this.nvor_acc_rate_amount.Name = "nvor_acc_rate_amount";
            this.nvor_acc_rate_amount.Location = new System.Drawing.Point(177, 241);
            this.nvor_acc_rate_amount.Size = new System.Drawing.Size(68, 20);
            this.nvor_acc_rate_amount.TabIndex = 130;
            this.nvor_acc_rate_amount.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_acc_rate_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nvor_acc_rate_amount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorAccRateAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_acc_rate_amount);
            #region nvor_uniform_t define
            this.nvor_uniform_t = new System.Windows.Forms.Label();
            this.nvor_uniform_t.Name = "nvor_uniform_t";
            this.nvor_uniform_t.Location = new System.Drawing.Point(9, 263);
            this.nvor_uniform_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_uniform_t.TabIndex = 0;
            this.nvor_uniform_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_uniform_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_uniform_t.Text = "Nvor Uniform:";
            #endregion
            this.Controls.Add(nvor_uniform_t);
            #region nvor_uniform define
            this.nvor_uniform = new System.Windows.Forms.TextBox();
            this.nvor_uniform.Name = "nvor_uniform";
            this.nvor_uniform.Location = new System.Drawing.Point(177, 261);
            this.nvor_uniform.Size = new System.Drawing.Size(68, 20);
            this.nvor_uniform.TabIndex = 140;
            this.nvor_uniform.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_uniform.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nvor_uniform.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorUniform", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_uniform);
            #region nvor_delivery_wage_rate_t define
            this.nvor_delivery_wage_rate_t = new System.Windows.Forms.Label();
            this.nvor_delivery_wage_rate_t.Name = "nvor_delivery_wage_rate_t";
            this.nvor_delivery_wage_rate_t.Location = new System.Drawing.Point(9, 283);
            this.nvor_delivery_wage_rate_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_delivery_wage_rate_t.TabIndex = 0;
            this.nvor_delivery_wage_rate_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_delivery_wage_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_delivery_wage_rate_t.Text = "Nvor Delivery Wage Rate:";
            #endregion
            this.Controls.Add(nvor_delivery_wage_rate_t);
            #region nvor_delivery_wage_rate define
            this.nvor_delivery_wage_rate = new System.Windows.Forms.TextBox();
            this.nvor_delivery_wage_rate.Name = "nvor_delivery_wage_rate";
            this.nvor_delivery_wage_rate.Location = new System.Drawing.Point(177, 281);
            this.nvor_delivery_wage_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_delivery_wage_rate.TabIndex = 150;
            this.nvor_delivery_wage_rate.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_delivery_wage_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nvor_delivery_wage_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorDeliveryWageRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_delivery_wage_rate);
            #region nvor_processing_wage_rate_t define
            this.nvor_processing_wage_rate_t = new System.Windows.Forms.Label();
            this.nvor_processing_wage_rate_t.Name = "nvor_processing_wage_rate_t";
            this.nvor_processing_wage_rate_t.Location = new System.Drawing.Point(9, 303);
            this.nvor_processing_wage_rate_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_processing_wage_rate_t.TabIndex = 0;
            this.nvor_processing_wage_rate_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_processing_wage_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_processing_wage_rate_t.Text = "Nvor Processing Wage Rate:";
            #endregion
            this.Controls.Add(nvor_processing_wage_rate_t);
            #region nvor_processing_wage_rate define
            this.nvor_processing_wage_rate = new System.Windows.Forms.TextBox();
            this.nvor_processing_wage_rate.Name = "nvor_processing_wage_rate";
            this.nvor_processing_wage_rate.Location = new System.Drawing.Point(177, 301);
            this.nvor_processing_wage_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_processing_wage_rate.TabIndex = 160;
            this.nvor_processing_wage_rate.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_processing_wage_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nvor_processing_wage_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorProcessingWageRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_processing_wage_rate);
            #region nvor_accounting define
            this.nvor_accounting = new System.Windows.Forms.TextBox();
            this.nvor_accounting.Name = "nvor_accounting";
            this.nvor_accounting.Location = new System.Drawing.Point(177, 181);
            this.nvor_accounting.Size = new System.Drawing.Size(68, 20);
            this.nvor_accounting.TabIndex = 100;
            this.nvor_accounting.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_accounting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nvor_accounting.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorAccounting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_accounting);
            #region nvor_frozen define
            this.nvor_frozen = new System.Windows.Forms.TextBox();
            this.nvor_frozen.Name = "nvor_frozen";
            this.nvor_frozen.Location = new System.Drawing.Point(177, 161);
            this.nvor_frozen.Size = new System.Drawing.Size(68, 20);
            this.nvor_frozen.TabIndex = 90;
            this.nvor_frozen.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_frozen.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.nvor_frozen.MaxLength = 1;
            this.nvor_frozen.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorFrozen", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_frozen);
            #region nvor_effective_date_t define
            this.nvor_effective_date_t = new System.Windows.Forms.Label();
            this.nvor_effective_date_t.Name = "nvor_effective_date_t";
            this.nvor_effective_date_t.Location = new System.Drawing.Point(9, 44);
            this.nvor_effective_date_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_effective_date_t.TabIndex = 0;
            this.nvor_effective_date_t.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_effective_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nvor_effective_date_t.Text = "Nvor Effective Date:";
            #endregion
            this.Controls.Add(nvor_effective_date_t);
            #region nvor_effective_date define
            this.nvor_effective_date = new System.Windows.Forms.TextBox();
            this.nvor_effective_date.Name = "nvor_effective_date";
            this.nvor_effective_date.Location = new System.Drawing.Point(177, 41);
            this.nvor_effective_date.Size = new System.Drawing.Size(68, 20);
            this.nvor_effective_date.TabIndex = 30;
            this.nvor_effective_date.Font = new System.Drawing.Font("Arial", 8);
            this.nvor_effective_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.nvor_effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorEffectiveDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(nvor_effective_date);
            #region contract_seq_number_t define
            this.contract_seq_number_t = new System.Windows.Forms.Label();
            this.contract_seq_number_t.Name = "contract_seq_number_t";
            this.contract_seq_number_t.Location = new System.Drawing.Point(9, 23);
            this.contract_seq_number_t.Size = new System.Drawing.Size(163, 14);
            this.contract_seq_number_t.TabIndex = 0;
            this.contract_seq_number_t.Font = new System.Drawing.Font("Arial", 8);
            this.contract_seq_number_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.contract_seq_number_t.Text = "Contract Seq Number:";
            #endregion
            this.Controls.Add(contract_seq_number_t);
            #region contract_seq_number define
            this.contract_seq_number = new System.Windows.Forms.TextBox();
            this.contract_seq_number.Name = "contract_seq_number";
            this.contract_seq_number.Location = new System.Drawing.Point(177, 21);
            this.contract_seq_number.Size = new System.Drawing.Size(68, 20);
            this.contract_seq_number.TabIndex = 20;
            this.contract_seq_number.Font = new System.Drawing.Font("Arial", 8);
            this.contract_seq_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.contract_seq_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractSeqNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(contract_seq_number);
            this.Size = new System.Drawing.Size(650, 329);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.TextBox contract_no;
        private System.Windows.Forms.Label nvor_wage_hourly_rate_t;
        private System.Windows.Forms.TextBox nvor_wage_hourly_rate;
        private System.Windows.Forms.Label nvor_public_liability_rate_2_t;
        private System.Windows.Forms.TextBox nvor_public_liability_rate_2;
        private System.Windows.Forms.Label nvor_carrier_risk_rate_t;
        private System.Windows.Forms.TextBox nvor_carrier_risk_rate;
        private System.Windows.Forms.Label nvor_acc_rate_t;
        private System.Windows.Forms.TextBox nvor_acc_rate;
        private System.Windows.Forms.Label nvor_item_proc_rate_per_hour_t;
        private System.Windows.Forms.TextBox nvor_item_proc_rate_per_hour;
        private System.Windows.Forms.Label nvor_frozen_t;
        private System.Windows.Forms.Label nvor_accounting_t;
        private System.Windows.Forms.Label nvor_telephone_t;
        private System.Windows.Forms.TextBox nvor_telephone;
        private System.Windows.Forms.Label nvor_sundries_t;
        private System.Windows.Forms.TextBox nvor_sundries;
        private System.Windows.Forms.Label nvor_acc_rate_amount_t;
        private System.Windows.Forms.TextBox nvor_acc_rate_amount;
        private System.Windows.Forms.Label nvor_uniform_t;
        private System.Windows.Forms.TextBox nvor_uniform;
        private System.Windows.Forms.Label nvor_delivery_wage_rate_t;
        private System.Windows.Forms.TextBox nvor_delivery_wage_rate;
        private System.Windows.Forms.Label nvor_processing_wage_rate_t;
        private System.Windows.Forms.TextBox nvor_processing_wage_rate;
        private System.Windows.Forms.TextBox nvor_accounting;
        private System.Windows.Forms.TextBox nvor_frozen;
        private System.Windows.Forms.Label nvor_effective_date_t;
        private System.Windows.Forms.TextBox nvor_effective_date;
        private System.Windows.Forms.Label contract_seq_number_t;
        private System.Windows.Forms.TextBox contract_seq_number;
    }
}
