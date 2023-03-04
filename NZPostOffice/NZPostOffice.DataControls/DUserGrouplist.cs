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
	public partial class DUserGrouplist : Metex.Windows.DataUserControl
	{
		public DUserGrouplist()
		{
			InitializeComponent();
		}

		public int Retrieve( string as_userid )
		{
			return RetrieveCore<UserGrouplist>(new List<UserGrouplist>
                (UserGrouplist.GetAllUserGrouplist(as_userid)));
		}
	}
}
