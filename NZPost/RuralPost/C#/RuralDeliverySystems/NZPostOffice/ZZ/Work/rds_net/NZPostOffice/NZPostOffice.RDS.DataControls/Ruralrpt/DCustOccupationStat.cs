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
	public partial class DCustOccupationStat : Metex.Windows.DataUserControl
	{
		public DCustOccupationStat()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inRegion, int? inOutlet, int? inContractType, int? inPrivacy )
        {
            return RetrieveCore<CustOccupationStat>(new List<CustOccupationStat>(CustOccupationStat.GetAllCustOccupationStat(inRegion, inOutlet, inContractType, inPrivacy)));
		}
	}
}
