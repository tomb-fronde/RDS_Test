using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Windows;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    public partial class DCustomerInterests : Metex.Windows.DataUserControl
	{
        // TJB  Feb-2011  RPCR_023: New
        // Implements list of interests with checkboxes for selections
        // (not to be confused with DCustomerInterest!)

		public DCustomerInterests()
		{
			InitializeComponent();
//			this.SortString = "contract_type A";
		}

		public int Retrieve(int? in_cust_id)
		{
            int ret = RetrieveCore<CustomerInterests>(new List<CustomerInterests>(CustomerInterests.GetAllCustomerInterests(in_cust_id)));
			if (this.SortString != "")
				this.Sort<CustomerInterests>();
			return ret;
		}
	}
}
