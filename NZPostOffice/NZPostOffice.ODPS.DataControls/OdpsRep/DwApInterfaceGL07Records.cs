using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    // TJB  New AP Export File  Oct-2013: NEW
    // Datacontrol for entity 

    public partial class DwApInterfaceGL07Records : Metex.Windows.DataUserControl
    {
        public DwApInterfaceGL07Records()
        {
            InitializeComponent();
        }
        
        public int Retrieve(DateTime? ProcDate)
        {
            return RetrieveCore<ApInterfaceGL07Records>(new List<ApInterfaceGL07Records>
                (ApInterfaceGL07Records.GetAllApInterfaceGL07Records(ProcDate)));
        }
        
    }
}
