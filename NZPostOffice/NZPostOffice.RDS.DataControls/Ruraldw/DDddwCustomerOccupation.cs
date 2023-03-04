using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
//////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DDddwCustomerOccupation : Metex.Windows.DataUserControl
	{
		public DDddwCustomerOccupation()
		{
			InitializeComponent();
            this.SortString = "OccupationDescription A";
		}

		public override int Retrieve( )
        {
            int iRow = RetrieveCore<DddwCustomerOccupation>(DddwCustomerOccupation.GetAllDddwCustomerOccupation());
            if(iRow>0)
            this.Sort<DddwCustomerOccupation>();
            return iRow;
		}
	}
}
