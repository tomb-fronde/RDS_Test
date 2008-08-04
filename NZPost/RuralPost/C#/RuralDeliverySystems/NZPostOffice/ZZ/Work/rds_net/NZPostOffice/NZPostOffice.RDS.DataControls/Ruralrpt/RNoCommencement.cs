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
	public partial class RNoCommencement : Metex.Windows.DataUserControl
	{
		public RNoCommencement()
		{
			InitializeComponent();
		}

        private int days = 0;
        private int region = 0;
        private string privacy_override = string.Empty;

		public int Retrieve(int? ldays, int? lregion, string as_privacy_override)
        {
            days = ldays.GetValueOrDefault();
            region = lregion.GetValueOrDefault();
            privacy_override = as_privacy_override;
            int ret = RetrieveCore<NoCommencement>(new List<NoCommencement>(NoCommencement.GetAllNoCommencement(ldays, lregion, as_privacy_override)));
            this.viewer.RefreshReport();
            return ret;
		}
	}
}
