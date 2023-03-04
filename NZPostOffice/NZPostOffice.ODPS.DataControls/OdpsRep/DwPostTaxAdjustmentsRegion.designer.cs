using NZPostOffice.ODPS.DataControls.Report;
using System.Data;
using System;
namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwPostTaxAdjustmentsRegion
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
            this.rePostTaxAdjustmentsRegion = new REDwPostTaxAdjustmentsRegion();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.PostTaxAdjustmentsRegion);
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
            this.viewer.ReportSource = this.rePostTaxAdjustmentsRegion;
            this.viewer.Size = new System.Drawing.Size(671, 300);
            this.viewer.TabIndex = 0;
            this.Controls.Add(this.viewer);
            
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.rePostTaxAdjustmentsRegion.RefreshReport += new System.EventHandler(rePostTaxAdjustmentsRegion_RefreshReport);
            this.table = new PostTaxAdjustmentsRegionDataSet(this.bindingSource.DataSource);
            this.rePostTaxAdjustmentsRegion.SetDataSource(table);
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.RetrieveEnd += new System.EventHandler(DwPostTaxAdjustmentsRegion_RetrieveEnd);
            this.ResumeLayout(false); 
        }

        private void DwPostTaxAdjustmentsRegion_RetrieveEnd(object sender, EventArgs e)
        {
            SortOnce<NZPostOffice.ODPS.Entity.OdpsRep.PostTaxAdjustmentsRegion>
                (new Comparison<NZPostOffice.ODPS.Entity.OdpsRep.PostTaxAdjustmentsRegion>(this.PostTaxAdjustmentsRegionSorter));
            this.table = new PostTaxAdjustmentsRegionDataSet(this.bindingSource.DataSource);
            this.rePostTaxAdjustmentsRegion.SetDataSource(table);
        }

        private void rePostTaxAdjustmentsRegion_RefreshReport(object sender, System.EventArgs e)
        {
            this.rePostTaxAdjustmentsRegion.SetParameterValue("sdate", ui_sdate);
            this.rePostTaxAdjustmentsRegion.SetParameterValue("edate", ui_edate);
            this.rePostTaxAdjustmentsRegion.SetParameterValue("inregion", ui_inregion);
        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private REDwPostTaxAdjustmentsRegion rePostTaxAdjustmentsRegion;
        private DataTable table;
    }
}
