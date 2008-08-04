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
	public partial class DRenewalProcessCriteria : Metex.Windows.DataUserControl
	{
		public DRenewalProcessCriteria()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			region_id.AssignDropdownType<DDddwRegions>();
			rg_code.AssignDropdownType<DDddwRenewalgroup>();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<RenewalProcessCriteria>(new List<RenewalProcessCriteria>
				(RenewalProcessCriteria.GetAllRenewalProcessCriteria(  )));
		}
	}
}
