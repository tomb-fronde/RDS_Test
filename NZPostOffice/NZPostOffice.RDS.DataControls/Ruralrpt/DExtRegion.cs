using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.DataControls;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DExtRegion : Metex.Windows.DataUserControl
	{
        // TJB  FCR_001 28-Nov-2012
        // Increased size of renewal group dropdown to include November Renewals

		public DExtRegion()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			d_ext_region_id.AssignDropdownType<DDddwRegions>();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<ExtRegion>(new List<ExtRegion>
				(ExtRegion.GetAllExtRegion(  )));
		}
	}
}
