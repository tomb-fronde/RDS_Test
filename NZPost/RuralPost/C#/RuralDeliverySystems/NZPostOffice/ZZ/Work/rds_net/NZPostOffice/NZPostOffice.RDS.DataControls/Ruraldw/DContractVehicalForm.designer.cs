namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractVehicalForm
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
            this.Name = "DContractVehicalForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractVehicalForm);
            #region vehicle_v_vehicle_registration_number_t define
            this.vehicle_v_vehicle_registration_number_t = new System.Windows.Forms.Label();
            this.vehicle_v_vehicle_registration_number_t.Name = "vehicle_v_vehicle_registration_number_t";
            this.vehicle_v_vehicle_registration_number_t.Location = new System.Drawing.Point(29, 10);
            this.vehicle_v_vehicle_registration_number_t.Size = new System.Drawing.Size(45, 13);
            this.vehicle_v_vehicle_registration_number_t.TabIndex = 0;
            this.vehicle_v_vehicle_registration_number_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_vehicle_registration_number_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.vehicle_v_vehicle_registration_number_t.Text = "Reg No";
            #endregion
            this.Controls.Add(vehicle_v_vehicle_registration_number_t);
            #region n_50279347 define
            this.n_50279347 = new System.Windows.Forms.Label();
            this.n_50279347.Name = "n_50279347";
            this.n_50279347.Location = new System.Drawing.Point(3, 34);
            this.n_50279347.Size = new System.Drawing.Size(71, 13);
            this.n_50279347.TabIndex = 0;
            this.n_50279347.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_50279347.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_50279347.Text = "Vehicle Type";
            #endregion
            this.Controls.Add(n_50279347);
            #region vehicle_v_vehicle_make_t define
            this.vehicle_v_vehicle_make_t = new System.Windows.Forms.Label();
            this.vehicle_v_vehicle_make_t.Name = "vehicle_v_vehicle_make_t";
            this.vehicle_v_vehicle_make_t.Location = new System.Drawing.Point(38, 58);
            this.vehicle_v_vehicle_make_t.Size = new System.Drawing.Size(35, 13);
            this.vehicle_v_vehicle_make_t.TabIndex = 0;
            this.vehicle_v_vehicle_make_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_vehicle_make_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.vehicle_v_vehicle_make_t.Text = "Make";
            #endregion
            this.Controls.Add(vehicle_v_vehicle_make_t);
            #region vehicle_v_vehicle_model_t define
            this.vehicle_v_vehicle_model_t = new System.Windows.Forms.Label();
            this.vehicle_v_vehicle_model_t.Name = "vehicle_v_vehicle_model_t";
            this.vehicle_v_vehicle_model_t.Location = new System.Drawing.Point(35, 81);
            this.vehicle_v_vehicle_model_t.Size = new System.Drawing.Size(37, 13);
            this.vehicle_v_vehicle_model_t.TabIndex = 0;
            this.vehicle_v_vehicle_model_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_vehicle_model_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.vehicle_v_vehicle_model_t.Text = "Model";
            #endregion
            this.Controls.Add(vehicle_v_vehicle_model_t);
            #region n_49860945 define
            this.n_49860945 = new System.Windows.Forms.Label();
            this.n_49860945.Name = "n_49860945";
            this.n_49860945.Location = new System.Drawing.Point(16, 130);
            this.n_49860945.Size = new System.Drawing.Size(55, 13);
            this.n_49860945.TabIndex = 0;
            this.n_49860945.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_49860945.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_49860945.Text = "CC Rating";
            #endregion
            this.Controls.Add(n_49860945);
            #region n_46095324 define
            this.n_46095324 = new System.Windows.Forms.Label();
            this.n_46095324.Name = "n_46095324";
            this.n_46095324.Location = new System.Drawing.Point(17, 106);
            this.n_46095324.Size = new System.Drawing.Size(54, 13);
            this.n_46095324.TabIndex = 0;
            this.n_46095324.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_46095324.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.n_46095324.Text = "Fuel Type";
            #endregion
            this.Controls.Add(n_46095324);
            #region vehicle_v_vehicle_registration_number define
            this.vehicle_v_vehicle_registration_number = new System.Windows.Forms.TextBox();
            this.vehicle_v_vehicle_registration_number.Name = "vehicle_v_vehicle_registration_number";
            this.vehicle_v_vehicle_registration_number.Location = new System.Drawing.Point(78, 7);
            this.vehicle_v_vehicle_registration_number.Size = new System.Drawing.Size(48, 20);
            this.vehicle_v_vehicle_registration_number.TabIndex = 10;
            this.vehicle_v_vehicle_registration_number.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_vehicle_registration_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.vehicle_v_vehicle_registration_number.MaxLength = 8;
            this.vehicle_v_vehicle_registration_number.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.vehicle_v_vehicle_registration_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VehicleVVehicleRegistrationNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(vehicle_v_vehicle_registration_number);
            #region vehicle_v_vehicle_cc_rating define
            this.vehicle_v_vehicle_cc_rating = new System.Windows.Forms.MaskedTextBox();
            this.vehicle_v_vehicle_cc_rating.Name = "vehicle_v_vehicle_cc_rating";
            this.vehicle_v_vehicle_cc_rating.Location = new System.Drawing.Point(78, 127);
            this.vehicle_v_vehicle_cc_rating.Size = new System.Drawing.Size(30, 20);
            this.vehicle_v_vehicle_cc_rating.TabIndex = 60;
            this.vehicle_v_vehicle_cc_rating.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_vehicle_cc_rating.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.vehicle_v_vehicle_cc_rating.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VehicleVVehicleCcRating", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vehicle_v_vehicle_cc_rating.Mask = "####";
            #endregion
            this.Controls.Add(vehicle_v_vehicle_cc_rating);
            #region vehicle_v_vehicle_make define
            this.vehicle_v_vehicle_make = new System.Windows.Forms.TextBox();
            this.vehicle_v_vehicle_make.Name = "vehicle_v_vehicle_make";
            this.vehicle_v_vehicle_make.Location = new System.Drawing.Point(78, 55);
            this.vehicle_v_vehicle_make.Size = new System.Drawing.Size(129, 20);
            this.vehicle_v_vehicle_make.TabIndex = 30;
            this.vehicle_v_vehicle_make.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_vehicle_make.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.vehicle_v_vehicle_make.MaxLength = 20;
            this.vehicle_v_vehicle_make.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VehicleVVehicleMake", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(vehicle_v_vehicle_make);
            #region vehicle_v_vehicle_model define
            this.vehicle_v_vehicle_model = new System.Windows.Forms.TextBox();
            this.vehicle_v_vehicle_model.Name = "vehicle_v_vehicle_model";
            this.vehicle_v_vehicle_model.Location = new System.Drawing.Point(78, 79);
            this.vehicle_v_vehicle_model.Size = new System.Drawing.Size(129, 20);
            this.vehicle_v_vehicle_model.TabIndex = 40;
            this.vehicle_v_vehicle_model.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_vehicle_model.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.vehicle_v_vehicle_model.MaxLength = 20;
            this.vehicle_v_vehicle_model.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VehicleVVehicleModel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(vehicle_v_vehicle_model);
            #region vehicle_ft_key define
            this.vehicle_ft_key = new Metex.Windows.DataEntityCombo();
            this.vehicle_ft_key.Name = "vehicle_ft_key";
            this.vehicle_ft_key.Location = new System.Drawing.Point(78, 103);
            this.vehicle_ft_key.Size = new System.Drawing.Size(147, 21);
            this.vehicle_ft_key.TabIndex = 50;
            this.vehicle_ft_key.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.vehicle_ft_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.vehicle_ft_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VehicleFtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vehicle_ft_key.DisplayMember = "FtDescription";
            this.vehicle_ft_key.ValueMember = "FtKey";
            this.vehicle_ft_key.AutoRetrieve = true;
            #endregion
            this.Controls.Add(vehicle_ft_key);
            #region vehicle_vt_key define
            this.vehicle_vt_key = new Metex.Windows.DataEntityCombo();
            this.vehicle_vt_key.Name = "vehicle_vt_key";
            this.vehicle_vt_key.Location = new System.Drawing.Point(78, 31);
            this.vehicle_vt_key.Size = new System.Drawing.Size(147, 21);
            this.vehicle_vt_key.TabIndex = 20;
            this.vehicle_vt_key.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.vehicle_vt_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.vehicle_vt_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VehicleVtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vehicle_vt_key.DisplayMember = "VtDescription";
            this.vehicle_vt_key.ValueMember = "VtKey";
            this.vehicle_vt_key.AutoRetrieve = true;
            #endregion
            this.Controls.Add(vehicle_vt_key);
            #region vehicle_v_road_user_charges_indicator define
            this.vehicle_v_road_user_charges_indicator = new System.Windows.Forms.CheckBox();
            this.vehicle_v_road_user_charges_indicator.Name = "vehicle_v_road_user_charges_indicator";
            this.vehicle_v_road_user_charges_indicator.Location = new System.Drawing.Point(215, 5);
            this.vehicle_v_road_user_charges_indicator.Size = new System.Drawing.Size(123, 18);
            this.vehicle_v_road_user_charges_indicator.TabIndex = 70;
            this.vehicle_v_road_user_charges_indicator.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_road_user_charges_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vehicle_v_road_user_charges_indicator.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vehicle_v_road_user_charges_indicator.Text = "Road User Charges";
            this.vehicle_v_road_user_charges_indicator.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.vehicle_v_road_user_charges_indicator.ThreeState = true;
            #endregion
            this.Controls.Add(vehicle_v_road_user_charges_indicator);
            #region vehicle_v_leased define
            this.vehicle_v_leased = new System.Windows.Forms.CheckBox();
            this.vehicle_v_leased.Name = "vehicle_v_leased";
            this.vehicle_v_leased.Location = new System.Drawing.Point(273, 29);
            this.vehicle_v_leased.Size = new System.Drawing.Size(65, 16);
            this.vehicle_v_leased.TabIndex = 80;
            this.vehicle_v_leased.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_leased.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vehicle_v_leased.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vehicle_v_leased.Text = "Leased";
            this.vehicle_v_leased.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.vehicle_v_leased.ThreeState = true;
            #endregion
            this.Controls.Add(vehicle_v_leased);
            #region n_12204733 define
            this.n_12204733 = new System.Windows.Forms.Label();
            this.n_12204733.Name = "n_12204733";
            this.n_12204733.Location = new System.Drawing.Point(234, 56);
            this.n_12204733.Size = new System.Drawing.Size(85, 13);
            this.n_12204733.TabIndex = 0;
            this.n_12204733.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_12204733.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_12204733.Text = "Purchase Value";
            #endregion
            this.Controls.Add(n_12204733);
            #region n_42733733 define
            this.n_42733733 = new System.Windows.Forms.Label();
            this.n_42733733.Name = "n_42733733";
            this.n_42733733.Location = new System.Drawing.Point(237, 80);
            this.n_42733733.Size = new System.Drawing.Size(81, 13);
            this.n_42733733.TabIndex = 0;
            this.n_42733733.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_42733733.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_42733733.Text = "Purchase Date";
            #endregion
            this.Controls.Add(n_42733733);
            #region n_49059277 define
            this.n_49059277 = new System.Windows.Forms.Label();
            this.n_49059277.Name = "n_49059277";
            this.n_49059277.Location = new System.Drawing.Point(286, 105);
            this.n_49059277.Size = new System.Drawing.Size(29, 13);
            this.n_49059277.TabIndex = 0;
            this.n_49059277.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_49059277.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.n_49059277.Text = "Year";
            #endregion
            this.Controls.Add(n_49059277);
            #region vehicle_v_vehicle_month_t define
            this.vehicle_v_vehicle_month_t = new System.Windows.Forms.Label();
            this.vehicle_v_vehicle_month_t.Name = "vehicle_v_vehicle_month_t";
            this.vehicle_v_vehicle_month_t.Location = new System.Drawing.Point(281, 130);
            this.vehicle_v_vehicle_month_t.Size = new System.Drawing.Size(37, 13);
            this.vehicle_v_vehicle_month_t.TabIndex = 0;
            this.vehicle_v_vehicle_month_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_vehicle_month_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vehicle_v_vehicle_month_t.Text = "Month";
            #endregion
            this.Controls.Add(vehicle_v_vehicle_month_t);
            #region vehicle_v_purchase_value define
            this.vehicle_v_purchase_value = new System.Windows.Forms.MaskedTextBox();
            this.vehicle_v_purchase_value.Name = "vehicle_v_purchase_value";
            this.vehicle_v_purchase_value.Location = new System.Drawing.Point(324, 53);
            this.vehicle_v_purchase_value.Size = new System.Drawing.Size(53, 20);
            this.vehicle_v_purchase_value.TabIndex = 90;
            this.vehicle_v_purchase_value.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_purchase_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.vehicle_v_purchase_value.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VehicleVPurchaseValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vehicle_v_purchase_value.Mask = "###,###";
            this.vehicle_v_purchase_value.DataBindings[0].FormatString = "###,###";
            #endregion
            this.Controls.Add(vehicle_v_purchase_value);
            #region vehicle_v_purchased_date define
            this.vehicle_v_purchased_date = new System.Windows.Forms.MaskedTextBox();
            this.vehicle_v_purchased_date.Name = "vehicle_v_purchased_date";
            this.vehicle_v_purchased_date.Location = new System.Drawing.Point(324, 77);
            this.vehicle_v_purchased_date.Size = new System.Drawing.Size(74, 20);
            this.vehicle_v_purchased_date.TabIndex = 100;
            this.vehicle_v_purchased_date.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_purchased_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.vehicle_v_purchased_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VehicleVPurchasedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vehicle_v_purchased_date.Mask = "00/00/0000";
            this.vehicle_v_purchased_date.ValidatingType = typeof(System.DateTime);
            this.vehicle_v_purchased_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            #endregion
            this.Controls.Add(vehicle_v_purchased_date);
            #region vehicle_v_vehicle_year define
            this.vehicle_v_vehicle_year = new System.Windows.Forms.MaskedTextBox();
            this.vehicle_v_vehicle_year.Name = "vehicle_v_vehicle_year";
            this.vehicle_v_vehicle_year.Location = new System.Drawing.Point(324, 101);
            this.vehicle_v_vehicle_year.Size = new System.Drawing.Size(27, 20);
            this.vehicle_v_vehicle_year.TabIndex = 110;
            this.vehicle_v_vehicle_year.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.vehicle_v_vehicle_year.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.vehicle_v_vehicle_year.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VehicleVVehicleYear", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vehicle_v_vehicle_year.Mask = "####";
            #endregion
            this.Controls.Add(vehicle_v_vehicle_year);
            #region vehicle_v_vehicle_month define
            this.vehicle_v_vehicle_month = new Metex.Windows.DataEntityCombo();
            this.vehicle_v_vehicle_month.Name = "vehicle_v_vehicle_month";
            this.vehicle_v_vehicle_month.Location = new System.Drawing.Point(324, 125);
            this.vehicle_v_vehicle_month.Size = new System.Drawing.Size(91, 21);
            this.vehicle_v_vehicle_month.TabIndex = 120;
            this.vehicle_v_vehicle_month.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.vehicle_v_vehicle_month.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.vehicle_v_vehicle_month.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VehicleVVehicleMonth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(vehicle_v_vehicle_month);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.Label vehicle_v_vehicle_registration_number_t;
        private System.Windows.Forms.Label n_50279347;
        private System.Windows.Forms.Label vehicle_v_vehicle_make_t;
        private System.Windows.Forms.Label vehicle_v_vehicle_model_t;
        private System.Windows.Forms.Label n_49860945;
        private System.Windows.Forms.Label n_46095324;
        private System.Windows.Forms.TextBox vehicle_v_vehicle_registration_number;
        private System.Windows.Forms.MaskedTextBox vehicle_v_vehicle_cc_rating;
        private System.Windows.Forms.TextBox vehicle_v_vehicle_make;
        private System.Windows.Forms.TextBox vehicle_v_vehicle_model;
        private Metex.Windows.DataEntityCombo vehicle_ft_key;
        private Metex.Windows.DataEntityCombo vehicle_vt_key;
        private System.Windows.Forms.CheckBox vehicle_v_road_user_charges_indicator;
        private System.Windows.Forms.CheckBox vehicle_v_leased;
        private System.Windows.Forms.Label n_12204733;
        private System.Windows.Forms.Label n_42733733;
        private System.Windows.Forms.Label n_49059277;
        private System.Windows.Forms.Label vehicle_v_vehicle_month_t;
        private System.Windows.Forms.MaskedTextBox vehicle_v_purchase_value;
        private System.Windows.Forms.MaskedTextBox vehicle_v_purchased_date;
        private System.Windows.Forms.MaskedTextBox vehicle_v_vehicle_year;
        private Metex.Windows.DataEntityCombo vehicle_v_vehicle_month;
    }
}
