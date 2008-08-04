using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;
//!using NZPostOffice.RDSAdmin.DataControls.EpDropdowns;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
    public partial class DOutletForm : Metex.Windows.DataUserControl
    {
        public DOutletForm()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                InitializeDropdown();
            }
        }
        public new bool DesignMode
        {
            get
            {
                return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
            }
        }
        private void InitializeDropdown()
        {
            ot_code.AssignDropdownType<DDddwOutletType>();
        }

        public int Retrieve(int? al_outlet_id)
        {
            return RetrieveCore<OutletForm>(new List<OutletForm>(OutletForm.GetAllOutletForm(al_outlet_id)));
        }
    }
}
