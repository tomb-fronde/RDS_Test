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
	public partial class DReportGenericCriteria : Metex.Windows.DataUserControl
	{
		public DReportGenericCriteria()
		{
			InitializeComponent();
			//InitializeDropdown();
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
			sf_key.AssignDropdownType<DDddwStandardFrequency>();
			region_id.AssignDropdownType<DDddwRegions>();
			region_id_ro.AssignDropdownType<DDddwRegions>();
			rg_code.AssignDropdownType<DDddwRenewalgroup>();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<ReportGenericCriteria>(new List<ReportGenericCriteria>
				(ReportGenericCriteria.GetAllReportGenericCriteria()));
		}
	}
}
