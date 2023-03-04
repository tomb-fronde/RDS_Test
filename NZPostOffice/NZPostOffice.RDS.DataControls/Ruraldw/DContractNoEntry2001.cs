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
    public partial class DContractNoEntry2001 : Metex.Windows.DataUserControl
	{
		public DContractNoEntry2001()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			sf_key.AssignDropdownType<DDddwStandardFrequency>();
		}


		public override int Retrieve( )
        {
			return RetrieveCore<ContractNoEntry2001>(ContractNoEntry2001.GetAllContractNoEntry2001());
		}
	}
}
