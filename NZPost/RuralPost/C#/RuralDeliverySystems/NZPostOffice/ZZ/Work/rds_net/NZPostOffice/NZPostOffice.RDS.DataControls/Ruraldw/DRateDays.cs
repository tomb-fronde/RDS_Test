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
	public partial class DRateDays : Metex.Windows.DataUserControl
	{
		public DRateDays()
		{
			InitializeComponent();
		}

		public int Retrieve( DateTime? effectivedate )
		{
			return RetrieveCore<RateDays>(new List<RateDays>
				(RateDays.GetAllRateDays(effectivedate)));
		}
	}
}
