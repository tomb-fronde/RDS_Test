using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DInterestCriteria : Metex.Windows.DataUserControl
	{
		public DInterestCriteria()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<InterestCriteria>(new List<InterestCriteria>
				(InterestCriteria.GetAllInterestCriteria(  )));
		}
	}
}
