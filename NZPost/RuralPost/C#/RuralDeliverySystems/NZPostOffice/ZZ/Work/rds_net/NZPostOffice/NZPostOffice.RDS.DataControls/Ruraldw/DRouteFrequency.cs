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
    // TJB Frequencies Nov-2020
    // Code tidyup
    // See st_contract in DRouteFrequency.designer
    //
    // TJB  RPCR_044  Jan-2013
    // Added in_showAll in Retrieve
    //    == 0 select only active frequencies
    //    == 1 select all

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

		public int Retrieve( int? in_Contract, int? in_showAll )
		{
            // TJB  RPCR_044  Jan-2013
            // Added in_showAll; == 0 select only active frequencies; == 1 select all
            if (in_showAll == null || in_showAll != 0)
                in_showAll = 1;
            else
                in_showAll = 0;

			return RetrieveCore<RouteFrequency>(new List<RouteFrequency>
				(RouteFrequency.GetAllRouteFrequency(in_Contract, in_showAll)));
		}

        public event EventHandler CellClick;
        public event EventHandler CellDoubleClick;
	}
}
