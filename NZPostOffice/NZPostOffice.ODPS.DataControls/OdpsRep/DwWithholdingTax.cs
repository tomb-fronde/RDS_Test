using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    public partial class DwWithholdingTax : Metex.Windows.DataUserControl
    {
        public DwWithholdingTax()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? sdate, DateTime? edate, DateTime? fin_sdate, DateTime? fin_edate)
        {
            this.eDate = edate;
            return RetrieveCore<WithholdingTax>(new List<WithholdingTax>
                (WithholdingTax.GetAllWithholdingTax(sdate, edate, fin_sdate, fin_edate)));
        }
    }
}
