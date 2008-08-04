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
	public partial class DRenewalArticalCountsTest : Metex.Windows.DataUserControl
	{
        public DRenewalArticalCountsTest()
		{
			InitializeComponent();            
		}

		public int Retrieve( int? in_Contract, int? in_Sequence )
		{
			return RetrieveCore<RenewalArticalCounts>(new List<RenewalArticalCounts>
				(RenewalArticalCounts.GetAllRenewalArticalCounts( in_Contract, in_Sequence )));
		}
	}
}
