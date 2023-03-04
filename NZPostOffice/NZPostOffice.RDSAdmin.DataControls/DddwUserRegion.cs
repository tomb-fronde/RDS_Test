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
	public partial class DddwUserRegion : Metex.Windows.DataUserControl
	{
		public DddwUserRegion()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
            return RetrieveCore<DUserRegion>(new List<DUserRegion>(DUserRegion.GetAllUserRegion()));
		}
	}
}
