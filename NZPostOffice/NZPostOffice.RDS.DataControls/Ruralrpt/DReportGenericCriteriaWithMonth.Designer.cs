namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DReportGenericCriteriaWithMonth
    {
        // TJB  FCR_001 28-Nov-2012
        // Increased size of renewal group dropdown to include November Renewals

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DReportGenericCriteriaWithMonth));
            this.n_27241609 = new System.Windows.Forms.Label();
            this.st_report = new System.Windows.Forms.Label();
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.outlet_picklist = new System.Windows.Forms.CheckBox();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.region_id_ro = new Metex.Windows.DataEntityCombo();
            this.outlet_outlet_id_t = new System.Windows.Forms.Label();
            this.o_name = new System.Windows.Forms.TextBox();
            this.outlet_bmp = new System.Windows.Forms.PictureBox();
            this.renewal_group_rg_code_t = new System.Windows.Forms.Label();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.standard_frequency_sf_key_t = new System.Windows.Forms.Label();
            this.sf_key = new Metex.Windows.DataEntityCombo();
            this.contract_type_ct_key_t = new System.Windows.Forms.Label();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.n_43847892 = new System.Windows.Forms.Label();
            this.monthyear = new System.Windows.Forms.MaskedTextBox();
            this.monthyear1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.ReportGenericCriteriaWithMonth);
            // 
            // n_27241609
            // 
            this.n_27241609.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_27241609.Location = new System.Drawing.Point(117, 12);
            this.n_27241609.Name = "n_27241609";
            this.n_27241609.Size = new System.Drawing.Size(113, 13);
            this.n_27241609.TabIndex = 0;
            this.n_27241609.Text = "Search Criteria";
            this.n_27241609.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // st_report
            // 
            this.st_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_report.Location = new System.Drawing.Point(3, -1);
            this.st_report.Name = "st_report";
            this.st_report.Size = new System.Drawing.Size(326, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Text = "Report:";
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outlet_region_id_t
            // 
            this.outlet_region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_region_id_t.Location = new System.Drawing.Point(62, 36);
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Size = new System.Drawing.Size(50, 13);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Text = "Region";
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // outlet_picklist
            // 
            this.outlet_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_picklist.Location = new System.Drawing.Point(5, 32);
            this.outlet_picklist.Name = "outlet_picklist";
            this.outlet_picklist.Size = new System.Drawing.Size(10, 24);
            this.outlet_picklist.TabIndex = 40;
            this.outlet_picklist.Visible = false;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.DropDownHeight = 150;
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.IntegralHeight = false;
            this.region_id.Location = new System.Drawing.Point(118, 28);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(163, 21);
            this.region_id.TabIndex = 20;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // region_id_ro
            // 
            this.region_id_ro.AutoRetrieve = true;
            this.region_id_ro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id_ro.DisplayMember = "RgnName";
            this.region_id_ro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_ro.Location = new System.Drawing.Point(118, 28);
            this.region_id_ro.Name = "region_id_ro";
            this.region_id_ro.Size = new System.Drawing.Size(163, 21);
            this.region_id_ro.TabIndex = 10;
            this.region_id_ro.Value = null;
            this.region_id_ro.ValueMember = "RegionId";
            // 
            // outlet_outlet_id_t
            // 
            this.outlet_outlet_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_outlet_id_t.Location = new System.Drawing.Point(38, 58);
            this.outlet_outlet_id_t.Name = "outlet_outlet_id_t";
            this.outlet_outlet_id_t.Size = new System.Drawing.Size(75, 13);
            this.outlet_outlet_id_t.TabIndex = 0;
            this.outlet_outlet_id_t.Text = "Base Office";
            this.outlet_outlet_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // o_name
            // 
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name.Location = new System.Drawing.Point(118, 50);
            this.o_name.MaxLength = 40;
            this.o_name.Name = "o_name";
            this.o_name.Size = new System.Drawing.Size(140, 20);
            this.o_name.TabIndex = 30;
            // 
            // outlet_bmp
            // 
            this.outlet_bmp.Image = ((System.Drawing.Image)(resources.GetObject("outlet_bmp.Image")));
            this.outlet_bmp.Location = new System.Drawing.Point(264, 53);
            this.outlet_bmp.Name = "outlet_bmp";
            this.outlet_bmp.Size = new System.Drawing.Size(17, 17);
            this.outlet_bmp.TabIndex = 0;
            this.outlet_bmp.TabStop = false;
            // 
            // renewal_group_rg_code_t
            // 
            this.renewal_group_rg_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.renewal_group_rg_code_t.Location = new System.Drawing.Point(16, 80);
            this.renewal_group_rg_code_t.Name = "renewal_group_rg_code_t";
            this.renewal_group_rg_code_t.Size = new System.Drawing.Size(98, 13);
            this.renewal_group_rg_code_t.TabIndex = 0;
            this.renewal_group_rg_code_t.Text = "Renewal Group";
            this.renewal_group_rg_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.DropDownHeight = 150;
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.Location = new System.Drawing.Point(118, 73);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(163, 21);
            this.rg_code.TabIndex = 50;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            // 
            // standard_frequency_sf_key_t
            // 
            this.standard_frequency_sf_key_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.standard_frequency_sf_key_t.Location = new System.Drawing.Point(2, 103);
            this.standard_frequency_sf_key_t.Name = "standard_frequency_sf_key_t";
            this.standard_frequency_sf_key_t.Size = new System.Drawing.Size(112, 13);
            this.standard_frequency_sf_key_t.TabIndex = 0;
            this.standard_frequency_sf_key_t.Text = "Standard Frequency";
            this.standard_frequency_sf_key_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sf_key
            // 
            this.sf_key.AutoRetrieve = true;
            this.sf_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "SfKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sf_key.DisplayMember = "SfDescription";
            this.sf_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sf_key.Location = new System.Drawing.Point(118, 96);
            this.sf_key.Name = "sf_key";
            this.sf_key.Size = new System.Drawing.Size(163, 21);
            this.sf_key.TabIndex = 60;
            this.sf_key.Value = null;
            this.sf_key.ValueMember = "SfKey";
            // 
            // contract_type_ct_key_t
            // 
            this.contract_type_ct_key_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_type_ct_key_t.Location = new System.Drawing.Point(18, 125);
            this.contract_type_ct_key_t.Name = "contract_type_ct_key_t";
            this.contract_type_ct_key_t.Size = new System.Drawing.Size(96, 13);
            this.contract_type_ct_key_t.TabIndex = 0;
            this.contract_type_ct_key_t.Text = "Contract Type";
            this.contract_type_ct_key_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.DropDownHeight = 150;
            this.ct_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ct_key.IntegralHeight = false;
            this.ct_key.Location = new System.Drawing.Point(118, 119);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(163, 21);
            this.ct_key.TabIndex = 70;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";
            // 
            // n_43847892
            // 
            this.n_43847892.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_43847892.Location = new System.Drawing.Point(6, 147);
            this.n_43847892.Name = "n_43847892";
            this.n_43847892.Size = new System.Drawing.Size(107, 13);
            this.n_43847892.TabIndex = 0;
            this.n_43847892.Text = "Date";
            this.n_43847892.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // monthyear
            // 
            this.monthyear.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Monthyear", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.monthyear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.monthyear.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.monthyear.Location = new System.Drawing.Point(118, 142);
            this.monthyear.Mask = "00/00";
            this.monthyear.Name = "monthyear";
            this.monthyear.PromptChar = '0';
            this.monthyear.Size = new System.Drawing.Size(42, 20);
            this.monthyear.TabIndex = 80;
            this.monthyear.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.monthyear.ValidatingType = typeof(System.DateTime);
            this.monthyear.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // monthyear1
            // 
            this.monthyear1.Location = new System.Drawing.Point(118, 142);
            this.monthyear1.Name = "monthyear1";
            this.monthyear1.Size = new System.Drawing.Size(42, 20);
            this.monthyear1.TabIndex = 81;
            // 
            // DReportGenericCriteriaWithMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.n_27241609);
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.outlet_region_id_t);
            this.Controls.Add(this.outlet_picklist);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.region_id_ro);
            this.Controls.Add(this.outlet_outlet_id_t);
            this.Controls.Add(this.o_name);
            this.Controls.Add(this.outlet_bmp);
            this.Controls.Add(this.renewal_group_rg_code_t);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.standard_frequency_sf_key_t);
            this.Controls.Add(this.sf_key);
            this.Controls.Add(this.contract_type_ct_key_t);
            this.Controls.Add(this.ct_key);
            this.Controls.Add(this.n_43847892);
            this.Controls.Add(this.monthyear);
            this.Controls.Add(this.monthyear1);
            this.Name = "DReportGenericCriteriaWithMonth";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_27241609;
        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.Label outlet_region_id_t;
        private System.Windows.Forms.CheckBox outlet_picklist;
        private Metex.Windows.DataEntityCombo region_id;
        private Metex.Windows.DataEntityCombo region_id_ro;
        private System.Windows.Forms.Label outlet_outlet_id_t;
        private System.Windows.Forms.TextBox o_name;
        private System.Windows.Forms.PictureBox outlet_bmp;
        private System.Windows.Forms.Label renewal_group_rg_code_t;
        private Metex.Windows.DataEntityCombo rg_code;
        private System.Windows.Forms.Label standard_frequency_sf_key_t;
        private Metex.Windows.DataEntityCombo sf_key;
        private System.Windows.Forms.Label contract_type_ct_key_t;
        private Metex.Windows.DataEntityCombo ct_key;
        private System.Windows.Forms.Label n_43847892;
        private System.Windows.Forms.MaskedTextBox monthyear;
        private System.Windows.Forms.TextBox monthyear1;
    }
}

