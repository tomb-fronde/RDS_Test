using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class ROutletBaseOfficeReport : Metex.Windows.DataUserControl
	{
		public ROutletBaseOfficeReport()
		{
			InitializeComponent();
		}

        private int ai_in_region = 0;

		public int Retrieve(int? inRegion)
        {
            ai_in_region = inRegion.GetValueOrDefault();
            int ret = RetrieveCore<OutletBaseOfficeReport>(new List<OutletBaseOfficeReport>(OutletBaseOfficeReport.GetAllOutletBaseOfficeReport(inRegion)));
            this.viewer.RefreshReport();
            return ret;
		}
	}
}
