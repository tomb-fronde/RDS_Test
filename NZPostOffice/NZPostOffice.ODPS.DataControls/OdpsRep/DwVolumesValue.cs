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
    public partial class DwVolumesValue : Metex.Windows.DataUserControl
    {
        public DwVolumesValue()
        {
            InitializeComponent();
        }

        private DateTime ui_sdate = DateTime.MinValue;
        private DateTime ui_edate = DateTime.MinValue;
        private int ui_inregion = 0;
        public int Retrieve(DateTime? sdate, DateTime? edate, int? inregion)
        {
            ui_sdate = sdate.GetValueOrDefault();
            ui_edate = edate.GetValueOrDefault();
            ui_inregion = inregion.GetValueOrDefault();
            int ret =  RetrieveCore<VolumesValue>(new List<VolumesValue>
                (VolumesValue.GetAllVolumesValue(sdate, edate, inregion)));
            this.viewer.RefreshReport();
            return ret;
        }
    }
}
