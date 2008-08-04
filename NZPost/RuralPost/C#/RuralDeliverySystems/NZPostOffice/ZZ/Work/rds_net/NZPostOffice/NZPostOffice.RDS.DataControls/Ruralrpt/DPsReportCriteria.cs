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
	public partial class DPsReportCriteria : Metex.Windows.DataUserControl
	{
		public DPsReportCriteria()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			region_id.AssignDropdownType<DDddwRegions>();
			region_id_ro.AssignDropdownType<DDddwRegions>();
		}

		public override int Retrieve( )
        {
            return RetrieveCore<PsReportCriteria>(new List<PsReportCriteria>(PsReportCriteria.GetAllPsReportCriteria()));
		}
	}
}
