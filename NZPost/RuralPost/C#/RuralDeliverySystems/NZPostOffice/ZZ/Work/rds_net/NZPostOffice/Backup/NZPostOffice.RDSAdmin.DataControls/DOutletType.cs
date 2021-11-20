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
	public partial class DOutletType : Metex.Windows.DataUserControl
	{
		public DOutletType()
		{
			InitializeComponent();
            this.SortString = "ot_outlet_type A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<OutletType>(new List<OutletType>
                (OutletType.GetAllOutletType()));
            if(this.SortString != "")
                this.Sort<OutletType>();
            return ret;
		}
	}
}
