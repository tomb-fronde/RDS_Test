namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DReportGenericRegOutletCriteria
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
            this.Name = "DReportGenericRegOutletCriteria";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.ReportGenericRegOutletCriteria);
            #region checked1 define
            this.checked1 = new System.Windows.Forms.CheckBox();
            this.checked1.Name = "checked1";
            this.checked1.Location = new System.Drawing.Point(269, 105);
            this.checked1.Size = new System.Drawing.Size(14, 12);
            this.checked1.TabIndex = 50;
            this.checked1.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.checked1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checked1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "Checked1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checked1.Text = "";
            this.checked1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //?this.checked1.ThreeState = true;
            #endregion
            this.Controls.Add(checked1);

            #region checked2 define
            this.checked2 = new System.Windows.Forms.CheckBox();
            this.checked2.Name = "checked2";
            this.checked2.Location = new System.Drawing.Point(269, 132);
            this.checked2.Size = new System.Drawing.Size(14, 12);
            this.checked2.TabIndex = 60;
            this.checked2.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.checked2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checked2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "Checked2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checked2.Text = "";
            this.checked2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //?this.checked2.ThreeState = true;
            //?this.checked2.BringToFront();
            #endregion
            this.Controls.Add(checked2);

            #region st_report define
            this.st_report = new System.Windows.Forms.Label();
            this.st_report.Name = "st_report";
            this.st_report.Location = new System.Drawing.Point(4, 2);
            this.st_report.Size = new System.Drawing.Size(326, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_report.Text = "Report:";
            #endregion
            this.Controls.Add(st_report);
            #region n_18111828 define
            this.n_18111828 = new System.Windows.Forms.Label();
            this.n_18111828.Name = "n_18111828";
            this.n_18111828.Location = new System.Drawing.Point(117, 15);
            this.n_18111828.Size = new System.Drawing.Size(113, 13);
            this.n_18111828.TabIndex = 0;
            this.n_18111828.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.n_18111828.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_18111828.Text = "Search Criteria";
            #endregion
            this.Controls.Add(n_18111828);
            #region outlet_picklist define
            this.outlet_picklist = new System.Windows.Forms.CheckBox();
            this.outlet_picklist.Name = "outlet_picklist";
            this.outlet_picklist.Location = new System.Drawing.Point(5, 5);
            this.outlet_picklist.Size = new System.Drawing.Size(5, 1);
            this.outlet_picklist.TabIndex = 0;
            this.outlet_picklist.Enabled = false;
            this.outlet_picklist.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.outlet_picklist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.outlet_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_picklist.Text = "";
            this.outlet_picklist.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.outlet_picklist.ThreeState = false;
            #endregion
            this.Controls.Add(outlet_picklist);
            #region ct_key define
            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.ct_key.Name = "ct_key";
            this.ct_key.Location = new System.Drawing.Point(390, 208);
            this.ct_key.Size = new System.Drawing.Size(22, 22);
            this.ct_key.TabIndex = 0;
            this.ct_key.Enabled = false;
            this.ct_key.Font = new System.Drawing.Font("Arial", 8);
            //this.ct_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.ValueMember = "CtKey";
            this.ct_key.AutoRetrieve = true;
            #endregion
            this.Controls.Add(ct_key);
            #region rg_code define
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.rg_code.Name = "rg_code";
            this.rg_code.Location = new System.Drawing.Point(420, 206);
            this.rg_code.Size = new System.Drawing.Size(22, 22);
            this.rg_code.TabIndex = 0;
            this.rg_code.Enabled = false;
            this.rg_code.Font = new System.Drawing.Font("Arial", 8);
            //this.rg_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.ValueMember = "RgCode";
            this.rg_code.AutoRetrieve = true;
            #endregion
            this.Controls.Add(rg_code);
            #region sf_key define
            this.sf_key = new Metex.Windows.DataEntityCombo();
            this.sf_key.Name = "sf_key";
            this.sf_key.Location = new System.Drawing.Point(452, 211);
            this.sf_key.Size = new System.Drawing.Size(22, 22);
            this.sf_key.TabIndex = 0;
            this.sf_key.Enabled = false;
            this.sf_key.Font = new System.Drawing.Font("Arial", 8);
            //this.sf_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.sf_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "SfKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sf_key.DisplayMember = "SfDescription";
            this.sf_key.ValueMember = "SfKey";
            this.sf_key.AutoRetrieve = true;
            #endregion
            this.Controls.Add(sf_key);
            #region outlet_region_id_t define
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Location = new System.Drawing.Point(75, 38);
            this.outlet_region_id_t.Size = new System.Drawing.Size(42, 11);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.outlet_region_id_t.Text = "Region";
            #endregion
            this.Controls.Add(outlet_region_id_t);
            #region region_id define
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.region_id.Name = "region_id";
            this.region_id.Location = new System.Drawing.Point(118, 33);
            this.region_id.Size = new System.Drawing.Size(168, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.region_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.ValueMember = "RegionId";
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings[0].DataSourceNullValue = null;
            #endregion
            this.Controls.Add(region_id);
            #region outlet_outlet_id_t define
            this.outlet_outlet_id_t = new System.Windows.Forms.Label();
            this.outlet_outlet_id_t.Name = "outlet_outlet_id_t";
            this.outlet_outlet_id_t.Location = new System.Drawing.Point(35, 60);
            this.outlet_outlet_id_t.Size = new System.Drawing.Size(80, 13);
            this.outlet_outlet_id_t.TabIndex = 0;
            this.outlet_outlet_id_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.outlet_outlet_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.outlet_outlet_id_t.Text = "Base Office";
            #endregion
            this.Controls.Add(outlet_outlet_id_t);
            #region o_name define
            this.o_name = new System.Windows.Forms.TextBox();
            this.o_name.Name = "o_name";
            this.o_name.Location = new System.Drawing.Point(118, 54);
            this.o_name.Size = new System.Drawing.Size(147, 20);
            this.o_name.TabIndex = 20;
            this.o_name.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.o_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.o_name.MaxLength = 40;
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(o_name);
            #region outlet_bmp define
            this.outlet_bmp = new System.Windows.Forms.PictureBox();
            this.outlet_bmp.Name = "outlet_bmp";
            this.outlet_bmp.Location = new System.Drawing.Point(269, 57);
            this.outlet_bmp.Size = new System.Drawing.Size(17, 15);
            this.outlet_bmp.TabIndex = 0;
            this.outlet_bmp.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;// ((object)(resources.GetObject("outlet_bmp.Image")));

            #endregion
            this.Controls.Add(outlet_bmp);
            #region n_28788730 define
            this.n_28788730 = new System.Windows.Forms.Label();
            this.n_28788730.Name = "n_28788730";
            this.n_28788730.Location = new System.Drawing.Point(20, 80);
            this.n_28788730.Size = new System.Drawing.Size(96, 14);
            this.n_28788730.TabIndex = 0;
            this.n_28788730.Font = new System.Drawing.Font("Arial", 8);
            this.n_28788730.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_28788730.Text = "Mail Count Date";
            #endregion
            this.Controls.Add(n_28788730);
            #region mail_count_date define
            this.mail_count_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.mail_count_date.Name = "mail_count_date";
            this.mail_count_date.Location = new System.Drawing.Point(118, 74);
            this.mail_count_date.Size = new System.Drawing.Size(70, 20);
            this.mail_count_date.TabIndex = 30;
            this.mail_count_date.Font = new System.Drawing.Font("Arial", 8);
            this.mail_count_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mail_count_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "MailCountDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mail_count_date.Mask = "00/00/0000";
            this.mail_count_date.DataBindings[0].FormatString = "dd/MM/yyyy";

            this.mail_count_date.ValidatingType = typeof(System.DateTime);

            #endregion
            this.Controls.Add(mail_count_date);
            #region n_57771982 define
            this.n_57771982 = new System.Windows.Forms.Label();
            this.n_57771982.Name = "n_57771982";
            this.n_57771982.Location = new System.Drawing.Point(2, 103);
            this.n_57771982.Size = new System.Drawing.Size(98, 36);
            this.n_57771982.TabIndex = 0;
            this.n_57771982.Font = new System.Drawing.Font("Arial", 8);
            this.n_57771982.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_57771982.Text = "Renewal Groups Due to Expire";
            #endregion
            this.Controls.Add(n_57771982);
            #region n_50185793 define
            this.n_50185793 = new System.Windows.Forms.Label();
            this.n_50185793.Name = "n_50185793";
            this.n_50185793.Location = new System.Drawing.Point(105, 105);
            this.n_50185793.Size = new System.Drawing.Size(11, 13);
            this.n_50185793.TabIndex = 0;
            this.n_50185793.Font = new System.Drawing.Font("Arial", 8);
            this.n_50185793.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_50185793.Text = "1.";
            #endregion
            this.Controls.Add(n_50185793);
            #region rg_code1 define
            this.rg_code1 = new Metex.Windows.DataEntityCombo();
            this.rg_code1.AutoRetrieve = true;
            this.rg_code1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rg_code1.Name = "rg_code1";
            this.rg_code1.Location = new System.Drawing.Point(118, 102);
            this.rg_code1.Size = new System.Drawing.Size(168, 22);
            this.rg_code1.TabIndex = 0;
            this.rg_code1.Enabled = false;
            this.rg_code1.Font = new System.Drawing.Font("Arial", 8);
            this.rg_code1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code1.DisplayMember = "RgDescription";
            this.rg_code1.ValueMember = "RgCode";
            this.rg_code1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            #endregion
            this.Controls.Add(rg_code1);

            #region n_49018956 define
            this.n_49018956 = new System.Windows.Forms.Label();
            this.n_49018956.Name = "n_49018956";
            this.n_49018956.Location = new System.Drawing.Point(106, 131);
            this.n_49018956.Size = new System.Drawing.Size(10, 14);
            this.n_49018956.TabIndex = 0;
            this.n_49018956.Font = new System.Drawing.Font("Arial", 8);
            this.n_49018956.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_49018956.Text = "2.";
            #endregion
            this.Controls.Add(n_49018956);
            #region rg_code2 define
            this.rg_code2 = new Metex.Windows.DataEntityCombo();
            this.rg_code2.AutoRetrieve = true;
            this.rg_code2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rg_code2.Name = "rg_code2";
            this.rg_code2.Location = new System.Drawing.Point(118, 124);
            this.rg_code2.Size = new System.Drawing.Size(168, 22);
            this.rg_code2.TabIndex = 0;
            this.rg_code2.Enabled = false;
            this.rg_code2.Font = new System.Drawing.Font("Arial", 8);
            this.rg_code2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code2.DisplayMember = "RgDescription";
            this.rg_code2.ValueMember = "RgCode";
            this.rg_code2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;


            #endregion
            this.Controls.Add(rg_code2);

            #region n_38517424 define
            this.n_38517424 = new System.Windows.Forms.Label();
            this.n_38517424.Name = "n_38517424";
            this.n_38517424.Location = new System.Drawing.Point(76, 151);
            this.n_38517424.Size = new System.Drawing.Size(36, 14);
            this.n_38517424.TabIndex = 0;
            this.n_38517424.Font = new System.Drawing.Font("Arial", 8);
            this.n_38517424.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_38517424.Text = "Print";
            #endregion
            this.Controls.Add(n_38517424);
            #region blankforms define
            this.blankforms = new System.Windows.Forms.TextBox();
            this.blankforms.Name = "blankforms";
            this.blankforms.Location = new System.Drawing.Point(118, 146);
            this.blankforms.Size = new System.Drawing.Size(44, 20);
            this.blankforms.TabIndex = 40;
            this.blankforms.Font = new System.Drawing.Font("Arial", 8);
            this.blankforms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.blankforms.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Blankforms", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.blankforms.DataBindings[0].NullValue = "";
            this.blankforms.DataBindings[0].DataSourceNullValue = null;
            #endregion
            this.Controls.Add(blankforms);
            #region n_11112503 define
            this.n_11112503 = new System.Windows.Forms.Label();
            this.n_11112503.Name = "n_11112503";
            this.n_11112503.Location = new System.Drawing.Point(171, 151);
            this.n_11112503.Size = new System.Drawing.Size(64, 14);
            this.n_11112503.TabIndex = 0;
            this.n_11112503.Font = new System.Drawing.Font("Arial", 8);
            this.n_11112503.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_11112503.Text = "blank forms";
            #endregion
            this.Controls.Add(n_11112503);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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


