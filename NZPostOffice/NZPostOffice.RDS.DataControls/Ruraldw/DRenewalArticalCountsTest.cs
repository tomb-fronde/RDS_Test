using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  RPCR_093  Feb-2015
    // Hide references to Large Parcels

    public partial class DRenewalArticalCounts : Metex.Windows.DataUserControl
    {
        public DRenewalArticalCounts()
        {
            InitializeComponent();

            ac_w1_large_parcels_t.Visible = false;
            t_10.Visible = false;
            t_11.Visible = false;
        }

        public int Retrieve(int? in_Contract, int? in_Sequence)
        {
            return RetrieveCore<RenewalArticalCounts>(new List<RenewalArticalCounts>
                (RenewalArticalCounts.GetAllRenewalArticalCounts(in_Contract, in_Sequence)));
        }
    }
}
