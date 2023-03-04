using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsPayrun;
using NZPostOffice.ODPS.Entity.OdpsInvoice;
using NZPostOffice.ODPS.DataControls.OdpsInvoice;
namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    public partial class DwPaymentRunPeriodRegion : Metex.Windows.DataUserControl
    {
        public DwPaymentRunPeriodRegion()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {
            region_id.AssignDropdownType<DDddwRegions>();
        }

        public override int Retrieve()
        {
            return RetrieveCore<PaymentRunPeriodRegion>(new List<PaymentRunPeriodRegion>
                (PaymentRunPeriodRegion.GetAllPaymentRunPeriodRegion()));
        }
    }
}
