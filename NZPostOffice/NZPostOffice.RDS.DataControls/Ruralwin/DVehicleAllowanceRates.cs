using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  Allowances  28-Mar-2021:  New
    // Data store for vehicle allowance calculations

    public partial class DVehicleAllowanceRates : Metex.Windows.DataUserControl
    {
        public DVehicleAllowanceRates()
        {
            InitializeComponent();
        }

        public int Retrieve(int? in_var_id)
        {
            return RetrieveCore<VehicleAllowanceRates>(VehicleAllowanceRates.GetAllVehicleAllowanceRates(in_var_id));
        }
    }
}
