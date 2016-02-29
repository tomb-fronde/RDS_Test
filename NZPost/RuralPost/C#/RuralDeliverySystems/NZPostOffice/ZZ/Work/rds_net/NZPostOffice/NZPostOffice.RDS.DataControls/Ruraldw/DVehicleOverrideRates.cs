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
    // TJB  RPCR_101  Feb 2016
    // Changed "Livery" to "Vehicle Allowance"

	public partial class DVehicleOverrideRates : Metex.Windows.DataUserControl
	{
		public DVehicleOverrideRates()
		{
			InitializeComponent();
            // TJB  RD7:0038  Nov-2009:  Moved from designer; allows nulls to be entered
            this.vor_nominal_vehicle_value.DataBindings[0].DataSourceNullValue = null;
            this.vor_nominal_vehicle_value.DataBindings[0].NullValue = "";
            this.vor_repairs_maintenance_rate.DataBindings[0].DataSourceNullValue = null;
            this.vor_repairs_maintenance_rate.DataBindings[0].NullValue = "";
            this.vor_tyre_tubes_rate.DataBindings[0].DataSourceNullValue = null;
            this.vor_tyre_tubes_rate.DataBindings[0].NullValue = "";
            this.vor_vehical_allowance_rate.DataBindings[0].DataSourceNullValue = null;
            this.vor_vehical_allowance_rate.DataBindings[0].NullValue = "";
            this.vor_licence_rate.DataBindings[0].DataSourceNullValue = null;
            this.vor_licence_rate.DataBindings[0].NullValue = "";
            this.vor_vehicle_rate_of_return_pct.DataBindings[0].DataSourceNullValue = null;
            this.vor_vehicle_rate_of_return_pct.DataBindings[0].NullValue = "";
            this.vor_salvage_ratio.DataBindings[0].DataSourceNullValue = null;
            this.vor_salvage_ratio.DataBindings[0].NullValue = "";
            this.vor_ruc.DataBindings[0].DataSourceNullValue = null;
            this.vor_ruc.DataBindings[0].NullValue = "";
            this.vor_sundries_k.DataBindings[0].DataSourceNullValue = null;
            this.vor_sundries_k.DataBindings[0].NullValue = "";
            this.vor_vehicle_insurance_premium.DataBindings[0].DataSourceNullValue = null;
            this.vor_vehicle_insurance_premium.DataBindings[0].NullValue = "";
            this.vor_fuel_rate.DataBindings[0].DataSourceNullValue = null;
            this.vor_fuel_rate.DataBindings[0].NullValue = "";
            this.vor_consumption_rate.DataBindings[0].DataSourceNullValue = null;
            this.vor_consumption_rate.DataBindings[0].NullValue = "";
            this.vor_livery.DataBindings[0].DataSourceNullValue = null;
            this.vor_livery.DataBindings[0].NullValue = "";

            this.vor_nominal_vehicle_value.Validated += new System.EventHandler(Value_Validated);
            this.vor_repairs_maintenance_rate.Validated += new System.EventHandler(Value_Validated);
            this.vor_tyre_tubes_rate.Validated += new System.EventHandler(Value_Validated);
            this.vor_vehical_allowance_rate.Validated += new System.EventHandler(Value_Validated);
            this.vor_licence_rate.Validated += new System.EventHandler(Value_Validated);
            this.vor_vehicle_rate_of_return_pct.Validated += new System.EventHandler(Value_Validated);
            this.vor_salvage_ratio.Validated += new System.EventHandler(Value_Validated);
            this.vor_ruc.Validated += new System.EventHandler(Value_Validated);
            this.vor_sundries_k.Validated += new System.EventHandler(Value_Validated);
            this.vor_vehicle_insurance_premium.Validated += new System.EventHandler(Value_Validated);
            this.vor_fuel_rate.Validated += new System.EventHandler(Value_Validated);
            this.vor_consumption_rate.Validated += new System.EventHandler(Value_Validated);
            this.vor_livery.Validated += new System.EventHandler(Value_Validated);

            ActiveEvent();
		}

        private void ActiveEvent()
        {
            foreach (Control var in this.Controls)
            {
                var.GotFocus += new System.EventHandler(var_GotFocus);
            }
        }

        void Value_Validated(object sender, System.EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
            }
            else
            {
                ((TextBox)sender).Text = System.Math.Round(System.Convert.ToDecimal(((TextBox)sender).Text), 2).ToString("0.00");
            }
        }

		public int Retrieve( int? incontract_no, int? incontract_seq_no )
        {
			return RetrieveCore<VehicleOverrideRates>(VehicleOverrideRates.GetAllVehicleOverrideRates(incontract_no, incontract_seq_no));
		}

        public event EventHandler TextBoxLostFocus;

        private void TextBox_LostFocus(object sender, System.EventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }
        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }
	}
}
