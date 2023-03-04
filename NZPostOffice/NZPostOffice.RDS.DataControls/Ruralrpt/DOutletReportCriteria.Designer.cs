namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DOutletReportCriteria
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
            this.t_1 = new System.Windows.Forms.Label();
            this.st_report_name = new System.Windows.Forms.Label();
            this.region_id_t = new System.Windows.Forms.Label();
            this.regionid = new Metex.Windows.DataEntityCombo();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.OutletReportCriteria);
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.t_1.Location = new System.Drawing.Point(230, 4);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(98, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "Search Criteria";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // st_report_name
            // 
            this.st_report_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_report_name.Location = new System.Drawing.Point(4, 4);
            this.st_report_name.Name = "st_report_name";
            this.st_report_name.Size = new System.Drawing.Size(202, 13);
            this.st_report_name.TabIndex = 0;
            this.st_report_name.Text = "Base Office Outlet Report";
            this.st_report_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // region_id_t
            // 
            this.region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_t.Location = new System.Drawing.Point(36, 27);
            this.region_id_t.Name = "region_id_t";
            this.region_id_t.Size = new System.Drawing.Size(51, 13);
            this.region_id_t.TabIndex = 0;
            this.region_id_t.Text = "Region";
            this.region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // regionid
            // 
            this.regionid.AutoRetrieve = true;
            this.regionid.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Regionid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.regionid.DisplayMember = "RgnName";
            this.regionid.DropDownHeight = 150;
            this.regionid.Font = new System.Drawing.Font("Arial", 8F);
            this.regionid.Location = new System.Drawing.Point(94, 23);
            this.regionid.Name = "regionid";
            this.regionid.Size = new System.Drawing.Size(208, 22);
            this.regionid.TabIndex = 10;
            this.regionid.Value = null;
            this.regionid.ValueMember = "RegionId";
            // 
            // DOutletReportCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.st_report_name);
            this.Controls.Add(this.region_id_t);
            this.Controls.Add(this.regionid);
            this.Name = "DOutletReportCriteria";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label st_report_name;
        private System.Windows.Forms.Label region_id_t;
        private Metex.Windows.DataEntityCombo regionid;
    }
}
