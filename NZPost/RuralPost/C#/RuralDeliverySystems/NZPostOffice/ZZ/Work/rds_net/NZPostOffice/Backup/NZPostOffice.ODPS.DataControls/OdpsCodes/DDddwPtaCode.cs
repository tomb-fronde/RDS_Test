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
    public partial class DDddwPtaCode : Metex.Windows.DataUserControl
    {
        public DDddwPtaCode()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<DddwPtaCode>(new List<DddwPtaCode>
                (DddwPtaCode.GetAllDddwPtaCode()));
        }
    }
}
