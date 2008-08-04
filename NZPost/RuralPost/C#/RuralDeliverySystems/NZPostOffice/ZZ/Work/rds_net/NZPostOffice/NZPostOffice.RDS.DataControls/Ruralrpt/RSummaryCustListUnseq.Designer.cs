namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class RSummaryCustListUnseq
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
            this.reRSummaryCustListUnseq = new NZPostOffice.RDS.DataControls.Report.RERSummaryCustListUnseq();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.SummaryCustListUnseq);

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
            this.viewer.ReportSource = this.reRSummaryCustListUnseq;

            // 
            // DwRunningSheetHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "RSummaryCustListUnseq";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            table = new NZPostOffice.RDS.DataControls.Report.SummaryCustListUnseqDataSet(this.bindingSource.DataSource);
            this.reRSummaryCustListUnseq.SetDataSource(table);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.ResumeLayout(false);

        }

        private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lock (reRSummaryCustListUnseq)
                {
                    table = new NZPostOffice.RDS.DataControls.Report.SummaryCustListUnseqDataSet(this.bindingSource.DataSource);
                    this.reRSummaryCustListUnseq.SetDataSource(table);
                    viewer.RefreshReport();
                }
            }
            catch
            { }

        }
        #endregion

        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.RERSummaryCustListUnseq reRSummaryCustListUnseq;
    }
}
