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
	public partial class DListContractsForProcessing2001 : Metex.Windows.DataUserControl
	{
		public DListContractsForProcessing2001()
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

		public int Retrieve( int? in_Region, int? in_RgCode, int? in_Contract )
		{
			return RetrieveCore<ListContractsForProcessing2001>(new List<ListContractsForProcessing2001>
				(ListContractsForProcessing2001.GetAllListContractsForProcessing2001(in_Region, in_RgCode, in_Contract)));
		}

        public event EventHandler CellDoubleClick;
	}
}
