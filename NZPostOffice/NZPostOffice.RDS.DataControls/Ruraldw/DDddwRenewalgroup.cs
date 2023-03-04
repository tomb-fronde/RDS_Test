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
            this.SortString = "rg_description A";
            this.Sort<DddwRenewalgroup>();
            return li_count;
		}
	}
}
