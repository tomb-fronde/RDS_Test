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
	public partial class DsRouteFrequency : Metex.Windows.DataUserControl
	{
		public DsRouteFrequency()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inContract )
        {
			return RetrieveCore<RouteFrequency>(new List<RouteFrequency>(RouteFrequency.GetAllRouteFrequency(inContract)));
		}
	}
}
