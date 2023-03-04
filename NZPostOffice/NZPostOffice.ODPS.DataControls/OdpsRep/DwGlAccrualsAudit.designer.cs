using NZPostOffice.ODPS.DataControls.Report;
using System.Data;
using System;
namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwGlAccrualsAudit
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
            this.reGlAccrualsAudit = new REDwGlAccrualsAudit();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.GlAccrualsAudit);
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
            this.viewer.ReportSource = this.reGlAccrualsAudit;
            this.viewer.Size = new System.Drawing.Size(671, 300);
            this.viewer.TabIndex = 0;
            this.Controls.Add(this.viewer);
            
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.reGlAccrualsAudit.RefreshReport += new System.EventHandler(reGlAccrualsAudit_RefreshReport);
            this.table = new GlAccrualsAuditDataSet(this.bindingSource.DataSource);
            this.reGlAccrualsAudit.SetDataSource(table);
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.ResumeLayout(false);
        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private REDwGlAccrualsAudit reGlAccrualsAudit;
        private DataTable table;
    }
}
