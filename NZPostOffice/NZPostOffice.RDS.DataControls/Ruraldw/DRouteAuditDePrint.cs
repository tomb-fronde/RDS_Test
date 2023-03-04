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
	public partial class DRouteAuditDePrint : Metex.Windows.DataUserControl
	{
		public DRouteAuditDePrint()
		{
			InitializeComponent();
		}

		public int Retrieve( int? contract, DateTime? auditdate )
		{
			return RetrieveCore<RouteAuditDePrint>(new List<RouteAuditDePrint>
				(RouteAuditDePrint.GetAllRouteAuditDePrint(contract, auditdate )));
		}
        public void Print()
        {
            this.viewer.RefreshReport();
            this.viewer.PrintReport();
        }
        
	}
}
