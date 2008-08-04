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
	public partial class DsVehicleOverrideRate : Metex.Windows.DataUserControl
	{
		public DsVehicleOverrideRate()
		{
			InitializeComponent();
		}

        public int Retrieve(int? contract, int? sequence)
        {
			return RetrieveCore<VehicleOverrideRate>(new List<VehicleOverrideRate>(VehicleOverrideRate.GetAllVehicleOverrideRate(contract, sequence)));
		}
	}
}
