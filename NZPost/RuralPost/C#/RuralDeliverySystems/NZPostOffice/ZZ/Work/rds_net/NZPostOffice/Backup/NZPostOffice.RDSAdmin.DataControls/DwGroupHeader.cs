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
	public partial class DwGroupHeader : Metex.Windows.DataUserControl
	{
		public DwGroupHeader()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_group_id )
		{
			return RetrieveCore<GroupHeader>( new List<GroupHeader>(GroupHeader.GetAllGroupHeader(al_group_id)));
		}
	}
}
