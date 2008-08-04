using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	public partial class DwGroupsAndUsersLevel3 : Metex.Windows.DataUserControl
	{
		public DwGroupsAndUsersLevel3()
		{
			InitializeComponent();
		}

        public int Retrieve(int al_parent_id1, int al_parent_id2)
		{
			int ret = RetrieveCore<GroupsAndUsersLevel3>(new List<GroupsAndUsersLevel3>
				(GroupsAndUsersLevel3.GetAllGroupsAndUsersLevel3( al_parent_id1, al_parent_id2 )));
            this.Sort();
            return ret;
		}

        private void Sort()
        {
            SortOnce<GroupsAndUsersLevel3>(new Comparison<GroupsAndUsersLevel3>(this.defaultSorter));
        }

        private int defaultSorter(GroupsAndUsersLevel3 s1, GroupsAndUsersLevel3 s2)
        {
            return string.CompareOrdinal(s1.Label, s2.Label);
        }
    }
}
