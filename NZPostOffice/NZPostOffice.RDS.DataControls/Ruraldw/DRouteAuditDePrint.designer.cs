namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DRouteAuditDePrint
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
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reDRouteAuditDePrint = new NZPostOffice.RDS.DataControls.Report.REDRouteAuditDePrint();
            components = new System.ComponentModel.Container();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RouteAuditDePrint);

            // 
            // viewer
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
            this.viewer.ReportSource = this.reDRouteAuditDePrint;

            // 
            // DwRunningSheetHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DRouteAuditDePrint";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            table = new NZPostOffice.RDS.DataControls.Report.RouteAuditDePrintDataSet(this.bindingSource.DataSource);
            this.reDRouteAuditDePrint.SetDataSource(table);

            this.RetrieveEnd += new System.EventHandler(DRouteAuditDePrint_RetrieveEnd);
            this.ResumeLayout(false);
        }

        void DRouteAuditDePrint_RetrieveEnd(object sender, System.EventArgs e)
        {
            table = new NZPostOffice.RDS.DataControls.Report.RouteAuditDePrintDataSet(this.bindingSource.DataSource);
            this.reDRouteAuditDePrint.SetDataSource(table);

            viewer.RefreshReport();
        }
        #endregion

        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.REDRouteAuditDePrint reDRouteAuditDePrint;
        public CrystalDecisions.CrystalReports.Engine.ReportClass ReportDocument
        {
            get { return this.reDRouteAuditDePrint; }
        }
    }
}
