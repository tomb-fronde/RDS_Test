using NZPostOffice.ODPS.DataControls.Report;
using System;
using System.Data;
namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwVolumesValueDetail
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
            this.reVolumesValueDetail = new REDwVolumesValueDetail();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.VolumesValueDetail);
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
            this.viewer.ReportSource = this.reVolumesValueDetail;
            this.viewer.Size = new System.Drawing.Size(671, 300);
            this.viewer.TabIndex = 0;
            this.Controls.Add(this.viewer);
            

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.reVolumesValueDetail.RefreshReport += new System.EventHandler(reVolumesValueDetail_RefreshReport);
            this.table = new VolumesValueDetailDataSet(this.bindingSource.DataSource);
            this.reVolumesValueDetail.SetDataSource(table);
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.RetrieveEnd += new System.EventHandler(DwVolumesValueDetail_RetrieveEnd);
            this.ResumeLayout(false); 
        }
        private void DwVolumesValueDetail_RetrieveEnd(object sender, EventArgs e)
        {
            SortOnce<NZPostOffice.ODPS.Entity.OdpsRep.VolumesValueDetail>
                (new Comparison<NZPostOffice.ODPS.Entity.OdpsRep.VolumesValueDetail>(this.VolumesValueDetailSorter));
            this.table = new VolumesValueDetailDataSet(this.bindingSource.DataSource);
            this.reVolumesValueDetail.SetDataSource(table);
        }

        private void reVolumesValueDetail_RefreshReport(object sender, System.EventArgs e)
        {
            this.reVolumesValueDetail.SetParameterValue("sdate", ui_sdate);
            this.reVolumesValueDetail.SetParameterValue("edate", ui_edate);
            this.reVolumesValueDetail.SetParameterValue("inregion", ui_inregion);
        }
        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private REDwVolumesValueDetail reVolumesValueDetail;
        private DataTable table;
    }
}
