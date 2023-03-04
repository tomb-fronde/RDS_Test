using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;
//!using NZPostOffice.RDSAdmin.DataControls.EpDropdowns;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	public partial class DwTowncity : Metex.Windows.DataUserControl
	{
		public DwTowncity()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_tc_sl_id )
		{
			return RetrieveCore<Towncity>( new List<Towncity>(Towncity.GetAllTowncity(al_tc_sl_id)));
		}
	}
}
