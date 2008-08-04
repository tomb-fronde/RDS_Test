using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Windows;
using NZPostOffice.ODPS.Entity.OdpsPayrun;
using NZPostOffice.ODPS.DataControls.OdpsCodes;
using NZPostOffice.ODPS.Entity.OdpsCodes;

namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    public partial class DwEmergency : Metex.Windows.DataUserControl
    {
        public DwEmergency()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {
            payment_component_pct_id.AssignDropdownType<DddwPaymentComponents>();
        }

        public int Retrieve(DateTime? edate, int? lcontract)
        {
            return RetrieveCore<Emergency>(new List<Emergency>
                (Emergency.GetAllEmergency(edate, lcontract)));
        }
    }
}
