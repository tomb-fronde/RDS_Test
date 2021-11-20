using System;
namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwIr66n
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
            this.reDwIr66n = new  NZPostOffice.ODPS.DataControls.Report.REDwIr66n();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.Ir66n);

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
            this.viewer.ReportSource = this.reDwIr66n;
            // 
            // 
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DwIr66n";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.reDwIr66n.RefreshReport += new EventHandler(reDwIr66n_RefreshReport);

            table = new  NZPostOffice.ODPS.DataControls.Report.Ir66nDataSet(this.bindingSource.DataSource);
            this.reDwIr66n.SetDataSource(table);
            
            this.RetrieveEnd += new System.EventHandler(DwIr66n_RetrieveEnd);
            this.ResumeLayout(false);
        }

        void reDwIr66n_RefreshReport(object sender, EventArgs e)
        {
            
            this.reDwIr66n.SetParameterValue(1, this.edate.GetValueOrDefault());
        }

        void DwIr66n_RetrieveEnd(object sender, System.EventArgs e)
        {
            table = new  NZPostOffice.ODPS.DataControls.Report.Ir66nDataSet(this.bindingSource.DataSource);
            this.reDwIr66n.SetDataSource(table);
            viewer.RefreshReport();
        }
        #endregion

        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.ODPS.DataControls.Report.REDwIr66n reDwIr66n;
        private DateTime? edate;
    }
}
