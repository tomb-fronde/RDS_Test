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
	public partial class DRoadType : Metex.Windows.DataUserControl
	{
		public DRoadType()
		{
			InitializeComponent();
            this.SortString = "rt_name A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<RoadType>(new List<RoadType>
                (RoadType.GetAllRoadType()));
            if(this.SortString != "")
                this.Sort<RoadType>();
            return ret;
		}
	}
}
