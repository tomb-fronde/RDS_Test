namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DReportGenericOutletCriteriawithrgct
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
            this.Name = "DReportGenericOutletCriteriawithrgct";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.ReportGenericOutletCriteriawithrgct);
            #region n_54656863 define
            this.n_54656863 = new System.Windows.Forms.Label();
            this.n_54656863.Name = "n_54656863";
            this.n_54656863.Location = new System.Drawing.Point(117, 20);
            this.n_54656863.Size = new System.Drawing.Size(113, 13);
            this.n_54656863.TabIndex = 0;
            this.n_54656863.Font = new System.Drawing.Font("MS Sans Serif", 8F,System.Drawing.FontStyle.Bold);
            this.n_54656863.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_54656863.Text = "Search Criteria";
            #endregion
            this.Controls.Add(n_54656863);
            #region st_report define
            this.st_report = new System.Windows.Forms.Label();
            this.st_report.Name = "st_report";
            this.st_report.Location = new System.Drawing.Point(118, 3);
            this.st_report.Size = new System.Drawing.Size(326, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_report.Text = "Report:";
            #endregion
            this.Controls.Add(st_report);
            #region outlet_picklist define
            this.outlet_picklist = new System.Windows.Forms.CheckBox();
            this.outlet_picklist.Name = "outlet_picklist";
            this.outlet_picklist.Location = new System.Drawing.Point(701, 60);
            this.outlet_picklist.Size = new System.Drawing.Size(30, 15);
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
            #region outlet_region_id_t define
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Location = new System.Drawing.Point(53, 40);
            this.outlet_region_id_t.Size = new System.Drawing.Size(62, 13);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.outlet_region_id_t.Text = "Region";
            #endregion
            this.Controls.Add(outlet_region_id_t);
            #region region_id_ro define
            this.region_id_ro = new Metex.Windows.DataEntityCombo();
            this.region_id_ro.Name = "region_id_ro";
            this.region_id_ro.Location = new System.Drawing.Point(118, 37);
            this.region_id_ro.Size = new System.Drawing.Size(179, 21);
            this.region_id_ro.TabIndex = 0;
            this.region_id_ro.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.region_id_ro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.region_id_ro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id_ro.DataBindings[0].DataSourceNullValue = null;
            this.region_id_ro.DisplayMember = "RgnName";
            this.region_id_ro.ValueMember = "RegionId";
            this.region_id_ro.AutoRetrieve = true;
            #endregion
            this.Controls.Add(region_id_ro);
            #region region_id define
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.region_id.Name = "region_id";
            this.region_id.Location = new System.Drawing.Point(118, 37);
            this.region_id.Size = new System.Drawing.Size(179, 21);
            this.region_id.TabIndex = 20;
            this.region_id.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.region_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DataBindings[0].DataSourceNullValue = null;
            this.region_id.DisplayMember = "RgnName";
            this.region_id.ValueMember = "RegionId";
            this.region_id.AutoRetrieve = true;
            #endregion
            this.Controls.Add(region_id);
            #region outlet_outlet_id_t define
            this.outlet_outlet_id_t = new System.Windows.Forms.Label();
            this.outlet_outlet_id_t.Name = "outlet_outlet_id_t";
            this.outlet_outlet_id_t.Location = new System.Drawing.Point(35, 61);
            this.outlet_outlet_id_t.Size = new System.Drawing.Size(81, 13);
            this.outlet_outlet_id_t.TabIndex = 0;
            this.outlet_outlet_id_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.outlet_outlet_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.outlet_outlet_id_t.Text = "Base Office";
            #endregion
            this.Controls.Add(outlet_outlet_id_t);
            #region o_name define
            this.o_name = new System.Windows.Forms.TextBox();
            this.o_name.Name = "o_name";
            this.o_name.Location = new System.Drawing.Point(118, 60);
            this.o_name.Size = new System.Drawing.Size(156, 20);
            this.o_name.TabIndex = 30;
            this.o_name.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.o_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.o_name.MaxLength = 40;
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(o_name);
            #region outlet_bmp define
            this.outlet_bmp = new System.Windows.Forms.PictureBox();
            this.outlet_bmp.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;
            this.outlet_bmp.Name = "outlet_bmp";
            this.outlet_bmp.Location = new System.Drawing.Point(277, 64);
            this.outlet_bmp.Size = new System.Drawing.Size(17, 15);
            this.outlet_bmp.TabIndex = 0;
            //?this.outlet_bmp.Image = ((object)(resources.GetObject("outlet_bmp.Image")));
            #endregion
            this.Controls.Add(outlet_bmp);
            #region n_22149720 define
            this.n_22149720 = new System.Windows.Forms.Label();
            this.n_22149720.Name = "n_22149720";
            this.n_22149720.Location = new System.Drawing.Point(28, 82);
            this.n_22149720.Size = new System.Drawing.Size(88, 13);
            this.n_22149720.TabIndex = 0;
            this.n_22149720.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_22149720.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_22149720.Text = "Renewal group";
            #endregion
            this.Controls.Add(n_22149720);
            #region rg_code define
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.rg_code.Name = "rg_code";
            this.rg_code.Location = new System.Drawing.Point(118, 82);
            this.rg_code.Size = new System.Drawing.Size(179, 21);
            this.rg_code.TabIndex = 40;
            this.rg_code.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.rg_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.ValueMember = "RgCode";
            this.rg_code.DataBindings[0].DataSourceNullValue = null;
            this.rg_code.AutoRetrieve = true;
            #endregion
            this.Controls.Add(rg_code);
            #region n_65129753 define
            this.n_65129753 = new System.Windows.Forms.Label();
            this.n_65129753.Name = "n_65129753";
            this.n_65129753.Location = new System.Drawing.Point(28, 108);
            this.n_65129753.Size = new System.Drawing.Size(88, 13);
            this.n_65129753.TabIndex = 0;
            this.n_65129753.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_65129753.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_65129753.Text = "Contract type";
            #endregion
            this.Controls.Add(n_65129753);
            #region ct_key define
            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.ct_key.Name = "ct_key";
            this.ct_key.Location = new System.Drawing.Point(118, 105);
            this.ct_key.Size = new System.Drawing.Size(179, 21);
            this.ct_key.TabIndex = 10;
            this.ct_key.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.ct_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.ValueMember = "CtKey";
            this.ct_key.AutoRetrieve = true;
            #endregion
            this.Controls.Add(ct_key);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.Label n_54656863;
        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.CheckBox outlet_picklist;
        private System.Windows.Forms.Label outlet_region_id_t;
        private Metex.Windows.DataEntityCombo region_id_ro;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.Label outlet_outlet_id_t;
        private System.Windows.Forms.TextBox o_name;
        private System.Windows.Forms.PictureBox outlet_bmp;
        private System.Windows.Forms.Label n_22149720;
        private Metex.Windows.DataEntityCombo rg_code;
        private System.Windows.Forms.Label n_65129753;
        private Metex.Windows.DataEntityCombo ct_key;
    }
}


