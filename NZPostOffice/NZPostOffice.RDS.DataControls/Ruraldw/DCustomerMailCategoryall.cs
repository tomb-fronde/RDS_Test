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
    public partial class DCustomerMailCategoryall : Metex.Windows.DataUserControl
	{
		public DCustomerMailCategoryall()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			//?mc_key.AssignDropdownType<DddwMailCategoryAll>();
		}

		public int Retrieve( int? in_Cust_Id )
        {
			return RetrieveCore<CustomerMailCategoryall>(CustomerMailCategoryall.GetAllCustomerMailCategoryall(in_Cust_Id));
		}
	}
}
