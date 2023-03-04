using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
//?wjtang //using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DConCriteria : Metex.Windows.DataUserControl
	{
		public DConCriteria()
		{
			InitializeComponent();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
                CellDoubleClick(sender, e);
        }

		public override int Retrieve()
        {
			return RetrieveCore<ConCriteria>(ConCriteria.GetAllConCriteria());
		}

        public event EventHandler CellDoubleClick;
	}
}
