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
    // TJB  RPCR_101  Feb 2016
    // Changed "Livery" to "Vehicle Allowance"
    // Changed "$ pa" to "$ p/a"

	public partial class DVehicleRates2001 : Metex.Windows.DataUserControl
	{
		public DVehicleRates2001()
		{
			InitializeComponent();
		}

		public int Retrieve( int? in_vt_key, DateTime? in_effective_date )
        {
			return RetrieveCore<VehicleRates2001>(VehicleRates2001.GetAllVehicleRates2001(in_vt_key, in_effective_date));
		}
	}
}
