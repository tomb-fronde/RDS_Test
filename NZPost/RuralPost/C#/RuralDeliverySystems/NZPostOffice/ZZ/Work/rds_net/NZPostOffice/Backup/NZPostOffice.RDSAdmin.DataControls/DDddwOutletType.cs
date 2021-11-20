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
	public partial class DDddwOutletType : Metex.Windows.DataUserControl
	{
		public DDddwOutletType()
		{
			InitializeComponent();
            this.SortString = "ot_outlet_type A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<DddwOutletType>( new List<DddwOutletType>(DddwOutletType.GetAllDddwOutletType()));
            this.Sort<DddwOutletType>();
            return ret;
		}
	}
}
