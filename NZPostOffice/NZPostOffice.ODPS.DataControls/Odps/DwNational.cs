using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.DataControls.OdpsCodes;
using NZPostOffice.ODPS.Entity.Odps;
using NZPostOffice.ODPS.Entity.OdpsCodes;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    public partial class DwNational : Metex.Windows.DataUserControl
    {
        public DwNational()
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
            ac_id.AssignDropdownType<AccountId>("AcId", "AcDescription");
        }

        public override int Retrieve()
        {
            return RetrieveCore<National>(new List<National>
                (National.GetAllNational()));
        }
    }
}
