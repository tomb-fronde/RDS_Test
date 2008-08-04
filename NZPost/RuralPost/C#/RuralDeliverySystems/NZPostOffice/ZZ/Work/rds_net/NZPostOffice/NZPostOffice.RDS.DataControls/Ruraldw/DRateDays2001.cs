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
	public partial class DRateDays2001 : Metex.Windows.DataUserControl
	{
		public DRateDays2001()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inRgCode, DateTime? in_Date )
		{
			int ll_return = RetrieveCore<RateDays2001>(new List<RateDays2001>
				(RateDays2001.GetAllRateDays2001( inRgCode, in_Date )));
            this.SortString = "sf_description A";
            this.Sort<RateDays2001>();
            return ll_return;
		}
	}
}
