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
    // [9-Jul-2021]Changed Fuel use heading (in designer) to "Fuel Use 100Km" (was 1000Km)

	public partial class DVehicleAllowanceRates : Metex.Windows.DataUserControl
	{
		public DVehicleAllowanceRates()
		{
			InitializeComponent();
            this.SortString = "var_id A";

            // For dates, it sets the prompt to '\0' instead of '0'
            this.var_effective_date.PromptChar = '0';
            this.var_effective_date.Mask = "00/00/0000";
            this.var_effective_date.ValueType = typeof(System.DateTime);

            // These settings allow the row height to adjust to the text if it wraps.
            this.var_notes.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.var_notes.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
