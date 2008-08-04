using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DDddwPrimContactsForAnAddress : Metex.Windows.DataUserControl
	{
		public DDddwPrimContactsForAnAddress()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_adr_id )
        {
			return RetrieveCore<DddwPrimContactsForAnAddress>(DddwPrimContactsForAnAddress.GetAllDddwPrimContactsForAnAddress(al_adr_id));
		}
	}
}
