namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DwPostTaxDeductions
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

            this.startbal_flag = new System.Windows.Forms.TextBox();
            this.ded_description_t = new System.Windows.Forms.Label();
            this.ded_description = new System.Windows.Forms.TextBox();
            this.n_26347107 = new System.Windows.Forms.Label();
            this.ded_id = new System.Windows.Forms.TextBox();
            this.pct_id_t = new System.Windows.Forms.Label();
            this.pct_id = new Metex.Windows.DataEntityCombo();
            this.ded_priority_t = new System.Windows.Forms.Label();
            this.ded_priority = new System.Windows.Forms.NumericUpDown();
            this.ded_reference_t = new System.Windows.Forms.Label();
            this.ded_reference = new System.Windows.Forms.TextBox();
            this.ded_type_period_t = new System.Windows.Forms.Label();
            this.ded_start_balance_t = new System.Windows.Forms.Label();
            this.ded_start_balance = new System.Windows.Forms.TextBox();
            this.ded_end_balance_t = new System.Windows.Forms.Label();
            this.ded_end_balance = new System.Windows.Forms.TextBox();
            this.n_53740895 = new System.Windows.Forms.Label();
            this.n_13906014 = new System.Windows.Forms.Label();
            this.ded_default_minimum_t = new System.Windows.Forms.Label();
            this.ded_min_threshold_gross_t = new System.Windows.Forms.Label();
            this.n_58045264 = new System.Windows.Forms.Label();
            this.ded_max_threshold_net_pct_t = new System.Windows.Forms.Label();
            this.n_52645336 = new System.Windows.Forms.Label();
            this.n_4045982 = new System.Windows.Forms.Label();
            this.compute_2 = new System.Windows.Forms.TextBox();
            this.ded_pay_highest_value = new System.Windows.Forms.CheckBox();
            this.ded_default_minimum = new System.Windows.Forms.TextBox();
            this.ded_min_threshold_gross = new System.Windows.Forms.TextBox();
            this.ded_max_threshold_net_pct = new System.Windows.Forms.TextBox();
            this.ded_percent_gross_t = new System.Windows.Forms.Label();
            this.ded_percent_net_t = new System.Windows.Forms.Label();
            this.ded_fixed_amount_t = new System.Windows.Forms.Label();
            this.ded_percent_start_balance_t = new System.Windows.Forms.Label();
            this.ded_percent_start_balance = new System.Windows.Forms.TextBox();
            this.ded_fixed_amount = new System.Windows.Forms.TextBox();
            this.ded_percent_net = new System.Windows.Forms.TextBox();
            this.ded_percent_gross = new System.Windows.Forms.TextBox();
            this.n_59289136 = new System.Windows.Forms.Label();
            this.n_63840183 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            compute_1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.PostTaxDeductions);
            // 
            // compute_1
            // 
            compute_1.BackColor = System.Drawing.SystemColors.Control;
            compute_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            compute_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            compute_1.Location = new System.Drawing.Point(210, 91);
            compute_1.Name = "compute_1";
            compute_1.Size = new System.Drawing.Size(108, 13);
            compute_1.TabStop = false;
            // 
            // startbal_flag
            // 
            this.startbal_flag.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "StartbalFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.startbal_flag.Enabled = false;
            this.startbal_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.startbal_flag.Location = new System.Drawing.Point(508, 43);
            this.startbal_flag.Name = "startbal_flag";
            this.startbal_flag.Size = new System.Drawing.Size(57, 20);
            this.startbal_flag.TabIndex = 0;
            this.startbal_flag.Visible = false;
            // 
            // ded_description_t
            // 
            this.ded_description_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_description_t.Location = new System.Drawing.Point(3, 2);
            this.ded_description_t.Name = "ded_description_t";
            this.ded_description_t.Size = new System.Drawing.Size(89, 13);
            //this.ded_description_t.TabIndex = 0;
            this.ded_description_t.Text = "Description:";
            this.ded_description_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ded_description
            // 
            this.ded_description.BackColor = System.Drawing.Color.Aqua;
            this.ded_description.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_description.Location = new System.Drawing.Point(134, 2);
            this.ded_description.MaxLength = 200;
            this.ded_description.Name = "ded_description";
            this.ded_description.Size = new System.Drawing.Size(346, 20);
            this.ded_description.TabIndex = 0;
            // 
            // n_26347107
            // 
            this.n_26347107.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_26347107.Location = new System.Drawing.Point(501, 3);
            this.n_26347107.Name = "n_26347107";
            this.n_26347107.Size = new System.Drawing.Size(21, 13);
            //  this.n_26347107.TabIndex = 0;
            this.n_26347107.Text = "ID:";
            this.n_26347107.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ded_id
            // 
            this.ded_id.BackColor = System.Drawing.SystemColors.Control;
            this.ded_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_id.Enabled = false;
            this.ded_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.ded_id.Location = new System.Drawing.Point(522, 2);
            this.ded_id.Name = "ded_id";
            this.ded_id.Size = new System.Drawing.Size(50, 13);
            this.ded_id.TabIndex = 0;
            // 
            // pct_id_t
            // 
            this.pct_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pct_id_t.Location = new System.Drawing.Point(3, 23);
            this.pct_id_t.Name = "pct_id_t";
            this.pct_id_t.Size = new System.Drawing.Size(122, 13);
            //this.pct_id_t.TabIndex = 0;
            this.pct_id_t.Text = "Pay Component Type:";
            this.pct_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pct_id
            // 
            this.pct_id.AutoRetrieve = true;
            this.pct_id.BackColor = System.Drawing.Color.Aqua;
            this.pct_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "PctId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pct_id.DisplayMember = "PctDescription";
            this.pct_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pct_id.Location = new System.Drawing.Point(134, 23);
            this.pct_id.Name = "pct_id";
            this.pct_id.Size = new System.Drawing.Size(262, 21);
            this.pct_id.TabIndex = 1;
            this.pct_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //this.pct_id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            //this.pct_id.Value = null;
            this.pct_id.ValueMember = "PctId";
            this.pct_id.SelectedIndexChanged += new System.EventHandler(pct_id_SelectedIndexChanged);//add by ybfan
            this.pct_id.Click += new System.EventHandler(pct_id_Click);
            this.pct_id.LostFocus += new System.EventHandler(pct_id_LostFocus);
            // 
            // ded_priority_t
            // 
            this.ded_priority_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_priority_t.Location = new System.Drawing.Point(386, 26);
            this.ded_priority_t.Name = "ded_priority_t";
            this.ded_priority_t.Size = new System.Drawing.Size(58, 13);
            //this.ded_priority_t.TabIndex = 0;
            this.ded_priority_t.Text = "Priority:";
            this.ded_priority_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_priority
            // 
            this.ded_priority.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedPriority", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_priority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_priority.Location = new System.Drawing.Point(444, 24);
            this.ded_priority.Name = "ded_priority";
            this.ded_priority.Size = new System.Drawing.Size(35, 20);
            this.ded_priority.TabIndex = 2;
            this.ded_priority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ded_reference_t
            // 
            this.ded_reference_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_reference_t.Location = new System.Drawing.Point(3, 46);
            this.ded_reference_t.Name = "ded_reference_t";
            this.ded_reference_t.Size = new System.Drawing.Size(80, 13);
            // this.ded_reference_t.TabIndex = 0;
            this.ded_reference_t.Text = "Reference:";
            this.ded_reference_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ded_reference
            // 
            this.ded_reference.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedReference", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_reference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_reference.Location = new System.Drawing.Point(134, 46);
            this.ded_reference.MaxLength = 200;
            this.ded_reference.Name = "ded_reference";
            this.ded_reference.Size = new System.Drawing.Size(346, 20);
            this.ded_reference.TabIndex = 3;
            // 
            // ded_type_period_t
            // 
            this.ded_type_period_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_type_period_t.Location = new System.Drawing.Point(3, 73);
            this.ded_type_period_t.Name = "ded_type_period_t";
            this.ded_type_period_t.Size = new System.Drawing.Size(93, 13);
            //this.ded_type_period_t.TabIndex = 0;
            this.ded_type_period_t.Text = "Period Type:";
            this.ded_type_period_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ded_start_balance_t
            // 
            this.ded_start_balance_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_start_balance_t.Location = new System.Drawing.Point(3, 96);
            this.ded_start_balance_t.Name = "ded_start_balance_t";
            this.ded_start_balance_t.Size = new System.Drawing.Size(100, 13);
            this.ded_start_balance_t.TabIndex = 0;
            this.ded_start_balance_t.Text = "Total Amount:";
            this.ded_start_balance_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ded_start_balance
            // 
            this.ded_start_balance.BackColor = System.Drawing.Color.Aqua;
            this.ded_start_balance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedStartBalance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_start_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_start_balance.Location = new System.Drawing.Point(133, 94);
            this.ded_start_balance.Name = "ded_start_balance";
            this.ded_start_balance.Size = new System.Drawing.Size(74, 20);
            this.ded_start_balance.TabIndex = 6;
            this.ded_start_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ded_end_balance_t
            // 
            this.ded_end_balance_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_end_balance_t.Location = new System.Drawing.Point(326, 94);
            this.ded_end_balance_t.Name = "ded_end_balance_t";
            this.ded_end_balance_t.Size = new System.Drawing.Size(93, 13);
            //this.ded_end_balance_t.TabIndex = 0;
            this.ded_end_balance_t.Text = "Ending Balance:";
            this.ded_end_balance_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ded_end_balance
            // 
            this.ded_end_balance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedEndBalance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_end_balance.Enabled = false;
            this.ded_end_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_end_balance.Location = new System.Drawing.Point(422, 92);
            this.ded_end_balance.Name = "ded_end_balance";
            this.ded_end_balance.Size = new System.Drawing.Size(76, 20);
            this.ded_end_balance.TabIndex = 0;
            this.ded_end_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // n_53740895
            // 
            this.n_53740895.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_53740895.Location = new System.Drawing.Point(3, 10);
            this.n_53740895.Name = "n_53740895";
            this.n_53740895.Size = new System.Drawing.Size(18, 13);
            //this.n_53740895.TabIndex = 0;
            this.n_53740895.Text = "A. ";
            this.n_53740895.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // n_13906014
            // 
            this.n_13906014.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_13906014.Location = new System.Drawing.Point(6, 9);
            this.n_13906014.Name = "n_13906014";
            this.n_13906014.Size = new System.Drawing.Size(121, 33);
            //this.n_13906014.TabIndex = 0;
            this.n_13906014.Text = "B. Selected if A.  fails Special Rules";
            this.n_13906014.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ded_default_minimum_t
            // 
            //?this.ded_default_minimum_t.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ded_default_minimum_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_default_minimum_t.Location = new System.Drawing.Point(10, 55);
            this.ded_default_minimum_t.Name = "ded_default_minimum_t";
            this.ded_default_minimum_t.Size = new System.Drawing.Size(114, 17);
            this.ded_default_minimum_t.TabIndex = 0;
            this.ded_default_minimum_t.Text = "Default Min Amount";
            this.ded_default_minimum_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ded_min_threshold_gross_t
            // 
            this.ded_min_threshold_gross_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_min_threshold_gross_t.Location = new System.Drawing.Point(3, 24);
            this.ded_min_threshold_gross_t.Name = "ded_min_threshold_gross_t";
            this.ded_min_threshold_gross_t.Size = new System.Drawing.Size(160, 26);
            //this.ded_min_threshold_gross_t.TabIndex = 0;
            this.ded_min_threshold_gross_t.Text = "Min Gross/Net Threshold($)\r\nif % of Gross or Net is specified";
            this.ded_min_threshold_gross_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_58045264
            // 
            this.n_58045264.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_58045264.Location = new System.Drawing.Point(239, 24);
            this.n_58045264.Name = "n_58045264";
            this.n_58045264.Size = new System.Drawing.Size(209, 35);
            //this.n_58045264.TabIndex = 0;
            this.n_58045264.Text = "(% of Gross cannot be applied if gross/net pay is less than this amount)";
            this.n_58045264.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ded_max_threshold_net_pct_t
            // 
            this.ded_max_threshold_net_pct_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_max_threshold_net_pct_t.Location = new System.Drawing.Point(2, 63);
            this.ded_max_threshold_net_pct_t.Name = "ded_max_threshold_net_pct_t";
            this.ded_max_threshold_net_pct_t.Size = new System.Drawing.Size(157, 13);
            this.ded_max_threshold_net_pct_t.TabIndex = 0;
            this.ded_max_threshold_net_pct_t.Text = "Min Net Threshold(%)";
            this.ded_max_threshold_net_pct_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_52645336
            // 
            this.n_52645336.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_52645336.Location = new System.Drawing.Point(239, 63);
            this.n_52645336.Name = "n_52645336";
            this.n_52645336.Size = new System.Drawing.Size(209, 32);
            //  this.n_52645336.TabIndex = 0;
            this.n_52645336.Text = "(Net pay must not be reduced to less than this %)";
            this.n_52645336.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_4045982
            // 
            this.n_4045982.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_4045982.Location = new System.Drawing.Point(3, 123);
            this.n_4045982.Name = "n_4045982";
            this.n_4045982.Size = new System.Drawing.Size(162, 13);
            //this.n_4045982.TabIndex = 0;
            this.n_4045982.Text = "Amount for Evaluation";
            this.n_4045982.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // compute_2
            // 
            this.compute_2.BackColor = System.Drawing.SystemColors.Control;
            this.compute_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_2.Location = new System.Drawing.Point(0, 138);
            this.compute_2.Name = "compute_2";
            this.compute_2.Size = new System.Drawing.Size(69, 13);
            this.compute_2.TabStop = false;
            // 
            // ded_pay_highest_value
            // 
            this.ded_pay_highest_value.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DedPayHighestValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_pay_highest_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_pay_highest_value.Location = new System.Drawing.Point(3, 162);
            this.ded_pay_highest_value.Name = "ded_pay_highest_value";
            this.ded_pay_highest_value.Size = new System.Drawing.Size(117, 17);
            this.ded_pay_highest_value.TabIndex = 7;
            this.ded_pay_highest_value.Text = "Pay highest value";
            this.ded_pay_highest_value.ThreeState = true;
            // 
            // ded_default_minimum
            // 
            this.ded_default_minimum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedDefaultMinimum", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_default_minimum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_default_minimum.Location = new System.Drawing.Point(35, 78);
            this.ded_default_minimum.Name = "ded_default_minimum";
            this.ded_default_minimum.Size = new System.Drawing.Size(68, 20);
            this.ded_default_minimum.TabIndex = 14;
            this.ded_default_minimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ded_default_minimum.DataBindings[0].FormatString = ".00";
            // 
            // ded_min_threshold_gross
            // 
            this.ded_min_threshold_gross.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedMinThresholdGross", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_min_threshold_gross.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_min_threshold_gross.Location = new System.Drawing.Point(169, 26);
            this.ded_min_threshold_gross.Name = "ded_min_threshold_gross";
            this.ded_min_threshold_gross.Size = new System.Drawing.Size(62, 20);
            this.ded_min_threshold_gross.TabIndex = 16;
            this.ded_min_threshold_gross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ded_min_threshold_gross.DataBindings[0].FormatString = "##0.00";
            this.ded_min_threshold_gross.DataBindings[0].NullValue = "";

            // 
            // ded_max_threshold_net_pct
            // 
            this.ded_max_threshold_net_pct.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedMaxThresholdNetPct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_max_threshold_net_pct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_max_threshold_net_pct.Location = new System.Drawing.Point(185, 63);
            this.ded_max_threshold_net_pct.Name = "ded_max_threshold_net_pct";
            this.ded_max_threshold_net_pct.Size = new System.Drawing.Size(46, 20);
            this.ded_max_threshold_net_pct.TabIndex = 17;
            this.ded_max_threshold_net_pct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ded_max_threshold_net_pct.DataBindings[0].FormatString = "##0.00";
            this.ded_max_threshold_net_pct.DataBindings[0].NullValue = "";
            // 
            // ded_percent_gross_t
            // 
            this.ded_percent_gross_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_percent_gross_t.Location = new System.Drawing.Point(26, 25);
            this.ded_percent_gross_t.Name = "ded_percent_gross_t";
            this.ded_percent_gross_t.Size = new System.Drawing.Size(75, 13);
            this.ded_percent_gross_t.TabIndex = 0;
            this.ded_percent_gross_t.Text = "%of Gross";
            this.ded_percent_gross_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ded_percent_net_t
            // 
            this.ded_percent_net_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_percent_net_t.Location = new System.Drawing.Point(26, 44);
            this.ded_percent_net_t.Name = "ded_percent_net_t";
            this.ded_percent_net_t.Size = new System.Drawing.Size(60, 13);
            this.ded_percent_net_t.TabIndex = 0;
            this.ded_percent_net_t.Text = "% of Net";
            this.ded_percent_net_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ded_fixed_amount_t
            // 
            this.ded_fixed_amount_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_fixed_amount_t.Location = new System.Drawing.Point(26, 64);
            this.ded_fixed_amount_t.Name = "ded_fixed_amount_t";
            this.ded_fixed_amount_t.Size = new System.Drawing.Size(100, 13);
            // this.ded_fixed_amount_t.TabIndex = 0;
            this.ded_fixed_amount_t.Text = "Fixed Amount";
            this.ded_fixed_amount_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ded_percent_start_balance_t
            // 
            this.ded_percent_start_balance_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_percent_start_balance_t.Location = new System.Drawing.Point(26, 84);
            this.ded_percent_start_balance_t.Name = "ded_percent_start_balance_t";
            this.ded_percent_start_balance_t.Size = new System.Drawing.Size(100, 13);
            // this.ded_percent_start_balance_t.TabIndex = 0;
            this.ded_percent_start_balance_t.Text = "% of Total Amount";
            this.ded_percent_start_balance_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ded_percent_start_balance
            // 
            this.ded_percent_start_balance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedPercentStartBalance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_percent_start_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_percent_start_balance.Location = new System.Drawing.Point(124, 84);
            this.ded_percent_start_balance.Name = "ded_percent_start_balance";
            this.ded_percent_start_balance.Size = new System.Drawing.Size(68, 20);
            this.ded_percent_start_balance.TabIndex = 12;
            this.ded_percent_start_balance.DataBindings[0].FormatString = ".00";
            // 
            // ded_fixed_amount
            // 
            this.ded_fixed_amount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedFixedAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_fixed_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_fixed_amount.Location = new System.Drawing.Point(124, 64);
            this.ded_fixed_amount.Name = "ded_fixed_amount";
            this.ded_fixed_amount.Size = new System.Drawing.Size(68, 20);
            this.ded_fixed_amount.TabIndex = 11;
            this.ded_fixed_amount.DataBindings[0].FormatString = ".00";

            // 
            // ded_percent_net
            // 
            this.ded_percent_net.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedPercentNet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_percent_net.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_percent_net.Location = new System.Drawing.Point(124, 44);
            this.ded_percent_net.Name = "ded_percent_net";
            this.ded_percent_net.Size = new System.Drawing.Size(68, 20);
            this.ded_percent_net.TabIndex = 10;
            this.ded_percent_net.DataBindings[0].FormatString = ".00";

            // 
            // ded_percent_gross
            // 
            this.ded_percent_gross.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedPercentGross", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_percent_gross.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ded_percent_gross.Location = new System.Drawing.Point(124, 24);
            this.ded_percent_gross.Name = "ded_percent_gross";
            this.ded_percent_gross.Size = new System.Drawing.Size(68, 20);
            this.ded_percent_gross.TabIndex = 9;
            this.ded_percent_gross.DataBindings[0].FormatString = ".00";
            // 
            // n_59289136
            // 
            this.n_59289136.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_59289136.Location = new System.Drawing.Point(3, 233);
            this.n_59289136.Name = "n_59289136";
            this.n_59289136.Size = new System.Drawing.Size(107, 13);
            // this.n_59289136.TabIndex = 0;
            this.n_59289136.Text = "Special Rules:";
            this.n_59289136.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_63840183
            // 
            this.n_63840183.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_63840183.Location = new System.Drawing.Point(3, 250);
            this.n_63840183.Name = "n_63840183";
            this.n_63840183.Size = new System.Drawing.Size(114, 29);
            // this.n_63840183.TabIndex = 0;
            this.n_63840183.Text = "(Applied to Both A. and B.)";
            this.n_63840183.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DedTypePeriod1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton1.Location = new System.Drawing.Point(-1, -1);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 17);
            this.radioButton1.TabIndex = 141;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Week";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DedTypePeriod2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton2.Location = new System.Drawing.Point(55, -1);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(55, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Month";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Location = new System.Drawing.Point(134, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 20);
            this.panel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ded_percent_gross_t);
            this.groupBox1.Controls.Add(this.ded_percent_gross);
            this.groupBox1.Controls.Add(this.ded_percent_net);
            this.groupBox1.Controls.Add(this.ded_fixed_amount);
            this.groupBox1.Controls.Add(this.ded_percent_start_balance);
            this.groupBox1.Controls.Add(this.ded_percent_start_balance_t);
            this.groupBox1.Controls.Add(this.ded_fixed_amount_t);
            this.groupBox1.Controls.Add(this.ded_percent_net_t);
            this.groupBox1.Controls.Add(this.n_53740895);
            this.groupBox1.Location = new System.Drawing.Point(134, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 112);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.n_13906014);
            this.groupBox2.Controls.Add(this.ded_default_minimum);
            this.groupBox2.Controls.Add(this.ded_default_minimum_t);
            this.groupBox2.Location = new System.Drawing.Point(453, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 112);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ded_min_threshold_gross);
            this.groupBox3.Controls.Add(this.ded_max_threshold_net_pct);
            this.groupBox3.Controls.Add(this.n_52645336);
            this.groupBox3.Controls.Add(this.ded_max_threshold_net_pct_t);
            this.groupBox3.Controls.Add(this.n_58045264);
            this.groupBox3.Controls.Add(this.ded_min_threshold_gross_t);
            this.groupBox3.Location = new System.Drawing.Point(133, 227);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(454, 100);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            // 
            // DwPostTaxDeductions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.startbal_flag);
            this.Controls.Add(this.ded_description_t);
            this.Controls.Add(this.ded_description);
            this.Controls.Add(this.n_26347107);
            this.Controls.Add(this.ded_id);
            this.Controls.Add(this.pct_id_t);
            this.Controls.Add(this.pct_id);
            this.Controls.Add(this.ded_priority_t);
            this.Controls.Add(this.ded_priority);
            this.Controls.Add(this.ded_reference_t);
            this.Controls.Add(this.ded_reference);
            this.Controls.Add(this.ded_type_period_t);
            this.Controls.Add(this.ded_start_balance_t);
            this.Controls.Add(this.ded_start_balance);
            this.Controls.Add(this.compute_1);
            this.Controls.Add(this.ded_end_balance_t);
            this.Controls.Add(this.ded_end_balance);
            this.Controls.Add(this.n_4045982);
            this.Controls.Add(this.compute_2);
            this.Controls.Add(this.ded_pay_highest_value);
            this.Controls.Add(this.n_59289136);
            this.Controls.Add(this.n_63840183);
            this.Name = "DwPostTaxDeductions";
            this.Size = new System.Drawing.Size(590, 332);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void pct_id_LostFocus(object sender, System.EventArgs e)
        {
            this.pct_id.DisplayMember = "PctDescription";
        }

        void pct_id_Click(object sender, System.EventArgs e)
        {
            if (this.pct_id.DroppedDown)
            {
                this.pct_id.DisplayMember = "";
            }
            else
            {
                this.pct_id.DisplayMember = "PctDescription";
            }
        }

        //add by ybfan
        void pct_id_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int li_index = this.pct_id.SelectedIndex;
            this.pct_id.DisplayMember = "PctDescription";
            this.pct_id.SelectedIndex = li_index;
            this.AcceptText();

            // if the column is not checked in itemchanged event below is not needed
            if (this.RowCount > 0)
            {
                this.OnItemChanged(this.pct_id, new System.EventArgs());
            }
        }
        #endregion

        private System.Windows.Forms.TextBox compute_1;
        private System.Windows.Forms.TextBox startbal_flag;
        private System.Windows.Forms.Label ded_description_t;
        private System.Windows.Forms.TextBox ded_description;
        private System.Windows.Forms.Label n_26347107;
        private System.Windows.Forms.TextBox ded_id;
        private System.Windows.Forms.Label pct_id_t;
        private Metex.Windows.DataEntityCombo pct_id;
        private System.Windows.Forms.Label ded_priority_t;
        private System.Windows.Forms.NumericUpDown ded_priority;
        private System.Windows.Forms.Label ded_reference_t;
        private System.Windows.Forms.TextBox ded_reference;
        private System.Windows.Forms.Label ded_type_period_t;
        private System.Windows.Forms.Label ded_start_balance_t;
        private System.Windows.Forms.TextBox ded_start_balance;
        private System.Windows.Forms.Label ded_end_balance_t;
        private System.Windows.Forms.TextBox ded_end_balance;
        private System.Windows.Forms.Label n_53740895;
        private System.Windows.Forms.Label n_13906014;
        private System.Windows.Forms.Label ded_default_minimum_t;
        private System.Windows.Forms.Label ded_min_threshold_gross_t;
        private System.Windows.Forms.Label n_58045264;
        private System.Windows.Forms.Label ded_max_threshold_net_pct_t;
        private System.Windows.Forms.Label n_52645336;
        private System.Windows.Forms.Label n_4045982;
        private System.Windows.Forms.TextBox compute_2;
        private System.Windows.Forms.CheckBox ded_pay_highest_value;
        private System.Windows.Forms.TextBox ded_default_minimum;
        private System.Windows.Forms.TextBox ded_min_threshold_gross;
        private System.Windows.Forms.TextBox ded_max_threshold_net_pct;
        private System.Windows.Forms.Label ded_percent_gross_t;
        private System.Windows.Forms.Label ded_percent_net_t;
        private System.Windows.Forms.Label ded_fixed_amount_t;
        private System.Windows.Forms.Label ded_percent_start_balance_t;
        private System.Windows.Forms.TextBox ded_percent_start_balance;
        private System.Windows.Forms.TextBox ded_fixed_amount;
        private System.Windows.Forms.TextBox ded_percent_net;
        private System.Windows.Forms.TextBox ded_percent_gross;
        private System.Windows.Forms.Label n_59289136;
        private System.Windows.Forms.Label n_63840183;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
