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
        // TJB  Frequencies & Vehicles  22-Jan-2021
        // Added vehicle_number to retrieve parameters
        //
        // TJB  RPCR_041  Nov-2012
        // Added references to nvor_relief_weeks

		public DNonVehicleOverrideRates()
		{
			InitializeComponent();
            // TJB  RD7:0038  Nov-2009:  Added to allow nulls to be entered
            this.nvor_relief_weeks.DataBindings[0].DataSourceNullValue = null;
            this.nvor_relief_weeks.DataBindings[0].NullValue = "";
            this.nvor_processing_wage_rate.DataBindings[0].DataSourceNullValue = null;
            this.nvor_processing_wage_rate.DataBindings[0].NullValue = "";
            this.nvor_delivery_wage_rate.DataBindings[0].DataSourceNullValue = null;
            this.nvor_delivery_wage_rate.DataBindings[0].NullValue = "";
            this.nvor_public_liability_rate.DataBindings[0].DataSourceNullValue = null;
            this.nvor_public_liability_rate.DataBindings[0].NullValue = "";
            this.nvor_carrier_risk_rate.DataBindings[0].DataSourceNullValue = null;
            this.nvor_carrier_risk_rate.DataBindings[0].NullValue = "";
            this.nvor_item_proc_rate_per_hour.DataBindings[0].DataSourceNullValue = null;
            this.nvor_item_proc_rate_per_hour.DataBindings[0].NullValue = "";
            this.nvor_accounting.DataBindings[0].DataSourceNullValue = null;
            this.nvor_accounting.DataBindings[0].NullValue = "";
            this.nvor_telephone.DataBindings[0].DataSourceNullValue = null;
            this.nvor_telephone.DataBindings[0].NullValue = "";
            this.nvor_sundries.DataBindings[0].DataSourceNullValue = null;
            this.nvor_sundries.DataBindings[0].NullValue = "";
            this.nvor_acc_rate.DataBindings[0].DataSourceNullValue = null;
            this.nvor_acc_rate.DataBindings[0].NullValue = "";
            this.nvor_acc_rate_amount.DataBindings[0].DataSourceNullValue = null;
            this.nvor_acc_rate_amount.DataBindings[0].NullValue = "";
            this.nvor_uniform.DataBindings[0].DataSourceNullValue = null;
            this.nvor_uniform.DataBindings[0].NullValue = "";

            this.nvor_relief_weeks.Validated += new System.EventHandler(this.Value_Validated);
            this.nvor_processing_wage_rate.Validated += new System.EventHandler(this.Value_Validated);
            this.nvor_delivery_wage_rate.Validated += new System.EventHandler(this.Value_Validated);
            this.nvor_public_liability_rate.Validated += new System.EventHandler(this.Value_Validated);
            this.nvor_carrier_risk_rate.Validated += new System.EventHandler(this.Value_Validated);
            this.nvor_item_proc_rate_per_hour.Validated += new System.EventHandler(this.Value_Validated);
            this.nvor_accounting.Validated += new System.EventHandler(this.Value_Validated);
            this.nvor_telephone.Validated += new System.EventHandler(this.Value_Validated);
            this.nvor_sundries.Validated += new System.EventHandler(this.Value_Validated);
            this.nvor_acc_rate.Validated += new System.EventHandler(this.Value_Validated);
            this.nvor_acc_rate_amount.Validated += new System.EventHandler(this.Value_Validated);
            this.nvor_uniform.Validated += new System.EventHandler(this.Value_Validated);

            ActiveEvent();
		}

        private void ActiveEvent()
        {
            foreach (Control var in this.Controls)
            {
                var.GotFocus += new System.EventHandler(var_GotFocus);
            }
        }

        // TJB  Frequencies & Vehicles  22-Jan-2021
        // Added vehicle_number to parameters
        public int Retrieve(int? incontract_no, int? incontract_seq_number, int? invehicle_number)
		{
			return RetrieveCore<NonVehicleOverrideRates>(new List<NonVehicleOverrideRates>
                (NonVehicleOverrideRates.GetAllNonVehicleOverrideRates(incontract_no, incontract_seq_number, invehicle_number)));
		}

        // TJB  RD7_0038  Nov-2009:  Added 
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

        // TJB  RD7_0038  Nov-2009:  Added 
        public event EventHandler TextBoxLostFocus;

        private void TextBox_LostFocus(object sender, System.EventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }

        // TJB  RD7_0038  Nov-2009:  Added 
        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }
	}
}
