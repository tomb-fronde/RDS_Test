using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  RPCR_060  Feb-2014
    // Added HsiAdditionalDate to display
    //
    // TJB  RPCR_060  Jan-2014: NEW
    // Datacontrol for Driver Health & Safety info

    public partial class DDriverHSInfo : Metex.Windows.DataUserControl
    {
        public DDriverHSInfo()
        {
            InitializeComponent();
            //InitializeDropdown();
        }
/*
        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            
            base.OnHandleCreated(e);
        }

        private void InitializeDropdown()
        {
            rd_no.AssignDropdownType<DDddwContractRd>();
            tc_id.AssignDropdownType<DDddwContractMailtown>();
        }
*/
        public int Retrieve(int? in_driver_no)
        {
            return RetrieveCore<DriverHSInfo>(DriverHSInfo.GetAllDriverHSInfo(in_driver_no));
        }
    }
}
