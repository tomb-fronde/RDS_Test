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
            this.n_1886449 = new System.Windows.Forms.Label();
            this.rg_code_t = new System.Windows.Forms.Label();
            this.contract_no = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.region_id_t = new System.Windows.Forms.Label();
            this.con_title_t = new System.Windows.Forms.Label();
            this.con_old_mail_service_no_t = new System.Windows.Forms.Label();
            this.con_old_mail_service_no = new System.Windows.Forms.TextBox();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.con_title = new System.Windows.Forms.TextBox();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.n_16978042 = new System.Windows.Forms.Label();
            this.n_18584657 = new System.Windows.Forms.Label();
            this.n_33044190 = new System.Windows.Forms.Label();
            this.con_last_service_review_1_t = new System.Windows.Forms.Label();
            this.con_last_service_review_1 = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.con_last_service_review_2 = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.con_last_delivery_check_1_t = new System.Windows.Forms.Label();
            this.con_last_delivery_check_1 = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.con_last_delivery_check_2 = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.con_last_work_msr_1_t = new System.Windows.Forms.Label();
            this.con_last_work_msr_1 = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.con_last_work_msr_2 = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.pbu_id = new Metex.Windows.DataEntityCombo();
            this.pbu_id_t = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractSearch);
            // 
            // n_1886449
            // 
            this.n_1886449.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.n_1886449.Location = new System.Drawing.Point(145, 1);
            this.n_1886449.Name = "n_1886449";
            this.n_1886449.Size = new System.Drawing.Size(113, 13);
            this.n_1886449.TabIndex = 0;
            this.n_1886449.Text = "Search Criteria";
            this.n_1886449.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rg_code_t
            // 
            this.rg_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code_t.Location = new System.Drawing.Point(76, 25);
            this.rg_code_t.Name = "rg_code_t";
            this.rg_code_t.Size = new System.Drawing.Size(65, 13);
            this.rg_code_t.TabIndex = 0;
            this.rg_code_t.Text = "Contract No";
            this.rg_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_no
            // 
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.EditMask = "######";
            this.contract_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.contract_no.Location = new System.Drawing.Point(146, 18);
            this.contract_no.Name = "contract_no";
            this.contract_no.PromptChar = ' ';
            this.contract_no.Size = new System.Drawing.Size(56, 20);
            this.contract_no.TabIndex = 10;
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.contract_no.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.contract_no.Value = "";
            // 
            // region_id_t
            // 
            this.region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_t.Location = new System.Drawing.Point(99, 47);
            this.region_id_t.Name = "region_id_t";
            this.region_id_t.Size = new System.Drawing.Size(41, 13);
            this.region_id_t.TabIndex = 0;
            this.region_id_t.Text = "Region";
            this.region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_title_t
            // 
            this.con_title_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_title_t.Location = new System.Drawing.Point(67, 68);
            this.con_title_t.Name = "con_title_t";
            this.con_title_t.Size = new System.Drawing.Size(73, 13);
            this.con_title_t.TabIndex = 0;
            this.con_title_t.Text = "Contract Title";
            this.con_title_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_old_mail_service_no_t
            // 
            this.con_old_mail_service_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_old_mail_service_no_t.Location = new System.Drawing.Point(365, 84);
            this.con_old_mail_service_no_t.Name = "con_old_mail_service_no_t";
            this.con_old_mail_service_no_t.Size = new System.Drawing.Size(85, 13);
            this.con_old_mail_service_no_t.TabIndex = 0;
            this.con_old_mail_service_no_t.Text = "Mail Service No";
            this.con_old_mail_service_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_old_mail_service_no
            // 
            this.con_old_mail_service_no.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.con_old_mail_service_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConOldMailServiceNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_old_mail_service_no.Enabled = false;
            this.con_old_mail_service_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_old_mail_service_no.Location = new System.Drawing.Point(457, 81);
            this.con_old_mail_service_no.MaxLength = 6;
            this.con_old_mail_service_no.Name = "con_old_mail_service_no";
            this.con_old_mail_service_no.Size = new System.Drawing.Size(67, 20);
            this.con_old_mail_service_no.TabIndex = 0;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.Location = new System.Drawing.Point(146, 40);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(185, 21);
            this.region_id.TabIndex = 11;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // con_title
            // 
            this.con_title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_title.Location = new System.Drawing.Point(146, 62);
            this.con_title.MaxLength = 60;
            this.con_title.Name = "con_title";
            this.con_title.Size = new System.Drawing.Size(185, 20);
            this.con_title.TabIndex = 30;
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ct_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ct_key.Location = new System.Drawing.Point(146, 83);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(185, 21);
            this.ct_key.TabIndex = 31;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";
            // 
            // n_16978042
            // 
            this.n_16978042.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_16978042.Location = new System.Drawing.Point(38, 90);
            this.n_16978042.Name = "n_16978042";
            this.n_16978042.Size = new System.Drawing.Size(101, 13);
            this.n_16978042.TabIndex = 0;
            this.n_16978042.Text = "Contract Type";
            this.n_16978042.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_18584657
            // 
            this.n_18584657.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_18584657.Location = new System.Drawing.Point(146, 140);
            this.n_18584657.Name = "n_18584657";
            this.n_18584657.Size = new System.Drawing.Size(31, 13);
            this.n_18584657.TabIndex = 0;
            this.n_18584657.Text = "From";
            this.n_18584657.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_33044190
            // 
            this.n_33044190.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_33044190.Location = new System.Drawing.Point(228, 140);
            this.n_33044190.Name = "n_33044190";
            this.n_33044190.Size = new System.Drawing.Size(20, 13);
            this.n_33044190.TabIndex = 0;
            this.n_33044190.Text = "To";
            this.n_33044190.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_last_service_review_1_t
            // 
            this.con_last_service_review_1_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_service_review_1_t.Location = new System.Drawing.Point(27, 157);
            this.con_last_service_review_1_t.Name = "con_last_service_review_1_t";
            this.con_last_service_review_1_t.Size = new System.Drawing.Size(113, 13);
            this.con_last_service_review_1_t.TabIndex = 0;
            this.con_last_service_review_1_t.Text = "Last Service Review";
            this.con_last_service_review_1_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_last_service_review_1
            // 
            this.con_last_service_review_1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastServiceReview1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_service_review_1.EditMask = "";
            this.con_last_service_review_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_service_review_1.Location = new System.Drawing.Point(146, 153);
            this.con_last_service_review_1.Mask = "00/00/0000";
            this.con_last_service_review_1.Name = "con_last_service_review_1";
            this.con_last_service_review_1.Size = new System.Drawing.Size(74, 20);
            this.con_last_service_review_1.TabIndex = 50;
            this.con_last_service_review_1.Text = "00000000";
            this.con_last_service_review_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_last_service_review_1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_service_review_1.ValidatingType = typeof(System.Nullable<System.DateTime>);
            this.con_last_service_review_1.Value = null;
            // 
            // con_last_service_review_2
            // 
            this.con_last_service_review_2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastServiceReview2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_service_review_2.EditMask = "";
            this.con_last_service_review_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_service_review_2.Location = new System.Drawing.Point(227, 153);
            this.con_last_service_review_2.Mask = "00/00/0000";
            this.con_last_service_review_2.Name = "con_last_service_review_2";
            this.con_last_service_review_2.Size = new System.Drawing.Size(74, 20);
            this.con_last_service_review_2.TabIndex = 60;
            this.con_last_service_review_2.Text = "00000000";
            this.con_last_service_review_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_last_service_review_2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_service_review_2.ValidatingType = typeof(System.Nullable<System.DateTime>);
            this.con_last_service_review_2.Value = null;
            // 
            // con_last_delivery_check_1_t
            // 
            this.con_last_delivery_check_1_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_delivery_check_1_t.Location = new System.Drawing.Point(32, 180);
            this.con_last_delivery_check_1_t.Name = "con_last_delivery_check_1_t";
            this.con_last_delivery_check_1_t.Size = new System.Drawing.Size(108, 13);
            this.con_last_delivery_check_1_t.TabIndex = 0;
            this.con_last_delivery_check_1_t.Text = "Last Delivery Check";
            this.con_last_delivery_check_1_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_last_delivery_check_1
            // 
            this.con_last_delivery_check_1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastDeliveryCheck1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_delivery_check_1.EditMask = "";
            this.con_last_delivery_check_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_delivery_check_1.Location = new System.Drawing.Point(146, 175);
            this.con_last_delivery_check_1.Mask = "00/00/0000";
            this.con_last_delivery_check_1.Name = "con_last_delivery_check_1";
            this.con_last_delivery_check_1.Size = new System.Drawing.Size(74, 20);
            this.con_last_delivery_check_1.TabIndex = 70;
            this.con_last_delivery_check_1.Text = "00000000";
            this.con_last_delivery_check_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_last_delivery_check_1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_delivery_check_1.ValidatingType = typeof(System.Nullable<System.DateTime>);
            this.con_last_delivery_check_1.Value = null;
            // 
            // con_last_delivery_check_2
            // 
            this.con_last_delivery_check_2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastDeliveryCheck2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_delivery_check_2.EditMask = "";
            this.con_last_delivery_check_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_delivery_check_2.Location = new System.Drawing.Point(227, 175);
            this.con_last_delivery_check_2.Mask = "00/00/0000";
            this.con_last_delivery_check_2.Name = "con_last_delivery_check_2";
            this.con_last_delivery_check_2.Size = new System.Drawing.Size(74, 20);
            this.con_last_delivery_check_2.TabIndex = 80;
            this.con_last_delivery_check_2.Text = "00000000";
            this.con_last_delivery_check_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_last_delivery_check_2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_delivery_check_2.ValidatingType = typeof(System.Nullable<System.DateTime>);
            this.con_last_delivery_check_2.Value = null;
            // 
            // con_last_work_msr_1_t
            // 
            this.con_last_work_msr_1_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_work_msr_1_t.Location = new System.Drawing.Point(3, 200);
            this.con_last_work_msr_1_t.Name = "con_last_work_msr_1_t";
            this.con_last_work_msr_1_t.Size = new System.Drawing.Size(137, 13);
            this.con_last_work_msr_1_t.TabIndex = 0;
            this.con_last_work_msr_1_t.Text = "Last Work Msrmnt Check";
            this.con_last_work_msr_1_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_last_work_msr_1
            // 
            this.con_last_work_msr_1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastWorkMsr1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_work_msr_1.EditMask = "";
            this.con_last_work_msr_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_work_msr_1.Location = new System.Drawing.Point(146, 195);
            this.con_last_work_msr_1.Mask = "00/00/0000";
            this.con_last_work_msr_1.Name = "con_last_work_msr_1";
            this.con_last_work_msr_1.Size = new System.Drawing.Size(74, 20);
            this.con_last_work_msr_1.TabIndex = 90;
            this.con_last_work_msr_1.Text = "00000000";
            this.con_last_work_msr_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_last_work_msr_1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_work_msr_1.ValidatingType = typeof(System.Nullable<System.DateTime>);
            this.con_last_work_msr_1.Value = null;
            // 
            // con_last_work_msr_2
            // 
            this.con_last_work_msr_2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastWorkMsr2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_work_msr_2.EditMask = "";
            this.con_last_work_msr_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_work_msr_2.Location = new System.Drawing.Point(227, 195);
            this.con_last_work_msr_2.Mask = "00/00/0000";
            this.con_last_work_msr_2.Name = "con_last_work_msr_2";
            this.con_last_work_msr_2.Size = new System.Drawing.Size(74, 20);
            this.con_last_work_msr_2.TabIndex = 100;
            this.con_last_work_msr_2.Text = "00000000";
            this.con_last_work_msr_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_last_work_msr_2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_work_msr_2.ValidatingType = typeof(System.Nullable<System.DateTime>);
            this.con_last_work_msr_2.Value = null;
            // 
            // pbu_id
            // 
            this.pbu_id.AutoRetrieve = true;
            this.pbu_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "PbuId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbu_id.DisplayMember = "PbuCode";
            this.pbu_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pbu_id.Location = new System.Drawing.Point(146, 110);
            this.pbu_id.Name = "pbu_id";
            this.pbu_id.Size = new System.Drawing.Size(185, 21);
            this.pbu_id.TabIndex = 102;
            this.pbu_id.Value = null;
            this.pbu_id.ValueMember = "PbuId";
            this.pbu_id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.pbu_id.DropDownWidth = 240;
            this.pbu_id.SelectedIndexChanged += new System.EventHandler(pbu_id_SelectedIndexChanged);//add by ybfan
            this.pbu_id.Click += new System.EventHandler(pbu_id_Click);
            this.pbu_id.LostFocus += new System.EventHandler(pbu_id_LostFocus);
            // 
            // pbu_id_t
            // 
            this.pbu_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pbu_id_t.Location = new System.Drawing.Point(38, 117);
            this.pbu_id_t.Name = "pbu_id_t";
            this.pbu_id_t.Size = new System.Drawing.Size(101, 13);
            this.pbu_id_t.TabIndex = 0;
            this.pbu_id_t.Text = "PBU Code";
            this.pbu_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DContractSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbu_id);
            this.Controls.Add(this.pbu_id_t);
            this.Controls.Add(this.n_1886449);
            this.Controls.Add(this.rg_code_t);
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.region_id_t);
            this.Controls.Add(this.con_title_t);
            this.Controls.Add(this.con_old_mail_service_no_t);
            this.Controls.Add(this.con_old_mail_service_no);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.con_title);
            this.Controls.Add(this.ct_key);
            this.Controls.Add(this.n_16978042);
            this.Controls.Add(this.n_18584657);
            this.Controls.Add(this.n_33044190);
            this.Controls.Add(this.con_last_service_review_1_t);
            this.Controls.Add(this.con_last_service_review_1);
            this.Controls.Add(this.con_last_service_review_2);
            this.Controls.Add(this.con_last_delivery_check_1_t);
            this.Controls.Add(this.con_last_delivery_check_1);
            this.Controls.Add(this.con_last_delivery_check_2);
            this.Controls.Add(this.con_last_work_msr_1_t);
            this.Controls.Add(this.con_last_work_msr_1);
            this.Controls.Add(this.con_last_work_msr_2);
            this.Name = "DContractSearch";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
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

        void pbu_id_LostFocus(object sender, System.EventArgs e)
        {
            this.pbu_id.DisplayMember = "PbuCode";
        }

        void pbu_id_Click(object sender, System.EventArgs e)
        {
            if (this.pbu_id.DroppedDown)
            {
                this.pbu_id.DisplayMember = "";
            }
            else
            {
                this.pbu_id.DisplayMember = "PbuCode";
            }
        }

        //add by ybfan
        void pbu_id_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int li_index = this.pbu_id.SelectedIndex;
            this.pbu_id.DisplayMember = "PbuCode";
            this.pbu_id.SelectedIndex = li_index;
            this.AcceptText();

            // if the column is not checked in itemchanged event below is not needed
            if (this.RowCount > 0)
            {
                this.OnItemChanged(this.pbu_id, new System.EventArgs());
            }
        }

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
        private DateTimeMaskedTextBox con_last_work_msr_2;
        private Metex.Windows.DataEntityCombo pbu_id;
        private System.Windows.Forms.Label pbu_id_t;// System.Windows.Forms.MaskedTextBox con_last_work_msr_2;
        //  private DateTimeMaskedTextBox con_last_work_msr_2;
    }
}
