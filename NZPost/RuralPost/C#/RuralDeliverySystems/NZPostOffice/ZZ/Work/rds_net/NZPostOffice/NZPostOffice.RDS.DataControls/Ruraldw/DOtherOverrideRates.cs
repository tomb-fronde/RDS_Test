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
    // TJB  Frequencies & Vehicles  22-Jan-2021
    // Added vehicle_number to retrieve parameters
    
    public partial class DOtherOverrideRates : Metex.Windows.DataUserControl
	{
		public DOtherOverrideRates()
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

        // TJB  Frequencies & Vehicles  22-Jan-2021
        // Added vehicle_number to parameters
        public int Retrieve(int? incontract_no, int? incontract_seq_number, int? invehicle_number)
		{
			return RetrieveCore<OtherOverrideRates>(new List<OtherOverrideRates>
				(OtherOverrideRates.GetAllOtherOverrideRates( incontract_no, incontract_seq_number, invehicle_number )));
		}

        public void DOtherOverrideRates_RetrieveEnd(object sender, EventArgs e)
        {
            if (this.bindingSource.Count > 0)
            {
                panel1.Visible = true;
                st_renewal.Visible = false;
            }
            else
            {
                panel1.Visible = false;
                st_renewal.Visible = true;
            }
        }
	}
}
