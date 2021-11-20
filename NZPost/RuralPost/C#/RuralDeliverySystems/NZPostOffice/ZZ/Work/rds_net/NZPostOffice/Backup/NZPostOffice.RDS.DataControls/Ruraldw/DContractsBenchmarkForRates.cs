using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
//?////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    public partial class DContractsBenchmarkForRates : Metex.Windows.DataUserControl
	{
		public DContractsBenchmarkForRates()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_rg_code )
        {
			return RetrieveCore<ContractsBenchmarkForRates>(ContractsBenchmarkForRates.GetAllContractsBenchmarkForRates(al_rg_code));
		}
	}
}
