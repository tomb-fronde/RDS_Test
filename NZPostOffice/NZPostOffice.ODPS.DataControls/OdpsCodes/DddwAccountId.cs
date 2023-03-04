using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsCodes;

namespace NZPostOffice.ODPS.DataControls.OdpsCodes
{
    public partial class DddwAccountId : Metex.Windows.DataUserControl
    {
        public DddwAccountId()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<AccountId>(new List<AccountId>
                (AccountId.GetAllAccountId()));
        }
    }
}
