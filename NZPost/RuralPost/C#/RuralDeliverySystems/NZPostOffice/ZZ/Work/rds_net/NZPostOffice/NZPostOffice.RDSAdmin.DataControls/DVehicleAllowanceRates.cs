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
    // TJB  Allowances 21-Apr-2021: New
    // Form for maintenance of vehicle_allowance_rates table

	public partial class DVehicleAllowanceRates : Metex.Windows.DataUserControl
	{
		public DVehicleAllowanceRates()
		{
			InitializeComponent();
            this.SortString = "var_id A";
		}

        public override int Retrieve()
		{
			int ret = RetrieveCore<VehicleAllowanceRates>(new List<VehicleAllowanceRates>
                (VehicleAllowanceRates.GetAllVehicleAllowanceRates()));
            if(this.SortString != "")
                this.Sort<VehicleAllowanceRates>();
            return ret;
		}
	}
}
