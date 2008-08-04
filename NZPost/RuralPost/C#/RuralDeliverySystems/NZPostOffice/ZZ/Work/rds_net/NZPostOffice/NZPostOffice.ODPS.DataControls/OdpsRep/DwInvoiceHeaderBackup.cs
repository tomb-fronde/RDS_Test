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
    public partial class DwInvoiceHeaderBackup : Metex.Windows.DataUserControl
    {
        public DwInvoiceHeaderBackup()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? end_date, int? contractor, int? contract, int? region, string cname)
        {
            return RetrieveCore<InvoiceHeaderBackup>(new List<InvoiceHeaderBackup>
                (InvoiceHeaderBackup.GetAllInvoiceHeaderBackup(end_date, contractor, contract, region, cname)));
        }
    }
}
