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
	public partial class DNonVehicleRates2005 : Metex.Windows.DataUserControl
	{
		public DNonVehicleRates2005()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			rg_code.AssignDropdownType<DDddwRenewalGroups>();
		}

		public int Retrieve( int? inRGCode, DateTime? in_EffectDate )
        {
			return RetrieveCore<NonVehicleRates2005>(NonVehicleRates2005.GetAllNonVehicleRates2005(inRGCode, in_EffectDate));
		}
	}
}
