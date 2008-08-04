using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataControls.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	public partial class DAddAllowance : Metex.Windows.DataUserControl
	{
		public DAddAllowance()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			alt_key.AssignDropdownType<DDddwAllowanceTypes>();
		}

		public int Retrieve(int? inContractNo)
        {
			return RetrieveCore<AddAllowance>(AddAllowance.GetAllAddAllowance(inContractNo));
		}
	}
}
