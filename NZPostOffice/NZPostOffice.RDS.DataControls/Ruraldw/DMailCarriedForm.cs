using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
//////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DMailCarriedForm : Metex.Windows.DataUserControl
	{
		public DMailCarriedForm()
		{
			InitializeComponent();
		}

        void up_pcklst_bmp_Click(object sender, EventArgs e)
        {
            if (CellButtonClick != null)
            {
                CellButtonClick(sender,e);
            }
        }

		public int Retrieve( int? inContract, int? inSFKey, string inDeliveryDays )
        {
			return RetrieveCore<MailCarriedForm>(MailCarriedForm.GetAllMailCarriedForm(inContract, inSFKey, inDeliveryDays));
		}

        public event EventHandler CellButtonClick;
	}
}
