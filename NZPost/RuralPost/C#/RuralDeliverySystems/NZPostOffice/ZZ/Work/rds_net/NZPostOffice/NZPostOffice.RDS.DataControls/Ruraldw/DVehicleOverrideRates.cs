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
	public partial class DVehicleOverrideRates : Metex.Windows.DataUserControl
	{
		public DVehicleOverrideRates()
		{
			InitializeComponent();

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
