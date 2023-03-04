using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Report;
using System.Data;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class RMailCarriedSingleContract
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
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.report = new NZPostOffice.RDS.DataControls.Report.RERMailCarriedSingleContract();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.MailCarriedSingleContract);

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

            // 
            // RMailCarriedSingleContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.viewer);
            this.Name = "RMailCarriedSingleContract";
            this.Size = new System.Drawing.Size(562, 365);// (650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

            this.report.RefreshReport += new System.EventHandler(report_RefreshReport);
            DataTable table = new MailCarriedSingleContractDataSet(this.bindingSource.DataSource);
            this.report.SetDataSource(table);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.RetrieveEnd += new EventHandler(RMailCarriedSingleContract_RetrieveEnd);
        }

        void RMailCarriedSingleContract_RetrieveEnd(object sender, EventArgs e)
        {
            DataTable table = new MailCarriedSingleContractDataSet(this.bindingSource.DataSource);
            ds.Merge(table);

            this.report.SetDataSource(ds);
            this.report.GroupHeaderSection3.SectionFormat.EnableSuppress = false;
            this.viewer.RefreshReport();
        }

        private void report_RefreshReport(object sender, System.EventArgs e)
        {
            this.report.SetParameterValue("inContract", ai_inContract);
            this.report.SetParameterValue("inSequence", ai_inSequence);
        }

        private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                if (this.RowCount == 0)
                    this.report.GroupHeaderSection3.SectionFormat.EnableSuppress = true;// Height = 739;
                //this.report.SetDataSource(table);
                //this.viewer.RefreshReport();
            }
            catch (Exception ex)
            { }
        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private DataTable ds = new DataTable();
        private NZPostOffice.RDS.DataControls.Report.RERMailCarriedSingleContract report;
    }
}
