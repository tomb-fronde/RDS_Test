namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DReportGenericOutletCriteriawithrg
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
            this.n_46915732 = new System.Windows.Forms.Label();
            this.st_report = new System.Windows.Forms.Label();
            this.outlet_picklist = new System.Windows.Forms.CheckBox();
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.outlet_outlet_id_t = new System.Windows.Forms.Label();
            this.contract_type = new System.Windows.Forms.Label();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.o_name = new System.Windows.Forms.TextBox();
            this.outlet_bmp = new System.Windows.Forms.PictureBox();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.n_19588408 = new System.Windows.Forms.Label();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ReportGenericOutletCriteriawithrg);
            // 
            // n_46915732
            // 
            this.n_46915732.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_46915732.Location = new System.Drawing.Point(117, 18);
            this.n_46915732.Name = "n_46915732";
            this.n_46915732.Size = new System.Drawing.Size(113, 13);
            this.n_46915732.TabIndex = 0;
            this.n_46915732.Text = "Search Criteria";
            this.n_46915732.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // outlet_picklist
            // 
            this.outlet_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_picklist.Enabled = false;
            this.outlet_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_picklist.Location = new System.Drawing.Point(701, 60);
            this.outlet_picklist.Name = "outlet_picklist";
            this.outlet_picklist.Size = new System.Drawing.Size(30, 15);
            this.outlet_picklist.TabIndex = 0;
            // 
            // outlet_region_id_t
            // 
            this.outlet_region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_region_id_t.Location = new System.Drawing.Point(50, 36);
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Size = new System.Drawing.Size(61, 13);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Text = "Region";
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // outlet_outlet_id_t
            // 
            this.outlet_outlet_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_outlet_id_t.Location = new System.Drawing.Point(35, 63);
            this.outlet_outlet_id_t.Name = "outlet_outlet_id_t";
            this.outlet_outlet_id_t.Size = new System.Drawing.Size(76, 13);
            this.outlet_outlet_id_t.TabIndex = 0;
            this.outlet_outlet_id_t.Text = "Base Office";
            this.outlet_outlet_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_type
            // 
            this.contract_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_type.Location = new System.Drawing.Point(11, 89);
            this.contract_type.Name = "contract_type";
            this.contract_type.Size = new System.Drawing.Size(101, 13);
            this.contract_type.TabIndex = 0;
            this.contract_type.Text = "Contract Type";
            this.contract_type.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.Location = new System.Drawing.Point(116, 36);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(171, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            this.region_id.DataBindings[0].DataSourceNullValue = null;
            // 
            // o_name
            // 
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name.Location = new System.Drawing.Point(116, 61);
            this.o_name.MaxLength = 40;
            this.o_name.Name = "o_name";
            this.o_name.Size = new System.Drawing.Size(152, 20);
            this.o_name.TabIndex = 20;
            // 
            // outlet_bmp
            // 
            this.outlet_bmp.Location = new System.Drawing.Point(270, 62);
            this.outlet_bmp.Name = "outlet_bmp";
            this.outlet_bmp.Size = new System.Drawing.Size(17, 18);
            this.outlet_bmp.TabIndex = 0;
            this.outlet_bmp.TabStop = false;
            this.outlet_bmp.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ct_key.Location = new System.Drawing.Point(116, 86);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(171, 21);
            this.ct_key.TabIndex = 30;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";
            this.ct_key.DataBindings[0].DataSourceNullValue = null;
            // 
            // n_19588408
            // 
            this.n_19588408.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_19588408.Location = new System.Drawing.Point(13, 113);
            this.n_19588408.Name = "n_19588408";
            this.n_19588408.Size = new System.Drawing.Size(98, 13);
            this.n_19588408.TabIndex = 0;
            this.n_19588408.Text = "Renewal group";
            this.n_19588408.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.Location = new System.Drawing.Point(116, 111);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(171, 21);
            this.rg_code.TabIndex = 40;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            this.rg_code.DataBindings[0].DataSourceNullValue = null;

            // 
            // DReportGenericOutletCriteriawithrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.n_46915732);
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.outlet_picklist);
            this.Controls.Add(this.outlet_region_id_t);
            this.Controls.Add(this.outlet_outlet_id_t);
            this.Controls.Add(this.contract_type);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.o_name);
            this.Controls.Add(this.outlet_bmp);
            this.Controls.Add(this.ct_key);
            this.Controls.Add(this.n_19588408);
            this.Controls.Add(this.rg_code);
            this.Name = "DReportGenericOutletCriteriawithrg";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_46915732;
        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.CheckBox outlet_picklist;
        private System.Windows.Forms.Label outlet_region_id_t;
        private System.Windows.Forms.Label outlet_outlet_id_t;
        private System.Windows.Forms.Label contract_type;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.TextBox o_name;
        private System.Windows.Forms.PictureBox outlet_bmp;
        private Metex.Windows.DataEntityCombo ct_key;
        private System.Windows.Forms.Label n_19588408;
        private Metex.Windows.DataEntityCombo rg_code;
    }
}
