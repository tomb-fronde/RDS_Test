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
    public partial class DContractorInfo : Metex.Windows.DataUserControl
	{
		public DContractorInfo()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_contract_no )
        {
			return RetrieveCore<ContractorInfo>(ContractorInfo.GetAllContractorInfo(al_contract_no));
		}
	}
}
