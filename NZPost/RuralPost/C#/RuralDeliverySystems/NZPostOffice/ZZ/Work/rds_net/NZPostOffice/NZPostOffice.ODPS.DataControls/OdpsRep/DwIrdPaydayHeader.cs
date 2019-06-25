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
    // Derived from DwIr348Header

    public partial class DwIrdPaydayHeader : Metex.Windows.DataUserControl
    {
        public DwIrdPaydayHeader()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? startdate, DateTime? enddate)
        {
            return RetrieveCore<IrdPaydayHeader>(new List<IrdPaydayHeader>
                (IrdPaydayHeader.GetAllIrdPaydayHeader(startdate, enddate)));
        }
    }
}
