using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin2;

namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
	public partial class DWhatifCalculatorReport2005 : Metex.Windows.DataUserControl
	{
		public DWhatifCalculatorReport2005()
		{
			InitializeComponent();
		}

        public int Retrieve(int? inContract, int? inSequence, int? inRGCode, DateTime? inEffectDate, string inVolumeSource)
		{
			return RetrieveCore<WhatifCalculatorReport2005>(new List<WhatifCalculatorReport2005>
				(WhatifCalculatorReport2005.GetAllWhatifCalculatorReport2005( inContract, inSequence, inRGCode, inEffectDate, inVolumeSource )));
		}

        public void Print()
        {
            this.viewer.PrintReport();
        }
	}
}
