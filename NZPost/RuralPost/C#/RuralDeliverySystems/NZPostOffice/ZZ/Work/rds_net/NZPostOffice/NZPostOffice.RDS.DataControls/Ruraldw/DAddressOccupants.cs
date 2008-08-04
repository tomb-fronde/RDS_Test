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
	public partial class DAddressOccupants : Metex.Windows.DataUserControl
	{
		public DAddressOccupants()
		{
			InitializeComponent();
			InitializeDropdown();

            grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender, e);
            }
        }

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick(sender, e);
            }
        }

        public Metex.Windows.DataEntityGrid Grid
        {
            get { return this.grid; }
        }

		private void InitializeDropdown()
		{
            master_cust_id.AssignDropdownType<DddwPrimContactsForAnAddress>("CustId", "CustomerName");
		}

		public int Retrieve( int? al_adr_id )
		{
			return RetrieveCore<AddressOccupants>(new List<AddressOccupants>
				(AddressOccupants.GetAllAddressOccupants( al_adr_id )));
		}

        public event EventHandler CellClick;
        public event EventHandler CellDoubleClick;
	}
}
