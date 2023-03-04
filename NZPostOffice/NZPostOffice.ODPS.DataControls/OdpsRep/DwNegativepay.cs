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
    public partial class DwNegativepay : Metex.Windows.DataUserControl
    {
        public DwNegativepay()
        {
            InitializeComponent();
        }

        private DateTime ui_sdate = DateTime.MinValue;
        private DateTime ui_edate = DateTime.MinValue;
        public int Retrieve(DateTime? sdate, DateTime? edate)
        {
            ui_sdate = sdate.GetValueOrDefault();
            ui_edate = edate.GetValueOrDefault();
            int ret = RetrieveCore<Negativepay>(new List<Negativepay>
                (Negativepay.GetAllNegativepay(sdate, edate)));
            this.viewer.RefreshReport();
            return ret;
        }
    }
}
