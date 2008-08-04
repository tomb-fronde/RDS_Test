namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractRates
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
            this.Name = "DContractRates";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractRates);
            #region st_renewal define
            this.st_renewal = new System.Windows.Forms.Label();
            this.st_renewal.Name = "st_renewal";
            this.st_renewal.Location = new System.Drawing.Point(4, 6);
            this.st_renewal.Size = new System.Drawing.Size(436, 13);
            this.st_renewal.TabIndex = 0;
            this.st_renewal.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.st_renewal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_renewal.Text = "text";
            #endregion
            this.Controls.Add(st_renewal);
            #region st_readonly define
            this.st_readonly = new System.Windows.Forms.Label();
            this.st_readonly.Name = "st_readonly";
            this.st_readonly.Location = new System.Drawing.Point(549, 8);
            this.st_readonly.Size = new System.Drawing.Size(9, 14);
            this.st_readonly.TabIndex = 0;
            this.st_readonly.Font = new System.Drawing.Font("Arial", 8);
            this.st_readonly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_readonly.Text = "Y";
            this.st_readonly.Visible = false;
            #endregion
            this.Controls.Add(st_readonly);
            #region rr_nominal_vehical_value_t define
            this.rr_nominal_vehical_value_t = new System.Windows.Forms.Label();
            this.rr_nominal_vehical_value_t.Name = "rr_nominal_vehical_value_t";
            this.rr_nominal_vehical_value_t.Location = new System.Drawing.Point(18, 24);
            this.rr_nominal_vehical_value_t.Size = new System.Drawing.Size(149, 13);
            this.rr_nominal_vehical_value_t.TabIndex = 0;
            this.rr_nominal_vehical_value_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_nominal_vehical_value_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_nominal_vehical_value_t.Text = "Nominal Vehicle Value ($)";
            #endregion
            this.Controls.Add(rr_nominal_vehical_value_t);
            #region rr_wage_hourly_rate_t define
            this.rr_wage_hourly_rate_t = new System.Windows.Forms.Label();
            this.rr_wage_hourly_rate_t.Name = "rr_wage_hourly_rate_t";
            this.rr_wage_hourly_rate_t.Location = new System.Drawing.Point(27, 48);
            this.rr_wage_hourly_rate_t.Size = new System.Drawing.Size(140, 13);
            this.rr_wage_hourly_rate_t.TabIndex = 0;
            this.rr_wage_hourly_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_wage_hourly_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_wage_hourly_rate_t.Text = "Wage Hourly Rate ($)";
            #endregion
            this.Controls.Add(rr_wage_hourly_rate_t);
            #region rr_repairs_maintenance_rate_t define
            this.rr_repairs_maintenance_rate_t = new System.Windows.Forms.Label();
            this.rr_repairs_maintenance_rate_t.Name = "rr_repairs_maintenance_rate_t";
            this.rr_repairs_maintenance_rate_t.Location = new System.Drawing.Point(10, 72);
            this.rr_repairs_maintenance_rate_t.Size = new System.Drawing.Size(157, 13);
            this.rr_repairs_maintenance_rate_t.TabIndex = 0;
            this.rr_repairs_maintenance_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_repairs_maintenance_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_repairs_maintenance_rate_t.Text = "Rep Maint Rate ($/1000k)";
            #endregion
            this.Controls.Add(rr_repairs_maintenance_rate_t);
            #region rr_public_liability_rate_t define
            this.rr_public_liability_rate_t = new System.Windows.Forms.Label();
            this.rr_public_liability_rate_t.Name = "rr_public_liability_rate_t";
            this.rr_public_liability_rate_t.Location = new System.Drawing.Point(27, 168);
            this.rr_public_liability_rate_t.Size = new System.Drawing.Size(140, 13);
            this.rr_public_liability_rate_t.TabIndex = 0;
            this.rr_public_liability_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_public_liability_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_public_liability_rate_t.Text = "Public Liability ($ pa)";
            #endregion
            this.Controls.Add(rr_public_liability_rate_t);
            #region rr_vehical_insurance_premium_t define
            this.rr_vehical_insurance_premium_t = new System.Windows.Forms.Label();
            this.rr_vehical_insurance_premium_t.Name = "rr_vehical_insurance_premium_t";
            this.rr_vehical_insurance_premium_t.Location = new System.Drawing.Point(27, 144);
            this.rr_vehical_insurance_premium_t.Size = new System.Drawing.Size(140, 13);
            this.rr_vehical_insurance_premium_t.TabIndex = 0;
            this.rr_vehical_insurance_premium_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_vehical_insurance_premium_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_vehical_insurance_premium_t.Text = "Vehicle Insurance ($ pa)";
            #endregion
            this.Controls.Add(rr_vehical_insurance_premium_t);
            #region rr_vehical_allowance_rate_t define
            this.rr_vehical_allowance_rate_t = new System.Windows.Forms.Label();
            this.rr_vehical_allowance_rate_t.Name = "rr_vehical_allowance_rate_t";
            this.rr_vehical_allowance_rate_t.Location = new System.Drawing.Point(27, 120);
            this.rr_vehical_allowance_rate_t.Size = new System.Drawing.Size(140, 13);
            this.rr_vehical_allowance_rate_t.TabIndex = 0;
            this.rr_vehical_allowance_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_vehical_allowance_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_vehical_allowance_rate_t.Text = "Vehicle Dep ($/1000k)";
            #endregion
            this.Controls.Add(rr_vehical_allowance_rate_t);
            #region rr_tyre_tubes_rate_t define
            this.rr_tyre_tubes_rate_t = new System.Windows.Forms.Label();
            this.rr_tyre_tubes_rate_t.Name = "rr_tyre_tubes_rate_t";
            this.rr_tyre_tubes_rate_t.Location = new System.Drawing.Point(27, 96);
            this.rr_tyre_tubes_rate_t.Size = new System.Drawing.Size(140, 13);
            this.rr_tyre_tubes_rate_t.TabIndex = 0;
            this.rr_tyre_tubes_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_tyre_tubes_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_tyre_tubes_rate_t.Text = "Tyre Tubes ($/1000k)";
            #endregion
            this.Controls.Add(rr_tyre_tubes_rate_t);
            #region rr_carrier_risk_rate_t define
            this.rr_carrier_risk_rate_t = new System.Windows.Forms.Label();
            this.rr_carrier_risk_rate_t.Name = "rr_carrier_risk_rate_t";
            this.rr_carrier_risk_rate_t.Location = new System.Drawing.Point(285, 24);
            this.rr_carrier_risk_rate_t.Size = new System.Drawing.Size(124, 13);
            this.rr_carrier_risk_rate_t.TabIndex = 0;
            this.rr_carrier_risk_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_carrier_risk_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_carrier_risk_rate_t.Text = "Carrier Risk ($ pa)";
            #endregion
            this.Controls.Add(rr_carrier_risk_rate_t);
            #region rr_acc_rate_t define
            this.rr_acc_rate_t = new System.Windows.Forms.Label();
            this.rr_acc_rate_t.Name = "rr_acc_rate_t";
            this.rr_acc_rate_t.Location = new System.Drawing.Point(316, 48);
            this.rr_acc_rate_t.Size = new System.Drawing.Size(93, 13);
            this.rr_acc_rate_t.TabIndex = 0;
            this.rr_acc_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_acc_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_acc_rate_t.Text = "ACC (%)";
            #endregion
            this.Controls.Add(rr_acc_rate_t);
            #region rr_licence_rate_t define
            this.rr_licence_rate_t = new System.Windows.Forms.Label();
            this.rr_licence_rate_t.Name = "rr_licence_rate_t";
            this.rr_licence_rate_t.Location = new System.Drawing.Point(256, 72);
            this.rr_licence_rate_t.Size = new System.Drawing.Size(154, 13);
            this.rr_licence_rate_t.TabIndex = 0;
            this.rr_licence_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_licence_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_licence_rate_t.Text = "Relicensing ($ pa)";
            #endregion
            this.Controls.Add(rr_licence_rate_t);
            #region rr_vehical_rate_of_return_pct_t define
            this.rr_vehical_rate_of_return_pct_t = new System.Windows.Forms.Label();
            this.rr_vehical_rate_of_return_pct_t.Name = "rr_vehical_rate_of_return_pct_t";
            this.rr_vehical_rate_of_return_pct_t.Location = new System.Drawing.Point(258, 96);
            this.rr_vehical_rate_of_return_pct_t.Size = new System.Drawing.Size(152, 13);
            this.rr_vehical_rate_of_return_pct_t.TabIndex = 0;
            this.rr_vehical_rate_of_return_pct_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_vehical_rate_of_return_pct_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_vehical_rate_of_return_pct_t.Text = "Vehicle Rate Of Return (%)";
            #endregion
            this.Controls.Add(rr_vehical_rate_of_return_pct_t);
            #region rr_salvage_ratio_t define
            this.rr_salvage_ratio_t = new System.Windows.Forms.Label();
            this.rr_salvage_ratio_t.Name = "rr_salvage_ratio_t";
            this.rr_salvage_ratio_t.Location = new System.Drawing.Point(259, 120);
            this.rr_salvage_ratio_t.Size = new System.Drawing.Size(150, 13);
            this.rr_salvage_ratio_t.TabIndex = 0;
            this.rr_salvage_ratio_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_salvage_ratio_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_salvage_ratio_t.Text = "Salvage Ratio (%)";
            #endregion
            this.Controls.Add(rr_salvage_ratio_t);
            #region rr_item_processing_rate_per_h_t define
            this.rr_item_processing_rate_per_h_t = new System.Windows.Forms.Label();
            this.rr_item_processing_rate_per_h_t.Name = "rr_item_processing_rate_per_h_t";
            this.rr_item_processing_rate_per_h_t.Location = new System.Drawing.Point(260, 144);
            this.rr_item_processing_rate_per_h_t.Size = new System.Drawing.Size(149, 13);
            this.rr_item_processing_rate_per_h_t.TabIndex = 0;
            this.rr_item_processing_rate_per_h_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_item_processing_rate_per_h_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rr_item_processing_rate_per_h_t.Text = "Item Processing Rate/Hr";
            #endregion
            this.Controls.Add(rr_item_processing_rate_per_h_t);
            #region n_61062380 define
            this.n_61062380 = new System.Windows.Forms.Label();
            this.n_61062380.Name = "n_61062380";
            this.n_61062380.Location = new System.Drawing.Point(269, 168);
            this.n_61062380.Size = new System.Drawing.Size(140, 13);
            this.n_61062380.TabIndex = 0;
            this.n_61062380.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_61062380.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_61062380.Text = "Fuel Rate (cents/litre)";
            #endregion
            this.Controls.Add(n_61062380);
            #region n_12690509 define
            this.n_12690509 = new System.Windows.Forms.Label();
            this.n_12690509.Name = "n_12690509";
            this.n_12690509.Location = new System.Drawing.Point(268, 192);
            this.n_12690509.Size = new System.Drawing.Size(140, 13);
            this.n_12690509.TabIndex = 0;
            this.n_12690509.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_12690509.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_12690509.Text = "Sundries ($/1000k)";
            #endregion
            this.Controls.Add(n_12690509);
            #region n_47105724 define
            this.n_47105724 = new System.Windows.Forms.Label();
            this.n_47105724.Name = "n_47105724";
            this.n_47105724.Location = new System.Drawing.Point(214, 216);
            this.n_47105724.Size = new System.Drawing.Size(195, 13);
            this.n_47105724.TabIndex = 0;
            this.n_47105724.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_47105724.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_47105724.Text = "Consumption Rate (litres/1000k)";
            #endregion
            this.Controls.Add(n_47105724);
            #region n_21298337 define
            this.n_21298337 = new System.Windows.Forms.Label();
            this.n_21298337.Name = "n_21298337";
            this.n_21298337.Location = new System.Drawing.Point(301, 252);
            this.n_21298337.Size = new System.Drawing.Size(108, 13);
            this.n_21298337.TabIndex = 0;
            this.n_21298337.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_21298337.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_21298337.Text = "Telephone ($ pa)";
            #endregion
            this.Controls.Add(n_21298337);
            #region n_57467309 define
            this.n_57467309 = new System.Windows.Forms.Label();
            this.n_57467309.Name = "n_57467309";
            this.n_57467309.Location = new System.Drawing.Point(297, 276);
            this.n_57467309.Size = new System.Drawing.Size(113, 13);
            this.n_57467309.TabIndex = 0;
            this.n_57467309.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_57467309.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_57467309.Text = "Sundries ($ pa)";
            #endregion
            this.Controls.Add(n_57467309);
            #region n_47443737 define
            this.n_47443737 = new System.Windows.Forms.Label();
            this.n_47443737.Name = "n_47443737";
            this.n_47443737.Location = new System.Drawing.Point(2, 252);
            this.n_47443737.Size = new System.Drawing.Size(165, 13);
            this.n_47443737.TabIndex = 0;
            this.n_47443737.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_47443737.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_47443737.Text = "Road User Charges ($/1000K)";
            #endregion
            this.Controls.Add(n_47443737);
            #region n_24340454 define
            this.n_24340454 = new System.Windows.Forms.Label();
            this.n_24340454.Name = "n_24340454";
            this.n_24340454.Location = new System.Drawing.Point(60, 276);
            this.n_24340454.Size = new System.Drawing.Size(107, 13);
            this.n_24340454.TabIndex = 0;
            this.n_24340454.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_24340454.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_24340454.Text = "Accounting ($ pa)";
            #endregion
            this.Controls.Add(n_24340454);
            #region rr_carrier_risk_rate define
            this.rr_carrier_risk_rate = new System.Windows.Forms.MaskedTextBox();
            this.rr_carrier_risk_rate.Name = "rr_carrier_risk_rate";
            this.rr_carrier_risk_rate.Location = new System.Drawing.Point(416, 24);
            this.rr_carrier_risk_rate.Size = new System.Drawing.Size(56, 20);
            this.rr_carrier_risk_rate.TabIndex = 80;
            this.rr_carrier_risk_rate.Enabled = false;
            this.rr_carrier_risk_rate.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_carrier_risk_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_carrier_risk_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrCarrierRiskRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_carrier_risk_rate.Mask = "#,###.00";
            this.rr_carrier_risk_rate.DataBindings[0].FormatString = "#,###.00";
            #endregion
            this.Controls.Add(rr_carrier_risk_rate);
            #region rr_acc_rate define
            this.rr_acc_rate = new System.Windows.Forms.MaskedTextBox();
            this.rr_acc_rate.Name = "rr_acc_rate";
            this.rr_acc_rate.Location = new System.Drawing.Point(416, 48);
            this.rr_acc_rate.Size = new System.Drawing.Size(56, 20);
            this.rr_acc_rate.TabIndex = 90;
            this.rr_acc_rate.Enabled = false;
            this.rr_acc_rate.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_acc_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_acc_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrAccRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_acc_rate.Mask = "#,###.00";
            this.rr_acc_rate.DataBindings[0].FormatString = "#,###.00";
            #endregion
            this.Controls.Add(rr_acc_rate);
            #region rr_licence_rate define
            this.rr_licence_rate = new System.Windows.Forms.MaskedTextBox();
            this.rr_licence_rate.Name = "rr_licence_rate";
            this.rr_licence_rate.Location = new System.Drawing.Point(416, 72);
            this.rr_licence_rate.Size = new System.Drawing.Size(56, 20);
            this.rr_licence_rate.TabIndex = 100;
            this.rr_licence_rate.Enabled = false;
            this.rr_licence_rate.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_licence_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_licence_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrLicenceRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_licence_rate.Mask = "#,###.00";
            this.rr_licence_rate.DataBindings[0].FormatString = "#,###.00";
            #endregion
            this.Controls.Add(rr_licence_rate);
            #region rr_vehical_rate_of_return_pct define
            this.rr_vehical_rate_of_return_pct = new System.Windows.Forms.MaskedTextBox();
            this.rr_vehical_rate_of_return_pct.Name = "rr_vehical_rate_of_return_pct";
            this.rr_vehical_rate_of_return_pct.Location = new System.Drawing.Point(416, 96);
            this.rr_vehical_rate_of_return_pct.Size = new System.Drawing.Size(56, 20);
            this.rr_vehical_rate_of_return_pct.TabIndex = 110;
            this.rr_vehical_rate_of_return_pct.Enabled = false;
            this.rr_vehical_rate_of_return_pct.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_vehical_rate_of_return_pct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_vehical_rate_of_return_pct.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrVehicalRateOfReturnPct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_vehical_rate_of_return_pct.Mask = "#,###.00";
            this.rr_vehical_rate_of_return_pct.DataBindings[0].FormatString = "#,###.00";
            #endregion
            this.Controls.Add(rr_vehical_rate_of_return_pct);
            #region rr_salvage_ratio define
            this.rr_salvage_ratio = new System.Windows.Forms.MaskedTextBox();
            this.rr_salvage_ratio.Name = "rr_salvage_ratio";
            this.rr_salvage_ratio.Location = new System.Drawing.Point(416, 120);
            this.rr_salvage_ratio.Size = new System.Drawing.Size(56, 20);
            this.rr_salvage_ratio.TabIndex = 120;
            this.rr_salvage_ratio.Enabled = false;
            this.rr_salvage_ratio.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_salvage_ratio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_salvage_ratio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrSalvageRatio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_salvage_ratio.Mask = "#,###.00";
            this.rr_salvage_ratio.DataBindings[0].FormatString = "#,###.00";
            #endregion
            this.Controls.Add(rr_salvage_ratio);
            #region rr_item_proc_rate_per_hour define
            this.rr_item_proc_rate_per_hour = new System.Windows.Forms.MaskedTextBox();
            this.rr_item_proc_rate_per_hour.Name = "rr_item_proc_rate_per_hour";
            this.rr_item_proc_rate_per_hour.Location = new System.Drawing.Point(416, 144);
            this.rr_item_proc_rate_per_hour.Size = new System.Drawing.Size(56, 20);
            this.rr_item_proc_rate_per_hour.TabIndex = 130;
            this.rr_item_proc_rate_per_hour.Enabled = false;
            this.rr_item_proc_rate_per_hour.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_item_proc_rate_per_hour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_item_proc_rate_per_hour.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrItemProcRatePerHour", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_item_proc_rate_per_hour.DataBindings[0].FormatString = "##,###";
            this.rr_item_proc_rate_per_hour.Mask = "##,###";
            #endregion
            this.Controls.Add(rr_item_proc_rate_per_hour);
            #region rr_fuel_rate define
            this.rr_fuel_rate = new System.Windows.Forms.MaskedTextBox();
            this.rr_fuel_rate.Name = "rr_fuel_rate";
            this.rr_fuel_rate.Location = new System.Drawing.Point(416, 168);
            this.rr_fuel_rate.Size = new System.Drawing.Size(56, 20);
            this.rr_fuel_rate.TabIndex = 140;
            this.rr_fuel_rate.Enabled = false;
            this.rr_fuel_rate.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_fuel_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_fuel_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrFuelRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_fuel_rate.DataBindings[0].FormatString = "##.000";
            this.rr_fuel_rate.Mask = "##.000";
            #endregion
            this.Controls.Add(rr_fuel_rate);
            #region rr_sundries_k define
            this.rr_sundries_k = new System.Windows.Forms.TextBox();
            this.rr_sundries_k.Name = "rr_sundries_k";
            this.rr_sundries_k.Location = new System.Drawing.Point(416, 192);
            this.rr_sundries_k.Size = new System.Drawing.Size(56, 20);
            this.rr_sundries_k.TabIndex = 150;
            this.rr_sundries_k.Enabled = false;
            this.rr_sundries_k.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_sundries_k.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_sundries_k.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrSundriesK", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(rr_sundries_k);
            #region rr_consumption_rate define
            this.rr_consumption_rate = new System.Windows.Forms.MaskedTextBox();
            this.rr_consumption_rate.Name = "rr_consumption_rate";
            this.rr_consumption_rate.Location = new System.Drawing.Point(416, 216);
            this.rr_consumption_rate.Size = new System.Drawing.Size(56, 20);
            this.rr_consumption_rate.TabIndex = 160;
            this.rr_consumption_rate.Enabled = false;
            this.rr_consumption_rate.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_consumption_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_consumption_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrConsumptionRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_consumption_rate.Mask = "##.00";
            this.rr_consumption_rate.DataBindings[0].FormatString = "##.00";
            #endregion
            this.Controls.Add(rr_consumption_rate);
            #region rr_telephone define
            this.rr_telephone = new System.Windows.Forms.TextBox();
            this.rr_telephone.Name = "rr_telephone";
            this.rr_telephone.Location = new System.Drawing.Point(416, 252);
            this.rr_telephone.Size = new System.Drawing.Size(56, 20);
            this.rr_telephone.TabIndex = 190;
            this.rr_telephone.Enabled = false;
            this.rr_telephone.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_telephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(rr_telephone);
            #region rr_sundries define
            this.rr_sundries = new System.Windows.Forms.TextBox();
            this.rr_sundries.Name = "rr_sundries";
            this.rr_sundries.Location = new System.Drawing.Point(416, 276);
            this.rr_sundries.Size = new System.Drawing.Size(56, 20);
            this.rr_sundries.TabIndex = 200;
            this.rr_sundries.Enabled = false;
            this.rr_sundries.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_sundries.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_sundries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrSundries", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(rr_sundries);
            #region rr_ruc define
            this.rr_ruc = new System.Windows.Forms.TextBox();
            this.rr_ruc.Name = "rr_ruc";
            this.rr_ruc.Location = new System.Drawing.Point(174, 252);
            this.rr_ruc.Size = new System.Drawing.Size(56, 20);
            this.rr_ruc.TabIndex = 170;
            this.rr_ruc.Enabled = false;
            this.rr_ruc.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_ruc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.rr_ruc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrRuc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(rr_ruc);
            #region rr_accounting define
            this.rr_accounting = new System.Windows.Forms.TextBox();
            this.rr_accounting.Name = "rr_accounting";
            this.rr_accounting.Location = new System.Drawing.Point(174, 276);
            this.rr_accounting.Size = new System.Drawing.Size(56, 20);
            this.rr_accounting.TabIndex = 180;
            this.rr_accounting.Enabled = false;
            this.rr_accounting.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_accounting.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.rr_accounting.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrAccounting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(rr_accounting);
            #region rr_nominal_vehical_value define
            this.rr_nominal_vehical_value = new System.Windows.Forms.MaskedTextBox();
            this.rr_nominal_vehical_value.Name = "rr_nominal_vehical_value";
            this.rr_nominal_vehical_value.Location = new System.Drawing.Point(174, 24);
            this.rr_nominal_vehical_value.Size = new System.Drawing.Size(56, 20);
            this.rr_nominal_vehical_value.TabIndex = 10;
            this.rr_nominal_vehical_value.Enabled = false;
            this.rr_nominal_vehical_value.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_nominal_vehical_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_nominal_vehical_value.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrNominalVehicalValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_nominal_vehical_value.Mask = "###,###";
            this.rr_nominal_vehical_value.DataBindings[0].FormatString = "###,###";
            #endregion
            this.Controls.Add(rr_nominal_vehical_value);
            #region rr_wage_hourly_rate define
            this.rr_wage_hourly_rate = new System.Windows.Forms.MaskedTextBox();
            this.rr_wage_hourly_rate.Name = "rr_wage_hourly_rate";
            this.rr_wage_hourly_rate.Location = new System.Drawing.Point(174, 48);
            this.rr_wage_hourly_rate.Size = new System.Drawing.Size(56, 20);
            this.rr_wage_hourly_rate.TabIndex = 20;
            this.rr_wage_hourly_rate.Enabled = false;
            this.rr_wage_hourly_rate.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_wage_hourly_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_wage_hourly_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrWageHourlyRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_wage_hourly_rate.Mask = "##.00";
            this.rr_wage_hourly_rate.DataBindings[0].FormatString = "##.00";
            #endregion
            this.Controls.Add(rr_wage_hourly_rate);
            #region rr_repairs_maintenance_rate define
            this.rr_repairs_maintenance_rate = new System.Windows.Forms.MaskedTextBox();
            this.rr_repairs_maintenance_rate.Name = "rr_repairs_maintenance_rate";
            this.rr_repairs_maintenance_rate.Location = new System.Drawing.Point(174, 72);
            this.rr_repairs_maintenance_rate.Size = new System.Drawing.Size(56, 20);
            this.rr_repairs_maintenance_rate.TabIndex = 30;
            this.rr_repairs_maintenance_rate.Enabled = false;
            this.rr_repairs_maintenance_rate.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_repairs_maintenance_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_repairs_maintenance_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrRepairsMaintenanceRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_repairs_maintenance_rate.Mask = "#,###.00";
            this.rr_repairs_maintenance_rate.DataBindings[0].FormatString = "#,###.00";
            #endregion
            this.Controls.Add(rr_repairs_maintenance_rate);
            #region rr_tyre_tubes_rate define
            this.rr_tyre_tubes_rate = new System.Windows.Forms.MaskedTextBox();
            this.rr_tyre_tubes_rate.Name = "rr_tyre_tubes_rate";
            this.rr_tyre_tubes_rate.Location = new System.Drawing.Point(174, 96);
            this.rr_tyre_tubes_rate.Size = new System.Drawing.Size(56, 20);
            this.rr_tyre_tubes_rate.TabIndex = 40;
            this.rr_tyre_tubes_rate.Enabled = false;
            this.rr_tyre_tubes_rate.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_tyre_tubes_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_tyre_tubes_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrTyreTubesRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_tyre_tubes_rate.Mask = "#,###.00";
            this.rr_tyre_tubes_rate.DataBindings[0].FormatString = "#,###.00";
            #endregion
            this.Controls.Add(rr_tyre_tubes_rate);
            #region rr_vehical_allowance_rate define
            this.rr_vehical_allowance_rate = new System.Windows.Forms.MaskedTextBox();
            this.rr_vehical_allowance_rate.Name = "rr_vehical_allowance_rate";
            this.rr_vehical_allowance_rate.Location = new System.Drawing.Point(174, 120);
            this.rr_vehical_allowance_rate.Size = new System.Drawing.Size(56, 20);
            this.rr_vehical_allowance_rate.TabIndex = 50;
            this.rr_vehical_allowance_rate.Enabled = false;
            this.rr_vehical_allowance_rate.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_vehical_allowance_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_vehical_allowance_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrVehicalAllowanceRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_vehical_allowance_rate.Mask = "#,###.00";
            this.rr_vehical_allowance_rate.DataBindings[0].FormatString = "#,###.00";
            #endregion
            this.Controls.Add(rr_vehical_allowance_rate);
            #region rr_vehical_insurance_premium define
            this.rr_vehical_insurance_premium = new System.Windows.Forms.MaskedTextBox();
            this.rr_vehical_insurance_premium.Name = "rr_vehical_insurance_premium";
            this.rr_vehical_insurance_premium.Location = new System.Drawing.Point(174, 144);
            this.rr_vehical_insurance_premium.Size = new System.Drawing.Size(56, 20);
            this.rr_vehical_insurance_premium.TabIndex = 60;
            this.rr_vehical_insurance_premium.Enabled = false;
            this.rr_vehical_insurance_premium.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_vehical_insurance_premium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_vehical_insurance_premium.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrVehicalInsurancePremium", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_vehical_insurance_premium.Mask = "#,###.00";
            this.rr_vehical_insurance_premium.DataBindings[0].FormatString = "#,###.00";
            #endregion
            this.Controls.Add(rr_vehical_insurance_premium);
            #region rr_public_liability_rate_2 define
            this.rr_public_liability_rate_2 = new System.Windows.Forms.MaskedTextBox();
            this.rr_public_liability_rate_2.Name = "rr_public_liability_rate_2";
            this.rr_public_liability_rate_2.Location = new System.Drawing.Point(174, 168);
            this.rr_public_liability_rate_2.Size = new System.Drawing.Size(56, 20);
            this.rr_public_liability_rate_2.TabIndex = 70;
            this.rr_public_liability_rate_2.Enabled = false;
            this.rr_public_liability_rate_2.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rr_public_liability_rate_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rr_public_liability_rate_2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RrPublicLiabilityRate2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rr_public_liability_rate_2.Mask = "#,###.00";
            this.rr_public_liability_rate_2.DataBindings[0].FormatString = "#,###.00";
            #endregion
            this.Controls.Add(rr_public_liability_rate_2);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.Label st_renewal;
        private System.Windows.Forms.Label st_readonly;
        private System.Windows.Forms.Label rr_nominal_vehical_value_t;
        private System.Windows.Forms.Label rr_wage_hourly_rate_t;
        private System.Windows.Forms.Label rr_repairs_maintenance_rate_t;
        private System.Windows.Forms.Label rr_public_liability_rate_t;
        private System.Windows.Forms.Label rr_vehical_insurance_premium_t;
        private System.Windows.Forms.Label rr_vehical_allowance_rate_t;
        private System.Windows.Forms.Label rr_tyre_tubes_rate_t;
        private System.Windows.Forms.Label rr_carrier_risk_rate_t;
        private System.Windows.Forms.Label rr_acc_rate_t;
        private System.Windows.Forms.Label rr_licence_rate_t;
        private System.Windows.Forms.Label rr_vehical_rate_of_return_pct_t;
        private System.Windows.Forms.Label rr_salvage_ratio_t;
        private System.Windows.Forms.Label rr_item_processing_rate_per_h_t;
        private System.Windows.Forms.Label n_61062380;
        private System.Windows.Forms.Label n_12690509;
        private System.Windows.Forms.Label n_47105724;
        private System.Windows.Forms.Label n_21298337;
        private System.Windows.Forms.Label n_57467309;
        private System.Windows.Forms.Label n_47443737;
        private System.Windows.Forms.Label n_24340454;
        private System.Windows.Forms.MaskedTextBox rr_carrier_risk_rate;
        private System.Windows.Forms.MaskedTextBox rr_acc_rate;
        private System.Windows.Forms.MaskedTextBox rr_licence_rate;
        private System.Windows.Forms.MaskedTextBox rr_vehical_rate_of_return_pct;
        private System.Windows.Forms.MaskedTextBox rr_salvage_ratio;
        private System.Windows.Forms.MaskedTextBox rr_item_proc_rate_per_hour;
        private System.Windows.Forms.MaskedTextBox rr_fuel_rate;
        private System.Windows.Forms.TextBox rr_sundries_k;
        private System.Windows.Forms.MaskedTextBox rr_consumption_rate;
        private System.Windows.Forms.TextBox rr_telephone;
        private System.Windows.Forms.TextBox rr_sundries;
        private System.Windows.Forms.TextBox rr_ruc;
        private System.Windows.Forms.TextBox rr_accounting;
        private System.Windows.Forms.MaskedTextBox rr_nominal_vehical_value;
        private System.Windows.Forms.MaskedTextBox rr_wage_hourly_rate;
        private System.Windows.Forms.MaskedTextBox rr_repairs_maintenance_rate;
        private System.Windows.Forms.MaskedTextBox rr_tyre_tubes_rate;
        private System.Windows.Forms.MaskedTextBox rr_vehical_allowance_rate;
        private System.Windows.Forms.MaskedTextBox rr_vehical_insurance_premium;
        private System.Windows.Forms.MaskedTextBox rr_public_liability_rate_2;
    }
}
