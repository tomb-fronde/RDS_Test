using System;
using NZPostOffice.RDS.DataControls.Report;
using System.Data;
namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class RRouteDescriptionSingleContract
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
            this.reRRouteDescriptionSingleContract = new RERRouteDescriptionSingleContract();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.RouteDescriptionSingleContract);

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
            this.viewer.ReportSource = this.reRRouteDescriptionSingleContract;
            this.viewer.Size = new System.Drawing.Size(671, 300);
            this.viewer.TabIndex = 0;

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(562, 365);// (638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            table = new RouteDescriptionSingleContractDataSet(this.bindingSource.DataSource);
            reRRouteDescriptionSingleContract.SetDataSource(table);
            this.RetrieveEnd += new System.EventHandler(RRouteDescriptionSingleContract_RetrieveEnd);
            this.ResumeLayout(false);
        }
        void RRouteDescriptionSingleContract_RetrieveEnd(object sender, EventArgs e)
        {
            table = new RouteDescriptionSingleContractDataSet(this.bindingSource.DataSource);

            ds.Merge(table);
            reRRouteDescriptionSingleContract.SetDataSource(ds);
            viewer.RefreshReport();
        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private RERRouteDescriptionSingleContract reRRouteDescriptionSingleContract;
        private DataTable table;
        private DataTable ds = new DataTable();
    }
}
