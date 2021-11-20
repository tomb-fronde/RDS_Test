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
	public partial class DFrequencyTitle : Metex.Windows.DataUserControl
	{
		public DFrequencyTitle()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
			return RetrieveCore<FrequencyTitle>(FrequencyTitle.GetAllFrequencyTitle());
		}
	}
}
