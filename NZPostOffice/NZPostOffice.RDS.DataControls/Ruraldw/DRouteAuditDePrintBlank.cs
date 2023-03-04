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
	public partial class DRouteAuditDePrintBlank : Metex.Windows.DataUserControl
	{
		public DRouteAuditDePrintBlank()
		{
			InitializeComponent();
		}

        private int ai_contract = 0;
        private DateTime adt_auditdate = DateTime.MinValue;

		public int Retrieve(int? contract, DateTime? auditdate)
		{
            ai_contract = contract.GetValueOrDefault();
            adt_auditdate = auditdate.GetValueOrDefault();
			int ret = RetrieveCore<RouteAuditDePrintBlank>(new List<RouteAuditDePrintBlank>(RouteAuditDePrintBlank.GetAllRouteAuditDePrintBlank(contract, auditdate)));
            this.viewer.RefreshReport();
            return ret;
		}
        public void Print()
        {
            this.viewer.RefreshReport();
            this.viewer.PrintReport();
        }
	}
}
