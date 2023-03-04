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
	public partial class RVehiclePerfAge : Metex.Windows.DataUserControl
	{
		public RVehiclePerfAge()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inRegion, int? inOutlet, int? inRengroup, int? inContract_type )
        {
            return RetrieveCore<VehiclePerfAge>(new List<VehiclePerfAge>(VehiclePerfAge.GetAllVehiclePerfAge(inRegion, inOutlet, inRengroup, inContract_type)));
		}
	}
}
