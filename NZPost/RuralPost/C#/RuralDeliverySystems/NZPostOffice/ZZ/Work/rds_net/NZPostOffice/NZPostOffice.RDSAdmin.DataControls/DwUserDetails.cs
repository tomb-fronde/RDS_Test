using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Windows;
using NZPostOffice.RDSAdmin.Entity.Security;
//!using NZPostOffice.RDSAdmin.DataControls.EpDropdowns;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
    // TJB  RPCR_117  July-2018 (in Designer)
    // Changed rds_user_u_phone to rds_user_u_email
    // and RdsUserUPhone to RdsUserUEmail

	public partial class DwUserDetails : Metex.Windows.DataUserControl
	{
		public DwUserDetails()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			rds_user_region_id.AssignDropdownType<DddwUserRegion>();
		}

		public int Retrieve(int al_user_id )
		{
			return RetrieveCore<UserDetails>( new List<UserDetails>(UserDetails.GetAllUserDetails(al_user_id)));
		}
	}
}
