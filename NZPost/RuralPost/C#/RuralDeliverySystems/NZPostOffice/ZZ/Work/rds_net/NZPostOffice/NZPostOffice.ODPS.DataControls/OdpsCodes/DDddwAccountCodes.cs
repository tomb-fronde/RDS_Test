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
    public partial class DDddwAccountCodes : Metex.Windows.DataUserControl
    {
        public DDddwAccountCodes()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<DddwAccountCodes>(new List<DddwAccountCodes>
                (DddwAccountCodes.GetAllDddwAccountCodes()));
        }
    }
}
