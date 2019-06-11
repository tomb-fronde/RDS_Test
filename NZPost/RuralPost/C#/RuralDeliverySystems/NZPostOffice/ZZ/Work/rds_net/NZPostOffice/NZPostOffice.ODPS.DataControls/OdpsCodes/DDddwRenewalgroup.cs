using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsCodes;
////using NZPostOffice.ODPS.DataControls.EpDropdowns;

namespace NZPostOffice.ODPS.DataControls.OdpsCodes
{
    // TJB RPCR_140 June-2019: Copied from RDS.DataControls.Ruraldw

	public partial class DDddwRenewalgroup : Metex.Windows.DataUserControl
	{
		public DDddwRenewalgroup()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
            int li_count;
			li_count = RetrieveCore<DddwRenewalgroup>(DddwRenewalgroup.GetAllDddwRenewalgroup());
            this.SortString = "rg_description D";
            this.Sort<DddwRenewalgroup>();
            return li_count;
		}
	}
}
