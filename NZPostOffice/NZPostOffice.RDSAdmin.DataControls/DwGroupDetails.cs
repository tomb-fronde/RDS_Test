using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	public partial class DwGroupDetails : Metex.Windows.DataUserControl
    {
        public new bool DesignMode
        {
            get
            {
                return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
            }
        }
		public DwGroupDetails()
		{
			InitializeComponent();
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            this.SortString = "rds_component_rc_description A";
		}

		private void InitializeDropdown()
		{
            rds_user_rights_region_id.AssignDropdownType<GroupRegion>("RegionId", "RgnName");
		}

		public int Retrieve( int al_group_id )
		{
			int ret = RetrieveCore<GroupDetails>(new List<GroupDetails>
                (GroupDetails.GetAllGroupDetails(al_group_id)));
            NZPostOffice.Shared.StaticFunctions.ClearDeleteBuffer(this);
            //if(this.SortString != "" && this.SortString != null)
            //    this.Sort<GroupDetails>();
            return ret;
		}
	}
}
