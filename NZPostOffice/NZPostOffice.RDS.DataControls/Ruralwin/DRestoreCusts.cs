using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	public partial class DRestoreCusts : Metex.Windows.DataUserControl
	{
		public DRestoreCusts()
		{
			InitializeComponent();

            grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick(sender, e);
            }
        }

		public int Retrieve( int? in_addr_id )
		{
			return RetrieveCore<RestoreCusts>(new List<RestoreCusts>
				(RestoreCusts.GetAllRestoreCusts(in_addr_id )));
		}

        public event EventHandler CellClick;
        public event EventHandler CellDoubleClick;
	}
}
