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
    public partial class DwIr348Header : Metex.Windows.DataUserControl
    {
        public DwIr348Header()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? startdate, DateTime? enddate)
        {
            return RetrieveCore<Ir348Header>(new List<Ir348Header>
                (Ir348Header.GetAllIr348Header(startdate, enddate)));
        }
    }
}
