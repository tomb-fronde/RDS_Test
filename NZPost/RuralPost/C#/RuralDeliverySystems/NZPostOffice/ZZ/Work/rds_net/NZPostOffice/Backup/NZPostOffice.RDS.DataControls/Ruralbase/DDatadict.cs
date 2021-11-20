using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Windows;
using NZPostOffice.RDS.Entity.Ruralbase;

namespace NZPostOffice.RDS.DataControls.Ruralbase
{
    public partial class DDatadict : Metex.Windows.DataUserControl
	{
		public DDatadict()
		{
			InitializeComponent();
		}

		public int Retrieve( string user )
		{
			return RetrieveCore<Datadict>(new List<Datadict>
				(Datadict.GetAllDatadict(user)));
		}
	}
}
