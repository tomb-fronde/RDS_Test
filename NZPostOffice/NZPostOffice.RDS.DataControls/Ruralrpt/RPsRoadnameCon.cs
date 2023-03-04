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
	public partial class RPsRoadnameCon : Metex.Windows.DataUserControl
	{
		public RPsRoadnameCon()
		{
			InitializeComponent();
		}

		public int Retrieve( int? con_id )
        {
            return RetrieveCore<PsRoadnameCon>(new List<PsRoadnameCon>(PsRoadnameCon.GetAllPsRoadnameCon(con_id)));
		}
	}
}
