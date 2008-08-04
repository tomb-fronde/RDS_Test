using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DRouteAuditDe : Metex.Windows.DataUserControl
	{
		public DRouteAuditDe()
		{
			InitializeComponent();
		}

		public int Retrieve( int? contract, DateTime? auditdate )
		{
			return RetrieveCore<RouteAuditDe>(new List<RouteAuditDe>
				(RouteAuditDe.GetAllRouteAuditDe( contract, auditdate )));
		}
	}
}
