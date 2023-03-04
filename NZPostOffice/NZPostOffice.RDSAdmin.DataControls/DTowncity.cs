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
	public partial class DTowncity : Metex.Windows.DataUserControl
	{
		public DTowncity()
		{
			InitializeComponent();
			InitializeDropdown();
            this.SortString = "tc_name A";
		}

		private void InitializeDropdown()
		{
            region_id.AssignDropdownType<DddwRegion>("RegionId", "RgnName");
		}

		public override int Retrieve(  )
		{
            int ret = RetrieveCore<NZPostOffice.RDSAdmin.Entity.Security.DTowncity>(new List<NZPostOffice.RDSAdmin.Entity.Security.DTowncity>
                (NZPostOffice.RDSAdmin.Entity.Security.DTowncity.GetAllTowncity()));
            if(this.SortString != "")
                this.Sort<NZPostOffice.RDSAdmin.Entity.Security.DTowncity>();
            return ret;
		}
	}
}
