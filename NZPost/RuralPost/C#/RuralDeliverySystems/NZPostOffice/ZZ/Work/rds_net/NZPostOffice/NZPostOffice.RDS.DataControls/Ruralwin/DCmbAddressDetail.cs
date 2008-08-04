using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    public partial class DCmbAddressDetail : Metex.Windows.DataUserControl
    {
        public DCmbAddressDetail()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {
            rd_no.AssignDropdownType<DDddwContractRd>();
            tc_id.AssignDropdownType<DDddwContractMailtown>();
        }

        public int Retrieve(int? in_cmb_id)
        {
            return RetrieveCore<CmbAddressDetail>(CmbAddressDetail.GetAllCmbAddressDetail(in_cmb_id));
        }
    }
}
