using NZPostOffice.Shared.VisualComponents;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractSearch
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
            this.Name = "DContractSearch";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractSearch);

            #region n_1886449 define
            this.n_1886449 = new System.Windows.Forms.Label();
            this.n_1886449.Name = "n_1886449";
            this.n_1886449.Location = new System.Drawing.Point(145, 1);
            this.n_1886449.Size = new System.Drawing.Size(113, 13);
            this.n_1886449.TabIndex = 0;
            this.n_1886449.Font = new System.Drawing.Font("MS Sans Serif", 8, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline)));
            this.n_1886449.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_1886449.Text = "Search Criteria";
            #endregion
            this.Controls.Add(n_1886449);

            #region rg_code_t define
            this.rg_code_t = new System.Windows.Forms.Label();
            this.rg_code_t.Name = "rg_code_t";
            this.rg_code_t.Location = new System.Drawing.Point(76, 25);
            this.rg_code_t.Size = new System.Drawing.Size(65, 13);
            this.rg_code_t.TabIndex = 0;
            this.rg_code_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.rg_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rg_code_t.Text = "Contract No";
            #endregion
            this.Controls.Add(rg_code_t);

            #region contract_no define
            this.contract_no = new NumericalMaskedTextBox();
            this.contract_no.Name = "contract_no";
            this.contract_no.Location = new System.Drawing.Point(146, 18);
            this.contract_no.Size = new System.Drawing.Size(56, 20);
            this.contract_no.TabIndex = 10;
            this.contract_no.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.EditMask = "######";
            this.contract_no.DataBindings[0].FormatString = "######";
            this.contract_no.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.contract_no.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.contract_no.PromptChar = ' ';
            this.contract_no.DataBindings[0].NullValue = "";
            #endregion
            this.Controls.Add(contract_no);

            #region region_id_t define
            this.region_id_t = new System.Windows.Forms.Label();
            this.region_id_t.Name = "region_id_t";
            this.region_id_t.Location = new System.Drawing.Point(99, 47);
            this.region_id_t.Size = new System.Drawing.Size(41, 13);
            this.region_id_t.TabIndex = 0;
            this.region_id_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.region_id_t.Text = "Region";
            #endregion
            this.Controls.Add(region_id_t);

            #region con_title_t define
            this.con_title_t = new System.Windows.Forms.Label();
            this.con_title_t.Name = "con_title_t";
            this.con_title_t.Location = new System.Drawing.Point(67, 68);
            this.con_title_t.Size = new System.Drawing.Size(73, 13);
            this.con_title_t.TabIndex = 0;
            this.con_title_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_title_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.con_title_t.Text = "Contract Title";
            #endregion
            this.Controls.Add(con_title_t);

            #region con_old_mail_service_no_t define
            this.con_old_mail_service_no_t = new System.Windows.Forms.Label();
            this.con_old_mail_service_no_t.Name = "con_old_mail_service_no_t";
            this.con_old_mail_service_no_t.Location = new System.Drawing.Point(365, 84);
            this.con_old_mail_service_no_t.Size = new System.Drawing.Size(85, 13);
            this.con_old_mail_service_no_t.TabIndex = 0;
            this.con_old_mail_service_no_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_old_mail_service_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.con_old_mail_service_no_t.Text = "Mail Service No";
            #endregion
            this.Controls.Add(con_old_mail_service_no_t);

            #region con_old_mail_service_no define
            this.con_old_mail_service_no = new System.Windows.Forms.TextBox();
            this.con_old_mail_service_no.Name = "con_old_mail_service_no";
            this.con_old_mail_service_no.Location = new System.Drawing.Point(457, 81);
            this.con_old_mail_service_no.Size = new System.Drawing.Size(67, 20);
            this.con_old_mail_service_no.TabIndex = 0;
            this.con_old_mail_service_no.Enabled = false;
            this.con_old_mail_service_no.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_old_mail_service_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.con_old_mail_service_no.MaxLength = 6;
            this.con_old_mail_service_no.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.con_old_mail_service_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConOldMailServiceNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(con_old_mail_service_no);

            #region region_id define
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.region_id.AutoRetrieve = true;
            this.region_id.Name = "region_id";
            this.region_id.Location = new System.Drawing.Point(146, 40);
            this.region_id.Size = new System.Drawing.Size(185, 21);
            //?this.region_id.TabIndex = 20;
            this.region_id.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.ValueMember = "RegionId";
           // this.region_id.Value = null;
            this.region_id.DataBindings[0].DataSourceNullValue = null;

            #endregion

            this.Controls.Add(region_id);

            #region con_title define
            this.con_title = new System.Windows.Forms.TextBox();
            this.con_title.Name = "con_title";
            this.con_title.Location = new System.Drawing.Point(146, 62);
            this.con_title.Size = new System.Drawing.Size(185, 20);
            this.con_title.TabIndex = 30;
            this.con_title.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_title.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.con_title.MaxLength = 60;
            this.con_title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(con_title);

            #region ct_key define

            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ct_key.Name = "ct_key";
            this.ct_key.Location = new System.Drawing.Point(146, 83);
            this.ct_key.Size = new System.Drawing.Size(185, 21);
            //?this.ct_key.TabIndex = 40;
            this.ct_key.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.ValueMember = "CtKey";
            this.ct_key.Value = null;
            this.ct_key.DataBindings[0].DataSourceNullValue = null;

            #endregion
            this.Controls.Add(ct_key);

            #region n_16978042 define
            this.n_16978042 = new System.Windows.Forms.Label();
            this.n_16978042.Name = "n_16978042";
            this.n_16978042.Location = new System.Drawing.Point(38, 90);
            this.n_16978042.Size = new System.Drawing.Size(101, 13);
            this.n_16978042.TabIndex = 0;
            this.n_16978042.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_16978042.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_16978042.Text = "Contract Type";
            #endregion
            this.Controls.Add(n_16978042);

            #region n_18584657 define
            this.n_18584657 = new System.Windows.Forms.Label();
            this.n_18584657.Name = "n_18584657";
            this.n_18584657.Location = new System.Drawing.Point(146, 105);
            this.n_18584657.Size = new System.Drawing.Size(31, 13);
            this.n_18584657.TabIndex = 0;
            this.n_18584657.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_18584657.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_18584657.Text = "From";
            #endregion
            this.Controls.Add(n_18584657);

            #region n_33044190 define
            this.n_33044190 = new System.Windows.Forms.Label();
            this.n_33044190.Name = "n_33044190";
            this.n_33044190.Location = new System.Drawing.Point(228, 105);
            this.n_33044190.Size = new System.Drawing.Size(20, 13);
            this.n_33044190.TabIndex = 0;
            this.n_33044190.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_33044190.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_33044190.Text = "To";
            #endregion
            this.Controls.Add(n_33044190);

            #region con_last_service_review_1_t define
            this.con_last_service_review_1_t = new System.Windows.Forms.Label();
            this.con_last_service_review_1_t.Name = "con_last_service_review_1_t";
            this.con_last_service_review_1_t.Location = new System.Drawing.Point(27, 122);
            this.con_last_service_review_1_t.Size = new System.Drawing.Size(113, 13);
            this.con_last_service_review_1_t.TabIndex = 0;
            this.con_last_service_review_1_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_last_service_review_1_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.con_last_service_review_1_t.Text = "Last Service Review";
            #endregion
            this.Controls.Add(con_last_service_review_1_t);

            #region con_last_service_review_1 define
            this.con_last_service_review_1 = new DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();
            this.con_last_service_review_1.Name = "con_last_service_review_1";
            this.con_last_service_review_1.Location = new System.Drawing.Point(146, 118);
            this.con_last_service_review_1.Size = new System.Drawing.Size(74, 20);
            this.con_last_service_review_1.TabIndex = 50;
            this.con_last_service_review_1.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_last_service_review_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_last_service_review_1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastServiceReview1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_service_review_1.Mask = "00/00/0000";
            //this.con_last_service_review_1.PromptChar = '0';
            this.con_last_service_review_1.ValidatingType = typeof(System.DateTime?);
            this.con_last_service_review_1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_service_review_1.DataBindings[0].FormatString = "dd/MM/yyyy";
            //this.con_last_service_review_1.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(DateTime_TypeValidationCompleted);
            //this.con_last_service_review_1.Validated += new System.EventHandler(DateTime_Validated);
            #endregion
            this.Controls.Add(con_last_service_review_1);

            #region con_last_service_review_2 define
            this.con_last_service_review_2 = new DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();
            this.con_last_service_review_2.Name = "con_last_service_review_2";
            this.con_last_service_review_2.Location = new System.Drawing.Point(227, 118);
            this.con_last_service_review_2.Size = new System.Drawing.Size(74, 20);
            this.con_last_service_review_2.TabIndex = 60;
            this.con_last_service_review_2.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_last_service_review_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_last_service_review_2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastServiceReview2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_service_review_2.Mask = "00/00/0000";
            //this.con_last_service_review_2.PromptChar = '0';
            this.con_last_service_review_2.ValidatingType = typeof(System.DateTime?);
            this.con_last_service_review_2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_service_review_2.DataBindings[0].FormatString = "dd/MM/yyyy";
            //this.con_last_service_review_2.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(DateTime_TypeValidationCompleted);
            //this.con_last_service_review_2.Validated += new System.EventHandler(DateTime_Validated);
            #endregion
            this.Controls.Add(con_last_service_review_2);

            #region con_last_delivery_check_1_t define
            this.con_last_delivery_check_1_t = new System.Windows.Forms.Label();
            this.con_last_delivery_check_1_t.Name = "con_last_delivery_check_1_t";
            this.con_last_delivery_check_1_t.Location = new System.Drawing.Point(32, 145);
            this.con_last_delivery_check_1_t.Size = new System.Drawing.Size(108, 13);
            this.con_last_delivery_check_1_t.TabIndex = 0;
            this.con_last_delivery_check_1_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_last_delivery_check_1_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.con_last_delivery_check_1_t.Text = "Last Delivery Check";
            #endregion
            this.Controls.Add(con_last_delivery_check_1_t);

            #region con_last_delivery_check_1 define
            this.con_last_delivery_check_1 = new DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();
            this.con_last_delivery_check_1.Name = "con_last_delivery_check_1";
            this.con_last_delivery_check_1.Location = new System.Drawing.Point(146, 140);
            this.con_last_delivery_check_1.Size = new System.Drawing.Size(74, 20);
            this.con_last_delivery_check_1.TabIndex = 70;
            this.con_last_delivery_check_1.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_last_delivery_check_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_last_delivery_check_1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastDeliveryCheck1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_delivery_check_1.Mask = "00/00/0000";
            //this.con_last_delivery_check_1.PromptChar = '0';
            this.con_last_delivery_check_1.ValidatingType = typeof(System.DateTime?);
            this.con_last_delivery_check_1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_delivery_check_1.DataBindings[0].FormatString = "dd/MM/yyyy";
            //this.con_last_delivery_check_1.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(DateTime_TypeValidationCompleted);
            //this.con_last_delivery_check_1.Validated += new System.EventHandler(DateTime_Validated);
            #endregion
            this.Controls.Add(con_last_delivery_check_1);

            #region con_last_delivery_check_2 define
            this.con_last_delivery_check_2 = new DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();
            this.con_last_delivery_check_2.Name = "con_last_delivery_check_2";
            this.con_last_delivery_check_2.Location = new System.Drawing.Point(227, 140);
            this.con_last_delivery_check_2.Size = new System.Drawing.Size(74, 20);
            this.con_last_delivery_check_2.TabIndex = 80;
            this.con_last_delivery_check_2.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_last_delivery_check_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_last_delivery_check_2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastDeliveryCheck2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_delivery_check_2.Mask = "00/00/0000";
            //this.con_last_delivery_check_2.PromptChar = '0';
            this.con_last_delivery_check_2.ValidatingType = typeof(System.DateTime?);
            this.con_last_delivery_check_2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_delivery_check_2.DataBindings[0].FormatString = "dd/MM/yyyy";
            //this.con_last_delivery_check_2.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(DateTime_TypeValidationCompleted);
            //this.con_last_delivery_check_2.Validated += new System.EventHandler(DateTime_Validated);
            #endregion
            this.Controls.Add(con_last_delivery_check_2);

            #region con_last_work_msr_1_t define
            this.con_last_work_msr_1_t = new System.Windows.Forms.Label();
            this.con_last_work_msr_1_t.Name = "con_last_work_msr_1_t";
            this.con_last_work_msr_1_t.Location = new System.Drawing.Point(3, 165);
            this.con_last_work_msr_1_t.Size = new System.Drawing.Size(137, 13);
            this.con_last_work_msr_1_t.TabIndex = 0;
            this.con_last_work_msr_1_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_last_work_msr_1_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.con_last_work_msr_1_t.Text = "Last Work Msrmnt Check";
            #endregion
            this.Controls.Add(con_last_work_msr_1_t);

            #region con_last_work_msr_1 define
            this.con_last_work_msr_1 = new DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();
            this.con_last_work_msr_1.Name = "con_last_work_msr_1";
            this.con_last_work_msr_1.Location = new System.Drawing.Point(146, 160);
            this.con_last_work_msr_1.Size = new System.Drawing.Size(74, 20);
            this.con_last_work_msr_1.TabIndex = 90;
            this.con_last_work_msr_1.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_last_work_msr_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_last_work_msr_1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastWorkMsr1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_work_msr_1.Mask = "00/00/0000";
            //this.con_last_work_msr_1.PromptChar = '0';
            this.con_last_work_msr_1.ValidatingType = typeof(System.DateTime?);
            this.con_last_work_msr_1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_work_msr_1.DataBindings[0].FormatString = "dd/MM/yyyy";
            //this.con_last_work_msr_1.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(DateTime_TypeValidationCompleted);
            //this.con_last_work_msr_1.Validated += new System.EventHandler(DateTime_Validated);
            #endregion
            this.Controls.Add(con_last_work_msr_1);

            #region con_last_work_msr_2 define
            this.con_last_work_msr_2 = new DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();
            this.con_last_work_msr_2.Name = "con_last_work_msr_2";
            this.con_last_work_msr_2.Location = new System.Drawing.Point(227, 160);
            this.con_last_work_msr_2.Size = new System.Drawing.Size(74, 20);
            this.con_last_work_msr_2.TabIndex = 100;
            this.con_last_work_msr_2.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.con_last_work_msr_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_last_work_msr_2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastWorkMsr2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_work_msr_2.Mask = "00/00/0000";
            //this.con_last_work_msr_2.PromptChar = '0';
            this.con_last_work_msr_2.ValidatingType = typeof(System.DateTime?);
            this.con_last_work_msr_2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_work_msr_2.DataBindings[0].FormatString = "dd/MM/yyyy";
            //this.con_last_work_msr_2.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(DateTime_TypeValidationCompleted);
            //this.con_last_work_msr_2.Validated += new System.EventHandler(DateTime_Validated);
            #endregion
            this.Controls.Add(con_last_work_msr_2);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.PerformLayout();
        }

        //private void DateTime_Validated(object sender, System.EventArgs e)
        //{
        //    System.Windows.Forms.MaskedTextBox textBox = (System.Windows.Forms.MaskedTextBox)sender;
        //    if (textBox.Text == "01/01/0001")
        //    {
        //        textBox.Text = "00/00/0000";
        //    }
        //}

        //private void DateTime_TypeValidationCompleted(object sender, System.Windows.Forms.TypeValidationEventArgs e)
        //{
        //    System.Windows.Forms.MaskedTextBox textBox = (System.Windows.Forms.MaskedTextBox)sender;
        //    if (textBox.Text == "00/00/0000")
        //    {
        //        textBox.Text = new System.DateTime?().GetValueOrDefault().ToString();
        //    }
        //}

        #endregion

        private System.Windows.Forms.Label n_1886449;
        private System.Windows.Forms.Label rg_code_t;
        private NumericalMaskedTextBox contract_no;
        private System.Windows.Forms.Label region_id_t;
        private System.Windows.Forms.Label con_title_t;
        private System.Windows.Forms.Label con_old_mail_service_no_t;
        private System.Windows.Forms.TextBox con_old_mail_service_no;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.TextBox con_title;
        private Metex.Windows.DataEntityCombo ct_key;
        private System.Windows.Forms.Label n_16978042;
        private System.Windows.Forms.Label n_18584657;
        private System.Windows.Forms.Label n_33044190;
        private System.Windows.Forms.Label con_last_service_review_1_t;
        private DateTimeMaskedTextBox con_last_service_review_1;// System.Windows.Forms.MaskedTextBox con_last_service_review_1;
        private DateTimeMaskedTextBox con_last_service_review_2;// System.Windows.Forms.MaskedTextBox con_last_service_review_2;
        private System.Windows.Forms.Label con_last_delivery_check_1_t;
        private DateTimeMaskedTextBox con_last_delivery_check_1;// System.Windows.Forms.MaskedTextBox con_last_delivery_check_1;
        private DateTimeMaskedTextBox con_last_delivery_check_2;// System.Windows.Forms.MaskedTextBox con_last_delivery_check_2;
        private System.Windows.Forms.Label con_last_work_msr_1_t;
        private DateTimeMaskedTextBox con_last_work_msr_1;// System.Windows.Forms.MaskedTextBox con_last_work_msr_1;
        private DateTimeMaskedTextBox con_last_work_msr_2;// System.Windows.Forms.MaskedTextBox con_last_work_msr_2;
        //  private DateTimeMaskedTextBox con_last_work_msr_2;
    }
}
