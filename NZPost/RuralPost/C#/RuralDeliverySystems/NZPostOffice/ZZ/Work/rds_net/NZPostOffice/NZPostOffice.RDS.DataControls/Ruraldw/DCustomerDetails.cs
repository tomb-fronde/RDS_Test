using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
//////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    public partial class DCustomerDetails : Metex.Windows.DataUserControl
	{
		public DCustomerDetails()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_cust_id )
        {
			return RetrieveCore<CustomerDetails>(new List<CustomerDetails>(CustomerDetails.GetAllCustomerDetails(al_cust_id)));
		}
	}
}
