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
	public partial class DRouteFreqVerbs : Metex.Windows.DataUserControl
	{
		public DRouteFreqVerbs()
		{
			InitializeComponent();
            this.SortString = "rfv_description A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<RouteFreqVerbs>(new List<RouteFreqVerbs>
                (RouteFreqVerbs.GetAllRouteFreqVerbs()));
            if(this.SortString != "")
                this.Sort<RouteFreqVerbs>();
            return ret;
		}
	}
}
