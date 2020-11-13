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
    // TJB Frequencies Nov-2020
    // Created modelled on DContractFixedAssets
    //
    // TJB Frequencies Changes 13-Nov-2020
    // Checkin sort-of-working version
    //

    public partial class DRouteFrequency2 : Metex.Windows.DataUserControl
	{
        public DRouteFrequency2()
		{
			InitializeComponent();
            //InitializeDropdown();
		}

        private void InitializeDropdown()
        {
            //sf_key.AssignDropdownType<DddwStandardFrequency>();
        }

        public int Retrieve(int? contract_no, int? in_showall)
		{
            int rc;
            rc =  RetrieveCore<RouteFrequency2>(new List<RouteFrequency2>
                (RouteFrequency2.GetAllRouteFrequency2(contract_no, in_showall)));
            return rc;
		}
	}
}
