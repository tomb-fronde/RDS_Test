using System;
using System.ComponentModel;
using System.Windows.Forms;

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

        private System.Windows.Forms.Label cust_surname_company_t;
        private System.Windows.Forms.Label cust_initials_t;
        private System.Windows.Forms.TextBox cust_initials;
        private System.Windows.Forms.Label cust_title_t;
        private System.Windows.Forms.Label cust_phone_day_t;
        private System.Windows.Forms.Label cust_phone_mobile_t;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label cust_care_of_t;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label cust_date_commenced_t;
        private System.Windows.Forms.Label t_3;
        private System.Windows.Forms.MaskedTextBox cust_phone_mobile;
        private System.Windows.Forms.Label cust_phone_night_t;
        // TJB RD7_0042 Jan-2010: Changed to ComboBox
        //private Metex.Windows.DataEntityCombo cust_title;
        private System.Windows.Forms.ComboBox cust_title;

        private System.Windows.Forms.TextBox cust_adpost_quantity;
        private System.Windows.Forms.TextBox cust_care_of;
        private System.Windows.Forms.MaskedTextBox cust_phone_day;
        private System.Windows.Forms.MaskedTextBox cust_phone_night;
        private System.Windows.Forms.Label cust_id_t;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox cust_date_commenced;// System.Windows.Forms.MaskedTextBox cust_date_commenced;
        private System.Windows.Forms.Label t_cust_dpid;
        private System.Windows.Forms.TextBox cust_id;
        private System.Windows.Forms.TextBox cust_dpid;
        private System.Windows.Forms.TextBox cust_surname_company;
        private System.Windows.Forms.Label customer_category_t;
        private System.Windows.Forms.CheckBox cust_business;
        private System.Windows.Forms.CheckBox cust_rural_resident;
        private System.Windows.Forms.CheckBox cust_rural_farmer;
        private System.Windows.Forms.RadioButton cust_dir_listing_ind_1;
        private System.Windows.Forms.RadioButton cust_dir_listing_ind_2;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cust_surname_company_t = new System.Windows.Forms.Label();
            this.cust_surname_company = new System.Windows.Forms.TextBox();
            this.cust_initials_t = new System.Windows.Forms.Label();
            this.cust_initials = new System.Windows.Forms.TextBox();
            this.cust_title_t = new System.Windows.Forms.Label();
            this.cust_title = new System.Windows.Forms.ComboBox();
            this.cust_phone_day_t = new System.Windows.Forms.Label();
            this.cust_phone_day = new System.Windows.Forms.MaskedTextBox();
            this.cust_phone_mobile_t = new System.Windows.Forms.Label();
            this.cust_phone_mobile = new System.Windows.Forms.MaskedTextBox();
            this.cust_phone_night_t = new System.Windows.Forms.Label();
            this.cust_phone_night = new System.Windows.Forms.MaskedTextBox();
            this.t_1 = new System.Windows.Forms.Label();
            this.cust_care_of_t = new System.Windows.Forms.Label();
            this.t_2 = new System.Windows.Forms.Label();
            this.cust_date_commenced_t = new System.Windows.Forms.Label();
            this.t_3 = new System.Windows.Forms.Label();
            this.cust_adpost_quantity = new System.Windows.Forms.TextBox();
            this.cust_care_of = new System.Windows.Forms.TextBox();
            this.cust_id_t = new System.Windows.Forms.Label();
            this.cust_date_commenced = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.t_cust_dpid = new System.Windows.Forms.Label();
            this.cust_id = new System.Windows.Forms.TextBox();
            this.cust_dpid = new System.Windows.Forms.TextBox();
            this.customer_category_t = new System.Windows.Forms.Label();
            this.cust_business = new System.Windows.Forms.CheckBox();
            this.cust_rural_resident = new System.Windows.Forms.CheckBox();
            this.cust_rural_farmer = new System.Windows.Forms.CheckBox();
            this.cust_dir_listing_ind_1 = new System.Windows.Forms.RadioButton();
            this.cust_dir_listing_ind_2 = new System.Windows.Forms.RadioButton();
            this.move_in_date_t = new System.Windows.Forms.Label();
            this.move_in_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.cust_case_name_t = new System.Windows.Forms.Label();
            this.cust_case_name = new System.Windows.Forms.TextBox();
            this.cust_slot_allocation_t = new System.Windows.Forms.Label();
            this.cust_slot_allocation = new System.Windows.Forms.TextBox();
            this.case_name_max_size = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.CustomerDetails2);
            // 
            // cust_surname_company_t
            // 
            this.cust_surname_company_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_surname_company_t.Location = new System.Drawing.Point(-6, 62);
            this.cust_surname_company_t.Name = "cust_surname_company_t";
            this.cust_surname_company_t.Size = new System.Drawing.Size(109, 13);
            this.cust_surname_company_t.TabIndex = 0;
            this.cust_surname_company_t.Text = "Surname / Company";
            this.cust_surname_company_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_surname_company
            // 
            this.cust_surname_company.BackColor = System.Drawing.Color.Aqua;
            this.cust_surname_company.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustSurnameCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_surname_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_surname_company.Location = new System.Drawing.Point(107, 58);
            this.cust_surname_company.MaxLength = 45;
            this.cust_surname_company.Name = "cust_surname_company";
            this.cust_surname_company.Size = new System.Drawing.Size(256, 20);
            this.cust_surname_company.TabIndex = 20;
            // 
            // cust_initials_t
            // 
            this.cust_initials_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_initials_t.Location = new System.Drawing.Point(-2, 84);
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
            this.cust_initials.Location = new System.Drawing.Point(107, 80);
            this.cust_initials.MaxLength = 30;
            this.cust_initials.Name = "cust_initials";
            this.cust_initials.Size = new System.Drawing.Size(153, 20);
            this.cust_initials.TabIndex = 30;
            // 
            // cust_title_t
            // 
            this.cust_title_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_title_t.Location = new System.Drawing.Point(258, 84);
            this.cust_title_t.Name = "cust_title_t";
            this.cust_title_t.Size = new System.Drawing.Size(28, 13);
            this.cust_title_t.TabIndex = 0;
            this.cust_title_t.Text = "Title";
            this.cust_title_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_title
            // 
            this.cust_title.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cust_title.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cust_title.DisplayMember = "CustomerTitle";
            this.cust_title.DropDownWidth = 74;
            this.cust_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_title.Location = new System.Drawing.Point(289, 80);
            this.cust_title.Name = "cust_title";
            this.cust_title.Size = new System.Drawing.Size(74, 21);
            this.cust_title.TabIndex = 40;
            this.cust_title.ValueMember = "CustomerTitle";
            // 
            // cust_phone_day_t
            // 
            this.cust_phone_day_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_phone_day_t.Location = new System.Drawing.Point(74, 106);
            this.cust_phone_day_t.Name = "cust_phone_day_t";
            this.cust_phone_day_t.Size = new System.Drawing.Size(28, 13);
            this.cust_phone_day_t.TabIndex = 0;
            this.cust_phone_day_t.Text = "Day";
            this.cust_phone_day_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_phone_day
            // 
            this.cust_phone_day.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustPhoneDay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_phone_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_phone_day.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.cust_phone_day.Location = new System.Drawing.Point(107, 102);
            this.cust_phone_day.Mask = "(##) ###-######";
            this.cust_phone_day.Name = "cust_phone_day";
            this.cust_phone_day.PromptChar = ' ';
            this.cust_phone_day.Size = new System.Drawing.Size(110, 20);
            this.cust_phone_day.TabIndex = 50;
            this.cust_phone_day.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // cust_phone_mobile_t
            // 
            this.cust_phone_mobile_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_phone_mobile_t.Location = new System.Drawing.Point(63, 128);
            this.cust_phone_mobile_t.Name = "cust_phone_mobile_t";
            this.cust_phone_mobile_t.Size = new System.Drawing.Size(39, 13);
            this.cust_phone_mobile_t.TabIndex = 0;
            this.cust_phone_mobile_t.Text = "Mobile";
            this.cust_phone_mobile_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_phone_mobile
            // 
            this.cust_phone_mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustPhoneMobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_phone_mobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_phone_mobile.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.cust_phone_mobile.Location = new System.Drawing.Point(107, 124);
            this.cust_phone_mobile.Mask = "(###) ###-#####";
            this.cust_phone_mobile.Name = "cust_phone_mobile";
            this.cust_phone_mobile.PromptChar = ' ';
            this.cust_phone_mobile.Size = new System.Drawing.Size(110, 20);
            this.cust_phone_mobile.TabIndex = 70;
            this.cust_phone_mobile.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cust_phone_night_t
            // 
            this.cust_phone_night_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_phone_night_t.Location = new System.Drawing.Point(226, 106);
            this.cust_phone_night_t.Name = "cust_phone_night_t";
            this.cust_phone_night_t.Size = new System.Drawing.Size(37, 13);
            this.cust_phone_night_t.TabIndex = 0;
            this.cust_phone_night_t.Text = "Night";
            this.cust_phone_night_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_phone_night
            // 
            this.cust_phone_night.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustPhoneNight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_phone_night.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_phone_night.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.cust_phone_night.Location = new System.Drawing.Point(272, 102);
            this.cust_phone_night.Mask = "(##) ###-######";
            this.cust_phone_night.Name = "cust_phone_night";
            this.cust_phone_night.PromptChar = ' ';
            this.cust_phone_night.Size = new System.Drawing.Size(91, 20);
            this.cust_phone_night.TabIndex = 60;
            this.cust_phone_night.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.Location = new System.Drawing.Point(232, 128);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(66, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "Kiwimail Qty";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_care_of_t
            // 
            this.cust_care_of_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_care_of_t.Location = new System.Drawing.Point(53, 150);
            this.cust_care_of_t.Name = "cust_care_of_t";
            this.cust_care_of_t.Size = new System.Drawing.Size(49, 13);
            this.cust_care_of_t.TabIndex = 0;
            this.cust_care_of_t.Text = "Care Of";
            this.cust_care_of_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_2
            // 
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.Location = new System.Drawing.Point(0, 170);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(106, 13);
            this.t_2.TabIndex = 0;
            this.t_2.Text = "Privacy Required?";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_date_commenced_t
            // 
            this.cust_date_commenced_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_date_commenced_t.Location = new System.Drawing.Point(3, 29);
            this.cust_date_commenced_t.Name = "cust_date_commenced_t";
            this.cust_date_commenced_t.Size = new System.Drawing.Size(99, 13);
            this.cust_date_commenced_t.TabIndex = 0;
            this.cust_date_commenced_t.Text = "Date Commenced";
            this.cust_date_commenced_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_3
            // 
            this.t_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.t_3.Location = new System.Drawing.Point(122, 46);
            this.t_3.Name = "t_3";
            this.t_3.Size = new System.Drawing.Size(49, 10);
            this.t_3.TabIndex = 0;
            this.t_3.Text = "dd/MM/yyyy";
            this.t_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cust_adpost_quantity
            // 
            this.cust_adpost_quantity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustAdpostQuantity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_adpost_quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_adpost_quantity.Location = new System.Drawing.Point(310, 124);
            this.cust_adpost_quantity.Name = "cust_adpost_quantity";
            this.cust_adpost_quantity.Size = new System.Drawing.Size(54, 20);
            this.cust_adpost_quantity.TabIndex = 80;
            // 
            // cust_care_of
            // 
            this.cust_care_of.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustCareOf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_care_of.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_care_of.Location = new System.Drawing.Point(107, 146);
            this.cust_care_of.MaxLength = 75;
            this.cust_care_of.Name = "cust_care_of";
            this.cust_care_of.Size = new System.Drawing.Size(257, 20);
            this.cust_care_of.TabIndex = 90;
            // 
            // cust_id_t
            // 
            this.cust_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_id_t.Location = new System.Drawing.Point(2, 6);
            this.cust_id_t.Name = "cust_id_t";
            this.cust_id_t.Size = new System.Drawing.Size(100, 13);
            this.cust_id_t.TabIndex = 0;
            this.cust_id_t.Text = "Customer Id";
            this.cust_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_date_commenced
            // 
            this.cust_date_commenced.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CustDateCommenced", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_date_commenced.EditMask = "";
            this.cust_date_commenced.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_date_commenced.Location = new System.Drawing.Point(107, 25);
            this.cust_date_commenced.Mask = "00/00/0000";
            this.cust_date_commenced.Name = "cust_date_commenced";
            this.cust_date_commenced.Size = new System.Drawing.Size(82, 20);
            this.cust_date_commenced.TabIndex = 10;
            this.cust_date_commenced.Text = "00000000";
            this.cust_date_commenced.Value = null;
            // 
            // t_cust_dpid
            // 
            this.t_cust_dpid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_cust_dpid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.t_cust_dpid.Location = new System.Drawing.Point(208, 6);
            this.t_cust_dpid.Name = "t_cust_dpid";
            this.t_cust_dpid.Size = new System.Drawing.Size(81, 13);
            this.t_cust_dpid.TabIndex = 0;
            this.t_cust_dpid.Text = "Customer DPID";
            this.t_cust_dpid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_id
            // 
            this.cust_id.BackColor = System.Drawing.SystemColors.Control;
            this.cust_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cust_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_id.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cust_id.Location = new System.Drawing.Point(107, 6);
            this.cust_id.Name = "cust_id";
            this.cust_id.ReadOnly = true;
            this.cust_id.Size = new System.Drawing.Size(82, 13);
            this.cust_id.TabIndex = 0;
            this.cust_id.TabStop = false;
            // 
            // cust_dpid
            // 
            this.cust_dpid.BackColor = System.Drawing.SystemColors.Control;
            this.cust_dpid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cust_dpid.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustDpid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_dpid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_dpid.Location = new System.Drawing.Point(296, 6);
            this.cust_dpid.Name = "cust_dpid";
            this.cust_dpid.ReadOnly = true;
            this.cust_dpid.Size = new System.Drawing.Size(67, 13);
            this.cust_dpid.TabIndex = 0;
            this.cust_dpid.TabStop = false;
            // 
            // customer_category_t
            // 
            this.customer_category_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.customer_category_t.Location = new System.Drawing.Point(6, 188);
            this.customer_category_t.Name = "customer_category_t";
            this.customer_category_t.Size = new System.Drawing.Size(97, 13);
            this.customer_category_t.TabIndex = 0;
            this.customer_category_t.Text = "Customer Category";
            this.customer_category_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_business
            // 
            this.cust_business.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cust_business.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CustBusiness", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_business.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_business.Location = new System.Drawing.Point(117, 187);
            this.cust_business.Name = "cust_business";
            this.cust_business.Size = new System.Drawing.Size(105, 20);
            this.cust_business.TabIndex = 110;
            this.cust_business.Text = "Business";
            // 
            // cust_rural_resident
            // 
            this.cust_rural_resident.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cust_rural_resident.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CustRuralResident", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_rural_resident.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_rural_resident.Location = new System.Drawing.Point(117, 204);
            this.cust_rural_resident.Name = "cust_rural_resident";
            this.cust_rural_resident.Size = new System.Drawing.Size(105, 20);
            this.cust_rural_resident.TabIndex = 120;
            this.cust_rural_resident.Text = "Rural Resident";
            // 
            // cust_rural_farmer
            // 
            this.cust_rural_farmer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cust_rural_farmer.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CustRuralFarmer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_rural_farmer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_rural_farmer.Location = new System.Drawing.Point(117, 221);
            this.cust_rural_farmer.Name = "cust_rural_farmer";
            this.cust_rural_farmer.Size = new System.Drawing.Size(105, 20);
            this.cust_rural_farmer.TabIndex = 130;
            this.cust_rural_farmer.Text = "Rural Farmer";
            // 
            // cust_dir_listing_ind_1
            // 
            this.cust_dir_listing_ind_1.AutoSize = true;
            this.cust_dir_listing_ind_1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CustDirListingInd1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_dir_listing_ind_1.Location = new System.Drawing.Point(117, 168);
            this.cust_dir_listing_ind_1.Name = "cust_dir_listing_ind_1";
            this.cust_dir_listing_ind_1.Size = new System.Drawing.Size(43, 17);
            this.cust_dir_listing_ind_1.TabIndex = 141;
            this.cust_dir_listing_ind_1.TabStop = true;
            this.cust_dir_listing_ind_1.Text = "Yes";
            this.cust_dir_listing_ind_1.UseVisualStyleBackColor = true;
            // 
            // cust_dir_listing_ind_2
            // 
            this.cust_dir_listing_ind_2.AutoSize = true;
            this.cust_dir_listing_ind_2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CustDirListingInd2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_dir_listing_ind_2.Location = new System.Drawing.Point(181, 168);
            this.cust_dir_listing_ind_2.Name = "cust_dir_listing_ind_2";
            this.cust_dir_listing_ind_2.Size = new System.Drawing.Size(39, 17);
            this.cust_dir_listing_ind_2.TabIndex = 142;
            this.cust_dir_listing_ind_2.TabStop = true;
            this.cust_dir_listing_ind_2.Text = "No";
            this.cust_dir_listing_ind_2.UseVisualStyleBackColor = true;
            // 
            // move_in_date_t
            // 
            this.move_in_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.move_in_date_t.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.move_in_date_t.Location = new System.Drawing.Point(211, 29);
            this.move_in_date_t.Name = "move_in_date_t";
            this.move_in_date_t.Size = new System.Drawing.Size(78, 13);
            this.move_in_date_t.TabIndex = 143;
            this.move_in_date_t.Text = "Move In Date";
            this.move_in_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_in_date
            // 
            this.move_in_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.move_in_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CustMoveInDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.move_in_date.EditMask = "";
            this.move_in_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.move_in_date.ForeColor = System.Drawing.SystemColors.WindowText;
            this.move_in_date.Location = new System.Drawing.Point(296, 29);
            this.move_in_date.Mask = "00/00/0000";
            this.move_in_date.Name = "move_in_date";
            this.move_in_date.ReadOnly = true;
            this.move_in_date.Size = new System.Drawing.Size(62, 13);
            this.move_in_date.TabIndex = 0;
            this.move_in_date.TabStop = false;
            this.move_in_date.Text = "00000000";
            this.move_in_date.Value = null;
            // 
            // cust_case_name_t
            // 
            this.cust_case_name_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_case_name_t.Location = new System.Drawing.Point(9, 238);
            this.cust_case_name_t.Name = "cust_case_name_t";
            this.cust_case_name_t.Size = new System.Drawing.Size(94, 13);
            this.cust_case_name_t.TabIndex = 144;
            this.cust_case_name_t.Text = "Case Name";
            this.cust_case_name_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cust_case_name
            // 
            this.cust_case_name.BackColor = System.Drawing.SystemColors.Window;
            this.cust_case_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustCaseName", true));
            this.cust_case_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_case_name.Location = new System.Drawing.Point(107, 241);
            this.cust_case_name.MaxLength = 25;
            this.cust_case_name.Name = "cust_case_name";
            this.cust_case_name.Size = new System.Drawing.Size(153, 20);
            this.cust_case_name.TabIndex = 145;
            // 
            // cust_slot_allocation_t
            // 
            this.cust_slot_allocation_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_slot_allocation_t.Location = new System.Drawing.Point(275, 235);
            this.cust_slot_allocation_t.Name = "cust_slot_allocation_t";
            this.cust_slot_allocation_t.Size = new System.Drawing.Size(57, 29);
            this.cust_slot_allocation_t.TabIndex = 146;
            this.cust_slot_allocation_t.Text = "Slot Allocation";
            this.cust_slot_allocation_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cust_slot_allocation
            // 
            this.cust_slot_allocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustSlotAllocation", true));
            this.cust_slot_allocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_slot_allocation.Location = new System.Drawing.Point(334, 241);
            this.cust_slot_allocation.Name = "cust_slot_allocation";
            this.cust_slot_allocation.Size = new System.Drawing.Size(29, 20);
            this.cust_slot_allocation.TabIndex = 147;
            // 
            // case_name_max_size
            // 
            this.case_name_max_size.AutoSize = true;
            this.case_name_max_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.case_name_max_size.Location = new System.Drawing.Point(15, 251);
            this.case_name_max_size.Name = "case_name_max_size";
            this.case_name_max_size.Size = new System.Drawing.Size(88, 12);
            this.case_name_max_size.TabIndex = 148;
            this.case_name_max_size.Text = "(Max 25 characters)";
            // 
            // DCustomerDetails2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.case_name_max_size);
            this.Controls.Add(this.cust_slot_allocation_t);
            this.Controls.Add(this.cust_slot_allocation);
            this.Controls.Add(this.cust_case_name_t);
            this.Controls.Add(this.cust_case_name);
            this.Controls.Add(this.move_in_date);
            this.Controls.Add(this.move_in_date_t);
            this.Controls.Add(this.cust_id);
            this.Controls.Add(this.cust_dir_listing_ind_2);
            this.Controls.Add(this.cust_dir_listing_ind_1);
            this.Controls.Add(this.cust_surname_company_t);
            this.Controls.Add(this.cust_initials_t);
            this.Controls.Add(this.cust_initials);
            this.Controls.Add(this.cust_title_t);
            this.Controls.Add(this.cust_phone_day_t);
            this.Controls.Add(this.cust_phone_mobile_t);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.cust_care_of_t);
            this.Controls.Add(this.t_2);
            this.Controls.Add(this.cust_date_commenced_t);
            this.Controls.Add(this.t_3);
            this.Controls.Add(this.cust_phone_mobile);
            this.Controls.Add(this.cust_phone_night_t);
            this.Controls.Add(this.cust_title);
            this.Controls.Add(this.cust_adpost_quantity);
            this.Controls.Add(this.cust_care_of);
            this.Controls.Add(this.cust_phone_day);
            this.Controls.Add(this.cust_phone_night);
            this.Controls.Add(this.cust_id_t);
            this.Controls.Add(this.cust_date_commenced);
            this.Controls.Add(this.t_cust_dpid);
            this.Controls.Add(this.cust_dpid);
            this.Controls.Add(this.cust_surname_company);
            this.Controls.Add(this.customer_category_t);
            this.Controls.Add(this.cust_business);
            this.Controls.Add(this.cust_rural_resident);
            this.Controls.Add(this.cust_rural_farmer);
            this.Name = "DCustomerDetails2";
            this.Size = new System.Drawing.Size(374, 284);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label move_in_date_t;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox move_in_date;
        private Label cust_case_name_t;
        private TextBox cust_case_name;
        private Label cust_slot_allocation_t;
        private TextBox cust_slot_allocation;
        private Label case_name_max_size;

    }
}
