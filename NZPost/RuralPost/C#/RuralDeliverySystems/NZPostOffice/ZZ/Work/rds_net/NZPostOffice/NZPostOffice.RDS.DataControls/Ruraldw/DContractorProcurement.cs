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
    public partial class DContractorProcurement : Metex.Windows.DataUserControl
	{
		public DContractorProcurement()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
            proc_id.AssignDropdownType<DddwProcurement>("ProcId", "ProcName");
		}

		public int Retrieve( int? in_contractor )
		{
			return RetrieveCore<ContractorProcurement>(new List<ContractorProcurement>
				(ContractorProcurement.GetAllContractorProcurement( in_contractor )));
		}
	}
}
