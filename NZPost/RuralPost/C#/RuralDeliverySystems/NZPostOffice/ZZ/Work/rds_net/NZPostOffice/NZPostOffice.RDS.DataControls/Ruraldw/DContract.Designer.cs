using System.Windows.Forms;
using System.Collections.Generic;

using NZPostOffice.RDS.Entity.Ruraldw;


namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContract
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
            this.t_1 = new System.Windows.Forms.Label();
            this.t_2 = new System.Windows.Forms.Label();
            this.pbu_id = new Metex.Windows.DataEntityCombo();
            this.con_rd_paper_file_text_t = new System.Windows.Forms.Label();
            this.con_rcm_paper_file_text_t = new System.Windows.Forms.Label();
            this.con_rd_paper_file_text = new System.Windows.Forms.RichTextBox();
            this.con_rcm_paper_file_text = new System.Windows.Forms.RichTextBox();
            this.lo_picklist = new System.Windows.Forms.CheckBox();
            this.bo_picklist = new System.Windows.Forms.CheckBox();
            this.con_base_office = new System.Windows.Forms.TextBox();
            this.con_last_service_review_t = new System.Windows.Forms.Label();
            this.con_last_delivery_check_t = new System.Windows.Forms.Label();
            this.con_last_work_msrmnt_check_t = new System.Windows.Forms.Label();
            this.message_for_invoice = new System.Windows.Forms.TextBox();
            this.con_last_service_review = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();// MaskedTextBox();
            this.con_last_delivery_check = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();// MaskedTextBox();
            this.con_last_work_msrmnt_check = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();// MaskedTextBox();
            this.con_date_terminated = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();

            this.con_base_office_name_t = new System.Windows.Forms.Label();
            this.t_4 = new System.Windows.Forms.Label();
            this.con_rd_ref_text_t = new System.Windows.Forms.Label();
            this.con_title = new System.Windows.Forms.TextBox();
            this.con_base_office_type = new System.Windows.Forms.TextBox();
            this.con_lodgement_office_type = new System.Windows.Forms.TextBox();
            this.con_rd_ref_text = new System.Windows.Forms.TextBox();
            this.con_base_office_name = new System.Windows.Forms.TextBox();
            this.bo_button = new System.Windows.Forms.Button();
            this.t_3 = new System.Windows.Forms.Label();
            this.con_title_t = new System.Windows.Forms.Label();
            this.con_lodgement_office_name_t = new System.Windows.Forms.Label();
            this.con_lodgement_office_name = new System.Windows.Forms.TextBox();
            this.lo_button = new System.Windows.Forms.Button();
            this.con_date_terminated_t = new System.Windows.Forms.Label();
            this.con_base_cont_type_t = new System.Windows.Forms.Label();
            this.contract_no_t = new System.Windows.Forms.Label();
            this.contract_no = new System.Windows.Forms.TextBox();
            this.rg_code_t = new System.Windows.Forms.Label();
            this.con_old_mail_service_no_t = new System.Windows.Forms.Label();
            this.con_old_mail_service_no = new System.Windows.Forms.TextBox();
            this.gb_3 = new System.Windows.Forms.GroupBox();
            this.gb_2 = new System.Windows.Forms.GroupBox();
            this.gb_1 = new System.Windows.Forms.GroupBox();
            
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.ac_id = new Metex.Windows.DataEntityCombo();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.bo_button)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.lo_button)).BeginInit();
            this.gb_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.Contract);
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.Location = new System.Drawing.Point(303, 175);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(60, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "PBU Code";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_2
            // 
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.Location = new System.Drawing.Point(285, 155);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(78, 13);
            this.t_2.TabIndex = 0;
            this.t_2.Text = "Account Code";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbu_id
            // 
            this.pbu_id.AutoRetrieve = true;
            this.pbu_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "PbuId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbu_id.DisplayMember = "PbuCode";
            this.pbu_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pbu_id.Location = new System.Drawing.Point(364, 172);
            this.pbu_id.Name = "pbu_id";
            this.pbu_id.Size = new System.Drawing.Size(130, 21);
            this.pbu_id.TabIndex = 170;
            this.pbu_id.Value = null;
            this.pbu_id.ValueMember = "PbuId";
            this.pbu_id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.pbu_id.DropDownWidth = 180;
            this.pbu_id.SelectedIndexChanged += new System.EventHandler(pbu_id_SelectedIndexChanged);//add by ybfan
            this.pbu_id.Click += new System.EventHandler(pbu_id_Click);
            this.pbu_id.LostFocus += new System.EventHandler(pbu_id_LostFocus);
            // 
            // con_rd_paper_file_text_t
            // 
            this.con_rd_paper_file_text_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_rd_paper_file_text_t.Location = new System.Drawing.Point(286, 70);
            this.con_rd_paper_file_text_t.Name = "con_rd_paper_file_text_t";
            this.con_rd_paper_file_text_t.Size = new System.Drawing.Size(76, 13);
            this.con_rd_paper_file_text_t.TabIndex = 0;
            this.con_rd_paper_file_text_t.Text = "RD Paper File";
            this.con_rd_paper_file_text_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_rcm_paper_file_text_t
            // 
            this.con_rcm_paper_file_text_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_rcm_paper_file_text_t.Location = new System.Drawing.Point(278, 101);
            this.con_rcm_paper_file_text_t.Name = "con_rcm_paper_file_text_t";
            this.con_rcm_paper_file_text_t.Size = new System.Drawing.Size(84, 13);
            this.con_rcm_paper_file_text_t.TabIndex = 0;
            this.con_rcm_paper_file_text_t.Text = "RCM Paper File";
            this.con_rcm_paper_file_text_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_rd_paper_file_text
            // 
            this.con_rd_paper_file_text.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConRdPaperFileText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_rd_paper_file_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_rd_paper_file_text.Location = new System.Drawing.Point(364, 68);
            this.con_rd_paper_file_text.MaxLength = 40;
            this.con_rd_paper_file_text.Multiline = true;
            this.con_rd_paper_file_text.Name = "con_rd_paper_file_text";
            this.con_rd_paper_file_text.Size = new System.Drawing.Size(130, 32);
            this.con_rd_paper_file_text.TabIndex = 130;
            // 
            // con_rcm_paper_file_text
            // 
            this.con_rcm_paper_file_text.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConRcmPaperFileText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_rcm_paper_file_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_rcm_paper_file_text.Location = new System.Drawing.Point(364, 100);
            this.con_rcm_paper_file_text.MaxLength = 40;
            this.con_rcm_paper_file_text.Multiline = true;
            this.con_rcm_paper_file_text.Name = "con_rcm_paper_file_text";
            this.con_rcm_paper_file_text.Size = new System.Drawing.Size(130, 32);
            this.con_rcm_paper_file_text.TabIndex = 140;
            // 
            // lo_picklist
            // 
            this.lo_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "LoPicklist", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lo_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lo_picklist.Location = new System.Drawing.Point(289, 392);
            this.lo_picklist.Name = "lo_picklist";
            this.lo_picklist.Size = new System.Drawing.Size(1, 1);
            this.lo_picklist.TabIndex = 60;
            // 
            // bo_picklist
            // 
            this.bo_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "BoPicklist", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.bo_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bo_picklist.Location = new System.Drawing.Point(291, 384);
            this.bo_picklist.Name = "bo_picklist";
            this.bo_picklist.Size = new System.Drawing.Size(1, 1);
            this.bo_picklist.TabIndex = 40;
            // 
            // con_base_office
            // 
            this.con_base_office.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConBaseOffice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_base_office.ReadOnly = true;
            this.con_base_office.Font = new System.Drawing.Font("Arial", 12F);
            this.con_base_office.Location = new System.Drawing.Point(216, 202);
            this.con_base_office.Name = "con_base_office";
            this.con_base_office.Size = new System.Drawing.Size(65, 26);
            this.con_base_office.TabIndex = 0;
            this.con_base_office.Visible = false;
            // 
            // con_last_service_review_t
            // 
            this.con_last_service_review_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_service_review_t.Location = new System.Drawing.Point(9, 212);
            this.con_last_service_review_t.Name = "con_last_service_review_t";
            this.con_last_service_review_t.Size = new System.Drawing.Size(70, 13);
            this.con_last_service_review_t.TabIndex = 0;
            this.con_last_service_review_t.Text = "Service Rev";
            this.con_last_service_review_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // con_last_delivery_check_t
            // 
            this.con_last_delivery_check_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_delivery_check_t.Location = new System.Drawing.Point(9, 232);
            this.con_last_delivery_check_t.Name = "con_last_delivery_check_t";
            this.con_last_delivery_check_t.Size = new System.Drawing.Size(70, 13);
            this.con_last_delivery_check_t.TabIndex = 0;
            this.con_last_delivery_check_t.Text = "Del. Check";
            this.con_last_delivery_check_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_last_work_msrmnt_check_t
            // 
            this.con_last_work_msrmnt_check_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_work_msrmnt_check_t.Location = new System.Drawing.Point(9, 252);
            this.con_last_work_msrmnt_check_t.Name = "con_last_work_msrmnt_check_t";
            this.con_last_work_msrmnt_check_t.Size = new System.Drawing.Size(70, 13);
            this.con_last_work_msrmnt_check_t.TabIndex = 0;
            this.con_last_work_msrmnt_check_t.Text = "Work Msrmnt";
            this.con_last_work_msrmnt_check_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // message_for_invoice
            // 
            this.message_for_invoice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "MessageForInvoice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.message_for_invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.message_for_invoice.Location = new System.Drawing.Point(180, 207);
            this.message_for_invoice.Multiline = true;
            this.message_for_invoice.Name = "message_for_invoice";
            this.message_for_invoice.Size = new System.Drawing.Size(309, 74);
            this.message_for_invoice.TabIndex = 180;
            // 
            // con_last_service_review
            // 
            this.con_last_service_review.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastServiceReview", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_service_review.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_service_review.Location = new System.Drawing.Point(79, 209);
            this.con_last_service_review.Mask = "00/00/0000";
            this.con_last_service_review.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.con_last_service_review.Name = "con_last_service_review";
            this.con_last_service_review.Size = new System.Drawing.Size(74, 20);
            this.con_last_service_review.TabIndex = 80;
            this.con_last_service_review.ValidatingType = typeof(System.DateTime);
            //this.con_last_service_review.PromptChar = '0';
            //this.con_last_service_review.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            //this.con_last_service_review.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            //this.con_last_service_review.DataBindings[0].DataSourceNullValue = null;
            //this.con_last_service_review.TypeValidationCompleted += new TypeValidationEventHandler(DateTime_TypeValidationCompleted);
            // 
            // con_last_delivery_check
            // 
            this.con_last_delivery_check.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastDeliveryCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_delivery_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_delivery_check.Location = new System.Drawing.Point(79, 229);
            this.con_last_delivery_check.Mask = "00/00/0000";
            this.con_last_delivery_check.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.con_last_delivery_check.Name = "con_last_delivery_check";
            this.con_last_delivery_check.Size = new System.Drawing.Size(74, 20);
            this.con_last_delivery_check.TabIndex = 90;
            this.con_last_delivery_check.ValidatingType = typeof(System.DateTime);
            //this.con_last_delivery_check.PromptChar = '0';
            //this.con_last_delivery_check.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            //this.con_last_delivery_check.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            //this.con_last_delivery_check.DataBindings[0].DataSourceNullValue = null;
            //this.con_last_delivery_check.TypeValidationCompleted += new TypeValidationEventHandler(DateTime_TypeValidationCompleted);
            // 
            // con_last_work_msrmnt_check
            // 
            this.con_last_work_msrmnt_check.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConLastWorkMsrmntCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_last_work_msrmnt_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_last_work_msrmnt_check.Location = new System.Drawing.Point(79, 249);
            this.con_last_work_msrmnt_check.Mask = "00/00/0000";
            this.con_last_work_msrmnt_check.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.con_last_work_msrmnt_check.Name = "con_last_work_msrmnt_check";
            this.con_last_work_msrmnt_check.Size = new System.Drawing.Size(74, 20);
            this.con_last_work_msrmnt_check.TabIndex = 100;
            this.con_last_work_msrmnt_check.ValidatingType = typeof(System.DateTime);
            //this.con_last_work_msrmnt_check.PromptChar = '0';
            //this.con_last_work_msrmnt_check.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            //this.con_last_work_msrmnt_check.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_last_work_msrmnt_check.DataBindings[0].DataSourceNullValue = null;
            //this.con_last_work_msrmnt_check.TypeValidationCompleted += new TypeValidationEventHandler(DateTime_TypeValidationCompleted);
            // 
            // con_base_office_name_t
            // 
            this.con_base_office_name_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_base_office_name_t.Location = new System.Drawing.Point(16, 90);
            this.con_base_office_name_t.Name = "con_base_office_name_t";
            this.con_base_office_name_t.Size = new System.Drawing.Size(76, 12);
            this.con_base_office_name_t.TabIndex = 0;
            this.con_base_office_name_t.Text = "Base Office";
            this.con_base_office_name_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_4
            // 
            this.t_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_4.Location = new System.Drawing.Point(7, 154);
            this.t_4.Name = "t_4";
            this.t_4.Size = new System.Drawing.Size(85, 13);
            this.t_4.TabIndex = 0;
            this.t_4.Text = "Lodgment Type";
            this.t_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_rd_ref_text_t
            // 
            this.con_rd_ref_text_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_rd_ref_text_t.Location = new System.Drawing.Point(22, 175);
            this.con_rd_ref_text_t.Name = "con_rd_ref_text_t";
            this.con_rd_ref_text_t.Size = new System.Drawing.Size(70, 13);
            this.con_rd_ref_text_t.TabIndex = 0;
            this.con_rd_ref_text_t.Text = "RD Ref Text";
            this.con_rd_ref_text_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_title
            // 
            this.con_title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_title.Location = new System.Drawing.Point(93, 28);
            this.con_title.MaxLength = 100;
            this.con_title.Multiline = true;
            this.con_title.Name = "con_title";
            this.con_title.Size = new System.Drawing.Size(181, 55);
            this.con_title.TabIndex = 10;
            this.con_title.BackColor = System.Drawing.Color.Aqua;
            // 
            // con_base_office_type
            // 
            this.con_base_office_type.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConBaseOfficeType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_base_office_type.ReadOnly = true;
            this.con_base_office_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_base_office_type.Location = new System.Drawing.Point(93, 107);
            this.con_base_office_type.Name = "con_base_office_type";
            this.con_base_office_type.Size = new System.Drawing.Size(151, 20);
            this.con_base_office_type.TabIndex = 0;
            this.con_base_office_type.BackColor = System.Drawing.Color.Aqua;
            // 
            // con_lodgement_office_type
            // 
            this.con_lodgement_office_type.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConLodgementOfficeType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_lodgement_office_type.ReadOnly = true;
            this.con_lodgement_office_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_lodgement_office_type.Location = new System.Drawing.Point(93, 151);
            this.con_lodgement_office_type.Name = "con_lodgement_office_type";
            this.con_lodgement_office_type.Size = new System.Drawing.Size(151, 20);
            this.con_lodgement_office_type.TabIndex = 0;
            this.con_lodgement_office_type.BackColor = System.Drawing.Color.Aqua;
            // 
            // con_rd_ref_text
            // 
            this.con_rd_ref_text.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConRdRefText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_rd_ref_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_rd_ref_text.Location = new System.Drawing.Point(93, 173);
            this.con_rd_ref_text.MaxLength = 35;
            this.con_rd_ref_text.Name = "con_rd_ref_text";
            this.con_rd_ref_text.Size = new System.Drawing.Size(180, 20);
            this.con_rd_ref_text.TabIndex = 70;
            this.con_rd_ref_text.BackColor = System.Drawing.Color.Aqua;
            // 
            // con_base_office_name
            // 
            this.con_base_office_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConBaseOfficeName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_base_office_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_base_office_name.Location = new System.Drawing.Point(93, 85);
            this.con_base_office_name.MaxLength = 40;
            this.con_base_office_name.Name = "con_base_office_name";
            this.con_base_office_name.Size = new System.Drawing.Size(163, 20);
            this.con_base_office_name.TabIndex = 30;
            this.con_base_office_name.BackColor = System.Drawing.Color.Aqua;
            // 
            // bo_button
            // 
            this.bo_button.Location = new System.Drawing.Point(257, 85);
            this.bo_button.Name = "bo_button";
            this.bo_button.Size = new System.Drawing.Size(20, 20);
            this.bo_button.TabIndex = 0;
            this.bo_button.TabStop = false;
            this.bo_button.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;
            // 
            // t_3
            // 
            this.t_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_3.Location = new System.Drawing.Point(33, 111);
            this.t_3.Name = "t_3";
            this.t_3.Size = new System.Drawing.Size(59, 13);
            this.t_3.TabIndex = 0;
            this.t_3.Text = "Base Type";
            this.t_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_title_t
            // 
            this.con_title_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_title_t.Location = new System.Drawing.Point(21, 30);
            this.con_title_t.Name = "con_title_t";
            this.con_title_t.Size = new System.Drawing.Size(70, 13);
            this.con_title_t.TabIndex = 0;
            this.con_title_t.Text = "Contract Title";
            this.con_title_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_lodgement_office_name_t
            // 
            this.con_lodgement_office_name_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_lodgement_office_name_t.Location = new System.Drawing.Point(8, 133);
            this.con_lodgement_office_name_t.Name = "con_lodgement_office_name_t";
            this.con_lodgement_office_name_t.Size = new System.Drawing.Size(85, 13);
            this.con_lodgement_office_name_t.TabIndex = 0;
            this.con_lodgement_office_name_t.Text = "Lodgment Office";
            this.con_lodgement_office_name_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_lodgement_office_name
            // 
            this.con_lodgement_office_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConLodgementOfficeName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_lodgement_office_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_lodgement_office_name.Location = new System.Drawing.Point(93, 129);
            this.con_lodgement_office_name.MaxLength = 40;
            this.con_lodgement_office_name.Name = "con_lodgement_office_name";
            this.con_lodgement_office_name.Size = new System.Drawing.Size(162, 20);
            this.con_lodgement_office_name.TabIndex = 50;
            // 
            // lo_button
            // 
            this.lo_button.Location = new System.Drawing.Point(257, 129);
            this.lo_button.Name = "lo_button";
            this.lo_button.Size = new System.Drawing.Size(20, 20);
            this.lo_button.TabIndex = 0;
            this.lo_button.TabStop = false;
            this.lo_button.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;
            // 
            // con_date_terminated_t
            // 
            this.con_date_terminated_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_date_terminated_t.Location = new System.Drawing.Point(299, 134);
            this.con_date_terminated_t.Name = "con_date_terminated_t";
            this.con_date_terminated_t.Size = new System.Drawing.Size(63, 13);
            this.con_date_terminated_t.TabIndex = 0;
            this.con_date_terminated_t.Text = "Terminated";
            this.con_date_terminated_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_base_cont_type_t
            // 
            this.con_base_cont_type_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_base_cont_type_t.Location = new System.Drawing.Point(280, 52);
            this.con_base_cont_type_t.Name = "con_base_cont_type_t";
            this.con_base_cont_type_t.Size = new System.Drawing.Size(82, 13);
            this.con_base_cont_type_t.TabIndex = 0;
            this.con_base_cont_type_t.Text = "Def. Con. Type";
            this.con_base_cont_type_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_no_t
            // 
            this.contract_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no_t.Location = new System.Drawing.Point(16, 12);
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Size = new System.Drawing.Size(75, 13);
            this.contract_no_t.TabIndex = 0;
            this.contract_no_t.Text = "Contract No";
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_no
            // 
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.ReadOnly = true ;
            this.contract_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no.Location = new System.Drawing.Point(93, 12);
            this.contract_no.Name = "contract_no";
            this.contract_no.Size = new System.Drawing.Size(60, 13);
            this.contract_no.TabIndex = 0;
            this.contract_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
            // 
            // rg_code_t
            // 
            this.rg_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code_t.Location = new System.Drawing.Point(279, 30);
            this.rg_code_t.Name = "rg_code_t";
            this.rg_code_t.Size = new System.Drawing.Size(84, 13);
            this.rg_code_t.TabIndex = 0;
            this.rg_code_t.Text = "Renewal Group";
            this.rg_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_old_mail_service_no_t
            // 
            this.con_old_mail_service_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_old_mail_service_no_t.Location = new System.Drawing.Point(309, 14);
            this.con_old_mail_service_no_t.Name = "con_old_mail_service_no_t";
            this.con_old_mail_service_no_t.Size = new System.Drawing.Size(53, 13);
            this.con_old_mail_service_no_t.TabIndex = 0;
            this.con_old_mail_service_no_t.Text = "Old MSN";
            this.con_old_mail_service_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.con_old_mail_service_no_t.Visible = false;
            // 
            // con_old_mail_service_no
            // 
            this.con_old_mail_service_no.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.con_old_mail_service_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConOldMailServiceNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_old_mail_service_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_old_mail_service_no.Location = new System.Drawing.Point(364, 8);
            this.con_old_mail_service_no.MaxLength = 6;
            this.con_old_mail_service_no.Name = "con_old_mail_service_no";
            this.con_old_mail_service_no.Size = new System.Drawing.Size(68, 20);
            this.con_old_mail_service_no.TabIndex = 110;
            this.con_old_mail_service_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.con_old_mail_service_no.Visible = false;
            // 
            // gb_3
            // 
            this.gb_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_3.Location = new System.Drawing.Point(171, 195);
            this.gb_3.Name = "gb_3";
            this.gb_3.Size = new System.Drawing.Size(326, 90);
            this.gb_3.TabIndex = 0;
            this.gb_3.TabStop = false;
            this.gb_3.Text = "Message For Invoice";
            // 
            // gb_2
            // 
            this.gb_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_2.Location = new System.Drawing.Point(3, 195);
            this.gb_2.Name = "gb_2";
            this.gb_2.Size = new System.Drawing.Size(159, 90);
            this.gb_2.TabIndex = 0;
            this.gb_2.TabStop = false;
            this.gb_2.Text = "Last Actioned Dates";
            // 
            // gb_1
            // 
            this.gb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_1.Location = new System.Drawing.Point(3, 0);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(493, 196);
            this.gb_1.TabIndex = 0;
            this.gb_1.TabStop = false;
            // 
            // con_date_terminated
            // 
            this.con_date_terminated.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ConDateTerminated", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_date_terminated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_date_terminated.Location = new System.Drawing.Point(364, 132);
            this.con_date_terminated.Mask = "00/00/0000";
            this.con_date_terminated.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.con_date_terminated.Name = "con_date_terminated";
            //this.con_date_terminated.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            //this.con_date_terminated.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.con_date_terminated.DataBindings[0].DataSourceNullValue = null;
            this.con_date_terminated.Size = new System.Drawing.Size(84, 20);
            this.con_date_terminated.TabIndex = 150;
            this.con_date_terminated.ValidatingType = typeof(System.DateTime?);
            //this.con_date_terminated.PromptChar = '0';
            //this.con_date_terminated.TypeValidationCompleted += new TypeValidationEventHandler(DateTime_TypeValidationCompleted);
            //// t_2
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.Location = new System.Drawing.Point(364, 28);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(130, 21);
            this.rg_code.TabIndex = 20;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            this.rg_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rg_code.BackColor = System.Drawing.Color.Aqua;
            // 
            // ac_id
            // 
            this.ac_id.AutoRetrieve = true;
            this.ac_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_id.DisplayMember = "AcCode";
            this.ac_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_id.Location = new System.Drawing.Point(364, 152);
            this.ac_id.Name = "ac_id";
            this.ac_id.Size = new System.Drawing.Size(130, 21);
            this.ac_id.TabIndex = 160;
            this.ac_id.Value = null;
            this.ac_id.ValueMember = "AcId";
            this.ac_id.DropDownWidth = 180;
            this.ac_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ac_id.SelectedIndexChanged += new System.EventHandler(ac_id_SelectedIndexChanged);
            this.ac_id.Click += new System.EventHandler(ac_id_Click);
            this.ac_id.LostFocus += new System.EventHandler(ac_id_LostFocus);
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DataBindings.Add("Enabled", this.bindingSource, "CtKeyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.BackColor = System.Drawing.Color.Aqua;
            this.ct_key.EnabledChanged += new System.EventHandler(ct_key_EnabledChanged);
            this.ct_key.Enabled = false;
            this.ct_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ct_key.Location = new System.Drawing.Point(364, 48);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(130, 20);
            this.ct_key.TabIndex = 120;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";
            this.ct_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.ct_key.DropDownWidth = 195;
            // 
            // DContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.t_2);
            this.Controls.Add(this.pbu_id);
            this.Controls.Add(this.con_rd_paper_file_text_t);
            this.Controls.Add(this.con_rcm_paper_file_text_t);
            this.Controls.Add(this.lo_picklist);
            this.Controls.Add(this.bo_picklist);
            this.Controls.Add(this.con_base_office);
            this.Controls.Add(this.con_last_service_review_t);
            this.Controls.Add(this.con_last_delivery_check_t);
            this.Controls.Add(this.con_last_work_msrmnt_check_t);
            this.Controls.Add(this.message_for_invoice);
            this.Controls.Add(this.con_last_service_review);
            this.Controls.Add(this.con_last_delivery_check);
            this.Controls.Add(this.con_last_work_msrmnt_check);
            this.Controls.Add(this.con_base_office_name_t);
            this.Controls.Add(this.t_4);
            this.Controls.Add(this.con_rd_ref_text_t);
            this.Controls.Add(this.con_title);
            this.Controls.Add(this.con_base_office_type);
            this.Controls.Add(this.con_base_office_name);
            this.Controls.Add(this.bo_button);
            this.Controls.Add(this.t_3);
            this.Controls.Add(this.con_title_t);
            this.Controls.Add(this.con_lodgement_office_name_t);
            this.Controls.Add(this.con_lodgement_office_name);
            this.Controls.Add(this.lo_button);
            this.Controls.Add(this.con_date_terminated_t);
            this.Controls.Add(this.con_base_cont_type_t);
            this.Controls.Add(this.contract_no_t);
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.rg_code_t);
            this.Controls.Add(this.con_old_mail_service_no);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.con_rd_paper_file_text);
            this.Controls.Add(this.con_rcm_paper_file_text);
            this.Controls.Add(this.con_lodgement_office_type);
            this.Controls.Add(this.con_rd_ref_text);
            this.Controls.Add(this.con_old_mail_service_no_t);
            this.Controls.Add(this.con_date_terminated);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.ac_id);
            this.Controls.Add(this.ct_key);
            this.Controls.Add(this.gb_1);
            this.Controls.Add(this.gb_3);
            this.Controls.Add(this.gb_2);

            this.Name = "DContract";
            this.Size = new System.Drawing.Size(521, 369);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.bo_button)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.lo_button)).EndInit();
            this.gb_1.ResumeLayout(false);
            this.gb_1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void DateTime_TypeValidationCompleted(object sender, System.Windows.Forms.TypeValidationEventArgs e)
        {
            System.Windows.Forms.MaskedTextBox textBox = (System.Windows.Forms.MaskedTextBox)sender;
            if (textBox.Text == "00/00/0000")
            {
                this.SetValue(0, textBox.Name, null);
                this.bindingSource.CurrencyManager.Refresh();
            }
        }
       
        void ct_key_EnabledChanged(object sender, System.EventArgs e)
        {
            if (ct_key.Enabled)
            {
                this.ct_key.BackColor = System.Drawing.Color.Aqua;
            }
            else
            {
                this.ct_key.BackColor = System.Drawing.SystemColors.Control;
            }
        }

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
        //add by mkwang
        void ac_id_LostFocus(object sender, System.EventArgs e)
        {
            this.ac_id.DisplayMember = "AcCode";
        }

        void ac_id_Click(object sender, System.EventArgs e)
        {
            if (this.ac_id.DroppedDown)
            {
                this.ac_id.DisplayMember = "";
            }
            else
            {
                this.ac_id.DisplayMember = "AcCode";
            }
        }

        void ac_id_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int li_index = this.ac_id.SelectedIndex;
            this.ac_id.DisplayMember = "AcCode";
            this.ac_id.SelectedIndex = li_index;
            this.AcceptText();
            // if the column is not checked in itemchanged event below is not needed
            if (this.RowCount > 0)
            {
                this.OnItemChanged(this.ac_id, new System.EventArgs());
            }
        }


        #endregion

        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label t_2;
        private Metex.Windows.DataEntityCombo pbu_id;
        private System.Windows.Forms.Label con_rd_paper_file_text_t;
        private System.Windows.Forms.Label con_rcm_paper_file_text_t;
        private System.Windows.Forms.RichTextBox con_rd_paper_file_text;
        private System.Windows.Forms.RichTextBox con_rcm_paper_file_text;
        private System.Windows.Forms.CheckBox lo_picklist;
        private System.Windows.Forms.CheckBox bo_picklist;
        private System.Windows.Forms.TextBox con_base_office;
        private System.Windows.Forms.Label con_last_service_review_t;
        private System.Windows.Forms.Label con_last_delivery_check_t;
        private System.Windows.Forms.Label con_last_work_msrmnt_check_t;
        private System.Windows.Forms.TextBox message_for_invoice;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox con_last_service_review;// System.Windows.Forms.MaskedTextBox con_last_service_review;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox con_last_delivery_check;// System.Windows.Forms.MaskedTextBox con_last_delivery_check;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox con_last_work_msrmnt_check;// System.Windows.Forms.MaskedTextBox con_last_work_msrmnt_check; 
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox con_date_terminated;// System.Windows.Forms.MaskedTextBox con_date_terminated;

        private System.Windows.Forms.Label con_base_office_name_t;
        private System.Windows.Forms.Label t_4;
        private System.Windows.Forms.Label con_rd_ref_text_t;
        private System.Windows.Forms.TextBox con_title;
        private System.Windows.Forms.TextBox con_base_office_type;
        private System.Windows.Forms.TextBox con_lodgement_office_type;
        private System.Windows.Forms.TextBox con_rd_ref_text;
        private System.Windows.Forms.TextBox con_base_office_name;
        private System.Windows.Forms.Button bo_button;
        private System.Windows.Forms.Label t_3;
        private System.Windows.Forms.Label con_title_t;
        private System.Windows.Forms.Label con_lodgement_office_name_t;
        private System.Windows.Forms.TextBox con_lodgement_office_name;
        private System.Windows.Forms.Button lo_button;
        private System.Windows.Forms.Label con_date_terminated_t;
        private System.Windows.Forms.Label con_base_cont_type_t;
        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.TextBox contract_no;
        private System.Windows.Forms.Label rg_code_t;
        private System.Windows.Forms.Label con_old_mail_service_no_t;
        private System.Windows.Forms.TextBox con_old_mail_service_no;
        private System.Windows.Forms.GroupBox gb_3;
        private System.Windows.Forms.GroupBox gb_2;
        private System.Windows.Forms.GroupBox gb_1;
       
        private Metex.Windows.DataEntityCombo rg_code;
        private Metex.Windows.DataEntityCombo ac_id;
        private Metex.Windows.DataEntityCombo ct_key;
    }
}

