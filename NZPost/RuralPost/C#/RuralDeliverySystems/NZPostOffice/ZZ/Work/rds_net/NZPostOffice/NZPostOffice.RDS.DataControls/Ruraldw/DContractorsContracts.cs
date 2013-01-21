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
    // TJB  RPCR_045  Jan 2013
    // Added con_date_terminated to displayed values

    public partial class DContractorsContracts : Metex.Windows.DataUserControl
	{
		public DContractorsContracts()
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

		public int Retrieve( int? in_Contractor )
		{
			return RetrieveCore<ContractorsContracts>(new List<ContractorsContracts>
				(ContractorsContracts.GetAllContractorsContracts( in_Contractor )));
		}
        public event EventHandler CellDoubleClick;
	}
}
