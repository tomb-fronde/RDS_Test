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
    public partial class DwInvoiceInterfaceHeader : Metex.Windows.DataUserControl
    {
        public DwInvoiceInterfaceHeader()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? Procdate)
        {
            return RetrieveCore<InvoiceInterfaceHeader>(new List<InvoiceInterfaceHeader>
                (InvoiceInterfaceHeader.GetAllInvoiceInterfaceHeader(Procdate)));
        }
    }
}
