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
    public partial class DwPaymentRunContractors : Metex.Windows.DataUserControl
    {
        public DwPaymentRunContractors()
        {
            InitializeComponent();
        }

        public int Retrieve(string inOwnerDriver, DateTime? sdate, DateTime? edate)
        {
            return RetrieveCore<PaymentRunContractors>(new List<PaymentRunContractors>
                (PaymentRunContractors.GetAllPaymentRunContractors(inOwnerDriver, sdate, edate)));
        }
    }
}
