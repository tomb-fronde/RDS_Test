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
	public partial class DwInvoiceDetailPayment : Metex.Windows.DataUserControl
	{
		public DwInvoiceDetailPayment()
		{
			InitializeComponent();
		}

        public int Retrieve(int? invoiceid, DateTime? enddate, int? insupplier, int? incontract_no)
        {
            return RetrieveCore<InvoiceDetailPayment>(InvoiceDetailPayment.GetAllInvoiceDetailPayment(invoiceid, enddate, insupplier, incontract_no));
        }
	}
}
