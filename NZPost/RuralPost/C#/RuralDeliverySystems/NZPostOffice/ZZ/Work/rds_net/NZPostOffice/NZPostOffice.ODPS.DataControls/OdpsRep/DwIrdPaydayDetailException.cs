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
    // TJB  RPCR_128  June-2019: New
    // Derived from DwIr348DetailException, otherwise unchanged

    public partial class DwIrdPaydayDetailException : Metex.Windows.DataUserControl
    {
        public DwIrdPaydayDetailException()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? startdate, DateTime? enddate)
        {
            return RetrieveCore<IrdPaydayDetailException>(new List<IrdPaydayDetailException>
                (IrdPaydayDetailException.GetAllIrdPaydayDetailException(startdate, enddate)));
        }
    }
}
