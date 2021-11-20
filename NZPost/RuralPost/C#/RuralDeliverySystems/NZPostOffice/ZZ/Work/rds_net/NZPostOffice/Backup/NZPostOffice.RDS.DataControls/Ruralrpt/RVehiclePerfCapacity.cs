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
	public partial class RVehiclePerfCapacity : Metex.Windows.DataUserControl
	{
		public RVehiclePerfCapacity()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inRegion, int? inOutlet, int? inrengroup, int? inContract_Type )
        {
            return RetrieveCore<VehiclePerfCapacity>(new List<VehiclePerfCapacity>(VehiclePerfCapacity.GetAllVehiclePerfCapacity(inRegion, inOutlet, inrengroup, inContract_Type)));
		}
	}
}
