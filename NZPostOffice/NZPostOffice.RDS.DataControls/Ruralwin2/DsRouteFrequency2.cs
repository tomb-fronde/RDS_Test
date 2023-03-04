using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
//using NZPostOffice.RDS.Entity.Ruralwin2;
////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
    // TJB  Frequencies & Vehicles  25-Jan-2021
    // From DsRouteFrequency
    // Uses <new> RouteFrequency2 with added columns (eg vehicle_number)

	public partial class DsRouteFrequency2 : Metex.Windows.DataUserControl
	{
		public DsRouteFrequency2()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inContract )
        {
            // "1" added = 'showall' - retrieve both active and not active
			return RetrieveCore<RouteFrequency2>(new List<RouteFrequency2>(RouteFrequency2.GetAllRouteFrequency2(inContract, 1)));
		}
	}
}
