using NZPostOffice.ODPS.DataControls.Report;
using System.Data;
using System;
namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwVolumesValueSummary
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
            this.reVolumesValueSummary = new REDwVolumesValueSummary();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.VolumesValueSummary);
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
            this.viewer.ReportSource = this.reVolumesValueSummary;
            this.viewer.Size = new System.Drawing.Size(671, 300);
            this.viewer.TabIndex = 0;
            this.Controls.Add(this.viewer);
            
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.reVolumesValueSummary.RefreshReport += new System.EventHandler(reVolumesValueSummary_RefreshReport);
            this.table = new VolumesValueSummaryDataSet(this.bindingSource.DataSource);
            this.reVolumesValueSummary.SetDataSource(table);
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.RetrieveEnd += new System.EventHandler(DwVolumesValueSummary_RetrieveEnd);
            this.ResumeLayout(false);
        }
        private void DwVolumesValueSummary_RetrieveEnd(object sender, EventArgs e)
        {
            SortOnce<NZPostOffice.ODPS.Entity.OdpsRep.VolumesValueSummary>
                (new Comparison<NZPostOffice.ODPS.Entity.OdpsRep.VolumesValueSummary>(this.VolumesValueSummarySorter));
            this.table = new VolumesValueSummaryDataSet(this.bindingSource.DataSource);
            this.reVolumesValueSummary.SetDataSource(table);
        }

        private void reVolumesValueSummary_RefreshReport(object sender, System.EventArgs e)
        {
            this.reVolumesValueSummary.SetParameterValue("sdate", ui_sdate);
            this.reVolumesValueSummary.SetParameterValue("edate", ui_edate);
            this.reVolumesValueSummary.SetParameterValue("inregion", ui_inregion);
        }
        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private REDwVolumesValueSummary reVolumesValueSummary;
        private DataTable table;
    }
}
