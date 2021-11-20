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
    public partial class DwAcceptRejectMainrundetailGrid : Metex.Windows.DataUserControl
    {
        public DwAcceptRejectMainrundetailGrid()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<AcceptRejectMainrundetailGrid>(new List<AcceptRejectMainrundetailGrid>
                (AcceptRejectMainrundetailGrid.GetAllAcceptRejectMainrundetailGrid()));
        }
    }
}
