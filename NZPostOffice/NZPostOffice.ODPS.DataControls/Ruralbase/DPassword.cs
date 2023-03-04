using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Ruralbase;

namespace NZPostOffice.ODPS.DataControls.Ruralbase
{
    public partial class DPassword : Metex.Windows.DataUserControl
    {
        public DPassword()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            List<Password> list = new List<Password>();
            return RetrieveCore<Password>(list);
        }
    }
}
