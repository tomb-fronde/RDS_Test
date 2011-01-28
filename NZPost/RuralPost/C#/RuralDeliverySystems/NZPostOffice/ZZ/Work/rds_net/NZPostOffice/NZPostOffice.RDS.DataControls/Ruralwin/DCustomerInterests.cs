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
		public DCustomerInterests()
		{
			InitializeComponent();
			this.SortString = "contract_type A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<CustomerInterests>(new List<CustomerInterests>(CustomerInterests.GetAllContractType()));
			if (this.SortString != "")
				this.Sort<CustomerInterests>();
			return ret;
		}
	}
}
