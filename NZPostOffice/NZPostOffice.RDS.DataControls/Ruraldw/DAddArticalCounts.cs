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
	public partial class DAddArticalCounts : Metex.Windows.DataUserControl
	{
		public DAddArticalCounts()
		{
			InitializeComponent();
		}

		public int Retrieve( int? in_Contract, int? in_WeekPeriod )
		{
			return RetrieveCore<AddArticalCounts>(new List<AddArticalCounts>
				(AddArticalCounts.GetAllAddArticalCounts( in_Contract, in_WeekPeriod )));
		}
	}
}
