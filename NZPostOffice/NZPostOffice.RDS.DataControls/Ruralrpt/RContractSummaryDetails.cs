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
	public partial class RContractSummaryDetails : Metex.Windows.DataUserControl
	{
		public RContractSummaryDetails()
		{
			InitializeComponent();
		}

        private int ai_inContract = 0;
        private int ai_inSequence = 0;
		public int Retrieve( int? inContract, int? inSequence )
        {
            ai_inContract = inContract.GetValueOrDefault();
            ai_inSequence = inSequence.GetValueOrDefault();
            int ret = RetrieveCore<ContractSummaryDetails>(new List<ContractSummaryDetails>(ContractSummaryDetails.GetAllContractSummaryDetails(inContract, inSequence)));
            this.viewer.RefreshReport();
            return ret;

		}
	}
}
