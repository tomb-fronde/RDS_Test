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
	public partial class DddwTowncity : Metex.Windows.DataUserControl
	{
		public DddwTowncity()
		{
			InitializeComponent();
		}
		public override int Retrieve(  )
		{
            return RetrieveCore<NZPostOffice.RDSAdmin.Entity.Security.DddwTowncity>(new List<NZPostOffice.RDSAdmin.Entity.Security.DddwTowncity>(NZPostOffice.RDSAdmin.Entity.Security.DddwTowncity.GetAllTowncity()));
		}
	}
}
