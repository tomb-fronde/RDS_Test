using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractorFull
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
            this.gb_detail = new System.Windows.Forms.GroupBox();
            this.nz_post_employee = new System.Windows.Forms.CheckBox();
            this.nz_post_employee_t = new System.Windows.Forms.Label();
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.c_surname_company_t = new System.Windows.Forms.Label();
            this.c_surname_company = new System.Windows.Forms.TextBox();
            this.c_first_names_t = new System.Windows.Forms.Label();
            this.c_first_names = new System.Windows.Forms.TextBox();
            this.c_initials_t = new System.Windows.Forms.Label();
            this.c_initials = new System.Windows.Forms.TextBox();
            this.c_salutation_t = new System.Windows.Forms.Label();
            this.c_salutation = new System.Windows.Forms.RichTextBox();
            this.c_address_t = new System.Windows.Forms.Label();
            this.c_address = new System.Windows.Forms.RichTextBox();
            this.contractor_supplier_no_t = new System.Windows.Forms.Label();
            this.contractor_supplier_no = new System.Windows.Forms.TextBox();
            this.c_title_t = new System.Windows.Forms.Label();
            this.c_title = new System.Windows.Forms.TextBox();
            this.gb_2 = new System.Windows.Forms.GroupBox();
            this.c_prime_contact_3 = new System.Windows.Forms.RadioButton();
            this.c_prime_contact_2 = new System.Windows.Forms.RadioButton();
            this.c_prime_contact_1 = new System.Windows.Forms.RadioButton();
            this.c_phone_day_t = new System.Windows.Forms.Label();
            this.c_phone_night_t = new System.Windows.Forms.Label();
            this.c_mobile_t = new System.Windows.Forms.Label();
            this.c_mobile2_t = new System.Windows.Forms.Label();
            this.c_primary_contact_t = new System.Windows.Forms.Label();
            this.c_phone_day = new System.Windows.Forms.MaskedTextBox();
            this.c_phone_night = new System.Windows.Forms.MaskedTextBox();
            this.c_mobile = new System.Windows.Forms.MaskedTextBox();
            this.c_mobile2 = new System.Windows.Forms.MaskedTextBox();
            this.c_notes = new System.Windows.Forms.TextBox();
            this.c_bank_account_no_t = new System.Windows.Forms.Label();
            this.c_bank_account_no = new System.Windows.Forms.MaskedTextBox();
            this.c_ird_no_t = new System.Windows.Forms.Label();
            this.c_ird_no = new System.Windows.Forms.MaskedTextBox();
            this.c_gst_number_t = new System.Windows.Forms.Label();
            this.c_gst_number = new System.Windows.Forms.MaskedTextBox();
            this.c_tax_rate_t = new System.Windows.Forms.Label();
            this.c_tax_rate = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.c_witholding_tax_certificate_t = new System.Windows.Forms.Label();
            this.c_witholding_tax_certificate = new Metex.Windows.DataEntityCombo();
            this.c_tpid_number_t = new System.Windows.Forms.Label();
            this.c_tpid_number = new System.Windows.Forms.TextBox();
            this.gb_notes = new System.Windows.Forms.GroupBox();
            this.gb_pay = new System.Windows.Forms.GroupBox();
            this.c_email_address_t = new System.Windows.Forms.Label();
            this.c_email_address = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractorFull);
            // 
            // gb_detail
            // 
            this.gb_detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_detail.Location = new System.Drawing.Point(6, 9);
            this.gb_detail.Name = "gb_detail";
            this.gb_detail.Size = new System.Drawing.Size(318, 280);
            this.gb_detail.TabIndex = 0;
            this.gb_detail.TabStop = false;
            this.gb_detail.Text = "None";
            this.gb_detail.Visible = false;
            // 
            // nz_post_employee
            // 
            this.nz_post_employee.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "NzPostEmployeeChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nz_post_employee.Font = new System.Drawing.Font("Arial", 8F);
            this.nz_post_employee.Location = new System.Drawing.Point(113, 188);
            this.nz_post_employee.Name = "nz_post_employee";
            this.nz_post_employee.Size = new System.Drawing.Size(13, 13);
            this.nz_post_employee.TabIndex = 72;
            this.nz_post_employee.ThreeState = true;
            // 
            // nz_post_employee_t
            // 
            this.nz_post_employee_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nz_post_employee_t.Location = new System.Drawing.Point(8, 188);
            this.nz_post_employee_t.Name = "nz_post_employee_t";
            this.nz_post_employee_t.Size = new System.Drawing.Size(96, 13);
            this.nz_post_employee_t.TabIndex = 150;
            this.nz_post_employee_t.Text = "NZ Post Employee";
            this.nz_post_employee_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_1
            // 
            this.gb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_1.Location = new System.Drawing.Point(5, 5);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(281, 199);
            this.gb_1.TabIndex = 1;
            this.gb_1.TabStop = false;
            // 
            // c_surname_company_t
            // 
            this.c_surname_company_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_surname_company_t.Location = new System.Drawing.Point(6, 36);
            this.c_surname_company_t.Name = "c_surname_company_t";
            this.c_surname_company_t.Size = new System.Drawing.Size(99, 13);
            this.c_surname_company_t.TabIndex = 66;
            this.c_surname_company_t.Text = "Surname/Company";
            // 
            // c_surname_company
            // 
            this.c_surname_company.BackColor = System.Drawing.Color.Aqua;
            this.c_surname_company.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CSurnameCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_surname_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_surname_company.Location = new System.Drawing.Point(105, 33);
            this.c_surname_company.MaxLength = 40;
            this.c_surname_company.Name = "c_surname_company";
            this.c_surname_company.Size = new System.Drawing.Size(174, 20);
            this.c_surname_company.TabIndex = 2;
            // 
            // c_first_names_t
            // 
            this.c_first_names_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_first_names_t.Location = new System.Drawing.Point(20, 55);
            this.c_first_names_t.Name = "c_first_names_t";
            this.c_first_names_t.Size = new System.Drawing.Size(84, 13);
            this.c_first_names_t.TabIndex = 67;
            this.c_first_names_t.Text = "First Names";
            this.c_first_names_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_first_names
            // 
            this.c_first_names.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CFirstNames", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_first_names.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_first_names.Location = new System.Drawing.Point(105, 52);
            this.c_first_names.MaxLength = 40;
            this.c_first_names.Name = "c_first_names";
            this.c_first_names.Size = new System.Drawing.Size(174, 20);
            this.c_first_names.TabIndex = 3;
            // 
            // c_initials_t
            // 
            this.c_initials_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_initials_t.Location = new System.Drawing.Point(20, 75);
            this.c_initials_t.Name = "c_initials_t";
            this.c_initials_t.Size = new System.Drawing.Size(84, 13);
            this.c_initials_t.TabIndex = 68;
            this.c_initials_t.Text = "Initials";
            this.c_initials_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_initials
            // 
            this.c_initials.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CInitials", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_initials.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_initials.Location = new System.Drawing.Point(105, 72);
            this.c_initials.MaxLength = 10;
            this.c_initials.Name = "c_initials";
            this.c_initials.Size = new System.Drawing.Size(70, 20);
            this.c_initials.TabIndex = 4;
            // 
            // c_salutation_t
            // 
            this.c_salutation_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_salutation_t.Location = new System.Drawing.Point(20, 93);
            this.c_salutation_t.Name = "c_salutation_t";
            this.c_salutation_t.Size = new System.Drawing.Size(84, 13);
            this.c_salutation_t.TabIndex = 69;
            this.c_salutation_t.Text = "Salutation";
            this.c_salutation_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_salutation
            // 
            this.c_salutation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CSalutation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_salutation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_salutation.Location = new System.Drawing.Point(105, 95);
            this.c_salutation.MaxLength = 40;
            this.c_salutation.Name = "c_salutation";
            this.c_salutation.Size = new System.Drawing.Size(174, 29);
            this.c_salutation.TabIndex = 5;
            this.c_salutation.Text = "";
            // 
            // c_address_t
            // 
            this.c_address_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_address_t.Location = new System.Drawing.Point(10, 128);
            this.c_address_t.Name = "c_address_t";
            this.c_address_t.Size = new System.Drawing.Size(94, 13);
            this.c_address_t.TabIndex = 70;
            this.c_address_t.Text = "Address";
            this.c_address_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_address
            // 
            this.c_address.BackColor = System.Drawing.Color.Aqua;
            this.c_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_address.Location = new System.Drawing.Point(105, 125);
            this.c_address.MaxLength = 200;
            this.c_address.Name = "c_address";
            this.c_address.Size = new System.Drawing.Size(174, 57);
            this.c_address.TabIndex = 6;
            this.c_address.Text = "";
            // 
            // contractor_supplier_no_t
            // 
            this.contractor_supplier_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_supplier_no_t.Location = new System.Drawing.Point(10, 18);
            this.contractor_supplier_no_t.Name = "contractor_supplier_no_t";
            this.contractor_supplier_no_t.Size = new System.Drawing.Size(94, 13);
            this.contractor_supplier_no_t.TabIndex = 71;
            this.contractor_supplier_no_t.Text = "Supplier No";
            this.contractor_supplier_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contractor_supplier_no
            // 
            this.contractor_supplier_no.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contractor_supplier_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contractor_supplier_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractorSupplierNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contractor_supplier_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contractor_supplier_no.Location = new System.Drawing.Point(105, 17);
            this.contractor_supplier_no.Name = "contractor_supplier_no";
            this.contractor_supplier_no.ReadOnly = true;
            this.contractor_supplier_no.Size = new System.Drawing.Size(60, 13);
            this.contractor_supplier_no.TabIndex = 72;
            this.contractor_supplier_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // c_title_t
            // 
            this.c_title_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_title_t.Location = new System.Drawing.Point(171, 17);
            this.c_title_t.Name = "c_title_t";
            this.c_title_t.Size = new System.Drawing.Size(30, 13);
            this.c_title_t.TabIndex = 73;
            this.c_title_t.Text = "Title";
            this.c_title_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_title
            // 
            this.c_title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_title.Location = new System.Drawing.Point(206, 13);
            this.c_title.MaxLength = 10;
            this.c_title.Name = "c_title";
            this.c_title.Size = new System.Drawing.Size(55, 20);
            this.c_title.TabIndex = 1;
            // 
            // gb_2
            // 
            this.gb_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_2.Location = new System.Drawing.Point(294, 5);
            this.gb_2.Name = "gb_2";
            this.gb_2.Size = new System.Drawing.Size(212, 125);
            this.gb_2.TabIndex = 9;
            this.gb_2.TabStop = false;
            this.gb_2.Text = "Phones";
            // 
            // c_prime_contact_3
            // 
            this.c_prime_contact_3.AutoSize = true;
            this.c_prime_contact_3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CPrimeContact3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_prime_contact_3.Location = new System.Drawing.Point(475, 68);
            this.c_prime_contact_3.Name = "c_prime_contact_3";
            this.c_prime_contact_3.Size = new System.Drawing.Size(14, 13);
            this.c_prime_contact_3.TabIndex = 151;
            this.c_prime_contact_3.TabStop = true;
            this.c_prime_contact_3.UseVisualStyleBackColor = true;
            this.c_prime_contact_3.Click += new System.EventHandler(this.c_prime_contact_3_CheckedChanged);
            // 
            // c_prime_contact_2
            // 
            this.c_prime_contact_2.AutoSize = true;
            this.c_prime_contact_2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CPrimeContact2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_prime_contact_2.Location = new System.Drawing.Point(475, 48);
            this.c_prime_contact_2.Name = "c_prime_contact_2";
            this.c_prime_contact_2.Size = new System.Drawing.Size(14, 13);
            this.c_prime_contact_2.TabIndex = 152;
            this.c_prime_contact_2.TabStop = true;
            this.c_prime_contact_2.UseVisualStyleBackColor = true;
            this.c_prime_contact_2.Click += new System.EventHandler(this.c_prime_contact_2_CheckedChanged);
            // 
            // c_prime_contact_1
            // 
            this.c_prime_contact_1.AutoSize = true;
            this.c_prime_contact_1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CPrimeContact1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_prime_contact_1.Location = new System.Drawing.Point(475, 28);
            this.c_prime_contact_1.Name = "c_prime_contact_1";
            this.c_prime_contact_1.Size = new System.Drawing.Size(14, 13);
            this.c_prime_contact_1.TabIndex = 40;
            this.c_prime_contact_1.TabStop = true;
            this.c_prime_contact_1.UseVisualStyleBackColor = true;
            this.c_prime_contact_1.Click += new System.EventHandler(this.c_prime_contact_1_CheckedChanged);
            // 
            // c_phone_day_t
            // 
            this.c_phone_day_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_phone_day_t.Location = new System.Drawing.Point(304, 28);
            this.c_phone_day_t.Name = "c_phone_day_t";
            this.c_phone_day_t.Size = new System.Drawing.Size(60, 13);
            this.c_phone_day_t.TabIndex = 153;
            this.c_phone_day_t.Text = "Day Phone";
            this.c_phone_day_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_phone_night_t
            // 
            this.c_phone_night_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_phone_night_t.Location = new System.Drawing.Point(304, 47);
            this.c_phone_night_t.Name = "c_phone_night_t";
            this.c_phone_night_t.Size = new System.Drawing.Size(60, 13);
            this.c_phone_night_t.TabIndex = 154;
            this.c_phone_night_t.Text = "After Hours";
            this.c_phone_night_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_mobile_t
            // 
            this.c_mobile_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_mobile_t.Location = new System.Drawing.Point(304, 66);
            this.c_mobile_t.Name = "c_mobile_t";
            this.c_mobile_t.Size = new System.Drawing.Size(60, 13);
            this.c_mobile_t.TabIndex = 155;
            this.c_mobile_t.Text = "Mobile";
            this.c_mobile_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_mobile2_t
            // 
            this.c_mobile2_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_mobile2_t.Location = new System.Drawing.Point(304, 85);
            this.c_mobile2_t.Name = "c_mobile2_t";
            this.c_mobile2_t.Size = new System.Drawing.Size(60, 13);
            this.c_mobile2_t.TabIndex = 156;
            this.c_mobile2_t.Text = "Mobile2";
            this.c_mobile2_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_primary_contact_t
            // 
            this.c_primary_contact_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.c_primary_contact_t.Location = new System.Drawing.Point(457, 12);
            this.c_primary_contact_t.Name = "c_primary_contact_t";
            this.c_primary_contact_t.Size = new System.Drawing.Size(43, 13);
            this.c_primary_contact_t.TabIndex = 157;
            this.c_primary_contact_t.Text = "Primary";
            this.c_primary_contact_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_phone_day
            // 
            this.c_phone_day.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.c_phone_day.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CPhoneDay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_phone_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_phone_day.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.c_phone_day.Location = new System.Drawing.Point(373, 25);
            this.c_phone_day.Mask = "(##) ###-######";
            this.c_phone_day.Name = "c_phone_day";
            this.c_phone_day.PromptChar = ' ';
            this.c_phone_day.Size = new System.Drawing.Size(97, 20);
            this.c_phone_day.TabIndex = 10;
            this.c_phone_day.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // c_phone_night
            // 
            this.c_phone_night.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.c_phone_night.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CPhoneNight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_phone_night.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_phone_night.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.c_phone_night.Location = new System.Drawing.Point(373, 45);
            this.c_phone_night.Mask = "(##) ###-######";
            this.c_phone_night.Name = "c_phone_night";
            this.c_phone_night.PromptChar = ' ';
            this.c_phone_night.Size = new System.Drawing.Size(97, 20);
            this.c_phone_night.TabIndex = 11;
            this.c_phone_night.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // c_mobile
            // 
            this.c_mobile.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.c_mobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CMobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_mobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_mobile.Location = new System.Drawing.Point(373, 65);
            this.c_mobile.Mask = "(###) ###-#####";
            this.c_mobile.Name = "c_mobile";
            this.c_mobile.PromptChar = ' ';
            this.c_mobile.Size = new System.Drawing.Size(97, 20);
            this.c_mobile.TabIndex = 12;
            this.c_mobile.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // c_mobile2
            // 
            this.c_mobile2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.c_mobile2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CMobile2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_mobile2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_mobile2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.c_mobile2.Location = new System.Drawing.Point(373, 85);
            this.c_mobile2.Mask = "(###) ###-#####";
            this.c_mobile2.Name = "c_mobile2";
            this.c_mobile2.PromptChar = ' ';
            this.c_mobile2.Size = new System.Drawing.Size(97, 20);
            this.c_mobile2.TabIndex = 13;
            this.c_mobile2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // c_notes
            // 
            this.c_notes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CNotes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_notes.Location = new System.Drawing.Point(45, 223);
            this.c_notes.Multiline = true;
            this.c_notes.Name = "c_notes";
            this.c_notes.Size = new System.Drawing.Size(234, 47);
            this.c_notes.TabIndex = 8;
            // 
            // c_bank_account_no_t
            // 
            this.c_bank_account_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_bank_account_no_t.Location = new System.Drawing.Point(296, 150);
            this.c_bank_account_no_t.Name = "c_bank_account_no_t";
            this.c_bank_account_no_t.Size = new System.Drawing.Size(70, 13);
            this.c_bank_account_no_t.TabIndex = 74;
            this.c_bank_account_no_t.Text = " Bank Act";
            this.c_bank_account_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_bank_account_no
            // 
            this.c_bank_account_no.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.c_bank_account_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CBankAccountNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_bank_account_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_bank_account_no.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.c_bank_account_no.Location = new System.Drawing.Point(373, 148);
            this.c_bank_account_no.Mask = "000000  0000000 00#";
            this.c_bank_account_no.Name = "c_bank_account_no";
            this.c_bank_account_no.PromptChar = ' ';
            this.c_bank_account_no.Size = new System.Drawing.Size(127, 20);
            this.c_bank_account_no.TabIndex = 15;
            this.c_bank_account_no.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // c_ird_no_t
            // 
            this.c_ird_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_ird_no_t.Location = new System.Drawing.Point(296, 171);
            this.c_ird_no_t.Name = "c_ird_no_t";
            this.c_ird_no_t.Size = new System.Drawing.Size(70, 13);
            this.c_ird_no_t.TabIndex = 75;
            this.c_ird_no_t.Text = "IRD No";
            this.c_ird_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_ird_no
            // 
            this.c_ird_no.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.c_ird_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CIrdNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_ird_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_ird_no.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.c_ird_no.Location = new System.Drawing.Point(373, 169);
            this.c_ird_no.Mask = "000-000-00#";
            this.c_ird_no.Name = "c_ird_no";
            this.c_ird_no.PromptChar = ' ';
            this.c_ird_no.Size = new System.Drawing.Size(92, 20);
            this.c_ird_no.TabIndex = 16;
            this.c_ird_no.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // c_gst_number_t
            // 
            this.c_gst_number_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_gst_number_t.Location = new System.Drawing.Point(296, 191);
            this.c_gst_number_t.Name = "c_gst_number_t";
            this.c_gst_number_t.Size = new System.Drawing.Size(70, 13);
            this.c_gst_number_t.TabIndex = 76;
            this.c_gst_number_t.Text = "GST No";
            this.c_gst_number_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_gst_number
            // 
            this.c_gst_number.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.c_gst_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CGstNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_gst_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_gst_number.HidePromptOnLeave = true;
            this.c_gst_number.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.c_gst_number.Location = new System.Drawing.Point(373, 189);
            this.c_gst_number.Mask = "###-###-###";
            this.c_gst_number.Name = "c_gst_number";
            this.c_gst_number.PromptChar = ' ';
            this.c_gst_number.Size = new System.Drawing.Size(92, 20);
            this.c_gst_number.TabIndex = 17;
            this.c_gst_number.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // c_tax_rate_t
            // 
            this.c_tax_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_tax_rate_t.Location = new System.Drawing.Point(296, 211);
            this.c_tax_rate_t.Name = "c_tax_rate_t";
            this.c_tax_rate_t.Size = new System.Drawing.Size(70, 13);
            this.c_tax_rate_t.TabIndex = 77;
            this.c_tax_rate_t.Text = "Tax Rate";
            this.c_tax_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_tax_rate
            // 
            this.c_tax_rate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CTaxRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_tax_rate.EditMask = "#0.00";
            this.c_tax_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_tax_rate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.c_tax_rate.Location = new System.Drawing.Point(373, 209);
            this.c_tax_rate.Name = "c_tax_rate";
            this.c_tax_rate.PromptChar = ' ';
            this.c_tax_rate.Size = new System.Drawing.Size(92, 20);
            this.c_tax_rate.TabIndex = 18;
            this.c_tax_rate.Text = "0.00";
            this.c_tax_rate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.c_tax_rate.Value = "0.00";
            // 
            // c_witholding_tax_certificate_t
            // 
            this.c_witholding_tax_certificate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_witholding_tax_certificate_t.Location = new System.Drawing.Point(296, 231);
            this.c_witholding_tax_certificate_t.Name = "c_witholding_tax_certificate_t";
            this.c_witholding_tax_certificate_t.Size = new System.Drawing.Size(75, 13);
            this.c_witholding_tax_certificate_t.TabIndex = 78;
            this.c_witholding_tax_certificate_t.Text = "Tax Certificate";
            // 
            // c_witholding_tax_certificate
            // 
            this.c_witholding_tax_certificate.AutoRetrieve = false;
            this.c_witholding_tax_certificate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CWitholdingTaxCertificate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_witholding_tax_certificate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_witholding_tax_certificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_witholding_tax_certificate.Location = new System.Drawing.Point(373, 229);
            this.c_witholding_tax_certificate.Name = "c_witholding_tax_certificate";
            this.c_witholding_tax_certificate.Size = new System.Drawing.Size(92, 21);
            this.c_witholding_tax_certificate.TabIndex = 19;
            this.c_witholding_tax_certificate.Value = null;
            // 
            // c_tpid_number_t
            // 
            this.c_tpid_number_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_tpid_number_t.Location = new System.Drawing.Point(296, 251);
            this.c_tpid_number_t.Name = "c_tpid_number_t";
            this.c_tpid_number_t.Size = new System.Drawing.Size(75, 13);
            this.c_tpid_number_t.TabIndex = 79;
            this.c_tpid_number_t.Text = "TP ID Number";
            // 
            // c_tpid_number
            // 
            this.c_tpid_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CTpidNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_tpid_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_tpid_number.Location = new System.Drawing.Point(373, 249);
            this.c_tpid_number.Name = "c_tpid_number";
            this.c_tpid_number.Size = new System.Drawing.Size(92, 20);
            this.c_tpid_number.TabIndex = 20;
            // 
            // gb_notes
            // 
            this.gb_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_notes.Location = new System.Drawing.Point(5, 207);
            this.gb_notes.Name = "gb_notes";
            this.gb_notes.Size = new System.Drawing.Size(281, 68);
            this.gb_notes.TabIndex = 7;
            this.gb_notes.TabStop = false;
            this.gb_notes.Text = "Notes";
            // 
            // gb_pay
            // 
            this.gb_pay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_pay.Location = new System.Drawing.Point(295, 133);
            this.gb_pay.Name = "gb_pay";
            this.gb_pay.Size = new System.Drawing.Size(211, 142);
            this.gb_pay.TabIndex = 100;
            this.gb_pay.TabStop = false;
            this.gb_pay.Text = "Pay-Related";
            // 
            // c_email_address_t
            // 
            this.c_email_address_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_email_address_t.Location = new System.Drawing.Point(295, 111);
            this.c_email_address_t.Name = "c_email_address_t";
            this.c_email_address_t.Size = new System.Drawing.Size(33, 13);
            this.c_email_address_t.TabIndex = 80;
            this.c_email_address_t.Text = "Email";
            this.c_email_address_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_email_address
            // 
            this.c_email_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CEmailAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_email_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.c_email_address.Location = new System.Drawing.Point(333, 105);
            this.c_email_address.MaxLength = 40;
            this.c_email_address.Name = "c_email_address";
            this.c_email_address.Size = new System.Drawing.Size(167, 20);
            this.c_email_address.TabIndex = 14;
            this.c_email_address.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // DContractorFull
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.c_surname_company_t);
            this.Controls.Add(this.c_surname_company);
            this.Controls.Add(this.c_first_names_t);
            this.Controls.Add(this.c_first_names);
            this.Controls.Add(this.c_initials_t);
            this.Controls.Add(this.c_initials);
            this.Controls.Add(this.c_salutation_t);
            this.Controls.Add(this.c_salutation);
            this.Controls.Add(this.c_address_t);
            this.Controls.Add(this.c_address);
            this.Controls.Add(this.contractor_supplier_no_t);
            this.Controls.Add(this.contractor_supplier_no);
            this.Controls.Add(this.c_title_t);
            this.Controls.Add(this.c_title);
            this.Controls.Add(this.c_notes);
            this.Controls.Add(this.c_bank_account_no_t);
            this.Controls.Add(this.c_bank_account_no);
            this.Controls.Add(this.c_ird_no_t);
            this.Controls.Add(this.c_ird_no);
            this.Controls.Add(this.c_gst_number_t);
            this.Controls.Add(this.c_gst_number);
            this.Controls.Add(this.c_tax_rate_t);
            this.Controls.Add(this.c_tax_rate);
            this.Controls.Add(this.c_witholding_tax_certificate_t);
            this.Controls.Add(this.c_witholding_tax_certificate);
            this.Controls.Add(this.c_tpid_number_t);
            this.Controls.Add(this.c_tpid_number);
            this.Controls.Add(this.c_email_address_t);
            this.Controls.Add(this.c_email_address);
            this.Controls.Add(this.nz_post_employee);
            this.Controls.Add(this.nz_post_employee_t);
            this.Controls.Add(this.c_prime_contact_3);
            this.Controls.Add(this.c_prime_contact_2);
            this.Controls.Add(this.c_prime_contact_1);
            this.Controls.Add(this.c_phone_day_t);
            this.Controls.Add(this.c_phone_night_t);
            this.Controls.Add(this.c_mobile_t);
            this.Controls.Add(this.c_mobile2_t);
            this.Controls.Add(this.c_primary_contact_t);
            this.Controls.Add(this.c_phone_day);
            this.Controls.Add(this.c_phone_night);
            this.Controls.Add(this.c_mobile);
            this.Controls.Add(this.c_mobile2);
            this.Controls.Add(this.gb_1);
            this.Controls.Add(this.gb_2);
            this.Controls.Add(this.gb_notes);
            this.Controls.Add(this.gb_pay);
            this.Controls.Add(this.gb_detail);
            this.Name = "DContractorFull";
            this.Size = new System.Drawing.Size(660, 344);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void c_prime_contact_1_CheckedChanged(object sender, System.EventArgs e)
        {
            this.GetItem<ContractorFull>(this.GetRow()).CPrimeContact = 1;
            this.bindingSource.CurrencyManager.Refresh();
            this.OnItemChanged(this.c_prime_contact_1, new System.EventArgs());
        }

        void c_prime_contact_2_CheckedChanged(object sender, System.EventArgs e)
        {
            this.GetItem<ContractorFull>(this.GetRow()).CPrimeContact = 2;
            this.bindingSource.CurrencyManager.Refresh();
            this.OnItemChanged(this.c_prime_contact_2, new System.EventArgs());
        }

        void c_prime_contact_3_CheckedChanged(object sender, System.EventArgs e)
        {
            this.GetItem<ContractorFull>(this.GetRow()).CPrimeContact = 3;
            this.bindingSource.CurrencyManager.Refresh();
            this.OnItemChanged(this.c_prime_contact_3, new System.EventArgs());
        }

        #endregion

        private System.Windows.Forms.GroupBox gb_detail;
        private System.Windows.Forms.GroupBox gb_2;
        private System.Windows.Forms.TextBox c_notes;
        private System.Windows.Forms.Label c_bank_account_no_t;
        private System.Windows.Forms.MaskedTextBox c_bank_account_no;
        private System.Windows.Forms.Label c_ird_no_t;
        private System.Windows.Forms.MaskedTextBox c_ird_no;
        private System.Windows.Forms.Label c_gst_number_t;
        private System.Windows.Forms.MaskedTextBox c_gst_number;
        private System.Windows.Forms.Label c_tax_rate_t;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox c_tax_rate;
        private System.Windows.Forms.Label c_witholding_tax_certificate_t;
        private Metex.Windows.DataEntityCombo c_witholding_tax_certificate;
        private System.Windows.Forms.Label c_tpid_number_t;
        private System.Windows.Forms.TextBox c_tpid_number;
        private System.Windows.Forms.GroupBox gb_notes;
        private System.Windows.Forms.GroupBox gb_pay;
        private System.Windows.Forms.Label c_email_address_t;
        private System.Windows.Forms.TextBox c_email_address;
        private System.Windows.Forms.Label c_phone_day_t;
        private System.Windows.Forms.Label c_phone_night_t;
        private System.Windows.Forms.Label c_mobile_t;
        private System.Windows.Forms.Label c_mobile2_t;
        private System.Windows.Forms.Label c_primary_contact_t;
        private System.Windows.Forms.MaskedTextBox c_phone_day;
        private System.Windows.Forms.MaskedTextBox c_phone_night;
        private System.Windows.Forms.MaskedTextBox c_mobile;
        private System.Windows.Forms.MaskedTextBox c_mobile2;
        private System.Windows.Forms.CheckBox nz_post_employee;
        private System.Windows.Forms.Label nz_post_employee_t;
        private System.Windows.Forms.GroupBox gb_1;
        private System.Windows.Forms.Label c_surname_company_t;
        private System.Windows.Forms.TextBox c_surname_company;
        private System.Windows.Forms.Label c_first_names_t;
        private System.Windows.Forms.TextBox c_first_names;
        private System.Windows.Forms.Label c_initials_t;
        private System.Windows.Forms.TextBox c_initials;
        private System.Windows.Forms.Label c_salutation_t;
        private System.Windows.Forms.RichTextBox c_salutation;
        private System.Windows.Forms.Label c_address_t;
        private System.Windows.Forms.RichTextBox c_address;
        private System.Windows.Forms.Label contractor_supplier_no_t;
        private System.Windows.Forms.TextBox contractor_supplier_no;
        private System.Windows.Forms.Label c_title_t;
        private System.Windows.Forms.TextBox c_title;
        private System.Windows.Forms.RadioButton c_prime_contact_3;
        private System.Windows.Forms.RadioButton c_prime_contact_2;
        private System.Windows.Forms.RadioButton c_prime_contact_1;
    }
}
