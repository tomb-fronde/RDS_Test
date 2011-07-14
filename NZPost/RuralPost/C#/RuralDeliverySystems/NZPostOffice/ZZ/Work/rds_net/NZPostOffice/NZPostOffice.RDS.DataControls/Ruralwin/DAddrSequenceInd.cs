using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  RPCR_026  June-2011
    // Added rf_frozen_ind

	public partial class DAddrSequenceInd : Metex.Windows.DataUserControl
	{
		public DAddrSequenceInd()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inContractNo, int? inSFkey, string inDeliveryDays)
        {
			return RetrieveCore<AddrSequenceInd>(AddrSequenceInd.GetAllAddrSequenceInd(inContractNo, inSFkey, inDeliveryDays));
		}
	}
}
