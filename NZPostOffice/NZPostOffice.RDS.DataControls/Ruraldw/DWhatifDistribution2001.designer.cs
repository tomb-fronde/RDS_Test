namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DWhatifDistribution2001
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reDWhatifDistribution2001 = new NZPostOffice.RDS.DataControls.Report.REDWhatifDistribution2001();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.WhatifDistribution2001);

            // 
            // crystalReportViewer1
            // 
            this.viewer.ActiveViewIndex = 0;
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.DisplayGroupTree = false;
            this.viewer.DisplayStatusBar = false;
            this.viewer.Size = new System.Drawing.Size(638, 252);
            this.viewer.TabIndex = 0;
            this.viewer.ReportSource = this.reDWhatifDistribution2001;

            // 
            // DWhatifDistribution2001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DwRunningSheetHeader";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            table = new NZPostOffice.RDS.DataControls.Report.WhatifDistribution2001DataSet(this.bindingSource.DataSource);
            this.reDWhatifDistribution2001.SetDataSource(table);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.RetrieveEnd += new System.EventHandler(DWhatifDistribution2001_RetrieveEnd);
            this.ResumeLayout(false);
        }

        void DWhatifDistribution2001_RetrieveEnd(object sender, System.EventArgs e)
        {

        }
        private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            //table = new NZPostOffice.RDS.DataControls.Report.WhatifDistribution2001DataSet(this.bindingSource.DataSource);
            //this.reDWhatifDistribution2001.SetDataSource(table);
            //viewer.RefreshReport();
        }
        #endregion

        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.REDWhatifDistribution2001 reDWhatifDistribution2001;
    }
}
