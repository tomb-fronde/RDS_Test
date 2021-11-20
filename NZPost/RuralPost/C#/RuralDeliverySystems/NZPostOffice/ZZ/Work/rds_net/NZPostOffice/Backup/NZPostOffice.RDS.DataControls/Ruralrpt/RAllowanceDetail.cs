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
	public partial class RAllowanceDetail : Metex.Windows.DataUserControl
	{
		public RAllowanceDetail()
		{
			InitializeComponent();
		}


        private int ai_inRegionId = 0;
        private int ai_inRgCode = 0;
        private int ai_inCtKey = 0;

		public int Retrieve( int? inRegionId, int? inRgCode, int? inCtKey )
        {
            ai_inRegionId = inRegionId.GetValueOrDefault();
            ai_inRgCode = inRgCode.GetValueOrDefault();
            ai_inCtKey = inCtKey.GetValueOrDefault();
            int ret = RetrieveCore<AllowanceDetail>(new List<AllowanceDetail>(AllowanceDetail.GetAllAllowanceDetail(inRegionId, inRgCode, inCtKey)));
            this.viewer.RefreshReport();
            return ret;
		}
	}
}
