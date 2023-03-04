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
    public partial class DwIr68aIr68p : Metex.Windows.DataUserControl
    {
        public DwIr68aIr68p()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? sdate, DateTime? edate)
        {
            return RetrieveCore<Ir68aIr68p>(new List<Ir68aIr68p>
                (Ir68aIr68p.GetAllIr68aIr68p(sdate, edate)));
        }
    }
}
