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
    // TJB  RPCR_122  July-2018
    // Added in_PbuId to retrieve parameter list

	public partial class DContractListing : Metex.Windows.DataUserControl
	{
		public DContractListing()
		{
			InitializeComponent();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender,e);
            }
        }

		public int Retrieve( int? in_Region, int? in_Contract, string in_ContractTitle, string in_ConMSN
                           , DateTime? in_LastServiceStart, DateTime? in_LastServiceEnd
                           , DateTime? in_LastDelStart, DateTime? in_LastDelEnd
                           , DateTime? in_LastWorkStart, DateTime? in_LastWorkEnd
                           , int? in_ContractType, int? in_PbuId )
		{
			return RetrieveCore<ContractListing>(new List<ContractListing>(ContractListing.GetAllContractListing( in_Region, in_Contract, in_ContractTitle
                                , in_ConMSN, in_LastServiceStart, in_LastServiceEnd, in_LastDelStart
                                , in_LastDelEnd, in_LastWorkStart, in_LastWorkEnd, in_ContractType, in_PbuId)));
		}

        public event EventHandler CellDoubleClick;
	}
}
