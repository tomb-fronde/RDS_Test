namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DCustomerDetails
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
            System.Windows.Forms.RadioButton cust_dir_listing_ind_2;
            this.cust_business = new System.Windows.Forms.CheckBox();
            this.cust_rural_resident = new System.Windows.Forms.CheckBox();
            this.cust_rural_farmer = new System.Windows.Forms.CheckBox();
            this.cust_surname_company_t = new System.Windows.Forms.Label();
            this.cust_initials_t = new System.Windows.Forms.Label();
            this.cust_initials = new System.Windows.Forms.TextBox();
            this.cust_title_t = new System.Windows.Forms.Label();
            this.cust_phone_day_t = new System.Windows.Forms.Label();
            this.cust_phone_mobile_t = new System.Windows.Forms.Label();
            this.t_1 = new System.Windows.Forms.Label();
            this.cust_care_of_t = new System.Windows.Forms.Label();
            this.t_2 = new System.Windows.Forms.Label();
            this.cust_last_amended_user = new System.Windows.Forms.TextBox();
            this.cust_last_amended_date = new System.Windows.Forms.TextBox();
            this.cust_id = new System.Windows.Forms.TextBox();
            this.cust_date_commenced_t = new System.Windows.Forms.Label();
            this.cust_date_commenced = new System.Windows.Forms.MaskedTextBox();
            this.cust_id_t = new System.Windows.Forms.Label();
            this.t_3 = new System.Windows.Forms.Label();
            this.t_cust_dpid = new System.Windows.Forms.Label();
            this.cust_phone_mobile = new System.Windows.Forms.MaskedTextBox();
            this.cust_phone_night_t = new System.Windows.Forms.Label();
            this.cust_dpid = new System.Windows.Forms.TextBox();
            this.cust_surname_company = new System.Windows.Forms.TextBox();
            this.cust_title = new System.Windows.Forms.TextBox();
            this.cust_adpost_quantity = new System.Windows.Forms.TextBox();
            this.cust_care_of = new System.Windows.Forms.TextBox();
            this.cust_phone_day = new System.Windows.Forms.MaskedTextBox();
            this.cust_phone_night = new System.Windows.Forms.MaskedTextBox();
            this.cust_dir_listing_ind_1 = new System.Windows.Forms.RadioButton();
            cust_dir_listing_ind_2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.CustomerDetails);
            // 
            // cust_business
            // 
            this.cust_business.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cust_business.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CustBusiness", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_business.Enabled = false;
            this.cust_business.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_business.Location = new System.Drawing.Point(483, 222);
            this.cust_business.Name = "cust_business";
            this.cust_business.Size = new System.Drawing.Size(105, 16);
            this.cust_business.TabIndex = 0;
            this.cust_business.Text = "Business";
            this.cust_business.ThreeState = true;               
            // 
            // cust_rural_resident
            // 
            this.cust_rural_resident.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cust_rural_resident.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CustRuralResident", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_rural_resident.Enabled = false;
            this.cust_rural_resident.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_rural_resident.Location = new System.Drawing.Point(483, 246);
            this.cust_rural_resident.Name = "cust_rural_resident";
            this.cust_rural_resident.Size = new System.Drawing.Size(105, 16);
            this.cust_rural_resident.TabIndex = 0;
            this.cust_rural_resident.Text = "Rural Resident";
            this.cust_rural_resident.ThreeState = true;
            // 
            // cust_rural_farmer
            // 
            this.cust_rural_farmer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cust_rural_farmer.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CustRuralFarmer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_rural_farmer.Enabled = false;
            this.cust_rural_farmer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_rural_farmer.Location = new System.Drawing.Point(483, 270);
            this.cust_rural_farmer.Name = "cust_rural_farmer";
            this.cust_rural_farmer.Size = new System.Drawing.Size(105, 16);
            this.cust_rural_farmer.TabIndex = 0;
            this.cust_rural_farmer.Text = "Rural Farmer";
            this.cust_rural_farmer.ThreeState = true;
            // 
            // cust_surname_company_t
            // 
            this.cust_surname_company_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_surname_company_t.Location = new System.Drawing.Point(0, 73);
            this.cust_surname_company_t.Name = "cust_surname_company_t";
            this.cust_surname_company_t.Size = new System.Drawing.Size(115, 13);
            this.cust_surname_company_t.TabIndex = 0;
            this.cust_surname_company_t.Text = "Surname / Company";
            this.cust_surname_company_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_initials_t
            // 
            this.cust_initials_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_initials_t.Location = new System.Drawing.Point(10, 102);
            this.cust_initials_t.Name = "cust_initials_t";
            this.cust_initials_t.Size = new System.Drawing.Size(105, 13);
            this.cust_initials_t.TabIndex = 0;
            this.cust_initials_t.Text = "Initials / First Name";
            this.cust_initials_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_initials
            // 
            this.cust_initials.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustInitials", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_initials.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_initials.Location = new System.Drawing.Point(125, 100);
            this.cust_initials.MaxLength = 30;
            this.cust_initials.Name = "cust_initials";
            this.cust_initials.Size = new System.Drawing.Size(177, 20);
            this.cust_initials.TabIndex = 30;
            // 
            // cust_title_t
            // 
            this.cust_title_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_title_t.Location = new System.Drawing.Point(312, 100);
            this.cust_title_t.Name = "cust_title_t";
            this.cust_title_t.Size = new System.Drawing.Size(32, 13);
            this.cust_title_t.TabIndex = 0;
            this.cust_title_t.Text = "Title";
            this.cust_title_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_phone_day_t
            // 
            this.cust_phone_day_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_phone_day_t.Location = new System.Drawing.Point(87, 133);
            this.cust_phone_day_t.Name = "cust_phone_day_t";
            this.cust_phone_day_t.Size = new System.Drawing.Size(29, 13);
            this.cust_phone_day_t.TabIndex = 0;
            this.cust_phone_day_t.Text = "Day";
            this.cust_phone_day_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_phone_mobile_t
            // 
            this.cust_phone_mobile_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_phone_mobile_t.Location = new System.Drawing.Point(78, 160);
            this.cust_phone_mobile_t.Name = "cust_phone_mobile_t";
            this.cust_phone_mobile_t.Size = new System.Drawing.Size(39, 13);
            this.cust_phone_mobile_t.TabIndex = 0;
            this.cust_phone_mobile_t.Text = "Mobile";
            this.cust_phone_mobile_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.Location = new System.Drawing.Point(277, 161);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(66, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "Kiwimail Qty";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_care_of_t
            // 
            this.cust_care_of_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_care_of_t.Location = new System.Drawing.Point(65, 190);
            this.cust_care_of_t.Name = "cust_care_of_t";
            this.cust_care_of_t.Size = new System.Drawing.Size(51, 13);
            this.cust_care_of_t.TabIndex = 0;
            this.cust_care_of_t.Text = "Care Of";
            this.cust_care_of_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_2
            // 
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.Location = new System.Drawing.Point(9, 220);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(107, 13);
            this.t_2.TabIndex = 0;
            this.t_2.Text = "Privacy Required?";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_last_amended_user
            // 
            this.cust_last_amended_user.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustLastAmendedUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_last_amended_user.Enabled = false;
            this.cust_last_amended_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_last_amended_user.Location = new System.Drawing.Point(652, 16);
            this.cust_last_amended_user.Name = "cust_last_amended_user";
            this.cust_last_amended_user.Size = new System.Drawing.Size(115, 20);
            this.cust_last_amended_user.TabIndex = 0;
            // 
            // cust_last_amended_date
            // 
            this.cust_last_amended_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustLastAmendedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_last_amended_date.Enabled = false;
            this.cust_last_amended_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_last_amended_date.Location = new System.Drawing.Point(648, 45);
            this.cust_last_amended_date.Name = "cust_last_amended_date";
            this.cust_last_amended_date.Size = new System.Drawing.Size(166, 20);
            this.cust_last_amended_date.TabIndex = 0;
            // 
            // cust_id
            // 
            this.cust_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_id.Enabled = false;
            this.cust_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_id.Location = new System.Drawing.Point(125, 5);
            this.cust_id.Name = "cust_id";
            this.cust_id.Size = new System.Drawing.Size(82, 20);
            this.cust_id.TabIndex = 0;
            // 
            // cust_date_commenced_t
            // 
            this.cust_date_commenced_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_date_commenced_t.Location = new System.Drawing.Point(14, 35);
            this.cust_date_commenced_t.Name = "cust_date_commenced_t";
            this.cust_date_commenced_t.Size = new System.Drawing.Size(100, 13);
            this.cust_date_commenced_t.TabIndex = 0;
            this.cust_date_commenced_t.Text = "Date Commenced";
            this.cust_date_commenced_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_date_commenced
            // 
            this.cust_date_commenced.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustDateCommenced", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_date_commenced.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_date_commenced.Location = new System.Drawing.Point(125, 32);
            this.cust_date_commenced.Mask = "00/00/0000";
            this.cust_date_commenced.Name = "cust_date_commenced";
            this.cust_date_commenced.Size = new System.Drawing.Size(82, 20);
            this.cust_date_commenced.TabIndex = 10;
            this.cust_date_commenced.ValidatingType = typeof(System.DateTime);
            // 
            // cust_id_t
            // 
            this.cust_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_id_t.Location = new System.Drawing.Point(14, 7);
            this.cust_id_t.Name = "cust_id_t";
            this.cust_id_t.Size = new System.Drawing.Size(100, 13);
            this.cust_id_t.TabIndex = 0;
            this.cust_id_t.Text = "Customer Id";
            this.cust_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_3
            // 
            this.t_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.t_3.Location = new System.Drawing.Point(140, 56);
            this.t_3.Name = "t_3";
            this.t_3.Size = new System.Drawing.Size(49, 10);
            this.t_3.TabIndex = 0;
            this.t_3.Text = "dd/mm/yyyy";
            this.t_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_cust_dpid
            // 
            this.t_cust_dpid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_cust_dpid.Location = new System.Drawing.Point(235, 8);
            this.t_cust_dpid.Name = "t_cust_dpid";
            this.t_cust_dpid.Size = new System.Drawing.Size(91, 13);
            this.t_cust_dpid.TabIndex = 0;
            this.t_cust_dpid.Text = "Customer DPID";
            this.t_cust_dpid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_phone_mobile
            // 
            this.cust_phone_mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustPhoneMobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_phone_mobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_phone_mobile.Location = new System.Drawing.Point(125, 158);
            this.cust_phone_mobile.Mask = "(###) ###-#####";
            this.cust_phone_mobile.Name = "cust_phone_mobile";
            this.cust_phone_mobile.Size = new System.Drawing.Size(110, 20);
            this.cust_phone_mobile.TabIndex = 70;
            // 
            // cust_phone_night_t
            // 
            this.cust_phone_night_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_phone_night_t.Location = new System.Drawing.Point(253, 131);
            this.cust_phone_night_t.Name = "cust_phone_night_t";
            this.cust_phone_night_t.Size = new System.Drawing.Size(37, 13);
            this.cust_phone_night_t.TabIndex = 0;
            this.cust_phone_night_t.Text = "Night";
            this.cust_phone_night_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_dpid
            // 
            this.cust_dpid.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustDpid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_dpid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_dpid.Location = new System.Drawing.Point(334, 5);
            this.cust_dpid.Name = "cust_dpid";
            this.cust_dpid.Size = new System.Drawing.Size(75, 20);
            this.cust_dpid.TabIndex = 110;
            // 
            // cust_surname_company
            // 
            this.cust_surname_company.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustSurnameCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_surname_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_surname_company.Location = new System.Drawing.Point(125, 70);
            this.cust_surname_company.MaxLength = 45;
            this.cust_surname_company.Name = "cust_surname_company";
            this.cust_surname_company.Size = new System.Drawing.Size(284, 20);
            this.cust_surname_company.TabIndex = 20;
            // 
            // cust_title
            // 
            this.cust_title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_title.Location = new System.Drawing.Point(352, 100);
            this.cust_title.MaxLength = 10;
            this.cust_title.Name = "cust_title";
            this.cust_title.Size = new System.Drawing.Size(58, 20);
            this.cust_title.TabIndex = 40;
            // 
            // cust_adpost_quantity
            // 
            this.cust_adpost_quantity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustAdpostQuantity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_adpost_quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_adpost_quantity.Location = new System.Drawing.Point(355, 158);
            this.cust_adpost_quantity.Name = "cust_adpost_quantity";
            this.cust_adpost_quantity.Size = new System.Drawing.Size(54, 20);
            this.cust_adpost_quantity.TabIndex = 80;
            // 
            // cust_care_of
            // 
            this.cust_care_of.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustCareOf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_care_of.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_care_of.Location = new System.Drawing.Point(125, 188);
            this.cust_care_of.MaxLength = 75;
            this.cust_care_of.Name = "cust_care_of";
            this.cust_care_of.Size = new System.Drawing.Size(284, 20);
            this.cust_care_of.TabIndex = 90;
            // 
            // cust_phone_day
            // 
            this.cust_phone_day.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustPhoneDay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_phone_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_phone_day.Location = new System.Drawing.Point(125, 129);
            this.cust_phone_day.Mask = "(##) ###-######";
            this.cust_phone_day.Name = "cust_phone_day";
            this.cust_phone_day.Size = new System.Drawing.Size(110, 20);
            this.cust_phone_day.TabIndex = 50;
            // 
            // cust_phone_night
            // 
            this.cust_phone_night.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustPhoneNight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_phone_night.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_phone_night.Location = new System.Drawing.Point(299, 129);
            this.cust_phone_night.Mask = "(##) ###-######";
            this.cust_phone_night.Name = "cust_phone_night";
            this.cust_phone_night.Size = new System.Drawing.Size(110, 20);
            this.cust_phone_night.TabIndex = 60;
            // 
            // cust_dir_listing_ind_1
            // 
            this.cust_dir_listing_ind_1.AutoSize = true;
            this.cust_dir_listing_ind_1.Location = new System.Drawing.Point(125, 220);
            this.cust_dir_listing_ind_1.Name = "cust_dir_listing_ind_1";
            this.cust_dir_listing_ind_1.Size = new System.Drawing.Size(43, 17);
            this.cust_dir_listing_ind_1.TabIndex = 111;
            this.cust_dir_listing_ind_1.TabStop = true;
            this.cust_dir_listing_ind_1.Text = "Yes";
            this.cust_dir_listing_ind_1.UseVisualStyleBackColor = true;
            this.cust_dir_listing_ind_1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CustDirListingInd1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            // 
            // cust_dir_listing_ind_2
            // 
            cust_dir_listing_ind_2.AutoSize = true;
            cust_dir_listing_ind_2.Location = new System.Drawing.Point(174, 222);
            cust_dir_listing_ind_2.Name = "cust_dir_listing_ind_2";
            cust_dir_listing_ind_2.Size = new System.Drawing.Size(39, 17);
            cust_dir_listing_ind_2.TabIndex = 112;
            cust_dir_listing_ind_2.TabStop = true;
            cust_dir_listing_ind_2.Text = "No";
            cust_dir_listing_ind_2.UseVisualStyleBackColor = true;
            cust_dir_listing_ind_2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CustDirListingInd2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            // 
            // DCustomerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(cust_dir_listing_ind_2);
            this.Controls.Add(this.cust_dir_listing_ind_1);
            this.Controls.Add(this.cust_business);
            this.Controls.Add(this.cust_rural_resident);
            this.Controls.Add(this.cust_rural_farmer);
            this.Controls.Add(this.cust_surname_company_t);
            this.Controls.Add(this.cust_initials_t);
            this.Controls.Add(this.cust_initials);
            this.Controls.Add(this.cust_title_t);
            this.Controls.Add(this.cust_phone_day_t);
            this.Controls.Add(this.cust_phone_mobile_t);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.cust_care_of_t);
            this.Controls.Add(this.t_2);
            this.Controls.Add(this.cust_last_amended_user);
            this.Controls.Add(this.cust_last_amended_date);
            this.Controls.Add(this.cust_id);
            this.Controls.Add(this.cust_date_commenced_t);
            this.Controls.Add(this.cust_date_commenced);
            this.Controls.Add(this.cust_id_t);
            this.Controls.Add(this.t_3);
            this.Controls.Add(this.t_cust_dpid);
            this.Controls.Add(this.cust_phone_mobile);
            this.Controls.Add(this.cust_phone_night_t);
            this.Controls.Add(this.cust_dpid);
            this.Controls.Add(this.cust_surname_company);
            this.Controls.Add(this.cust_title);
            this.Controls.Add(this.cust_adpost_quantity);
            this.Controls.Add(this.cust_care_of);
            this.Controls.Add(this.cust_phone_day);
            this.Controls.Add(this.cust_phone_night);
            this.Name = "DCustomerDetails";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cust_business;
        private System.Windows.Forms.CheckBox cust_rural_resident;
        private System.Windows.Forms.CheckBox cust_rural_farmer;
        private System.Windows.Forms.Label cust_surname_company_t;
        private System.Windows.Forms.Label cust_initials_t;
        private System.Windows.Forms.TextBox cust_initials;
        private System.Windows.Forms.Label cust_title_t;
        private System.Windows.Forms.Label cust_phone_day_t;
        private System.Windows.Forms.Label cust_phone_mobile_t;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label cust_care_of_t;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.TextBox cust_last_amended_user;
        private System.Windows.Forms.TextBox cust_last_amended_date;
        private System.Windows.Forms.TextBox cust_id;
        private System.Windows.Forms.Label cust_date_commenced_t;
        private System.Windows.Forms.MaskedTextBox cust_date_commenced;
        private System.Windows.Forms.Label cust_id_t;
        private System.Windows.Forms.Label t_3;
        private System.Windows.Forms.Label t_cust_dpid;
        private System.Windows.Forms.MaskedTextBox cust_phone_mobile;
        private System.Windows.Forms.Label cust_phone_night_t;
        private System.Windows.Forms.TextBox cust_dpid;
        private System.Windows.Forms.TextBox cust_surname_company;
        private System.Windows.Forms.TextBox cust_title;
        private System.Windows.Forms.TextBox cust_adpost_quantity;
        private System.Windows.Forms.TextBox cust_care_of;
        private System.Windows.Forms.MaskedTextBox cust_phone_day;
        private System.Windows.Forms.MaskedTextBox cust_phone_night;
        private System.Windows.Forms.RadioButton cust_dir_listing_ind_1;
    }
}
