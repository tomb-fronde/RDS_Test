using NZPostOffice.RDS.DataControls.Report;
using System.Data;
using System;
namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class DOutValList
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
			
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
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
            this.reDOutValList = new REDOutValList();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.OutValList);
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
            this.viewer.ReportSource = this.reDOutValList;
            this.viewer.Size = new System.Drawing.Size(671, 300);
            this.viewer.TabIndex = 0;
            this.Controls.Add(this.viewer);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.Color.White;
            table = new OutValListDataSet(this.bindingSource.DataSource);
            reDOutValList.SetDataSource(table);
            this.RetrieveEnd += new System.EventHandler(DOutValList_RetrieveEnd);
            this.ResumeLayout(false);
		}

        void DOutValList_RetrieveEnd(object sender, EventArgs e)
        {
            table = new OutValListDataSet(this.bindingSource.DataSource);
            reDOutValList.SetDataSource(table);
            viewer.RefreshReport();
        }

		#endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private REDOutValList reDOutValList;
        private DataTable table;
	}
}
