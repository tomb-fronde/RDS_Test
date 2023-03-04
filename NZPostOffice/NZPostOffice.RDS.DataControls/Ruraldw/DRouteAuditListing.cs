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
	public partial class DRouteAuditListing : Metex.Windows.DataUserControl
	{
		public DRouteAuditListing()
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

		public int Retrieve( int? contract )
		{
            int ll_return = RetrieveCore<RouteAuditListing>(new List<RouteAuditListing>
				(RouteAuditListing.GetAllRouteAuditListing( contract )));
            this.SortString = "ra_date_of_check D";
            this.Sort<RouteAuditListing>();
            return ll_return;

		}

        public event EventHandler CellClick;
        public event EventHandler CellDoubleClick;
	}
}
