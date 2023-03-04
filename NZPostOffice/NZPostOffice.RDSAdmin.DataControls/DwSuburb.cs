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
	public partial class DwSuburb : Metex.Windows.DataUserControl
	{
		public DwSuburb()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_suburb_id )
		{
			return RetrieveCore<Suburb>( new List<Suburb>(Suburb.GetAllSuburb(al_suburb_id)));
		}
	}
}
