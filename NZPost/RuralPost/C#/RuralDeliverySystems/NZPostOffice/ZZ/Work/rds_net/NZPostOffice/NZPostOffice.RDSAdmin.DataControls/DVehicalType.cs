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
	public partial class DVehicalType : Metex.Windows.DataUserControl
	{
		public DVehicalType()
		{
			InitializeComponent();
            this.SortString = "vt_description A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<VehicalType>(new List<VehicalType>
                (VehicalType.GetAllVehicalType()));
            if(this.SortString != "" && this.SortString != null)
                this.Sort<VehicalType>();
            return ret;
		}
	}
}
