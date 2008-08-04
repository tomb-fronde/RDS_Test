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
    public partial class DwUpdatedContractors : Metex.Windows.DataUserControl
    {
        public DwUpdatedContractors()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? FromDate, DateTime? ToDate)
        {
            return RetrieveCore<UpdatedContractors>(new List<UpdatedContractors>
                (UpdatedContractors.GetAllUpdatedContractors(FromDate, ToDate)));
        }
    }
}
