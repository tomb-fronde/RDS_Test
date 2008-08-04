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
    public partial class DwPaymentRunNegativepay : Metex.Windows.DataUserControl
    {
        public DwPaymentRunNegativepay()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<PaymentRunNegativepay>(new List<PaymentRunNegativepay>
                (PaymentRunNegativepay.GetAllPaymentRunNegativepay()));
        }
    }
}
