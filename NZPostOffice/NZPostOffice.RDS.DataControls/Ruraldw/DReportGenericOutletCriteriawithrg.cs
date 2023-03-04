using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.DataControls;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DReportGenericOutletCriteriawithrg : Metex.Windows.DataUserControl
	{
		public DReportGenericOutletCriteriawithrg()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			ct_key.AssignDropdownType<DDddwContractTypes>();
			region_id.AssignDropdownType<DDddwRegions>();
			rg_code.AssignDropdownType<DDddwRenewalgroup>();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<ReportGenericOutletCriteriawithrg>(new List<ReportGenericOutletCriteriawithrg>
				(ReportGenericOutletCriteriawithrg.GetAllReportGenericOutletCriteriawithrg()));
		}
	}
}
