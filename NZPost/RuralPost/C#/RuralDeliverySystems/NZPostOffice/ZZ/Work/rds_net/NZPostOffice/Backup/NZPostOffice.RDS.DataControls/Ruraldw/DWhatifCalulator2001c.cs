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
	public partial class DWhatifCalulator2001c : Metex.Windows.DataUserControl
	{
		public DWhatifCalulator2001c()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inContract, int? inSequence, int? inRGCode, DateTime? inEffectDate, string inVolumeSource )
		{
			return RetrieveCore<WhatifCalulator2001c>(new List<WhatifCalulator2001c>
				(WhatifCalulator2001c.GetAllWhatifCalulator2001c( inContract, inSequence, inRGCode, inEffectDate, inVolumeSource )));
		}
	}
}
