using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    public partial class DwApInterfaceHeaderRows : Metex.Windows.DataUserControl
    {
        public DwApInterfaceHeaderRows()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? ProcDate)
        {
            return RetrieveCore<ApInterfaceHeaderRows>(new List<ApInterfaceHeaderRows>
                (ApInterfaceHeaderRows.GetAllApInterfaceHeaderRows(ProcDate)));
        }
    }
}
