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
	public partial class DUserComponentRegionlist : Metex.Windows.DataUserControl
	{
		public DUserComponentRegionlist()
		{
			InitializeComponent();
		}

		public int Retrieve( string as_userid, string as_componentname )
        {
            return RetrieveCore<UserComponentRegionlist>(new List<UserComponentRegionlist>(UserComponentRegionlist.GetAllUserComponentRegionlist(as_userid, as_componentname)));
		}
	}
}
