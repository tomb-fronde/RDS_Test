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
    public partial class DCustomerOccupation : Metex.Windows.DataUserControl
	{
		public DCustomerOccupation()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			occupation_id.AssignDropdownType<DddwCustomerOccupation>();
		}

		public int Retrieve( int? al_cust_id )
		{
			return RetrieveCore<CustomerOccupation>(new List<CustomerOccupation>
				(CustomerOccupation.GetAllCustomerOccupation( al_cust_id )));
		}
	}
}
