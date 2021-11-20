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
    public partial class DCustomerInterest : Metex.Windows.DataUserControl
	{
		public DCustomerInterest()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			interest_id.AssignDropdownType<DddwCustomerInterest>();
		}

		public int Retrieve( int? al_cust_id )
		{
			return RetrieveCore<CustomerInterest>(new List<CustomerInterest>
				(CustomerInterest.GetAllCustomerInterest( al_cust_id )));
		}
	}
}
