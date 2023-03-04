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
	public partial class DNpadParameters : Metex.Windows.DataUserControl
	{
		public DNpadParameters()
		{
			InitializeComponent();
			InitializeDropdown();
            this.RowFocusChanged += new EventHandler(DNpadParameters_RowFocusChanged);
		}

		private void InitializeDropdown()
		{
            npad_userid.AssignDropdownType<Username>("UiUserid", "UName");
		}

		public override int Retrieve(  )
		{
			return RetrieveCore<NpadParameters>(new List<NpadParameters>
				(NpadParameters.GetAllNpadParameters(  )));
		}

        private int? old_focusrow = null;
        void DNpadParameters_RowFocusChanged(object sender, EventArgs args)
        {
            if (old_focusrow != null)
                this.grid.Rows[(int)old_focusrow].Cells["npad_userid"].ReadOnly = true;
            try
            {
                this.grid.Rows[this.GetRow()].Cells["npad_userid"].ReadOnly = false;
                old_focusrow = this.GetRow();
            }
            catch (Exception ex)
            { }
        }

	}
}
