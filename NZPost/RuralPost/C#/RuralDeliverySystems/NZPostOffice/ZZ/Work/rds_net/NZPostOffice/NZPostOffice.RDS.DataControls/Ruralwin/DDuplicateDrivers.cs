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
    // TJB  RPCR_060  Mar-2014: NEW
    // DW for WDuplicateDrivers
    // Display list of duplicate drivers in an untitled popup window

    public partial class DDuplicateDrivers : Metex.Windows.DataUserControl
    {
        public DDuplicateDrivers()
        {
            InitializeComponent();
        }

        public int Retrieve(string inFirstnames, string inSurname)
        {
            return RetrieveCore<DuplicateDrivers>(new List<DuplicateDrivers>
                (DuplicateDrivers.GetAllDuplicateDrivers(inFirstnames, inSurname)));
        }
    }
}
