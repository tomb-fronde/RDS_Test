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
    public partial class DwIr13InterfaceHeader : Metex.Windows.DataUserControl
    {
        public DwIr13InterfaceHeader()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? Procdate)
        {
            return RetrieveCore<Ir13InterfaceHeader>(new List<Ir13InterfaceHeader>
                (Ir13InterfaceHeader.GetAllIr13InterfaceHeader(Procdate)));
        }
    }
}
