namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DReportGenericCriteriaWithRegion
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
            this.n_12347112 = new System.Windows.Forms.Label();
            this.st_report = new System.Windows.Forms.Label();
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.region_id = new Metex.Windows.DataEntityCombo();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.ReportGenericCriteriaWithRegion);
            // 
            // n_12347112
            // 
            this.n_12347112.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F,System.Drawing.FontStyle.Bold);
            this.n_12347112.Location = new System.Drawing.Point(88, 15);
            this.n_12347112.Name = "n_12347112";
            this.n_12347112.Size = new System.Drawing.Size(113, 13);
            this.n_12347112.TabIndex = 0;
            this.n_12347112.Text = "Search Criteria";
            this.n_12347112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // st_report
            // 
            this.st_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F,System.Drawing.FontStyle.Bold);
            this.st_report.Location = new System.Drawing.Point(4, 2);
            this.st_report.Name = "st_report";
            this.st_report.Size = new System.Drawing.Size(397, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Text = "Report:";
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outlet_region_id_t
            // 
            this.outlet_region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_region_id_t.Location = new System.Drawing.Point(11, 34);
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Size = new System.Drawing.Size(80, 13);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Text = "Region";
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.Location = new System.Drawing.Point(97, 31);
            this.region_id.Name = "region_id";
            this.region_id.DataBindings[0].DataSourceNullValue = null;
            this.region_id.Size = new System.Drawing.Size(198, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // DReportGenericCriteriaWithRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.n_12347112);
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.outlet_region_id_t);
            this.Controls.Add(this.region_id);
            this.Name = "DReportGenericCriteriaWithRegion";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label n_12347112;
        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.Label outlet_region_id_t;
        private Metex.Windows.DataEntityCombo region_id;
    }
}
