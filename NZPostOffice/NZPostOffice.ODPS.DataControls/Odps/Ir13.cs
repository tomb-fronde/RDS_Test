using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    public partial class Ir13 : Metex.Windows.DataUserControl
    {
        public Ir13()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<NZPostOffice.ODPS.Entity.Odps.Ir13>(new List<NZPostOffice.ODPS.Entity.Odps.Ir13>
                (NZPostOffice.ODPS.Entity.Odps.Ir13.GetAll()));
        }
    }
}
