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
	public partial class ROutletLabel : Metex.Windows.DataUserControl
	{
		public ROutletLabel()
		{
			InitializeComponent();
		}

        private int ai_in_region = 0;
        private int ai_in_phy_flag = 0;

        public int Retrieve(int? in_Region, int? in_phyFlag)
		{
            ai_in_region = in_Region.GetValueOrDefault();
            ai_in_phy_flag = in_phyFlag.GetValueOrDefault();
            int ret = RetrieveCore<OutletLabel>(new List<OutletLabel>(OutletLabel.GetAllOutletLabel(in_Region, in_phyFlag)));
            this.viewer.RefreshReport();
            return ret;
		}
	}
}
