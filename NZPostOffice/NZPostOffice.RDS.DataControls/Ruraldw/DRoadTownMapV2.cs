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
	public partial class DRoadTownMapV2 : Metex.Windows.DataUserControl
	{
		public DRoadTownMapV2()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<RoadTownMapV2>(new List<RoadTownMapV2>
				(RoadTownMapV2.GetAllRoadTownMapV2()));
		}
	}
}
