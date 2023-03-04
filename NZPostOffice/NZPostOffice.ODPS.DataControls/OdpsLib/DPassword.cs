using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.OdpsLib;

namespace NZPostOffice.ODPS.DataControls.OdpsLib
{
    public partial class DPassword : Metex.Windows.DataUserControl
    {
        public DPassword()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {

        }

        public override int Retrieve()
        {
            return RetrieveCore<Password>(new List<Password>(Password.GetAllPassword()));
        }
    }
}
