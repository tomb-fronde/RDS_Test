using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralsec;
//?//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralsec
{
	public partial class DUserGroupRights : Metex.Windows.DataUserControl
	{
		public DUserGroupRights()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_groupid )
        {
            return RetrieveCore<UserGroupRights>(new List<UserGroupRights>(UserGroupRights.GetAllUserGroupRights(al_groupid)),new Comparison<UserGroupRights>(name_ascending),null);
		}
        private int name_ascending<T>(T x,T y)
        {
            UserGroupRights X = x as UserGroupRights;
            UserGroupRights Y = y as UserGroupRights;
            return String.Compare(X.Name, Y.Name, StringComparison.Ordinal);
        }
	}
}
