using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractArticalCountForm
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
            this.st_contract = new System.Windows.Forms.Label();
            this.t_1 = new System.Windows.Forms.Label();
            this.t_2 = new System.Windows.Forms.Label();
            this.t_3 = new System.Windows.Forms.Label();
            this.t_4 = new System.Windows.Forms.Label();
            this.ac_w1_medium_letters_t = new System.Windows.Forms.Label();
            this.ac_w1_other_envelopes_t = new System.Windows.Forms.Label();
            this.ac_w1_large_parcels_t = new System.Windows.Forms.Label();
            this.t_6 = new System.Windows.Forms.Label();
            this.ac_w1_inward_mail_t = new System.Windows.Forms.Label();
            this.ac_w1_small_parcels_t = new System.Windows.Forms.Label();
            this.contract_seq_number = new System.Windows.Forms.TextBox();
            this.compute_1 = new System.Windows.Forms.TextBox();
            this.ac_start_week_period = new System.Windows.Forms.TextBox();
            this.cust_rd_number = new System.Windows.Forms.TextBox();
            this.t_7 = new System.Windows.Forms.Label();
            this.compute_2 = new System.Windows.Forms.TextBox();
            this.compute_3 = new System.Windows.Forms.TextBox();
            this.compute_4 = new System.Windows.Forms.TextBox();
            this.compute_7 = new System.Windows.Forms.TextBox();
            this.t_8 = new System.Windows.Forms.Label();
            this.t_9 = new System.Windows.Forms.Label();
            this.ac_w1_medium_letters = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.ac_w1_other_envelopes = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.ac_w1_small_parcels = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.ac_w2_medium_letters = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.ac_w2_other_envelopes = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.ac_w2_small_parcels = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.ac_w2_inward_mail = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.ac_w1_inward_mail = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.week2del = new System.Windows.Forms.TextBox();
            this.compute_6 = new System.Windows.Forms.TextBox();
            this.ac_w1_large_parcels = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.ac_w2_large_parcels = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.compute_5 = new System.Windows.Forms.TextBox();
            this.week1del = new System.Windows.Forms.TextBox();
            this.t_5 = new System.Windows.Forms.Label();
            this.note = new System.Windows.Forms.Label();
            this.l_1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractArticalCountForm);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // st_contract
            // 
            this.st_contract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_contract.Location = new System.Drawing.Point(0, 0);
            this.st_contract.Name = "st_contract";
            this.st_contract.Size = new System.Drawing.Size(690, 12);
            this.st_contract.TabIndex = 0;
            this.st_contract.Text = "Contract No";
            this.st_contract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Arial", 8F);
            this.t_1.Location = new System.Drawing.Point(11, 22);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(50, 14);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "Renewal";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_2
            // 
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.Location = new System.Drawing.Point(66, 23);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(69, 13);
            this.t_2.TabIndex = 0;
            this.t_2.Text = "Count Period";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // t_3
            // 
            this.t_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_3.Location = new System.Drawing.Point(140, 23);
            this.t_3.Name = "t_3";
            this.t_3.Size = new System.Drawing.Size(36, 13);
            this.t_3.TabIndex = 0;
            this.t_3.Text = "Week";
            this.t_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_4
            // 
            this.t_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_4.Location = new System.Drawing.Point(186, 10);
            this.t_4.Name = "t_4";
            this.t_4.Size = new System.Drawing.Size(97, 13);
            this.t_4.TabIndex = 0;
            this.t_4.Text = "Letters";
            this.t_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ac_w1_medium_letters_t
            // 
            this.ac_w1_medium_letters_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_medium_letters_t.Location = new System.Drawing.Point(184, 23);
            this.ac_w1_medium_letters_t.Name = "ac_w1_medium_letters_t";
            this.ac_w1_medium_letters_t.Size = new System.Drawing.Size(46, 13);
            this.ac_w1_medium_letters_t.TabIndex = 0;
            this.ac_w1_medium_letters_t.Text = "Medium";
            this.ac_w1_medium_letters_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ac_w1_other_envelopes_t
            // 
            this.ac_w1_other_envelopes_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_other_envelopes_t.Location = new System.Drawing.Point(247, 23);
            this.ac_w1_other_envelopes_t.Name = "ac_w1_other_envelopes_t";
            this.ac_w1_other_envelopes_t.Size = new System.Drawing.Size(34, 13);
            this.ac_w1_other_envelopes_t.TabIndex = 0;
            this.ac_w1_other_envelopes_t.Text = "Other";
            this.ac_w1_other_envelopes_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ac_w1_large_parcels_t
            // 
            this.ac_w1_large_parcels_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_large_parcels_t.Location = new System.Drawing.Point(426, 10);
            this.ac_w1_large_parcels_t.Name = "ac_w1_large_parcels_t";
            this.ac_w1_large_parcels_t.Size = new System.Drawing.Size(43, 26);
            this.ac_w1_large_parcels_t.TabIndex = 0;
            this.ac_w1_large_parcels_t.Text = "Large\r\nParcels";
            this.ac_w1_large_parcels_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // t_6
            // 
            this.t_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_6.Location = new System.Drawing.Point(348, 10);
            this.t_6.Name = "t_6";
            this.t_6.Size = new System.Drawing.Size(53, 26);
            this.t_6.TabIndex = 0;
            this.t_6.Text = "Total\r\nDeliveries";
            this.t_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ac_w1_inward_mail_t
            // 
            this.ac_w1_inward_mail_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_inward_mail_t.Location = new System.Drawing.Point(479, 10);
            this.ac_w1_inward_mail_t.Name = "ac_w1_inward_mail_t";
            this.ac_w1_inward_mail_t.Size = new System.Drawing.Size(40, 26);
            this.ac_w1_inward_mail_t.TabIndex = 0;
            this.ac_w1_inward_mail_t.Text = "Inward\r\nMail";
            this.ac_w1_inward_mail_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ac_w1_small_parcels_t
            // 
            this.ac_w1_small_parcels_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_small_parcels_t.Location = new System.Drawing.Point(293, 10);
            this.ac_w1_small_parcels_t.Name = "ac_w1_small_parcels_t";
            this.ac_w1_small_parcels_t.Size = new System.Drawing.Size(43, 26);
            this.ac_w1_small_parcels_t.TabIndex = 0;
            this.ac_w1_small_parcels_t.Text = "Small\r\nParcels";
            this.ac_w1_small_parcels_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contract_seq_number
            // 
            this.contract_seq_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractSeqNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_seq_number.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_seq_number.Location = new System.Drawing.Point(1004, 0);
            this.contract_seq_number.Name = "contract_seq_number";
            this.contract_seq_number.Size = new System.Drawing.Size(45, 20);
            this.contract_seq_number.TabIndex = 0;
            // 
            // compute_1
            // 
            this.compute_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_1.Location = new System.Drawing.Point(3, 41);
            this.compute_1.Name = "compute_1";
            this.compute_1.ReadOnly = true;
            this.compute_1.Size = new System.Drawing.Size(49, 13);
            this.compute_1.TabIndex = 0;
            this.compute_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ac_start_week_period
            // 
            this.ac_start_week_period.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ac_start_week_period.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcStartWeekPeriod", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_start_week_period.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_start_week_period.Location = new System.Drawing.Point(70, 41);
            this.ac_start_week_period.Name = "ac_start_week_period";
            this.ac_start_week_period.ReadOnly = true;
            this.ac_start_week_period.Size = new System.Drawing.Size(77, 13);
            this.ac_start_week_period.TabIndex = 0;
            // 
            // cust_rd_number
            // 
            this.cust_rd_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustRdNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_rd_number.Font = new System.Drawing.Font("Arial", 8F);
            this.cust_rd_number.Location = new System.Drawing.Point(1050, 0);
            this.cust_rd_number.Name = "cust_rd_number";
            this.cust_rd_number.Size = new System.Drawing.Size(229, 20);
            this.cust_rd_number.TabIndex = 0;
            // 
            // t_7
            // 
            this.t_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_7.Location = new System.Drawing.Point(136, 96);
            this.t_7.Name = "t_7";
            this.t_7.Size = new System.Drawing.Size(41, 13);
            this.t_7.TabIndex = 0;
            this.t_7.Text = "Annual";
            this.t_7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.t_7.Visible = false;
            // 
            // compute_2
            // 
            this.compute_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_2.Location = new System.Drawing.Point(184, 93);
            this.compute_2.Name = "compute_2";
            this.compute_2.ReadOnly = true;
            this.compute_2.Size = new System.Drawing.Size(49, 13);
            this.compute_2.TabIndex = 0;
            this.compute_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_2.Visible = false;
            // 
            // compute_3
            // 
            this.compute_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_3.Location = new System.Drawing.Point(237, 93);
            this.compute_3.Name = "compute_3";
            this.compute_3.ReadOnly = true;
            this.compute_3.Size = new System.Drawing.Size(45, 13);
            this.compute_3.TabIndex = 0;
            this.compute_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_3.Visible = false;
            // 
            // compute_4
            // 
            this.compute_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_4.Location = new System.Drawing.Point(293, 93);
            this.compute_4.Name = "compute_4";
            this.compute_4.ReadOnly = true;
            this.compute_4.Size = new System.Drawing.Size(45, 13);
            this.compute_4.TabIndex = 0;
            this.compute_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_4.Visible = false;
            // 
            // compute_7
            // 
            this.compute_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute7", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_7.Location = new System.Drawing.Point(475, 93);
            this.compute_7.Name = "compute_7";
            this.compute_7.ReadOnly = true;
            this.compute_7.Size = new System.Drawing.Size(44, 13);
            this.compute_7.TabIndex = 0;
            this.compute_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_7.Visible = false;
            // 
            // t_8
            // 
            this.t_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_8.Location = new System.Drawing.Point(151, 44);
            this.t_8.Name = "t_8";
            this.t_8.Size = new System.Drawing.Size(28, 13);
            this.t_8.TabIndex = 0;
            this.t_8.Text = "One";
            this.t_8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_9
            // 
            this.t_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_9.Location = new System.Drawing.Point(150, 69);
            this.t_9.Name = "t_9";
            this.t_9.Size = new System.Drawing.Size(28, 13);
            this.t_9.TabIndex = 0;
            this.t_9.Text = "Two";
            this.t_9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ac_w1_medium_letters
            // 
            this.ac_w1_medium_letters.BackColor = System.Drawing.SystemColors.ButtonShadow;//.Color.Gray;
            this.ac_w1_medium_letters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ac_w1_medium_letters.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW1MediumLetters", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_medium_letters.EditMask = "###,###";
            this.ac_w1_medium_letters.DataBindings[0].FormatString = "###,###";
            this.ac_w1_medium_letters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_medium_letters.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w1_medium_letters.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w1_medium_letters.Location = new System.Drawing.Point(188, 41);
            this.ac_w1_medium_letters.Name = "ac_w1_medium_letters";
            this.ac_w1_medium_letters.PromptChar = ' ';
            this.ac_w1_medium_letters.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_medium_letters.TabIndex = 10;
            this.ac_w1_medium_letters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w1_medium_letters.Value = "";
            // 
            // ac_w1_other_envelopes
            // 
            this.ac_w1_other_envelopes.BackColor = System.Drawing.SystemColors.ButtonShadow;//.Color.Gray;
            this.ac_w1_other_envelopes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ac_w1_other_envelopes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW1OtherEnvelopes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_other_envelopes.EditMask = "###,###";
            this.ac_w1_other_envelopes.DataBindings[0].FormatString = "###,###";
            this.ac_w1_other_envelopes.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w1_other_envelopes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_other_envelopes.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w1_other_envelopes.Location = new System.Drawing.Point(238, 41);
            this.ac_w1_other_envelopes.Name = "ac_w1_other_envelopes";
            this.ac_w1_other_envelopes.PromptChar = ' ';
            this.ac_w1_other_envelopes.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_other_envelopes.TabIndex = 20;
            this.ac_w1_other_envelopes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w1_other_envelopes.Value = "";
            // 
            // ac_w1_small_parcels
            // 
            this.ac_w1_small_parcels.BackColor = System.Drawing.SystemColors.ButtonShadow;//.Color.Gray;
            this.ac_w1_small_parcels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ac_w1_small_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW1SmallParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_small_parcels.EditMask = "###,###";
            this.ac_w1_small_parcels.DataBindings[0].FormatString = "###,###";
            this.ac_w1_small_parcels.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w1_small_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_small_parcels.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w1_small_parcels.Location = new System.Drawing.Point(294, 41);
            this.ac_w1_small_parcels.Name = "ac_w1_small_parcels";
            this.ac_w1_small_parcels.PromptChar = ' ';
            this.ac_w1_small_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_small_parcels.TabIndex = 30;
            this.ac_w1_small_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w1_small_parcels.Value = "";
            // 
            // ac_w2_medium_letters
            // 
            this.ac_w2_medium_letters.BackColor = System.Drawing.SystemColors.ButtonShadow;//.Color.Gray;
            this.ac_w2_medium_letters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ac_w2_medium_letters.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW2MediumLetters", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_medium_letters.EditMask = "###,###";
            this.ac_w2_medium_letters.DataBindings[0].FormatString = "###,###";
            this.ac_w2_medium_letters.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w2_medium_letters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_medium_letters.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w2_medium_letters.Location = new System.Drawing.Point(188, 67);
            this.ac_w2_medium_letters.Name = "ac_w2_medium_letters";
            this.ac_w2_medium_letters.PromptChar = ' ';
            this.ac_w2_medium_letters.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_medium_letters.TabIndex = 60;
            this.ac_w2_medium_letters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w2_medium_letters.Value = "";
            // 
            // ac_w2_other_envelopes
            // 
            this.ac_w2_other_envelopes.BackColor = System.Drawing.SystemColors.ButtonShadow;//.Color.Gray;
            this.ac_w2_other_envelopes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ac_w2_other_envelopes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW2OtherEnvelopes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_other_envelopes.EditMask = "###,###";
            this.ac_w2_other_envelopes.DataBindings[0].FormatString = "###,###";
            this.ac_w2_other_envelopes.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w2_other_envelopes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_other_envelopes.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w2_other_envelopes.Location = new System.Drawing.Point(238, 67);
            this.ac_w2_other_envelopes.Name = "ac_w2_other_envelopes";
            this.ac_w2_other_envelopes.PromptChar = ' ';
            this.ac_w2_other_envelopes.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_other_envelopes.TabIndex = 70;
            this.ac_w2_other_envelopes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w2_other_envelopes.Value = "";
            // 
            // ac_w2_small_parcels
            // 
            this.ac_w2_small_parcels.BackColor = System.Drawing.SystemColors.ButtonShadow;//.Color.Gray;
            this.ac_w2_small_parcels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ac_w2_small_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW2SmallParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_small_parcels.EditMask = "###,###";
            this.ac_w2_small_parcels.DataBindings[0].FormatString = "###,###";
            this.ac_w2_small_parcels.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w2_small_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_small_parcels.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w2_small_parcels.Location = new System.Drawing.Point(294, 67);
            this.ac_w2_small_parcels.Name = "ac_w2_small_parcels";
            this.ac_w2_small_parcels.PromptChar = ' ';
            this.ac_w2_small_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_small_parcels.TabIndex = 80;
            this.ac_w2_small_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w2_small_parcels.Value = "";
            // 
            // ac_w2_inward_mail
            // 
            this.ac_w2_inward_mail.BackColor = System.Drawing.SystemColors.ButtonShadow;//.Color.Gray;
            this.ac_w2_inward_mail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ac_w2_inward_mail.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW2InwardMail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_inward_mail.EditMask = "###,###";
            this.ac_w2_inward_mail.DataBindings[0].FormatString = "###,###";
            this.ac_w2_inward_mail.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w2_inward_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_inward_mail.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w2_inward_mail.Location = new System.Drawing.Point(475, 67);
            this.ac_w2_inward_mail.Name = "ac_w2_inward_mail";
            this.ac_w2_inward_mail.PromptChar = ' ';
            this.ac_w2_inward_mail.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_inward_mail.TabIndex = 100;
            this.ac_w2_inward_mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w2_inward_mail.Value = "";
            // 
            // ac_w1_inward_mail
            // 
            this.ac_w1_inward_mail.BackColor = System.Drawing.SystemColors.ButtonShadow;//.Color.Gray;
            this.ac_w1_inward_mail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ac_w1_inward_mail.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW1InwardMail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_inward_mail.EditMask = "###,###";
            this.ac_w1_inward_mail.DataBindings[0].FormatString = "###,###";
            this.ac_w1_inward_mail.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w1_inward_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_inward_mail.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w1_inward_mail.Location = new System.Drawing.Point(475, 41);
            this.ac_w1_inward_mail.Name = "ac_w1_inward_mail";
            this.ac_w1_inward_mail.PromptChar = ' ';
            this.ac_w1_inward_mail.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_inward_mail.TabIndex = 50;
            this.ac_w1_inward_mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w1_inward_mail.Value = "";
            // 
            // week2del
            // 
            this.week2del.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.week2del.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Week2del", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.week2del.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.week2del.Location = new System.Drawing.Point(355, 67);
            this.week2del.Name = "week2del";
            this.week2del.ReadOnly = true;
            this.week2del.Size = new System.Drawing.Size(51, 13);
            this.week2del.TabIndex = 0;
            this.week2del.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.week2del.DataBindings[0].FormatString = "#,##0";
            // 
            // compute_6
            // 
            this.compute_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_6.Location = new System.Drawing.Point(355, 92);
            this.compute_6.Name = "compute_6";
            this.compute_6.ReadOnly = true;
            this.compute_6.Size = new System.Drawing.Size(51, 13);
            this.compute_6.TabIndex = 0;
            this.compute_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_6.Visible = false;
            // 
            // ac_w1_large_parcels
            // 
            this.ac_w1_large_parcels.BackColor = System.Drawing.SystemColors.ButtonShadow;//.Color.Gray;
            this.ac_w1_large_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW1LargeParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_large_parcels.EditMask = "###,###";
            this.ac_w1_large_parcels.DataBindings[0].FormatString = "###,###";
            this.ac_w1_large_parcels.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w1_large_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_large_parcels.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w1_large_parcels.Location = new System.Drawing.Point(420, 41);
            this.ac_w1_large_parcels.Name = "ac_w1_large_parcels";
            this.ac_w1_large_parcels.PromptChar = ' ';
            this.ac_w1_large_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_large_parcels.TabIndex = 40;
            this.ac_w1_large_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w1_large_parcels.Value = "";
            // 
            // ac_w2_large_parcels
            // 
            this.ac_w2_large_parcels.BackColor = System.Drawing.SystemColors.ButtonShadow;//.Color.Gray;
            this.ac_w2_large_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW2LargeParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_large_parcels.EditMask = "###,###";
            this.ac_w2_large_parcels.DataBindings[0].FormatString = "###,###";
            this.ac_w2_large_parcels.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w2_large_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_large_parcels.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w2_large_parcels.Location = new System.Drawing.Point(420, 69);
            this.ac_w2_large_parcels.Name = "ac_w2_large_parcels";
            this.ac_w2_large_parcels.PromptChar = ' ';
            this.ac_w2_large_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_large_parcels.TabIndex = 90;
            this.ac_w2_large_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w2_large_parcels.Value = "";
            // 
            // compute_5
            // 
            this.compute_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_5.Location = new System.Drawing.Point(420, 93);
            this.compute_5.Name = "compute_5";
            this.compute_5.ReadOnly = true;
            this.compute_5.Size = new System.Drawing.Size(44, 13);
            this.compute_5.TabIndex = 0;
            this.compute_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_5.Visible = false;
            // 
            // week1del
            // 
            this.week1del.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.week1del.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Week1del", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.week1del.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.week1del.Location = new System.Drawing.Point(355, 41);
            this.week1del.Name = "week1del";
            this.week1del.ReadOnly = true;
            this.week1del.Size = new System.Drawing.Size(51, 13);
            this.week1del.TabIndex = 0;
            this.week1del.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.week1del.DataBindings[0].FormatString = "#,##0";
            // 
            // t_5
            // 
            this.t_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.t_5.Location = new System.Drawing.Point(2, 94);
            this.t_5.Name = "t_5";
            this.t_5.Size = new System.Drawing.Size(33, 13);
            this.t_5.TabIndex = 0;
            this.t_5.Text = "Note: ";
            this.t_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // note
            // 
            this.note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.note.Location = new System.Drawing.Point(35, 92);
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(497, 20);
            this.note.TabIndex = 0;
            this.note.Text = "Large Parcel items are not included in the Total Deliveries but are counted in th" +
                "e mailcounts.";
            this.note.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_1
            // 
            this.l_1.BackColor = System.Drawing.Color.Black;
            this.l_1.Location = new System.Drawing.Point(136, 90);
            this.l_1.Name = "l_1";
            this.l_1.Size = new System.Drawing.Size(390, 1);
            this.l_1.TabIndex = 101;
            // 
            // DContractArticalCountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.st_contract);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.t_2);
            this.Controls.Add(this.t_3);
            this.Controls.Add(this.t_4);
            this.Controls.Add(this.ac_w1_medium_letters_t);
            this.Controls.Add(this.ac_w1_other_envelopes_t);
            this.Controls.Add(this.ac_w1_large_parcels_t);
            this.Controls.Add(this.t_6);
            this.Controls.Add(this.ac_w1_inward_mail_t);
            this.Controls.Add(this.ac_w1_small_parcels_t);
            this.Controls.Add(this.contract_seq_number);
            this.Controls.Add(this.compute_1);
            this.Controls.Add(this.ac_start_week_period);
            this.Controls.Add(this.cust_rd_number);
            this.Controls.Add(this.t_7);
            this.Controls.Add(this.compute_2);
            this.Controls.Add(this.compute_3);
            this.Controls.Add(this.compute_4);
            this.Controls.Add(this.compute_7);
            this.Controls.Add(this.t_8);
            this.Controls.Add(this.t_9);
            this.Controls.Add(this.ac_w1_medium_letters);
            this.Controls.Add(this.ac_w1_other_envelopes);
            this.Controls.Add(this.ac_w1_small_parcels);
            this.Controls.Add(this.ac_w2_medium_letters);
            this.Controls.Add(this.ac_w2_other_envelopes);
            this.Controls.Add(this.ac_w2_small_parcels);
            this.Controls.Add(this.ac_w2_inward_mail);
            this.Controls.Add(this.ac_w1_inward_mail);
            this.Controls.Add(this.week2del);
            this.Controls.Add(this.compute_6);
            this.Controls.Add(this.ac_w1_large_parcels);
            this.Controls.Add(this.ac_w2_large_parcels);
            this.Controls.Add(this.compute_5);
            this.Controls.Add(this.week1del);
            this.Controls.Add(this.t_5);
            this.Controls.Add(this.note);
            this.Controls.Add(this.l_1);
            this.Name = "DContractArticalCountForm";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.Label st_contract;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label t_3;
        private System.Windows.Forms.Label t_4;
        private System.Windows.Forms.Label ac_w1_medium_letters_t;
        private System.Windows.Forms.Label ac_w1_other_envelopes_t;
        private System.Windows.Forms.Label ac_w1_large_parcels_t;
        private System.Windows.Forms.Label t_6;
        private System.Windows.Forms.Label ac_w1_inward_mail_t;
        private System.Windows.Forms.Label ac_w1_small_parcels_t;
        private System.Windows.Forms.TextBox contract_seq_number;
        private System.Windows.Forms.TextBox compute_1;
        private System.Windows.Forms.TextBox ac_start_week_period;
        private System.Windows.Forms.TextBox cust_rd_number;
        private System.Windows.Forms.Label t_7;
        private System.Windows.Forms.TextBox compute_2;
        private System.Windows.Forms.TextBox compute_3;
        private System.Windows.Forms.TextBox compute_4;
        private System.Windows.Forms.TextBox compute_7;
        private System.Windows.Forms.Label t_8;
        private System.Windows.Forms.Label t_9;
        
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w1_medium_letters;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w1_other_envelopes;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w1_small_parcels;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w2_medium_letters;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w2_other_envelopes;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w2_small_parcels;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w2_inward_mail;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w1_inward_mail;
        private System.Windows.Forms.TextBox week2del;
        private System.Windows.Forms.TextBox compute_6;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w1_large_parcels;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w2_large_parcels;
        private System.Windows.Forms.TextBox compute_5;
        private System.Windows.Forms.TextBox week1del;
        private System.Windows.Forms.Label t_5;
        private System.Windows.Forms.Label note;
        private System.Windows.Forms.Panel l_1;
    }
}
