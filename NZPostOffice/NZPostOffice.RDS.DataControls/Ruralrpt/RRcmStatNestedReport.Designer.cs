using NZPostOffice.RDS.DataControls.Report;
using System.Data;
using System;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.Shared;
namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class RRcmStatNestedReport
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
            components = new System.ComponentModel.Container();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reRRcmStatNestedReport = new RERRcmStatNestedReport();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.RcmStatNestedReport);

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
            this.viewer.ReportSource = this.reRRcmStatNestedReport;
            this.viewer.Size = new System.Drawing.Size(671, 300);
            this.viewer.TabIndex = 0;
            this.viewer.EnableDrillDown = false;

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.Controls.Add(this.viewer);
            this.reRRcmStatNestedReport.RefreshReport += new EventHandler(reRRcmStatNestedReport_RefreshReport);
            table = new RcmStatNestedReportDataSet(this.bindingSource.DataSource);
            reRRcmStatNestedReport.SetDataSource(table);

            DataTable table2 = new RcmStatisticalReportDataSet(new RcmStatisticalReport());
            this.reRRcmStatNestedReport.Subreports["RERRcmStatisticalReport.rpt"].SetDataSource(table2);

            this.RetrieveEnd += new EventHandler(RRcmStatNestedReport_RetrieveEnd);
            this.ResumeLayout(false);
        }

        void reRRcmStatNestedReport_RefreshReport(object sender, EventArgs e)
        {
            this.reRRcmStatNestedReport.SetParameterValue("stparms", StaticVariables.gnv_app.of_get_parameters().miscstringparm);
        }

        void RRcmStatNestedReport_RetrieveEnd(object sender, EventArgs e)
        {
            this.viewer.RefreshReport();
        }
        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private RERRcmStatNestedReport reRRcmStatNestedReport;
        private DataTable table;
    }
}
