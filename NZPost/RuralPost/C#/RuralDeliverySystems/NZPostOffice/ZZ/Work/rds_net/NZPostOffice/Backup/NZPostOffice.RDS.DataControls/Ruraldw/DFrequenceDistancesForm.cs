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
	public partial class DFrequenceDistancesForm : Metex.Windows.DataUserControl
	{
		public DFrequenceDistancesForm()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inContract, int? inSFKey, string inDeliveryDays )
        {
			return RetrieveCore<FrequenceDistancesForm>(FrequenceDistancesForm.GetAllFrequenceDistancesForm(inContract, inSFKey, inDeliveryDays));
		}
	}
}
