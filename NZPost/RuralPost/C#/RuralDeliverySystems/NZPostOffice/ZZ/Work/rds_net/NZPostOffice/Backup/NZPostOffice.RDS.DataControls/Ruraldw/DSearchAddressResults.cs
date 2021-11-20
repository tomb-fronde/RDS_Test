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
	public partial class DSearchAddressResults : Metex.Windows.DataUserControl
	{
		public DSearchAddressResults()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			sl_id.AssignDropdownType<DddwSuburb>();
			tc_id.AssignDropdownType<DddwTown>();
		}

		public int Retrieve( string in_AdrNum, int? in_RoadId, int? in_SuburbId, int? in_TownId, int? in_Contract, string in_RDNo, string in_Surname, string in_Initials, string in_UI_UserId, int? in_ComponentId )
		{
			return RetrieveCore<SearchAddressResults>(new List<SearchAddressResults>
				(SearchAddressResults.GetAllSearchAddressResults( in_AdrNum, in_RoadId, in_SuburbId, in_TownId, in_Contract, in_RDNo, in_Surname, in_Initials, in_UI_UserId, in_ComponentId )));
		}
	}
}
