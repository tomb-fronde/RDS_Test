using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class RSummaryCustListCust
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
            components = new System.ComponentModel.Container();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reRSummaryCustListCust = new NZPostOffice.RDS.DataControls.Report.RERSummaryCustListCust();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.SummaryCustListCust);

            // 
            // viewer
            // 
            this.viewer.ActiveViewIndex = 0;
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.DisplayGroupTree = false;
            this.viewer.DisplayStatusBar = false;
            this.viewer.Size = new System.Drawing.Size(638, 252);
            this.viewer.TabIndex = 0;
            this.viewer.ReportSource = this.reRSummaryCustListCust;

            // 
            // DwRunningSheetHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "RSummaryCustListCust";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            table = new NZPostOffice.RDS.DataControls.Report.SummaryCustListCustDataSet(this.bindingSource.DataSource);
            this.reRSummaryCustListCust.SetDataSource(table);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.ResumeLayout(false);

        }

        private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lock (reRSummaryCustListCust)
                {
                    table = new NZPostOffice.RDS.DataControls.Report.SummaryCustListCustDataSet(this.bindingSource.DataSource);
                    this.reRSummaryCustListCust.SetDataSource(table);
                    viewer.RefreshReport();
                }
            }
            catch
            { }

        }
        #endregion

        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.RERSummaryCustListCust reRSummaryCustListCust;
    }
}
