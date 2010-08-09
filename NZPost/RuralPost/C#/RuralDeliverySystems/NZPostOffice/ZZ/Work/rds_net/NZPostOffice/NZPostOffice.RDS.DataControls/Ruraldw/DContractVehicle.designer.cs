using NZPostOffice.Shared.VisualComponents;
using System.Windows.Forms;
using System;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractVehicle
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
            this.components = new System.ComponentModel.Container();
            this.st_active = new System.Windows.Forms.Label();
            this.st_sysadmin = new System.Windows.Forms.Label();
            this.st_title = new System.Windows.Forms.Label();
            this.contract_vehical_vehicle_number = new System.Windows.Forms.TextBox();
            this.v_vehicle_registration_number = new System.Windows.Forms.TextBox();
            this.v_vehicle_registration_number_t = new System.Windows.Forms.Label();
            this.vt_key = new Metex.Windows.DataEntityCombo();
            this.t_8 = new System.Windows.Forms.Label();
            this.t_1 = new System.Windows.Forms.Label();
            this.vs_key = new Metex.Windows.DataEntityCombo();
            this.t_2 = new System.Windows.Forms.Label();
            this.v_vehicle_make_t = new System.Windows.Forms.Label();
            this.v_vehicle_make = new System.Windows.Forms.TextBox();
            this.v_vehicle_model_t = new System.Windows.Forms.Label();
            this.v_vehicle_model = new System.Windows.Forms.TextBox();
            this.t_5 = new System.Windows.Forms.Label();
            this.v_vehicle_month_t = new System.Windows.Forms.Label();
            this.v_vehicle_year = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.v_vehicle_month = new Metex.Windows.DataEntityCombo();
            this.t_4 = new System.Windows.Forms.Label();
            this.v_vehicle_cc_rating = new System.Windows.Forms.MaskedTextBox();
            this.t_7 = new System.Windows.Forms.Label();
            this.ft_key = new Metex.Windows.DataEntityCombo();
            this.t_3 = new System.Windows.Forms.Label();
            this.t_10 = new System.Windows.Forms.Label();
            this.v_purchased_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.contract_vehical_cv_vehical_status = new Metex.Windows.DataEntityCombo();
            this.t_6 = new System.Windows.Forms.Label();
            this.contract_vehical_start_kms_t = new System.Windows.Forms.Label();
            this.contract_vehical_vehicle_allowance_paid_ = new System.Windows.Forms.TextBox();
            this.t_9 = new System.Windows.Forms.Label();
            this.v_road_user_charges_indicator = new System.Windows.Forms.CheckBox();
            this.v_leased = new System.Windows.Forms.CheckBox();
            this.v_remaining_economic_life = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.t_11 = new System.Windows.Forms.Label();
            this.signage_compliant = new System.Windows.Forms.CheckBox();
            this.t_12 = new System.Windows.Forms.Label();
            this.t_13 = new System.Windows.Forms.Label();
            this.v_vehicle_speedo_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.v_vehicle_speedo_kms = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.contract_vehical_start_kms = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.t_salvage = new System.Windows.Forms.Label();
            this.v_purchase_value = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.v_salvage_value = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.Safety_t = new System.Windows.Forms.Label();
            this.Safety1 = new System.Windows.Forms.Button();
            this.Safety2 = new System.Windows.Forms.Button();
            this.Safety3 = new System.Windows.Forms.Button();
            this.Safety4 = new System.Windows.Forms.Button();
            this.Safety5 = new System.Windows.Forms.Button();
            this.Star_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.Emissions_t = new System.Windows.Forms.Label();
            this.Emissions = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.Consumption_t = new System.Windows.Forms.Label();
            this.Consumption = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.SafetyValue_t = new System.Windows.Forms.Label();
            this.SafetyValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle);
            // 
            // st_active
            // 
            this.st_active.Location = new System.Drawing.Point(0, 0);
            this.st_active.Name = "st_active";
            this.st_active.Size = new System.Drawing.Size(100, 23);
            this.st_active.TabIndex = 0;
            // 
            // st_sysadmin
            // 
            this.st_sysadmin.Location = new System.Drawing.Point(0, 0);
            this.st_sysadmin.Name = "st_sysadmin";
            this.st_sysadmin.Size = new System.Drawing.Size(100, 23);
            this.st_sysadmin.TabIndex = 0;
            // 
            // st_title
            // 
            this.st_title.Location = new System.Drawing.Point(0, 0);
            this.st_title.Name = "st_title";
            this.st_title.Size = new System.Drawing.Size(100, 23);
            this.st_title.TabIndex = 0;
            // 
            // contract_vehical_vehicle_number
            // 
            this.contract_vehical_vehicle_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VehicleNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_vehical_vehicle_number.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_vehical_vehicle_number.Location = new System.Drawing.Point(218, 23);
            this.contract_vehical_vehicle_number.Name = "contract_vehical_vehicle_number";
            this.contract_vehical_vehicle_number.Size = new System.Drawing.Size(42, 20);
            this.contract_vehical_vehicle_number.TabIndex = 0;
            this.contract_vehical_vehicle_number.Visible = false;
            // 
            // v_vehicle_registration_number
            // 
            this.v_vehicle_registration_number.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.v_vehicle_registration_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VVehicleRegistrationNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_vehicle_registration_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_vehicle_registration_number.Location = new System.Drawing.Point(84, 25);
            this.v_vehicle_registration_number.MaxLength = 8;
            this.v_vehicle_registration_number.Name = "v_vehicle_registration_number";
            this.v_vehicle_registration_number.Size = new System.Drawing.Size(84, 20);
            this.v_vehicle_registration_number.TabIndex = 1;
            // 
            // v_vehicle_registration_number_t
            // 
            this.v_vehicle_registration_number_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_vehicle_registration_number_t.Location = new System.Drawing.Point(0, 25);
            this.v_vehicle_registration_number_t.Name = "v_vehicle_registration_number_t";
            this.v_vehicle_registration_number_t.Size = new System.Drawing.Size(77, 13);
            this.v_vehicle_registration_number_t.TabIndex = 0;
            this.v_vehicle_registration_number_t.Text = "Reg No";
            this.v_vehicle_registration_number_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vt_key
            // 
            this.vt_key.AutoRetrieve = true;
            this.vt_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vt_key.DisplayMember = "VtDescription";
            this.vt_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vt_key.Location = new System.Drawing.Point(84, 49);
            this.vt_key.Name = "vt_key";
            this.vt_key.Size = new System.Drawing.Size(176, 21);
            this.vt_key.TabIndex = 2;
            this.vt_key.Value = null;
            this.vt_key.ValueMember = "VtKey";
            this.vt_key.TextChanged += new System.EventHandler(this.vehicle_vt_key_TextChanged);
            // 
            // t_8
            // 
            this.t_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_8.Location = new System.Drawing.Point(301, 47);
            this.t_8.Name = "t_8";
            this.t_8.Size = new System.Drawing.Size(114, 13);
            this.t_8.TabIndex = 0;
            this.t_8.Text = "Purchase Date";
            this.t_8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.Location = new System.Drawing.Point(0, 49);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(77, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "Vehicle Type";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vs_key
            // 
            this.vs_key.AutoRetrieve = true;
            this.vs_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VsKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vs_key.DisplayMember = "VsDescription";
            this.vs_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vs_key.Location = new System.Drawing.Point(84, 73);
            this.vs_key.Name = "vs_key";
            this.vs_key.Size = new System.Drawing.Size(176, 21);
            this.vs_key.TabIndex = 3;
            this.vs_key.Value = null;
            this.vs_key.ValueMember = "VsKey";
            this.vs_key.TextChanged += new System.EventHandler(this.vehicle_vt_key_TextChanged);
            // 
            // t_2
            // 
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.Location = new System.Drawing.Point(0, 73);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(77, 13);
            this.t_2.TabIndex = 0;
            this.t_2.Text = "Vehicle Class";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // v_vehicle_make_t
            // 
            this.v_vehicle_make_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_vehicle_make_t.Location = new System.Drawing.Point(0, 97);
            this.v_vehicle_make_t.Name = "v_vehicle_make_t";
            this.v_vehicle_make_t.Size = new System.Drawing.Size(77, 13);
            this.v_vehicle_make_t.TabIndex = 0;
            this.v_vehicle_make_t.Text = "Make";
            this.v_vehicle_make_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // v_vehicle_make
            // 
            this.v_vehicle_make.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VVehicleMake", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_vehicle_make.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_vehicle_make.Location = new System.Drawing.Point(84, 97);
            this.v_vehicle_make.MaxLength = 20;
            this.v_vehicle_make.Name = "v_vehicle_make";
            this.v_vehicle_make.Size = new System.Drawing.Size(176, 20);
            this.v_vehicle_make.TabIndex = 4;
            // 
            // v_vehicle_model_t
            // 
            this.v_vehicle_model_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_vehicle_model_t.Location = new System.Drawing.Point(0, 121);
            this.v_vehicle_model_t.Name = "v_vehicle_model_t";
            this.v_vehicle_model_t.Size = new System.Drawing.Size(77, 13);
            this.v_vehicle_model_t.TabIndex = 0;
            this.v_vehicle_model_t.Text = "Model";
            this.v_vehicle_model_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // v_vehicle_model
            // 
            this.v_vehicle_model.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VVehicleModel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_vehicle_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_vehicle_model.Location = new System.Drawing.Point(84, 121);
            this.v_vehicle_model.MaxLength = 20;
            this.v_vehicle_model.Name = "v_vehicle_model";
            this.v_vehicle_model.Size = new System.Drawing.Size(176, 20);
            this.v_vehicle_model.TabIndex = 5;
            // 
            // t_5
            // 
            this.t_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_5.Location = new System.Drawing.Point(0, 146);
            this.t_5.Name = "t_5";
            this.t_5.Size = new System.Drawing.Size(77, 13);
            this.t_5.TabIndex = 0;
            this.t_5.Text = "Year";
            this.t_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // v_vehicle_month_t
            // 
            this.v_vehicle_month_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_vehicle_month_t.Location = new System.Drawing.Point(122, 148);
            this.v_vehicle_month_t.Name = "v_vehicle_month_t";
            this.v_vehicle_month_t.Size = new System.Drawing.Size(37, 13);
            this.v_vehicle_month_t.TabIndex = 0;
            this.v_vehicle_month_t.Text = "Month";
            this.v_vehicle_month_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // v_vehicle_year
            // 
            this.v_vehicle_year.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VVehicleYear", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_vehicle_year.EditMask = "####";
            this.v_vehicle_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_vehicle_year.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.v_vehicle_year.Location = new System.Drawing.Point(84, 145);
            this.v_vehicle_year.Name = "v_vehicle_year";
            this.v_vehicle_year.PromptChar = ' ';
            this.v_vehicle_year.Size = new System.Drawing.Size(35, 20);
            this.v_vehicle_year.TabIndex = 6;
            this.v_vehicle_year.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.v_vehicle_year.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.v_vehicle_year.ValidatingType = typeof(System.DateTime);
            this.v_vehicle_year.Value = "";
            // 
            // v_vehicle_month
            // 
            this.v_vehicle_month.AutoRetrieve = false;
            this.v_vehicle_month.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VVehicleMonth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_vehicle_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_vehicle_month.Location = new System.Drawing.Point(160, 145);
            this.v_vehicle_month.Name = "v_vehicle_month";
            this.v_vehicle_month.Size = new System.Drawing.Size(102, 21);
            this.v_vehicle_month.TabIndex = 7;
            this.v_vehicle_month.Value = null;
            this.v_vehicle_month.TextChanged += new System.EventHandler(this.vehicle_vt_key_TextChanged);
            // 
            // t_4
            // 
            this.t_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_4.Location = new System.Drawing.Point(0, 172);
            this.t_4.Name = "t_4";
            this.t_4.Size = new System.Drawing.Size(77, 13);
            this.t_4.TabIndex = 0;
            this.t_4.Text = "CC Rating";
            this.t_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // v_vehicle_cc_rating
            // 
            this.v_vehicle_cc_rating.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VVehicleCcRating", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_vehicle_cc_rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_vehicle_cc_rating.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.v_vehicle_cc_rating.Location = new System.Drawing.Point(84, 169);
            this.v_vehicle_cc_rating.Mask = "####";
            this.v_vehicle_cc_rating.Name = "v_vehicle_cc_rating";
            this.v_vehicle_cc_rating.PromptChar = ' ';
            this.v_vehicle_cc_rating.Size = new System.Drawing.Size(35, 20);
            this.v_vehicle_cc_rating.TabIndex = 8;
            this.v_vehicle_cc_rating.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.v_vehicle_cc_rating.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.v_vehicle_cc_rating.ValidatingType = typeof(System.DateTime);
            // 
            // t_7
            // 
            this.t_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_7.Location = new System.Drawing.Point(301, 23);
            this.t_7.Name = "t_7";
            this.t_7.Size = new System.Drawing.Size(114, 13);
            this.t_7.TabIndex = 0;
            this.t_7.Text = "Purchase Value";
            this.t_7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ft_key
            // 
            this.ft_key.AutoRetrieve = true;
            this.ft_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "FtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ft_key.DisplayMember = "FtDescription";
            this.ft_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ft_key.Location = new System.Drawing.Point(84, 193);
            this.ft_key.Name = "ft_key";
            this.ft_key.Size = new System.Drawing.Size(148, 21);
            this.ft_key.TabIndex = 10;
            this.ft_key.Value = null;
            this.ft_key.ValueMember = "FtKey";
            this.ft_key.TextChanged += new System.EventHandler(this.vehicle_vt_key_TextChanged);
            // 
            // t_3
            // 
            this.t_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_3.Location = new System.Drawing.Point(0, 197);
            this.t_3.Name = "t_3";
            this.t_3.Size = new System.Drawing.Size(77, 13);
            this.t_3.TabIndex = 0;
            this.t_3.Text = "Fuel Type";
            this.t_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_10
            // 
            this.t_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_10.Location = new System.Drawing.Point(0, 218);
            this.t_10.Name = "t_10";
            this.t_10.Size = new System.Drawing.Size(77, 13);
            this.t_10.TabIndex = 0;
            this.t_10.Text = "Transmission";
            this.t_10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // v_purchased_date
            // 
            this.v_purchased_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VPurchasedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_purchased_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_purchased_date.Location = new System.Drawing.Point(422, 47);
            this.v_purchased_date.Mask = "00/00/0000";
            this.v_purchased_date.Name = "v_purchased_date";
            this.v_purchased_date.Size = new System.Drawing.Size(80, 20);
            this.v_purchased_date.TabIndex = 16;
            this.v_purchased_date.Text = "00000000";
            this.v_purchased_date.Value = null;
            // 
            // contract_vehical_cv_vehical_status
            // 
            this.contract_vehical_cv_vehical_status.AutoRetrieve = false;
            this.contract_vehical_cv_vehical_status.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CvVehicalStatus", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_vehical_cv_vehical_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_vehical_cv_vehical_status.Location = new System.Drawing.Point(249, 274);
            this.contract_vehical_cv_vehical_status.Name = "contract_vehical_cv_vehical_status";
            this.contract_vehical_cv_vehical_status.Size = new System.Drawing.Size(92, 21);
            this.contract_vehical_cv_vehical_status.TabIndex = 0;
            this.contract_vehical_cv_vehical_status.Value = null;
            this.contract_vehical_cv_vehical_status.Visible = false;
            // 
            // t_6
            // 
            this.t_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_6.Location = new System.Drawing.Point(196, 274);
            this.t_6.Name = "t_6";
            this.t_6.Size = new System.Drawing.Size(44, 21);
            this.t_6.TabIndex = 0;
            this.t_6.Text = "Status";
            this.t_6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.t_6.Visible = false;
            // 
            // contract_vehical_start_kms_t
            // 
            this.contract_vehical_start_kms_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_vehical_start_kms_t.Location = new System.Drawing.Point(301, 97);
            this.contract_vehical_start_kms_t.Name = "contract_vehical_start_kms_t";
            this.contract_vehical_start_kms_t.Size = new System.Drawing.Size(114, 13);
            this.contract_vehical_start_kms_t.TabIndex = 0;
            this.contract_vehical_start_kms_t.Text = "Start Kms";
            this.contract_vehical_start_kms_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_vehical_vehicle_allowance_paid_
            // 
            this.contract_vehical_vehicle_allowance_paid_.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VehicleAllowancePaid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_vehical_vehicle_allowance_paid_.Enabled = false;
            this.contract_vehical_vehicle_allowance_paid_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_vehical_vehicle_allowance_paid_.Location = new System.Drawing.Point(422, 121);
            this.contract_vehical_vehicle_allowance_paid_.Name = "contract_vehical_vehicle_allowance_paid_";
            this.contract_vehical_vehicle_allowance_paid_.Size = new System.Drawing.Size(93, 20);
            this.contract_vehical_vehicle_allowance_paid_.TabIndex = 0;
            // 
            // t_9
            // 
            this.t_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_9.Location = new System.Drawing.Point(301, 121);
            this.t_9.Name = "t_9";
            this.t_9.Size = new System.Drawing.Size(114, 13);
            this.t_9.TabIndex = 0;
            this.t_9.Text = "Allowances Paid";
            this.t_9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // v_road_user_charges_indicator
            // 
            this.v_road_user_charges_indicator.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.v_road_user_charges_indicator.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "VRoadUserChargesIndicator", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_road_user_charges_indicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_road_user_charges_indicator.Location = new System.Drawing.Point(458, 145);
            this.v_road_user_charges_indicator.Name = "v_road_user_charges_indicator";
            this.v_road_user_charges_indicator.Size = new System.Drawing.Size(56, 18);
            this.v_road_user_charges_indicator.TabIndex = 20;
            this.v_road_user_charges_indicator.Text = "RUC";
            this.v_road_user_charges_indicator.ThreeState = true;
            // 
            // v_leased
            // 
            this.v_leased.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.v_leased.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "VLeased", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_leased.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_leased.Location = new System.Drawing.Point(334, 144);
            this.v_leased.Name = "v_leased";
            this.v_leased.Size = new System.Drawing.Size(102, 18);
            this.v_leased.TabIndex = 19;
            this.v_leased.Text = "Leased Vehicle";
            this.v_leased.ThreeState = true;
            // 
            // v_remaining_economic_life
            // 
            this.v_remaining_economic_life.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VRemainingEconomicLife", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_remaining_economic_life.EditMask = "###,##0";
            this.v_remaining_economic_life.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_remaining_economic_life.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.v_remaining_economic_life.Location = new System.Drawing.Point(422, 169);
            this.v_remaining_economic_life.Name = "v_remaining_economic_life";
            this.v_remaining_economic_life.PromptChar = ' ';
            this.v_remaining_economic_life.Size = new System.Drawing.Size(66, 20);
            this.v_remaining_economic_life.TabIndex = 21;
            this.v_remaining_economic_life.Text = "0";
            this.v_remaining_economic_life.Value = "0";
            // 
            // t_11
            // 
            this.t_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_11.Location = new System.Drawing.Point(247, 172);
            this.t_11.Name = "t_11";
            this.t_11.Size = new System.Drawing.Size(168, 13);
            this.t_11.TabIndex = 0;
            this.t_11.Text = "Remaining Economic Life (km)";
            this.t_11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // signage_compliant
            // 
            this.signage_compliant.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.signage_compliant.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "SignageCompliant", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.signage_compliant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.signage_compliant.Location = new System.Drawing.Point(318, 193);
            this.signage_compliant.Name = "signage_compliant";
            this.signage_compliant.Size = new System.Drawing.Size(118, 18);
            this.signage_compliant.TabIndex = 22;
            this.signage_compliant.Text = "Signage Compliant";
            this.signage_compliant.ThreeState = true;
            // 
            // t_12
            // 
            this.t_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_12.Location = new System.Drawing.Point(294, 217);
            this.t_12.Name = "t_12";
            this.t_12.Size = new System.Drawing.Size(121, 13);
            this.t_12.TabIndex = 0;
            this.t_12.Text = "Speedo Reading Date";
            this.t_12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_13
            // 
            this.t_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_13.Location = new System.Drawing.Point(294, 241);
            this.t_13.Name = "t_13";
            this.t_13.Size = new System.Drawing.Size(121, 13);
            this.t_13.TabIndex = 0;
            this.t_13.Text = "Speedo Reading Kms";
            this.t_13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // v_vehicle_speedo_date
            // 
            this.v_vehicle_speedo_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VVehicleSpeedoDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_vehicle_speedo_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_vehicle_speedo_date.Location = new System.Drawing.Point(423, 217);
            this.v_vehicle_speedo_date.Mask = "00/00/0000";
            this.v_vehicle_speedo_date.Name = "v_vehicle_speedo_date";
            this.v_vehicle_speedo_date.Size = new System.Drawing.Size(80, 20);
            this.v_vehicle_speedo_date.TabIndex = 23;
            this.v_vehicle_speedo_date.Text = "00000000";
            this.v_vehicle_speedo_date.Value = null;
            // 
            // v_vehicle_speedo_kms
            // 
            this.v_vehicle_speedo_kms.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VVehicleSpeedoKms", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_vehicle_speedo_kms.EditMask = "###,###";
            this.v_vehicle_speedo_kms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_vehicle_speedo_kms.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.v_vehicle_speedo_kms.Location = new System.Drawing.Point(422, 241);
            this.v_vehicle_speedo_kms.Name = "v_vehicle_speedo_kms";
            this.v_vehicle_speedo_kms.PromptChar = ' ';
            this.v_vehicle_speedo_kms.Size = new System.Drawing.Size(52, 20);
            this.v_vehicle_speedo_kms.TabIndex = 24;
            this.v_vehicle_speedo_kms.Value = "";
            // 
            // contract_vehical_start_kms
            // 
            this.contract_vehical_start_kms.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "StartKms", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_vehical_start_kms.EditMask = "#,###,##0";
            this.contract_vehical_start_kms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_vehical_start_kms.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.contract_vehical_start_kms.Location = new System.Drawing.Point(422, 97);
            this.contract_vehical_start_kms.Name = "contract_vehical_start_kms";
            this.contract_vehical_start_kms.PromptChar = ' ';
            this.contract_vehical_start_kms.Size = new System.Drawing.Size(52, 20);
            this.contract_vehical_start_kms.TabIndex = 18;
            this.contract_vehical_start_kms.Text = "0";
            this.contract_vehical_start_kms.Value = "0";
            // 
            // t_salvage
            // 
            this.t_salvage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_salvage.Location = new System.Drawing.Point(301, 72);
            this.t_salvage.Name = "t_salvage";
            this.t_salvage.Size = new System.Drawing.Size(114, 13);
            this.t_salvage.TabIndex = 0;
            this.t_salvage.Text = "Salvage Value";
            this.t_salvage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // v_purchase_value
            // 
            this.v_purchase_value.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VPurchaseValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_purchase_value.EditMask = "$###,##0";
            this.v_purchase_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_purchase_value.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.v_purchase_value.Location = new System.Drawing.Point(422, 23);
            this.v_purchase_value.Name = "v_purchase_value";
            this.v_purchase_value.PromptChar = ' ';
            this.v_purchase_value.Size = new System.Drawing.Size(52, 20);
            this.v_purchase_value.TabIndex = 15;
            this.v_purchase_value.Text = "$0";
            this.v_purchase_value.Value = "$0";
            // 
            // v_salvage_value
            // 
            this.v_salvage_value.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VSalvageValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.v_salvage_value.EditMask = "$###,##0";
            this.v_salvage_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.v_salvage_value.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.v_salvage_value.Location = new System.Drawing.Point(422, 72);
            this.v_salvage_value.Name = "v_salvage_value";
            this.v_salvage_value.PromptChar = ' ';
            this.v_salvage_value.Size = new System.Drawing.Size(52, 20);
            this.v_salvage_value.TabIndex = 17;
            this.v_salvage_value.Text = "$0";
            this.v_salvage_value.Value = "$0";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "VVehicleTransmission1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton1.Location = new System.Drawing.Point(85, 218);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(60, 17);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.Text = "Manual";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "VVehicleTransmission2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton2.Location = new System.Drawing.Point(158, 218);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(72, 17);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.Text = "Automatic";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Safety_t
            // 
            this.Safety_t.AutoSize = true;
            this.Safety_t.Location = new System.Drawing.Point(5, 241);
            this.Safety_t.Name = "Safety_t";
            this.Safety_t.Size = new System.Drawing.Size(71, 13);
            this.Safety_t.TabIndex = 0;
            this.Safety_t.Text = "Safety Rating";
            // 
            // Safety1
            // 
            this.Safety1.FlatAppearance.BorderSize = 0;
            this.Safety1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Safety1.Image = global::NZPostOffice.RDS.DataControls.Properties.Resources.star_empty;
            this.Safety1.Location = new System.Drawing.Point(87, 241);
            this.Safety1.Name = "Safety1";
            this.Safety1.Size = new System.Drawing.Size(15, 13);
            this.Safety1.TabIndex = 13;
            this.Safety1.UseVisualStyleBackColor = true;
            // 
            // Safety2
            // 
            this.Safety2.FlatAppearance.BorderSize = 0;
            this.Safety2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Safety2.Image = global::NZPostOffice.RDS.DataControls.Properties.Resources.star_empty;
            this.Safety2.Location = new System.Drawing.Point(108, 241);
            this.Safety2.Name = "Safety2";
            this.Safety2.Size = new System.Drawing.Size(15, 13);
            this.Safety2.TabIndex = 0;
            this.Safety2.UseVisualStyleBackColor = true;
            // 
            // Safety3
            // 
            this.Safety3.FlatAppearance.BorderSize = 0;
            this.Safety3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Safety3.Image = global::NZPostOffice.RDS.DataControls.Properties.Resources.star_empty;
            this.Safety3.Location = new System.Drawing.Point(129, 241);
            this.Safety3.Name = "Safety3";
            this.Safety3.Size = new System.Drawing.Size(15, 13);
            this.Safety3.TabIndex = 0;
            this.Safety3.UseVisualStyleBackColor = true;
            // 
            // Safety4
            // 
            this.Safety4.FlatAppearance.BorderSize = 0;
            this.Safety4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Safety4.Image = global::NZPostOffice.RDS.DataControls.Properties.Resources.star_empty;
            this.Safety4.Location = new System.Drawing.Point(150, 241);
            this.Safety4.Name = "Safety4";
            this.Safety4.Size = new System.Drawing.Size(15, 13);
            this.Safety4.TabIndex = 0;
            this.Safety4.UseVisualStyleBackColor = true;
            // 
            // Safety5
            // 
            this.Safety5.FlatAppearance.BorderSize = 0;
            this.Safety5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Safety5.Image = global::NZPostOffice.RDS.DataControls.Properties.Resources.star_empty;
            this.Safety5.Location = new System.Drawing.Point(172, 241);
            this.Safety5.Name = "Safety5";
            this.Safety5.Size = new System.Drawing.Size(15, 13);
            this.Safety5.TabIndex = 0;
            this.Safety5.UseVisualStyleBackColor = true;
            // 
            // Star_tooltip
            // 
            this.Star_tooltip.Popup += new System.Windows.Forms.PopupEventHandler(this.Star1_tooltip_Popup);
            // 
            // Emissions_t
            // 
            this.Emissions_t.AutoSize = true;
            this.Emissions_t.Location = new System.Drawing.Point(122, 172);
            this.Emissions_t.Name = "Emissions_t";
            this.Emissions_t.Size = new System.Drawing.Size(87, 13);
            this.Emissions_t.TabIndex = 0;
            this.Emissions_t.Text = "Emissions (g/km)";
            // 
            // Emissions
            // 
            this.Emissions.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VVehicleEmissions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Emissions.EditMask = "###,###";
            this.Emissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Emissions.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.Emissions.Location = new System.Drawing.Point(215, 169);
            this.Emissions.Name = "Emissions";
            this.Emissions.PromptChar = ' ';
            this.Emissions.Size = new System.Drawing.Size(45, 20);
            this.Emissions.TabIndex = 9;
            this.Emissions.Value = "";
            // 
            // Consumption_t
            // 
            this.Consumption_t.AutoSize = true;
            this.Consumption_t.Location = new System.Drawing.Point(5, 263);
            this.Consumption_t.Name = "Consumption_t";
            this.Consumption_t.Size = new System.Drawing.Size(115, 13);
            this.Consumption_t.TabIndex = 0;
            this.Consumption_t.Text = "Mfg Consumption Rate";
            // 
            // Consumption
            // 
            this.Consumption.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VVehicleConsumptionRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Consumption.EditMask = "";
            this.Consumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Consumption.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.Consumption.Location = new System.Drawing.Point(125, 260);
            this.Consumption.Name = "Consumption";
            this.Consumption.PromptChar = ' ';
            this.Consumption.Size = new System.Drawing.Size(62, 20);
            this.Consumption.TabIndex = 14;
            this.Consumption.Value = "";
            this.Consumption.ReadOnly = true;
            // 
            // SafetyValue_t
            // 
            this.SafetyValue_t.AutoSize = true;
            this.SafetyValue_t.Location = new System.Drawing.Point(348, 277);
            this.SafetyValue_t.Name = "SafetyValue_t";
            this.SafetyValue_t.Size = new System.Drawing.Size(67, 13);
            this.SafetyValue_t.TabIndex = 0;
            this.SafetyValue_t.Text = "Safety Value";
            this.SafetyValue_t.Visible = false;
            // 
            // SafetyValue
            // 
            this.SafetyValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VVehicleSafety", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SafetyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.SafetyValue.Location = new System.Drawing.Point(422, 273);
            this.SafetyValue.Name = "SafetyValue";
            this.SafetyValue.Size = new System.Drawing.Size(52, 20);
            this.SafetyValue.TabIndex = 0;
            this.SafetyValue.Visible = false;
            // 
            // DContractVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SafetyValue);
            this.Controls.Add(this.SafetyValue_t);
            this.Controls.Add(this.Consumption);
            this.Controls.Add(this.Consumption_t);
            this.Controls.Add(this.Emissions);
            this.Controls.Add(this.Emissions_t);
            this.Controls.Add(this.Safety5);
            this.Controls.Add(this.Safety4);
            this.Controls.Add(this.Safety3);
            this.Controls.Add(this.Safety2);
            this.Controls.Add(this.Safety1);
            this.Controls.Add(this.Safety_t);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.st_active);
            this.Controls.Add(this.st_sysadmin);
            this.Controls.Add(this.st_title);
            this.Controls.Add(this.contract_vehical_vehicle_number);
            this.Controls.Add(this.v_vehicle_registration_number);
            this.Controls.Add(this.v_vehicle_registration_number_t);
            this.Controls.Add(this.vt_key);
            this.Controls.Add(this.t_8);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.vs_key);
            this.Controls.Add(this.t_2);
            this.Controls.Add(this.v_vehicle_make_t);
            this.Controls.Add(this.v_vehicle_make);
            this.Controls.Add(this.v_vehicle_model_t);
            this.Controls.Add(this.v_vehicle_model);
            this.Controls.Add(this.t_5);
            this.Controls.Add(this.v_vehicle_month_t);
            this.Controls.Add(this.v_vehicle_year);
            this.Controls.Add(this.v_vehicle_month);
            this.Controls.Add(this.t_4);
            this.Controls.Add(this.v_vehicle_cc_rating);
            this.Controls.Add(this.t_7);
            this.Controls.Add(this.ft_key);
            this.Controls.Add(this.t_3);
            this.Controls.Add(this.t_10);
            this.Controls.Add(this.v_purchased_date);
            this.Controls.Add(this.contract_vehical_cv_vehical_status);
            this.Controls.Add(this.t_6);
            this.Controls.Add(this.contract_vehical_start_kms_t);
            this.Controls.Add(this.contract_vehical_vehicle_allowance_paid_);
            this.Controls.Add(this.t_9);
            this.Controls.Add(this.v_road_user_charges_indicator);
            this.Controls.Add(this.v_leased);
            this.Controls.Add(this.v_remaining_economic_life);
            this.Controls.Add(this.t_11);
            this.Controls.Add(this.signage_compliant);
            this.Controls.Add(this.t_12);
            this.Controls.Add(this.t_13);
            this.Controls.Add(this.v_vehicle_speedo_date);
            this.Controls.Add(this.v_vehicle_speedo_kms);
            this.Controls.Add(this.contract_vehical_start_kms);
            this.Controls.Add(this.t_salvage);
            this.Controls.Add(this.v_purchase_value);
            this.Controls.Add(this.v_salvage_value);
            this.Name = "DContractVehicle";
            this.Size = new System.Drawing.Size(534, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void vehicle_vt_key_TextChanged(object sender, System.EventArgs e)
        {
            if (((Metex.Windows.DataEntityCombo)sender).Focused)
            {
                ((Metex.Windows.DataEntityCombo)sender).DroppedDown = true;
                SendKeys.Send("{ENTER}");
            }
        }

        #endregion
        private System.Windows.Forms.Label st_sysadmin;
        private System.Windows.Forms.Label st_active;
        private System.Windows.Forms.Label st_title;
        private System.Windows.Forms.TextBox contract_vehical_vehicle_number;
        private System.Windows.Forms.TextBox v_vehicle_registration_number;
        private System.Windows.Forms.Label v_vehicle_registration_number_t;
        private Metex.Windows.DataEntityCombo vt_key;
        private System.Windows.Forms.Label t_8;
        private System.Windows.Forms.Label t_1;
        private Metex.Windows.DataEntityCombo vs_key;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label v_vehicle_make_t;
        private System.Windows.Forms.TextBox v_vehicle_make;
        private System.Windows.Forms.Label v_vehicle_model_t;
        private System.Windows.Forms.TextBox v_vehicle_model;
        private System.Windows.Forms.Label t_5;
        private System.Windows.Forms.Label v_vehicle_month_t;
        private NumericalMaskedTextBox v_vehicle_year;
        private Metex.Windows.DataEntityCombo v_vehicle_month;
        private System.Windows.Forms.Label t_4;
        private System.Windows.Forms.MaskedTextBox v_vehicle_cc_rating;
        private System.Windows.Forms.Label t_7;
        private Metex.Windows.DataEntityCombo ft_key;
        private System.Windows.Forms.Label t_3;
        private System.Windows.Forms.Label t_10;
        private DateTimeMaskedTextBox v_purchased_date;
        private Metex.Windows.DataEntityCombo contract_vehical_cv_vehical_status;
        private System.Windows.Forms.Label t_6;
        private System.Windows.Forms.Label contract_vehical_start_kms_t;
        private System.Windows.Forms.TextBox contract_vehical_vehicle_allowance_paid_;
        private System.Windows.Forms.Label t_9;
        private System.Windows.Forms.CheckBox v_road_user_charges_indicator;
        private System.Windows.Forms.CheckBox v_leased;
        private NumericalMaskedTextBox v_remaining_economic_life;
        private System.Windows.Forms.Label t_11;
        private System.Windows.Forms.CheckBox signage_compliant;
        private System.Windows.Forms.Label t_12;
        private System.Windows.Forms.Label t_13;
        private DateTimeMaskedTextBox v_vehicle_speedo_date;
        private NumericalMaskedTextBox v_vehicle_speedo_kms;
        private NumericalMaskedTextBox contract_vehical_start_kms;
        private System.Windows.Forms.Label t_salvage;
        private NumericalMaskedTextBox v_purchase_value;
        private NumericalMaskedTextBox v_salvage_value;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private Label Safety_t;
        private Button Safety1;
        private Button Safety2;
        private Button Safety3;
        private Button Safety4;
        private Button Safety5;
        private ToolTip Star_tooltip;
        private Label Emissions_t;
        private NumericalMaskedTextBox Emissions;
        private Label Consumption_t;
        private NumericalMaskedTextBox Consumption;
        private Label SafetyValue_t;
        private TextBox SafetyValue;
    }
}
