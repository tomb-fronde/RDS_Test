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
    public partial class DDddwPbuCodes : Metex.Windows.DataUserControl
    {
        public DDddwPbuCodes()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<DddwPbuCodes>(new List<DddwPbuCodes>
                (DddwPbuCodes.GetAllDddwPbuCodes()));
        }
    }
}
