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
	public partial class DUserGroups : Metex.Windows.DataUserControl
	{
		public DUserGroups()
		{
			InitializeComponent();
		}

		public int Retrieve( string as_userid )
		{
			return RetrieveCore<UserGroups>(new List<UserGroups>
                (UserGroups.GetAllUserGroups(as_userid)));
		}
	}
}
