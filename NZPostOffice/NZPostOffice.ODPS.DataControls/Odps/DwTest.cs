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
    public partial class DwTest : Metex.Windows.DataUserControl
    {
        public DwTest()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<Test>(new List<Test>
                (Test.GetAllTest()));
        }
    }
}
