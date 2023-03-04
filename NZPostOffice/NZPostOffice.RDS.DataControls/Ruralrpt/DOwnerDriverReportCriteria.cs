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
//using NZPostOffice.RDS.DataControls.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DOwnerDriverReportCriteria : Metex.Windows.DataUserControl
	{
        // TJB  FCR_001 28-Nov-2012
        // Increased size of renewal group dropdown to include November Renewals

		public DOwnerDriverReportCriteria()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			ct_key.AssignDropdownType<DDddwContractTypes>();
			region_id.AssignDropdownType<DDddwRegions>();
			region_id_ro.AssignDropdownType<DDddwRegions>();
			rg_code.AssignDropdownType<DDddwRenewalgroup>();
		}

		public override int Retrieve( )
        {
            return RetrieveCore<OwnerDriverReportCriteria>(new List<OwnerDriverReportCriteria>(OwnerDriverReportCriteria.GetAllOwnerDriverReportCriteria()));
		}
	}
}
