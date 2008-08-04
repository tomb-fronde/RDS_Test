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
    public partial class DContractRouteFrequencySelect2001 : Metex.Windows.DataUserControl
	{
		public DContractRouteFrequencySelect2001()
		{
			InitializeComponent();
			InitializeDropdown();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
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

		public int Retrieve( int? in_Contract )
		{
			return RetrieveCore<ContractRouteFrequencySelect2001>(new List<ContractRouteFrequencySelect2001>
				(ContractRouteFrequencySelect2001.GetAllContractRouteFrequencySelect2001( in_Contract )));
		}
        public event EventHandler CellDoubleClick;
	}
}
