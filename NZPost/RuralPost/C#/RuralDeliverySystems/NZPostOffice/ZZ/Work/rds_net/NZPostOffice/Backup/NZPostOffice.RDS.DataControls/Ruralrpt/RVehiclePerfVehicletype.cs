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
	public partial class RVehiclePerfVehicletype : Metex.Windows.DataUserControl
	{
		public RVehiclePerfVehicletype()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inRegion, int? inOutlet, int? inrengroup, int? inContract_Type )
        {
            return RetrieveCore<VehiclePerfVehicletype>(new List<VehiclePerfVehicletype>(VehiclePerfVehicletype.GetAllVehiclePerfVehicletype(inRegion, inOutlet, inrengroup, inContract_Type)));
		}
	}
}
