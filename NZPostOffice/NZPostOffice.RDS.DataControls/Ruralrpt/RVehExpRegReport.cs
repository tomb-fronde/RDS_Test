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
	public partial class RVehExpRegReport : Metex.Windows.DataUserControl
	{
		public RVehExpRegReport()
		{
			InitializeComponent();
		}

		public int Retrieve( int? reg_id )
        {
            return RetrieveCore<VehExpRegReport>(new List<VehExpRegReport>(VehExpRegReport.GetAllVehExpRegReport(reg_id)));
		}
	}
}
