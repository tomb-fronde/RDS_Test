namespace NZPostOffice.RDS.DataControls.Ruralmailmerge
{
    partial class DMailmergeOdDownloadData
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
            this.cc_salutation = new System.Windows.Forms.TextBox();
            this.contract_contract_no = new System.Windows.Forms.TextBox();
            this.contractor_c_title = new System.Windows.Forms.TextBox();
            this.contractor_c_salutation = new System.Windows.Forms.TextBox();
            this.contractor_c_initials = new System.Windows.Forms.TextBox();
            this.contractor_c_first_names = new System.Windows.Forms.TextBox();
            this.contractor_c_surname_company = new System.Windows.Forms.TextBox();
            this.contractor_c_address = new System.Windows.Forms.TextBox();
            this.outlet_o_manager = new System.Windows.Forms.TextBox();
            this.outlet_o_address = new System.Windows.Forms.TextBox();
            this.outlet_o_telephone = new System.Windows.Forms.TextBox();
            this.outlet_o_fax = new System.Windows.Forms.TextBox();
            this.region_rgn_rcm_manager = new System.Windows.Forms.TextBox();
            this.region_rgn_fax = new System.Windows.Forms.TextBox();
            this.region_rgn_telephone = new System.Windows.Forms.TextBox();
            this.region_rgn_address = new System.Windows.Forms.TextBox();
            this.contract_renewals_con_expiry_date = new System.Windows.Forms.TextBox();
            this.outlet_o_name = new System.Windows.Forms.TextBox();
            this.contract_con_title = new System.Windows.Forms.TextBox();
            this.contractor_c_tax_rate = new System.Windows.Forms.TextBox();
            this.contractor_c_ird_no = new System.Windows.Forms.TextBox();
            this.contractor_renewals_cr_effective_date = new System.Windows.Forms.TextBox();
            this.c_phone_day = new System.Windows.Forms.TextBox();
            this.c_phone_night = new System.Windows.Forms.TextBox();
            this.c_mobile = new System.Windows.Forms.TextBox();
            this.c_mobile2 = new System.Windows.Forms.TextBox();
            this.primary_contact = new System.Windows.Forms.TextBox();
            this.c_email_address = new System.Windows.Forms.TextBox();
            this.contractor_c_bank_account_no = new System.Windows.Forms.TextBox();
            this.contract_renewals_con_start_date = new System.Windows.Forms.TextBox();
            this.region_rgn_name = new System.Windows.Forms.TextBox();
            this.driver_name = new System.Windows.Forms.TextBox();
            this.contractor_contractor_supplier_no = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralmailmerge.MailmergeOdDownloadData);
            // 
            // cc_salutation
            // 
            this.cc_salutation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RegionRgnAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cc_salutation.Enabled = false;
            this.cc_salutation.Font = new System.Drawing.Font("Arial", 8F);
            this.cc_salutation.Location = new System.Drawing.Point(1129, 1);
            this.cc_salutation.Name = "cc_salutation";
            this.cc_salutation.Size = new System.Drawing.Size(529, 20);
            this.cc_salutation.TabIndex = 0;
            // 
            // contract_contract_no
            // 
            this.contract_contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCSalutation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_contract_no.Enabled = false;
            this.contract_contract_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_contract_no.Location = new System.Drawing.Point(1662, 1);
            this.contract_contract_no.Name = "contract_contract_no";
            this.contract_contract_no.Size = new System.Drawing.Size(246, 20);
            this.contract_contract_no.TabIndex = 0;
            // 
            // contractor_c_title
            // 
            this.contractor_c_title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_title.Enabled = false;
            this.contractor_c_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_c_title.Location = new System.Drawing.Point(124, 1);
            this.contractor_c_title.MaxLength = 10;
            this.contractor_c_title.Name = "contractor_c_title";
            this.contractor_c_title.Size = new System.Drawing.Size(62, 20);
            this.contractor_c_title.TabIndex = 0;
            // 
            // contractor_c_salutation
            // 
            this.contractor_c_salutation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RegionRgnTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_salutation.Enabled = false;
            this.contractor_c_salutation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_c_salutation.Location = new System.Drawing.Point(187, 1);
            this.contractor_c_salutation.MaxLength = 40;
            this.contractor_c_salutation.Name = "contractor_c_salutation";
            this.contractor_c_salutation.Size = new System.Drawing.Size(234, 20);
            this.contractor_c_salutation.TabIndex = 0;
            // 
            // contractor_c_initials
            // 
            this.contractor_c_initials.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCInitials", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_initials.Enabled = false;
            this.contractor_c_initials.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_c_initials.Location = new System.Drawing.Point(424, 1);
            this.contractor_c_initials.MaxLength = 10;
            this.contractor_c_initials.Name = "contractor_c_initials";
            this.contractor_c_initials.Size = new System.Drawing.Size(64, 20);
            this.contractor_c_initials.TabIndex = 0;
            // 
            // contractor_c_first_names
            // 
            this.contractor_c_first_names.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCFirstNames", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_first_names.Enabled = false;
            this.contractor_c_first_names.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_c_first_names.Location = new System.Drawing.Point(489, 1);
            this.contractor_c_first_names.MaxLength = 40;
            this.contractor_c_first_names.Name = "contractor_c_first_names";
            this.contractor_c_first_names.Size = new System.Drawing.Size(234, 20);
            this.contractor_c_first_names.TabIndex = 0;
            // 
            // contractor_c_surname_company
            // 
            this.contractor_c_surname_company.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCSurnameCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_surname_company.Enabled = false;
            this.contractor_c_surname_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_c_surname_company.Location = new System.Drawing.Point(724, 1);
            this.contractor_c_surname_company.MaxLength = 40;
            this.contractor_c_surname_company.Name = "contractor_c_surname_company";
            this.contractor_c_surname_company.Size = new System.Drawing.Size(234, 20);
            this.contractor_c_surname_company.TabIndex = 0;
            // 
            // contractor_c_address
            // 
            this.contractor_c_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_address.Enabled = false;
            this.contractor_c_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_c_address.Location = new System.Drawing.Point(542, 28);
            this.contractor_c_address.MaxLength = 200;
            this.contractor_c_address.Name = "contractor_c_address";
            this.contractor_c_address.Size = new System.Drawing.Size(254, 20);
            this.contractor_c_address.TabIndex = 0;
            // 
            // outlet_o_manager
            // 
            this.outlet_o_manager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OutletOTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_o_manager.Enabled = false;
            this.outlet_o_manager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_o_manager.Location = new System.Drawing.Point(830, 120);
            this.outlet_o_manager.MaxLength = 40;
            this.outlet_o_manager.Name = "outlet_o_manager";
            this.outlet_o_manager.Size = new System.Drawing.Size(234, 20);
            this.outlet_o_manager.TabIndex = 0;
            // 
            // outlet_o_address
            // 
            this.outlet_o_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractRenewalsConExpiryDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_o_address.Enabled = false;
            this.outlet_o_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_o_address.Location = new System.Drawing.Point(461, 120);
            this.outlet_o_address.MaxLength = 200;
            this.outlet_o_address.Name = "outlet_o_address";
            this.outlet_o_address.Size = new System.Drawing.Size(221, 20);
            this.outlet_o_address.TabIndex = 0;
            // 
            // outlet_o_telephone
            // 
            this.outlet_o_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OutletOName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_o_telephone.Enabled = false;
            this.outlet_o_telephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_o_telephone.Location = new System.Drawing.Point(684, 120);
            this.outlet_o_telephone.MaxLength = 11;
            this.outlet_o_telephone.Name = "outlet_o_telephone";
            this.outlet_o_telephone.Size = new System.Drawing.Size(68, 20);
            this.outlet_o_telephone.TabIndex = 0;
            // 
            // outlet_o_fax
            // 
            this.outlet_o_fax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OutletOAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_o_fax.Enabled = false;
            this.outlet_o_fax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_o_fax.Location = new System.Drawing.Point(760, 120);
            this.outlet_o_fax.MaxLength = 11;
            this.outlet_o_fax.Name = "outlet_o_fax";
            this.outlet_o_fax.Size = new System.Drawing.Size(68, 20);
            this.outlet_o_fax.TabIndex = 0;
            // 
            // region_rgn_rcm_manager
            // 
            this.region_rgn_rcm_manager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OutletOManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_rgn_rcm_manager.Enabled = false;
            this.region_rgn_rcm_manager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_rgn_rcm_manager.Location = new System.Drawing.Point(246, 150);
            this.region_rgn_rcm_manager.MaxLength = 40;
            this.region_rgn_rcm_manager.Name = "region_rgn_rcm_manager";
            this.region_rgn_rcm_manager.Size = new System.Drawing.Size(234, 20);
            this.region_rgn_rcm_manager.TabIndex = 0;
            // 
            // region_rgn_fax
            // 
            this.region_rgn_fax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RegionRgnName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_rgn_fax.Enabled = false;
            this.region_rgn_fax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_rgn_fax.Location = new System.Drawing.Point(482, 150);
            this.region_rgn_fax.MaxLength = 11;
            this.region_rgn_fax.Name = "region_rgn_fax";
            this.region_rgn_fax.Size = new System.Drawing.Size(69, 20);
            this.region_rgn_fax.TabIndex = 0;
            // 
            // region_rgn_telephone
            // 
            this.region_rgn_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RegionRgnRcmManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_rgn_telephone.Enabled = false;
            this.region_rgn_telephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_rgn_telephone.Location = new System.Drawing.Point(553, 150);
            this.region_rgn_telephone.MaxLength = 20;
            this.region_rgn_telephone.Name = "region_rgn_telephone";
            this.region_rgn_telephone.Size = new System.Drawing.Size(120, 20);
            this.region_rgn_telephone.TabIndex = 0;
            // 
            // region_rgn_address
            // 
            this.region_rgn_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RegionRgnFax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_rgn_address.Enabled = false;
            this.region_rgn_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_rgn_address.Location = new System.Drawing.Point(684, 150);
            this.region_rgn_address.MaxLength = 200;
            this.region_rgn_address.Name = "region_rgn_address";
            this.region_rgn_address.Size = new System.Drawing.Size(444, 20);
            this.region_rgn_address.TabIndex = 0;
            // 
            // contract_renewals_con_expiry_date
            // 
            this.contract_renewals_con_expiry_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorRenewalsCrEffectiveDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_renewals_con_expiry_date.Enabled = false;
            this.contract_renewals_con_expiry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_renewals_con_expiry_date.Location = new System.Drawing.Point(109, 120);
            this.contract_renewals_con_expiry_date.Name = "contract_renewals_con_expiry_date";
            this.contract_renewals_con_expiry_date.Size = new System.Drawing.Size(69, 20);
            this.contract_renewals_con_expiry_date.TabIndex = 0;
            // 
            // outlet_o_name
            // 
            this.outlet_o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractRenewalsConStartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_o_name.Enabled = false;
            this.outlet_o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_o_name.Location = new System.Drawing.Point(214, 120);
            this.outlet_o_name.MaxLength = 40;
            this.outlet_o_name.Name = "outlet_o_name";
            this.outlet_o_name.Size = new System.Drawing.Size(234, 20);
            this.outlet_o_name.TabIndex = 0;
            // 
            // contract_con_title
            // 
            this.contract_con_title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CTaxRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_con_title.Enabled = false;
            this.contract_con_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_con_title.Location = new System.Drawing.Point(305, 88);
            this.contract_con_title.MaxLength = 60;
            this.contract_con_title.Name = "contract_con_title";
            this.contract_con_title.Size = new System.Drawing.Size(348, 20);
            this.contract_con_title.TabIndex = 0;
            // 
            // contractor_c_tax_rate
            // 
            this.contractor_c_tax_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCTaxRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_tax_rate.Enabled = false;
            this.contractor_c_tax_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_c_tax_rate.Location = new System.Drawing.Point(118, 89);
            this.contractor_c_tax_rate.Name = "contractor_c_tax_rate";
            this.contractor_c_tax_rate.Size = new System.Drawing.Size(89, 20);
            this.contractor_c_tax_rate.TabIndex = 0;
            this.contractor_c_tax_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // contractor_c_ird_no
            // 
            this.contractor_c_ird_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCIrdNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_ird_no.Enabled = false;
            this.contractor_c_ird_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_c_ird_no.Location = new System.Drawing.Point(214, 89);
            this.contractor_c_ird_no.MaxLength = 10;
            this.contractor_c_ird_no.Name = "contractor_c_ird_no";
            this.contractor_c_ird_no.Size = new System.Drawing.Size(82, 20);
            this.contractor_c_ird_no.TabIndex = 0;
            // 
            // contractor_renewals_cr_effective_date
            // 
            this.contractor_renewals_cr_effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorCIrdNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_renewals_cr_effective_date.Enabled = false;
            this.contractor_renewals_cr_effective_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_renewals_cr_effective_date.Location = new System.Drawing.Point(661, 89);
            this.contractor_renewals_cr_effective_date.Name = "contractor_renewals_cr_effective_date";
            this.contractor_renewals_cr_effective_date.Size = new System.Drawing.Size(68, 20);
            this.contractor_renewals_cr_effective_date.TabIndex = 0;
            // 
            // c_phone_day
            // 
            this.c_phone_day.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CPhoneDay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_phone_day.Enabled = false;
            this.c_phone_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_phone_day.Location = new System.Drawing.Point(1, 54);
            this.c_phone_day.MaxLength = 15;
            this.c_phone_day.Name = "c_phone_day";
            this.c_phone_day.Size = new System.Drawing.Size(92, 20);
            this.c_phone_day.TabIndex = 0;
            // 
            // c_phone_night
            // 
            this.c_phone_night.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CPhoneNight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_phone_night.Enabled = false;
            this.c_phone_night.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_phone_night.Location = new System.Drawing.Point(94, 54);
            this.c_phone_night.MaxLength = 15;
            this.c_phone_night.Name = "c_phone_night";
            this.c_phone_night.Size = new System.Drawing.Size(91, 20);
            this.c_phone_night.TabIndex = 0;
            // 
            // c_mobile
            // 
            this.c_mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CMobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_mobile.Enabled = false;
            this.c_mobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_mobile.Location = new System.Drawing.Point(193, 54);
            this.c_mobile.MaxLength = 15;
            this.c_mobile.Name = "c_mobile";
            this.c_mobile.Size = new System.Drawing.Size(91, 20);
            this.c_mobile.TabIndex = 0;
            // 
            // c_mobile2
            // 
            this.c_mobile2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CMobile2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_mobile2.Enabled = false;
            this.c_mobile2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_mobile2.Location = new System.Drawing.Point(291, 54);
            this.c_mobile2.Name = "c_mobile2";
            this.c_mobile2.Size = new System.Drawing.Size(85, 20);
            this.c_mobile2.TabIndex = 0;
            // 
            // primary_contact
            // 
            this.primary_contact.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PrimaryContact", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.primary_contact.Enabled = false;
            this.primary_contact.Font = new System.Drawing.Font("Arial", 8F);
            this.primary_contact.Location = new System.Drawing.Point(382, 54);
            this.primary_contact.Name = "primary_contact";
            this.primary_contact.Size = new System.Drawing.Size(85, 20);
            this.primary_contact.TabIndex = 0;
            // 
            // c_email_address
            // 
            this.c_email_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CEmailAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_email_address.Enabled = false;
            this.c_email_address.Font = new System.Drawing.Font("Arial", 8F);
            this.c_email_address.Location = new System.Drawing.Point(478, 54);
            this.c_email_address.Name = "c_email_address";
            this.c_email_address.Size = new System.Drawing.Size(229, 20);
            this.c_email_address.TabIndex = 0;
            // 
            // contractor_c_bank_account_no
            // 
            this.contractor_c_bank_account_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CMobile2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_c_bank_account_no.Enabled = false;
            this.contractor_c_bank_account_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_c_bank_account_no.Location = new System.Drawing.Point(1, 89);
            this.contractor_c_bank_account_no.MaxLength = 18;
            this.contractor_c_bank_account_no.Name = "contractor_c_bank_account_no";
            this.contractor_c_bank_account_no.Size = new System.Drawing.Size(108, 20);
            this.contractor_c_bank_account_no.TabIndex = 0;
            // 
            // contract_renewals_con_start_date
            // 
            this.contract_renewals_con_start_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractConTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_renewals_con_start_date.Enabled = false;
            this.contract_renewals_con_start_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_renewals_con_start_date.Location = new System.Drawing.Point(1, 120);
            this.contract_renewals_con_start_date.Name = "contract_renewals_con_start_date";
            this.contract_renewals_con_start_date.Size = new System.Drawing.Size(68, 20);
            this.contract_renewals_con_start_date.TabIndex = 0;
            // 
            // region_rgn_name
            // 
            this.region_rgn_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OutletOFax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_rgn_name.Enabled = false;
            this.region_rgn_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_rgn_name.Location = new System.Drawing.Point(1, 150);
            this.region_rgn_name.MaxLength = 40;
            this.region_rgn_name.Name = "region_rgn_name";
            this.region_rgn_name.Size = new System.Drawing.Size(234, 20);
            this.region_rgn_name.TabIndex = 0;
            // 
            // driver_name
            // 
            this.driver_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DriverName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.driver_name.Enabled = false;
            this.driver_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.driver_name.Location = new System.Drawing.Point(1, 28);
            this.driver_name.MaxLength = 92;
            this.driver_name.Name = "driver_name";
            this.driver_name.Size = new System.Drawing.Size(531, 20);
            this.driver_name.TabIndex = 0;
            // 
            // contractor_contractor_supplier_no
            // 
            this.contractor_contractor_supplier_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorContractorSupplierNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_contractor_supplier_no.Enabled = false;
            this.contractor_contractor_supplier_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_contractor_supplier_no.Location = new System.Drawing.Point(1, 1);
            this.contractor_contractor_supplier_no.Name = "contractor_contractor_supplier_no";
            this.contractor_contractor_supplier_no.Size = new System.Drawing.Size(68, 20);
            this.contractor_contractor_supplier_no.TabIndex = 0;
            this.contractor_contractor_supplier_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DMailmergeOdDownloadData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cc_salutation);
            this.Controls.Add(this.contract_contract_no);
            this.Controls.Add(this.contractor_c_title);
            this.Controls.Add(this.contractor_c_salutation);
            this.Controls.Add(this.contractor_c_initials);
            this.Controls.Add(this.contractor_c_first_names);
            this.Controls.Add(this.contractor_c_surname_company);
            this.Controls.Add(this.contractor_c_address);
            this.Controls.Add(this.outlet_o_manager);
            this.Controls.Add(this.outlet_o_address);
            this.Controls.Add(this.outlet_o_telephone);
            this.Controls.Add(this.outlet_o_fax);
            this.Controls.Add(this.region_rgn_rcm_manager);
            this.Controls.Add(this.region_rgn_fax);
            this.Controls.Add(this.region_rgn_telephone);
            this.Controls.Add(this.region_rgn_address);
            this.Controls.Add(this.contract_renewals_con_expiry_date);
            this.Controls.Add(this.outlet_o_name);
            this.Controls.Add(this.contract_con_title);
            this.Controls.Add(this.contractor_c_tax_rate);
            this.Controls.Add(this.contractor_c_ird_no);
            this.Controls.Add(this.contractor_renewals_cr_effective_date);
            this.Controls.Add(this.c_phone_day);
            this.Controls.Add(this.c_phone_night);
            this.Controls.Add(this.c_mobile);
            this.Controls.Add(this.c_mobile2);
            this.Controls.Add(this.primary_contact);
            this.Controls.Add(this.c_email_address);
            this.Controls.Add(this.contractor_c_bank_account_no);
            this.Controls.Add(this.contract_renewals_con_start_date);
            this.Controls.Add(this.region_rgn_name);
            this.Controls.Add(this.driver_name);
            this.Controls.Add(this.contractor_contractor_supplier_no);
            this.Name = "DMailmergeOdDownloadData";
            this.Size = new System.Drawing.Size(1914, 231);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cc_salutation;
        private System.Windows.Forms.TextBox contract_contract_no;
        private System.Windows.Forms.TextBox contractor_c_title;
        private System.Windows.Forms.TextBox contractor_c_salutation;
        private System.Windows.Forms.TextBox contractor_c_initials;
        private System.Windows.Forms.TextBox contractor_c_first_names;
        private System.Windows.Forms.TextBox contractor_c_surname_company;
        private System.Windows.Forms.TextBox contractor_c_address;
        private System.Windows.Forms.TextBox outlet_o_manager;
        private System.Windows.Forms.TextBox outlet_o_address;
        private System.Windows.Forms.TextBox outlet_o_telephone;
        private System.Windows.Forms.TextBox outlet_o_fax;
        private System.Windows.Forms.TextBox region_rgn_rcm_manager;
        private System.Windows.Forms.TextBox region_rgn_fax;
        private System.Windows.Forms.TextBox region_rgn_telephone;
        private System.Windows.Forms.TextBox region_rgn_address;
        private System.Windows.Forms.TextBox contract_renewals_con_expiry_date;
        private System.Windows.Forms.TextBox outlet_o_name;
        private System.Windows.Forms.TextBox contract_con_title;
        private System.Windows.Forms.TextBox contractor_c_tax_rate;
        private System.Windows.Forms.TextBox contractor_c_ird_no;
        private System.Windows.Forms.TextBox contractor_renewals_cr_effective_date;
        private System.Windows.Forms.TextBox c_phone_day;
        private System.Windows.Forms.TextBox c_phone_night;
        private System.Windows.Forms.TextBox c_mobile;
        private System.Windows.Forms.TextBox c_mobile2;
        private System.Windows.Forms.TextBox primary_contact;
        private System.Windows.Forms.TextBox c_email_address;
        private System.Windows.Forms.TextBox contractor_c_bank_account_no;
        private System.Windows.Forms.TextBox contract_renewals_con_start_date;
        private System.Windows.Forms.TextBox region_rgn_name;
        private System.Windows.Forms.TextBox driver_name;
        private System.Windows.Forms.TextBox contractor_contractor_supplier_no;
    }
}
