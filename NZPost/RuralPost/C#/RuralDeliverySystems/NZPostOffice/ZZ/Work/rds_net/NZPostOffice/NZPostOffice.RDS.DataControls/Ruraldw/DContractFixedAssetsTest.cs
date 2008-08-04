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
    public partial class DContractFixedAssets : Metex.Windows.DataUserControl
	{
        public DContractFixedAssets()
		{
			InitializeComponent();
		}

		public int Retrieve( int? contract_no )
		{
			return RetrieveCore<ContractFixedAssets>(new List<ContractFixedAssets>
				(ContractFixedAssets.GetAllContractFixedAssets( contract_no )));
		}
	}
}
