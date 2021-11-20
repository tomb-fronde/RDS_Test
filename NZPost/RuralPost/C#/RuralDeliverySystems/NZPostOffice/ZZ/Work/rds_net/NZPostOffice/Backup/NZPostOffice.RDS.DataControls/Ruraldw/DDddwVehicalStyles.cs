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
    public partial class DDddwVehicalStyles : Metex.Windows.DataUserControl
    {
        public DDddwVehicalStyles()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            int ll = RetrieveCore<DddwVehicalStyles>(new List<DddwVehicalStyles>(DddwVehicalStyles.GetAllDddwVehicalStyles()));
            this.SortString = "vs_description A";
            this.Sort<DddwVehicalStyles>();
            return ll;
        }
    }
}
