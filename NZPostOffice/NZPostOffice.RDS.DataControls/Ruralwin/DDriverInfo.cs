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
    // TJB  RPCR_060  Mar-2014
    // Removed redundant/unused code
    //
    // TJB  RPCR_060  Feb-2014
    // Added Mobile2 to display
    //
    // TJB  RPCR_060  Jan-2014: NEW
    // Datacontrol for Driver 'personal' info

    public partial class DDriverInfo : Metex.Windows.DataUserControl
    {
        public DDriverInfo()
        {
            InitializeComponent();
        }

        public int Retrieve(int? in_driver_no)
        {
            return RetrieveCore<DriverInfo>(DriverInfo.GetAllDriverInfo(in_driver_no));
        }
    }
}
