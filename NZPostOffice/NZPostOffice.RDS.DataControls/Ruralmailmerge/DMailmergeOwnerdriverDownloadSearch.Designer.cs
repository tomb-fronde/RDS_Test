namespace NZPostOffice.RDS.DataControls.Ruralmailmerge
{
    partial class DMailmergeOwnerdriverDownloadSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMailmergeOwnerdriverDownloadSearch));
            this.n_65556790 = new System.Windows.Forms.Label();
            this.st_report = new System.Windows.Forms.Label();
            this.outlet_picklist = new System.Windows.Forms.CheckBox();
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.region_id_ro = new Metex.Windows.DataEntityCombo();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.n_53140205 = new System.Windows.Forms.Label();
            this.outlet_outlet_id_t = new System.Windows.Forms.Label();
            this.o_name = new System.Windows.Forms.TextBox();
            this.outlet_bmp = new System.Windows.Forms.PictureBox();
            this.renewal_group_rg_code_t = new System.Windows.Forms.Label();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.contract_type_ct_key_t = new System.Windows.Forms.Label();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.n_8499801 = new System.Windows.Forms.Label();
            this.t_4 = new System.Windows.Forms.Label();
            this.proclist = new System.Windows.Forms.Label();
            this.printlabels_2 = new System.Windows.Forms.RadioButton();
            this.printlabels_1 = new System.Windows.Forms.RadioButton();
            this.procur_bmp = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procur_bmp)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralmailmerge.MailmergeOwnerdriverDownloadSearch);
            // 
            // n_65556790
            // 
            this.n_65556790.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_65556790.Location = new System.Drawing.Point(112, 17);
            this.n_65556790.Name = "n_65556790";
            this.n_65556790.Size = new System.Drawing.Size(113, 13);
            this.n_65556790.TabIndex = 0;
            this.n_65556790.Text = "Search Criteria";
            this.n_65556790.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // st_report
            // 
            this.st_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_report.Location = new System.Drawing.Point(4, 2);
            this.st_report.Name = "st_report";
            this.st_report.Size = new System.Drawing.Size(326, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Text = "Report:";
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outlet_picklist
            // 
            this.outlet_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_picklist.Location = new System.Drawing.Point(749, 28);
            this.outlet_picklist.Name = "outlet_picklist";
            this.outlet_picklist.Size = new System.Drawing.Size(12, 14);
            this.outlet_picklist.TabIndex = 40;
            // 
            // outlet_region_id_t
            // 
            this.outlet_region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_region_id_t.Location = new System.Drawing.Point(61, 40);
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Size = new System.Drawing.Size(47, 13);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Text = "Region";
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // region_id_ro
            // 
            this.region_id_ro.AutoRetrieve = true;
            this.region_id_ro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id_ro.DisplayMember = "RgnName";
            this.region_id_ro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_ro.Location = new System.Drawing.Point(115, 36);
            this.region_id_ro.Name = "region_id_ro";
            this.region_id_ro.Size = new System.Drawing.Size(135, 21);
            this.region_id_ro.TabIndex = 20;
            this.region_id_ro.Value = null;
            this.region_id_ro.ValueMember = "RegionId";
            this.region_id_ro.Visible = false;
            this.region_id_ro.DataBindings[0].DataSourceNullValue = null;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.Location = new System.Drawing.Point(114, 37);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(136, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            this.region_id.DataBindings[0].DataSourceNullValue = null;
            // 
            // n_53140205
            // 
            this.n_53140205.Font = new System.Drawing.Font("Arial", 8F);
            this.n_53140205.Location = new System.Drawing.Point(396, 35);
            this.n_53140205.Name = "n_53140205";
            this.n_53140205.Size = new System.Drawing.Size(246, 49);
            this.n_53140205.TabIndex = 0;
            this.n_53140205.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outlet_outlet_id_t
            // 
            this.outlet_outlet_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_outlet_id_t.Location = new System.Drawing.Point(47, 63);
            this.outlet_outlet_id_t.Name = "outlet_outlet_id_t";
            this.outlet_outlet_id_t.Size = new System.Drawing.Size(62, 13);
            this.outlet_outlet_id_t.TabIndex = 0;
            this.outlet_outlet_id_t.Text = "Base Office";
            this.outlet_outlet_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // o_name
            // 
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name.Location = new System.Drawing.Point(114, 62);
            this.o_name.MaxLength = 40;
            this.o_name.Name = "o_name";
            this.o_name.Size = new System.Drawing.Size(113, 20);
            this.o_name.TabIndex = 30;
            // 
            // outlet_bmp
            // 
            this.outlet_bmp.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;
            this.outlet_bmp.Location = new System.Drawing.Point(233, 63);
            this.outlet_bmp.Name = "outlet_bmp";
            this.outlet_bmp.Size = new System.Drawing.Size(17, 19);
            this.outlet_bmp.TabIndex = 0;
            this.outlet_bmp.TabStop = false;
            // 
            // renewal_group_rg_code_t
            // 
            this.renewal_group_rg_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.renewal_group_rg_code_t.Location = new System.Drawing.Point(25, 91);
            this.renewal_group_rg_code_t.Name = "renewal_group_rg_code_t";
            this.renewal_group_rg_code_t.Size = new System.Drawing.Size(84, 13);
            this.renewal_group_rg_code_t.TabIndex = 0;
            this.renewal_group_rg_code_t.Text = "Renewal Group";
            this.renewal_group_rg_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.Location = new System.Drawing.Point(114, 86);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(136, 21);
            this.rg_code.TabIndex = 50;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            this.rg_code.DataBindings[0].DataSourceNullValue = null;
            // 
            // contract_type_ct_key_t
            // 
            this.contract_type_ct_key_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_type_ct_key_t.Location = new System.Drawing.Point(33, 116);
            this.contract_type_ct_key_t.Name = "contract_type_ct_key_t";
            this.contract_type_ct_key_t.Size = new System.Drawing.Size(76, 13);
            this.contract_type_ct_key_t.TabIndex = 0;
            this.contract_type_ct_key_t.Text = "Contract Type";
            this.contract_type_ct_key_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ct_key.Location = new System.Drawing.Point(114, 113);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(136, 21);
            this.ct_key.TabIndex = 60;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";
            this.ct_key.DataBindings[0].DataSourceNullValue = null;
            // 
            // n_8499801
            // 
            this.n_8499801.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_8499801.Location = new System.Drawing.Point(47, 239);
            this.n_8499801.Name = "n_8499801";
            this.n_8499801.Size = new System.Drawing.Size(62, 17);
            this.n_8499801.TabIndex = 0;
            this.n_8499801.Text = "Print Option";
            this.n_8499801.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_4
            // 
            this.t_4.AutoSize = true;
            this.t_4.Location = new System.Drawing.Point(41, 144);
            this.t_4.Name = "t_4";
            this.t_4.Size = new System.Drawing.Size(67, 13);
            this.t_4.TabIndex = 71;
            this.t_4.Text = "Procurement";
            // 
            // proclist
            // 
            this.proclist.BackColor = System.Drawing.SystemColors.Window;
            this.proclist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.proclist.Location = new System.Drawing.Point(114, 139);
            this.proclist.Name = "proclist";
            this.proclist.Size = new System.Drawing.Size(113, 82);
            this.proclist.TabIndex = 72;
            // 
            // printlabels_2
            // 
            this.printlabels_2.AutoSize = true;
            this.printlabels_2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "PrintLabels2", true));
            this.printlabels_2.Location = new System.Drawing.Point(56, 15);
            this.printlabels_2.Name = "printlabels_2";
            this.printlabels_2.Size = new System.Drawing.Size(77, 17);
            this.printlabels_2.TabIndex = 76;
            this.printlabels_2.TabStop = true;
            this.printlabels_2.Text = "Mail Merge";
            this.printlabels_2.UseVisualStyleBackColor = true;
            // 
            // printlabels_1
            // 
            this.printlabels_1.AutoSize = true;
            this.printlabels_1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "PrintLabels1", true));
            this.printlabels_1.Location = new System.Drawing.Point(0, 15);
            this.printlabels_1.Name = "printlabels_1";
            this.printlabels_1.Size = new System.Drawing.Size(56, 17);
            this.printlabels_1.TabIndex = 75;
            this.printlabels_1.TabStop = true;
            this.printlabels_1.Text = "Labels";
            this.printlabels_1.UseVisualStyleBackColor = true;
            // 
            // procur_bmp
            // 
            this.procur_bmp.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;
            this.procur_bmp.Location = new System.Drawing.Point(233, 140);
            this.procur_bmp.Name = "procur_bmp";
            this.procur_bmp.Size = new System.Drawing.Size(16, 16);
            this.procur_bmp.TabIndex = 76;
            this.procur_bmp.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.printlabels_1);
            this.panel1.Controls.Add(this.printlabels_2);
            this.panel1.Location = new System.Drawing.Point(113, 224);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(136, 44);
            this.panel1.TabIndex = 77;
            // 
            // DMailmergeOwnerdriverDownloadSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.procur_bmp);
            this.Controls.Add(this.proclist);
            this.Controls.Add(this.t_4);
            this.Controls.Add(this.n_65556790);
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.outlet_picklist);
            this.Controls.Add(this.outlet_region_id_t);
            this.Controls.Add(this.region_id_ro);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.n_53140205);
            this.Controls.Add(this.outlet_outlet_id_t);
            this.Controls.Add(this.o_name);
            this.Controls.Add(this.outlet_bmp);
            this.Controls.Add(this.renewal_group_rg_code_t);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.contract_type_ct_key_t);
            this.Controls.Add(this.ct_key);
            this.Controls.Add(this.n_8499801);
            this.Name = "DMailmergeOwnerdriverDownloadSearch";
            this.Size = new System.Drawing.Size(362, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procur_bmp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_65556790;
        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.CheckBox outlet_picklist;
        private System.Windows.Forms.Label outlet_region_id_t;
        private Metex.Windows.DataEntityCombo region_id_ro;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.Label n_53140205;
        private System.Windows.Forms.Label outlet_outlet_id_t;
        private System.Windows.Forms.TextBox o_name;
        private System.Windows.Forms.PictureBox outlet_bmp;
        private System.Windows.Forms.Label renewal_group_rg_code_t;
        private Metex.Windows.DataEntityCombo rg_code;
        private System.Windows.Forms.Label contract_type_ct_key_t;
        private Metex.Windows.DataEntityCombo ct_key;
        private System.Windows.Forms.Label n_8499801;
        private System.Windows.Forms.Label t_4;
        private System.Windows.Forms.Label proclist;
        private System.Windows.Forms.RadioButton printlabels_2;
        private System.Windows.Forms.RadioButton printlabels_1;
        private System.Windows.Forms.PictureBox procur_bmp;
        private System.Windows.Forms.Panel panel1;
    }
}

