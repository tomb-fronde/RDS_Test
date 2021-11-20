using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.DataControls;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DCustCriteriaDeldays : Metex.Windows.DataUserControl
	{
		public DCustCriteriaDeldays()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			mail_category.AssignDropdownType<DDddwMailCategoryFixed>();
			ct_key.AssignDropdownType<DDddwContractTypes>();
			region_id.AssignDropdownType<DDddwRegions>();
			rg_code.AssignDropdownType<DDddwRenewalgroup>();
            
		}

		public override int Retrieve( )
		{
			return RetrieveCore<CustCriteriaDeldays>(new List<CustCriteriaDeldays>
				(CustCriteriaDeldays.GetAllCustCriteriaDeldays(  )));
		}
	}
}
