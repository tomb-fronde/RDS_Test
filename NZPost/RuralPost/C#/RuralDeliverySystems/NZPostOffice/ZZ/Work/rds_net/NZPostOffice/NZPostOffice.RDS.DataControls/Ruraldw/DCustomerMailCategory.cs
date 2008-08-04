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
    public partial class DCustomerMailCategory : Metex.Windows.DataUserControl
	{
		public DCustomerMailCategory()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			mc_key_1.AssignDropdownType<DddwMailCategory>();
			mc_key_2.AssignDropdownType<DddwMailCategory>();
			mc_key_3.AssignDropdownType<DddwMailCategory>();
		}

		public int Retrieve( int? in_Cust_Id )
		{
			return RetrieveCore<CustomerMailCategory>(new List<CustomerMailCategory>
				(CustomerMailCategory.GetAllCustomerMailCategory( in_Cust_Id )));
		}
	}
}
