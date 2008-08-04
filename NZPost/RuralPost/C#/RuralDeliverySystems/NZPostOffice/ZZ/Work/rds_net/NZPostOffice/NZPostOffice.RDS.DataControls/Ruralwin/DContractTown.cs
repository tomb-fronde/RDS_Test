using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	public partial class DContractTown : Metex.Windows.DataUserControl
	{
		public DContractTown()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			//tc_name.AssignDropdownType<DDddwTown>();
		}

		public int Retrieve( int? in_contract )
        {
			return RetrieveCore<ContractTown>(ContractTown.GetAllContractTown(in_contract));
		}
	}
}
