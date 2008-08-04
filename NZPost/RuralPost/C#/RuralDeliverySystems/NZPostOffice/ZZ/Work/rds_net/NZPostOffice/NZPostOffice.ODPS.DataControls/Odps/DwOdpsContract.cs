using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Odps;
using NZPostOffice.ODPS.DataControls.OdpsCodes;

namespace NZPostOffice.ODPS.DataControls.Odps
{
	public partial class DwOdpsContract : Metex.Windows.DataUserControl
	{
		public DwOdpsContract()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			pbu_id.AssignDropdownType<DddwPbuCode>();
			ac_id.AssignDropdownType<DddwAccountId>();
		}

		public int Retrieve( int? in_Contract )
        {
			return RetrieveCore<OdpsContract>(OdpsContract.GetAllOdpsContract(in_Contract));
		}
	}
}
