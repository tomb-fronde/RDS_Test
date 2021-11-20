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
    // TJB  RPCR_094  Mar-2015 - NEW
    // Datawindow for WNegativePayReport
    
    public partial class DwPayrunNegativepay : Metex.Windows.DataUserControl
    {
        public DwPayrunNegativepay()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<PayrunNegativepay>(new List<PayrunNegativepay>
                (PayrunNegativepay.GetAllPayrunNegativepay()));
        }
    }
}
