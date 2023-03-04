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
	public partial class DFrequencyAnnotation : Metex.Windows.DataUserControl
	{
		public DFrequencyAnnotation()
		{
			InitializeComponent();
		}

		public int Retrieve( int? contractno, int? sfkey, string rf_deliverydays )
        {
			return RetrieveCore<FrequencyAnnotation>(FrequencyAnnotation.GetAllFrequencyAnnotation(contractno, sfkey, rf_deliverydays));
		}
	}
}
