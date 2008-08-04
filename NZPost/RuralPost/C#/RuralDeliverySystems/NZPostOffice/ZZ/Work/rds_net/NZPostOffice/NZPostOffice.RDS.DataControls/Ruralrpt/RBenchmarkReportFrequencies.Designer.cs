using System.Data;
namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class RBenchmarkReportFrequencies
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.RERBenchmarkReportFrequencies report;

	
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
            this.report = new NZPostOffice.RDS.DataControls.Report.RERBenchmarkReportFrequencies();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.BenchmarkReportFrequencies);
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
            // RBenchmarkReportFrequencies
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewer);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
            this.Name = "RBenchmarkReportFrequencies";
            this.report.RefreshReport += new System.EventHandler(report_RefreshReport);
            DataTable table = new NZPostOffice.RDS.DataControls.Report.BenchmarkReportFrequenciesDataSet(this.bindingSource.DataSource);
            this.report.SetDataSource(table);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
		}
		#endregion

        private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                DataTable table = new NZPostOffice.RDS.DataControls.Report.BenchmarkReportFrequenciesDataSet(this.bindingSource.DataSource);
                this.report.SetDataSource(table);
                this.viewer.RefreshReport();
            }
            catch
            { }
        }

        private void report_RefreshReport(object sender, System.EventArgs e)
        {
            this.report.SetParameterValue("contract_no", ai_contractNo);
        }

	}
}
