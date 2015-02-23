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
    // TJB  RPCR_093  Feb 2015
    // Hide Large Parcels heading and note about large parcels

    public partial class DContractArticalCounts : Metex.Windows.DataUserControl
    {
        public DContractArticalCounts()
        {
            InitializeComponent();

            t_4.Visible = false;         // "Note" 
            note.Visible = false;        // Note re large parcels
            t_10.Visible = false;        // Large Parcels heading
        }

        public int Retrieve(int? in_Contract)
        {
            return RetrieveCore<ContractArticalCounts>(new List<ContractArticalCounts>
                (ContractArticalCounts.GetAllContractArticalCounts(in_Contract)));
        }
    }
}
