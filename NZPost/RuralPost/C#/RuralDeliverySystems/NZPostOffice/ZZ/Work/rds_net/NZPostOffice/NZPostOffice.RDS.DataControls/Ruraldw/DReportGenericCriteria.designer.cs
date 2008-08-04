namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DReportGenericCriteria
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
            this.n_20005910 = new System.Windows.Forms.Label();
            this.st_report = new System.Windows.Forms.Label();
            this.outlet_picklist = new System.Windows.Forms.CheckBox();
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.outlet_outlet_id_t = new System.Windows.Forms.Label();
            this.renewal_group_rg_code_t = new System.Windows.Forms.Label();
            this.standard_frequency_sf_key_t = new System.Windows.Forms.Label();
            this.contract_type_ct_key_t = new System.Windows.Forms.Label();
            this.n_45835463 = new System.Windows.Forms.Label();
            this.region_id_ro = new Metex.Windows.DataEntityCombo();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.o_name = new System.Windows.Forms.TextBox();
            this.outlet_bmp = new System.Windows.Forms.PictureBox();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.sf_key = new Metex.Windows.DataEntityCombo();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.ceffectivedate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ReportGenericCriteria);
            // 
            // n_20005910
            // 
            this.n_20005910.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_20005910.Location = new System.Drawing.Point(103, 18);
            this.n_20005910.Name = "n_20005910";
            this.n_20005910.Size = new System.Drawing.Size(99, 13);
            this.n_20005910.TabIndex = 0;
            this.n_20005910.Text = "Search Criteria";
            this.n_20005910.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // st_report
            // 
            this.st_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_report.Location = new System.Drawing.Point(4, 2);
            this.st_report.Name = "st_report";
            this.st_report.Size = new System.Drawing.Size(300, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Text = "Report:";
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outlet_picklist
            // 
            this.outlet_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "OutletPicklistCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_picklist.Location = new System.Drawing.Point(6, 36);
            this.outlet_picklist.Name = "outlet_picklist";
            this.outlet_picklist.Size = new System.Drawing.Size(12, 12);
            this.outlet_picklist.TabIndex = 40;
            this.outlet_picklist.Visible = false;
            // 
            // outlet_region_id_t
            // 
            this.outlet_region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_region_id_t.Location = new System.Drawing.Point(61, 36);
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Size = new System.Drawing.Size(39, 13);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Text = "Region";
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // outlet_outlet_id_t
            // 
            this.outlet_outlet_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_outlet_id_t.Location = new System.Drawing.Point(35, 54);
            this.outlet_outlet_id_t.Name = "outlet_outlet_id_t";
            this.outlet_outlet_id_t.Size = new System.Drawing.Size(65, 13);
            this.outlet_outlet_id_t.TabIndex = 0;
            this.outlet_outlet_id_t.Text = "Base Office";
            this.outlet_outlet_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // renewal_group_rg_code_t
            // 
            this.renewal_group_rg_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.renewal_group_rg_code_t.Location = new System.Drawing.Point(20, 74);
            this.renewal_group_rg_code_t.Name = "renewal_group_rg_code_t";
            this.renewal_group_rg_code_t.Size = new System.Drawing.Size(80, 13);
            this.renewal_group_rg_code_t.TabIndex = 0;
            this.renewal_group_rg_code_t.Text = "Renewal Group";
            this.renewal_group_rg_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // standard_frequency_sf_key_t
            // 
            this.standard_frequency_sf_key_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.standard_frequency_sf_key_t.Location = new System.Drawing.Point(0, 94);
            this.standard_frequency_sf_key_t.Name = "standard_frequency_sf_key_t";
            this.standard_frequency_sf_key_t.Size = new System.Drawing.Size(105, 13);
            this.standard_frequency_sf_key_t.TabIndex = 0;
            this.standard_frequency_sf_key_t.Text = "Standard Frequency";
            this.standard_frequency_sf_key_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_type_ct_key_t
            // 
            this.contract_type_ct_key_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_type_ct_key_t.Location = new System.Drawing.Point(24, 114);
            this.contract_type_ct_key_t.Name = "contract_type_ct_key_t";
            this.contract_type_ct_key_t.Size = new System.Drawing.Size(76, 13);
            this.contract_type_ct_key_t.TabIndex = 0;
            this.contract_type_ct_key_t.Text = "Contract Type";
            this.contract_type_ct_key_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_45835463
            // 
            this.n_45835463.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_45835463.Location = new System.Drawing.Point(0, 136);
            this.n_45835463.Name = "n_45835463";
            this.n_45835463.Size = new System.Drawing.Size(100, 13);
            this.n_45835463.TabIndex = 0;
            this.n_45835463.Text = "Effective Date (opt)";
            this.n_45835463.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // region_id_ro
            // 
            this.region_id_ro.AutoRetrieve = true;
            this.region_id_ro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id_ro.DisplayMember = "RgnName";
            this.region_id_ro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_ro.Location = new System.Drawing.Point(104, 34);
            this.region_id_ro.Name = "region_id_ro";
            this.region_id_ro.Size = new System.Drawing.Size(182, 21);
            this.region_id_ro.TabIndex = 20;
            this.region_id_ro.Value = null;
            this.region_id_ro.ValueMember = "RegionId";
            this.region_id_ro.DataBindings[0].NullValue = null;
            this.region_id_ro.DataBindings[0].DataSourceNullValue = null;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.Location = new System.Drawing.Point(104, 34);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(182, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            this.region_id.DataBindings[0].NullValue = null;
            this.region_id.DataBindings[0].DataSourceNullValue = null;

            // 
            // o_name
            // 
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name.Location = new System.Drawing.Point(104, 55);
            this.o_name.MaxLength = 40;
            this.o_name.Name = "o_name";
            this.o_name.Size = new System.Drawing.Size(164, 20);
            this.o_name.TabIndex = 30;
            // 
            // outlet_bmp
            // 
            this.outlet_bmp.Location = new System.Drawing.Point(270, 56);
            this.outlet_bmp.Name = "outlet_bmp";
            this.outlet_bmp.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;
            this.outlet_bmp.Size = new System.Drawing.Size(17, 17);
            this.outlet_bmp.TabIndex = 0;
            this.outlet_bmp.TabStop = false;
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.Location = new System.Drawing.Point(104, 75);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(182, 21);
            this.rg_code.TabIndex = 50;
            this.rg_code.Value = null;
            this.rg_code.DataBindings[0].DataSourceNullValue = null;
            this.rg_code.ValueMember = "RgCode";
            // 
            // sf_key
            // 
            this.sf_key.AutoRetrieve = true;
            this.sf_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "SfKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sf_key.DisplayMember = "SfDescription";
            this.sf_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sf_key.Location = new System.Drawing.Point(104, 96);
            this.sf_key.Name = "sf_key";
            this.sf_key.Size = new System.Drawing.Size(182, 21);
            this.sf_key.TabIndex = 60;
            this.sf_key.Value = null;
            this.sf_key.DataBindings[0].DataSourceNullValue = null;
            this.sf_key.ValueMember = "SfKey";
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ct_key.Location = new System.Drawing.Point(104, 117);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(182, 21);
            this.ct_key.TabIndex = 70;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";

            this.ct_key.DataBindings[0].NullValue = null;
            this.ct_key.DataBindings[0].DataSourceNullValue = null;


            // 
            // ceffectivedate
            // 
            this.ceffectivedate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Ceffectivedate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ceffectivedate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ceffectivedate.Location = new System.Drawing.Point(104, 138);
            this.ceffectivedate.Name = "ceffectivedate";
            this.ceffectivedate.Size = new System.Drawing.Size(50, 20);
            this.ceffectivedate.TabIndex = 80;
            // 
            // DReportGenericCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.n_20005910);
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.outlet_picklist);
            this.Controls.Add(this.outlet_region_id_t);
            this.Controls.Add(this.outlet_outlet_id_t);
            this.Controls.Add(this.renewal_group_rg_code_t);
            this.Controls.Add(this.standard_frequency_sf_key_t);
            this.Controls.Add(this.contract_type_ct_key_t);
            this.Controls.Add(this.n_45835463);
            this.Controls.Add(this.region_id_ro);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.o_name);
            this.Controls.Add(this.outlet_bmp);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.sf_key);
            this.Controls.Add(this.ct_key);
            this.Controls.Add(this.ceffectivedate);
            this.Name = "DReportGenericCriteria";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_20005910;
        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.CheckBox outlet_picklist;
        private System.Windows.Forms.Label outlet_region_id_t;
        private System.Windows.Forms.Label outlet_outlet_id_t;
        private System.Windows.Forms.Label renewal_group_rg_code_t;
        private System.Windows.Forms.Label standard_frequency_sf_key_t;
        private System.Windows.Forms.Label contract_type_ct_key_t;
        private System.Windows.Forms.Label n_45835463;
        private Metex.Windows.DataEntityCombo region_id_ro;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.TextBox o_name;
        private System.Windows.Forms.PictureBox outlet_bmp;
        private Metex.Windows.DataEntityCombo rg_code;
        private Metex.Windows.DataEntityCombo sf_key;
        private Metex.Windows.DataEntityCombo ct_key;
        private System.Windows.Forms.TextBox ceffectivedate;
    }
}

