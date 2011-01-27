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
    public partial class DContractAddressFrequency : Metex.Windows.DataUserControl
	{
        // TJB  Sequencing review  Jan-2011: New
        // Lists all frequencies associated with a contract, with selection 
        // checkboxes for those associated with a specified address.  Updates 
        // address_frequency table when changes made.

		public DContractAddressFrequency()
		{
			InitializeComponent();
			//InitializeDropdown();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            
            base.OnHandleCreated(e);
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender, e);
            }
        }

		private void InitializeDropdown()
		{
			sf_key.AssignDropdownType<DddwStandardFrequency>();
		}

        public int Retrieve(int? in_Contract, int? in_AdrId)
		{
			return RetrieveCore<ContractAddressFrequency>(new List<ContractAddressFrequency>
                (ContractAddressFrequency.GetAllContractAddressFrequency(in_Contract, in_AdrId)));
		}
        public event EventHandler CellDoubleClick;
	}
}
