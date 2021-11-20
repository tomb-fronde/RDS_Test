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
    public partial class DContractAllowances : Metex.Windows.DataUserControl
	{
		public DContractAllowances()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			alt_key.AssignDropdownType<DDddwAllowanceTypes>();
			pct_id.AssignDropdownType<DDddwPaymentComponents>();
		}

		public int Retrieve( int? in_Contract )
		{
			return RetrieveCore<ContractAllowances>(new List<ContractAllowances>
				(ContractAllowances.GetAllContractAllowances( in_Contract )));
		}
	}
}
