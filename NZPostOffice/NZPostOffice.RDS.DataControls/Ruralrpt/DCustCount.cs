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
	public partial class DCustCount : Metex.Windows.DataUserControl
	{
		public DCustCount()
		{
			InitializeComponent();

            this.RetrieveEnd += new EventHandler(DCustCount_RetrieveEnd);
		}

        void DCustCount_RetrieveEnd(object sender, EventArgs e)
        {
            viewer.RefreshReport();
        }

		public int Retrieve( int? inRegion, int? inOutlet, int? inContractType, int? inRenewalGroup )
		{
			return RetrieveCore<CustCount>(new List<CustCount>(CustCount.GetAllCustCount(inRegion, inOutlet, inContractType,inRenewalGroup)));
		}
	}
}
