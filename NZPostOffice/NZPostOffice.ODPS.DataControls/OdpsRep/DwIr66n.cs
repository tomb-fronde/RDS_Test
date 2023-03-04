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
    public partial class DwIr66n : Metex.Windows.DataUserControl
    {
        public DwIr66n()
        {
            InitializeComponent();
        }
        
        public int Retrieve(DateTime? sdate, DateTime? edate)
        {
            this.edate = edate;
            return RetrieveCore<Ir66n>(new List<Ir66n>
                (Ir66n.GetAllIr66n(sdate, edate)));
        }
    }
}
