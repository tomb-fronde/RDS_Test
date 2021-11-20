using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.DataControls.Report;
using NZPostOffice.RDS.Entity.Ruralrpt;
//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RContractSummary : Metex.Windows.DataUserControl
	{
        private DateTime? indate;

		public RContractSummary()
		{
			InitializeComponent();
		}

        public int Retrieve(int? inContract, int? inSequence, DateTime? indate)
        {
            int ret = 0;

            this.indate = indate;

            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reRContractSummary = new RERContractSummary();
            this.reRContractSummary.RefreshReport += new EventHandler(reRContractSummary_RefreshReport);

            table = new NZPostOffice.RDS.DataControls.Report.ContractSummaryDataSet(this.bindingSource.DataSource);
            reRContractSummary.SetDataSource(table);

                DataTable detailsDT = new ContractSummaryDetailsDataSet(new ContractSummaryDetails());
                reRContractSummary.Subreports["RERContractSummaryDetails.rpt"].SetDataSource(detailsDT);

                DataTable frequencyDT = new ContractSummaryFrequenciesDataSet(new ContractSummaryFrequencies());
                reRContractSummary.Subreports["RERContractSummaryFrequencies.rpt"].SetDataSource(frequencyDT);

                DataTable paymentDT = new ContractSummaryPaymentsDataSet(new ContractSummaryPayments());
                reRContractSummary.Subreports["RERContractSummaryPayments.rpt"].SetDataSource(paymentDT);

                DataTable ownerDriverDT = new ContractSummaryOwnerDriverDataSet(new ContractSummaryOwnerDriver());
                reRContractSummary.Subreports["RERContractSummaryOwnerDriver.rpt"].SetDataSource(ownerDriverDT);

                DataTable vehicleDT = new ContractSummaryVehicleDataSet(new ContractSummaryVehicle());
                reRContractSummary.Subreports["RERContractSummaryVehicle.rpt"].SetDataSource(vehicleDT);

                DataTable pieceRatesDT = new ContractSummaryPieceRatesDataSet(new ContractSummaryPieceRates());
                reRContractSummary.Subreports["RERContractSummaryPieceRates.rpt"].SetDataSource(pieceRatesDT);

                DataTable volumeDT = new ContractSummaryVolumeDataSet(new ContractSummaryVolume());
                reRContractSummary.Subreports["RERContractSummaryVolume.rpt"].SetDataSource(volumeDT);

                ret = RetrieveCore<ContractSummary>(new List<ContractSummary>(ContractSummary.GetAllContractSummary(inContract, inSequence, indate)));
                GC.Collect();
          
            detailsDT = new ContractSummaryDetailsDataSet(ContractSummaryDetails.GetAllContractSummaryDetails(inContract, inSequence));
            reRContractSummary.Subreports["RERContractSummaryDetails.rpt"].SetDataSource(detailsDT);

            frequencyDT = new ContractSummaryFrequenciesDataSet(ContractSummaryFrequencies.GetAllContractSummaryFrequencies(inContract, inSequence));
            reRContractSummary.Subreports["RERContractSummaryFrequencies.rpt"].SetDataSource(frequencyDT);

            paymentDT = new ContractSummaryPaymentsDataSet(ContractSummaryPayments.GetAllContractSummaryPayments(inContract, inSequence));
            paymentDT.DefaultView.Sort = "CSort ASC,CType ASC";
            DataTable paymentDTSort = paymentDT.Copy();
            paymentDTSort.Rows.Clear();
            for (int i = 0; i < paymentDT.Rows.Count; i++)
            {
                object[] l_column = new object[3];
                paymentDT.DefaultView[i].Row.ItemArray.CopyTo(l_column, 0);
                paymentDTSort.Rows.Add(l_column);
            }
            reRContractSummary.Subreports["RERContractSummaryPayments.rpt"].SetDataSource(paymentDTSort);

            ownerDriverDT = new ContractSummaryOwnerDriverDataSet(ContractSummaryOwnerDriver.GetAllContractSummaryOwnerDriver(inContract, inSequence));
            reRContractSummary.Subreports["RERContractSummaryOwnerDriver.rpt"].SetDataSource(ownerDriverDT);

            vehicleDT = new ContractSummaryVehicleDataSet(ContractSummaryVehicle.GetAllContractSummaryVehicle(inContract, inSequence));
            reRContractSummary.Subreports["RERContractSummaryVehicle.rpt"].SetDataSource(vehicleDT);

            pieceRatesDT = new ContractSummaryPieceRatesDataSet(ContractSummaryPieceRates.GetAllContractSummaryPieceRates(inContract, indate.GetValueOrDefault().Month, indate.GetValueOrDefault().Year));
            reRContractSummary.Subreports["RERContractSummaryPieceRates.rpt"].SetDataSource(pieceRatesDT);

            volumeDT = new ContractSummaryVolumeDataSet(ContractSummaryVolume.GetAllContractSummaryVolume(inContract, inSequence));
            reRContractSummary.Subreports["RERContractSummaryVolume.rpt"].SetDataSource(volumeDT);

            this.viewer.RefreshReport();
            return ret;
        }

        void reRContractSummary_RefreshReport(object sender, EventArgs e)
        {
            if (indate == null)
            {
                indate = Convert.ToDateTime("30/12/1899");
            }
                reRContractSummary.SetParameterValue("MoMo", indate, "RERContractSummaryPieceRates.rpt");
                reRContractSummary.SetParameterValue("YrYr", indate, "RERContractSummaryPieceRates.rpt");
        }

        void RContractSummary_RetrieveEnd(object sender, System.EventArgs e)
        {
            rptHeight = this.ParentForm.ParentForm.ClientSize.Height;

            this.viewer.ActiveViewIndex = rptIndex;
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer.DisplayGroupTree = false;
            this.viewer.DisplayStatusBar = false;
            //this.viewer.ShowExportButton = false;
            //this.viewer.ShowPrintButton = false;
            this.viewer.ShowGroupTreeButton = false;
            this.viewer.EnableDrillDown = false;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, rptIndex * rptHeight);
            // TJB  RD7_0051  Oct-2009
            // Removed rptIndex from viewer name; name looked up by wRenewalProcess2006
            this.viewer.Name = "viewer";    // +rptIndex.ToString();
            this.viewer.ReportSource = this.reRContractSummary;
            this.viewer.Size = new System.Drawing.Size(671, rptHeight);
            this.viewer.TabIndex = rptIndex;
            this.Controls.Add(this.viewer);

            rptIndex++;
        }
	}
}
