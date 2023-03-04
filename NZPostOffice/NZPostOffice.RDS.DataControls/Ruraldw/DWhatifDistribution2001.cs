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
	public partial class DWhatifDistribution2001 : Metex.Windows.DataUserControl
	{
		public DWhatifDistribution2001()
		{
			InitializeComponent();
		}

        public void RefreshData()
        {
            //!this.bindingSource_ListChanged(null,null);
            this.viewer.RefreshReport();
        }

		public override int Retrieve( )
		{
			int ret =  RetrieveCore<WhatifDistribution2001>(new List<WhatifDistribution2001>
				(WhatifDistribution2001.GetAllWhatifDistribution2001()));
            this.SortString = "sort A";
            this.Sort<WhatifDistribution2001>();
            return ret;
		}

        public void Print()
        {
            this.viewer.PrintReport();
        }
	}
}
