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
	public partial class DReportGenericRegOutletCriteria : Metex.Windows.DataUserControl
	{
        // TJB 30-Jan-2013
        // Increased size of region group dropdown

		public DReportGenericRegOutletCriteria()
		{
			InitializeComponent();
			//!InitializeDropdown();
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            base.OnHandleCreated(e);
        }

		private void InitializeDropdown()
		{
			ct_key.AssignDropdownType<DDddwContractTypes>();
			region_id.AssignDropdownType<DDddwRegions>();
			sf_key.AssignDropdownType<DDddwStandardFrequency>();
			rg_code1.AssignDropdownType<DDddwRenewalgroup>();
			rg_code2.AssignDropdownType<DDddwRenewalgroup>();
			rg_code.AssignDropdownType<DDddwRenewalGroups>();
		}

		public override int Retrieve( )
        {
            return RetrieveCore<ReportGenericRegOutletCriteria>(new List<ReportGenericRegOutletCriteria>(ReportGenericRegOutletCriteria.GetAllReportGenericRegOutletCriteria()));
		}
	}
}
