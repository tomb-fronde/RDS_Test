using System.Data;
using NZPostOffice.RDS.DataControls.Report;
using NZPostOffice.Shared;
namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class RDetailedCustomerListing
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
            this.report = new NZPostOffice.RDS.DataControls.Report.RERDetailedCustomerListing();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.DetailedCustomerListing);
            // 
            // viewer
            // 
            this.viewer.ActiveViewIndex = 0;
            this.viewer.DisplayGroupTree = false;
            this.viewer.DisplayStatusBar = false;
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer.DisplayGroupTree = false;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.ReportSource = this.report;
            this.viewer.Size = new System.Drawing.Size(638, 252);
            this.viewer.TabIndex = 0;
            this.report.RefreshReport += new System.EventHandler(report_RefreshReport);
            // 
            // RDetailedCustomerListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "RDetailedCustomerListing";
            this.Size = new System.Drawing.Size(738, 252);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RetrieveEnd += new System.EventHandler(RDetailedCustomerListing_RetrieveEnd);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

            DataTable table = new DetailedCustomerListingDataSet(this.bindingSource.DataSource);
            this.report.SetDataSource(table);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
        }

        void report_RefreshReport(object sender, System.EventArgs e)
        {
            this.report.SetParameterValue("stparms", StaticVariables.gnv_app.of_get_parameters().miscstringparm );
        }

        void RDetailedCustomerListing_RetrieveEnd(object sender, System.EventArgs e)
        {
            DataTable table = new DetailedCustomerListingDataSet(this.bindingSource.DataSource);
            this.report.SetDataSource(table);
            this.viewer.RefreshReport();
        }

        private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                
            }
            catch
            { }
        }

		#endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.RERDetailedCustomerListing report;
	}
}