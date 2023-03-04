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
	public partial class DUiIdDetails : Metex.Windows.DataUserControl
	{
		public DUiIdDetails()
		{
			InitializeComponent();
            ui_last_login_time.DataBindings["Text"].FormatString = "HH:mm:ss";
		}

		public int Retrieve( int? al_user_id )
		{
			return RetrieveCore<UiIdDetails>( new List<UiIdDetails>(UiIdDetails.GetAllUiIdDetails(al_user_id)));
		}

        private void unlock_button_Click(object sender, EventArgs e)
        {
            if (lockClick != null)
            {
                this.lockClick(sender, e);
            }
        }
        public event EventHandler lockClick;
	}
}
