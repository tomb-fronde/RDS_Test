using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwYearlyEarnings
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
            this.reDwYearlyEarnings = new  NZPostOffice.ODPS.DataControls.Report.REDwYearlyEarnings();
            this.Name = "DwYearlyEarnings";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.YearlyEarnings);

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
            this.viewer.ReportSource = this.reDwYearlyEarnings;
            // 
            // DwRunningSheetHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();

            this.reDwYearlyEarnings.RefreshReport += new EventHandler(reDwYearlyEarnings_RefreshReport);
            table = new  NZPostOffice.ODPS.DataControls.Report.YearlyEarningsDataSet(this.bindingSource.DataSource);
            this.reDwYearlyEarnings.SetDataSource(table);
            this.RetrieveEnd += new EventHandler(DwYearlyEarnings_RetrieveEnd);
            this.ResumeLayout(false);

        }

        void reDwYearlyEarnings_RefreshReport(object sender, EventArgs e)
        {
            this.reDwYearlyEarnings.SetParameterValue(0, this.eDate.GetValueOrDefault());
        }

        void DwYearlyEarnings_RetrieveEnd(object sender, EventArgs e)
        {
            //SortOnce<YearlyEarnings>(new Comparison<YearlyEarnings>(this.Sorter));

            table = new  NZPostOffice.ODPS.DataControls.Report.YearlyEarningsDataSet(this.bindingSource.DataSource);
            this.reDwYearlyEarnings.SetDataSource(table);
            viewer.RefreshReport();
        }
        #endregion

        private DateTime? eDate;
        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.ODPS.DataControls.Report.REDwYearlyEarnings reDwYearlyEarnings;
    }
}
