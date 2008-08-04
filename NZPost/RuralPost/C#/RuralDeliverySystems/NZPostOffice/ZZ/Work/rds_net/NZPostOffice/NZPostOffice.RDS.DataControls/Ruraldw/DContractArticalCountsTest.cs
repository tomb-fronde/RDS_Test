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
    public partial class DContractArticalCounts : Metex.Windows.DataUserControl
    {
        public DContractArticalCounts()
        {
            InitializeComponent();
        }

        public int Retrieve(int? in_Contract)
        {
            return RetrieveCore<ContractArticalCounts>(new List<ContractArticalCounts>
                (ContractArticalCounts.GetAllContractArticalCounts(in_Contract)));
        }
    }
}
