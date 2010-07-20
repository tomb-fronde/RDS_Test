using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataControls.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	public partial class DAddAllowance0 : Metex.Windows.DataUserControl
	{
        // TJB RPCR_017 July-2010: Obsolete
        // See DAddAllowance.cs

		public DAddAllowance0()
		{
			InitializeComponent();
			//InitializeDropdown();

            this.contract_title.BorderStyle = BorderStyle.None;
            this.paid_to_date.BorderStyle = BorderStyle.None;

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
			alt_key.AssignDropdownType<DDddwAllowanceTypes>();
		}

		public int Retrieve(int? inContractNo)
        {
			return RetrieveCore<AddAllowance0>(AddAllowance0.GetAllAddAllowance0(inContractNo));
		}
	}
}
