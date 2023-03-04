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
	public partial class DFrequenceDistances : Metex.Windows.DataUserControl
	{
		public DFrequenceDistances()
		{
			InitializeComponent();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender, e);
            }
        }

		public int Retrieve( int? inContract, int? inSFKey, string inDeliveryDays )
		{
			return RetrieveCore<FrequenceDistances>(new List<FrequenceDistances>
				(FrequenceDistances.GetAllFrequenceDistances(inContract, inSFKey, inDeliveryDays )));
		}

        public event EventHandler CellDoubleClick;
	}
}
