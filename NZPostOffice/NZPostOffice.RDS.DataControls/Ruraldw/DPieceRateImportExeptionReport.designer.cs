using NZPostOffice.RDS.DataControls.Report;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DPieceRateImportExeptionReport
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
            this.report = new NZPostOffice.RDS.DataControls.Report.REDPieceRateImportExeptionReport();
            this.report.RefreshReport += new System.EventHandler(report_RefreshReport);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.PieceRateImportExeptionReport);
            //p! commented out extremely slow when retreiving many rows
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
            // DPieceRateImportExeptionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DPieceRateImportExeptionReport";
            this.Size = new System.Drawing.Size(638, 252);
            this.Load += new System.EventHandler(DPieceRateImportExeptionReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

		}

        void report_RefreshReport(object sender, System.EventArgs e)
        {
            //report.SetParameterValue("user_name", userName);
            //report.SetParameterValue("check_number", checkNumber);
        }

        int count = 0;
        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                count++;//! debugging variable
                System.Data.DataTable table = new PieceRateImportExeptionReportDataSet(this.bindingSource.DataSource);
                report.SetDataSource(table);
                viewer.RefreshReport();
            }
            catch
            { }
        }

        void DPieceRateImportExeptionReport_Load(object sender, System.EventArgs e)
        {
            System.Data.DataTable table = new PieceRateImportExeptionReportDataSet(this.bindingSource.DataSource);
            report.SetDataSource(table);
            viewer.RefreshReport();
        }

		#endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;

        private NZPostOffice.RDS.DataControls.Report.REDPieceRateImportExeptionReport report;
	}
}
