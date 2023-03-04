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
    // TJB  SOW (AP export file format change)  Dec-2013
    // Add supplier_no
    //
    // TJB  AP export file format change  Jan-2014: Bug fix
    // Disabled this.grid.CurrentCellDirtyStateChanged event handler
    //    (moved from designer)

    public partial class DContractorDs : Metex.Windows.DataUserControl
	{
        public DContractorDs()
		{
			InitializeComponent();
            //this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(grid_CurrentCellDirtyStateChanged);//added by ylwang
        }
/*
        void grid_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            if (this.grid.CurrentColumnName == "cd_old_ds_no"
                || this.grid.CurrentColumnName == "supplier_no")
            {
                this.grid.EndEdit();
            }
        }
*/
		public int Retrieve( int? in_Contractor )
		{
			return RetrieveCore<ContractorDs>(new List<ContractorDs>
				(ContractorDs.GetAllContractorDs( in_Contractor )));
		}
	}
}
