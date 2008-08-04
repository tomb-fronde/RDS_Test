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
	public partial class DNonVehicleOverrideRates : Metex.Windows.DataUserControl
	{
		public DNonVehicleOverrideRates()
		{
			InitializeComponent();
		}

		public int Retrieve( int? incontract_no, int? incontract_seq_no )
		{
			return RetrieveCore<NonVehicleOverrideRates>(new List<NonVehicleOverrideRates>
                (NonVehicleOverrideRates.GetAllNonVehicleOverrideRates(incontract_no, incontract_seq_no)));
		}
	}
}
