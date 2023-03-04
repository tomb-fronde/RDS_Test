using System.Data;
using NZPostOffice.RDS.DataControls.Report;
namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class RPieceRateReport
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
			components = new System.ComponentModel.Container();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reRPieceRateReport = new NZPostOffice.RDS.DataControls.Report.RERPieceRateReport();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.PieceRateReport);
            // 
            // viewer
            // 
            this.viewer.ActiveViewIndex = 0;
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer.DisplayGroupTree = false;
            this.viewer.DisplayStatusBar = false;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.ReportSource = this.reRPieceRateReport;
            this.viewer.Size = new System.Drawing.Size(638, 252);
            this.viewer.TabIndex = 0;
            this.Controls.Add(viewer);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.Color.White;
            this.ResumeLayout(false); 
            this.reRPieceRateReport.RefreshReport += new System.EventHandler(reRPieceRateReport_RefreshReport);
            table = new PieceRateReportDataSet(this.bindingSource.DataSource);
            this.reRPieceRateReport.SetDataSource(table);
            this.RetrieveEnd += new System.EventHandler(RPieceRateReport_RetrieveEnd);
		}

        private void reRPieceRateReport_RefreshReport(object sender, System.EventArgs e)
        {
            this.reRPieceRateReport.SetParameterValue("stparms", NZPostOffice.Shared.StaticVariables.gnv_app.of_get_parameters().miscstringparm);
            this.reRPieceRateReport.SetParameterValue("lContract", u_lContract);
            this.reRPieceRateReport.SetParameterValue("lRegion", u_lRegion);
            this.reRPieceRateReport.SetParameterValue("lOutlet", u_lOutlet);
            this.reRPieceRateReport.SetParameterValue("dPrMonth", u_dPrMonth);
        }

        private void RPieceRateReport_RetrieveEnd(object sender, System.EventArgs e)
        {
            try
            {
                table = new PieceRateReportDataSet(this.bindingSource.DataSource);
                muliTable.Merge(table);
                this.reRPieceRateReport.SetDataSource(muliTable);
                this.viewer.RefreshReport();
            }
            catch(System.Exception error)
            { }
        }

		#endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.RERPieceRateReport reRPieceRateReport;
        private DataTable table;
        private DataTable muliTable = new DataTable();
	}
}
