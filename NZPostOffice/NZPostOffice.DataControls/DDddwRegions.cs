using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Entity;

namespace NZPostOffice.DataControls
{
    public partial class DDddwRegions : Metex.Windows.DataUserControl
    {
        public DDddwRegions()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<DddwRegions>(DddwRegions.GetAllDddwRegions());
        }
    }
}
