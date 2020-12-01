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
    // Code tidied
    //
    // TJB Frequencies Changes 15-Nov-2020
    // Checkin working version witb DRouteFrequency2
    //
    // TJB Frequencies Nov-2020
    // Created modelled on DContractFixedAssetsTest

    public partial class DRouteFrequency2Rows : Metex.Windows.DataUserControl
	{
        // TJB  RPCR_026  July-2011
        // Added Load and Enter event handlers
        // Added contract_no to screen

        public DRouteFrequency2Rows()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        public event EventHandler TextBoxLostFocus;

        private void TextBox_LostFocus(object sender, System.EventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }

        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }
        private void InitializeDropdown()
        {
            sf_key.AssignDropdownType<DDddwStandardFrequency>();
            vehicle_number.AssignDropdownType<DDddwContractorVehicles>();
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
                MessageBox.Show("Retrieve error: " + msg, "DRouteFrequency2Rows");
            }
            return rc;
        }
    }
}
