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
	public partial class DOutletReportCriteria : Metex.Windows.DataUserControl
	{
		public DOutletReportCriteria()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			regionid.AssignDropdownType<DDddwRegions>();
		}

		public override int Retrieve( )
        {
            return RetrieveCore<OutletReportCriteria>(new List<OutletReportCriteria>(OutletReportCriteria.GetAllOutletReportCriteria()));
		}
	}
}
