using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
//////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	// TJB Frequencies & Allowances  March-2022
	// Changes to handle multiple vehicles per contract
	// Add effective_date to call parameters
	// Add vehicle number to returned values

	public partial class DContractsBenchmark : Metex.Windows.DataUserControl
	{
		public DContractsBenchmark()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_rg_code, DateTime? ad_eff_date )
        {
			return RetrieveCore<ContractsBenchmark>(ContractsBenchmark.GetAllContractsBenchmark(al_rg_code, ad_eff_date));
		}
	}
}
