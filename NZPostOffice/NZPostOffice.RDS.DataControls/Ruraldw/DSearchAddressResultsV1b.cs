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
	public partial class DSearchAddressResultsV1b : Metex.Windows.DataUserControl
	{
		public DSearchAddressResultsV1b()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			sl_id.AssignDropdownType<DddwSuburb>();
			tc_id.AssignDropdownType<DddwTown>();
		}

		public int Retrieve( string in_AdrNum, string in_roadName, int? in_roadType, int? in_roadSuffix, int? in_SuburbId, int? in_TownId, int? in_Contract, string in_RDNo, string in_Surname, string in_Initials, string in_UI_UserId, int? in_ComponentId, int? in_rd_contract, int? in_dpid )
		{
			return RetrieveCore<SearchAddressResultsV1b>(new List<SearchAddressResultsV1b>
				(SearchAddressResultsV1b.GetAllSearchAddressResultsV1b( in_AdrNum, in_roadName, in_roadType, in_roadSuffix, in_SuburbId, in_TownId, in_Contract, in_RDNo, in_Surname, in_Initials, in_UI_UserId, in_ComponentId, in_rd_contract, in_dpid )));
		}
	}
}
