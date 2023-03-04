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
	public partial class DUserGroupRights : Metex.Windows.DataUserControl
	{
		public DUserGroupRights()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_groupid )
		{
			return RetrieveCore<UserGroupRights>(new List<UserGroupRights>
                (UserGroupRights.GetAllUserGroupRights(al_groupid)));
		}
	}
}
