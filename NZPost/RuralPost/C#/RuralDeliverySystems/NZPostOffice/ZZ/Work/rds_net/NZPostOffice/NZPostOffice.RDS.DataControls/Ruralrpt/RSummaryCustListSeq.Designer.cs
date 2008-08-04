namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class RSummaryCustListSeq
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
            this.reRSummaryCustListSeq = new NZPostOffice.RDS.DataControls.Report.RERSummaryCustListSeq();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.SummaryCustListSeq);


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
            this.viewer.ReportSource = this.reRSummaryCustListSeq;

            // 
            // DwRunningSheetHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "RSummaryCustListSeq";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            table = new NZPostOffice.RDS.DataControls.Report.SummaryCustListSeqDataSet(this.bindingSource.DataSource);
            this.reRSummaryCustListSeq.SetDataSource(table);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.ResumeLayout(false);

        }

        private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lock (reRSummaryCustListSeq)
                {
                    table = new NZPostOffice.RDS.DataControls.Report.SummaryCustListSeqDataSet(this.bindingSource.DataSource);
                    this.reRSummaryCustListSeq.SetDataSource(table);
                    viewer.RefreshReport();
                }
            }
            catch
            { }

        }
        #endregion

        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.RERSummaryCustListSeq reRSummaryCustListSeq;
    }
}
