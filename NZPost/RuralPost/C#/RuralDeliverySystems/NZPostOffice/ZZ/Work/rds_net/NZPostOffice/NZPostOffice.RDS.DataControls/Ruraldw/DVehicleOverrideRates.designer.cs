using System.Windows.Forms;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DVehicleOverrideRates
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
            this.contract_no = new System.Windows.Forms.TextBox();
            this.contract_seq_number = new System.Windows.Forms.TextBox();
            this.t_1 = new System.Windows.Forms.Label();
            this.vor_effective_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
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
            this.vor_ruc_t = new System.Windows.Forms.Label();
            this.vor_ruc = new System.Windows.Forms.TextBox();
            this.vor_sundries_k_t = new System.Windows.Forms.Label();
            this.vor_sundries_k = new System.Windows.Forms.TextBox();
            this.vor_vehicle_insurance_base_premium_t = new System.Windows.Forms.Label();
            this.vor_vehicle_insurance_premium = new System.Windows.Forms.TextBox();
            this.vor_fuel_rate_t = new System.Windows.Forms.Label();
            this.vor_fuel_rate = new System.Windows.Forms.TextBox();
            this.vor_consumption_rate_t = new System.Windows.Forms.Label();
            this.vor_consumption_rate = new System.Windows.Forms.TextBox();
            this.t_2 = new System.Windows.Forms.Label();
            this.vor_livery = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.VehicleOverrideRates);
            // 
            // contract_no
            // 
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.Enabled = false;
            this.contract_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.contract_no.Location = new System.Drawing.Point(389, 5);
            this.contract_no.Name = "contract_no";
            this.contract_no.Size = new System.Drawing.Size(32, 26);
            this.contract_no.TabIndex = 0;
            // 
            // contract_seq_number
            // 
            this.contract_seq_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractSeqNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_seq_number.Enabled = false;
            this.contract_seq_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.contract_seq_number.Location = new System.Drawing.Point(390, 33);
            this.contract_seq_number.Name = "contract_seq_number";
            this.contract_seq_number.Size = new System.Drawing.Size(32, 26);
            this.contract_seq_number.TabIndex = 0;
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.Location = new System.Drawing.Point(4, 5);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(232, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "Effective Date";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_effective_date
            // 
            this.vor_effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VorEffectiveDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_effective_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_effective_date.Location = new System.Drawing.Point(241, 2);
            this.vor_effective_date.Mask = "00/00/0000";
            this.vor_effective_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.vor_effective_date.Name = "vor_effective_date";
            this.vor_effective_date.Size = new System.Drawing.Size(77, 20);
            this.vor_effective_date.TabIndex = 10;
            this.vor_effective_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vor_nominal_vehicle_value_t
            // 
            this.vor_nominal_vehicle_value_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_nominal_vehicle_value_t.Location = new System.Drawing.Point(4, 23);
            this.vor_nominal_vehicle_value_t.Name = "vor_nominal_vehicle_value_t";
            this.vor_nominal_vehicle_value_t.Size = new System.Drawing.Size(232, 13);
            this.vor_nominal_vehicle_value_t.TabIndex = 0;
            this.vor_nominal_vehicle_value_t.Text = "Net Vehicle Value ($)";
            this.vor_nominal_vehicle_value_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_nominal_vehicle_value
            // 
            this.vor_nominal_vehicle_value.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorNominalVehicleValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_nominal_vehicle_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_nominal_vehicle_value.Location = new System.Drawing.Point(241, 23);
            this.vor_nominal_vehicle_value.Name = "vor_nominal_vehicle_value";
            this.vor_nominal_vehicle_value.Size = new System.Drawing.Size(77, 20);
            this.vor_nominal_vehicle_value.TabIndex = 20;
            this.vor_nominal_vehicle_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_nominal_vehicle_value.DataBindings[0].DataSourceNullValue = null;
            this.vor_nominal_vehicle_value.DataBindings[0].NullValue = "";
            this.vor_nominal_vehicle_value.Validated += new System.EventHandler(Value_Validated);
            // 
            // vor_repairs_maintenance_rate_t
            // 
            this.vor_repairs_maintenance_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_repairs_maintenance_rate_t.Location = new System.Drawing.Point(3, 44);
            this.vor_repairs_maintenance_rate_t.Name = "vor_repairs_maintenance_rate_t";
            this.vor_repairs_maintenance_rate_t.Size = new System.Drawing.Size(232, 13);
            this.vor_repairs_maintenance_rate_t.TabIndex = 0;
            this.vor_repairs_maintenance_rate_t.Text = "Repairs and Maintenance Rate ($/1000k)";
            this.vor_repairs_maintenance_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_repairs_maintenance_rate
            // 
            this.vor_repairs_maintenance_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorRepairsMaintenanceRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_repairs_maintenance_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_repairs_maintenance_rate.Location = new System.Drawing.Point(241, 44);
            this.vor_repairs_maintenance_rate.Name = "vor_repairs_maintenance_rate";
            this.vor_repairs_maintenance_rate.Size = new System.Drawing.Size(77, 20);
            this.vor_repairs_maintenance_rate.TabIndex = 30;
            this.vor_repairs_maintenance_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_repairs_maintenance_rate.DataBindings[0].DataSourceNullValue = null;
            this.vor_repairs_maintenance_rate.DataBindings[0].NullValue = "";
            this.vor_repairs_maintenance_rate.Validated += new System.EventHandler(Value_Validated);
            // 
            // vor_tyre_tubes_rate_t
            // 
            this.vor_tyre_tubes_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_tyre_tubes_rate_t.Location = new System.Drawing.Point(3, 65);
            this.vor_tyre_tubes_rate_t.Name = "vor_tyre_tubes_rate_t";
            this.vor_tyre_tubes_rate_t.Size = new System.Drawing.Size(232, 13);
            this.vor_tyre_tubes_rate_t.TabIndex = 0;
            this.vor_tyre_tubes_rate_t.Text = "Tyres ($/1000k)";
            this.vor_tyre_tubes_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_tyre_tubes_rate
            // 
            this.vor_tyre_tubes_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorTyreTubesRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_tyre_tubes_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_tyre_tubes_rate.Location = new System.Drawing.Point(241, 65);
            this.vor_tyre_tubes_rate.Name = "vor_tyre_tubes_rate";
            this.vor_tyre_tubes_rate.Size = new System.Drawing.Size(77, 20);
            this.vor_tyre_tubes_rate.TabIndex = 40;
            this.vor_tyre_tubes_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_tyre_tubes_rate.DataBindings[0].DataSourceNullValue = null;
            this.vor_tyre_tubes_rate.DataBindings[0].NullValue = "";
            this.vor_tyre_tubes_rate.Validated += new System.EventHandler(Value_Validated);
            // 
            // vor_vehical_allowance_rate_t
            // 
            this.vor_vehical_allowance_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_vehical_allowance_rate_t.Location = new System.Drawing.Point(3, 86);
            this.vor_vehical_allowance_rate_t.Name = "vor_vehical_allowance_rate_t";
            this.vor_vehical_allowance_rate_t.Size = new System.Drawing.Size(232, 13);
            this.vor_vehical_allowance_rate_t.TabIndex = 0;
            this.vor_vehical_allowance_rate_t.Text = "Vehicle Allowance ($/1000k)";
            this.vor_vehical_allowance_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_vehical_allowance_rate
            // 
            this.vor_vehical_allowance_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorVehicalAllowanceRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_vehical_allowance_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_vehical_allowance_rate.Location = new System.Drawing.Point(241, 86);
            this.vor_vehical_allowance_rate.Name = "vor_vehical_allowance_rate";
            this.vor_vehical_allowance_rate.Size = new System.Drawing.Size(77, 20);
            this.vor_vehical_allowance_rate.TabIndex = 50;
            this.vor_vehical_allowance_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_vehical_allowance_rate.DataBindings[0].DataSourceNullValue = null;
            this.vor_vehical_allowance_rate.DataBindings[0].NullValue = "";
            this.vor_vehical_allowance_rate.Validated += new System.EventHandler(Value_Validated);
            // 
            // vor_licence_rate_t
            // 
            this.vor_licence_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_licence_rate_t.Location = new System.Drawing.Point(3, 107);
            this.vor_licence_rate_t.Name = "vor_licence_rate_t";
            this.vor_licence_rate_t.Size = new System.Drawing.Size(232, 13);
            this.vor_licence_rate_t.TabIndex = 0;
            this.vor_licence_rate_t.Text = "Relicensing ($ pa)";
            this.vor_licence_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_licence_rate
            // 
            this.vor_licence_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorLicenceRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_licence_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_licence_rate.Location = new System.Drawing.Point(241, 107);
            this.vor_licence_rate.Name = "vor_licence_rate";
            this.vor_licence_rate.Size = new System.Drawing.Size(77, 20);
            this.vor_licence_rate.TabIndex = 60;
            this.vor_licence_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_licence_rate.DataBindings[0].DataSourceNullValue = null;
            this.vor_licence_rate.DataBindings[0].NullValue = "";
            this.vor_licence_rate.Validated += new System.EventHandler(Value_Validated);
            // 
            // vor_vehicle_rate_of_return_pct_t
            // 
            this.vor_vehicle_rate_of_return_pct_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_vehicle_rate_of_return_pct_t.Location = new System.Drawing.Point(3, 128);
            this.vor_vehicle_rate_of_return_pct_t.Name = "vor_vehicle_rate_of_return_pct_t";
            this.vor_vehicle_rate_of_return_pct_t.Size = new System.Drawing.Size(232, 13);
            this.vor_vehicle_rate_of_return_pct_t.TabIndex = 0;
            this.vor_vehicle_rate_of_return_pct_t.Text = "Vehicle Rate Of Return (%)";
            this.vor_vehicle_rate_of_return_pct_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_vehicle_rate_of_return_pct
            // 
            this.vor_vehicle_rate_of_return_pct.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorVehicleRateOfReturnPct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_vehicle_rate_of_return_pct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_vehicle_rate_of_return_pct.Location = new System.Drawing.Point(241, 128);
            this.vor_vehicle_rate_of_return_pct.Name = "vor_vehicle_rate_of_return_pct";
            this.vor_vehicle_rate_of_return_pct.Size = new System.Drawing.Size(77, 20);
            this.vor_vehicle_rate_of_return_pct.TabIndex = 70;
            this.vor_vehicle_rate_of_return_pct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_vehicle_rate_of_return_pct.DataBindings[0].DataSourceNullValue = null;
            this.vor_vehicle_rate_of_return_pct.DataBindings[0].NullValue = "";
            this.vor_vehicle_rate_of_return_pct.Validated += new System.EventHandler(Value_Validated);
            // 
            // vor_salvage_ratio_t
            // 
            this.vor_salvage_ratio_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_salvage_ratio_t.Location = new System.Drawing.Point(3, 149);
            this.vor_salvage_ratio_t.Name = "vor_salvage_ratio_t";
            this.vor_salvage_ratio_t.Size = new System.Drawing.Size(232, 13);
            this.vor_salvage_ratio_t.TabIndex = 0;
            this.vor_salvage_ratio_t.Text = "Salvage Ratio (%)";
            this.vor_salvage_ratio_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_salvage_ratio
            // 
            this.vor_salvage_ratio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorSalvageRatio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_salvage_ratio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_salvage_ratio.Location = new System.Drawing.Point(241, 149);
            this.vor_salvage_ratio.Name = "vor_salvage_ratio";
            this.vor_salvage_ratio.Size = new System.Drawing.Size(77, 20);
            this.vor_salvage_ratio.TabIndex = 80;
            this.vor_salvage_ratio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_salvage_ratio.Validating += new System.ComponentModel.CancelEventHandler(TextBox_Validating);
            this.vor_salvage_ratio.DataBindings[0].DataSourceNullValue = null;
            this.vor_salvage_ratio.DataBindings[0].NullValue = "";
            this.vor_salvage_ratio.Validated += new System.EventHandler(Value_Validated);
            // 
            // vor_ruc_t
            // 
            this.vor_ruc_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_ruc_t.Location = new System.Drawing.Point(3, 170);
            this.vor_ruc_t.Name = "vor_ruc_t";
            this.vor_ruc_t.Size = new System.Drawing.Size(232, 13);
            this.vor_ruc_t.TabIndex = 0;
            this.vor_ruc_t.Text = "Road User Charges ($/1000K)";
            this.vor_ruc_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_ruc
            // 
            this.vor_ruc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorRuc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_ruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_ruc.Location = new System.Drawing.Point(241, 170);
            this.vor_ruc.Name = "vor_ruc";
            this.vor_ruc.Size = new System.Drawing.Size(77, 20);
            this.vor_ruc.TabIndex = 90;
            this.vor_ruc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_ruc.DataBindings[0].DataSourceNullValue = null;
            this.vor_ruc.DataBindings[0].NullValue = "";
            this.vor_ruc.Validated += new System.EventHandler(Value_Validated);
            // 
            // vor_sundries_k_t
            // 
            this.vor_sundries_k_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_sundries_k_t.Location = new System.Drawing.Point(3, 191);
            this.vor_sundries_k_t.Name = "vor_sundries_k_t";
            this.vor_sundries_k_t.Size = new System.Drawing.Size(232, 13);
            this.vor_sundries_k_t.TabIndex = 0;
            this.vor_sundries_k_t.Text = "Sundries ($/1000k)";
            this.vor_sundries_k_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_sundries_k
            // 
            this.vor_sundries_k.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorSundriesK", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_sundries_k.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_sundries_k.Location = new System.Drawing.Point(241, 191);
            this.vor_sundries_k.Name = "vor_sundries_k";
            this.vor_sundries_k.Size = new System.Drawing.Size(77, 20);
            this.vor_sundries_k.TabIndex = 100;
            this.vor_sundries_k.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_sundries_k.DataBindings[0].DataSourceNullValue = null;
            this.vor_sundries_k.DataBindings[0].NullValue = "";
            this.vor_sundries_k.Validated += new System.EventHandler(Value_Validated);
            // 
            // vor_vehicle_insurance_base_premium_t
            // 
            this.vor_vehicle_insurance_base_premium_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_vehicle_insurance_base_premium_t.Location = new System.Drawing.Point(3, 212);
            this.vor_vehicle_insurance_base_premium_t.Name = "vor_vehicle_insurance_base_premium_t";
            this.vor_vehicle_insurance_base_premium_t.Size = new System.Drawing.Size(232, 13);
            this.vor_vehicle_insurance_base_premium_t.TabIndex = 0;
            this.vor_vehicle_insurance_base_premium_t.Text = "Vehicle Insurance ($ pa)";
            this.vor_vehicle_insurance_base_premium_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_vehicle_insurance_premium
            // 
            this.vor_vehicle_insurance_premium.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorVehicleInsurancePremium", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_vehicle_insurance_premium.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_vehicle_insurance_premium.Location = new System.Drawing.Point(241, 212);
            this.vor_vehicle_insurance_premium.Name = "vor_vehicle_insurance_premium";
            this.vor_vehicle_insurance_premium.Size = new System.Drawing.Size(77, 20);
            this.vor_vehicle_insurance_premium.TabIndex = 110;
            this.vor_vehicle_insurance_premium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_vehicle_insurance_premium.DataBindings[0].DataSourceNullValue = null;
            this.vor_vehicle_insurance_premium.DataBindings[0].NullValue = "";
            this.vor_vehicle_insurance_premium.Validated += new System.EventHandler(Value_Validated);
            // 
            // vor_fuel_rate_t
            // 
            this.vor_fuel_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_fuel_rate_t.Location = new System.Drawing.Point(3, 233);
            this.vor_fuel_rate_t.Name = "vor_fuel_rate_t";
            this.vor_fuel_rate_t.Size = new System.Drawing.Size(232, 13);
            this.vor_fuel_rate_t.TabIndex = 0;
            this.vor_fuel_rate_t.Text = "Fuel Rate (cents/litre)";
            this.vor_fuel_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_fuel_rate
            // 
            this.vor_fuel_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorFuelRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_fuel_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_fuel_rate.Location = new System.Drawing.Point(241, 233);
            this.vor_fuel_rate.Name = "vor_fuel_rate";
            this.vor_fuel_rate.Size = new System.Drawing.Size(77, 20);
            this.vor_fuel_rate.TabIndex = 120;
            this.vor_fuel_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_fuel_rate.DataBindings[0].DataSourceNullValue = null;
            this.vor_fuel_rate.DataBindings[0].NullValue = "";
            this.vor_fuel_rate.Validated += new System.EventHandler(Value_Validated);
            // 
            // vor_consumption_rate_t
            // 
            this.vor_consumption_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_consumption_rate_t.Location = new System.Drawing.Point(3, 254);
            this.vor_consumption_rate_t.Name = "vor_consumption_rate_t";
            this.vor_consumption_rate_t.Size = new System.Drawing.Size(232, 13);
            this.vor_consumption_rate_t.TabIndex = 0;
            this.vor_consumption_rate_t.Text = "Consumption Rate (litres/100k)";
            this.vor_consumption_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_consumption_rate
            // 
            this.vor_consumption_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorConsumptionRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_consumption_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_consumption_rate.Location = new System.Drawing.Point(241, 254);
            this.vor_consumption_rate.Name = "vor_consumption_rate";
            this.vor_consumption_rate.Size = new System.Drawing.Size(77, 20);
            this.vor_consumption_rate.TabIndex = 130;
            this.vor_consumption_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_consumption_rate.DataBindings[0].DataSourceNullValue = null;
            this.vor_consumption_rate.DataBindings[0].NullValue = "";
            this.vor_consumption_rate.Validated += new System.EventHandler(Value_Validated);
            // 
            // t_2
            // 
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.Location = new System.Drawing.Point(3, 275);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(232, 13);
            this.t_2.TabIndex = 0;
            this.t_2.Text = "Livery";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vor_livery
            // 
            this.vor_livery.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VorLivery", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vor_livery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vor_livery.Location = new System.Drawing.Point(240, 275);
            this.vor_livery.Name = "vor_livery";
            this.vor_livery.Size = new System.Drawing.Size(78, 20);
            this.vor_livery.TabIndex = 140;
            this.vor_livery.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vor_livery.DataBindings[0].DataSourceNullValue = null;
            this.vor_livery.DataBindings[0].NullValue = "";
            this.vor_livery.Validated += new System.EventHandler(Value_Validated);
            // 
            // DVehicleOverrideRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.contract_seq_number);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.vor_effective_date);
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
            this.Controls.Add(this.vor_ruc_t);
            this.Controls.Add(this.vor_ruc);
            this.Controls.Add(this.vor_sundries_k_t);
            this.Controls.Add(this.vor_sundries_k);
            this.Controls.Add(this.vor_vehicle_insurance_base_premium_t);
            this.Controls.Add(this.vor_vehicle_insurance_premium);
            this.Controls.Add(this.vor_fuel_rate_t);
            this.Controls.Add(this.vor_fuel_rate);
            this.Controls.Add(this.vor_consumption_rate_t);
            this.Controls.Add(this.vor_consumption_rate);
            this.Controls.Add(this.t_2);
            this.Controls.Add(this.vor_livery);
            this.Name = "DVehicleOverrideRates";
            this.Size = new System.Drawing.Size(650, 306);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            ActiveEvent();
        }

        void Value_Validated(object sender, System.EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
            }
            else
            {
                ((TextBox)sender).Text = System.Math.Round(System.Convert.ToDecimal(((TextBox)sender).Text), 2).ToString("0.00");
            }
        }

        private void ActiveEvent()
        {
            foreach (Control var in this.Controls)
            {
                var.GotFocus += new System.EventHandler(var_GotFocus);
            }
        }

        void var_GotFocus(object sender, System.EventArgs e)
        {
            this.OnGotFocus(e);
        }
        #endregion

        private System.Windows.Forms.TextBox contract_no;
        private System.Windows.Forms.TextBox contract_seq_number;
        private System.Windows.Forms.Label t_1;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox vor_effective_date;
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
        private System.Windows.Forms.Label vor_ruc_t;
        private System.Windows.Forms.TextBox vor_ruc;
        private System.Windows.Forms.Label vor_sundries_k_t;
        private System.Windows.Forms.TextBox vor_sundries_k;
        private System.Windows.Forms.Label vor_vehicle_insurance_base_premium_t;
        private System.Windows.Forms.TextBox vor_vehicle_insurance_premium;
        private System.Windows.Forms.Label vor_fuel_rate_t;
        private System.Windows.Forms.TextBox vor_fuel_rate;
        private System.Windows.Forms.Label vor_consumption_rate_t;
        private System.Windows.Forms.TextBox vor_consumption_rate;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.TextBox vor_livery;
    }
}
