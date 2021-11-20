using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    public partial class DDddwFuewTypes : Metex.Windows.DataUserControl
    {
        public DDddwFuewTypes()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            int ll = RetrieveCore<DddwFuewTypes>(DddwFuewTypes.GetAllDddwFuewTypes());
            this.SortString = "ft_description A";
            this.Sort<DddwFuewTypes>();
            return ll;
        }
    }
}
