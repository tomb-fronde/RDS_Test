using System.Data;
using NZPostOffice.ODPS.DataControls.Report;
using System;
namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwPostTaxAdjustments
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
            this.rePostTaxAdjustments = new REDwPostTaxAdjustments();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.PostTaxAdjustments);
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
            this.viewer.ReportSource = this.rePostTaxAdjustments;
            this.viewer.Size = new System.Drawing.Size(671, 300);
            this.viewer.TabIndex = 0;
            this.Controls.Add(this.viewer);
            
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.rePostTaxAdjustments.RefreshReport += new EventHandler(rePostTaxAdjustments_RefreshReport);
            this.table = new PostTaxAdjustmentsDataSet(this.bindingSource.DataSource);
            this.rePostTaxAdjustments.SetDataSource(table);
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.RetrieveEnd += new System.EventHandler(DwPostTaxAdjustments_RetrieveEnd);
            this.ResumeLayout(false); 
        }
        private void DwPostTaxAdjustments_RetrieveEnd(object sender, EventArgs e)
        {
            this.Sort();
            this.table = new PostTaxAdjustmentsDataSet(this.bindingSource.DataSource);
            this.rePostTaxAdjustments.SetDataSource(table);
        }

        private void rePostTaxAdjustments_RefreshReport(object sender, System.EventArgs e)
        {
            this.rePostTaxAdjustments.SetParameterValue("sdate", ui_sdate);
            this.rePostTaxAdjustments.SetParameterValue("edate", ui_edate);
        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private REDwPostTaxAdjustments rePostTaxAdjustments;
        private DataTable table;
    }
}
