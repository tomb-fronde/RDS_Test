using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DCustlistSelect : Metex.Windows.DataUserControl
	{
		public DCustlistSelect()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
            return RetrieveCore<CustlistSelect>(new List<CustlistSelect>(CustlistSelect.GetAllCustlistSelect()));
		}
	}
}
