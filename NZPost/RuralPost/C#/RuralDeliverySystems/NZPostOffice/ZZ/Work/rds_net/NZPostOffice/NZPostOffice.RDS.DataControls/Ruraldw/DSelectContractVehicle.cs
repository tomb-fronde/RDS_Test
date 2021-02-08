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
    // TJB Frequencies & Vehicles Jan-2021  NEW
    // List a contract's vehicles - used by WSelectContractVehicle
    // A bit later, added grid_CellDoubleClick

	public partial class DSelectContractVehicle : Metex.Windows.DataUserControl
	{
        public DSelectContractVehicle()
		{
			InitializeComponent();
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
        }

		public int Retrieve( int? in_Contract, int? in_Sequence )
		{
            return RetrieveCore<SelectContractVehicle>(new List<SelectContractVehicle>
                (SelectContractVehicle.GetAllSelectContractVehicle(in_Contract, in_Sequence)));
		}

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender, e);
            }
        }
        public event EventHandler CellDoubleClick;
    }
}
