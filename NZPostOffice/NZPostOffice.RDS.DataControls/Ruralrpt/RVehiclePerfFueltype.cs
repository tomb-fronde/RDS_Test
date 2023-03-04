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
	public partial class RVehiclePerfFueltype : Metex.Windows.DataUserControl
	{
		public RVehiclePerfFueltype()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inRegion, int? inOutlet, int? inrengroup, int? inContract_Type )
        {
            return RetrieveCore<VehiclePerfFueltype>(new List<VehiclePerfFueltype>(VehiclePerfFueltype.GetAllVehiclePerfFueltype(inRegion, inOutlet, inrengroup, inContract_Type)));
		}
	}
}
