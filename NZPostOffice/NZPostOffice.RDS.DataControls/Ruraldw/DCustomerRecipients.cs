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
    public partial class DCustomerRecipients : Metex.Windows.DataUserControl
	{
		public DCustomerRecipients()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_cust_id )
		{
			return RetrieveCore<CustomerRecipients>(new List<CustomerRecipients>
				(CustomerRecipients.GetAllCustomerRecipients( al_cust_id )));
		}
	}
}
