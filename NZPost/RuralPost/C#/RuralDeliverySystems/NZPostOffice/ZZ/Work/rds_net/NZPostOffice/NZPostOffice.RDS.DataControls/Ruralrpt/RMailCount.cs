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
	public partial class RMailCount : Metex.Windows.DataUserControl
	{
		public RMailCount()
		{
			InitializeComponent();
		}

        private int ai_contract = 0;

		public int Retrieve(int? contract)
        {
            ai_contract = contract.GetValueOrDefault();
            int ret = RetrieveCore<MailCount>(new List<MailCount>(MailCount.GetAllMailCount(contract)));
            this.viewer.RefreshReport();
            return ret;
		}
	}
}
