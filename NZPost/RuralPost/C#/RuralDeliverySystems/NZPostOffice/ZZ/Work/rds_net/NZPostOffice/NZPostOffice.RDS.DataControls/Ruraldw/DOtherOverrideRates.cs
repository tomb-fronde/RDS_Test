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
	public partial class DOtherOverrideRates : Metex.Windows.DataUserControl
	{
		public DOtherOverrideRates()
		{
			InitializeComponent();
		}

		public int Retrieve( int? incontract_no, int? incontract_seq_no )
		{
			return RetrieveCore<OtherOverrideRates>(new List<OtherOverrideRates>
				(OtherOverrideRates.GetAllOtherOverrideRates( incontract_no, incontract_seq_no )));
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
