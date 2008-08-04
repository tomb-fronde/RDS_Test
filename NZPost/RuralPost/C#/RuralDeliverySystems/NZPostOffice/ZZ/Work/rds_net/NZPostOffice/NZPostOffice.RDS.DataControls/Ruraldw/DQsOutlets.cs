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
	public partial class DQsOutlets : Metex.Windows.DataUserControl
	{
		public DQsOutlets()
		{
			InitializeComponent();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender, e);
            }
        }

		public int Retrieve( int? in_Region, string in_Outlet )
		{
			return RetrieveCore<QsOutlets>(new List<QsOutlets>
				(QsOutlets.GetAllQsOutlets( in_Region, in_Outlet )));
		}

        public event EventHandler CellDoubleClick;
	}
}
