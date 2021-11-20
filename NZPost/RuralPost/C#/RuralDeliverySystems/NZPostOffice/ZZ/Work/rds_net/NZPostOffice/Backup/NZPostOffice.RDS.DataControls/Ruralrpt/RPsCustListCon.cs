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
	public partial class RPsCustListCon : Metex.Windows.DataUserControl
	{
		public RPsCustListCon()
		{
			InitializeComponent();
		}

		public int Retrieve( int? con_id )
        {
            return RetrieveCore<PsCustListCon>(new List<PsCustListCon>(PsCustListCon.GetAllPsCustListCon(con_id)));
		}
	}
}
