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
	public partial class DRenewals : Metex.Windows.DataUserControl
	{
		public DRenewals()
		{
			InitializeComponent();
            this.grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
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

		public int Retrieve( int? in_Contract )
		{
			return RetrieveCore<Renewals>(new List<Renewals>
				(Renewals.GetAllRenewals( in_Contract )));
		}

        public event EventHandler CellClick;
        public event EventHandler CellDoubleClick;
	}
}
