using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
	public partial class DwReportCriteria : Metex.Windows.DataUserControl
	{
		public DwReportCriteria()
		{
			InitializeComponent();
			InitializeDropdown();
		}

        private void InitializeDropdown()
        {
            region_id.AssignDropdownType<NZPostOffice.DataControls.DDddwRegions>();
        }

		public override int Retrieve( )
        {
			return RetrieveCore<ReportCriteria>(ReportCriteria.GetAllReportCriteria());
		}
	}
}
