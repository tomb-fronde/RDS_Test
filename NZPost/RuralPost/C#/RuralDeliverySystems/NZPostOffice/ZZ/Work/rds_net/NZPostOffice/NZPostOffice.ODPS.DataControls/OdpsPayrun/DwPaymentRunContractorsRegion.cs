using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsPayrun;

namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    public partial class DwPaymentRunContractorsRegion : Metex.Windows.DataUserControl
    {
        public DwPaymentRunContractorsRegion()
        {
            InitializeComponent();
        }

        public int Retrieve(string inOwnerDriver, int? inRegion, DateTime? sdate, DateTime? edate)
        {
            return RetrieveCore<PaymentRunContractorsRegion>(new List<PaymentRunContractorsRegion>
                (PaymentRunContractorsRegion.GetAllPaymentRunContractorsRegion(inOwnerDriver, inRegion, sdate, edate)));
        }
    }
}
