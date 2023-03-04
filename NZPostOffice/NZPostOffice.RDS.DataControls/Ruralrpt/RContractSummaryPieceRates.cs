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
	public partial class RContractSummaryPieceRates : Metex.Windows.DataUserControl
	{
		public RContractSummaryPieceRates()
		{
			InitializeComponent();
		}


        private int ai_inContract = 0;
        private int ai_mo = 0;
        private int ai_yr = 0;
		public int Retrieve( int? inContract, int? mo, int? yr )
        {
            ai_inContract = inContract.GetValueOrDefault();
            ai_mo = mo.GetValueOrDefault();
            ai_yr = yr.GetValueOrDefault();
            int ret = RetrieveCore<ContractSummaryPieceRates>(new List<ContractSummaryPieceRates>(ContractSummaryPieceRates.GetAllContractSummaryPieceRates(inContract, mo, yr)));
            this.viewer.RefreshReport();
            return ret;
		}
	}
}
