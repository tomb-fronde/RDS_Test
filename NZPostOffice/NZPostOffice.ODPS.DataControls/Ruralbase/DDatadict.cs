using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Ruralbase;

namespace NZPostOffice.ODPS.DataControls.Ruralbase
{
	public partial class DDatadict : Metex.Windows.DataUserControl
	{
		public DDatadict()
		{
			InitializeComponent();
		}

		public int Retrieve( string user )
		{
//?have no tables
            return RetrieveCore<Datadict>(new List<Datadict>(Datadict.GetAllDatadict(user)));
           
		}
	}
}
