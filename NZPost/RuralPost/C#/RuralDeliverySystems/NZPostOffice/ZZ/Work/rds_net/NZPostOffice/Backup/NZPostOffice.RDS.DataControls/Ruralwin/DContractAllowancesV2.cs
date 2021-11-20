using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	public partial class DContractAllowancesV2 : Metex.Windows.DataUserControl
	{
		public DContractAllowancesV2()
		{
			InitializeComponent();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender, e);
            }
        }

		public int Retrieve( int? inContractNo )
        {
            //compute column 
            decimal? total = 0;
            List<ContractAllowancesV2> rstList = new List<ContractAllowancesV2>(ContractAllowancesV2.GetAllContractAllowancesV2(inContractNo));

            foreach (ContractAllowancesV2 contractAllowancesV2 in rstList)
            {
                if (contractAllowancesV2.NetAmount != null)
                {
                    total += contractAllowancesV2.NetAmount;
                }
            }

            allowance_total.Text = "$" + string.Format("{0:#,##0.00}", total);
			return RetrieveCore<ContractAllowancesV2>(ContractAllowancesV2.GetAllContractAllowancesV2(inContractNo));
		}

        public event EventHandler CellDoubleClick;

	}
}
