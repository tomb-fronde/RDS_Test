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
    public partial class DwInvoiceInterfaceDetail : Metex.Windows.DataUserControl
    {
        public DwInvoiceInterfaceDetail()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? inStartDate, DateTime? inEndDate)
        {
            return RetrieveCore<InvoiceInterfaceDetail>(new List<InvoiceInterfaceDetail>
                (InvoiceInterfaceDetail.GetAllInvoiceInterfaceDetail(inStartDate, inEndDate)));
        }
    }
}
