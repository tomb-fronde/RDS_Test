using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
	public partial class DwSync : Metex.Windows.DataUserControl
	{
		public DwSync()
		{
			InitializeComponent();
		}

		public int Retrieve( string a_sync_name )
        {
			return RetrieveCore<Sync>(Sync.GetAllSync(a_sync_name));
		}
	}
}
