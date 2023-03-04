namespace NZPostOffice.RDS.DataControls.Ruralmailmerge
{
    partial class DMailmergeCustomerDownloadSearch
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
            this.st_report = new System.Windows.Forms.Label();
            this.n_50386953 = new System.Windows.Forms.Label();
            this.n_50829401 = new System.Windows.Forms.Label();
            this.sf_key = new Metex.Windows.DataEntityCombo();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.outlet_bmp = new System.Windows.Forms.PictureBox();
            this.n_54811429 = new System.Windows.Forms.Label();
            this.use_printedon = new System.Windows.Forms.CheckBox();
            this.updateafterprint = new System.Windows.Forms.CheckBox();
            this.firstletter = new System.Windows.Forms.MaskedTextBox();
            this.region_id_t = new System.Windows.Forms.Label();
            this.outlet_id_t = new System.Windows.Forms.Label();
            this.n_23540813 = new System.Windows.Forms.Label();
            this.n_10540732 = new System.Windows.Forms.Label();
            this.n_27757730 = new System.Windows.Forms.Label();
            this.n_48492984 = new System.Windows.Forms.Label();
            this.n_33783680 = new System.Windows.Forms.Label();
            this.printedon_fromdate = new System.Windows.Forms.MaskedTextBox();
            this.n_35617665 = new System.Windows.Forms.Label();
            this.printedon_todate = new System.Windows.Forms.MaskedTextBox();
            
            this.printlabels2 = new System.Windows.Forms.RadioButton();
            this.printlabels1 = new System.Windows.Forms.RadioButton();

            this.load_todate = new System.Windows.Forms.MaskedTextBox();
            this.load_fromdate = new System.Windows.Forms.MaskedTextBox();
            this.o_name = new System.Windows.Forms.TextBox();
            this.region_id = new Metex.Windows.DataEntityCombo();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralmailmerge.MailmergeCustomerDownloadSearch);
            // 
            // st_report
            // 
            this.st_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_report.Location = new System.Drawing.Point(4, 3);
            this.st_report.Name = "st_report";
            this.st_report.Size = new System.Drawing.Size(168, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Text = "Mailmerge - customers";
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_50386953
            // 
            this.n_50386953.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.n_50386953.Location = new System.Drawing.Point(107, 16);
            this.n_50386953.Name = "n_50386953";
            this.n_50386953.Size = new System.Drawing.Size(113, 13);
            this.n_50386953.TabIndex = 0;
            this.n_50386953.Text = "Search Criteria";
            this.n_50386953.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_50829401
            // 
            this.n_50829401.Font = new System.Drawing.Font("Arial", 8F);
            this.n_50829401.Location = new System.Drawing.Point(932, 54);
            this.n_50829401.Name = "n_50829401";
            this.n_50829401.Size = new System.Drawing.Size(246, 49);
            this.n_50829401.TabIndex = 0;
            this.n_50829401.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sf_key
            // 
            this.sf_key.AutoRetrieve = true;
            this.sf_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "SfKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sf_key.DisplayMember = "SfDescription";
            this.sf_key.Enabled = false;
            this.sf_key.Font = new System.Drawing.Font("Arial", 8F);
            this.sf_key.Location = new System.Drawing.Point(870, 80);
            this.sf_key.Name = "sf_key";
            this.sf_key.Size = new System.Drawing.Size(45, 22);
            this.sf_key.TabIndex = 0;
            this.sf_key.Value = null;
            this.sf_key.ValueMember = "SfKey";
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.Enabled = false;
            this.rg_code.Font = new System.Drawing.Font("Arial", 8F);
            this.rg_code.Location = new System.Drawing.Point(870, 106);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(45, 22);
            this.rg_code.DataBindings[0].DataSourceNullValue = null;
            this.rg_code.TabIndex = 0;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.Enabled = false;
            this.ct_key.Font = new System.Drawing.Font("Arial", 8F);
            this.ct_key.Location = new System.Drawing.Point(870, 53);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(45, 22);
            this.ct_key.TabIndex = 0;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";
            // 
            // outlet_bmp
            // 
            this.outlet_bmp.Location = new System.Drawing.Point(270, 55);
            this.outlet_bmp.Name = "outlet_bmp";
            this.outlet_bmp.Size = new System.Drawing.Size(17, 15);
            this.outlet_bmp.TabIndex = 0;
            this.outlet_bmp.TabStop = false;
            this.outlet_bmp.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;
            // 
            // n_54811429
            // 
            this.n_54811429.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_54811429.Location = new System.Drawing.Point(183, 79);
            this.n_54811429.Name = "n_54811429";
            this.n_54811429.Size = new System.Drawing.Size(16, 13);
            this.n_54811429.TabIndex = 0;
            this.n_54811429.Text = "to";
            this.n_54811429.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // use_printedon
            // 
            this.use_printedon.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.use_printedon.Font = new System.Drawing.Font("Arial", 8F);
            this.use_printedon.Location = new System.Drawing.Point(106, 101);
            this.use_printedon.Name = "use_printedon";
            this.use_printedon.Size = new System.Drawing.Size(14, 14);
            this.use_printedon.TabIndex = 50;
            this.use_printedon.ThreeState = true;
            // 
            // updateafterprint
            // 
            this.updateafterprint.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateafterprint.Enabled = false;
            this.updateafterprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.updateafterprint.Location = new System.Drawing.Point(105, 120);
            this.updateafterprint.Name = "updateafterprint";
            this.updateafterprint.Size = new System.Drawing.Size(13, 14);
            this.updateafterprint.TabIndex = 80;
            this.updateafterprint.ThreeState = true;
            // 
            // firstletter
            // 
            this.firstletter.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Firstletter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.firstletter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.firstletter.Location = new System.Drawing.Point(104, 135);
            this.firstletter.Mask = "a";
            this.firstletter.Name = "firstletter";
            this.firstletter.Size = new System.Drawing.Size(14, 20);
            this.firstletter.TabIndex = 90;
            // 
            // region_id_t
            // 
            this.region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_t.Location = new System.Drawing.Point(61, 33);
            this.region_id_t.Name = "region_id_t";
            this.region_id_t.Size = new System.Drawing.Size(41, 13);
            this.region_id_t.TabIndex = 0;
            this.region_id_t.Text = "Region";
            this.region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // outlet_id_t
            // 
            this.outlet_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_id_t.Location = new System.Drawing.Point(40, 56);
            this.outlet_id_t.Name = "outlet_id_t";
            this.outlet_id_t.Size = new System.Drawing.Size(62, 13);
            this.outlet_id_t.TabIndex = 0;
            this.outlet_id_t.Text = "Base Office";
            this.outlet_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_23540813
            // 
            this.n_23540813.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_23540813.Location = new System.Drawing.Point(33, 80);
            this.n_23540813.Name = "n_23540813";
            this.n_23540813.Size = new System.Drawing.Size(70, 13);
            this.n_23540813.TabIndex = 0;
            this.n_23540813.Text = "Date Loaded";
            this.n_23540813.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_10540732
            // 
            this.n_10540732.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_10540732.Location = new System.Drawing.Point(44, 99);
            this.n_10540732.Name = "n_10540732";
            this.n_10540732.Size = new System.Drawing.Size(57, 13);
            this.n_10540732.TabIndex = 0;
            this.n_10540732.Text = "Printed On";
            this.n_10540732.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_27757730
            // 
            this.n_27757730.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_27757730.Location = new System.Drawing.Point(10, 119);
            this.n_27757730.Name = "n_27757730";
            this.n_27757730.Size = new System.Drawing.Size(94, 13);
            this.n_27757730.TabIndex = 0;
            this.n_27757730.Text = "Update After Print";
            this.n_27757730.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_48492984
            // 
            this.n_48492984.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_48492984.Location = new System.Drawing.Point(-1, 137);
            this.n_48492984.Name = "n_48492984";
            this.n_48492984.Size = new System.Drawing.Size(104, 13);
            this.n_48492984.TabIndex = 0;
            this.n_48492984.Text = "1st letter of surname";
            this.n_48492984.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_33783680
            // 
            this.n_33783680.Font = new System.Drawing.Font("Arial", 8F);
            this.n_33783680.Location = new System.Drawing.Point(38, 157);
            this.n_33783680.Name = "n_33783680";
            this.n_33783680.Size = new System.Drawing.Size(62, 14);
            this.n_33783680.TabIndex = 0;
            this.n_33783680.Text = "Print Option";
            this.n_33783680.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // printedon_fromdate
            // 
            this.printedon_fromdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PrintedonFromdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.printedon_fromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.printedon_fromdate.Location = new System.Drawing.Point(126, 98);
            this.printedon_fromdate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.printedon_fromdate.Mask = "00/00/0000";//dd/MM/yyyy";
            this.printedon_fromdate.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.printedon_fromdate.PromptChar = '0';
            this.printedon_fromdate.ValidatingType = typeof(System.DateTime);
            this.printedon_fromdate.Name = "printedon_fromdate";
            this.printedon_fromdate.Size = new System.Drawing.Size(69, 20);
            this.printedon_fromdate.TabIndex = 60;
            // 
            // n_35617665
            // 
            this.n_35617665.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_35617665.Location = new System.Drawing.Point(198, 102);
            this.n_35617665.Name = "n_35617665";
            this.n_35617665.Size = new System.Drawing.Size(16, 13);
            this.n_35617665.TabIndex = 0;
            this.n_35617665.Text = "to";
            this.n_35617665.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // printedon_todate
            // 
            this.printedon_todate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PrintedonTodate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.printedon_todate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.printedon_todate.Location = new System.Drawing.Point(218, 98);
            this.printedon_todate.Mask = "00/00/0000";//dd/MM/yyyy";
            this.printedon_todate.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.printedon_todate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.printedon_todate.PromptChar = '0';
            this.printedon_todate.ValidatingType = typeof(System.DateTime);
            this.printedon_todate.Name = "printedon_todate";
            this.printedon_todate.Size = new System.Drawing.Size(65, 20);
            this.printedon_todate.TabIndex = 70;

            // 
            // printlabels2
            // 
            //this.printlabels.BackColor = System.Drawing.Color.White;
            this.printlabels2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.printlabels2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "Printlabels2", true));
            this.printlabels2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.printlabels2.Location = new System.Drawing.Point(102, 155);
            this.printlabels2.Name = "Labels";
            this.printlabels2.Size = new System.Drawing.Size(69, 20);
            this.printlabels2.TabIndex = 51;
            this.printlabels2.TabStop = true;
            this.printlabels2.Text = "Labels";
            this.printlabels2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.printlabels2.UseVisualStyleBackColor = false;
            // 
            // printlabels1
            // 
            //this.printlabels1.BackColor = System.Drawing.Color.White;
            this.printlabels1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.printlabels1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.printlabels1.Location = new System.Drawing.Point(184, 155);
            this.printlabels1.Name = "Mail Merge";
            this.printlabels1.Size = new System.Drawing.Size(80, 20);
            this.printlabels1.TabIndex = 52;
            this.printlabels1.TabStop = true;
            this.printlabels1.Text = "Mail Merge";
            this.printlabels1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.printlabels1.UseVisualStyleBackColor = false;
            this.printlabels1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "Printlabels1", true));

            // 
            // load_todate
            // 
            this.load_todate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "LoadTodate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.load_todate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.load_todate.Location = new System.Drawing.Point(212, 76);
            this.load_todate.Mask = "00/00/0000";//dd/MM/yyyy";
            this.load_todate.PromptChar = '0';
            this.load_todate.ValidatingType = typeof(System.DateTime);
            this.load_todate.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.load_todate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.load_todate.Name = "load_todate";
            this.load_todate.Size = new System.Drawing.Size(73, 20);
            this.load_todate.TabIndex = 40;
            // 
            // load_fromdate
            // 
            this.load_fromdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "LoadFromdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.load_fromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.load_fromdate.Location = new System.Drawing.Point(108, 76);
            this.load_fromdate.Mask = "00/00/0000";//dd/MM/yyyy";
            this.load_fromdate.PromptChar = '0';
            this.load_fromdate.ValidatingType = typeof(System.DateTime);
            this.load_fromdate.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.load_fromdate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.load_fromdate.Name = "load_fromdate";
            this.load_fromdate.Size = new System.Drawing.Size(64, 20);
            this.load_fromdate.TabIndex = 30;
            // 
            // o_name
            // 
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name.Location = new System.Drawing.Point(108, 53);
            this.o_name.MaxLength = 40;
            this.o_name.Name = "o_name";
            this.o_name.Size = new System.Drawing.Size(156, 20);
            this.o_name.TabIndex = 20;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionIdRo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.Location = new System.Drawing.Point(108, 30);
            this.region_id.DataBindings[0].DataSourceNullValue = null;
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(178, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // DMailmergeCustomerDownloadSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.n_50386953);
            this.Controls.Add(this.n_50829401);
            this.Controls.Add(this.sf_key);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.ct_key);
            this.Controls.Add(this.outlet_bmp);
            this.Controls.Add(this.n_54811429);
            this.Controls.Add(this.use_printedon);
            this.Controls.Add(this.updateafterprint);
            this.Controls.Add(this.firstletter);
            this.Controls.Add(this.region_id_t);
            this.Controls.Add(this.outlet_id_t);
            this.Controls.Add(this.n_23540813);
            this.Controls.Add(this.n_10540732);
            this.Controls.Add(this.n_27757730);
            this.Controls.Add(this.n_48492984);
            this.Controls.Add(this.n_33783680);
            this.Controls.Add(this.printedon_fromdate);
            this.Controls.Add(this.n_35617665);
            this.Controls.Add(this.printedon_todate);

            this.Controls.Add(this.printlabels2);
            this.Controls.Add(this.printlabels1);

            this.Controls.Add(this.load_todate);
            this.Controls.Add(this.load_fromdate);
            this.Controls.Add(this.o_name);
            this.Controls.Add(this.region_id);
            this.Name = "DMailmergeCustomerDownloadSearch";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.Label n_50386953;
        private System.Windows.Forms.Label n_50829401;
        private Metex.Windows.DataEntityCombo sf_key;
        private Metex.Windows.DataEntityCombo rg_code;
        private Metex.Windows.DataEntityCombo ct_key;
        private System.Windows.Forms.PictureBox outlet_bmp;
        private System.Windows.Forms.Label n_54811429;
        private System.Windows.Forms.CheckBox use_printedon;
        private System.Windows.Forms.CheckBox updateafterprint;
        private System.Windows.Forms.MaskedTextBox firstletter;
        private System.Windows.Forms.Label region_id_t;
        private System.Windows.Forms.Label outlet_id_t;
        private System.Windows.Forms.Label n_23540813;
        private System.Windows.Forms.Label n_10540732;
        private System.Windows.Forms.Label n_27757730;
        private System.Windows.Forms.Label n_48492984;
        private System.Windows.Forms.Label n_33783680;
        private System.Windows.Forms.MaskedTextBox printedon_fromdate;
        private System.Windows.Forms.Label n_35617665;
        private System.Windows.Forms.MaskedTextBox printedon_todate;

        private System.Windows.Forms.RadioButton printlabels2;
        private System.Windows.Forms.RadioButton printlabels1;

        private System.Windows.Forms.MaskedTextBox load_todate;
        private System.Windows.Forms.MaskedTextBox load_fromdate;
        private System.Windows.Forms.TextBox o_name;
        private Metex.Windows.DataEntityCombo region_id;
    }
}
