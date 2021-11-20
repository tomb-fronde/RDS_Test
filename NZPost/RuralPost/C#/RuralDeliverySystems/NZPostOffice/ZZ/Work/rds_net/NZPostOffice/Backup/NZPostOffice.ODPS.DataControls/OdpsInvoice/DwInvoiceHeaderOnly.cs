using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    public partial class DwInvoiceHeaderOnly : Metex.Windows.DataUserControl
    {
        public DwInvoiceHeaderOnly()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {

        }

        public int Retrieve(DateTime? start_date, DateTime? end_date, int? contractor, int? contract, int? region, string cname, int? ctKey)
        {
            return RetrieveCore<InvoiceHeaderOnly>(new List<InvoiceHeaderOnly>(InvoiceHeaderOnly.GetAllInvoiceHeaderOnly(start_date, end_date, contractor, contract, region, cname, ctKey)));
        }
    }
}
