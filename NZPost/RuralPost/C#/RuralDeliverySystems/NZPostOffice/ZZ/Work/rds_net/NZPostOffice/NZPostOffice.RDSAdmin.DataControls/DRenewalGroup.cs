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
	public partial class DRenewalGroup : Metex.Windows.DataUserControl
	{
		public DRenewalGroup()
		{
			InitializeComponent();
            this.SortString = "rg_description A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<RenewalGroup>(new List<RenewalGroup>
                (RenewalGroup.GetAllRenewalGroup()));
            if(this.SortString  != "")
                this.Sort<RenewalGroup>();
            return ret;
		}
	}
}
