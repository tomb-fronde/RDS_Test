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
	public partial class DEclDataImportExeptionReport : Metex.Windows.DataUserControl
	{
		public DEclDataImportExeptionReport()
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
			return RetrieveCore<EclDataImportExeptionReport>(new List<EclDataImportExeptionReport>
				(EclDataImportExeptionReport.GetAllEclDataImportExeptionReport()));
		}

        public int Retrieve(Metex.Core.EntityBindingList<EclDataImportExeptionReport> errorList)
        {
            return RetrieveCore<EclDataImportExeptionReport>(errorList);
        }

        public int Retrieve(List<EclDataImportExeptionReport> errorList)
        {
            return RetrieveCore<EclDataImportExeptionReport>(errorList);
        }

        public void Print()
        {
            //!this.viewer.PrintReport();
            DEclDataImportExeptionReport_Load(null, null);
            this.viewer.RefreshReport();
            (this.viewer.ReportSource as CrystalDecisions.CrystalReports.Engine.ReportClass).PrintToPrinter(1, false, 0, 0);
        }
	}
}
