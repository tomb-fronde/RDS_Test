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
    public partial class DwAccountCode : Metex.Windows.DataUserControl
    {
        public DwAccountCode()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<NZPostOffice.ODPS.Entity.Odps.AccountCode>(new List<NZPostOffice.ODPS.Entity.Odps.AccountCode>
                (NZPostOffice.ODPS.Entity.Odps.AccountCode.GetAllAccountCode()));
        }
    }
}
