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
	public partial class DCustCountExport : Metex.Windows.DataUserControl
	{
		public DCustCountExport()
		{
			InitializeComponent();
		}

        public int Retrieve(int? inRegion, int? inOutlet, int? inContractType, int? inRenewalGroup)
		{
			return RetrieveCore<CustCountExport>(new List<CustCountExport>
				(CustCountExport.GetAllCustCountExport( inRegion, inOutlet, inContractType, inRenewalGroup )));
		}
	}
}
