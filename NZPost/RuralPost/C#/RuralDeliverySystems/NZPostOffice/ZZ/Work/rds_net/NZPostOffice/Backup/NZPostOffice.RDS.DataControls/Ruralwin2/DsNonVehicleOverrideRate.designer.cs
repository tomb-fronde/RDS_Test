namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
    partial class DsNonVehicleOverrideRate
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
            this.contract_no_t = new System.Windows.Forms.Label();
            this.contract_no = new System.Windows.Forms.TextBox();
            this.contract_seq_number_t = new System.Windows.Forms.Label();
            this.contract_seq_number = new System.Windows.Forms.TextBox();
            this.nvor_wage_hourly_rate_t = new System.Windows.Forms.Label();
            this.nvor_wage_hourly_rate = new System.Windows.Forms.TextBox();
            this.nvor_public_liability_rate_2_t = new System.Windows.Forms.Label();
            this.nvor_public_liability_rate_2 = new System.Windows.Forms.TextBox();
            this.nvor_carrier_risk_rate_t = new System.Windows.Forms.Label();
            this.nvor_carrier_risk_rate = new System.Windows.Forms.TextBox();
            this.nvor_acc_rate_t = new System.Windows.Forms.Label();
            this.nvor_acc_rate = new System.Windows.Forms.TextBox();
            this.nvor_item_proc_rate_per_hour_t = new System.Windows.Forms.Label();
            this.nvor_item_proc_rate_per_hour = new System.Windows.Forms.TextBox();
            this.nvor_frozen_t = new System.Windows.Forms.Label();
            this.nvor_frozen = new System.Windows.Forms.TextBox();
            this.nvor_accounting_t = new System.Windows.Forms.Label();
            this.nvor_accounting = new System.Windows.Forms.TextBox();
            this.nvor_telephone_t = new System.Windows.Forms.Label();
            this.nvor_telephone = new System.Windows.Forms.TextBox();
            this.nvor_sundries_t = new System.Windows.Forms.Label();
            this.nvor_sundries = new System.Windows.Forms.TextBox();
            this.nvor_acc_rate_amount_t = new System.Windows.Forms.Label();
            this.nvor_acc_rate_amount = new System.Windows.Forms.TextBox();
            this.nvor_uniform_t = new System.Windows.Forms.Label();
            this.nvor_uniform = new System.Windows.Forms.TextBox();
            this.nvor_delivery_wage_rate_t = new System.Windows.Forms.Label();
            this.nvor_delivery_wage_rate = new System.Windows.Forms.TextBox();
            this.nvor_processing_wage_rate_t = new System.Windows.Forms.Label();
            this.nvor_processing_wage_rate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin2.NonVehicleOverrideRate);
            // 
            // contract_no_t
            // 
            this.contract_no_t.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_no_t.Location = new System.Drawing.Point(9, 3);
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Size = new System.Drawing.Size(163, 14);
            this.contract_no_t.TabIndex = 0;
            this.contract_no_t.Text = "Contract No:";
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_no
            // 
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_no.Location = new System.Drawing.Point(177, 1);
            this.contract_no.Name = "contract_no";
            this.contract_no.Size = new System.Drawing.Size(68, 20);
            this.contract_no.TabIndex = 10;
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // contract_seq_number_t
            // 
            this.contract_seq_number_t.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_seq_number_t.Location = new System.Drawing.Point(9, 23);
            this.contract_seq_number_t.Name = "contract_seq_number_t";
            this.contract_seq_number_t.Size = new System.Drawing.Size(163, 14);
            this.contract_seq_number_t.TabIndex = 0;
            this.contract_seq_number_t.Text = "Contract Seq Number:";
            this.contract_seq_number_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_seq_number
            // 
            this.contract_seq_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractSeqNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_seq_number.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_seq_number.Location = new System.Drawing.Point(177, 21);
            this.contract_seq_number.Name = "contract_seq_number";
            this.contract_seq_number.Size = new System.Drawing.Size(68, 20);
            this.contract_seq_number.TabIndex = 20;
            this.contract_seq_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_wage_hourly_rate_t
            // 
            this.nvor_wage_hourly_rate_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_wage_hourly_rate_t.Location = new System.Drawing.Point(9, 43);
            this.nvor_wage_hourly_rate_t.Name = "nvor_wage_hourly_rate_t";
            this.nvor_wage_hourly_rate_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_wage_hourly_rate_t.TabIndex = 0;
            this.nvor_wage_hourly_rate_t.Text = "Nvor Wage Hourly Rate:";
            this.nvor_wage_hourly_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_wage_hourly_rate
            // 
            this.nvor_wage_hourly_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorWageHourlyRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_wage_hourly_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_wage_hourly_rate.Location = new System.Drawing.Point(177, 41);
            this.nvor_wage_hourly_rate.Name = "nvor_wage_hourly_rate";
            this.nvor_wage_hourly_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_wage_hourly_rate.TabIndex = 30;
            this.nvor_wage_hourly_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_public_liability_rate_2_t
            // 
            this.nvor_public_liability_rate_2_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_public_liability_rate_2_t.Location = new System.Drawing.Point(9, 63);
            this.nvor_public_liability_rate_2_t.Name = "nvor_public_liability_rate_2_t";
            this.nvor_public_liability_rate_2_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_public_liability_rate_2_t.TabIndex = 0;
            this.nvor_public_liability_rate_2_t.Text = "Nvor Public Liability Rate 2:";
            this.nvor_public_liability_rate_2_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_public_liability_rate_2
            // 
            this.nvor_public_liability_rate_2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorPublicLiabilityRate2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_public_liability_rate_2.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_public_liability_rate_2.Location = new System.Drawing.Point(177, 61);
            this.nvor_public_liability_rate_2.Name = "nvor_public_liability_rate_2";
            this.nvor_public_liability_rate_2.Size = new System.Drawing.Size(68, 20);
            this.nvor_public_liability_rate_2.TabIndex = 40;
            this.nvor_public_liability_rate_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_carrier_risk_rate_t
            // 
            this.nvor_carrier_risk_rate_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_carrier_risk_rate_t.Location = new System.Drawing.Point(9, 83);
            this.nvor_carrier_risk_rate_t.Name = "nvor_carrier_risk_rate_t";
            this.nvor_carrier_risk_rate_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_carrier_risk_rate_t.TabIndex = 0;
            this.nvor_carrier_risk_rate_t.Text = "Nvor Carrier Risk Rate:";
            this.nvor_carrier_risk_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_carrier_risk_rate
            // 
            this.nvor_carrier_risk_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorCarrierRiskRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_carrier_risk_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_carrier_risk_rate.Location = new System.Drawing.Point(177, 81);
            this.nvor_carrier_risk_rate.Name = "nvor_carrier_risk_rate";
            this.nvor_carrier_risk_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_carrier_risk_rate.TabIndex = 50;
            this.nvor_carrier_risk_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_acc_rate_t
            // 
            this.nvor_acc_rate_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_acc_rate_t.Location = new System.Drawing.Point(9, 103);
            this.nvor_acc_rate_t.Name = "nvor_acc_rate_t";
            this.nvor_acc_rate_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_acc_rate_t.TabIndex = 0;
            this.nvor_acc_rate_t.Text = "Nvor Acc Rate:";
            this.nvor_acc_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_acc_rate
            // 
            this.nvor_acc_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorAccRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_acc_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_acc_rate.Location = new System.Drawing.Point(177, 101);
            this.nvor_acc_rate.Name = "nvor_acc_rate";
            this.nvor_acc_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_acc_rate.TabIndex = 60;
            this.nvor_acc_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_item_proc_rate_per_hour_t
            // 
            this.nvor_item_proc_rate_per_hour_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_item_proc_rate_per_hour_t.Location = new System.Drawing.Point(9, 123);
            this.nvor_item_proc_rate_per_hour_t.Name = "nvor_item_proc_rate_per_hour_t";
            this.nvor_item_proc_rate_per_hour_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_item_proc_rate_per_hour_t.TabIndex = 0;
            this.nvor_item_proc_rate_per_hour_t.Text = "Nvor Item Proc Rate Per Hour:";
            this.nvor_item_proc_rate_per_hour_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_item_proc_rate_per_hour
            // 
            this.nvor_item_proc_rate_per_hour.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorItemProcRatePerHour", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_item_proc_rate_per_hour.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_item_proc_rate_per_hour.Location = new System.Drawing.Point(177, 121);
            this.nvor_item_proc_rate_per_hour.Name = "nvor_item_proc_rate_per_hour";
            this.nvor_item_proc_rate_per_hour.Size = new System.Drawing.Size(68, 20);
            this.nvor_item_proc_rate_per_hour.TabIndex = 70;
            this.nvor_item_proc_rate_per_hour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_frozen_t
            // 
            this.nvor_frozen_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_frozen_t.Location = new System.Drawing.Point(9, 143);
            this.nvor_frozen_t.Name = "nvor_frozen_t";
            this.nvor_frozen_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_frozen_t.TabIndex = 0;
            this.nvor_frozen_t.Text = "Nvor Frozen:";
            this.nvor_frozen_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_frozen
            // 
            this.nvor_frozen.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorFrozen", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_frozen.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_frozen.Location = new System.Drawing.Point(177, 141);
            this.nvor_frozen.MaxLength = 1;
            this.nvor_frozen.Name = "nvor_frozen";
            this.nvor_frozen.Size = new System.Drawing.Size(68, 20);
            this.nvor_frozen.TabIndex = 80;
            // 
            // nvor_accounting_t
            // 
            this.nvor_accounting_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_accounting_t.Location = new System.Drawing.Point(9, 163);
            this.nvor_accounting_t.Name = "nvor_accounting_t";
            this.nvor_accounting_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_accounting_t.TabIndex = 0;
            this.nvor_accounting_t.Text = "Nvor Accounting:";
            this.nvor_accounting_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_accounting
            // 
            this.nvor_accounting.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorAccounting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_accounting.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_accounting.Location = new System.Drawing.Point(177, 161);
            this.nvor_accounting.Name = "nvor_accounting";
            this.nvor_accounting.Size = new System.Drawing.Size(68, 20);
            this.nvor_accounting.TabIndex = 90;
            this.nvor_accounting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_telephone_t
            // 
            this.nvor_telephone_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_telephone_t.Location = new System.Drawing.Point(9, 183);
            this.nvor_telephone_t.Name = "nvor_telephone_t";
            this.nvor_telephone_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_telephone_t.TabIndex = 0;
            this.nvor_telephone_t.Text = "Nvor Telephone:";
            this.nvor_telephone_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_telephone
            // 
            this.nvor_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_telephone.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_telephone.Location = new System.Drawing.Point(177, 181);
            this.nvor_telephone.Name = "nvor_telephone";
            this.nvor_telephone.Size = new System.Drawing.Size(68, 20);
            this.nvor_telephone.TabIndex = 100;
            this.nvor_telephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_sundries_t
            // 
            this.nvor_sundries_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_sundries_t.Location = new System.Drawing.Point(9, 203);
            this.nvor_sundries_t.Name = "nvor_sundries_t";
            this.nvor_sundries_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_sundries_t.TabIndex = 0;
            this.nvor_sundries_t.Text = "Nvor Sundries:";
            this.nvor_sundries_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_sundries
            // 
            this.nvor_sundries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorSundries", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_sundries.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_sundries.Location = new System.Drawing.Point(177, 201);
            this.nvor_sundries.Name = "nvor_sundries";
            this.nvor_sundries.Size = new System.Drawing.Size(68, 20);
            this.nvor_sundries.TabIndex = 110;
            this.nvor_sundries.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_acc_rate_amount_t
            // 
            this.nvor_acc_rate_amount_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_acc_rate_amount_t.Location = new System.Drawing.Point(9, 223);
            this.nvor_acc_rate_amount_t.Name = "nvor_acc_rate_amount_t";
            this.nvor_acc_rate_amount_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_acc_rate_amount_t.TabIndex = 0;
            this.nvor_acc_rate_amount_t.Text = "Nvor Acc Rate Amount:";
            this.nvor_acc_rate_amount_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_acc_rate_amount
            // 
            this.nvor_acc_rate_amount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorAccRateAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_acc_rate_amount.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_acc_rate_amount.Location = new System.Drawing.Point(177, 221);
            this.nvor_acc_rate_amount.Name = "nvor_acc_rate_amount";
            this.nvor_acc_rate_amount.Size = new System.Drawing.Size(68, 20);
            this.nvor_acc_rate_amount.TabIndex = 120;
            this.nvor_acc_rate_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_uniform_t
            // 
            this.nvor_uniform_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_uniform_t.Location = new System.Drawing.Point(9, 243);
            this.nvor_uniform_t.Name = "nvor_uniform_t";
            this.nvor_uniform_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_uniform_t.TabIndex = 0;
            this.nvor_uniform_t.Text = "Nvor Uniform:";
            this.nvor_uniform_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_uniform
            // 
            this.nvor_uniform.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorUniform", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_uniform.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_uniform.Location = new System.Drawing.Point(177, 241);
            this.nvor_uniform.Name = "nvor_uniform";
            this.nvor_uniform.Size = new System.Drawing.Size(68, 20);
            this.nvor_uniform.TabIndex = 130;
            this.nvor_uniform.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_delivery_wage_rate_t
            // 
            this.nvor_delivery_wage_rate_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_delivery_wage_rate_t.Location = new System.Drawing.Point(9, 264);
            this.nvor_delivery_wage_rate_t.Name = "nvor_delivery_wage_rate_t";
            this.nvor_delivery_wage_rate_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_delivery_wage_rate_t.TabIndex = 0;
            this.nvor_delivery_wage_rate_t.Text = "Nvor Delivery Wage Rate:";
            this.nvor_delivery_wage_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_delivery_wage_rate
            // 
            this.nvor_delivery_wage_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorDeliveryWageRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_delivery_wage_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_delivery_wage_rate.Location = new System.Drawing.Point(177, 261);
            this.nvor_delivery_wage_rate.Name = "nvor_delivery_wage_rate";
            this.nvor_delivery_wage_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_delivery_wage_rate.TabIndex = 140;
            this.nvor_delivery_wage_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_processing_wage_rate_t
            // 
            this.nvor_processing_wage_rate_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_processing_wage_rate_t.Location = new System.Drawing.Point(9, 284);
            this.nvor_processing_wage_rate_t.Name = "nvor_processing_wage_rate_t";
            this.nvor_processing_wage_rate_t.Size = new System.Drawing.Size(163, 14);
            this.nvor_processing_wage_rate_t.TabIndex = 0;
            this.nvor_processing_wage_rate_t.Text = "Nvor Processing Wage Rate:";
            this.nvor_processing_wage_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_processing_wage_rate
            // 
            this.nvor_processing_wage_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorProcessingWageRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_processing_wage_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.nvor_processing_wage_rate.Location = new System.Drawing.Point(177, 281);
            this.nvor_processing_wage_rate.Name = "nvor_processing_wage_rate";
            this.nvor_processing_wage_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_processing_wage_rate.TabIndex = 150;
            this.nvor_processing_wage_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DsNonVehicleOverrideRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contract_no_t);
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.contract_seq_number_t);
            this.Controls.Add(this.contract_seq_number);
            this.Controls.Add(this.nvor_wage_hourly_rate_t);
            this.Controls.Add(this.nvor_wage_hourly_rate);
            this.Controls.Add(this.nvor_public_liability_rate_2_t);
            this.Controls.Add(this.nvor_public_liability_rate_2);
            this.Controls.Add(this.nvor_carrier_risk_rate_t);
            this.Controls.Add(this.nvor_carrier_risk_rate);
            this.Controls.Add(this.nvor_acc_rate_t);
            this.Controls.Add(this.nvor_acc_rate);
            this.Controls.Add(this.nvor_item_proc_rate_per_hour_t);
            this.Controls.Add(this.nvor_item_proc_rate_per_hour);
            this.Controls.Add(this.nvor_frozen_t);
            this.Controls.Add(this.nvor_frozen);
            this.Controls.Add(this.nvor_accounting_t);
            this.Controls.Add(this.nvor_accounting);
            this.Controls.Add(this.nvor_telephone_t);
            this.Controls.Add(this.nvor_telephone);
            this.Controls.Add(this.nvor_sundries_t);
            this.Controls.Add(this.nvor_sundries);
            this.Controls.Add(this.nvor_acc_rate_amount_t);
            this.Controls.Add(this.nvor_acc_rate_amount);
            this.Controls.Add(this.nvor_uniform_t);
            this.Controls.Add(this.nvor_uniform);
            this.Controls.Add(this.nvor_delivery_wage_rate_t);
            this.Controls.Add(this.nvor_delivery_wage_rate);
            this.Controls.Add(this.nvor_processing_wage_rate_t);
            this.Controls.Add(this.nvor_processing_wage_rate);
            this.Name = "DsNonVehicleOverrideRate";
            this.Size = new System.Drawing.Size(650, 314);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.TextBox contract_no;
        private System.Windows.Forms.Label contract_seq_number_t;
        private System.Windows.Forms.TextBox contract_seq_number;
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
        private System.Windows.Forms.TextBox nvor_frozen;
        private System.Windows.Forms.Label nvor_accounting_t;
        private System.Windows.Forms.TextBox nvor_accounting;
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
    }
}
