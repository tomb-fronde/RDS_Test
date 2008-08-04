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
	}
}
