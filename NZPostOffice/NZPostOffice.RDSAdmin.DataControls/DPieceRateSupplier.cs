using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
    // TJB  RPCR_054  July-2013
    // Added pct_id and payment component type dropdown

	public partial class DPieceRateSupplier : Metex.Windows.DataUserControl
	{
		public DPieceRateSupplier()
		{
			InitializeComponent();
            InitializeDropdown();
            this.SortString = "prs_description A";
		}

        private void InitializeDropdown()
        {
            pct_id.AssignDropdownType<PaymentComponentTypes>("PctId", "PctDescription");
        }

        public override int Retrieve()
		{
			int ret = RetrieveCore<PieceRateSupplier>(new List<PieceRateSupplier>(PieceRateSupplier.GetAllPieceRateSupplier()));
            if(this.SortString != "")
                this.Sort<PieceRateSupplier>();
            return ret;
		}

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
	}
}
