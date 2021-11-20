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
	public partial class DGroupDetails : Metex.Windows.DataUserControl
	{
		public DGroupDetails()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_group_id )
		{
			return RetrieveCore<GroupDetails>(new List<GroupDetails>
				(GroupDetails.GetAllGroupDetails( al_group_id )));
		}
	}
}
