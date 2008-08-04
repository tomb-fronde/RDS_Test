using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataControls.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    public partial class DCustomerDetails2 : Metex.Windows.DataUserControl
	{
		public DCustomerDetails2()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			cust_title.AssignDropdownType<DDddwCustTitle>();
		}

		public int Retrieve( int? al_cust_id )
        {
            return RetrieveCore<CustomerDetails2>(new List<CustomerDetails2>(CustomerDetails2.GetAllCustomerDetails2(al_cust_id)));
		}

	}
}
