using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DPieceRateImportDiffRateReport : Metex.Windows.DataUserControl
	{
		public DPieceRateImportDiffRateReport()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			//?prt_key.AssignDropdownType<DddwPieceRates>();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<PieceRateImportDiffRateReport>(new List<PieceRateImportDiffRateReport>
				(PieceRateImportDiffRateReport.GetAllPieceRateImportDiffRateReport()));
		}

        public int Retrieve(Metex.Core.EntityBindingList<PieceRateImportDiffRateReport> dw_wrong_rate_List)
        {
            return RetrieveCore<PieceRateImportDiffRateReport>(dw_wrong_rate_List);
        }

        public int Retrieve(List<PieceRateImportDiffRateReport> dw_wrong_rate_List)
        {
            return RetrieveCore<PieceRateImportDiffRateReport>(dw_wrong_rate_List);
        }

        public void Print()
        {
            //!this.viewer.PrintReport();
            //!this.viewer.PrintReport();
            DPieceRateImportDiffRateReport_Load(null, null);
            this.viewer.RefreshReport();
            (this.viewer.ReportSource as CrystalDecisions.CrystalReports.Engine.ReportClass).PrintToPrinter(1, false, 0, 0);
        }
	}
}
