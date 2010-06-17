using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	public partial class DEclContractMapping : Metex.Windows.DataUserControl
	{
		public DEclContractMapping()
		{
			InitializeComponent();
			this.SortString = "ecl_driver_id A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<EclContractMapping>(new List<EclContractMapping>
			(EclContractMapping.GetAllEclContractMapping()));
			if(this.SortString != "")
				this.Sort<EclContractMapping>();
			return ret;
		}

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
	}
}
