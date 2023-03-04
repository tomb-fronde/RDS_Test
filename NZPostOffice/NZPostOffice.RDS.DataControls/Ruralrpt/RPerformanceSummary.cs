using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RPerformanceSummary : Metex.Windows.DataUserControl
	{
		public RPerformanceSummary()
		{
			InitializeComponent();
		}

        private int ai_in_region = 0;
        private DateTime adt_in_month = DateTime.MinValue;

		public int Retrieve( int? inRegion, DateTime? inMonth )
        {
            ai_in_region = inRegion.GetValueOrDefault();
            adt_in_month = inMonth.GetValueOrDefault();

            int ret = RetrieveCore<PerformanceSummary>(new List<PerformanceSummary>(PerformanceSummary.GetAllPerformanceSummary(inRegion, inMonth)));
            viewer.RefreshReport();
            return ret;
		}
	}
}
