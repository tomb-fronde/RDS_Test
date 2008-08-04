namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DWhatifCalculatorReport2001bf5
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
            this.reDWhatifCalculatorReport2001bf5 = new NZPostOffice.RDS.DataControls.Report.REDWhatifCalculatorReport2001bf5();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.WhatifCalculatorReport2001bf5);

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
            this.viewer.ReportSource = this.reDWhatifCalculatorReport2001bf5;

            // 
            // DWhatifCalculatorReport2001bf5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DWhatifCalculatorReport2001bf5";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            table = new NZPostOffice.RDS.DataControls.Report.WhatifCalculatorReport2001bf5DataSet(this.bindingSource.DataSource);
            this.reDWhatifCalculatorReport2001bf5.SetDataSource(table);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.ResumeLayout(false);
        }
        private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lock (reDWhatifCalculatorReport2001bf5)
                {
                    table = new NZPostOffice.RDS.DataControls.Report.WhatifCalculatorReport2001bf5DataSet(this.bindingSource.DataSource);
                    this.reDWhatifCalculatorReport2001bf5.SetDataSource(table);
                    viewer.RefreshReport();
                }
            }
            catch
            { }

        }
        #endregion

        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.REDWhatifCalculatorReport2001bf5 reDWhatifCalculatorReport2001bf5;
    }
}
