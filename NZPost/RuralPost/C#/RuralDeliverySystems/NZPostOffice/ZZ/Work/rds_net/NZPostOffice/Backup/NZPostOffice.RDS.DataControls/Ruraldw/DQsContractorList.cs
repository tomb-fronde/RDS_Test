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
	public partial class DQsContractorList : Metex.Windows.DataUserControl
	{
		public DQsContractorList()
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

		public int Retrieve( int? supplierno, string suppliername )
		{
			return RetrieveCore<QsContractorList>(new List<QsContractorList>
				(QsContractorList.GetAllQsContractorList(supplierno, suppliername )));
		}

        public event EventHandler CellDoubleClick;
	}
}
