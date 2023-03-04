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
    public partial class DShellImportProcessed : Metex.Windows.DataUserControl
    {
        public DShellImportProcessed()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<ShellImportProcessed>(new List<ShellImportProcessed>
                (ShellImportProcessed.GetAllShellImportProcessed()));
        }
    }
}
