using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin2;
////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
	public partial class DsFrequencyDistances : Metex.Windows.DataUserControl
	{
		public DsFrequencyDistances()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_contractNo, DateTime? ad_renewal_start )
        {
            return RetrieveCore<FrequencyDistances>(new List<FrequencyDistances>(FrequencyDistances.GetAllFrequencyDistances(al_contractNo, ad_renewal_start)));
		}
	}
}
