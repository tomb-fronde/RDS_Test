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
	public partial class DMailCarried : Metex.Windows.DataUserControl
	{
		public DMailCarried()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inContract, int? inSFKey, string inDeliveryDays )
		{
			return RetrieveCore<MailCarried>(new List<MailCarried>
				(MailCarried.GetAllMailCarried( inContract, inSFKey, inDeliveryDays )));
		}
	}
}
