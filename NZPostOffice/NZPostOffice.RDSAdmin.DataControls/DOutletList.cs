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
	public partial class DOutletList : Metex.Windows.DataUserControl
	{
		public DOutletList()
		{
			InitializeComponent();
            this.SortString = "o_name A";
		}

		public int Retrieve( int region_id )
		{
			int ret = RetrieveCore<OutletList>(new List<OutletList>
				(OutletList.GetAllOutletList( region_id )));
            if(this.SortString != "")
                this.Sort<OutletList>();
            return ret;
		}
	}
}
