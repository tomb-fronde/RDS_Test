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
    public partial class DwInvoiceHeaderPostaddress : Metex.Windows.DataUserControl
    {
        public DwInvoiceHeaderPostaddress()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {

        }

        public int Retrieve(DateTime? enddate)
        {
            return RetrieveCore<InvoiceHeaderPostaddress>(new List<InvoiceHeaderPostaddress>(InvoiceHeaderPostaddress.GetAllInvoiceHeaderPostaddress(enddate)));
        }
    }
}
