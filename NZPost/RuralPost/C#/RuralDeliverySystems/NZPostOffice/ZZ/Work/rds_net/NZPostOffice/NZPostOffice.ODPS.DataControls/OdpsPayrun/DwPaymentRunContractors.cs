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
    // TJB  RPCR_140  June-2019
    // Added rg_code and contract_no to parameter lists

    public partial class DwPaymentRunContractors : Metex.Windows.DataUserControl
    {
        public DwPaymentRunContractors()
        {
            InitializeComponent();
        }
        // TJB  RPCR_140  June-2019
        // Added rg_code and contract_no to parameter lists
        public int Retrieve(string inOwnerDriver, DateTime? sdate, DateTime? edate
                           , int? rg_code, int? contract_no)
        {
            return RetrieveCore<PaymentRunContractors>(new List<PaymentRunContractors>
                (PaymentRunContractors.GetAllPaymentRunContractors(inOwnerDriver, sdate, edate
                                                                  , rg_code, contract_no)));
        }
    }
}
