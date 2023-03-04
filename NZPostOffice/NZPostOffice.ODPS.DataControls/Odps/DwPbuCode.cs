using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    // TJB  RPCR_113  July-2018
    // Added 3 columns for email addresses to form (in designer)

    public partial class DwPbuCode : Metex.Windows.DataUserControl
    {
        // TJB  RPCR_113  July-2018
        // Added 3 columns for email addresses to form (in designer)

        public DwPbuCode()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<PbuCode>(new List<PbuCode>
                (PbuCode.GetAllPbuCode()));
        }
    }
}
