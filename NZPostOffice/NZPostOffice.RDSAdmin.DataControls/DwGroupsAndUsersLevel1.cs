using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;
//!using NZPostOffice.RDSAdmin.DataControls.EpDropdowns;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	public partial class DwGroupsAndUsersLevel1 : Metex.Windows.DataUserControl
	{
		public DwGroupsAndUsersLevel1()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<GroupsAndUsersLevel1>( new List<GroupsAndUsersLevel1>(GroupsAndUsersLevel1.GetAllGroupsAndUsersLevel1()));
            Sort();
            return ret;
		}

        private void Sort()
        {
            SortOnce<GroupsAndUsersLevel1>(new Comparison<GroupsAndUsersLevel1>(this.defaultSorter));
        }

        private int defaultSorter(GroupsAndUsersLevel1 s1, GroupsAndUsersLevel1 s2)
        {
            if (s1.Id > s2.Id)
            {
                return 1;
            }
            else if (s1.Id < s2.Id)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
	}
}
