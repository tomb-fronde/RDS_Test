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
	public partial class RScheduleaSingleContract : Metex.Windows.DataUserControl
	{
		public RScheduleaSingleContract()
		{
			InitializeComponent();
		}

        public int Retrieve( int? inContract, int? inSequence )
        {
            return RetrieveCore<ScheduleaSingleContract>(new List<ScheduleaSingleContract>(ScheduleaSingleContract.GetAllScheduleaSingleContract(inContract, inSequence)));
		}
	}
}
