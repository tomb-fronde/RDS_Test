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
    public partial class DwAuditLog : Metex.Windows.DataUserControl
    {
        public DwAuditLog()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? fromdate, DateTime? todate)
        {
            return RetrieveCore<AuditLog>(new List<AuditLog>
                    (AuditLog.GetAllAuditLog(fromdate, todate)));
        }
    }
}
