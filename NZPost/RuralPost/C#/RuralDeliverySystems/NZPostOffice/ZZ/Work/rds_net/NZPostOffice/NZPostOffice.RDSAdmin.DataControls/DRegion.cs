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
	public partial class DRegion : Metex.Windows.DataUserControl
	{
		public DRegion()
		{
			InitializeComponent();
		}

		public int Retrieve( int? regionid )
		{
            return RetrieveCore<NZPostOffice.RDSAdmin.Entity.Security.Region>(new List<NZPostOffice.RDSAdmin.Entity.Security.Region>(NZPostOffice.RDSAdmin.Entity.Security.Region.GetAllRegion(regionid)));
		}
	}
}
