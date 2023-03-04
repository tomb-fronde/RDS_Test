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
    public partial class DwNationalHistoryChanges : Metex.Windows.DataUserControl
    {
        public DwNationalHistoryChanges()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? sdate, DateTime? edate)
        {
            return RetrieveCore<NationalHistoryChanges>(new List<NationalHistoryChanges>
                (NationalHistoryChanges.GetAllNationalHistoryChanges(sdate, edate)));
        }
    }
}
