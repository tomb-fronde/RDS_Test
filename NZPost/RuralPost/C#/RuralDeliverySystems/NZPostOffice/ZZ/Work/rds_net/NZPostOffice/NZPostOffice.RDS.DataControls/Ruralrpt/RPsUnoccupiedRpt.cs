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
	public partial class RPsUnoccupiedRpt : Metex.Windows.DataUserControl
	{
		public RPsUnoccupiedRpt()
		{
			InitializeComponent();
		}

		public int Retrieve( int? con_id )
        {
            return RetrieveCore<PsUnoccupiedRpt>(new List<PsUnoccupiedRpt>(PsUnoccupiedRpt.GetAllPsUnoccupiedRpt(con_id)));
		}
	}
}
