using NZPostOffice.RDS.DataControls.Report;
namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
    partial class DWhatifCalculatorReport2005
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
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.report = new NZPostOffice.RDS.DataControls.Report.REDWhatifCalculatorReport2005();
            //this.report.RefreshReport += new System.EventHandler(report_RefreshReport);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin2.WhatifCalculatorReport2005);

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
            this.viewer.Size = new System.Drawing.Size(638, 252);
            this.viewer.TabIndex = 0;

            // 
            // DWhatifCalculatorReport2005
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DWhatifCalculatorReport2005";
            this.Size = new System.Drawing.Size(638, 252);

            System.Data.DataTable table = new WhatifCalculatorReport2005DataSet(this.bindingSource.DataSource);
            //this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            report.SetDataSource(table);

            //this.RetrieveEnd += new System.EventHandler(DWhatifCalculatorReport2005_RetrieveEnd);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        //void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        //{
        //    System.Data.DataTable table = new WhatifCalculatorReport2005DataSet(this.bindingSource.DataSource);
        //    report.SetDataSource(table);
        //    viewer.RefreshReport();
        //}

        //void DWhatifCalculatorReport2005_RetrieveEnd(object sender, System.EventArgs e)
        //{
        //    System.Data.DataTable table = new WhatifCalculatorReport2005DataSet(this.bindingSource.DataSource);
        //    report.SetDataSource(table);
        //    viewer.RefreshReport();
        //}

        //void report_RefreshReport(object sender, System.EventArgs e)
        //{
        //    //report.SetParameterValue("user_name", userName);
        //    //report.SetParameterValue("check_number", checkNumber);
        //}

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;

        private NZPostOffice.RDS.DataControls.Report.REDWhatifCalculatorReport2005 report;

        public CrystalDecisions.CrystalReports.Engine.ReportClass Report
        {
            get
            {
                return this.report;
            }
        }
    }
}
