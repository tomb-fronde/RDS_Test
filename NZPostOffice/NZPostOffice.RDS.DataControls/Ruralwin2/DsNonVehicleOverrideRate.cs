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
	public partial class DsNonVehicleOverrideRate : Metex.Windows.DataUserControl
	{
		public DsNonVehicleOverrideRate()
		{
			InitializeComponent();
		}

		public int Retrieve( int? contract, int? sequence )
        {
            return RetrieveCore<NonVehicleOverrideRate>(new List<NonVehicleOverrideRate>(NonVehicleOverrideRate.GetAllNonVehicleOverrideRate(contract, sequence)));
		}
	}
}
