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
    public partial class DContractor : Metex.Windows.DataUserControl
	{
		public DContractor()
		{
			InitializeComponent();
		}

		public int Retrieve( int? in_Contractor )
		{
			return RetrieveCore<Contractor>(new List<Contractor>
				(Contractor.GetAllContractor( in_Contractor )));
		}
	}
}
