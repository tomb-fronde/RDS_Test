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
	public partial class DReportGenericRegOutletContcriteria : Metex.Windows.DataUserControl
	{
		public DReportGenericRegOutletContcriteria()
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
			return RetrieveCore<ReportGenericRegOutletContcriteria>(new List<ReportGenericRegOutletContcriteria>
				(ReportGenericRegOutletContcriteria.GetAllReportGenericRegOutletContcriteria(  )));
		}
	}
}
