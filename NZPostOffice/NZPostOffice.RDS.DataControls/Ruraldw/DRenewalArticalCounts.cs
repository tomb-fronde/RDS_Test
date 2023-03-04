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
    // TJB  RPCR_093  Feb-2015
    // Hide references to Large Parcels

	public partial class DRenewalArticalCountsTest : Metex.Windows.DataUserControl
	{
        public DRenewalArticalCountsTest()
		{
			InitializeComponent();

            ac_w1_large_parcels.Visible = false;
            ac_w2_large_parcels.Visible = false;
            compute_4.Visible = false;
		}

		public int Retrieve( int? in_Contract, int? in_Sequence )
		{
			return RetrieveCore<RenewalArticalCounts>(new List<RenewalArticalCounts>
				(RenewalArticalCounts.GetAllRenewalArticalCounts( in_Contract, in_Sequence )));
		}
	}
}
