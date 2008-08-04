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
	public partial class DRoadSuffix : Metex.Windows.DataUserControl
	{
		public DRoadSuffix()
		{
			InitializeComponent();
            this.SortString = "rs_name A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<RoadSuffix>(new List<RoadSuffix>
				(RoadSuffix.GetAllRoadSuffix(  )));
            if(this.SortString != "")
                this.Sort<RoadSuffix>();
            return ret;
		}
	}
}
