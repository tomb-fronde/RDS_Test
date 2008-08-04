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
	public partial class DReportCustomerStatisticsCriteria : Metex.Windows.DataUserControl
	{
		public DReportCustomerStatisticsCriteria()
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
            return RetrieveCore<ReportCustomerStatisticsCriteria>(new List<ReportCustomerStatisticsCriteria>(ReportCustomerStatisticsCriteria.GetAllReportCustomerStatisticsCriteria()));
		}
	}
}
