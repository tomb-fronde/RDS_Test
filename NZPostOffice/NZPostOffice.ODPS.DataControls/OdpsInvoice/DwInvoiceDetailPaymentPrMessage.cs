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
    public partial class DwInvoiceDetailPaymentPrMessage : Metex.Windows.DataUserControl
    {
        public DwInvoiceDetailPaymentPrMessage()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {

        }

        public int Retrieve(string in_message)
        {
            return RetrieveCore<InvoiceDetailPaymentPrMessage>(new List<InvoiceDetailPaymentPrMessage>(InvoiceDetailPaymentPrMessage.GetAllInvoiceDetailPaymentPrMessage(in_message)));
        }
    }
}
