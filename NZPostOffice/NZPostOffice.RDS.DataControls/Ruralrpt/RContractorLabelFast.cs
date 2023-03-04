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
	public partial class RContractorLabelFast : Metex.Windows.DataUserControl
	{
		public RContractorLabelFast()
		{
			InitializeComponent();
		}

        private int ai_inregion = 0;
        private string ai_incontractor = string.Empty;
        private int ai_incontracttype = 0;
        private int ai_inrengroup = 0;
        private int ai_inoutlet = 0;
        private int ai_incontracts = 0;
        private string ai_incontractflag = string.Empty;

        public int Retrieve(int? inregion, string incontractor, int? incontracttype, int? inrengroup, int? inoutlet, int? incontracts, string incontractflag)
		{
            ai_inregion = inregion.GetValueOrDefault();
            ai_incontractor = incontractor;
            ai_incontracttype = incontracttype.GetValueOrDefault();
            ai_inrengroup = inrengroup.GetValueOrDefault();
            ai_inoutlet = inoutlet.GetValueOrDefault();
            ai_incontracts = incontracts.GetValueOrDefault();
            ai_incontractflag = incontractflag;
            int ret = RetrieveCore<ContractorLabelFast>(new List<ContractorLabelFast>
                (ContractorLabelFast.GetAllContractorLabelFast(inregion, incontractor, incontracttype, inrengroup, inoutlet, incontracts, incontractflag)));
            this.viewer.RefreshReport();
            return ret;
		}
	}
}
