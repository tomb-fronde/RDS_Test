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
	public partial class DwFind : Metex.Windows.DataUserControl
	{
		public DwFind()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
            return RetrieveCore<NZPostOffice.RDSAdmin.Entity.Security.Find>(new List<NZPostOffice.RDSAdmin.Entity.Security.Find>(NZPostOffice.RDSAdmin.Entity.Security.Find.GetAllFind()));
		}
	}
}
