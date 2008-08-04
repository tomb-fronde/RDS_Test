using System;
using System.Data;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class RVehicleScheduleSingleContractv2
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
            this.reRVehicleScheduleSingleContractv2 = new NZPostOffice.RDS.DataControls.Report.RERVehicleScheduleSingleContractv2();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.VehicleScheduleSingleContractv2);

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
            this.viewer.ReportSource = this.reRVehicleScheduleSingleContractv2;

            // 
            // DwRunningSheetHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "RVehicleScheduleSingleContractv2";
            this.Size = new System.Drawing.Size(562, 365);// (638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.reRVehicleScheduleSingleContractv2.RefreshReport += new EventHandler(reRVehicleScheduleSingleContractv2_RefreshReport);
            table = new NZPostOffice.RDS.DataControls.Report.VehicleScheduleSingleContractv2DataSet(this.bindingSource.DataSource);
            this.reRVehicleScheduleSingleContractv2.SetDataSource(table);
            this.RetrieveEnd += new System.EventHandler(RVehicleScheduleSingleContractv2_RetrieveEnd);
            this.ResumeLayout(false);

        }

        private void reRVehicleScheduleSingleContractv2_RefreshReport(object sender, System.EventArgs e)
        {
            this.reRVehicleScheduleSingleContractv2.SetParameterValue("inSequence", u_inSequence);
        }

        private void RVehicleScheduleSingleContractv2_RetrieveEnd(object sender, EventArgs e)
        {
            try
            {
                lock (reRVehicleScheduleSingleContractv2)
                {
                    table = new NZPostOffice.RDS.DataControls.Report.VehicleScheduleSingleContractv2DataSet(this.bindingSource.DataSource);
                    multiTabel.Merge(table);
                    this.reRVehicleScheduleSingleContractv2.SetDataSource(multiTabel);
                    viewer.RefreshReport();
                }
            }
            catch
            { }

        }
        #endregion

        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.RERVehicleScheduleSingleContractv2 reRVehicleScheduleSingleContractv2;
        private DataTable multiTabel = new DataTable();
    }
}
