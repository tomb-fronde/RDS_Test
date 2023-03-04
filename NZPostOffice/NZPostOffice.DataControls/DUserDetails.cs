using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.Entity;

namespace NZPostOffice.DataControls
{
	public partial class DUserDetails : Metex.Windows.DataUserControl
	{
		public DUserDetails()
		{
			InitializeComponent();
		}

		public int Retrieve( string as_username )
		{
			return RetrieveCore<UserDetails>(new List<UserDetails>
				(UserDetails.GetAllUserDetails( as_username )));
		}
	}
}
