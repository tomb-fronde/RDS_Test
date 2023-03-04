using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;
using System.Data;
using NZPostOffice.RDS.DataControls.Report;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class RCustlistRandomLabel
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
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();            
            //!this.report = new NZPostOffice.RDS.DataControls.Report.RERCustlistRandomLabel();
            this.report = new NZPostOffice.RDS.DataControls.Report.RERCustlistRandomLabel_Lbl();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.CustlistRandomLabel);
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
            this.viewer.Size = new System.Drawing.Size(650, 300);
            this.viewer.TabIndex = 0;
            // 
            // RCustlistRandomLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.viewer);
            this.Name = "RCustlistRandomLabel";
            this.Size = new System.Drawing.Size(650, 300);
            this.Dock = DockStyle.Fill;
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

            this.report.RefreshReport += new System.EventHandler(report_RefreshReport);
            DataTable table = new CustlistRandomLabelDataSet(this.bindingSource.DataSource);
            this.report.SetDataSource(table);
            this.RetrieveEnd += new System.EventHandler(RCustlistRandomLabel_RetrieveEnd);
        }

        private void report_RefreshReport(object sender, System.EventArgs e)
        {
            this.report.SetParameterValue("xrequired", ai_xrequired);
        }

        private void RCustlistRandomLabel_RetrieveEnd(object sender, System.EventArgs e)
        {
            try
            {
                DataTable table = new CustlistRandomLabelDataSet(this.bindingSource.DataSource);
                this.report.SetDataSource(table);
                this.viewer.RefreshReport();
            }
            catch
            { }
        }

		#endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;

        //!private NZPostOffice.RDS.DataControls.Report.RERCustlistRandomLabel report;
        private NZPostOffice.RDS.DataControls.Report.RERCustlistRandomLabel_Lbl report;
	}
}
