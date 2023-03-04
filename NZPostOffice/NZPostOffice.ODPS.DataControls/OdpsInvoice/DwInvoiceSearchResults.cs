using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    public partial class DwInvoiceSearchResults : Metex.Windows.DataUserControl
    {
        public DwInvoiceSearchResults()
        {
            InitializeComponent();
        }

        public int Retrieve(string inOwnerDriver, int? inRegion, DateTime? sdate, DateTime? edate, int? inContractNo, int? inCtKey)
        {
            return RetrieveCore<InvoiceSearchResults>(new List<InvoiceSearchResults>
                (InvoiceSearchResults.GetAllInvoiceSearchResults(inOwnerDriver, inRegion, sdate, edate, inContractNo, inCtKey)));
        }
    }
}
