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
    public partial class DContractorDs : Metex.Windows.DataUserControl
	{
        public DContractorDs()
		{
			InitializeComponent();
		}

        void grid_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            if (this.grid.CurrentColumnName == "cd_old_ds_no")
            {
                this.grid.EndEdit();
            }

        }

		public int Retrieve( int? in_Contractor )
		{
			return RetrieveCore<ContractorDs>(new List<ContractorDs>
				(ContractorDs.GetAllContractorDs( in_Contractor )));
		}
	}
}
