using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsRep;
using NZPostOffice.ODPS.Entity.OdpsPayrun;
using NZPostOffice.ODPS.Entity.OdpsCodes;

namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    public partial class DwPaymentComponentType : Metex.Windows.DataUserControl
    {
        public DwPaymentComponentType()
        {
            InitializeComponent();
            //InitializeDropdown();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            
            base.OnHandleCreated(e);
        }

        private void InitializeDropdown()
        {            
            pcg_id.AssignDropdownType<PaymentComponentGroup>();
            ac_id.AssignDropdownType<AccountId>();
        }

        public override int Retrieve()
        {
            return RetrieveCore<NZPostOffice.ODPS.Entity.OdpsRep.PaymentComponentType>(new List<NZPostOffice.ODPS.Entity.OdpsRep.PaymentComponentType>
                (NZPostOffice.ODPS.Entity.OdpsRep.PaymentComponentType.GetAllPaymentComponentType()));
        }
    }
}
