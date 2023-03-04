using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DwPostTaxDeductions : Metex.Windows.DataUserControl
	{
		public DwPostTaxDeductions()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			pct_id.AssignDropdownType<DDddwPaymentComponents>();
		}

		public int Retrieve( int? as_ded_id )
        {
			return RetrieveCore<PostTaxDeductions>(PostTaxDeductions.GetAllPostTaxDeductions(as_ded_id));
		}
	}
}
