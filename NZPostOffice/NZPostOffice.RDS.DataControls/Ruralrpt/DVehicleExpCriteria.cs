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
	public partial class DVehicleExpCriteria : Metex.Windows.DataUserControl
	{
		public DVehicleExpCriteria()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			ct_key.AssignDropdownType<DDddwContractTypes>();
			region_id.AssignDropdownType<DDddwRegions>();
			rg_code.AssignDropdownType<NZPostOffice.RDS.DataControls.Ruraldw.DDddwRenewalgroup>();
		}

		public override int Retrieve( )
        {
            return RetrieveCore<VehicleExpCriteria>(new List<VehicleExpCriteria>(VehicleExpCriteria.GetAllVehicleExpCriteria()));
		}
	}
}
