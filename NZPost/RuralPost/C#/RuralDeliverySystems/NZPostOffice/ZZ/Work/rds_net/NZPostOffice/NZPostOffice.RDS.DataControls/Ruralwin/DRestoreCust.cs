using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	public partial class DRestoreCust : Metex.Windows.DataUserControl
	{
		public DRestoreCust()
		{
			InitializeComponent();
		}

		public int Retrieve( int? in_custID )
		{
			return RetrieveCore<RestoreCust>(new List<RestoreCust>
				(RestoreCust.GetAllRestoreCust( in_custID )));
		}
	}
}
