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
    public partial class DDddwContracttypes : Metex.Windows.DataUserControl
    {
        public DDddwContracttypes()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<DddwContracttypes>(new List<DddwContracttypes>
                (DddwContracttypes.GetAllDddwContracttypes()));
        }
    }
}
