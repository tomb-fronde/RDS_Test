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
	public partial class DwOdpsContractAdjustments : Metex.Windows.DataUserControl
	{
		public DwOdpsContractAdjustments()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			pct_id.AssignDropdownType<DddwPaymentComponentType>();
		}

        public int Retrieve(int? in_Contract, int? in_Sequence, int? in_Contractor)
        {
			return RetrieveCore<OdpsContractAdjustments>(OdpsContractAdjustments.GetAllOdpsContractAdjustments(in_Contract, in_Sequence, in_Contractor));
		}
	}
}
