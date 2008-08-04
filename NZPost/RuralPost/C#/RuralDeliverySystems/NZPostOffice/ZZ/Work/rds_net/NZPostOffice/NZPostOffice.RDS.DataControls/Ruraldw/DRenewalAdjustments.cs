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
	public partial class DRenewalAdjustments : Metex.Windows.DataUserControl
	{
		public DRenewalAdjustments()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			pct_id.AssignDropdownType<DddwPaymentComponents>();
		}

		public int Retrieve( int? in_Contract, int? in_Sequence )
		{
			return RetrieveCore<RenewalAdjustments>(new List<RenewalAdjustments>
				(RenewalAdjustments.GetAllRenewalAdjustments(in_Contract, in_Sequence )));
		}
	}
}
