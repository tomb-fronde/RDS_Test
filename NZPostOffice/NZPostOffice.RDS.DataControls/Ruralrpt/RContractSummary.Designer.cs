using System.Data;
using NZPostOffice.RDS.DataControls.Report;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class RContractSummary
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
            //this.reRContractSummary = new NZPostOffice.RDS.DataControls.Report.RERContractSummary();
            //this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.ContractSummary);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(562, 365);// (638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.AutoScroll = true;

            //table = new NZPostOffice.RDS.DataControls.Report.ContractSummaryDataSet(this.bindingSource.DataSource);
            //reRContractSummary.SetDataSource(table);

            //DataTable detailsDT = new ContractSummaryDetailsDataSet(new ContractSummaryDetails());
            //reRContractSummary.Subreports["RERContractSummaryDetails.rpt"].SetDataSource(detailsDT);

            //DataTable frequencyDT = new ContractSummaryFrequenciesDataSet(new ContractSummaryFrequencies());
            //reRContractSummary.Subreports["RERContractSummaryFrequencies.rpt"].SetDataSource(frequencyDT);

            //DataTable paymentDT = new ContractSummaryPaymentsDataSet(new ContractSummaryPayments());
            //reRContractSummary.Subreports["RERContractSummaryPayments.rpt"].SetDataSource(paymentDT);

            //DataTable ownerDriverDT = new ContractSummaryOwnerDriverDataSet(new ContractSummaryOwnerDriver());
            //reRContractSummary.Subreports["RERContractSummaryOwnerDriver.rpt"].SetDataSource(ownerDriverDT);

            //DataTable vehicleDT = new ContractSummaryVehicleDataSet(new ContractSummaryVehicle());
            //reRContractSummary.Subreports["RERContractSummaryVehicle.rpt"].SetDataSource(vehicleDT);

            //DataTable pieceRatesDT = new ContractSummaryPieceRatesDataSet(new ContractSummaryPieceRates());
            //reRContractSummary.Subreports["RERContractSummaryPieceRates.rpt"].SetDataSource(pieceRatesDT);

            //DataTable volumeDT = new ContractSummaryVolumeDataSet(new ContractSummaryVolume());
            //reRContractSummary.Subreports["RERContractSummaryVolume.rpt"].SetDataSource(volumeDT);

            this.RetrieveEnd += new System.EventHandler(RContractSummary_RetrieveEnd);
            
            this.ResumeLayout(false);
        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.RERContractSummary reRContractSummary;
        private DataTable table;
        private int rptIndex = 0;
        private int rptHeight = 0;
    }
}
