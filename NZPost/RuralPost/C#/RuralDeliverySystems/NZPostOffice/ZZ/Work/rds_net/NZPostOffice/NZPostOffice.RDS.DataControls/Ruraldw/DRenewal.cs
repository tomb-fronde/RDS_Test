using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DRenewal : Metex.Windows.DataUserControl
	{
		public DRenewal()
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
			con_rg_code_at_renewal.AssignDropdownType<DDddwRenewalgroup>();
		}

		public int Retrieve( int? in_ContractNo, int? in_ContractSeq )
		{
			return RetrieveCore<Renewal>(new List<Renewal>
				(Renewal.GetAllRenewal( in_ContractNo, in_ContractSeq )));
		}
	}
}
