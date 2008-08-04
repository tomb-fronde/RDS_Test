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
	public partial class RPsCustListTown : Metex.Windows.DataUserControl
	{
		public RPsCustListTown()
		{
			InitializeComponent();
		}

		public int Retrieve( int? town_id )
        {
            return RetrieveCore<PsCustListTown>(new List<PsCustListTown>(PsCustListTown.GetAllPsCustListTown(town_id)));
		}
	}
}
