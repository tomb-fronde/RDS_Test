using System;
namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
	partial class DwGrosspayvariance
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
            this.reDwGrossPayVariance = new  NZPostOffice.ODPS.DataControls.Report.REDwGrossPayVariance();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.Grosspayvariance);

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
            this.viewer.ReportSource = this.reDwGrossPayVariance;
            // 
            // 
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DwGrosspayvariance";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();

            this.reDwGrossPayVariance.RefreshReport += new System.EventHandler(reDwGrossPayVariance_RefreshReport);
            table = new  NZPostOffice.ODPS.DataControls.Report.GrossPayVarianceDataSet(this.bindingSource.DataSource);
            this.reDwGrossPayVariance.SetDataSource(table);
            this.RetrieveEnd += new System.EventHandler(DwGrosspayvariance_RetrieveEnd);
            this.ResumeLayout(false);

		}

        void reDwGrossPayVariance_RefreshReport(object sender, System.EventArgs e)
        {
            this.reDwGrossPayVariance.SetParameterValue(0, this.eDate.GetValueOrDefault());
        }

        void DwGrosspayvariance_RetrieveEnd(object sender, System.EventArgs e)
        {
            
        }
		#endregion

        private DateTime? eDate;
        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.ODPS.DataControls.Report.REDwGrossPayVariance reDwGrossPayVariance;
	}
}
