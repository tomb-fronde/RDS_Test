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
	public partial class DPieceRateImportExeptionReport : Metex.Windows.DataUserControl
	{
		public DPieceRateImportExeptionReport()
		{
			InitializeComponent();
			//InitializeDropdown();
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            
            base.OnHandleCreated(e);
        }

		private void InitializeDropdown()
		{
			//?prt_key.AssignDropdownType<DddwPieceRates>();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<PieceRateImportExeptionReport>(new List<PieceRateImportExeptionReport>
				(PieceRateImportExeptionReport.GetAllPieceRateImportExeptionReport()));
		}

        public int Retrieve(Metex.Core.EntityBindingList<PieceRateImportExeptionReport> errorList)
        {
            return RetrieveCore<PieceRateImportExeptionReport>(errorList);
        }

        public int Retrieve(List<PieceRateImportExeptionReport> errorList)
        {
            return RetrieveCore<PieceRateImportExeptionReport>(errorList);
        }

        public void Print()
        {
            //!this.viewer.PrintReport();
            DPieceRateImportExeptionReport_Load(null, null);
            this.viewer.RefreshReport();
            try
            {
                (this.viewer.ReportSource as CrystalDecisions.CrystalReports.Engine.ReportClass).PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception e)
            {
                string eMsg = e.Message;
                MessageBox.Show(eMsg, "Warning"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
	}
}
