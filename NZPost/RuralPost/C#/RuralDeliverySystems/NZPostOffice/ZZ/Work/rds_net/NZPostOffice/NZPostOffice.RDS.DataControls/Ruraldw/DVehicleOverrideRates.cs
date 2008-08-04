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
