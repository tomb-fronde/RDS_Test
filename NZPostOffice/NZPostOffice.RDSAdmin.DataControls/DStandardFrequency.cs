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
	public partial class DStandardFrequency : Metex.Windows.DataUserControl
	{
		public DStandardFrequency()
		{
			InitializeComponent();
            this.SortString = "sf_description A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<StandardFrequency>(new List<StandardFrequency>
                (StandardFrequency.GetAllStandardFrequency()));
            if(this.SortString != "")
                this.Sort<StandardFrequency>();
            return ret;
		}
	}
}
