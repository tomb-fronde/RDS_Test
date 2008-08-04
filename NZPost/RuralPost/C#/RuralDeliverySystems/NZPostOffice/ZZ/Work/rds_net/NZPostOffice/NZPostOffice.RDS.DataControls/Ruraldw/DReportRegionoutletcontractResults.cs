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
	public partial class DReportRegionoutletcontractResults : Metex.Windows.DataUserControl
	{
		public DReportRegionoutletcontractResults()
		{
			InitializeComponent();
		}

        public int Retrieve(int? Inregion, int? inOutlet, int? inContract)
		{
			return RetrieveCore<ReportRegionoutletcontractResults>(new List<ReportRegionoutletcontractResults>
				(ReportRegionoutletcontractResults.GetAllReportRegionoutletcontractResults( Inregion, inOutlet, inContract )));
		}
	}
}
