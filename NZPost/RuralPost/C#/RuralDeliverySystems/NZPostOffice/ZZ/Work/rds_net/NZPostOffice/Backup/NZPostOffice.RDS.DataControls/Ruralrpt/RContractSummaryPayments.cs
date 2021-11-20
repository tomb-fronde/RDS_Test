using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RContractSummaryPayments : Metex.Windows.DataUserControl
	{
		public RContractSummaryPayments()
		{
			InitializeComponent();
		}

        private int ai_contract = 0;
        private int ai_renewal = 0;
		public int Retrieve( int? contract, int? renewal )
        {
            ai_contract = contract.GetValueOrDefault();
            ai_renewal = renewal.GetValueOrDefault();
            int ret = RetrieveCore<ContractSummaryPayments>(new List<ContractSummaryPayments>(ContractSummaryPayments.GetAllContractSummaryPayments(contract, renewal)));
            this.viewer.RefreshReport();
            return ret;
		}
	}
}
