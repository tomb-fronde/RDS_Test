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
	public partial class DWhatifCalculatorReport2001bf5 : Metex.Windows.DataUserControl
	{
		public DWhatifCalculatorReport2001bf5()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inContract, int? inSequence, int? inRGCode, DateTime? inEffectDate, string inVolumeSource )
		{
			return RetrieveCore<WhatifCalculatorReport2001bf5>(new List<WhatifCalculatorReport2001bf5>
				(WhatifCalculatorReport2001bf5.GetAllWhatifCalculatorReport2001bf5(inContract, inSequence, inRGCode, inEffectDate, inVolumeSource )));
		}
	}
}
