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
    public partial class DCustomerOccupations : Metex.Windows.DataUserControl
	{
        // TJB  Feb-2011  RPCR_023: New
        // Implements list of occupations with checkboxes for selections
        // (not to be confused with DCustomerOccupation!)

		public DCustomerOccupations()
		{
			InitializeComponent();
		}

		public int Retrieve(int? in_cust_id)
		{
			int ret = RetrieveCore<CustomerOccupations>(new List<CustomerOccupations>(CustomerOccupations.GetAllCustomerOccupations(in_cust_id)));
			if (this.SortString != "")
				this.Sort<CustomerOccupations>();
			return ret;
		}
	}
}
