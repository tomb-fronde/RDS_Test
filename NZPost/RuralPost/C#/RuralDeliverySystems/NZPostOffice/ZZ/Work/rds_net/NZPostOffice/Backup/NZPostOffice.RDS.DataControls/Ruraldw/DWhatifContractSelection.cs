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
	public partial class DWhatifContractSelection : Metex.Windows.DataUserControl
	{
		public DWhatifContractSelection()
		{
			InitializeComponent();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender,e);
            }
        }

        public int Retrieve(int? inRegion, int? inRGCode, int? inRegion1, int? inRGCode1)
		{
			return RetrieveCore<WhatifContractSelection>(new List<WhatifContractSelection>
				(WhatifContractSelection.GetAllWhatifContractSelection( inRegion, inRGCode, inRegion1, inRGCode1 )));
		}

        public event EventHandler CellDoubleClick;
	}
}
