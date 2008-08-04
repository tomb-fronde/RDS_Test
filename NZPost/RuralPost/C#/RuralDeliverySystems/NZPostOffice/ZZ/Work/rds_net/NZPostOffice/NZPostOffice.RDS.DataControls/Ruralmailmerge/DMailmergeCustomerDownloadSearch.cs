using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralmailmerge;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.DataControls;

namespace NZPostOffice.RDS.DataControls.Ruralmailmerge
{
	public partial class DMailmergeCustomerDownloadSearch : Metex.Windows.DataUserControl
	{
		public DMailmergeCustomerDownloadSearch()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			ct_key.AssignDropdownType<DDddwContractTypes>();
			region_id.AssignDropdownType<DDddwRegions>();
			sf_key.AssignDropdownType<DDddwStandardFrequency>();
			rg_code.AssignDropdownType<DDddwRenewalGroups>();
		}

		public override int Retrieve( )
        {
            return RetrieveCore<MailmergeCustomerDownloadSearch>(new List<MailmergeCustomerDownloadSearch>
                (MailmergeCustomerDownloadSearch.GetAllMailmergeCustomerDownloadSearch()));
		}
	}
}
