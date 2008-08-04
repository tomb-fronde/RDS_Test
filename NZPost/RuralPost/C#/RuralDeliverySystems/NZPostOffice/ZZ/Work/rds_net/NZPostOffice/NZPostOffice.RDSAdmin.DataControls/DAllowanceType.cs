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
	public partial class DAllowanceType : Metex.Windows.DataUserControl
	{
		public DAllowanceType()
		{
			InitializeComponent();
            this.SortString = "alt_description A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<AllowanceType>(new List<AllowanceType>
                (AllowanceType.GetAllAllowanceType()));
            if(this.SortString != "")
                this.Sort<AllowanceType>();
            return ret;
		}
	}
}
