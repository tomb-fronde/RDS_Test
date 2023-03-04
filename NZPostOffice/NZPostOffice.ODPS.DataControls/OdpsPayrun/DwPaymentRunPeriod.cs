using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsPayrun;
using NZPostOffice.ODPS.Entity.OdpsCodes;
using NZPostOffice.ODPS.DataControls.OdpsCodes;

namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    // TJB  RPCR_139 Bugfix July-2019 [In designer]
    // Changed contract_no to string (was numericmasked)
    //
    // TJB  RPCR_141  June-2019  [In designer]
    // Added contract_no and rg_code dropdown
    // Added this.contract_no.CausesValidation = false;

    // TJB  RPCR_141  June-2019
    // Added OnHandleCreated and InitializeDropdown for rg_code dropdown
    // Added this.contract_no.CausesValidation = false in designer

    public partial class DwPaymentRunPeriod : Metex.Windows.DataUserControl
    {
        public DwPaymentRunPeriod()
        {
            InitializeComponent();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            base.OnHandleCreated(e);
        }

        private void InitializeDropdown()
        {
            rg_code.AssignDropdownType<DDddwRenewalgroup>();
        }

        public override int Retrieve()
        {
            int rc = RetrieveCore<PaymentRunPeriod>(new List<PaymentRunPeriod>
                (PaymentRunPeriod.GetAllPaymentRunPeriod()));

            // TJB  RPCR_141  June-2019
            // This ensures the rg_code dropdown starts showing the blank entry
            // (otherwise sorted alphabetically)
            if (rg_code.Items.Count > 0)
            {
                int i = rg_code.SelectedIndex;
                if (i > 0)
                {
                    rg_code.SelectedIndex = 0;
                }
            }
            return rc;
        }
    }
}
