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
    public partial class DDuplicateDrivers : Metex.Windows.DataUserControl
    {
        // TJB  RPCR_017 July-2010
        // Added 'Approved' column + associated layout changes
        // Added setTotal method so WDuplicateDrivers can 
        // save recalculated compute_1 value.

        public DDuplicateDrivers()
        {
            InitializeComponent();
        }

        public int Retrieve(string inFirstnames, string inSurname)
        {
            //DuplicateDrivers
            return RetrieveCore<DuplicateDrivers>(new List<DuplicateDrivers>
                (DuplicateDrivers.GetAllDuplicateDrivers(inFirstnames, inSurname)));
        }
    }
}
