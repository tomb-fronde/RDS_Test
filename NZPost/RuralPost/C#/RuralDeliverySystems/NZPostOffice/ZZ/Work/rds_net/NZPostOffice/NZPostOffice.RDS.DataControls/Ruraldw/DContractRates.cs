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
    public partial class DContractRates : Metex.Windows.DataUserControl
	{
		public DContractRates()
		{
			InitializeComponent();
		}

		public int Retrieve( int? contract_no, int? contract_seq_number )
		{
			return RetrieveCore<ContractRates>(new List<ContractRates>
				(ContractRates.GetAllContractRates( contract_no, contract_seq_number )));
		}
	}
}
