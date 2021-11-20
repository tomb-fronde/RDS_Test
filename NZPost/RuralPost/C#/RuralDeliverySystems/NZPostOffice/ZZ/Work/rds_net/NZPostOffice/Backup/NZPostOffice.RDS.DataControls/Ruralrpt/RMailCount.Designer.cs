using System.Data;
using NZPostOffice.RDS.DataControls.Report;
using System;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class RMailCount
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
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.report = new NZPostOffice.RDS.DataControls.Report.RERMailCount();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.MailCount);

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
            // RMailCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "RMailCount";
            this.Size = new System.Drawing.Size(562, 365);// (638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

            this.report.RefreshReport += new System.EventHandler(report_RefreshReport);
            DataTable table = new MailCountDataSet(this.bindingSource.DataSource);
            this.report.SetDataSource(table);
            this.RetrieveEnd += new System.EventHandler(RMailCount_RetrieveEnd);
        }

        private void report_RefreshReport(object sender, System.EventArgs e)
        {
            this.report.SetParameterValue("contract", ai_contract);
        }

        private void RMailCount_RetrieveEnd(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new MailCountDataSet(this.bindingSource.DataSource);
                MultiTable.Merge(table);
                this.report.SetDataSource(MultiTable);
                this.viewer.RefreshReport();
            }
            catch
            { }
        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;

        private NZPostOffice.RDS.DataControls.Report.RERMailCount report;

        private DataTable MultiTable = new DataTable();
    }
}
