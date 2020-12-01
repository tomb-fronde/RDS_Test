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
    // Fixed bug with clearBackColour
    //
    // TJB Frequencies Changes 15-Nov-2020
    // Checkin working version witb DRouteFrequency2Rows
    //
    // TJB Frequencies Nov-2020
    // Created modelled on DContractFixedAssets
    //

    public partial class DRouteFrequency2 : Metex.Windows.DataUserControl
	{
        public DRouteFrequency2()
		{
			InitializeComponent();
		}

        public int Retrieve(int? contract_no, int? in_showall)
		{
            int rc = 0;
            string msg;
            try
            {
                rc = RetrieveCore<RouteFrequency2>(new List<RouteFrequency2>
                    (RouteFrequency2.GetAllRouteFrequency2(contract_no, in_showall)));
            }
            catch (Exception e)
            {
                msg = e.Message;
                MessageBox.Show("Retrieve error: " + msg, "DRouteFrequency2");
            }
            int nRows = this.RowCount;
            int n = nRows;
            return rc;
		}
	}
}
