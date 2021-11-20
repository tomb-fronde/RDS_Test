using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.DataControls;


namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    public partial class DContract : Metex.Windows.DataUserControl
	{
		public DContract()
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
			ct_key.AssignDropdownType<DDddwContractTypes>();
            ac_id.AssignDropdownType<DDddwAccountCodes>();
            pbu_id.AssignDropdownType<DDddwPbuCodes>();
            rg_code.AssignDropdownType<DDddwRenewalgroup>();
        }

		public int Retrieve( int? in_Contract )
        {
			return RetrieveCore<Contract>(Contract.GetAllContract(in_Contract));
		}
	}
}
