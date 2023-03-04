using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RContractorLabel : Metex.Windows.DataUserControl
	{
		public RContractorLabel()
		{
			InitializeComponent();
		}

        private int ai_region = 0;
        private string ai_contractor = string.Empty;
        private int ai_contract_type = 0;
        private int ai_renewal_group = 0;
        private int ai_outlet = 0;
        private int ai_contract = 0;
        private string ai_contractflag = string.Empty;
		public int Retrieve( int? region, string contractor, int? contract_type, int? renewal_group, int? outlet, int? contract, string contractflag )
		{
            ai_region = region.GetValueOrDefault();
            ai_contractor = contractor;
            ai_contract_type = contract_type.GetValueOrDefault();
            ai_renewal_group = renewal_group.GetValueOrDefault();
            ai_outlet = outlet.GetValueOrDefault();
            ai_contract = contract.GetValueOrDefault();
            ai_contractflag = contractflag;
            int ret = RetrieveCore<ContractorLabel>(new List<ContractorLabel>
                (ContractorLabel.GetAllContractorLabel(region, contractor, contract_type, renewal_group, outlet, contract, contractflag)));
            this.viewer.RefreshReport();
            return ret;
		}
	}
}
