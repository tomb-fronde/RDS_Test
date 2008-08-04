using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataControls.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DAddressDetails : Metex.Windows.DataUserControl
	{
		public DAddressDetails()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			sl_name.AssignDropdownType<DDddwSuburbNames>();
            rs_id.AssignDropdownType<DDddwRoadSuffix>();
            tc_id.AssignDropdownType<DDddwTownOnly>();
            rt_id.AssignDropdownType<DDddwRoadType>();
		}

		public int Retrieve( int? al_adr_id )
        {
			return RetrieveCore<AddressDetails>(AddressDetails.GetAllAddressDetails(al_adr_id));
		}
	}
}
