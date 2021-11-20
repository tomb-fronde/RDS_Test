using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsPayrun;
using NZPostOffice.ODPS.DataControls.OdpsCodes;

namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    public partial class DwPostTaxDeductions : Metex.Windows.DataUserControl
    {
        public DwPostTaxDeductions()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {
            pct_id.AssignDropdownType<DDddwPaymentComponents>();
        }

        public override int Retrieve()
        {
            return RetrieveCore<PostTaxDeductions>(new List<PostTaxDeductions>
                (PostTaxDeductions.GetAllPostTaxDeductions()));
        }

        private void DwPostTaxDeductions_Load(object sender, EventArgs e)
        {

        }
    }
}
