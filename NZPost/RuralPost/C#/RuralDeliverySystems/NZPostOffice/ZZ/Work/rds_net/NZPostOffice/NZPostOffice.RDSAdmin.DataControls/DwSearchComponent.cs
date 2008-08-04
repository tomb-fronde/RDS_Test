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
	public partial class DwSearchComponent : Metex.Windows.DataUserControl
	{
		public DwSearchComponent()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
			return RetrieveCore<SearchComponent>( new List<SearchComponent>(SearchComponent.GetAllSearchComponent()));
		}
	}
}
