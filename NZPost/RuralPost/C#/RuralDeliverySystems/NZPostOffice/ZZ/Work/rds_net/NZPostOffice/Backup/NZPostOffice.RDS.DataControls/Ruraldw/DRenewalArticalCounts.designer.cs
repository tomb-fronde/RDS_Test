using NZPostOffice.Shared.VisualComponents;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DRenewalArticalCountsTest
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
            this.st_title = new System.Windows.Forms.Label();
            this.contract_seq_number = new System.Windows.Forms.TextBox();
            this.cust_rd_number = new System.Windows.Forms.TextBox();
            this.n_20409962 = new System.Windows.Forms.Label();
            this.n_49471932 = new System.Windows.Forms.Label();
            this.ac_w1_medium_letters_t = new System.Windows.Forms.Label();
            this.ac_w1_other_envelopes_t = new System.Windows.Forms.Label();
            this.ac_w1_small_parcels_t = new System.Windows.Forms.Label();
            this.ac_w1_large_parcels_t = new System.Windows.Forms.Label();
            this.n_47803537 = new System.Windows.Forms.Label();
            this.ac_w1_inward_mail_t = new System.Windows.Forms.Label();
            this.n_27578655 = new System.Windows.Forms.Label();
            this.ac_w1_medium_letters = new NumericalMaskedTextBox();
            this.ac_w1_other_envelopes = new NumericalMaskedTextBox();
            this.ac_w1_small_parcels = new NumericalMaskedTextBox();
            this.ac_w1_large_parcels = new NumericalMaskedTextBox();
            this.week1del = new NumericalMaskedTextBox();
            this.ac_w1_inward_mail = new NumericalMaskedTextBox();
            this.n_46881303 = new System.Windows.Forms.Label();
            this.ac_w2_medium_letters = new NumericalMaskedTextBox();
            this.ac_w2_other_envelopes = new NumericalMaskedTextBox();
            this.ac_w2_small_parcels = new NumericalMaskedTextBox();
            this.ac_w2_large_parcels = new NumericalMaskedTextBox();
            this.week2del = new NumericalMaskedTextBox();
            this.ac_w2_inward_mail = new NumericalMaskedTextBox();
            this.n_19278548 = new System.Windows.Forms.Label();
            this.compute_1 = new NumericalMaskedTextBox();
            this.compute_2 = new NumericalMaskedTextBox();
            this.compute_3 = new NumericalMaskedTextBox();
            this.compute_4 = new NumericalMaskedTextBox();
            this.compute_5 = new NumericalMaskedTextBox();
            this.compute_6 = new NumericalMaskedTextBox();
            this.ac_start_week_period = new System.Windows.Forms.TextBox();
            this.n_45626804 = new System.Windows.Forms.Label();
            this.t_10 = new System.Windows.Forms.Label();
            this.t_11 = new System.Windows.Forms.Label();
            this.l_1 = new System.Windows.Forms.Panel();
            this.l_2 = new System.Windows.Forms.Panel();
            this.l_3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RenewalArticalCounts);
            //// 
            //// st_title
            //// 
            //this.st_title.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            //this.st_title.Location = new System.Drawing.Point(-3, 0);
            //this.st_title.Name = "st_title";
            //this.st_title.Size = new System.Drawing.Size(690, 13);
            //this.st_title.TabIndex = 0;
            //this.st_title.Text = "Contract No";
            //this.st_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contract_seq_number
            // 
            this.contract_seq_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractSeqNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_seq_number.ReadOnly = true;
            this.contract_seq_number.Font = new System.Drawing.Font("Arial", 8F);
            this.contract_seq_number.Location = new System.Drawing.Point(1004, 0);
            this.contract_seq_number.Name = "contract_seq_number";
            this.contract_seq_number.Size = new System.Drawing.Size(45, 20);
            this.contract_seq_number.TabIndex = 0;
            // 
            // cust_rd_number
            // 
            this.cust_rd_number.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CustRdNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cust_rd_number.ReadOnly = true;
            this.cust_rd_number.Font = new System.Drawing.Font("Arial", 12F);
            this.cust_rd_number.Location = new System.Drawing.Point(1050, 0);
            this.cust_rd_number.Name = "cust_rd_number";
            this.cust_rd_number.Size = new System.Drawing.Size(330, 26);
            this.cust_rd_number.TabIndex = 0;
            //// 
            //// n_20409962
            //// 
            //this.n_20409962.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.n_20409962.Location = new System.Drawing.Point(133, 36);
            //this.n_20409962.Name = "n_20409962";
            //this.n_20409962.Size = new System.Drawing.Size(36, 13);
            //this.n_20409962.TabIndex = 0;
            //this.n_20409962.Text = "Week";
            //this.n_20409962.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //// 
            //// n_49471932
            //// 
            //this.n_49471932.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.n_49471932.Location = new System.Drawing.Point(176, 19);
            //this.n_49471932.Name = "n_49471932";
            //this.n_49471932.Size = new System.Drawing.Size(97, 13);
            //this.n_49471932.TabIndex = 0;
            //this.n_49471932.Text = "Letters";
            //this.n_49471932.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //// 
            //// ac_w1_medium_letters_t
            //// 
            //this.ac_w1_medium_letters_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.ac_w1_medium_letters_t.Location = new System.Drawing.Point(178, 36);
            //this.ac_w1_medium_letters_t.Name = "ac_w1_medium_letters_t";
            //this.ac_w1_medium_letters_t.Size = new System.Drawing.Size(45, 13);
            //this.ac_w1_medium_letters_t.TabIndex = 0;
            //this.ac_w1_medium_letters_t.Text = "Medium";
            //this.ac_w1_medium_letters_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //// 
            //// ac_w1_other_envelopes_t
            //// 
            //this.ac_w1_other_envelopes_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.ac_w1_other_envelopes_t.Location = new System.Drawing.Point(240, 36);
            //this.ac_w1_other_envelopes_t.Name = "ac_w1_other_envelopes_t";
            //this.ac_w1_other_envelopes_t.Size = new System.Drawing.Size(33, 13);
            //this.ac_w1_other_envelopes_t.TabIndex = 0;
            //this.ac_w1_other_envelopes_t.Text = "Other";
            //this.ac_w1_other_envelopes_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //// 
            //// ac_w1_small_parcels_t
            //// 
            //this.ac_w1_small_parcels_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.ac_w1_small_parcels_t.Location = new System.Drawing.Point(281, 19);
            //this.ac_w1_small_parcels_t.Name = "ac_w1_small_parcels_t";
            //this.ac_w1_small_parcels_t.Size = new System.Drawing.Size(42, 30);
            //this.ac_w1_small_parcels_t.TabIndex = 0;
            //this.ac_w1_small_parcels_t.Text = "Small\r\nParcels";
            //this.ac_w1_small_parcels_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //// 
            //// ac_w1_large_parcels_t
            //// 
            //this.ac_w1_large_parcels_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.ac_w1_large_parcels_t.Location = new System.Drawing.Point(391, 19);
            //this.ac_w1_large_parcels_t.Name = "ac_w1_large_parcels_t";
            //this.ac_w1_large_parcels_t.Size = new System.Drawing.Size(48, 29);
            //this.ac_w1_large_parcels_t.TabIndex = 0;
            //this.ac_w1_large_parcels_t.Text = "Large\r\nParcels";
            //this.ac_w1_large_parcels_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //// 
            //// n_47803537
            //// 
            //this.n_47803537.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.n_47803537.Location = new System.Drawing.Point(329, 22);
            //this.n_47803537.Name = "n_47803537";
            //this.n_47803537.Size = new System.Drawing.Size(53, 26);
            //this.n_47803537.TabIndex = 0;
            //this.n_47803537.Text = "Total\r\nDeliveries";
            //this.n_47803537.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //// 
            //// ac_w1_inward_mail_t
            //// 
            //this.ac_w1_inward_mail_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.ac_w1_inward_mail_t.Location = new System.Drawing.Point(443, 22);
            //this.ac_w1_inward_mail_t.Name = "ac_w1_inward_mail_t";
            //this.ac_w1_inward_mail_t.Size = new System.Drawing.Size(40, 26);
            //this.ac_w1_inward_mail_t.TabIndex = 0;
            //this.ac_w1_inward_mail_t.Text = "Inward\r\nMail";
            //this.ac_w1_inward_mail_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // n_27578655
            // 
            this.n_27578655.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_27578655.Location = new System.Drawing.Point(139, 8);
            this.n_27578655.Name = "n_27578655";
            this.n_27578655.Size = new System.Drawing.Size(27, 13);
            this.n_27578655.TabIndex = 0;
            this.n_27578655.Text = "One";
            this.n_27578655.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ac_w1_medium_letters
            // 
            this.ac_w1_medium_letters.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW1MediumLetters", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.ac_w1_medium_letters.ReadOnly = true;
            this.ac_w1_medium_letters.EditMask = "###,###";
            this.ac_w1_medium_letters.DataBindings[0].FormatString = "###,###";
            this.ac_w1_medium_letters.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w1_medium_letters.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w1_medium_letters.PromptChar = ' ';
            this.ac_w1_medium_letters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_medium_letters.Location = new System.Drawing.Point(174, 8);
            this.ac_w1_medium_letters.Name = "ac_w1_medium_letters";
            this.ac_w1_medium_letters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ac_w1_medium_letters.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_medium_letters.TabIndex = 0;
            this.ac_w1_medium_letters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ac_w1_other_envelopes
            // 
            this.ac_w1_other_envelopes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW1OtherEnvelopes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.ac_w1_other_envelopes.ReadOnly = true;
            this.ac_w1_other_envelopes.EditMask = "###,###";
            this.ac_w1_other_envelopes.DataBindings[0].FormatString = "###,###";
            this.ac_w1_other_envelopes.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w1_other_envelopes.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w1_other_envelopes.PromptChar = ' ';
            this.ac_w1_other_envelopes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_other_envelopes.Location = new System.Drawing.Point(225, 8);
            this.ac_w1_other_envelopes.Name = "ac_w1_other_envelopes";
            this.ac_w1_other_envelopes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ac_w1_other_envelopes.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_other_envelopes.TabIndex = 0;
            this.ac_w1_other_envelopes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ac_w1_small_parcels
            // 
            this.ac_w1_small_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW1SmallParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.ac_w1_small_parcels.ReadOnly = true;
            this.ac_w1_small_parcels.EditMask = "###,###";
            this.ac_w1_small_parcels.DataBindings[0].FormatString = "###,###";
            this.ac_w1_small_parcels.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w1_small_parcels.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w1_small_parcels.PromptChar = ' ';
            this.ac_w1_small_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_small_parcels.Location = new System.Drawing.Point(269, 8);
            this.ac_w1_small_parcels.Name = "ac_w1_small_parcels";
            this.ac_w1_small_parcels.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ac_w1_small_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_small_parcels.TabIndex = 0;
            this.ac_w1_small_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ac_w1_large_parcels
            // 
            this.ac_w1_large_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW1LargeParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.ac_w1_large_parcels.ReadOnly = true;
            this.ac_w1_large_parcels.EditMask = "###,###";
            this.ac_w1_large_parcels.DataBindings[0].FormatString = "###,###";
            this.ac_w1_large_parcels.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w1_large_parcels.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w1_large_parcels.PromptChar = ' ';
            this.ac_w1_large_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_large_parcels.Location = new System.Drawing.Point(386, 8);
            this.ac_w1_large_parcels.Name = "ac_w1_large_parcels";
            this.ac_w1_large_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_large_parcels.TabIndex = 0;
            this.ac_w1_large_parcels.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ac_w1_large_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // week1del
            // 
            this.week1del.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Week1del", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.week1del.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.week1del.Location = new System.Drawing.Point(324, 8);
            this.week1del.Name = "week1del";
            this.week1del.EditMask = "#,##0";
            this.week1del.DataBindings[0].FormatString = "#,##0";
            this.week1del.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.week1del.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.week1del.PromptChar = ' ';
            this.week1del.Size = new System.Drawing.Size(51, 20);
            this.week1del.TabIndex = 0;
            this.week1del.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.week1del.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.week1del.ReadOnly = true;
            // 
            // ac_w1_inward_mail
            // 
            this.ac_w1_inward_mail.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW1InwardMail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.ac_w1_inward_mail.ReadOnly = true;
            this.ac_w1_inward_mail.EditMask = "###,###";
            this.ac_w1_inward_mail.DataBindings[0].FormatString = "###,###";
            this.ac_w1_inward_mail.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w1_inward_mail.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w1_inward_mail.PromptChar = ' ';
            this.ac_w1_inward_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_inward_mail.Location = new System.Drawing.Point(426, 8);
            this.ac_w1_inward_mail.Name = "ac_w1_inward_mail";
            this.ac_w1_inward_mail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ac_w1_inward_mail.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_inward_mail.TabIndex = 0;
            this.ac_w1_inward_mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // n_46881303
            // 
            this.n_46881303.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_46881303.Location = new System.Drawing.Point(137, 29);
            this.n_46881303.Name = "n_46881303";
            this.n_46881303.Size = new System.Drawing.Size(28, 13);
            this.n_46881303.TabIndex = 0;
            this.n_46881303.Text = "Two";
            this.n_46881303.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // l_1
            //
            this.l_1.Height = 1;
            this.l_1.Location = new System.Drawing.Point(125, 45);
            this.l_1.Width = 350;
            this.l_1.BackColor = System.Drawing.Color.Black;
            this.l_1.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // 
            // ac_w2_medium_letters
            // 
            this.ac_w2_medium_letters.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW2MediumLetters", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.ac_w2_medium_letters.ReadOnly = true;
            this.ac_w2_medium_letters.EditMask = "###,###";
            this.ac_w2_medium_letters.DataBindings[0].FormatString = "###,###";
            this.ac_w2_medium_letters.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w2_medium_letters.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w2_medium_letters.PromptChar = ' ';
            this.ac_w2_medium_letters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_medium_letters.Location = new System.Drawing.Point(174, 29);
            this.ac_w2_medium_letters.Name = "ac_w2_medium_letters";
            this.ac_w2_medium_letters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ac_w2_medium_letters.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_medium_letters.TabIndex = 0;
            this.ac_w2_medium_letters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ac_w2_other_envelopes
            // 
            this.ac_w2_other_envelopes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW2OtherEnvelopes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.ac_w2_other_envelopes.ReadOnly = true;
            this.ac_w2_other_envelopes.EditMask = "###,###";
            this.ac_w2_other_envelopes.DataBindings[0].FormatString = "###,###";
            this.ac_w2_other_envelopes.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w2_other_envelopes.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w2_other_envelopes.PromptChar = ' ';
            this.ac_w2_other_envelopes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_other_envelopes.Location = new System.Drawing.Point(225, 29);
            this.ac_w2_other_envelopes.Name = "ac_w2_other_envelopes";
            this.ac_w2_other_envelopes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ac_w2_other_envelopes.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_other_envelopes.TabIndex = 0;
            this.ac_w2_other_envelopes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ac_w2_small_parcels
            // 
            this.ac_w2_small_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW2SmallParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.ac_w2_small_parcels.ReadOnly = true;
            this.ac_w2_small_parcels.EditMask = "###,###";
            this.ac_w2_small_parcels.DataBindings[0].FormatString = "###,###";
            this.ac_w2_small_parcels.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w2_small_parcels.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w2_small_parcels.PromptChar = ' ';
            this.ac_w2_small_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_small_parcels.Location = new System.Drawing.Point(269, 29);
            this.ac_w2_small_parcels.Name = "ac_w2_small_parcels";
            this.ac_w2_small_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_small_parcels.TabIndex = 0;
            this.ac_w2_small_parcels.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ac_w2_small_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ac_w2_large_parcels
            // 
            this.ac_w2_large_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW2LargeParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.ac_w2_large_parcels.ReadOnly = true;
            this.ac_w2_large_parcels.EditMask = "###,###";
            this.ac_w2_large_parcels.DataBindings[0].FormatString = "###,###";
            this.ac_w2_large_parcels.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w2_large_parcels.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w2_large_parcels.PromptChar = ' ';
            this.ac_w2_large_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_large_parcels.Location = new System.Drawing.Point(386, 29);
            this.ac_w2_large_parcels.Name = "ac_w2_large_parcels";
            this.ac_w2_large_parcels.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ac_w2_large_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_large_parcels.TabIndex = 0;
            this.ac_w2_large_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // week2del
            // 
            this.week2del.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Week2del", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.week2del.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.week2del.Location = new System.Drawing.Point(324, 29);
            this.week2del.Name = "week2del";
            this.week2del.EditMask = "#,##0";
            this.week2del.DataBindings[0].FormatString = "#,##0";
            this.week2del.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.week2del.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.week2del.PromptChar = ' ';
            this.week2del.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.week2del.Size = new System.Drawing.Size(51, 20);
            this.week2del.TabIndex = 0;
            this.week2del.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.week2del.ReadOnly = true;
            // 
            // ac_w2_inward_mail
            // 
            this.ac_w2_inward_mail.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcW2InwardMail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.ac_w2_inward_mail.ReadOnly = true;
            this.ac_w2_inward_mail.EditMask = "###,###";
            this.ac_w2_inward_mail.DataBindings[0].FormatString = "###,###";
            this.ac_w2_inward_mail.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ac_w2_inward_mail.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ac_w2_inward_mail.PromptChar = ' ';
            this.ac_w2_inward_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_inward_mail.Location = new System.Drawing.Point(426, 29);
            this.ac_w2_inward_mail.Name = "ac_w2_inward_mail";
            this.ac_w2_inward_mail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ac_w2_inward_mail.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_inward_mail.TabIndex = 0;
            this.ac_w2_inward_mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // n_19278548
            // 
            this.n_19278548.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_19278548.Location = new System.Drawing.Point(125, 52);
            this.n_19278548.Name = "n_19278548";
            this.n_19278548.Size = new System.Drawing.Size(41, 13);
            this.n_19278548.TabIndex = 0;
            this.n_19278548.Text = "Annual";
            this.n_19278548.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // l_2
            //
            this.l_2.Height = 1;
            this.l_2.Location = new System.Drawing.Point(125, 65);
            this.l_2.Width = 350;
            this.l_2.BackColor = System.Drawing.Color.Black;
            this.l_2.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // 
            // l_3
            //
            this.l_3.Height = 1;
            this.l_3.Location = new System.Drawing.Point(125, 67);
            this.l_3.Width = 350;
            this.l_3.BackColor = System.Drawing.Color.Black;
            this.l_3.BorderStyle = System.Windows.Forms.BorderStyle.None;


            // 
            // compute_1
            // 
            this.compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Compute1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.compute_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_1.Location = new System.Drawing.Point(170, 52);
            this.compute_1.Name = "compute_1";
            this.compute_1.EditMask = "#,##0";
            this.compute_1.DataBindings[0].FormatString = "#,##0";
            this.compute_1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.compute_1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.compute_1.PromptChar = ' ';
            this.compute_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_1.Size = new System.Drawing.Size(49, 20);
            this.compute_1.TabIndex = 0;
            this.compute_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_1.ReadOnly = true;
            // 
            // compute_2
            // 
            this.compute_2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Compute2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.compute_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_2.Location = new System.Drawing.Point(223, 52);
            this.compute_2.Name = "compute_2";
            this.compute_2.EditMask = "#,##0";
            this.compute_2.DataBindings[0].FormatString = "#,##0";
            this.compute_2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.compute_2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.compute_2.PromptChar = ' ';
            this.compute_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_2.Size = new System.Drawing.Size(45, 20);
            this.compute_2.TabIndex = 0;
            this.compute_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_2.ReadOnly = true;
            // 
            // compute_3
            // 
            this.compute_3.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Compute3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.compute_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_3.Location = new System.Drawing.Point(269, 52);
            this.compute_3.Name = "compute_3";
            this.compute_3.EditMask = "#,##0";
            this.compute_3.DataBindings[0].FormatString = "#,##0";
            this.compute_3.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.compute_3.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.compute_3.PromptChar = ' ';
            this.compute_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_3.Size = new System.Drawing.Size(45, 20);
            this.compute_3.TabIndex = 0;
            this.compute_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_3.ReadOnly = true;
            // 
            // compute_4
            // 
            this.compute_4.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Compute4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.compute_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_4.Location = new System.Drawing.Point(386, 52);
            this.compute_4.Name = "compute_4";
            this.compute_4.EditMask = "#,##0";
            this.compute_4.DataBindings[0].FormatString = "#,##0";
            this.compute_4.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.compute_4.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.compute_4.PromptChar = ' ';
            this.compute_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_4.Size = new System.Drawing.Size(44, 20);
            this.compute_4.TabIndex = 0;
            this.compute_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_4.ReadOnly = true;
            // 
            // compute_5
            // 
            this.compute_5.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Compute5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,###"));
            this.compute_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_5.Location = new System.Drawing.Point(324, 52);
            this.compute_5.Name = "compute_5";
            this.compute_5.EditMask = "#,##0";
            this.compute_5.DataBindings[0].FormatString = "#,##0";
            this.compute_5.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.compute_5.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.compute_5.PromptChar = ' ';
            this.compute_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_5.Size = new System.Drawing.Size(51, 20);
            this.compute_5.TabIndex = 0;
            this.compute_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_5.ReadOnly = true;
            // 
            // compute_6
            // 
            this.compute_6.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Compute6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "###,##0"));
            this.compute_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_6.Location = new System.Drawing.Point(426, 52);
            this.compute_6.Name = "compute_6";
            this.compute_6.EditMask = "#,##0";
            this.compute_6.DataBindings[0].FormatString = "#,##0";
            this.compute_6.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.compute_6.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.compute_6.PromptChar = ' ';
            this.compute_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_6.Size = new System.Drawing.Size(44, 20);
            this.compute_6.TabIndex = 0;
            this.compute_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_6.ReadOnly = true;
            // 
            // ac_start_week_period
            // 
            this.ac_start_week_period.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcStartWeekPeriod", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_start_week_period.ReadOnly = true;
            this.ac_start_week_period.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_start_week_period.Location = new System.Drawing.Point(25, 8);
            this.ac_start_week_period.Name = "ac_start_week_period";
            this.ac_start_week_period.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ac_start_week_period.Size = new System.Drawing.Size(75, 20);
            this.ac_start_week_period.TabIndex = 0;
            //// 
            //// n_45626804
            //// 
            //this.n_45626804.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.n_45626804.Location = new System.Drawing.Point(17, 37);
            //this.n_45626804.Name = "n_45626804";
            //this.n_45626804.Size = new System.Drawing.Size(75, 13);
            //this.n_45626804.TabIndex = 0;
            //this.n_45626804.Text = "Count Period";
            //this.n_45626804.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //// 
            //// t_10
            //// 
            //this.t_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            //this.t_10.Location = new System.Drawing.Point(0, 310);
            //this.t_10.Name = "t_10";
            //this.t_10.Size = new System.Drawing.Size(33, 13);
            //this.t_10.TabIndex = 0;
            //this.t_10.Text = "Note:";
            //this.t_10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //// 
            //// t_11
            //// 
            //this.t_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F,System.Drawing.FontStyle.Italic);
            //this.t_11.Location = new System.Drawing.Point(33, 310);
            //this.t_11.Name = "t_11";
            //this.t_11.Size = new System.Drawing.Size(575, 13);
            //this.t_11.TabIndex = 0;
            //this.t_11.Text = "Large Parcel items are not included in the Total Deliveries but are counted in the mailcounts.    ";
            //this.t_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DRenewalArticalCounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.Controls.Add(this.st_title);
            this.Controls.Add(this.contract_seq_number);
            this.Controls.Add(this.cust_rd_number);
            //this.Controls.Add(this.n_20409962);
            //this.Controls.Add(this.n_49471932);
            //this.Controls.Add(this.ac_w1_medium_letters_t);
            //this.Controls.Add(this.ac_w1_other_envelopes_t);
            //this.Controls.Add(this.ac_w1_small_parcels_t);
            //this.Controls.Add(this.ac_w1_large_parcels_t);
            //this.Controls.Add(this.n_47803537);
            //this.Controls.Add(this.ac_w1_inward_mail_t);
            this.Controls.Add(this.n_27578655);
            this.Controls.Add(this.ac_w1_medium_letters);
            this.Controls.Add(this.ac_w1_other_envelopes);
            this.Controls.Add(this.ac_w1_small_parcels);
            this.Controls.Add(this.ac_w1_large_parcels);
            this.Controls.Add(this.week1del);
            this.Controls.Add(this.ac_w1_inward_mail);
            this.Controls.Add(this.n_46881303);
            this.Controls.Add(this.ac_w2_medium_letters);
            this.Controls.Add(this.ac_w2_other_envelopes);
            this.Controls.Add(this.ac_w2_small_parcels);
            this.Controls.Add(this.ac_w2_large_parcels);
            this.Controls.Add(this.week2del);
            this.Controls.Add(this.ac_w2_inward_mail);
            this.Controls.Add(this.n_19278548);
            this.Controls.Add(this.compute_1);
            this.Controls.Add(this.compute_2);
            this.Controls.Add(this.compute_3);
            this.Controls.Add(this.compute_4);
            this.Controls.Add(this.compute_5);
            this.Controls.Add(this.compute_6);
            this.Controls.Add(this.ac_start_week_period);
            //this.Controls.Add(this.n_45626804);
            this.Controls.Add(this.t_10);
            this.Controls.Add(this.t_11);
            this.Controls.Add(this.l_1);
            this.Controls.Add(this.l_2);
            this.Controls.Add(this.l_3);
            this.Name = "DRenewalArticalCounts";
            this.Size = new System.Drawing.Size(500, 68);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label st_title;
        private System.Windows.Forms.TextBox contract_seq_number;
        private System.Windows.Forms.TextBox cust_rd_number;
        private System.Windows.Forms.Label n_20409962;
        private System.Windows.Forms.Label n_49471932;
        private System.Windows.Forms.Label ac_w1_medium_letters_t;
        private System.Windows.Forms.Label ac_w1_other_envelopes_t;
        private System.Windows.Forms.Label ac_w1_small_parcels_t;
        private System.Windows.Forms.Label ac_w1_large_parcels_t;
        private System.Windows.Forms.Label n_47803537;
        private System.Windows.Forms.Label ac_w1_inward_mail_t;
        private System.Windows.Forms.Label n_27578655;
        private NumericalMaskedTextBox ac_w1_medium_letters;
        private NumericalMaskedTextBox ac_w1_other_envelopes;
        private NumericalMaskedTextBox ac_w1_small_parcels;
        private NumericalMaskedTextBox ac_w1_large_parcels;
        private NumericalMaskedTextBox week1del;
        private NumericalMaskedTextBox ac_w1_inward_mail;
        private System.Windows.Forms.Label n_46881303;
        private NumericalMaskedTextBox ac_w2_medium_letters;
        private NumericalMaskedTextBox ac_w2_other_envelopes;
        private NumericalMaskedTextBox ac_w2_small_parcels;
        private NumericalMaskedTextBox ac_w2_large_parcels;
        private NumericalMaskedTextBox week2del;
        private NumericalMaskedTextBox ac_w2_inward_mail;
        private System.Windows.Forms.Label n_19278548;
        private NumericalMaskedTextBox compute_1;
        private NumericalMaskedTextBox compute_2;
        private NumericalMaskedTextBox compute_3;
        private NumericalMaskedTextBox compute_4;
        private NumericalMaskedTextBox compute_5;
        private NumericalMaskedTextBox compute_6;
        private System.Windows.Forms.TextBox ac_start_week_period;
        private System.Windows.Forms.Label n_45626804;
        private System.Windows.Forms.Label t_10;
        private System.Windows.Forms.Label t_11;
        private System.Windows.Forms.Panel l_1;
        private System.Windows.Forms.Panel l_2;
        private System.Windows.Forms.Panel l_3;
    }
}
