using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin2;
////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
	public partial class DsNonVehicleOverrideRateHistory : Metex.Windows.DataUserControl
	{
		public DsNonVehicleOverrideRateHistory()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_contract, int? al_sequence )
        {
            return RetrieveCore<NonVehicleOverrideRateHistory>(new List<NonVehicleOverrideRateHistory>(NonVehicleOverrideRateHistory.GetAllNonVehicleOverrideRateHistory(al_contract, al_sequence)));
		}
	}
}
