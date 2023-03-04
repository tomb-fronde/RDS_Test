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
    public partial class DwInvoiceDetailPaymentPrTitle : Metex.Windows.DataUserControl
    {
        public DwInvoiceDetailPaymentPrTitle()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {

        }

        public int Retrieve(string in_message)
        {
            return RetrieveCore<InvoiceDetailPaymentPrTitle>(new List<InvoiceDetailPaymentPrTitle>(InvoiceDetailPaymentPrTitle.GetAllInvoiceDetailPaymentPrTitle(in_message)));
        }
    }
}
