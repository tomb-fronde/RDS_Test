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
	public partial class DNonVehicleRates2001 : Metex.Windows.DataUserControl
	{
		public DNonVehicleRates2001()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			//?rg_code.AssignDropdownType<DDddwRenewalGroups>();
		}

		public int Retrieve( int? inRGCode, DateTime? in_EffectDate )
        {
			return RetrieveCore<NonVehicleRates2001>(NonVehicleRates2001.GetAllNonVehicleRates2001(inRGCode, in_EffectDate));
		}
	}
}
