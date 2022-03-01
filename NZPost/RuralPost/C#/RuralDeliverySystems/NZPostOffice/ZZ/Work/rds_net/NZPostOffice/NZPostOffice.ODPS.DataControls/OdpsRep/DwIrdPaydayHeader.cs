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
    // TJB IRD Payday Export  Feb-2022
    // Changes required for updated IRD requirements (in designer)
    //   Header changed to 'HEI2'; Gross and Paye columns moved
    //   Gross and paye prior adjustments, SLCIR and SLBOR deductions
    //   and share scheme columns added.
    //
    // TJB  RPCR_128  June-2019: New
    // Derived from DwIr348Header, otherwise unchanged

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
