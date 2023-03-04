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
	public partial class DwTownDddw : Metex.Windows.DataUserControl
	{
		public DwTownDddw()
		{
			InitializeComponent();
			//InitializeDropdown();
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            
            base.OnHandleCreated(e);
        }

		private void InitializeDropdown()
		{
            tc_id.AssignDropdownType<DddwTowncity>();
            tc_id.InnerDataUserControl.Retrieve();
		}

		public override int Retrieve(  )
		{
			return RetrieveCore<TownDddw>( new List<TownDddw>(TownDddw.GetAllTownDddw()));
		}

        public NZPostOffice.RDSAdmin.Entity.Security.DddwTowncity GetItemFromDropDown()
        {
            return tc_id.SelectedItem as NZPostOffice.RDSAdmin.Entity.Security.DddwTowncity;
        }
	}
}
