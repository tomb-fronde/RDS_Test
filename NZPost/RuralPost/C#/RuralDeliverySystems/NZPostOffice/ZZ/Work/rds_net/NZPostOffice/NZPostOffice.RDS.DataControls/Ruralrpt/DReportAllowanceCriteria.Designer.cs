namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DReportAllowanceCriteria
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
            this.t_1 = new System.Windows.Forms.Label();
            this.region_id_t = new System.Windows.Forms.Label();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.ct_key_t = new System.Windows.Forms.Label();
            this.rg_code_t = new System.Windows.Forms.Label();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.ReportAllowanceCriteria);
            // 
            // st_report
            // 
            this.st_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_report.Location = new System.Drawing.Point(4, 2);
            this.st_report.Name = "st_report";
            this.st_report.Size = new System.Drawing.Size(273, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Text = "Contract Allowance Summary Report";
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F,System.Drawing.FontStyle.Bold);
            this.t_1.Location = new System.Drawing.Point(117, 20);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(113, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "Search Criteria";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // region_id_t
            // 
            this.region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_t.Location = new System.Drawing.Point(20, 40);
            this.region_id_t.Name = "region_id_t";
            this.region_id_t.Size = new System.Drawing.Size(91, 13);
            this.region_id_t.TabIndex = 0;
            this.region_id_t.Text = "Region";
            this.region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Arial", 8F);
            this.region_id.Location = new System.Drawing.Point(118, 39);
            this.region_id.Name = "region_id";
            this.region_id.DataBindings[0].DataSourceNullValue = null;
            this.region_id.Size = new System.Drawing.Size(159, 22);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.Font = new System.Drawing.Font("Arial", 8F);
            this.ct_key.Location = new System.Drawing.Point(118, 92);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(159, 22);
            this.ct_key.TabIndex = 30;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";
            // 
            // ct_key_t
            // 
            this.ct_key_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ct_key_t.Location = new System.Drawing.Point(19, 94);
            this.ct_key_t.Name = "ct_key_t";
            this.ct_key_t.Size = new System.Drawing.Size(91, 14);
            this.ct_key_t.TabIndex = 0;
            this.ct_key_t.Text = "Contract Type";
            this.ct_key_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code_t
            // 
            this.rg_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code_t.Location = new System.Drawing.Point(20, 66);
            this.rg_code_t.Name = "rg_code_t";
            this.rg_code_t.Size = new System.Drawing.Size(91, 13);
            this.rg_code_t.TabIndex = 0;
            this.rg_code_t.Text = "Renewal Group";
            this.rg_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.Font = new System.Drawing.Font("Arial", 8F);
            this.rg_code.Location = new System.Drawing.Point(118, 65);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(159, 22);
            this.rg_code.TabIndex = 20;
            // this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            this.rg_code.DataBindings[0].DataSourceNullValue = null;
            this.rg_code.DataBindings[0].NullValue = null;
            // 
            // DReportAllowanceCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.region_id_t);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.ct_key);
            this.Controls.Add(this.ct_key_t);
            this.Controls.Add(this.rg_code_t);
            this.Controls.Add(this.rg_code);
            this.Name = "DReportAllowanceCriteria";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label region_id_t;
        private Metex.Windows.DataEntityCombo region_id;
        private Metex.Windows.DataEntityCombo ct_key;
        private System.Windows.Forms.Label ct_key_t;
        private System.Windows.Forms.Label rg_code_t;
        private Metex.Windows.DataEntityCombo rg_code;
    }
}
