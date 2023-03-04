using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DCustListTown : Metex.Windows.DataUserControl
	{
		public DCustListTown()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			town_list.AssignDropdownType<DTownList>();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<CustListTown>(new List<CustListTown>
				(CustListTown.GetAllCustListTown(  )));
		}
	}
}
