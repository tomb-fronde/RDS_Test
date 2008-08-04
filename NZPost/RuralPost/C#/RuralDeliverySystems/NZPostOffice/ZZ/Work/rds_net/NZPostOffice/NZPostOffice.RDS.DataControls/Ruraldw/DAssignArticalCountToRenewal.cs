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
    public partial class DAssignArticalCountToRenewal : Metex.Windows.DataUserControl
	{
		public DAssignArticalCountToRenewal()
		{
			InitializeComponent();
            this.grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick(sender, e);
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender, e);
            }
        }

		public int Retrieve( int? in_Contract )
		{
			return RetrieveCore<AssignArticalCountToRenewal>(new List<AssignArticalCountToRenewal>
				(AssignArticalCountToRenewal.GetAllAssignArticalCountToRenewal( in_Contract )));
		}

        public event EventHandler CellClick;
        public event EventHandler CellDoubleClick;
	}
}
