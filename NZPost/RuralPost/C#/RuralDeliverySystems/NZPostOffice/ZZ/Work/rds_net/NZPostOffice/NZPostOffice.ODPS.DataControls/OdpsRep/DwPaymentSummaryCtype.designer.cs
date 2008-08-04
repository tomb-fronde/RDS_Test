using NZPostOffice.ODPS.DataControls.Report;
using System.Data;
using System;
namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwPaymentSummaryCtype
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
            this.rePaymentSummaryCtype = new REDwPaymentSummaryCtype();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.PaymentSummaryCtype);
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
            this.viewer.ReportSource = this.rePaymentSummaryCtype;
            this.viewer.Size = new System.Drawing.Size(671, 300);
            this.viewer.TabIndex = 0;
            this.Controls.Add(this.viewer);
            
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.rePaymentSummaryCtype.RefreshReport += new System.EventHandler(rePaymentSummaryCtype_RefreshReport);
            this.table = new PaymentSummaryCtypeDataSet(this.bindingSource.DataSource);
            this.rePaymentSummaryCtype.SetDataSource(table);
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.RetrieveEnd += new System.EventHandler(DwPaymentSummaryCtype_RetrieveEnd);
            this.ResumeLayout(false); 
        }
        private void rePaymentSummaryCtype_RefreshReport(object sender, EventArgs e)
        {
            this.rePaymentSummaryCtype.SetParameterValue("sdate", ui_sdate);
            this.rePaymentSummaryCtype.SetParameterValue("edate", ui_edate);
            this.rePaymentSummaryCtype.SetParameterValue("inregion", ui_inregion);
            this.rePaymentSummaryCtype.SetParameterValue("inctype", ui_inctype);
        }
        private void DwPaymentSummaryCtype_RetrieveEnd(object sender, EventArgs e)
        {
            SortOnce<NZPostOffice.ODPS.Entity.OdpsRep.PaymentSummaryCtype>
                (new Comparison<NZPostOffice.ODPS.Entity.OdpsRep.PaymentSummaryCtype>(this.PaymentSummaryCtypeSorter));

            this.table = new PaymentSummaryCtypeDataSet(this.bindingSource.DataSource);
            this.rePaymentSummaryCtype.SetDataSource(table);
        }
        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private REDwPaymentSummaryCtype rePaymentSummaryCtype;
        private DataTable table;
    }
}
