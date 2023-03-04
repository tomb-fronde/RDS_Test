using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DQsRouteTerminationList : Metex.Windows.DataUserControl
	{
		public DQsRouteTerminationList()
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

		public int Retrieve( int? contract, string street_name )
        {
			return RetrieveCore<QsRouteTerminationList>(QsRouteTerminationList.GetAllQsRouteTerminationList(contract, street_name));
		}
        public event EventHandler CellDoubleClick;
	}
}
