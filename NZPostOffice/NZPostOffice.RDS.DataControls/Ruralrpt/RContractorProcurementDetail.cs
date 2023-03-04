using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RContractorProcurementDetail : Metex.Windows.DataUserControl
	{
		public RContractorProcurementDetail()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
            int ret = RetrieveCore<ContractorProcurementDetail>(new List<ContractorProcurementDetail>(ContractorProcurementDetail.GetAllContractorProcurementDetail()));
            this.SortString = "region_region_id A";
            this.Sort<ContractorProcurementDetail>();
            return ret;
		}
	}
}
