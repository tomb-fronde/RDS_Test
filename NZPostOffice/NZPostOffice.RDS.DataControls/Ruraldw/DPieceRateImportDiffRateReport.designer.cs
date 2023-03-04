using NZPostOffice.RDS.DataControls.Report;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DPieceRateImportDiffRateReport
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
        }

		#region Component Designer generated code

		private void InitializeComponent()
		{
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.report = new NZPostOffice.RDS.DataControls.Report.REDPieceRateImportDiffRateReport();
            this.report.RefreshReport += new System.EventHandler(report_RefreshReport);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.PieceRateImportDiffRateReport);

            //pp! too slow - better call DPieceRateImportDiffRateReport_Load from Print and print the report after
            //!this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            // 
            // viewer
            // 
            this.viewer.ActiveViewIndex = 0;
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer.DisplayGroupTree = false;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.ReportSource = this.report;
            this.viewer.Size = new System.Drawing.Size(638, 252);
            this.viewer.TabIndex = 0;
            // 
            // DPieceRateImportDiffRateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DPieceRateImportDiffRateReport";
            this.Size = new System.Drawing.Size(638, 252);
            this.Load += new System.EventHandler(DPieceRateImportDiffRateReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

		}

        void report_RefreshReport(object sender, System.EventArgs e)
        {
            //report.SetParameterValue("user_name", userName);
            //report.SetParameterValue("check_number", checkNumber);
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                System.Data.DataTable table = new PieceRateImportDiffRateReportDataSet(this.bindingSource.DataSource);
                report.SetDataSource(table);
                viewer.RefreshReport();
            }
            catch
            { }
        }

        void DPieceRateImportDiffRateReport_Load(object sender, System.EventArgs e)
        {
            System.Data.DataTable table = new PieceRateImportDiffRateReportDataSet(this.bindingSource.DataSource);
            report.SetDataSource(table);
            viewer.RefreshReport();
        }

		#endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;

        private NZPostOffice.RDS.DataControls.Report.REDPieceRateImportDiffRateReport report;
	}
}
