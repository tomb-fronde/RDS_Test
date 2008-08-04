using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RRcmStatisticalReport : Metex.Windows.DataUserControl
	{
		public RRcmStatisticalReport()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inRegion, int? inOutlet, int? inRengroup, int? inContractType )
        {
            return RetrieveCore<RcmStatisticalReport>(new List<RcmStatisticalReport>(RcmStatisticalReport.GetAllRcmStatisticalReport(inRegion, inOutlet, inRengroup, inContractType)));
		}
	}
}
