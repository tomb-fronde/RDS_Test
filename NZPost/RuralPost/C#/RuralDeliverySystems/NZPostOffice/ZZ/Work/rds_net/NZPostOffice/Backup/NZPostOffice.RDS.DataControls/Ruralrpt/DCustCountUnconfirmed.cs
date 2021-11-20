using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DCustCountUnconfirmed : Metex.Windows.DataUserControl
	{
		public DCustCountUnconfirmed()
		{
			InitializeComponent();
		}

        public int Retrieve(int? Inregion, int? inOutlet, int? inContract, DateTime? indate)
		{
			return RetrieveCore<CustCountUnconfirmed>(new List<CustCountUnconfirmed>
				(CustCountUnconfirmed.GetAllCustCountUnconfirmed( Inregion, inOutlet, inContract, indate )));
		}
	}
}
