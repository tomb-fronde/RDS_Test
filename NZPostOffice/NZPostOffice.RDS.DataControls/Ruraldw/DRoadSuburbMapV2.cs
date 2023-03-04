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
	public partial class DRoadSuburbMapV2 : Metex.Windows.DataUserControl
	{
		public DRoadSuburbMapV2()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<RoadSuburbMapV2>(new List<RoadSuburbMapV2>
				(RoadSuburbMapV2.GetAllRoadSuburbMapV2()));
		}
	}
}
