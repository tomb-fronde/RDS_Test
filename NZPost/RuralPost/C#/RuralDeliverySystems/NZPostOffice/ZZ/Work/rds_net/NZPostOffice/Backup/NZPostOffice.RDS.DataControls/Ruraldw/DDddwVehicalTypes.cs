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
	public partial class DDddwVehicalTypes : Metex.Windows.DataUserControl
	{
		public DDddwVehicalTypes()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
			int ll= RetrieveCore<DddwVehicalTypes>(DddwVehicalTypes.GetAllDddwVehicalTypes());
            this.SortString = "vt_description A";
            this.Sort<DddwVehicalTypes>();
            return ll;
		}
	}
}
