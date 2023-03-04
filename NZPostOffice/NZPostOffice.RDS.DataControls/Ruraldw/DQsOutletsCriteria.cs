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
	public partial class DQsOutletsCriteria : Metex.Windows.DataUserControl
	{
		public DQsOutletsCriteria()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			region_id.AssignDropdownType<DDddwRegions>();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<QsOutletsCriteria>(new List<QsOutletsCriteria>
				(QsOutletsCriteria.GetAllQsOutletsCriteria(  )));
		}
	}
}
