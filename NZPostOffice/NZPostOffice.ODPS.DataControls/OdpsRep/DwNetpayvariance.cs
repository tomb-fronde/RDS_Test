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
    public partial class DwNetpayvariance : Metex.Windows.DataUserControl
    {
        public DwNetpayvariance()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? sdate, DateTime? edate, DateTime? prevsdate, DateTime? prevedate)
        {
            return RetrieveCore<Netpayvariance>(new List<Netpayvariance>
                (Netpayvariance.GetAllNetpayvariance(sdate, edate, prevsdate, prevedate)));
        }
    }
}
