using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;
using System.Data;
using NZPostOffice.RDS.DataControls.Report;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class RDeedCompliance
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
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.report = new NZPostOffice.RDS.DataControls.Report.RERDeedCompliance();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.DeedCompliance);
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
            this.viewer.ReportSource = this.report;
            this.viewer.Size = new System.Drawing.Size(650, 300);
            this.viewer.TabIndex = 0;
            this.viewer.EnableDrillDown = false;
            // 
            // RDeedCompliance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.viewer);
            this.Name = "RDeedCompliance";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

            DataTable table = new DeedComplianceDataSet(this.bindingSource.DataSource);
            this.report.SetDataSource(table);

            DataTable custDT = new DeedCompRegCustDataSet(new DeedCompRegCust());
            this.report.Subreports["REDDeedCompRegCust.rpt"].SetDataSource(custDT);

            DataTable addrDT = new DeedCompRegAddrDataSet(new DeedCompRegAddr());
            this.report.Subreports["REDDeedCompRegAddr.rpt"].SetDataSource(addrDT);

            DataTable occupiedDT = new DeedCompRegOccupiedDataSet(new DeedCompRegOccupied());
            this.report.Subreports["REDDeedCompRegOccupied.rpt"].SetDataSource(occupiedDT);

            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.RetrieveEnd += new EventHandler(RDeedCompliance_RetrieveEnd);
        }

        void RDeedCompliance_RetrieveEnd(object sender, EventArgs e)
        {
            DataTable table = new DeedComplianceDataSet(this.bindingSource.DataSource);
                this.report.SetDataSource(table);
        }

        private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
        }

		#endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;

        private NZPostOffice.RDS.DataControls.Report.RERDeedCompliance report;
	}
}
