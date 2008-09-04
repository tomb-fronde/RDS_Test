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
	public partial class DRouteFrequency : Metex.Windows.DataUserControl
	{
		public DRouteFrequency()
		{
			InitializeComponent();
			//InitializeDropdown();

            this.grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
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

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick(sender, e);
            }
        }

		private void InitializeDropdown()
		{
			sf_key.AssignDropdownType<DddwStandardFrequency>();
		}

		public int Retrieve( int? in_Contract )
		{
			return RetrieveCore<RouteFrequency>(new List<RouteFrequency>
				(RouteFrequency.GetAllRouteFrequency(in_Contract)));
		}

        public event EventHandler CellClick;
        public event EventHandler CellDoubleClick;
	}
}
