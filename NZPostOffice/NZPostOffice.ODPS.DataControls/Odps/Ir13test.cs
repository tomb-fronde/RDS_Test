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
    public partial class Ir13test : Metex.Windows.DataUserControl
    {
        public Ir13test()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<NZPostOffice.ODPS.Entity.Odps.Ir13test>(new List<NZPostOffice.ODPS.Entity.Odps.Ir13test>
                (NZPostOffice.ODPS.Entity.Odps.Ir13test.GetAll()));
        }
    }
}
