using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DCustInterestStat : Metex.Windows.DataUserControl
	{
		public DCustInterestStat()
		{
			InitializeComponent();
		}

        public int Retrieve(int? inRegion, int? inOutlet, int? inContractType, int? inPrivacy)
		{
			return RetrieveCore<CustInterestStat>(new List<CustInterestStat>
				(CustInterestStat.GetAllCustInterestStat( inRegion, inOutlet, inContractType, inPrivacy )));
		}
	}
}
