namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DwRunningSheetHeader
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
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reRunningSheetHeader = new NZPostOffice.RDS.DataControls.Report.REDwRunningSheetHeader();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RunningSheetHeader);

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
            this.viewer.ReportSource = this.reRunningSheetHeader;

            // 
            // DwRunningSheetHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DwRunningSheetHeader";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            table = new NZPostOffice.RDS.DataControls.Report.RunningSheetHeaderDataSet(this.bindingSource.DataSource);
            this.reRunningSheetHeader.SetDataSource(table);
            this.RetrieveEnd += new System.EventHandler(DwRunningSheetHeader_RetrieveEnd);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.ResumeLayout(false);
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            //lock (reRunningSheetHeader)
            //{
            //    table = new NZPostOffice.RDS.DataControls.Report.RunningSheetHeaderDataSet(this.bindingSource.DataSource);
            //    this.reRunningSheetHeader.SetDataSource(table);
            //}
        }

        void DwRunningSheetHeader_RetrieveEnd(object sender, System.EventArgs e)
        {
            table = new NZPostOffice.RDS.DataControls.Report.RunningSheetHeaderDataSet(this.bindingSource.DataSource);
            this.reRunningSheetHeader.SetDataSource(table);

            viewer.RefreshReport();
        }

        #endregion

        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.REDwRunningSheetHeader reRunningSheetHeader;
    }
}
