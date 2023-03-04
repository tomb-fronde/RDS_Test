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
    public partial class DwIr348DetailException : Metex.Windows.DataUserControl
    {
        public DwIr348DetailException()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? startdate, DateTime? enddate)
        {
            return RetrieveCore<Ir348DetailException>(new List<Ir348DetailException>
                (Ir348DetailException.GetAllIr348DetailException(startdate, enddate)));
        }
    }
}
