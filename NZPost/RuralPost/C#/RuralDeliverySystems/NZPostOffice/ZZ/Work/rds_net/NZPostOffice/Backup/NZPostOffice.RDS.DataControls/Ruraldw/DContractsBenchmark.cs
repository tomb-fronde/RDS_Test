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
    public partial class DContractsBenchmark : Metex.Windows.DataUserControl
	{
		public DContractsBenchmark()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_rg_code )
        {
			return RetrieveCore<ContractsBenchmark>(ContractsBenchmark.GetAllContractsBenchmark(al_rg_code));
		}
	}
}
