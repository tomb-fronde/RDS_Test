using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;
using System.Data;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class RContractorLabelFast
	{

		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.RERContractorLabelFast report;
	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
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
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.report = new NZPostOffice.RDS.DataControls.Report.RERContractorLabelFast();
			this.Name = "RContractorLabelFast";

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.ContractorLabelFast);
            // 
            // viewer
            // 
            this.viewer.ActiveViewIndex = 0;
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer.DisplayGroupTree = false;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.ReportSource = this.report;
            this.viewer.Size = new System.Drawing.Size(638, 252);
            this.viewer.TabIndex = 0;
            //
            // RContractorLabelFast
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewer);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.report.RefreshReport += new System.EventHandler(report_RefreshReport);
            DataTable table = new NZPostOffice.RDS.DataControls.Report.ContractorLabelFastDataSet(this.bindingSource.DataSource);
            this.report.SetDataSource(table);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
		}
		#endregion
        private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                DataTable table = new NZPostOffice.RDS.DataControls.Report.ContractorLabelFastDataSet(this.bindingSource.DataSource);
                this.report.SetDataSource(table);
                this.viewer.RefreshReport();
            }
            catch
            { }
        }

        private void report_RefreshReport(object sender, System.EventArgs e)
        {
            this.report.SetParameterValue("inregion", ai_inregion);
            this.report.SetParameterValue("incontractor", ai_incontractor);
            this.report.SetParameterValue("incontracttype", ai_incontracttype);
            this.report.SetParameterValue("inrengroup", ai_inrengroup);
            this.report.SetParameterValue("inoutlet", ai_inoutlet);
            this.report.SetParameterValue("incontracts", ai_incontracts);
            this.report.SetParameterValue("incontractflag", ai_incontractflag);
        }
	}
}
