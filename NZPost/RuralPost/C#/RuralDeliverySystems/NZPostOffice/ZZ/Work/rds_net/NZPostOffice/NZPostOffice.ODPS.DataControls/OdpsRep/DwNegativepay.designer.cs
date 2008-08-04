using NZPostOffice.ODPS.DataControls.Report;
using System.Data;
using System;
namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwNegativepay
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
            this.reNegativepay = new REDwNegativepay();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.Negativepay);
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
            this.viewer.ReportSource = this.reNegativepay;
            this.viewer.Size = new System.Drawing.Size(671, 300);
            this.viewer.TabIndex = 0;
            this.Controls.Add(this.viewer);            

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.reNegativepay.RefreshReport += new EventHandler(reNegativepay_RefreshReport);
            this.table = new NegativepayDataSet(this.bindingSource.DataSource);
            this.reNegativepay.SetDataSource(table);
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.RetrieveEnd += new EventHandler(DwNegativepay_RetrieveEnd);
            this.ResumeLayout(false); 
        }
        private void DwNegativepay_RetrieveEnd(object sender, EventArgs e)
        {
            this.table = new NegativepayDataSet(this.bindingSource.DataSource);
            this.reNegativepay.SetDataSource(table);
        }

        private void reNegativepay_RefreshReport(object sender, System.EventArgs e)
        {
            this.reNegativepay.SetParameterValue("sdate", ui_sdate);
            this.reNegativepay.SetParameterValue("edate", ui_edate);
        }
        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private REDwNegativepay reNegativepay;
        private DataTable table;
    }
}
