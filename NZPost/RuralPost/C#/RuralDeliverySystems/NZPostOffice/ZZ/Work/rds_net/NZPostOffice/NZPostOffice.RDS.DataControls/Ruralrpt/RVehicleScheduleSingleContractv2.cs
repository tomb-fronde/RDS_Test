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
	public partial class RVehicleScheduleSingleContractv2 : Metex.Windows.DataUserControl
	{
		public RVehicleScheduleSingleContractv2()
		{
			InitializeComponent();
		}

        private int u_inSequence = 0;
		public int Retrieve( int? incontract, int? inSequence )
        {
            u_inSequence = inSequence.GetValueOrDefault();
            int ret =  RetrieveCore<VehicleScheduleSingleContractv2>(new List<VehicleScheduleSingleContractv2>(VehicleScheduleSingleContractv2.GetAllVehicleScheduleSingleContractv2(incontract, inSequence)));
            return ret;
		}
	}
}
