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
    // TJB Allowances 9-Mar-2021: New
    // Updated DContractAllowancesV2 with additional fields (notably ca_notes)

    public partial class DContractAllowancesV3 : Metex.Windows.DataUserControl
	{
		public DContractAllowancesV3()
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
            List<ContractAllowancesV3> rstList = new List<ContractAllowancesV3>(ContractAllowancesV3.GetAllContractAllowancesV3(inContractNo));

            foreach (ContractAllowancesV3 contractAllowancesV3 in rstList)
            {
                if (contractAllowancesV3.NetAmount != null)
                {
                    total += contractAllowancesV3.NetAmount;
                }
            }

            allowance_total.Text = "$" + string.Format("{0:#,##0.00}", total);
			return RetrieveCore<ContractAllowancesV3>(ContractAllowancesV3.GetAllContractAllowancesV3(inContractNo));
		}

        public event EventHandler CellDoubleClick;

	}
}
