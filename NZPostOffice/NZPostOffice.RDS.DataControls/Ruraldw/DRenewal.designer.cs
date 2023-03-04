using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared.VisualComponents;
using System.Windows.Forms;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DRenewal
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
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.gb_2 = new System.Windows.Forms.GroupBox();
            this.con_relief_driver_name_t = new System.Windows.Forms.Label();
            this.st_fullaccess = new System.Windows.Forms.Label();
            this.con_relief_driver_address_t = new System.Windows.Forms.Label();
            this.con_relief_driver_home_phone_t = new System.Windows.Forms.Label();
            this.con_relief_driver_name = new System.Windows.Forms.TextBox();
            this.con_relief_driver_address = new System.Windows.Forms.TextBox();
            this.con_relief_driver_home_phone = new System.Windows.Forms.TextBox();
            this.t_1 = new System.Windows.Forms.Label();
            this.gb_3 = new System.Windows.Forms.GroupBox();
            this.con_start_date_t = new System.Windows.Forms.Label();
            this.con_expiry_date_t = new System.Windows.Forms.Label();
            this.con_date_last_assigned_t = new System.Windows.Forms.Label();
            this.con_date_last_assigned = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.con_acceptance_flag = new System.Windows.Forms.CheckBox();
            this.con_start_pay_date_t = new System.Windows.Forms.Label();
            this.con_start_pay_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.con_last_paid_date_t = new System.Windows.Forms.Label();
            this.con_last_paid_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.con_expiry_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.con_start_date = new DateTimeMaskedTextBox();
            this.gb_4 = new System.Windows.Forms.GroupBox();
            this.con_processing_hours_per_week_t = new System.Windows.Forms.Label();
            this.con_processing_hours_per_week = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.con_distance_at_renewal_t = new System.Windows.Forms.Label();
            this.con_distance_at_renewal = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.con_no_private_bags_at_renewa_t = new System.Windows.Forms.Label();
            this.con_renewal_benchmark_price_t = new System.Windows.Forms.Label();
            this.con_renewal_benchmark_price = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.con_no_customers_at_renewal_t = new System.Windows.Forms.Label();
            this.con_no_post_offices_at_renewa_t = new System.Windows.Forms.Label();
            this.con_renewal_payment_value_t = new System.Windows.Forms.Label();
            this.con_no_rural_private_bags_at__t = new System.Windows.Forms.Label();
            this.con_no_cmbs_at_renewal_t = new System.Windows.Forms.Label();
            this.con_volume_at_renewal_t = new System.Windows.Forms.Label();
            this.con_no_other_bags_at_renewal_t = new System.Windows.Forms.Label();
            this.con_no_cmb_custs_at_renewal_t = new System.Windows.Forms.Label();
            this.con_del_hrs_week_at_renewal_t = new System.Windows.Forms.Label();

            this.con_rg_code_at_renewal_t = new System.Windows.Forms.Label();
            this.con_rg_code_at_renewal_t2 = new Label();

            this.con_rg_code_at_renewal = new Metex.Windows.DataEntityCombo();
            this.t_2 = new System.Windows.Forms.Label();
            this.con_rates_effective_date = new DateTimeMaskedTextBox();
            this.con_no_private_bags_at_renewa = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.con_no_post_offices_at_renewa = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.con_no_cmbs_at_renewal = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.con_no_cmb_custs_at_renewal = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.con_no_other_bags_at_renewal = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.con_no_rural_private_bags_at_ = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.con_no_customers_at_renewal = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.con_renewal_payment_value = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.con_volume_at_renewal = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.con_del_hrs_week_at_renewal = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.contract_no_t = new System.Windows.Forms.Label();
            this.contracttitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.gb_2.SuspendLayout();
            this.gb_3.SuspendLayout();
            this.gb_4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.Renewal);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // gb_1
            // 
            this.gb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_1.Location = new System.Drawing.Point(642, 32);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(557, 113);
            this.gb_1.TabIndex = 0;
            this.gb_1.TabStop = false;
            // 
            // gb_2
            // 
            this.gb_2.Controls.Add(this.con_relief_driver_name_t);
            this.gb_2.Controls.Add(this.st_fullaccess);
            this.gb_2.Controls.Add(this.con_relief_driver_address_t);
            this.gb_2.Controls.Add(this.con_relief_driver_home_phone_t);
            this.gb_2.Controls.Add(this.con_relief_driver_name);
            this.gb_2.Controls.Add(this.con_relief_driver_address);
            this.gb_2.Controls.Add(this.con_relief_driver_home_phone);
            this.gb_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_2.Location = new System.Drawing.Point(298, 21);
            this.gb_2.Name = "gb_2";
            this.gb_2.Size = new System.Drawing.Size(250, 124);
            this.gb_2.TabIndex = 0;
            this.gb_2.TabStop = false;
            this.gb_2.Text = "Relief Driver Details";
            // 
            // con_relief_driver_name_t
            // 
            this.con_relief_driver_name_t.AutoSize = true;
            this.con_relief_driver_name_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_relief_driver_name_t.Location = new System.Drawing.Point(12, 20);
            this.con_relief_driver_name_t.Name = "con_relief_driver_name_t";
            this.con_relief_driver_name_t.Size = new System.Drawing.Size(35, 13);
            this.con_relief_driver_name_t.TabIndex = 63;
            this.con_relief_driver_name_t.Text = "Name";
            this.con_relief_driver_name_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // st_fullaccess
            // 
            this.st_fullaccess.Font = new System.Drawing.Font("Arial", 8F);
            this.st_fullaccess.Location = new System.Drawing.Point(220, -1);
            this.st_fullaccess.Name = "st_fullaccess";
            this.st_fullaccess.Size = new System.Drawing.Size(11, 14);
            this.st_fullaccess.TabIndex = 64;
            this.st_fullaccess.Text = "Y";
            this.st_fullaccess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_fullaccess.Visible = false;
            // 
            // con_relief_driver_address_t
            // 
            this.con_relief_driver_address_t.AutoSize = true;
            this.con_relief_driver_address_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_relief_driver_address_t.Location = new System.Drawing.Point(2, 45);
            this.con_relief_driver_address_t.Name = "con_relief_driver_address_t";
            this.con_relief_driver_address_t.Size = new System.Drawing.Size(45, 13);
            this.con_relief_driver_address_t.TabIndex = 61;
            this.con_relief_driver_address_t.Text = "Address";
            this.con_relief_driver_address_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_relief_driver_home_phone_t
            // 
            this.con_relief_driver_home_phone_t.AutoSize = true;
            this.con_relief_driver_home_phone_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_relief_driver_home_phone_t.Location = new System.Drawing.Point(9, 98);
            this.con_relief_driver_home_phone_t.Name = "con_relief_driver_home_phone_t";
            this.con_relief_driver_home_phone_t.Size = new System.Drawing.Size(38, 13);
            this.con_relief_driver_home_phone_t.TabIndex = 62;
            this.con_relief_driver_home_phone_t.Text = "Phone";
            this.con_relief_driver_home_phone_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_relief_driver_name
            // 
            this.con_relief_driver_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConReliefDriverName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_relief_driver_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_relief_driver_name.Location = new System.Drawing.Point(50, 17);
            this.con_relief_driver_name.MaxLength = 40;
            this.con_relief_driver_name.Name = "con_relief_driver_name";
            this.con_relief_driver_name.Size = new System.Drawing.Size(191, 20);
            this.con_relief_driver_name.TabIndex = 65;
            // 
            // con_relief_driver_address
            // 
            this.con_relief_driver_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConReliefDriverAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_relief_driver_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_relief_driver_address.Location = new System.Drawing.Point(50, 42);
            this.con_relief_driver_address.MaxLength = 200;
            this.con_relief_driver_address.Multiline = true;
            this.con_relief_driver_address.Name = "con_relief_driver_address";
            this.con_relief_driver_address.Size = new System.Drawing.Size(192, 50);
            this.con_relief_driver_address.TabIndex = 66;
            // 
            // con_relief_driver_home_phone
            // 
            this.con_relief_driver_home_phone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConReliefDriverHomePhone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_relief_driver_home_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_relief_driver_home_phone.Location = new System.Drawing.Point(51, 95);
            this.con_relief_driver_home_phone.Name = "con_relief_driver_home_phone";
            this.con_relief_driver_home_phone.Size = new System.Drawing.Size(80, 20);
            this.con_relief_driver_home_phone.TabIndex = 67;
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.Location = new System.Drawing.Point(777, 1);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(106, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "Relief Driver Details";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_3
            // 
            this.gb_3.Controls.Add(this.con_start_date_t);
            this.gb_3.Controls.Add(this.con_expiry_date_t);
            this.gb_3.Controls.Add(this.con_date_last_assigned_t);
            this.gb_3.Controls.Add(this.con_date_last_assigned);
            this.gb_3.Controls.Add(this.con_acceptance_flag);
            this.gb_3.Controls.Add(this.con_start_pay_date_t);
            this.gb_3.Controls.Add(this.con_start_pay_date);
            this.gb_3.Controls.Add(this.con_last_paid_date_t);
            this.gb_3.Controls.Add(this.con_last_paid_date);
            this.gb_3.Controls.Add(this.con_expiry_date);
            this.gb_3.Controls.Add(this.con_start_date);
            this.gb_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_3.Location = new System.Drawing.Point(10, 21);
            this.gb_3.Name = "gb_3";
            this.gb_3.Size = new System.Drawing.Size(284, 124);
            this.gb_3.TabIndex = 0;
            this.gb_3.TabStop = false;
            // 
            // con_start_date_t
            // 
            this.con_start_date_t.AutoSize = true;
            this.con_start_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_start_date_t.Location = new System.Drawing.Point(4, 17);
            this.con_start_date_t.Name = "con_start_date_t";
            this.con_start_date_t.Size = new System.Drawing.Size(102, 13);
            this.con_start_date_t.TabIndex = 36;
            this.con_start_date_t.Text = "Contract Term: Start";
            this.con_start_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_expiry_date_t
            // 
            this.con_expiry_date_t.AutoSize = true;
            this.con_expiry_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_expiry_date_t.Location = new System.Drawing.Point(176, 17);
            this.con_expiry_date_t.Name = "con_expiry_date_t";
            this.con_expiry_date_t.Size = new System.Drawing.Size(35, 13);
            this.con_expiry_date_t.TabIndex = 35;
            this.con_expiry_date_t.Text = "Expiry";
            this.con_expiry_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_date_last_assigned_t
            // 
            this.con_date_last_assigned_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_date_last_assigned_t.Location = new System.Drawing.Point(28, 41);
            this.con_date_last_assigned_t.Name = "con_date_last_assigned_t";
            this.con_date_last_assigned_t.Size = new System.Drawing.Size(78, 13);
            this.con_date_last_assigned_t.TabIndex = 37;
            this.con_date_last_assigned_t.Text = "Date Assigned";
            this.con_date_last_assigned_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_date_last_assigned
            // 
            this.con_date_last_assigned.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.con_date_last_assigned.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConDateLastAssigned", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_date_last_assigned.ReadOnly = true;//.Enabled = false;
            this.con_date_last_assigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_date_last_assigned.Location = new System.Drawing.Point(109, 41);
            this.con_date_last_assigned.Mask = "00/00/0000";
            this.con_date_last_assigned.Name = "con_date_last_assigned";
            //this.con_date_last_assigned.InsertKeyMode = InsertKeyMode.Overwrite;
            //this.con_date_last_assigned.TextMaskFormat = MaskFormat.IncludePrompt;
            //this.con_date_last_assigned.ValidatingType = typeof(System.DateTime);
            //this.con_date_last_assigned.PromptChar = ' ';
            this.con_date_last_assigned.Size = new System.Drawing.Size(63, 13);
            this.con_date_last_assigned.TabIndex = 38;
            //this.con_date_last_assigned.DataBindings[0].FormatString = "dd/MM/yyyy";
            // 
            // con_acceptance_flag
            // 
            this.con_acceptance_flag.AutoCheck = false;
            this.con_acceptance_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.con_acceptance_flag.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "ConAcceptanceFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_acceptance_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_acceptance_flag.Location = new System.Drawing.Point(12, 65);
            this.con_acceptance_flag.Name = "con_acceptance_flag";
            this.con_acceptance_flag.Size = new System.Drawing.Size(114, 16);
            this.con_acceptance_flag.TabIndex = 41;
            this.con_acceptance_flag.Text = "Contract Accepted";
            this.con_acceptance_flag.ThreeState = true;
            // 
            // con_start_pay_date_t
            // 
            this.con_start_pay_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_start_pay_date_t.Location = new System.Drawing.Point(28, 91);
            this.con_start_pay_date_t.Name = "con_start_pay_date_t";
            this.con_start_pay_date_t.Size = new System.Drawing.Size(78, 13);
            this.con_start_pay_date_t.TabIndex = 32;
            this.con_start_pay_date_t.Text = "Payment: Start";
            this.con_start_pay_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_start_pay_date
            // 
            this.con_start_pay_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.con_start_pay_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConStartPayDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_start_pay_date.ReadOnly = true;//.Enabled = false;
            this.con_start_pay_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_start_pay_date.Location = new System.Drawing.Point(109, 91);
            this.con_start_pay_date.Mask = "00/00/0000";
            this.con_start_pay_date.Name = "con_start_pay_date";
            this.con_start_pay_date.Size = new System.Drawing.Size(72, 13);
            this.con_start_pay_date.TabIndex = 31;
            //this.con_start_pay_date.InsertKeyMode = InsertKeyMode.Overwrite;
            //this.con_start_pay_date.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            //this.con_start_pay_date.ValidatingType = typeof(System.DateTime);
            // this.con_start_pay_date.PromptChar ='0';
            //this.con_start_pay_date.DataBindings[0].FormatString = "dd/MM/yyyy";

            // 
            // con_last_paid_date_t
            // 
            this.con_last_paid_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_paid_date_t.Location = new System.Drawing.Point(180, 91);
            this.con_last_paid_date_t.Name = "con_last_paid_date_t";
            this.con_last_paid_date_t.Size = new System.Drawing.Size(29, 13);
            this.con_last_paid_date_t.TabIndex = 34;
            this.con_last_paid_date_t.Text = "Last";
            this.con_last_paid_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_last_paid_date
            // 
            this.con_last_paid_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.con_last_paid_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastPaidDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_paid_date.ReadOnly = true;//.Enabled = false;
            this.con_last_paid_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_paid_date.Location = new System.Drawing.Point(215, 91);
            this.con_last_paid_date.Mask = "00/00/0000";
            this.con_last_paid_date.Name = "con_last_paid_date";
            // this.con_last_paid_date.PromptChar = '0';
            this.con_last_paid_date.Size = new System.Drawing.Size(63, 13);
            this.con_last_paid_date.TabIndex = 33;
            // 
            // con_expiry_date
            // 
            this.con_expiry_date.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_expiry_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConExpiryDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_expiry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_expiry_date.Location = new System.Drawing.Point(214, 19);
            this.con_expiry_date.Mask = "00/00/0000";
            //this.con_expiry_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.con_expiry_date.Name = "con_expiry_date";
            // this.con_expiry_date.PromptChar = '0';
            this.con_expiry_date.Size = new System.Drawing.Size(66, 20);
            this.con_expiry_date.TabIndex = 40;
            // 
            // con_start_date
            // 
            this.con_start_date.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_start_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConStartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_start_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_start_date.Location = new System.Drawing.Point(109, 19);
            this.con_start_date.Mask = "00/00/0000";
            this.con_start_date.Name = "con_start_date";
            //this.con_start_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            // this.con_start_date.PromptChar = '0';
            this.con_start_date.Size = new System.Drawing.Size(64, 20);
            this.con_start_date.TabIndex = 39;
            // 
            // gb_4
            // 
            this.gb_4.Controls.Add(this.con_processing_hours_per_week_t);
            this.gb_4.Controls.Add(this.con_processing_hours_per_week);
            this.gb_4.Controls.Add(this.con_distance_at_renewal_t);
            this.gb_4.Controls.Add(this.con_distance_at_renewal);
            this.gb_4.Controls.Add(this.con_no_private_bags_at_renewa_t);
            this.gb_4.Controls.Add(this.con_renewal_benchmark_price_t);
            this.gb_4.Controls.Add(this.con_renewal_benchmark_price);
            this.gb_4.Controls.Add(this.con_no_customers_at_renewal_t);
            this.gb_4.Controls.Add(this.con_no_post_offices_at_renewa_t);
            this.gb_4.Controls.Add(this.con_renewal_payment_value_t);
            this.gb_4.Controls.Add(this.con_no_rural_private_bags_at__t);
            this.gb_4.Controls.Add(this.con_no_cmbs_at_renewal_t);
            this.gb_4.Controls.Add(this.con_volume_at_renewal_t);
            this.gb_4.Controls.Add(this.con_no_other_bags_at_renewal_t);
            this.gb_4.Controls.Add(this.con_no_cmb_custs_at_renewal_t);
            this.gb_4.Controls.Add(this.con_del_hrs_week_at_renewal_t);
            this.gb_4.Controls.Add(this.con_rg_code_at_renewal_t);
            this.gb_4.Controls.Add(this.con_rg_code_at_renewal_t2); //added by jlwang

            this.gb_4.Controls.Add(this.con_rg_code_at_renewal);
            this.gb_4.Controls.Add(this.t_2);
            this.gb_4.Controls.Add(this.con_rates_effective_date);
            this.gb_4.Controls.Add(this.con_no_private_bags_at_renewa);
            this.gb_4.Controls.Add(this.con_no_post_offices_at_renewa);
            this.gb_4.Controls.Add(this.con_no_cmbs_at_renewal);
            this.gb_4.Controls.Add(this.con_no_cmb_custs_at_renewal);
            this.gb_4.Controls.Add(this.con_no_other_bags_at_renewal);
            this.gb_4.Controls.Add(this.con_no_rural_private_bags_at_);
            this.gb_4.Controls.Add(this.con_no_customers_at_renewal);
            this.gb_4.Controls.Add(this.con_renewal_payment_value);
            this.gb_4.Controls.Add(this.con_volume_at_renewal);
            this.gb_4.Controls.Add(this.con_del_hrs_week_at_renewal);
            this.gb_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_4.Location = new System.Drawing.Point(10, 151);
            this.gb_4.Name = "gb_4";
            this.gb_4.Size = new System.Drawing.Size(538, 152);
            this.gb_4.TabIndex = 0;
            this.gb_4.TabStop = false;
            this.gb_4.Text = "Renewal Values";
            // 
            // con_processing_hours_per_week_t
            // 
            this.con_processing_hours_per_week_t.AutoSize = true;
            this.con_processing_hours_per_week_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_processing_hours_per_week_t.Location = new System.Drawing.Point(16, 20);
            this.con_processing_hours_per_week_t.Name = "con_processing_hours_per_week_t";
            this.con_processing_hours_per_week_t.Size = new System.Drawing.Size(82, 13);
            this.con_processing_hours_per_week_t.TabIndex = 174;
            this.con_processing_hours_per_week_t.Text = "Proc Hrs/Week";
            this.con_processing_hours_per_week_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_processing_hours_per_week
            // 
            this.con_processing_hours_per_week.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.con_processing_hours_per_week.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConProcessingHoursPerWeek", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_processing_hours_per_week.EditMask = "##.00";
            this.con_processing_hours_per_week.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_processing_hours_per_week.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_processing_hours_per_week.Location = new System.Drawing.Point(99, 25);
            this.con_processing_hours_per_week.Name = "con_processing_hours_per_week";
            this.con_processing_hours_per_week.PromptChar = ' ';
            this.con_processing_hours_per_week.ReadOnly = true;
            this.con_processing_hours_per_week.Size = new System.Drawing.Size(61, 13);
            this.con_processing_hours_per_week.TabIndex = 175;
            this.con_processing_hours_per_week.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_processing_hours_per_week.Value = "";
            // 
            // con_distance_at_renewal_t
            // 
            this.con_distance_at_renewal_t.AutoSize = true;
            this.con_distance_at_renewal_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_distance_at_renewal_t.Location = new System.Drawing.Point(213, 20);
            this.con_distance_at_renewal_t.Name = "con_distance_at_renewal_t";
            this.con_distance_at_renewal_t.Size = new System.Drawing.Size(49, 13);
            this.con_distance_at_renewal_t.TabIndex = 173;
            this.con_distance_at_renewal_t.Text = "Distance";
            this.con_distance_at_renewal_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_distance_at_renewal
            // 
            this.con_distance_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.con_distance_at_renewal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConDistanceAtRenewal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_distance_at_renewal.EditMask = "###,###.00";
            //this.con_distance_at_renewal.DataBindings[0].FormatString = "###,###.00";
            this.con_distance_at_renewal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_distance_at_renewal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_distance_at_renewal.Location = new System.Drawing.Point(270, 25);
            this.con_distance_at_renewal.Name = "con_distance_at_renewal";
            this.con_distance_at_renewal.PromptChar = ' ';
            this.con_distance_at_renewal.ReadOnly = true;
            this.con_distance_at_renewal.Size = new System.Drawing.Size(61, 13);
            this.con_distance_at_renewal.TabIndex = 171;
            this.con_distance_at_renewal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_distance_at_renewal.Value = "";
            // 
            // con_no_private_bags_at_renewa_t
            // 
            this.con_no_private_bags_at_renewa_t.AutoSize = true;
            this.con_no_private_bags_at_renewa_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_private_bags_at_renewa_t.Location = new System.Drawing.Point(377, 20);
            this.con_no_private_bags_at_renewa_t.Name = "con_no_private_bags_at_renewa_t";
            this.con_no_private_bags_at_renewa_t.Size = new System.Drawing.Size(67, 13);
            this.con_no_private_bags_at_renewa_t.TabIndex = 172;
            this.con_no_private_bags_at_renewa_t.Text = "Private Bags";
            this.con_no_private_bags_at_renewa_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_renewal_benchmark_price_t
            // 
            this.con_renewal_benchmark_price_t.AutoSize = true;
            this.con_renewal_benchmark_price_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_renewal_benchmark_price_t.Location = new System.Drawing.Point(5, 43);
            this.con_renewal_benchmark_price_t.Name = "con_renewal_benchmark_price_t";
            this.con_renewal_benchmark_price_t.Size = new System.Drawing.Size(88, 13);
            this.con_renewal_benchmark_price_t.TabIndex = 179;
            this.con_renewal_benchmark_price_t.Text = "Benchmark Price";
            this.con_renewal_benchmark_price_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_renewal_benchmark_price
            // 
            this.con_renewal_benchmark_price.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.con_renewal_benchmark_price.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConRenewalBenchmarkPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_renewal_benchmark_price.EditMask = "$###,###.00";
            //this.con_renewal_benchmark_price.DataBindings[0].FormatString = "$###,###.00";
            this.con_renewal_benchmark_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_renewal_benchmark_price.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_renewal_benchmark_price.Location = new System.Drawing.Point(99, 48);
            this.con_renewal_benchmark_price.Name = "con_renewal_benchmark_price";
            this.con_renewal_benchmark_price.PromptChar = ' ';
            this.con_renewal_benchmark_price.ReadOnly = true;
            this.con_renewal_benchmark_price.Size = new System.Drawing.Size(61, 13);
            this.con_renewal_benchmark_price.TabIndex = 180;
            this.con_renewal_benchmark_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_renewal_benchmark_price.Value = "";

            // 
            // con_no_customers_at_renewal_t
            // 
            this.con_no_customers_at_renewal_t.AutoSize = true;
            this.con_no_customers_at_renewal_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_customers_at_renewal_t.Location = new System.Drawing.Point(185, 43);
            this.con_no_customers_at_renewal_t.Name = "con_no_customers_at_renewal_t";
            this.con_no_customers_at_renewal_t.Size = new System.Drawing.Size(77, 13);
            this.con_no_customers_at_renewal_t.TabIndex = 178;
            this.con_no_customers_at_renewal_t.Text = "Delivery Points";
            this.con_no_customers_at_renewal_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_no_post_offices_at_renewa_t
            // 
            this.con_no_post_offices_at_renewa_t.AutoSize = true;
            this.con_no_post_offices_at_renewa_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_post_offices_at_renewa_t.Location = new System.Drawing.Point(380, 43);
            this.con_no_post_offices_at_renewa_t.Name = "con_no_post_offices_at_renewa_t";
            this.con_no_post_offices_at_renewa_t.Size = new System.Drawing.Size(64, 13);
            this.con_no_post_offices_at_renewa_t.TabIndex = 176;
            this.con_no_post_offices_at_renewa_t.Text = "Post Offices";
            this.con_no_post_offices_at_renewa_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_renewal_payment_value_t
            // 
            this.con_renewal_payment_value_t.AutoSize = true;
            this.con_renewal_payment_value_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_renewal_payment_value_t.Location = new System.Drawing.Point(15, 69);
            this.con_renewal_payment_value_t.Name = "con_renewal_payment_value_t";
            this.con_renewal_payment_value_t.Size = new System.Drawing.Size(78, 13);
            this.con_renewal_payment_value_t.TabIndex = 177;
            this.con_renewal_payment_value_t.Text = "Payment Value";
            this.con_renewal_payment_value_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_no_rural_private_bags_at__t
            // 
            this.con_no_rural_private_bags_at__t.AutoSize = true;
            this.con_no_rural_private_bags_at__t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_rural_private_bags_at__t.Location = new System.Drawing.Point(167, 69);
            this.con_no_rural_private_bags_at__t.Name = "con_no_rural_private_bags_at__t";
            this.con_no_rural_private_bags_at__t.Size = new System.Drawing.Size(95, 13);
            this.con_no_rural_private_bags_at__t.TabIndex = 164;
            this.con_no_rural_private_bags_at__t.Text = "Rural Private Bags";
            this.con_no_rural_private_bags_at__t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_no_cmbs_at_renewal_t
            // 
            this.con_no_cmbs_at_renewal_t.AutoSize = true;
            this.con_no_cmbs_at_renewal_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_cmbs_at_renewal_t.Location = new System.Drawing.Point(403, 69);
            this.con_no_cmbs_at_renewal_t.Name = "con_no_cmbs_at_renewal_t";
            this.con_no_cmbs_at_renewal_t.Size = new System.Drawing.Size(41, 13);
            this.con_no_cmbs_at_renewal_t.TabIndex = 165;
            this.con_no_cmbs_at_renewal_t.Text = "C.M.Bs";
            this.con_no_cmbs_at_renewal_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_volume_at_renewal_t
            // 
            this.con_volume_at_renewal_t.AutoSize = true;
            this.con_volume_at_renewal_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_volume_at_renewal_t.Location = new System.Drawing.Point(51, 95);
            this.con_volume_at_renewal_t.Name = "con_volume_at_renewal_t";
            this.con_volume_at_renewal_t.Size = new System.Drawing.Size(42, 13);
            this.con_volume_at_renewal_t.TabIndex = 163;
            this.con_volume_at_renewal_t.Text = "Volume";
            this.con_volume_at_renewal_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_no_other_bags_at_renewal_t
            // 
            this.con_no_other_bags_at_renewal_t.AutoSize = true;
            this.con_no_other_bags_at_renewal_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_other_bags_at_renewal_t.Location = new System.Drawing.Point(202, 95);
            this.con_no_other_bags_at_renewal_t.Name = "con_no_other_bags_at_renewal_t";
            this.con_no_other_bags_at_renewal_t.Size = new System.Drawing.Size(60, 13);
            this.con_no_other_bags_at_renewal_t.TabIndex = 161;
            this.con_no_other_bags_at_renewal_t.Text = "Other Bags";
            this.con_no_other_bags_at_renewal_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_no_cmb_custs_at_renewal_t
            // 
            this.con_no_cmb_custs_at_renewal_t.AutoSize = true;
            this.con_no_cmb_custs_at_renewal_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_cmb_custs_at_renewal_t.Location = new System.Drawing.Point(351, 95);
            this.con_no_cmb_custs_at_renewal_t.Name = "con_no_cmb_custs_at_renewal_t";
            this.con_no_cmb_custs_at_renewal_t.Size = new System.Drawing.Size(88, 13);
            this.con_no_cmb_custs_at_renewal_t.TabIndex = 162;
            this.con_no_cmb_custs_at_renewal_t.Text = "C.M.B Customers";
            this.con_no_cmb_custs_at_renewal_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_del_hrs_week_at_renewal_t
            // 
            this.con_del_hrs_week_at_renewal_t.AutoSize = true;
            this.con_del_hrs_week_at_renewal_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_del_hrs_week_at_renewal_t.Location = new System.Drawing.Point(17, 120);
            this.con_del_hrs_week_at_renewal_t.Name = "con_del_hrs_week_at_renewal_t";
            this.con_del_hrs_week_at_renewal_t.Size = new System.Drawing.Size(76, 13);
            this.con_del_hrs_week_at_renewal_t.TabIndex = 169;
            this.con_del_hrs_week_at_renewal_t.Text = "Del Hrs/Week";
            this.con_del_hrs_week_at_renewal_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_rg_code_at_renewal_t
            // 
            this.con_rg_code_at_renewal_t.AutoSize = true;
            this.con_rg_code_at_renewal_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_rg_code_at_renewal_t.Location = new System.Drawing.Point(181, 120);
            this.con_rg_code_at_renewal_t.Name = "con_rg_code_at_renewal_t";
            this.con_rg_code_at_renewal_t.Size = new System.Drawing.Size(81, 13);
            this.con_rg_code_at_renewal_t.TabIndex = 170;
            this.con_rg_code_at_renewal_t.Text = "Renewal Group";
            this.con_rg_code_at_renewal_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;


            // 
            // con_rg_code_at_renewal_t2
            // 
            //? this.con_rg_code_at_renewal_t2.AutoSize = true;
            this.con_rg_code_at_renewal_t2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_rg_code_at_renewal_t2.Location = new System.Drawing.Point(269, 120);
            this.con_rg_code_at_renewal_t2.Name = "con_rg_code_at_renewal_t2";
            this.con_rg_code_at_renewal_t2.Size = new System.Drawing.Size(108, 22);
            this.con_rg_code_at_renewal_t2.TabIndex = 170;
            this.con_rg_code_at_renewal_t2.Text = "";
            this.con_rg_code_at_renewal_t2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // con_rg_code_at_renewal
            // 
            this.con_rg_code_at_renewal.AutoRetrieve = true;
            this.con_rg_code_at_renewal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConRgCodeAtRenewal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_rg_code_at_renewal.DisplayMember = "RgDescription";
            this.con_rg_code_at_renewal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //?this.con_rg_code_at_renewal.Enabled = false;
            this.con_rg_code_at_renewal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_rg_code_at_renewal.Location = new System.Drawing.Point(269, 120);
            this.con_rg_code_at_renewal.Name = "con_rg_code_at_renewal";
            this.con_rg_code_at_renewal.Size = new System.Drawing.Size(108, 21);
            this.con_rg_code_at_renewal.TabIndex = 168;
            this.con_rg_code_at_renewal.Value = null;
            this.con_rg_code_at_renewal.TextChanged += new System.EventHandler(con_rg_code_at_renewal_TextChanged);
            this.con_rg_code_at_renewal.ValueMember = "RgCode";
            // 
            // t_2
            // 
            this.t_2.AutoSize = true;
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.Location = new System.Drawing.Point(408, 120);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(36, 13);
            this.t_2.TabIndex = 166;
            this.t_2.Text = "Dated";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // con_rates_effective_date
            // 
            this.con_rates_effective_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.con_rates_effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConRatesEffectiveDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_rates_effective_date.ReadOnly = true;//.Enabled = false;
            this.con_rates_effective_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_rates_effective_date.Location = new System.Drawing.Point(453, 122);
            this.con_rates_effective_date.Mask = "00/00/0000";
            this.con_rates_effective_date.Name = "con_rates_effective_date";
            //this.con_rates_effective_date.PromptChar = '0';
            this.con_rates_effective_date.Size = new System.Drawing.Size(73, 13);
            //this.con_rates_effective_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.con_rates_effective_date.TabIndex = 167;
            // 
            // con_no_private_bags_at_renewa
            // 
            this.con_no_private_bags_at_renewa.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConNoPrivateBagsAtRenewa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_no_private_bags_at_renewa.EditMask = "#,###";
            this.con_no_private_bags_at_renewa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_private_bags_at_renewa.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_no_private_bags_at_renewa.Location = new System.Drawing.Point(449, 18);
            this.con_no_private_bags_at_renewa.Name = "con_no_private_bags_at_renewa";
            this.con_no_private_bags_at_renewa.PromptChar = ' ';
            this.con_no_private_bags_at_renewa.Size = new System.Drawing.Size(61, 20);
            this.con_no_private_bags_at_renewa.TabIndex = 187;
            this.con_no_private_bags_at_renewa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_no_private_bags_at_renewa.Value = "";
            this.con_no_private_bags_at_renewa.DataBindings[0].DataSourceNullValue = 0;
            // 
            // con_no_post_offices_at_renewa
            // 
            this.con_no_post_offices_at_renewa.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConNoPostOfficesAtRenewa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_no_post_offices_at_renewa.EditMask = "#,###";
            this.con_no_post_offices_at_renewa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_post_offices_at_renewa.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_no_post_offices_at_renewa.Location = new System.Drawing.Point(449, 43);
            this.con_no_post_offices_at_renewa.Name = "con_no_post_offices_at_renewa";
            this.con_no_post_offices_at_renewa.PromptChar = ' ';
            this.con_no_post_offices_at_renewa.Size = new System.Drawing.Size(61, 20);
            this.con_no_post_offices_at_renewa.TabIndex = 188;
            this.con_no_post_offices_at_renewa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_no_post_offices_at_renewa.Value = "";
            this.con_no_post_offices_at_renewa.DataBindings[0].DataSourceNullValue = 0;
            // 
            // con_no_cmbs_at_renewal
            // 
            this.con_no_cmbs_at_renewal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConNoCmbsAtRenewal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_no_cmbs_at_renewal.EditMask = "#,###";
            this.con_no_cmbs_at_renewal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_cmbs_at_renewal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_no_cmbs_at_renewal.Location = new System.Drawing.Point(450, 70);
            this.con_no_cmbs_at_renewal.Name = "con_no_cmbs_at_renewal";
            this.con_no_cmbs_at_renewal.PromptChar = ' ';
            this.con_no_cmbs_at_renewal.Size = new System.Drawing.Size(61, 20);
            this.con_no_cmbs_at_renewal.TabIndex = 189;
            this.con_no_cmbs_at_renewal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_no_cmbs_at_renewal.Value = "";
            this.con_no_cmbs_at_renewal.DataBindings[0].DataSourceNullValue = 0;
            // 
            // con_no_cmb_custs_at_renewal
            // 
            this.con_no_cmb_custs_at_renewal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConNoCmbCustsAtRenewal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_no_cmb_custs_at_renewal.EditMask = "#,###";
            this.con_no_cmb_custs_at_renewal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_cmb_custs_at_renewal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_no_cmb_custs_at_renewal.Location = new System.Drawing.Point(449, 96);
            this.con_no_cmb_custs_at_renewal.Name = "con_no_cmb_custs_at_renewal";
            this.con_no_cmb_custs_at_renewal.PromptChar = ' ';
            this.con_no_cmb_custs_at_renewal.Size = new System.Drawing.Size(61, 20);
            this.con_no_cmb_custs_at_renewal.TabIndex = 190;
            this.con_no_cmb_custs_at_renewal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_no_cmb_custs_at_renewal.Value = "";
            this.con_no_cmb_custs_at_renewal.DataBindings[0].DataSourceNullValue = 0;
            // 
            // con_no_other_bags_at_renewal
            // 
            this.con_no_other_bags_at_renewal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConNoOtherBagsAtRenewal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_no_other_bags_at_renewal.EditMask = "#,###";
            this.con_no_other_bags_at_renewal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_other_bags_at_renewal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_no_other_bags_at_renewal.Location = new System.Drawing.Point(270, 96);
            this.con_no_other_bags_at_renewal.Name = "con_no_other_bags_at_renewal";
            this.con_no_other_bags_at_renewal.PromptChar = ' ';
            this.con_no_other_bags_at_renewal.Size = new System.Drawing.Size(61, 20);
            this.con_no_other_bags_at_renewal.TabIndex = 186;
            this.con_no_other_bags_at_renewal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_no_other_bags_at_renewal.Value = "";
            this.con_no_other_bags_at_renewal.DataBindings[0].DataSourceNullValue = 0;

            // 
            // con_no_rural_private_bags_at_
            // 
            this.con_no_rural_private_bags_at_.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConNoRuralPrivateBagsAt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_no_rural_private_bags_at_.EditMask = "#,###";
            this.con_no_rural_private_bags_at_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_rural_private_bags_at_.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_no_rural_private_bags_at_.Location = new System.Drawing.Point(269, 70);
            this.con_no_rural_private_bags_at_.Name = "con_no_rural_private_bags_at_";
            this.con_no_rural_private_bags_at_.PromptChar = ' ';
            this.con_no_rural_private_bags_at_.Size = new System.Drawing.Size(61, 20);
            this.con_no_rural_private_bags_at_.TabIndex = 185;
            this.con_no_rural_private_bags_at_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_no_rural_private_bags_at_.Value = "";
            this.con_no_rural_private_bags_at_.DataBindings[0].DataSourceNullValue = 0;

            // 
            // con_no_customers_at_renewal
            // 
            this.con_no_customers_at_renewal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConNoCustomersAtRenewal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_no_customers_at_renewal.EditMask = "####";
            this.con_no_customers_at_renewal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_no_customers_at_renewal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_no_customers_at_renewal.Location = new System.Drawing.Point(270, 43);
            this.con_no_customers_at_renewal.Name = "con_no_customers_at_renewal";
            this.con_no_customers_at_renewal.PromptChar = ' ';
            this.con_no_customers_at_renewal.Size = new System.Drawing.Size(61, 20);
            this.con_no_customers_at_renewal.TabIndex = 184;
            this.con_no_customers_at_renewal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_no_customers_at_renewal.Value = "";

            // 
            // con_renewal_payment_value
            // 
            this.con_renewal_payment_value.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConRenewalPaymentValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.con_renewal_payment_value.DataBindings[0].FormatString = "$###,###.00";
            this.con_renewal_payment_value.EditMask = "$###,###.00";
            this.con_renewal_payment_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_renewal_payment_value.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_renewal_payment_value.Location = new System.Drawing.Point(100, 70);
            this.con_renewal_payment_value.Name = "con_renewal_payment_value";
            this.con_renewal_payment_value.PromptChar = ' ';
            this.con_renewal_payment_value.Size = new System.Drawing.Size(61, 20);
            this.con_renewal_payment_value.TabIndex = 181;
            this.con_renewal_payment_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_renewal_payment_value.Value = "";
            this.con_renewal_payment_value.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;

            // 
            // con_volume_at_renewal
            // 
            this.con_volume_at_renewal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConVolumeAtRenewal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_volume_at_renewal.EditMask = "###,###";
            //this.con_volume_at_renewal.DataBindings[0].FormatString = "###,###";
            this.con_volume_at_renewal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_volume_at_renewal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_volume_at_renewal.Location = new System.Drawing.Point(99, 96);
            this.con_volume_at_renewal.Name = "con_volume_at_renewal";
            this.con_volume_at_renewal.PromptChar = ' ';
            this.con_volume_at_renewal.Size = new System.Drawing.Size(61, 20);
            this.con_volume_at_renewal.TabIndex = 182;
            this.con_volume_at_renewal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_volume_at_renewal.Value = "";
            // 
            // con_del_hrs_week_at_renewal
            // 
            this.con_del_hrs_week_at_renewal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConDelHrsWeekAtRenewal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_del_hrs_week_at_renewal.EditMask = "##.00";
            this.con_del_hrs_week_at_renewal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_del_hrs_week_at_renewal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.con_del_hrs_week_at_renewal.Location = new System.Drawing.Point(99, 122);
            this.con_del_hrs_week_at_renewal.Name = "con_del_hrs_week_at_renewal";
            this.con_del_hrs_week_at_renewal.PromptChar = ' ';
            this.con_del_hrs_week_at_renewal.Size = new System.Drawing.Size(61, 20);
            this.con_del_hrs_week_at_renewal.TabIndex = 183;
            this.con_del_hrs_week_at_renewal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.con_del_hrs_week_at_renewal.Value = "";
            // 
            // contract_no_t
            // 
            this.contract_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.contract_no_t.Location = new System.Drawing.Point(0, 5);
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Size = new System.Drawing.Size(60, 13);
            this.contract_no_t.TabIndex = 161;
            this.contract_no_t.Text = "Contract";
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contracttitle
            // 
            this.contracttitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.contracttitle.Location = new System.Drawing.Point(61, 5);
            this.contracttitle.Name = "contracttitle";
            this.contracttitle.Size = new System.Drawing.Size(500, 13);
            this.contracttitle.TabIndex = 161;
            this.contracttitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DRenewal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contract_no_t);
            this.Controls.Add(this.contracttitle);
            this.Controls.Add(this.gb_1);
            this.Controls.Add(this.gb_2);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.gb_3);
            this.Controls.Add(this.gb_4);
            this.Name = "DRenewal";
            this.Size = new System.Drawing.Size(574, 314);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.gb_2.ResumeLayout(false);
            this.gb_2.PerformLayout();
            this.gb_3.ResumeLayout(false);
            this.gb_3.PerformLayout();
            this.gb_4.ResumeLayout(false);
            this.gb_4.PerformLayout();
            this.ResumeLayout(false);

        }

        void con_rg_code_at_renewal_TextChanged(object sender, System.EventArgs e)
        {
            if (this.con_rg_code_at_renewal_t2.Visible)
                this.con_rg_code_at_renewal_t2.Text = this.con_rg_code_at_renewal.Text;
        }



        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (this.RowCount > 0)
            {
                //string( contract_no ) + "/" + string( contract_seq_number ) + ' ' + (con_title)
                contracttitle.Text = ((Metex.Windows.DataUserControl)(this)).GetItem<Renewal>(0).ContractNo.ToString() + "/" + ((Metex.Windows.DataUserControl)(this)).GetItem<Renewal>(0).ContractSeqNumber.ToString() + " " + ((Metex.Windows.DataUserControl)(this)).GetItem<Renewal>(0).ConTitle;
                //if( con_acceptance_flag = 'Y' and con_start_date <= today(), 1,0)
                if (((Metex.Windows.DataUserControl)(this)).GetItem<Renewal>(0).ConStartDate != null)
                {
                    if (((Metex.Windows.DataUserControl)(this)).GetItem<Renewal>(0).ConAcceptanceFlag == true && ((Metex.Windows.DataUserControl)(this)).GetItem<Renewal>(0).ConStartDate.Value <= System.DateTime.Today)
                    {
                        this.con_acceptance_flag.AutoCheck = false;// Enabled = false;
                    }
                    else
                    {
                        this.con_acceptance_flag.AutoCheck = true;// Enabled = true;
                    }
                }
                //if( con_acceptance_flag = 'Y' and describe('st_fullaccess.text') = 'N', 1, 0)
                if (((Metex.Windows.DataUserControl)(this)).GetItem<Renewal>(0).ConAcceptanceFlag == true && st_fullaccess.Text == "N")
                {
                    con_expiry_date.ReadOnly = true;
                    con_expiry_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
                else
                {
                    con_expiry_date.ReadOnly = false;
                    con_expiry_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                }
                //if( con_acceptance_flag = 'Y', 1,0)
                if (((Metex.Windows.DataUserControl)(this)).GetItem<Renewal>(0).ConAcceptanceFlag == true)
                {
                    con_renewal_payment_value.ReadOnly = true;
                    con_renewal_payment_value.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    con_volume_at_renewal.ReadOnly = true;
                    con_volume_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    con_del_hrs_week_at_renewal.ReadOnly = true;
                    con_del_hrs_week_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    con_no_customers_at_renewal.ReadOnly = true;
                    con_no_customers_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    con_no_rural_private_bags_at_.ReadOnly = true;
                    con_no_rural_private_bags_at_.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    con_no_other_bags_at_renewal.ReadOnly = true;
                    con_no_other_bags_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    con_no_private_bags_at_renewa.ReadOnly = true;
                    con_no_private_bags_at_renewa.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    con_no_post_offices_at_renewa.ReadOnly = true;
                    con_no_post_offices_at_renewa.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    con_no_cmbs_at_renewal.ReadOnly = true;
                    con_no_cmbs_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    con_no_cmb_custs_at_renewal.ReadOnly = true;
                    con_no_cmb_custs_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    //con_start_date.ReadOnly = true;
                    con_start_date.ReadOnly = true;//.Enabled = false;
                    con_start_date.BorderStyle = System.Windows.Forms.BorderStyle.None;

                    this.con_rg_code_at_renewal_t2.Text = this.con_rg_code_at_renewal.Text;
                }
                else
                {
                    con_renewal_payment_value.ReadOnly = false;
                    con_renewal_payment_value.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    con_del_hrs_week_at_renewal.ReadOnly = false;
                    con_del_hrs_week_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    con_volume_at_renewal.ReadOnly = false;
                    con_volume_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    con_no_customers_at_renewal.ReadOnly = false;
                    con_no_customers_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    con_no_rural_private_bags_at_.ReadOnly = false;
                    con_no_rural_private_bags_at_.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    con_no_other_bags_at_renewal.ReadOnly = false;
                    con_no_other_bags_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    con_no_private_bags_at_renewa.ReadOnly = false;
                    con_no_private_bags_at_renewa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    con_no_post_offices_at_renewa.ReadOnly = false;
                    con_no_post_offices_at_renewa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    con_no_cmbs_at_renewal.ReadOnly = false;
                    con_no_cmbs_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    con_no_cmb_custs_at_renewal.ReadOnly = false;
                    con_no_cmb_custs_at_renewal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    //con_start_date.ReadOnly = false;
                    con_start_date.ReadOnly = false;//.Enabled = true;
                    con_start_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                    this.con_rg_code_at_renewal_t2.Visible = false;
                    this.con_rg_code_at_renewal.Enabled = true;
                }
            }

        }

        #endregion

        private System.Windows.Forms.Label contracttitle;
        private System.Windows.Forms.GroupBox gb_1;
        private System.Windows.Forms.GroupBox gb_2;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.GroupBox gb_3;
        private System.Windows.Forms.GroupBox gb_4;
        private System.Windows.Forms.Label con_start_date_t;
        private System.Windows.Forms.Label con_expiry_date_t;
        private System.Windows.Forms.Label con_date_last_assigned_t;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox con_date_last_assigned;
        private System.Windows.Forms.CheckBox con_acceptance_flag;
        private System.Windows.Forms.Label con_start_pay_date_t;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox con_start_pay_date;
        private System.Windows.Forms.Label con_last_paid_date_t;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox con_last_paid_date;
        // private System.Windows.Forms.MaskedTextBox con_expiry_date;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox con_expiry_date;
        private DateTimeMaskedTextBox con_start_date;
        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.Label con_relief_driver_name_t;
        private System.Windows.Forms.Label st_fullaccess;
        private System.Windows.Forms.Label con_relief_driver_address_t;
        private System.Windows.Forms.Label con_relief_driver_home_phone_t;
        private System.Windows.Forms.TextBox con_relief_driver_name;
        private System.Windows.Forms.TextBox con_relief_driver_address;
        private System.Windows.Forms.TextBox con_relief_driver_home_phone;
        private System.Windows.Forms.Label con_processing_hours_per_week_t;
        private NumericalMaskedTextBox con_processing_hours_per_week;
        private System.Windows.Forms.Label con_distance_at_renewal_t;
        private NumericalMaskedTextBox con_distance_at_renewal;
        private System.Windows.Forms.Label con_no_private_bags_at_renewa_t;
        private System.Windows.Forms.Label con_renewal_benchmark_price_t;
        private NumericalMaskedTextBox con_renewal_benchmark_price;
        private System.Windows.Forms.Label con_no_customers_at_renewal_t;
        private System.Windows.Forms.Label con_no_post_offices_at_renewa_t;
        private System.Windows.Forms.Label con_renewal_payment_value_t;
        private System.Windows.Forms.Label con_no_rural_private_bags_at__t;
        private System.Windows.Forms.Label con_no_cmbs_at_renewal_t;
        private System.Windows.Forms.Label con_volume_at_renewal_t;
        private System.Windows.Forms.Label con_no_other_bags_at_renewal_t;
        private System.Windows.Forms.Label con_no_cmb_custs_at_renewal_t;
        private System.Windows.Forms.Label con_del_hrs_week_at_renewal_t;
        private System.Windows.Forms.Label con_rg_code_at_renewal_t;

        private System.Windows.Forms.Label con_rg_code_at_renewal_t2;

        private Metex.Windows.DataEntityCombo con_rg_code_at_renewal;
        private System.Windows.Forms.Label t_2;
        private DateTimeMaskedTextBox con_rates_effective_date;
        private NumericalMaskedTextBox con_no_private_bags_at_renewa;
        private NumericalMaskedTextBox con_no_post_offices_at_renewa;
        private NumericalMaskedTextBox con_no_cmbs_at_renewal;
        private NumericalMaskedTextBox con_no_cmb_custs_at_renewal;
        private NumericalMaskedTextBox con_no_other_bags_at_renewal;
        private NumericalMaskedTextBox con_no_rural_private_bags_at_;
        private NumericalMaskedTextBox con_no_customers_at_renewal;
        private NumericalMaskedTextBox con_renewal_payment_value;
        private NumericalMaskedTextBox con_volume_at_renewal;
        private NumericalMaskedTextBox con_del_hrs_week_at_renewal;
    }
}




