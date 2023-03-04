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
	public partial class DMailmergeOwnerdriverDownloadSearch : Metex.Windows.DataUserControl
	{
		public DMailmergeOwnerdriverDownloadSearch()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			ct_key.AssignDropdownType<DDddwContractTypes>();
			region_id.AssignDropdownType<DDddwRegions>();
			region_id_ro.AssignDropdownType<DDddwRegions>();
			rg_code.AssignDropdownType<DDddwRenewalgroup>();
		}

		public override int Retrieve( )
        {
            return RetrieveCore<MailmergeOwnerdriverDownloadSearch>(new List<MailmergeOwnerdriverDownloadSearch>(MailmergeOwnerdriverDownloadSearch.GetAllMailmergeOwnerdriverDownloadSearch()));
		}
	}
}
