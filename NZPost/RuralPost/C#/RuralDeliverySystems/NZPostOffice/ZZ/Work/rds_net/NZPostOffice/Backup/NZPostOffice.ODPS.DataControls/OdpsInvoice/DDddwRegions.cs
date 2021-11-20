using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    public partial class DDddwRegions : Metex.Windows.DataUserControl
    {
        public DDddwRegions()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<DddwRegions>(new List<DddwRegions>
                (DddwRegions.GetAllDddwRegions()));
        }
    }
}
