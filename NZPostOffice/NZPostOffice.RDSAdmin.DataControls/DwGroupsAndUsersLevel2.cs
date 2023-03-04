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
	public partial class DwGroupsAndUsersLevel2 : Metex.Windows.DataUserControl
	{
		public DwGroupsAndUsersLevel2()
		{
			InitializeComponent();
		}

		public int Retrieve( int al_parent_id1 )
		{
			int ret = RetrieveCore<GroupsAndUsersLevel2>( new List<GroupsAndUsersLevel2>(GroupsAndUsersLevel2.GetAllGroupsAndUsersLevel2(al_parent_id1)));
           // Sort();    
            return ret;
        
		}

        private void Sort()
        {
            SortOnce<GroupsAndUsersLevel2>(new Comparison<GroupsAndUsersLevel2>(this.defaultSorter));
        }

        private int defaultSorter(GroupsAndUsersLevel2 s1, GroupsAndUsersLevel2 s2)
        {
            return string.CompareOrdinal(s1.Label, s2.Label);
        }
	}
}
