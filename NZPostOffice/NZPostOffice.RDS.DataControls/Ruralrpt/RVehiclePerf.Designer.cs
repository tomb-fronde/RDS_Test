namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    using System.Data;
    using NZPostOffice.RDS.Entity.Ruralrpt;
    using NZPostOffice.RDS.DataControls.Report;
    using CrystalDecisions.CrystalReports.Engine;

    partial class RVehiclePerf
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
            this.reRVehiclePerf = new NZPostOffice.RDS.DataControls.Report.RERVehiclePerf();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.VehiclePerf);

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
            this.viewer.ReportSource = this.reRVehiclePerf;

            // 
            // DwRunningSheetHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "RVehiclePerf";
            this.Size = new System.Drawing.Size(562, 365);//(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();

            table = new NZPostOffice.RDS.DataControls.Report.VehiclePerfDataSet(this.bindingSource.DataSource);
            this.reRVehiclePerf.SetDataSource(table);
            this.reRVehiclePerf.RefreshReport += new System.EventHandler(reRVehiclePerf_RefreshReport);

            DataTable ageDT = new NZPostOffice.RDS.DataControls.Report.VehiclePerfAgeDataSet(new VehiclePerfAge());
            this.reRVehiclePerf.Subreports["RERVehiclePerfAge.rpt"].SetDataSource(ageDT);

            DataTable fuelTypeDT = new VehiclePerfFueltypeDataSet(new VehiclePerfAge());
            this.reRVehiclePerf.Subreports["RERVehiclePerfFueltype.rpt"].SetDataSource(fuelTypeDT);

            DataTable capacityDT = new VehiclePerfCapacityDataSet(new VehiclePerfCapacity());
            this.reRVehiclePerf.Subreports["RERVehiclePerfCapacity.rpt"].SetDataSource(capacityDT);

            DataTable vehicletypeDT = new VehiclePerfVehicletypeDataSet(new VehiclePerfVehicletype());
            this.reRVehiclePerf.Subreports["RERVehiclePerfVehicletype.rpt"].SetDataSource(vehicletypeDT);

            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.RetrieveEnd += new System.EventHandler(RVehiclePerf_RetrieveEnd);
            this.ResumeLayout(false);

        }

        void reRVehiclePerf_RefreshReport(object sender, System.EventArgs e)
        {
            this.reRVehiclePerf.SetParameterValue("stParms", NZPostOffice.Shared.StaticVariables.gnv_app.of_get_parameters().miscstringparm);
        }

        void RVehiclePerf_RetrieveEnd(object sender, System.EventArgs e)
        {
            table = new NZPostOffice.RDS.DataControls.Report.VehiclePerfDataSet(this.bindingSource.DataSource);
            this.reRVehiclePerf.SetDataSource(table);
        }

        private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {

        }
        #endregion

        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.RERVehiclePerf reRVehiclePerf;
    }
}
