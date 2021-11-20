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
    public partial class DTelecomImport : Metex.Windows.DataUserControl
    {
        public DTelecomImport()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<TelecomImport>(new List<TelecomImport>
                (TelecomImport.GetAllTelecomImport()));
        }
    }
}
