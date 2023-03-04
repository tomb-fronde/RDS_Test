using NZPostOffice.RDS.DataControls.Report;
using System.Data;
namespace NZPostOffice.RDS.DataControls.Ruralbase
{
	partial class DDatadict
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
            this.reDDatadict = new REDDatadict();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralbase.Datadict);
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
            this.viewer.ReportSource = this.reDDatadict;
            this.viewer.Size = new System.Drawing.Size(671, 300);
            this.viewer.TabIndex = 0;
            this.Controls.Add(this.viewer);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            table = new DatadictDataSet(this.bindingSource.DataSource);
            reDDatadict.SetDataSource(table);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ResumeLayout(false); 
		}

        DataTable table;

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            table = new DatadictDataSet(this.bindingSource.DataSource);
            reDDatadict.SetDataSource(table);
        }

		#endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private REDDatadict reDDatadict;
	}
}
