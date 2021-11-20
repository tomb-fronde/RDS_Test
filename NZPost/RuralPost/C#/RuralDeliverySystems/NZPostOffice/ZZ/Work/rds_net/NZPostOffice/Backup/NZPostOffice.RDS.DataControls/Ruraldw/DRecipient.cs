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
	public partial class DRecipient : Metex.Windows.DataUserControl
	{
		public DRecipient()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_cust_id )
		{
			return RetrieveCore<Recipient>(new List<Recipient>
				(Recipient.GetAllRecipient( al_cust_id )));
		}
	}
}
