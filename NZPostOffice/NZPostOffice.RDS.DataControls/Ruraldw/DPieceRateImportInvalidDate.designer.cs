using NZPostOffice.RDS.DataControls.Report;
using System;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DPieceRateImportInvalidDate
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
            this.report = new NZPostOffice.RDS.DataControls.Report.REDPieceRateImportInvalidDate();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.PieceRateImportInvalidDate);
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
            // DPieceRateImportInvalidDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DPieceRateImportInvalidDate";
            this.Size = new System.Drawing.Size(638, 252);
            this.RetrieveEnd += new System.EventHandler(DPieceRateImportInvalidDate_RetrieveEnd);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

		}

        void DPieceRateImportInvalidDate_RetrieveEnd(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable table = new PieceRateImportInvalidDateDataSet(this.bindingSource.DataSource);
                report.SetDataSource(table);
                viewer.RefreshReport();
            }
            catch
            { }
        }

		#endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;

        private NZPostOffice.RDS.DataControls.Report.REDPieceRateImportInvalidDate report;
	}
}
