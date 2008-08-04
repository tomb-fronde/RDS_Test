using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;
using System.Data;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class RBenchmarkReport2006
	{

		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.RERBenchmarkReport2006 report;
	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
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
            this.report = new NZPostOffice.RDS.DataControls.Report.RERBenchmarkReport2006();
			this.Name = "RBenchmarkReport2006";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.BenchmarkReport2006);
            // 
            // viewer
            // 
            this.viewer.ActiveViewIndex = 0;
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer.DisplayGroupTree = false;
            this.viewer.DisplayStatusBar = false;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.ReportSource = this.report;
            this.viewer.Name = "viewer";
            
            this.viewer.Size = new System.Drawing.Size(638, 252);
            this.viewer.TabIndex = 0;
            //
            // RBenchmarkReport2006
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewer);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.ResumeLayout(false);

            this.report.RefreshReport += new System.EventHandler(report_RefreshReport);
            DataTable table = new NZPostOffice.RDS.DataControls.Report.BenchmarkReport2006DataSet(this.bindingSource.DataSource);
            this.report.SetDataSource(table);

            DataTable table2 = new NZPostOffice.RDS.DataControls.Report.BenchmarkReportFrequenciesDataSet(new BenchmarkReportFrequencies());
            this.report.Subreports["RERBenchmarkReportFrequencies.rpt"].SetDataSource(table2);
		}
		#endregion

        private void report_RefreshReport(object sender, System.EventArgs e)
        {
            this.report.SetParameterValue("inContract", ai_inContract);
            this.report.SetParameterValue("inSequence", ai_inSequence);
        }

        public void Print()
        {
            this.viewer.PrintReport();
        }
	}
}
