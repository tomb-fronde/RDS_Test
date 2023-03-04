namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DReportGenericRegOutletCriteria
    {
        // TJB 30-Jan-2013
        // Increased size of region group dropdown

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DReportGenericRegOutletCriteria));
            this.checked1 = new System.Windows.Forms.CheckBox();
            this.checked2 = new System.Windows.Forms.CheckBox();
            this.st_report = new System.Windows.Forms.Label();
            this.n_18111828 = new System.Windows.Forms.Label();
            this.outlet_picklist = new System.Windows.Forms.CheckBox();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.sf_key = new Metex.Windows.DataEntityCombo();
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.outlet_outlet_id_t = new System.Windows.Forms.Label();
            this.o_name = new System.Windows.Forms.TextBox();
            this.outlet_bmp = new System.Windows.Forms.PictureBox();
            this.n_28788730 = new System.Windows.Forms.Label();
            this.mail_count_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.n_57771982 = new System.Windows.Forms.Label();
            this.n_50185793 = new System.Windows.Forms.Label();
            this.rg_code1 = new Metex.Windows.DataEntityCombo();
            this.n_49018956 = new System.Windows.Forms.Label();
            this.rg_code2 = new Metex.Windows.DataEntityCombo();
            this.n_38517424 = new System.Windows.Forms.Label();
            this.blankforms = new System.Windows.Forms.TextBox();
            this.n_11112503 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.ReportGenericRegOutletCriteria);
            // 
            // checked1
            // 
            this.checked1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "Checked1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checked1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.checked1.Location = new System.Drawing.Point(269, 105);
            this.checked1.Name = "checked1";
            this.checked1.Size = new System.Drawing.Size(14, 12);
            this.checked1.TabIndex = 50;
            // 
            // checked2
            // 
            this.checked2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "Checked2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checked2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.checked2.Location = new System.Drawing.Point(269, 132);
            this.checked2.Name = "checked2";
            this.checked2.Size = new System.Drawing.Size(14, 12);
            this.checked2.TabIndex = 60;
            // 
            // st_report
            // 
            this.st_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_report.Location = new System.Drawing.Point(4, 2);
            this.st_report.Name = "st_report";
            this.st_report.Size = new System.Drawing.Size(326, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Text = "Report:";
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_18111828
            // 
            this.n_18111828.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_18111828.Location = new System.Drawing.Point(117, 15);
            this.n_18111828.Name = "n_18111828";
            this.n_18111828.Size = new System.Drawing.Size(113, 13);
            this.n_18111828.TabIndex = 0;
            this.n_18111828.Text = "Search Criteria";
            this.n_18111828.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outlet_picklist
            // 
            this.outlet_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_picklist.Enabled = false;
            this.outlet_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_picklist.Location = new System.Drawing.Point(5, 5);
            this.outlet_picklist.Name = "outlet_picklist";
            this.outlet_picklist.Size = new System.Drawing.Size(5, 1);
            this.outlet_picklist.TabIndex = 0;
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.Enabled = false;
            this.ct_key.Font = new System.Drawing.Font("Arial", 8F);
            this.ct_key.Location = new System.Drawing.Point(390, 208);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(22, 22);
            this.ct_key.TabIndex = 0;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.Enabled = false;
            this.rg_code.Font = new System.Drawing.Font("Arial", 8F);
            this.rg_code.Location = new System.Drawing.Point(420, 206);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(22, 22);
            this.rg_code.TabIndex = 0;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            // 
            // sf_key
            // 
            this.sf_key.AutoRetrieve = true;
            this.sf_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "SfKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sf_key.DisplayMember = "SfDescription";
            this.sf_key.Enabled = false;
            this.sf_key.Font = new System.Drawing.Font("Arial", 8F);
            this.sf_key.Location = new System.Drawing.Point(452, 211);
            this.sf_key.Name = "sf_key";
            this.sf_key.Size = new System.Drawing.Size(22, 22);
            this.sf_key.TabIndex = 0;
            this.sf_key.Value = null;
            this.sf_key.ValueMember = "SfKey";
            // 
            // outlet_region_id_t
            // 
            this.outlet_region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_region_id_t.Location = new System.Drawing.Point(75, 38);
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Size = new System.Drawing.Size(42, 11);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Text = "Region";
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.DropDownHeight = 150;
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.IntegralHeight = false;
            this.region_id.Location = new System.Drawing.Point(118, 33);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(168, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // outlet_outlet_id_t
            // 
            this.outlet_outlet_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_outlet_id_t.Location = new System.Drawing.Point(35, 60);
            this.outlet_outlet_id_t.Name = "outlet_outlet_id_t";
            this.outlet_outlet_id_t.Size = new System.Drawing.Size(80, 13);
            this.outlet_outlet_id_t.TabIndex = 0;
            this.outlet_outlet_id_t.Text = "Base Office";
            this.outlet_outlet_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // o_name
            // 
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name.Location = new System.Drawing.Point(118, 54);
            this.o_name.MaxLength = 40;
            this.o_name.Name = "o_name";
            this.o_name.Size = new System.Drawing.Size(147, 20);
            this.o_name.TabIndex = 20;
            // 
            // outlet_bmp
            // 
            this.outlet_bmp.Image = ((System.Drawing.Image)(resources.GetObject("outlet_bmp.Image")));
            this.outlet_bmp.Location = new System.Drawing.Point(269, 57);
            this.outlet_bmp.Name = "outlet_bmp";
            this.outlet_bmp.Size = new System.Drawing.Size(17, 15);
            this.outlet_bmp.TabIndex = 0;
            this.outlet_bmp.TabStop = false;
            // 
            // n_28788730
            // 
            this.n_28788730.Font = new System.Drawing.Font("Arial", 8F);
            this.n_28788730.Location = new System.Drawing.Point(20, 80);
            this.n_28788730.Name = "n_28788730";
            this.n_28788730.Size = new System.Drawing.Size(96, 14);
            this.n_28788730.TabIndex = 0;
            this.n_28788730.Text = "Mail Count Date";
            this.n_28788730.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mail_count_date
            // 
            this.mail_count_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "MailCountDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mail_count_date.EditMask = null;
            this.mail_count_date.Font = new System.Drawing.Font("Arial", 8F);
            this.mail_count_date.Location = new System.Drawing.Point(118, 74);
            this.mail_count_date.Mask = "00/00/0000";
            this.mail_count_date.Name = "mail_count_date";
            this.mail_count_date.Size = new System.Drawing.Size(70, 20);
            this.mail_count_date.TabIndex = 30;
            this.mail_count_date.Text = "00000000";
            this.mail_count_date.ValidatingType = typeof(System.DateTime);
            this.mail_count_date.Value = null;
            // 
            // n_57771982
            // 
            this.n_57771982.Font = new System.Drawing.Font("Arial", 8F);
            this.n_57771982.Location = new System.Drawing.Point(2, 103);
            this.n_57771982.Name = "n_57771982";
            this.n_57771982.Size = new System.Drawing.Size(98, 36);
            this.n_57771982.TabIndex = 0;
            this.n_57771982.Text = "Renewal Groups Due to Expire";
            this.n_57771982.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_50185793
            // 
            this.n_50185793.Font = new System.Drawing.Font("Arial", 8F);
            this.n_50185793.Location = new System.Drawing.Point(105, 105);
            this.n_50185793.Name = "n_50185793";
            this.n_50185793.Size = new System.Drawing.Size(11, 13);
            this.n_50185793.TabIndex = 0;
            this.n_50185793.Text = "1.";
            this.n_50185793.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code1
            // 
            this.rg_code1.AutoRetrieve = true;
            this.rg_code1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code1.DisplayMember = "RgDescription";
            this.rg_code1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.rg_code1.Enabled = false;
            this.rg_code1.Font = new System.Drawing.Font("Arial", 8F);
            this.rg_code1.Location = new System.Drawing.Point(118, 102);
            this.rg_code1.Name = "rg_code1";
            this.rg_code1.Size = new System.Drawing.Size(168, 22);
            this.rg_code1.TabIndex = 0;
            this.rg_code1.Value = null;
            this.rg_code1.ValueMember = "RgCode";
            // 
            // n_49018956
            // 
            this.n_49018956.Font = new System.Drawing.Font("Arial", 8F);
            this.n_49018956.Location = new System.Drawing.Point(106, 131);
            this.n_49018956.Name = "n_49018956";
            this.n_49018956.Size = new System.Drawing.Size(10, 14);
            this.n_49018956.TabIndex = 0;
            this.n_49018956.Text = "2.";
            this.n_49018956.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code2
            // 
            this.rg_code2.AutoRetrieve = true;
            this.rg_code2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code2.DisplayMember = "RgDescription";
            this.rg_code2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.rg_code2.Enabled = false;
            this.rg_code2.Font = new System.Drawing.Font("Arial", 8F);
            this.rg_code2.Location = new System.Drawing.Point(118, 124);
            this.rg_code2.Name = "rg_code2";
            this.rg_code2.Size = new System.Drawing.Size(168, 22);
            this.rg_code2.TabIndex = 0;
            this.rg_code2.Value = null;
            this.rg_code2.ValueMember = "RgCode";
            // 
            // n_38517424
            // 
            this.n_38517424.Font = new System.Drawing.Font("Arial", 8F);
            this.n_38517424.Location = new System.Drawing.Point(76, 151);
            this.n_38517424.Name = "n_38517424";
            this.n_38517424.Size = new System.Drawing.Size(36, 14);
            this.n_38517424.TabIndex = 0;
            this.n_38517424.Text = "Print";
            this.n_38517424.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // blankforms
            // 
            this.blankforms.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Blankforms", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.blankforms.Font = new System.Drawing.Font("Arial", 8F);
            this.blankforms.Location = new System.Drawing.Point(118, 146);
            this.blankforms.Name = "blankforms";
            this.blankforms.Size = new System.Drawing.Size(44, 20);
            this.blankforms.TabIndex = 40;
            this.blankforms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // n_11112503
            // 
            this.n_11112503.Font = new System.Drawing.Font("Arial", 8F);
            this.n_11112503.Location = new System.Drawing.Point(171, 151);
            this.n_11112503.Name = "n_11112503";
            this.n_11112503.Size = new System.Drawing.Size(64, 14);
            this.n_11112503.TabIndex = 0;
            this.n_11112503.Text = "blank forms";
            this.n_11112503.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DReportGenericRegOutletCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checked1);
            this.Controls.Add(this.checked2);
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.n_18111828);
            this.Controls.Add(this.outlet_picklist);
            this.Controls.Add(this.ct_key);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.sf_key);
            this.Controls.Add(this.outlet_region_id_t);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.outlet_outlet_id_t);
            this.Controls.Add(this.o_name);
            this.Controls.Add(this.outlet_bmp);
            this.Controls.Add(this.n_28788730);
            this.Controls.Add(this.mail_count_date);
            this.Controls.Add(this.n_57771982);
            this.Controls.Add(this.n_50185793);
            this.Controls.Add(this.rg_code1);
            this.Controls.Add(this.n_49018956);
            this.Controls.Add(this.rg_code2);
            this.Controls.Add(this.n_38517424);
            this.Controls.Add(this.blankforms);
            this.Controls.Add(this.n_11112503);
            this.Name = "DReportGenericRegOutletCriteria";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.Label n_18111828;
        private System.Windows.Forms.CheckBox outlet_picklist;
        private Metex.Windows.DataEntityCombo ct_key;
        private Metex.Windows.DataEntityCombo rg_code;
        private Metex.Windows.DataEntityCombo sf_key;
        private System.Windows.Forms.Label outlet_region_id_t;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.Label outlet_outlet_id_t;
        private System.Windows.Forms.TextBox o_name;
        private System.Windows.Forms.PictureBox outlet_bmp;
        private System.Windows.Forms.Label n_28788730;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox mail_count_date;
        private System.Windows.Forms.Label n_57771982;
        private System.Windows.Forms.Label n_50185793;
        private Metex.Windows.DataEntityCombo rg_code1;
        private System.Windows.Forms.CheckBox checked1;
        private System.Windows.Forms.Label n_49018956;
        private Metex.Windows.DataEntityCombo rg_code2;
        private System.Windows.Forms.CheckBox checked2;
        private System.Windows.Forms.Label n_38517424;
        private System.Windows.Forms.TextBox blankforms;
        private System.Windows.Forms.Label n_11112503;
    }
}


