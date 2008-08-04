using NZPostOffice.RDS.DataControls.Report;
using System.Data;
namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class RPsCustListTown
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
            this.reRPsCustListTown = new RERPsCustListTown();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.PsCustListTown);
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
            this.viewer.ReportSource = this.reRPsCustListTown;
            this.viewer.Size = new System.Drawing.Size(671, 300);
            this.viewer.TabIndex = 0;

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.Color.White;
            table = new PsCustListTownDataSet(this.bindingSource.DataSource);
            reRPsCustListTown.SetDataSource(table);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.ResumeLayout(false); 
		}

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            table = new PsCustListTownDataSet(this.bindingSource.DataSource);
            reRPsCustListTown.SetDataSource(table);
        }

		#endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private RERPsCustListTown reRPsCustListTown;
        private DataTable table;
	}
}
