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
    public partial class DwIr13InterfaceDetail : Metex.Windows.DataUserControl
    {
        public DwIr13InterfaceDetail()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? StartDate, DateTime? EndDate)
        {
            return RetrieveCore<Ir13InterfaceDetail>(new List<Ir13InterfaceDetail>
                (Ir13InterfaceDetail.GetAllIr13InterfaceDetail(StartDate, EndDate)));
        }
    }
}
