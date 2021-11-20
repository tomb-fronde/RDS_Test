using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DRoadMap : Metex.Windows.DataUserControl
	{
		public DRoadMap()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<RoadMap>(new List<RoadMap>
				(RoadMap.GetAllRoadMap(  )));
		}
	}
}
