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
	public partial class DFuelOverrideFields : Metex.Windows.DataUserControl
	{
		public DFuelOverrideFields()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			al_renewal_group.AssignDropdownType<DDddwRenewalGroups>();
		}

		public override int Retrieve( )
        {
			return RetrieveCore<FuelOverrideFields>(FuelOverrideFields.GetAllFuelOverrideFields());
		}
	}
}
