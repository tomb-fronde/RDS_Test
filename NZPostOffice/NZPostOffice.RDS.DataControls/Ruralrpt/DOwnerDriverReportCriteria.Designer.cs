namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DOwnerDriverReportCriteria
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
            this.n_32979223 = new System.Windows.Forms.Label();
            this.st_report = new System.Windows.Forms.Label();
            this.region_id_ro = new Metex.Windows.DataEntityCombo();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.outlet_outlet_id_t = new System.Windows.Forms.Label();
            this.ownerdriver = new System.Windows.Forms.TextBox();
            this.n_28377553 = new System.Windows.Forms.Label();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.n_54071387 = new System.Windows.Forms.Label();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.OwnerDriverReportCriteria);
            // 
            // n_32979223
            // 
            this.n_32979223.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_32979223.Location = new System.Drawing.Point(115, 20);
            this.n_32979223.Name = "n_32979223";
            this.n_32979223.Size = new System.Drawing.Size(113, 13);
            this.n_32979223.TabIndex = 0;
            this.n_32979223.Text = "Search Criteria";
            this.n_32979223.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // st_report
            // 
            this.st_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_report.Location = new System.Drawing.Point(4, 2);
            this.st_report.Name = "st_report";
            this.st_report.Size = new System.Drawing.Size(214, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Text = "Report: Owner Driver Labels";
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // region_id_ro
            // 
            this.region_id_ro.AutoRetrieve = true;
            this.region_id_ro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id_ro.DisplayMember = "RgnName";
            this.region_id_ro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.region_id_ro.Enabled = false;
            this.region_id_ro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_ro.Location = new System.Drawing.Point(118, 39);
            this.region_id_ro.Name = "region_id_ro";
            this.region_id_ro.Size = new System.Drawing.Size(181, 21);
            this.region_id_ro.TabIndex = 10;
            this.region_id_ro.Value = null;
            this.region_id_ro.ValueMember = "RegionId";
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.DropDownHeight = 150;
            this.region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.IntegralHeight = false;
            this.region_id.Location = new System.Drawing.Point(118, 39);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(181, 21);
            this.region_id.TabIndex = 0;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // outlet_region_id_t
            // 
            this.outlet_region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_region_id_t.Location = new System.Drawing.Point(56, 39);
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Size = new System.Drawing.Size(58, 13);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Text = "Region";
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // outlet_outlet_id_t
            // 
            this.outlet_outlet_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_outlet_id_t.Location = new System.Drawing.Point(26, 61);
            this.outlet_outlet_id_t.Name = "outlet_outlet_id_t";
            this.outlet_outlet_id_t.Size = new System.Drawing.Size(88, 13);
            this.outlet_outlet_id_t.TabIndex = 0;
            this.outlet_outlet_id_t.Text = "Owner Driver";
            this.outlet_outlet_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ownerdriver
            // 
            this.ownerdriver.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Ownerdriver", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ownerdriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ownerdriver.Location = new System.Drawing.Point(118, 60);
            this.ownerdriver.MaxLength = 40;
            this.ownerdriver.Name = "ownerdriver";
            this.ownerdriver.Size = new System.Drawing.Size(160, 20);
            this.ownerdriver.TabIndex = 20;
            // 
            // n_28377553
            // 
            this.n_28377553.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_28377553.Location = new System.Drawing.Point(18, 83);
            this.n_28377553.Name = "n_28377553";
            this.n_28377553.Size = new System.Drawing.Size(96, 13);
            this.n_28377553.TabIndex = 0;
            this.n_28377553.Text = "Renewal Group";
            this.n_28377553.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.DropDownHeight = 150;
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.Location = new System.Drawing.Point(118, 80);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(181, 21);
            this.rg_code.TabIndex = 40;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            // 
            // n_54071387
            // 
            this.n_54071387.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_54071387.Location = new System.Drawing.Point(26, 105);
            this.n_54071387.Name = "n_54071387";
            this.n_54071387.Size = new System.Drawing.Size(88, 13);
            this.n_54071387.TabIndex = 0;
            this.n_54071387.Text = "Contract Type";
            this.n_54071387.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.DropDownHeight = 150;
            this.ct_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ct_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ct_key.IntegralHeight = false;
            this.ct_key.Location = new System.Drawing.Point(118, 101);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(181, 21);
            this.ct_key.TabIndex = 30;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";
            // 
            // DOwnerDriverReportCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.n_32979223);
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.outlet_region_id_t);
            this.Controls.Add(this.outlet_outlet_id_t);
            this.Controls.Add(this.ownerdriver);
            this.Controls.Add(this.n_28377553);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.n_54071387);
            this.Controls.Add(this.ct_key);
            this.Controls.Add(this.region_id_ro);
            this.Name = "DOwnerDriverReportCriteria";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_32979223;
        private System.Windows.Forms.Label st_report;
        private Metex.Windows.DataEntityCombo region_id_ro;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.Label outlet_region_id_t;
        private System.Windows.Forms.Label outlet_outlet_id_t;
        private System.Windows.Forms.TextBox ownerdriver;
        private System.Windows.Forms.Label n_28377553;
        private Metex.Windows.DataEntityCombo rg_code;
        private System.Windows.Forms.Label n_54071387;
        private Metex.Windows.DataEntityCombo ct_key;
    }
}
