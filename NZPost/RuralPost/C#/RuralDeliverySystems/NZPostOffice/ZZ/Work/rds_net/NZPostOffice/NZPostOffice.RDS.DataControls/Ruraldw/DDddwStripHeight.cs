using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  RPCR_026  June-2011: New
    // Adapted from DDddwRenewalgroup

    public partial class DDddwStripHeight : Metex.Windows.DataUserControl
    {
        public DDddwStripHeight()
        {
            InitializeComponent();
        }

        public override int Retrieve( )
        {
            int nRows;
            nRows = RetrieveCore<DddwStripHeight>(DddwStripHeight.GetAllDddwStripHeight());
        //    this.SortString = "sh_height A";
        //    this.Sort<DddwStripHeight>();
            return nRows;
        }
    }
}
