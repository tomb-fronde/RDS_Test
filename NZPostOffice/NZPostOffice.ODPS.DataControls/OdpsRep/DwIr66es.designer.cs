using System.Data;
using System;
namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwIr66es
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
            this.reDwIr66es = new  NZPostOffice.ODPS.DataControls.Report.REDwIr66es();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.Ir66es);

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
            this.viewer.ReportSource = this.reDwIr66es;
            // 
            // DwIr66es
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DwIr66es";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();

            this.reDwIr66es.RefreshReport += new System.EventHandler(reDwIr66es_RefreshReport);
            table = new  NZPostOffice.ODPS.DataControls.Report.Ir66esDataSet(this.bindingSource.DataSource);
            this.reDwIr66es.SetDataSource(table);
            
            DataTable table2 = new  NZPostOffice.ODPS.DataControls.Report.PostIrdNoDataSet(new  NZPostOffice.ODPS.DataControls.Report.RPostIrdNo());
            this.reDwIr66es.Subreports["REDwPostIrdNo.rpt"].SetDataSource(table2);

            this.RetrieveEnd += new System.EventHandler(DwIr66es_RetrieveEnd);
            this.ResumeLayout(false);
        }

        void reDwIr66es_RefreshReport(object sender, System.EventArgs e)
        {
            this.reDwIr66es.SetParameterValue(0, this.eDate.GetValueOrDefault());
        }

        void DwIr66es_RetrieveEnd(object sender, System.EventArgs e)
        {
            SortOnce<NZPostOffice.ODPS.Entity.OdpsRep.Ir66es>
                (new Comparison<NZPostOffice.ODPS.Entity.OdpsRep.Ir66es>(this.Sorter));

            table = new  NZPostOffice.ODPS.DataControls.Report.Ir66esDataSet(this.bindingSource.DataSource);
            this.reDwIr66es.SetDataSource(table);
            
        }
        #endregion

        private DateTime? eDate;
        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.ODPS.DataControls.Report.REDwIr66es reDwIr66es;
    }
}
