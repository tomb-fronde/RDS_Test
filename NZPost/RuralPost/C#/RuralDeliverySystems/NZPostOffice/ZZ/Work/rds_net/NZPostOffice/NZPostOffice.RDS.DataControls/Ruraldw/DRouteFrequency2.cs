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
    // TJB Frequencies Nov-2020
    // Created modelled on DContractFixedAssets

    public partial class DRouteFrequency2 : Metex.Windows.DataUserControl
	{
        // TJB  Frequencies Nov-2020 Notes (see also DRouteFrequency2Rows)
        // The original frequencies tab was a single-row Metex Grid. To get two
        // lines per row I used the technique used by DContractFixedAssets.
        // During development, I kept the original functioning and called 
        // the newer version Frequency2 (and related names).  Code for the original 
        // has been removed from WContract2001 but should still be available 
        // in the SourceSafe/GIT archive.
        //
        // The contract_no is included as a component, but is hidden.
        // Its a way to have the value available on each frequency
        // and is used to pass the contract_no to the vehicle_number 
        // dropdown DDddwContractorVehicles.
        //
        // DDddwContractorVehicles finds all the vehicles owned/used by the contractor. 
        // The contractor may hold other contracts; the vehicle list is made up of all 
        // the distinct vehicles from all the contractor’s current contracts.
        //
        // Rows are added to the tab in DRouteFrequency2.bindingSource_ListChanged()

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
