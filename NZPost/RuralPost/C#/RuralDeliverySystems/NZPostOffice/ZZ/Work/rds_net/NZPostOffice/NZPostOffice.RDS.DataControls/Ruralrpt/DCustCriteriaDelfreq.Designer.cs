namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DCustCriteriaDelfreq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCustCriteriaDelfreq));
            this.st_report = new System.Windows.Forms.Label();
            this.n_45713421 = new System.Windows.Forms.Label();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.outlet_picklist = new System.Windows.Forms.CheckBox();
            this.random_number = new System.Windows.Forms.TextBox();
            this.st_recipient = new System.Windows.Forms.Label();
            this.use_printedon = new System.Windows.Forms.CheckBox();
            this.n_8767611 = new System.Windows.Forms.Label();
            this.region_id_t = new System.Windows.Forms.Label();
            this.outlet_id_t = new System.Windows.Forms.Label();
            this.mail_category_t = new System.Windows.Forms.Label();
            this.n_11799640 = new System.Windows.Forms.Label();
            this.n_39087901 = new System.Windows.Forms.Label();
            this.n_16246796 = new System.Windows.Forms.Label();
            this.n_12003436 = new System.Windows.Forms.Label();
            this.n_40922063 = new System.Windows.Forms.Label();
            this.n_32754255 = new System.Windows.Forms.Label();
            this.n_26352844 = new System.Windows.Forms.Label();
            this.n_35849007 = new System.Windows.Forms.Label();
            this.print_recipients = new System.Windows.Forms.CheckBox();
            this.n_54205609 = new System.Windows.Forms.Label();
            this.n_18088435 = new System.Windows.Forms.Label();
            this.n_28578190 = new System.Windows.Forms.Label();
            this.st_counter = new System.Windows.Forms.Label();
            this.n_55877124 = new System.Windows.Forms.Label();
            this.n_33132068 = new System.Windows.Forms.Label();
            this.o_name = new System.Windows.Forms.TextBox();
            this.outlet_bmp = new System.Windows.Forms.PictureBox();
            this.mail_category = new Metex.Windows.DataEntityCombo();
            this.del_days_week = new Metex.Windows.DataEntityCombo();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.loaded_todate = new System.Windows.Forms.MaskedTextBox();
            this.loaded_fromdate = new System.Windows.Forms.MaskedTextBox();
            this.contract_no = new System.Windows.Forms.TextBox();
            this.n_61195818 = new System.Windows.Forms.Label();
            this.updateafterprint = new System.Windows.Forms.CheckBox();
            this.printedon_todate = new System.Windows.Forms.MaskedTextBox();
            this.printedon_fromdate = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.directory_listing3 = new System.Windows.Forms.RadioButton();
            this.directory_listing2 = new System.Windows.Forms.RadioButton();
            this.directory_listing1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cust_de_type2 = new System.Windows.Forms.RadioButton();
            this.cust_de_type1 = new System.Windows.Forms.RadioButton();
            this.n_29753161 = new System.Windows.Forms.Label();
            this.date_start = new System.Windows.Forms.MaskedTextBox();
            this.n_66451858 = new System.Windows.Forms.Label();
            this.date_end = new System.Windows.Forms.MaskedTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.detailed_report3 = new System.Windows.Forms.RadioButton();
            this.detailed_report2 = new System.Windows.Forms.RadioButton();
            this.detailed_report1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.CustCriteriaDelfreq);
            // 
            // st_report
            // 
            this.st_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_report.Location = new System.Drawing.Point(4, 0);
            this.st_report.Name = "st_report";
            this.st_report.Size = new System.Drawing.Size(257, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Text = "Customer Listing by Delivery Days";
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_report.Visible = false;
            // 
            // n_45713421
            // 
            this.n_45713421.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_45713421.Location = new System.Drawing.Point(121, 33);
            this.n_45713421.Name = "n_45713421";
            this.n_45713421.Size = new System.Drawing.Size(113, 13);
            this.n_45713421.TabIndex = 0;
            this.n_45713421.Text = "Search Criteria";
            this.n_45713421.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_45713421.Visible = false;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionIdRo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.Location = new System.Drawing.Point(117, 15);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(206, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // outlet_picklist
            // 
            this.outlet_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_picklist.Enabled = false;
            this.outlet_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_picklist.Location = new System.Drawing.Point(539, 78);
            this.outlet_picklist.Name = "outlet_picklist";
            this.outlet_picklist.Size = new System.Drawing.Size(20, 14);
            this.outlet_picklist.TabIndex = 0;
            // 
            // random_number
            // 
            this.random_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RandomNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.random_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.random_number.Location = new System.Drawing.Point(235, 391);
            this.random_number.Name = "random_number";
            this.random_number.Size = new System.Drawing.Size(44, 20);
            this.random_number.TabIndex = 200;
            this.random_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.random_number.Visible = false;
            // 
            // st_recipient
            // 
            this.st_recipient.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "StRecipient", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_recipient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_recipient.Location = new System.Drawing.Point(160, 420);
            this.st_recipient.Name = "st_recipient";
            this.st_recipient.Size = new System.Drawing.Size(120, 20);
            this.st_recipient.TabIndex = 0;
            // 
            // use_printedon
            // 
            this.use_printedon.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "UsePrintedon1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.use_printedon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.use_printedon.Location = new System.Drawing.Point(139, 194);
            this.use_printedon.Name = "use_printedon";
            this.use_printedon.Size = new System.Drawing.Size(16, 13);
            this.use_printedon.TabIndex = 100;
            // 
            // n_8767611
            // 
            this.n_8767611.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_8767611.Location = new System.Drawing.Point(4, 2);
            this.n_8767611.Name = "n_8767611";
            this.n_8767611.Size = new System.Drawing.Size(96, 13);
            this.n_8767611.TabIndex = 0;
            this.n_8767611.Text = "Main Criteria";
            this.n_8767611.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // region_id_t
            // 
            this.region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_t.Location = new System.Drawing.Point(44, 18);
            this.region_id_t.Name = "region_id_t";
            this.region_id_t.Size = new System.Drawing.Size(67, 13);
            this.region_id_t.TabIndex = 0;
            this.region_id_t.Text = "Region";
            this.region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // outlet_id_t
            // 
            this.outlet_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_id_t.Location = new System.Drawing.Point(25, 40);
            this.outlet_id_t.Name = "outlet_id_t";
            this.outlet_id_t.Size = new System.Drawing.Size(86, 13);
            this.outlet_id_t.TabIndex = 0;
            this.outlet_id_t.Text = "Base Office";
            this.outlet_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mail_category_t
            // 
            this.mail_category_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.mail_category_t.Location = new System.Drawing.Point(18, 60);
            this.mail_category_t.Name = "mail_category_t";
            this.mail_category_t.Size = new System.Drawing.Size(93, 13);
            this.mail_category_t.TabIndex = 0;
            this.mail_category_t.Text = "Mail Category";
            this.mail_category_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_11799640
            // 
            this.n_11799640.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_11799640.Location = new System.Drawing.Point(17, 81);
            this.n_11799640.Name = "n_11799640";
            this.n_11799640.Size = new System.Drawing.Size(94, 13);
            this.n_11799640.TabIndex = 0;
            this.n_11799640.Text = "Frequency";
            this.n_11799640.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_39087901
            // 
            this.n_39087901.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_39087901.Location = new System.Drawing.Point(18, 102);
            this.n_39087901.Name = "n_39087901";
            this.n_39087901.Size = new System.Drawing.Size(93, 13);
            this.n_39087901.TabIndex = 0;
            this.n_39087901.Text = "Contract Type";
            this.n_39087901.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_16246796
            // 
            this.n_16246796.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_16246796.Location = new System.Drawing.Point(19, 123);
            this.n_16246796.Name = "n_16246796";
            this.n_16246796.Size = new System.Drawing.Size(92, 13);
            this.n_16246796.TabIndex = 0;
            this.n_16246796.Text = "Renewal group";
            this.n_16246796.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_12003436
            // 
            this.n_12003436.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_12003436.Location = new System.Drawing.Point(17, 144);
            this.n_12003436.Name = "n_12003436";
            this.n_12003436.Size = new System.Drawing.Size(96, 13);
            this.n_12003436.TabIndex = 0;
            this.n_12003436.Text = "Date Loaded";
            this.n_12003436.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_40922063
            // 
            this.n_40922063.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_40922063.Location = new System.Drawing.Point(16, 164);
            this.n_40922063.Name = "n_40922063";
            this.n_40922063.Size = new System.Drawing.Size(96, 13);
            this.n_40922063.TabIndex = 0;
            this.n_40922063.Text = "Contract";
            this.n_40922063.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_32754255
            // 
            this.n_32754255.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_32754255.Location = new System.Drawing.Point(4, 179);
            this.n_32754255.Name = "n_32754255";
            this.n_32754255.Size = new System.Drawing.Size(58, 13);
            this.n_32754255.TabIndex = 0;
            this.n_32754255.Text = "Printing";
            this.n_32754255.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_26352844
            // 
            this.n_26352844.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_26352844.Location = new System.Drawing.Point(53, 194);
            this.n_26352844.Name = "n_26352844";
            this.n_26352844.Size = new System.Drawing.Size(72, 13);
            this.n_26352844.TabIndex = 0;
            this.n_26352844.Text = "Date Printed";
            this.n_26352844.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_35849007
            // 
            this.n_35849007.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_35849007.Location = new System.Drawing.Point(4, 213);
            this.n_35849007.Name = "n_35849007";
            this.n_35849007.Size = new System.Drawing.Size(58, 13);
            this.n_35849007.TabIndex = 0;
            this.n_35849007.Text = "Privacy";
            this.n_35849007.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // print_recipients
            // 
            this.print_recipients.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.print_recipients.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "PrintRecipients1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.print_recipients.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.print_recipients.Location = new System.Drawing.Point(54, 229);
            this.print_recipients.Name = "print_recipients";
            this.print_recipients.Size = new System.Drawing.Size(100, 17);
            this.print_recipients.TabIndex = 150;
            this.print_recipients.Text = "Print Recipients";
            // 
            // n_54205609
            // 
            this.n_54205609.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_54205609.Location = new System.Drawing.Point(54, 250);
            this.n_54205609.Name = "n_54205609";
            this.n_54205609.Size = new System.Drawing.Size(73, 13);
            this.n_54205609.TabIndex = 0;
            this.n_54205609.Text = "Privacy Flag ";
            this.n_54205609.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_18088435
            // 
            this.n_18088435.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_18088435.Location = new System.Drawing.Point(4, 269);
            this.n_18088435.Name = "n_18088435";
            this.n_18088435.Size = new System.Drawing.Size(148, 13);
            this.n_18088435.TabIndex = 0;
            this.n_18088435.Text = "Date Range Sorting";
            this.n_18088435.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_28578190
            // 
            this.n_28578190.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_28578190.Location = new System.Drawing.Point(3, 352);
            this.n_28578190.Name = "n_28578190";
            this.n_28578190.Size = new System.Drawing.Size(120, 13);
            this.n_28578190.TabIndex = 0;
            this.n_28578190.Text = "Select A Report";
            this.n_28578190.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // st_counter
            // 
            this.st_counter.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "StCounter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_counter.Location = new System.Drawing.Point(9, 420);
            this.st_counter.Name = "st_counter";
            this.st_counter.Size = new System.Drawing.Size(140, 20);
            this.st_counter.TabIndex = 0;
            // 
            // n_55877124
            // 
            this.n_55877124.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_55877124.Location = new System.Drawing.Point(201, 144);
            this.n_55877124.Name = "n_55877124";
            this.n_55877124.Size = new System.Drawing.Size(16, 13);
            this.n_55877124.TabIndex = 0;
            this.n_55877124.Text = "to";
            this.n_55877124.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_33132068
            // 
            this.n_33132068.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_33132068.Location = new System.Drawing.Point(238, 194);
            this.n_33132068.Name = "n_33132068";
            this.n_33132068.Size = new System.Drawing.Size(16, 13);
            this.n_33132068.TabIndex = 0;
            this.n_33132068.Text = "to";
            this.n_33132068.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // o_name
            // 
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name.Location = new System.Drawing.Point(117, 36);
            this.o_name.MaxLength = 40;
            this.o_name.Name = "o_name";
            this.o_name.Size = new System.Drawing.Size(187, 20);
            this.o_name.TabIndex = 20;
            // 
            // outlet_bmp
            // 
            this.outlet_bmp.Image = ((System.Drawing.Image)(resources.GetObject("outlet_bmp.Image")));
            this.outlet_bmp.Location = new System.Drawing.Point(308, 39);
            this.outlet_bmp.Name = "outlet_bmp";
            this.outlet_bmp.Size = new System.Drawing.Size(17, 15);
            this.outlet_bmp.TabIndex = 0;
            this.outlet_bmp.TabStop = false;
            // 
            // mail_category
            // 
            this.mail_category.AutoRetrieve = true;
            this.mail_category.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "MailCategory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mail_category.DisplayMember = "Desc";
            this.mail_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.mail_category.Location = new System.Drawing.Point(117, 56);
            this.mail_category.Name = "mail_category";
            this.mail_category.Size = new System.Drawing.Size(206, 21);
            this.mail_category.TabIndex = 30;
            this.mail_category.Value = null;
            this.mail_category.ValueMember = "Code";
            // 
            // del_days_week
            // 
            this.del_days_week.AutoRetrieve = false;
            this.del_days_week.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "DelDaysWeek", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.del_days_week.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.del_days_week.Location = new System.Drawing.Point(117, 77);
            this.del_days_week.Name = "del_days_week";
            this.del_days_week.Size = new System.Drawing.Size(206, 21);
            this.del_days_week.TabIndex = 40;
            this.del_days_week.Value = null;
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ct_key.Location = new System.Drawing.Point(117, 98);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(206, 21);
            this.ct_key.TabIndex = 50;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.Location = new System.Drawing.Point(117, 119);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(206, 21);
            this.rg_code.TabIndex = 60;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            // 
            // loaded_todate
            // 
            this.loaded_todate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "LoadedTodate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.loaded_todate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.loaded_todate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.loaded_todate.Location = new System.Drawing.Point(221, 140);
            this.loaded_todate.Mask = "00/00/0000";
            this.loaded_todate.Name = "loaded_todate";
            this.loaded_todate.PromptChar = '0';
            this.loaded_todate.Size = new System.Drawing.Size(73, 20);
            this.loaded_todate.TabIndex = 90;
            this.loaded_todate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.loaded_todate.ValidatingType = typeof(System.DateTime);
            this.loaded_todate.Validated += new System.EventHandler(this.DateTime_Validated);
            this.loaded_todate.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.DateTime_TypeValidationCompleted);
            // 
            // loaded_fromdate
            // 
            this.loaded_fromdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "LoadedFromdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.loaded_fromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.loaded_fromdate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.loaded_fromdate.Location = new System.Drawing.Point(117, 140);
            this.loaded_fromdate.Mask = "00/00/0000";
            this.loaded_fromdate.Name = "loaded_fromdate";
            this.loaded_fromdate.PromptChar = '0';
            this.loaded_fromdate.Size = new System.Drawing.Size(73, 20);
            this.loaded_fromdate.TabIndex = 80;
            this.loaded_fromdate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.loaded_fromdate.ValidatingType = typeof(System.DateTime);
            this.loaded_fromdate.Validated += new System.EventHandler(this.DateTime_Validated);
            this.loaded_fromdate.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.DateTime_TypeValidationCompleted);
            // 
            // contract_no
            // 
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_no.Location = new System.Drawing.Point(117, 161);
            this.contract_no.Name = "contract_no";
            this.contract_no.Size = new System.Drawing.Size(49, 20);
            this.contract_no.TabIndex = 70;
            // 
            // n_61195818
            // 
            this.n_61195818.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_61195818.Location = new System.Drawing.Point(120, 213);
            this.n_61195818.Name = "n_61195818";
            this.n_61195818.Size = new System.Drawing.Size(98, 13);
            this.n_61195818.TabIndex = 0;
            this.n_61195818.Text = "Update After Print";
            this.n_61195818.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateafterprint
            // 
            this.updateafterprint.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "Updateafterprint1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateafterprint.Enabled = false;
            this.updateafterprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.updateafterprint.Location = new System.Drawing.Point(221, 213);
            this.updateafterprint.Name = "updateafterprint";
            this.updateafterprint.Size = new System.Drawing.Size(17, 13);
            this.updateafterprint.TabIndex = 130;
            // 
            // printedon_todate
            // 
            this.printedon_todate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PrintedonTodate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.printedon_todate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.printedon_todate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.printedon_todate.Location = new System.Drawing.Point(257, 190);
            this.printedon_todate.Mask = "00/00/0000";
            this.printedon_todate.Name = "printedon_todate";
            this.printedon_todate.PromptChar = '0';
            this.printedon_todate.Size = new System.Drawing.Size(73, 20);
            this.printedon_todate.TabIndex = 120;
            this.printedon_todate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.printedon_todate.ValidatingType = typeof(System.DateTime);
            this.printedon_todate.Validated += new System.EventHandler(this.DateTime_Validated);
            this.printedon_todate.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.DateTime_TypeValidationCompleted);
            // 
            // printedon_fromdate
            // 
            this.printedon_fromdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PrintedonFromdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.printedon_fromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.printedon_fromdate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.printedon_fromdate.Location = new System.Drawing.Point(161, 190);
            this.printedon_fromdate.Mask = "00/00/0000";
            this.printedon_fromdate.Name = "printedon_fromdate";
            this.printedon_fromdate.PromptChar = '0';
            this.printedon_fromdate.Size = new System.Drawing.Size(73, 20);
            this.printedon_fromdate.TabIndex = 110;
            this.printedon_fromdate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.printedon_fromdate.ValidatingType = typeof(System.DateTime);
            this.printedon_fromdate.Validated += new System.EventHandler(this.DateTime_Validated);
            this.printedon_fromdate.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.DateTime_TypeValidationCompleted);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.directory_listing3);
            this.panel2.Controls.Add(this.directory_listing2);
            this.panel2.Controls.Add(this.directory_listing1);
            this.panel2.Location = new System.Drawing.Point(124, 246);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 20);
            this.panel2.TabIndex = 201;
            // 
            // directory_listing3
            // 
            this.directory_listing3.AutoSize = true;
            this.directory_listing3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.directory_listing3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DirectoryListing3", true));
            this.directory_listing3.Location = new System.Drawing.Point(157, 2);
            this.directory_listing3.Name = "directory_listing3";
            this.directory_listing3.Size = new System.Drawing.Size(36, 17);
            this.directory_listing3.TabIndex = 2;
            this.directory_listing3.TabStop = true;
            this.directory_listing3.Text = "All";
            this.directory_listing3.UseVisualStyleBackColor = true;
            // 
            // directory_listing2
            // 
            this.directory_listing2.AutoSize = true;
            this.directory_listing2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.directory_listing2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DirectoryListing2", true));
            this.directory_listing2.Location = new System.Drawing.Point(76, 2);
            this.directory_listing2.Name = "directory_listing2";
            this.directory_listing2.Size = new System.Drawing.Size(43, 17);
            this.directory_listing2.TabIndex = 1;
            this.directory_listing2.TabStop = true;
            this.directory_listing2.Text = "Yes";
            this.directory_listing2.UseVisualStyleBackColor = true;
            // 
            // directory_listing1
            // 
            this.directory_listing1.AutoSize = true;
            this.directory_listing1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.directory_listing1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DirectoryListing1", true));
            this.directory_listing1.Location = new System.Drawing.Point(11, 2);
            this.directory_listing1.Name = "directory_listing1";
            this.directory_listing1.Size = new System.Drawing.Size(39, 17);
            this.directory_listing1.TabIndex = 0;
            this.directory_listing1.TabStop = true;
            this.directory_listing1.Text = "No";
            this.directory_listing1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cust_de_type2);
            this.panel1.Controls.Add(this.cust_de_type1);
            this.panel1.Location = new System.Drawing.Point(56, 283);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 44);
            this.panel1.TabIndex = 202;
            // 
            // cust_de_type2
            // 
            this.cust_de_type2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cust_de_type2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CustDeType2", true));
            this.cust_de_type2.Location = new System.Drawing.Point(7, 24);
            this.cust_de_type2.Name = "cust_de_type2";
            this.cust_de_type2.Size = new System.Drawing.Size(99, 17);
            this.cust_de_type2.TabIndex = 186;
            this.cust_de_type2.TabStop = true;
            this.cust_de_type2.Text = "New Customers";
            this.cust_de_type2.UseVisualStyleBackColor = true;
            // 
            // cust_de_type1
            // 
            this.cust_de_type1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cust_de_type1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CustDeType1", true));
            this.cust_de_type1.Location = new System.Drawing.Point(7, 4);
            this.cust_de_type1.Name = "cust_de_type1";
            this.cust_de_type1.Size = new System.Drawing.Size(99, 17);
            this.cust_de_type1.TabIndex = 185;
            this.cust_de_type1.TabStop = true;
            this.cust_de_type1.Text = "All Customers";
            this.cust_de_type1.UseVisualStyleBackColor = true;
            // 
            // n_29753161
            // 
            this.n_29753161.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_29753161.Location = new System.Drawing.Point(67, 336);
            this.n_29753161.Name = "n_29753161";
            this.n_29753161.Size = new System.Drawing.Size(30, 13);
            this.n_29753161.TabIndex = 182;
            this.n_29753161.Text = "From";
            this.n_29753161.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // date_start
            // 
            this.date_start.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DateStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.date_start.Enabled = false;
            this.date_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.date_start.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.date_start.Location = new System.Drawing.Point(101, 332);
            this.date_start.Mask = "00/00/0000";
            this.date_start.Name = "date_start";
            this.date_start.PromptChar = '0';
            this.date_start.Size = new System.Drawing.Size(73, 20);
            this.date_start.TabIndex = 183;
            this.date_start.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.date_start.ValidatingType = typeof(System.DateTime);
            this.date_start.Validated += new System.EventHandler(this.DateTime_Validated);
            this.date_start.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.DateTime_TypeValidationCompleted);
            // 
            // n_66451858
            // 
            this.n_66451858.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_66451858.Location = new System.Drawing.Point(183, 336);
            this.n_66451858.Name = "n_66451858";
            this.n_66451858.Size = new System.Drawing.Size(20, 13);
            this.n_66451858.TabIndex = 181;
            this.n_66451858.Text = "To";
            this.n_66451858.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // date_end
            // 
            this.date_end.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DateEnd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.date_end.Enabled = false;
            this.date_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.date_end.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.date_end.Location = new System.Drawing.Point(206, 332);
            this.date_end.Mask = "00/00/0000";
            this.date_end.Name = "date_end";
            this.date_end.PromptChar = '0';
            this.date_end.Size = new System.Drawing.Size(73, 20);
            this.date_end.TabIndex = 184;
            this.date_end.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.date_end.ValidatingType = typeof(System.DateTime);
            this.date_end.Validated += new System.EventHandler(this.DateTime_Validated);
            this.date_end.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.DateTime_TypeValidationCompleted);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.detailed_report3);
            this.panel3.Controls.Add(this.detailed_report2);
            this.panel3.Controls.Add(this.detailed_report1);
            this.panel3.Location = new System.Drawing.Point(56, 365);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(173, 57);
            this.panel3.TabIndex = 203;
            // 
            // detailed_report3
            // 
            this.detailed_report3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.detailed_report3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DetailedReport3", true));
            this.detailed_report3.Location = new System.Drawing.Point(4, 35);
            this.detailed_report3.Name = "detailed_report3";
            this.detailed_report3.Size = new System.Drawing.Size(166, 17);
            this.detailed_report3.TabIndex = 2;
            this.detailed_report3.TabStop = true;
            this.detailed_report3.Text = "Randomly Generated Labels";
            this.detailed_report3.UseVisualStyleBackColor = true;
            // 
            // detailed_report2
            // 
            this.detailed_report2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.detailed_report2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.detailed_report2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DetailedReport2", true));
            this.detailed_report2.Location = new System.Drawing.Point(4, 19);
            this.detailed_report2.Name = "detailed_report2";
            this.detailed_report2.Size = new System.Drawing.Size(166, 16);
            this.detailed_report2.TabIndex = 1;
            this.detailed_report2.TabStop = true;
            this.detailed_report2.Text = "Customer Labels";
            this.detailed_report2.UseVisualStyleBackColor = true;
            // 
            // detailed_report1
            // 
            this.detailed_report1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.detailed_report1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DetailedReport1", true));
            this.detailed_report1.Location = new System.Drawing.Point(4, 3);
            this.detailed_report1.Name = "detailed_report1";
            this.detailed_report1.Size = new System.Drawing.Size(167, 16);
            this.detailed_report1.TabIndex = 0;
            this.detailed_report1.TabStop = true;
            this.detailed_report1.Text = "Detailed Customer Listing";
            this.detailed_report1.UseVisualStyleBackColor = true;
            // 
            // DCustCriteriaDelfreq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.st_recipient);
            this.Controls.Add(this.st_counter);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.n_29753161);
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.date_start);
            this.Controls.Add(this.n_45713421);
            this.Controls.Add(this.n_66451858);
            this.Controls.Add(this.date_end);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.outlet_picklist);
            this.Controls.Add(this.random_number);
            this.Controls.Add(this.use_printedon);
            this.Controls.Add(this.n_8767611);
            this.Controls.Add(this.region_id_t);
            this.Controls.Add(this.outlet_id_t);
            this.Controls.Add(this.mail_category_t);
            this.Controls.Add(this.n_11799640);
            this.Controls.Add(this.n_39087901);
            this.Controls.Add(this.n_16246796);
            this.Controls.Add(this.n_12003436);
            this.Controls.Add(this.n_40922063);
            this.Controls.Add(this.n_32754255);
            this.Controls.Add(this.n_26352844);
            this.Controls.Add(this.n_35849007);
            this.Controls.Add(this.print_recipients);
            this.Controls.Add(this.n_54205609);
            this.Controls.Add(this.n_18088435);
            this.Controls.Add(this.n_28578190);
            this.Controls.Add(this.n_55877124);
            this.Controls.Add(this.n_33132068);
            this.Controls.Add(this.o_name);
            this.Controls.Add(this.outlet_bmp);
            this.Controls.Add(this.mail_category);
            this.Controls.Add(this.del_days_week);
            this.Controls.Add(this.ct_key);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.loaded_todate);
            this.Controls.Add(this.loaded_fromdate);
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.n_61195818);
            this.Controls.Add(this.updateafterprint);
            this.Controls.Add(this.printedon_todate);
            this.Controls.Add(this.printedon_fromdate);
            this.Name = "DCustCriteriaDelfreq";
            this.Size = new System.Drawing.Size(650, 446);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        //--add by mkwang
        private void DateTime_Validated(object sender, System.EventArgs e)
        {
            System.Windows.Forms.MaskedTextBox textBox = (System.Windows.Forms.MaskedTextBox)sender;
            if (textBox.Text == "01/01/0001")
            {
                textBox.Text = "00/00/0000";
            }
        }
        //--add by mkwang
        private void DateTime_TypeValidationCompleted(object sender, System.Windows.Forms.TypeValidationEventArgs e)
        {
            System.Windows.Forms.MaskedTextBox textBox = (System.Windows.Forms.MaskedTextBox)sender;
            if (textBox.Text == "00/00/0000")
            {
                textBox.Text = new System.DateTime?().GetValueOrDefault().ToString();
            }
        }

        #endregion

        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.Label n_45713421;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.CheckBox outlet_picklist;
        private System.Windows.Forms.TextBox random_number;
        private System.Windows.Forms.Label st_recipient;
        private System.Windows.Forms.CheckBox use_printedon;
        private System.Windows.Forms.Label n_8767611;
        private System.Windows.Forms.Label region_id_t;
        private System.Windows.Forms.Label outlet_id_t;
        private System.Windows.Forms.Label mail_category_t;
        private System.Windows.Forms.Label n_11799640;
        private System.Windows.Forms.Label n_39087901;
        private System.Windows.Forms.Label n_16246796;
        private System.Windows.Forms.Label n_12003436;
        private System.Windows.Forms.Label n_40922063;
        private System.Windows.Forms.Label n_32754255;
        private System.Windows.Forms.Label n_26352844;
        private System.Windows.Forms.Label n_35849007;
        private System.Windows.Forms.CheckBox print_recipients;
        private System.Windows.Forms.Label n_54205609;
        private System.Windows.Forms.Label n_18088435;
        private System.Windows.Forms.Label n_28578190;
        private System.Windows.Forms.Label st_counter;
        private System.Windows.Forms.Label n_55877124;
        private System.Windows.Forms.Label n_33132068;
        private System.Windows.Forms.TextBox o_name;
        private System.Windows.Forms.PictureBox outlet_bmp;
        private Metex.Windows.DataEntityCombo mail_category;
        private Metex.Windows.DataEntityCombo del_days_week;
        private Metex.Windows.DataEntityCombo ct_key;
        private Metex.Windows.DataEntityCombo rg_code;
        private System.Windows.Forms.MaskedTextBox loaded_todate;
        private System.Windows.Forms.MaskedTextBox loaded_fromdate;
        private System.Windows.Forms.TextBox contract_no;
        private System.Windows.Forms.Label n_61195818;
        private System.Windows.Forms.CheckBox updateafterprint;
        private System.Windows.Forms.MaskedTextBox printedon_todate;
        private System.Windows.Forms.MaskedTextBox printedon_fromdate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton directory_listing1;
        private System.Windows.Forms.RadioButton directory_listing3;
        private System.Windows.Forms.RadioButton directory_listing2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label n_29753161;
        private System.Windows.Forms.MaskedTextBox date_start;
        private System.Windows.Forms.Label n_66451858;
        private System.Windows.Forms.MaskedTextBox date_end;
        private System.Windows.Forms.RadioButton cust_de_type1;
        private System.Windows.Forms.RadioButton cust_de_type2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton detailed_report1;
        private System.Windows.Forms.RadioButton detailed_report3;
        private System.Windows.Forms.RadioButton detailed_report2;
    }
}
