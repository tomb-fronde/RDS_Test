using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsLib;

namespace NZPostOffice.ODPS.DataControls.OdpsLib
{
    public partial class DShellImportTest : Metex.Windows.DataUserControl
    {
        public DShellImportTest()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<ShellImportTest>(new List<ShellImportTest>
                (ShellImportTest.GetAllShellImportTest()));
        }
    }
}
