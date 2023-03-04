namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
    partial class DsVehicleOverrideRate
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
            this.vor_nominal_vehicle_value_t = new System.Windows.Forms.Label();
            this.vor_nominal_vehicle_value = new System.Windows.Forms.TextBox();
            this.vor_repairs_maintenance_rate_t = new System.Windows.Forms.Label();
            this.vor_repairs_maintenance_rate = new System.Windows.Forms.TextBox();
            this.vor_tyre_tubes_rate_t = new System.Windows.Forms.Label();
            this.vor_tyre_tubes_rate = new System.Windows.Forms.TextBox();
            this.vor_vehical_allowance_rate_t = new System.Windows.Forms.Label();
            this.vor_vehical_allowance_rate = new System.Windows.Forms.TextBox();
            this.vor_licence_rate_t = new System.Windows.Forms.Label();
            this.vor_licence_rate = new System.Windows.Forms.TextBox();
            this.vor_vehicle_rate_of_return_pct_t = new System.Windows.Forms.Label();
            this.vor_vehicle_rate_of_return_pct = new System.Windows.Forms.TextBox();
            this.vor_salvage_ratio_t = new System.Windows.Forms.Label();
            this.vor_salvage_ratio = new System.Windows.Forms.TextBox();
            this.vor_ruc = new System.Windows.Forms.TextBox();
            this.vor_sundries_k = new System.Windows.Forms.TextBox();
            this.vor_vehicle_insurance_premium = new System.Windows.Forms.TextBox();
            this.vor_fuel_rate = new System.Windows.Forms.TextBox();
            this.vor_consumption_rate = new System.Windows.Forms.TextBox();
            this.vor_livery = new System.Windows.Forms.TextBox();
            this.vor_effective_date = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin2.VehicleOverrideRate);
            // 
            // contract_no_t
            // 
            this.contract_no_t.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_no_t.Location = new System.Drawing.Point(9, 3);
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Size = new System.Drawing.Size(174, 14);
            this.contract_no_t.TabIndex = 0;
            this.contract_no_t.Text = "Contract No:";
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_no
            // 
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.Enabled = false;
            this.contract_no.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_no.Location = new System.Drawing.Point(188, 1);
            this.contract_no.Name = "contract_no";
            this.contract_no.Size = new System.Drawing.Size(68, 20);
            this.contract_no.TabIndex = 0;
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // contract_seq_number_t
            // 
            this.contract_seq_number_t.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_seq_number_t.Location = new System.Drawing.Point(9, 23);
            this.contract_seq_number_t.Name = "contract_seq_number_t";
            this.contract_seq_number_t.Size = new System.Drawing.Size(174, 14);
            this.contract_seq_number_t.TabIndex = 0;
            this.contract_seq_number_t.Text = "Contract Seq Number:";
            this.contract_seq_number_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_seq_number
            // 
            this.contract_seq_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractSeqNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_seq_number.Enabled = false;
            this.contract_seq_number.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_seq_number.Location = new System.Drawing.Point(188, 21);
            this.contract_seq_number.Name = "contract_seq_number";
            this.contract_seq_number.Size = new System.Drawing.Size(68, 20);
            this.contract_seq_number.TabIndex = 0;
            this.contract_seq_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vor_nominal_vehicle_value_t
            // 
            this.vor_nominal_vehicle_value_t.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_nominal_vehicle_value_t.Location = new System.Drawing.Point(9, 43);
            this.vor_nominal_vehicle_value_t.Name = "vor_nominal_vehicle_value_t";
            this.vor_nominal_vehicle_value_t.Size = new System.Drawing.Size(174, 14);
            this.vor_nominal_vehicle_value_t.TabIndex = 0;
            this.vor_nominal_vehicle_value_t.Text = "Vor Nominal Vehicle Value:";
            this.vor_nominal_vehicle_value_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_nominal_vehicle_value
            // 
            this.vor_nominal_vehicle_value.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorNominalVehicleValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_nominal_vehicle_value.Enabled = false;
            this.vor_nominal_vehicle_value.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_nominal_vehicle_value.Location = new System.Drawing.Point(188, 41);
            this.vor_nominal_vehicle_value.Name = "vor_nominal_vehicle_value";
            this.vor_nominal_vehicle_value.Size = new System.Drawing.Size(68, 20);
            this.vor_nominal_vehicle_value.TabIndex = 0;
            this.vor_nominal_vehicle_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vor_repairs_maintenance_rate_t
            // 
            this.vor_repairs_maintenance_rate_t.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_repairs_maintenance_rate_t.Location = new System.Drawing.Point(9, 63);
            this.vor_repairs_maintenance_rate_t.Name = "vor_repairs_maintenance_rate_t";
            this.vor_repairs_maintenance_rate_t.Size = new System.Drawing.Size(174, 14);
            this.vor_repairs_maintenance_rate_t.TabIndex = 0;
            this.vor_repairs_maintenance_rate_t.Text = "Vor Repairs Maintenance Rate:";
            this.vor_repairs_maintenance_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_repairs_maintenance_rate
            // 
            this.vor_repairs_maintenance_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorRepairsMaintenanceRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_repairs_maintenance_rate.Enabled = false;
            this.vor_repairs_maintenance_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_repairs_maintenance_rate.Location = new System.Drawing.Point(189, 61);
            this.vor_repairs_maintenance_rate.Name = "vor_repairs_maintenance_rate";
            this.vor_repairs_maintenance_rate.Size = new System.Drawing.Size(68, 20);
            this.vor_repairs_maintenance_rate.TabIndex = 0;
            this.vor_repairs_maintenance_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vor_tyre_tubes_rate_t
            // 
            this.vor_tyre_tubes_rate_t.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_tyre_tubes_rate_t.Location = new System.Drawing.Point(9, 83);
            this.vor_tyre_tubes_rate_t.Name = "vor_tyre_tubes_rate_t";
            this.vor_tyre_tubes_rate_t.Size = new System.Drawing.Size(174, 14);
            this.vor_tyre_tubes_rate_t.TabIndex = 0;
            this.vor_tyre_tubes_rate_t.Text = "Vor Tyre Tubes Rate:";
            this.vor_tyre_tubes_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_tyre_tubes_rate
            // 
            this.vor_tyre_tubes_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorTyreTubesRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_tyre_tubes_rate.Enabled = false;
            this.vor_tyre_tubes_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_tyre_tubes_rate.Location = new System.Drawing.Point(188, 81);
            this.vor_tyre_tubes_rate.Name = "vor_tyre_tubes_rate";
            this.vor_tyre_tubes_rate.Size = new System.Drawing.Size(68, 20);
            this.vor_tyre_tubes_rate.TabIndex = 0;
            this.vor_tyre_tubes_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vor_vehical_allowance_rate_t
            // 
            this.vor_vehical_allowance_rate_t.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_vehical_allowance_rate_t.Location = new System.Drawing.Point(9, 103);
            this.vor_vehical_allowance_rate_t.Name = "vor_vehical_allowance_rate_t";
            this.vor_vehical_allowance_rate_t.Size = new System.Drawing.Size(174, 14);
            this.vor_vehical_allowance_rate_t.TabIndex = 0;
            this.vor_vehical_allowance_rate_t.Text = "Vor Vehical Allowance Rate:";
            this.vor_vehical_allowance_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_vehical_allowance_rate
            // 
            this.vor_vehical_allowance_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorVehicalAllowanceRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_vehical_allowance_rate.Enabled = false;
            this.vor_vehical_allowance_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_vehical_allowance_rate.Location = new System.Drawing.Point(188, 101);
            this.vor_vehical_allowance_rate.Name = "vor_vehical_allowance_rate";
            this.vor_vehical_allowance_rate.Size = new System.Drawing.Size(68, 20);
            this.vor_vehical_allowance_rate.TabIndex = 0;
            this.vor_vehical_allowance_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vor_licence_rate_t
            // 
            this.vor_licence_rate_t.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_licence_rate_t.Location = new System.Drawing.Point(9, 123);
            this.vor_licence_rate_t.Name = "vor_licence_rate_t";
            this.vor_licence_rate_t.Size = new System.Drawing.Size(174, 14);
            this.vor_licence_rate_t.TabIndex = 0;
            this.vor_licence_rate_t.Text = "Vor Licence Rate:";
            this.vor_licence_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_licence_rate
            // 
            this.vor_licence_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorLicenceRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_licence_rate.Enabled = false;
            this.vor_licence_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_licence_rate.Location = new System.Drawing.Point(188, 121);
            this.vor_licence_rate.Name = "vor_licence_rate";
            this.vor_licence_rate.Size = new System.Drawing.Size(68, 20);
            this.vor_licence_rate.TabIndex = 0;
            this.vor_licence_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vor_vehicle_rate_of_return_pct_t
            // 
            this.vor_vehicle_rate_of_return_pct_t.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_vehicle_rate_of_return_pct_t.Location = new System.Drawing.Point(9, 144);
            this.vor_vehicle_rate_of_return_pct_t.Name = "vor_vehicle_rate_of_return_pct_t";
            this.vor_vehicle_rate_of_return_pct_t.Size = new System.Drawing.Size(174, 14);
            this.vor_vehicle_rate_of_return_pct_t.TabIndex = 0;
            this.vor_vehicle_rate_of_return_pct_t.Text = "Vor Vehicle Rate Of Return Pct:";
            this.vor_vehicle_rate_of_return_pct_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_vehicle_rate_of_return_pct
            // 
            this.vor_vehicle_rate_of_return_pct.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorVehicleRateOfReturnPct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_vehicle_rate_of_return_pct.Enabled = false;
            this.vor_vehicle_rate_of_return_pct.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_vehicle_rate_of_return_pct.Location = new System.Drawing.Point(188, 141);
            this.vor_vehicle_rate_of_return_pct.Name = "vor_vehicle_rate_of_return_pct";
            this.vor_vehicle_rate_of_return_pct.Size = new System.Drawing.Size(68, 20);
            this.vor_vehicle_rate_of_return_pct.TabIndex = 0;
            this.vor_vehicle_rate_of_return_pct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vor_salvage_ratio_t
            // 
            this.vor_salvage_ratio_t.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_salvage_ratio_t.Location = new System.Drawing.Point(8, 164);
            this.vor_salvage_ratio_t.Name = "vor_salvage_ratio_t";
            this.vor_salvage_ratio_t.Size = new System.Drawing.Size(174, 14);
            this.vor_salvage_ratio_t.TabIndex = 0;
            this.vor_salvage_ratio_t.Text = "Vor Salvage Ratio:";
            this.vor_salvage_ratio_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_salvage_ratio
            // 
            this.vor_salvage_ratio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorSalvageRatio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_salvage_ratio.Enabled = false;
            this.vor_salvage_ratio.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_salvage_ratio.Location = new System.Drawing.Point(188, 161);
            this.vor_salvage_ratio.Name = "vor_salvage_ratio";
            this.vor_salvage_ratio.Size = new System.Drawing.Size(68, 20);
            this.vor_salvage_ratio.TabIndex = 0;
            this.vor_salvage_ratio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vor_ruc
            // 
            this.vor_ruc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorRuc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_ruc.Enabled = false;
            this.vor_ruc.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_ruc.Location = new System.Drawing.Point(188, 181);
            this.vor_ruc.Name = "vor_ruc";
            this.vor_ruc.Size = new System.Drawing.Size(248, 20);
            this.vor_ruc.TabIndex = 0;
            // 
            // vor_sundries_k
            // 
            this.vor_sundries_k.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorSundriesK", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_sundries_k.Enabled = false;
            this.vor_sundries_k.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_sundries_k.Location = new System.Drawing.Point(188, 201);
            this.vor_sundries_k.Name = "vor_sundries_k";
            this.vor_sundries_k.Size = new System.Drawing.Size(248, 20);
            this.vor_sundries_k.TabIndex = 0;
            // 
            // vor_vehicle_insurance_premium
            // 
            this.vor_vehicle_insurance_premium.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorVehicleInsurancePremium", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_vehicle_insurance_premium.Enabled = false;
            this.vor_vehicle_insurance_premium.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_vehicle_insurance_premium.Location = new System.Drawing.Point(188, 221);
            this.vor_vehicle_insurance_premium.Name = "vor_vehicle_insurance_premium";
            this.vor_vehicle_insurance_premium.Size = new System.Drawing.Size(248, 20);
            this.vor_vehicle_insurance_premium.TabIndex = 0;
            // 
            // vor_fuel_rate
            // 
            this.vor_fuel_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorFuelRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_fuel_rate.Enabled = false;
            this.vor_fuel_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_fuel_rate.Location = new System.Drawing.Point(188, 241);
            this.vor_fuel_rate.Name = "vor_fuel_rate";
            this.vor_fuel_rate.Size = new System.Drawing.Size(248, 20);
            this.vor_fuel_rate.TabIndex = 0;
            // 
            // vor_consumption_rate
            // 
            this.vor_consumption_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorConsumptionRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_consumption_rate.Enabled = false;
            this.vor_consumption_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_consumption_rate.Location = new System.Drawing.Point(188, 261);
            this.vor_consumption_rate.Name = "vor_consumption_rate";
            this.vor_consumption_rate.Size = new System.Drawing.Size(248, 20);
            this.vor_consumption_rate.TabIndex = 0;
            // 
            // vor_livery
            // 
            this.vor_livery.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorLivery", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_livery.Enabled = false;
            this.vor_livery.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_livery.Location = new System.Drawing.Point(188, 281);
            this.vor_livery.Name = "vor_livery";
            this.vor_livery.Size = new System.Drawing.Size(248, 20);
            this.vor_livery.TabIndex = 0;
            // 
            // vor_effective_date
            // 
            this.vor_effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorEffectiveDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_effective_date.Enabled = false;
            this.vor_effective_date.Font = new System.Drawing.Font("Arial", 8F);
            this.vor_effective_date.Location = new System.Drawing.Point(188, 301);
            this.vor_effective_date.Name = "vor_effective_date";
            this.vor_effective_date.Size = new System.Drawing.Size(109, 20);
            this.vor_effective_date.TabIndex = 0;
            // 
            // DsVehicleOverrideRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contract_no_t);
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.contract_seq_number_t);
            this.Controls.Add(this.contract_seq_number);
            this.Controls.Add(this.vor_nominal_vehicle_value_t);
            this.Controls.Add(this.vor_nominal_vehicle_value);
            this.Controls.Add(this.vor_repairs_maintenance_rate_t);
            this.Controls.Add(this.vor_repairs_maintenance_rate);
            this.Controls.Add(this.vor_tyre_tubes_rate_t);
            this.Controls.Add(this.vor_tyre_tubes_rate);
            this.Controls.Add(this.vor_vehical_allowance_rate_t);
            this.Controls.Add(this.vor_vehical_allowance_rate);
            this.Controls.Add(this.vor_licence_rate_t);
            this.Controls.Add(this.vor_licence_rate);
            this.Controls.Add(this.vor_vehicle_rate_of_return_pct_t);
            this.Controls.Add(this.vor_vehicle_rate_of_return_pct);
            this.Controls.Add(this.vor_salvage_ratio_t);
            this.Controls.Add(this.vor_salvage_ratio);
            this.Controls.Add(this.vor_ruc);
            this.Controls.Add(this.vor_sundries_k);
            this.Controls.Add(this.vor_vehicle_insurance_premium);
            this.Controls.Add(this.vor_fuel_rate);
            this.Controls.Add(this.vor_consumption_rate);
            this.Controls.Add(this.vor_livery);
            this.Controls.Add(this.vor_effective_date);
            this.Name = "DsVehicleOverrideRate";
            this.Size = new System.Drawing.Size(650, 329);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.TextBox contract_no;
        private System.Windows.Forms.Label contract_seq_number_t;
        private System.Windows.Forms.TextBox contract_seq_number;
        private System.Windows.Forms.Label vor_nominal_vehicle_value_t;
        private System.Windows.Forms.TextBox vor_nominal_vehicle_value;
        private System.Windows.Forms.Label vor_repairs_maintenance_rate_t;
        private System.Windows.Forms.TextBox vor_repairs_maintenance_rate;
        private System.Windows.Forms.Label vor_tyre_tubes_rate_t;
        private System.Windows.Forms.TextBox vor_tyre_tubes_rate;
        private System.Windows.Forms.Label vor_vehical_allowance_rate_t;
        private System.Windows.Forms.TextBox vor_vehical_allowance_rate;
        private System.Windows.Forms.Label vor_licence_rate_t;
        private System.Windows.Forms.TextBox vor_licence_rate;
        private System.Windows.Forms.Label vor_vehicle_rate_of_return_pct_t;
        private System.Windows.Forms.TextBox vor_vehicle_rate_of_return_pct;
        private System.Windows.Forms.Label vor_salvage_ratio_t;
        private System.Windows.Forms.TextBox vor_salvage_ratio;
        private System.Windows.Forms.TextBox vor_ruc;
        private System.Windows.Forms.TextBox vor_sundries_k;
        private System.Windows.Forms.TextBox vor_vehicle_insurance_premium;
        private System.Windows.Forms.TextBox vor_fuel_rate;
        private System.Windows.Forms.TextBox vor_consumption_rate;
        private System.Windows.Forms.TextBox vor_livery;
        private System.Windows.Forms.TextBox vor_effective_date;
    }
}
