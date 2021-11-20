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
	public partial class DRouteFreqPointType : Metex.Windows.DataUserControl
	{
		public DRouteFreqPointType()
		{
			InitializeComponent();
            this.SortString = "rfpt_description A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<RouteFreqPointType>(new List<RouteFreqPointType>
				(RouteFreqPointType.GetAllRouteFreqPointType(  )));
            if(this.SortString != "")
                this.Sort<RouteFreqPointType>();
            return ret;
		}
	}
}
