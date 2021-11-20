using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
	public partial class DwUserId : Metex.Windows.DataUserControl
	{
		public DwUserId()
		{
			InitializeComponent();
		}

		public int Retrieve( string a_user_id, string a_password )
        {
			return RetrieveCore<UserId>(UserId.GetAllUserId(a_user_id, a_password));
		}
	}
}
