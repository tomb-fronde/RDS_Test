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
    public partial class DwSptest : Metex.Windows.DataUserControl
    {
        public DwSptest()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<Sptest>(new List<Sptest>
                (Sptest.GetAllSptest()));
        }
    }
}
