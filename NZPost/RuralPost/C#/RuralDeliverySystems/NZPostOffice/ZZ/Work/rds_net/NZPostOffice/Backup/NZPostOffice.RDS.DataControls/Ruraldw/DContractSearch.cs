using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.DataControls;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  RPCR_122 Bug  July-2018
    // Lost Region dropdown size change - reinstated (in designer)
    //
    // TJB  RPCR_140  June-2019
    // contract_no_Leave event handler added
    //
    // TJB  RPCR_122  July-2018
    // Added PBU_Id dropdown assignment here
    // Added PBUCode label and dropdown select element in Designer

    public partial class DContractSearch : Metex.Windows.DataUserControl
	{
		public DContractSearch()
		{
			InitializeComponent();
			InitializeDropdown();
            InitialzeChildControlFocused();
		}

		private void InitializeDropdown()
		{
			ct_key.AssignDropdownType<DDddwContractTypes>();
			region_id.AssignDropdownType<DDddwRegions>();
            pbu_id.AssignDropdownType<DDddwPbuCodes>();
        }

		public override int Retrieve( )
		{
			return RetrieveCore<ContractSearch>(new List<ContractSearch>
				(ContractSearch.GetAllContractSearch(  )));
		}
        public event EventHandler ChildControlClick;
        private void InitialzeChildControlFocused()
        {
            foreach (Control c in this.Controls)
            {
                c.Click += new EventHandler(c_Click);
            }
        }

        private void c_Click(object sender, EventArgs e)
        {
            if (ChildControlClick != null)
            {
                ChildControlClick(sender, e);
            }
        }

        // TJB  RPCR_140  June-2019: Added
        // Appears necessary to ensure ContractNo in ContractSearch entity
        // (its bindingsource) is updated .
        // - a bindingsource refresh might have the same effect?
        private void contract_no_Leave(object sender, EventArgs e)
        {
            this.AcceptText();
        }
	}
}
