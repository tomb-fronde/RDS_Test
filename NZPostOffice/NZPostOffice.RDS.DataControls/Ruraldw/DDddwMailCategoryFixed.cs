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
	public partial class DDddwMailCategoryFixed : Metex.Windows.DataUserControl
	{
		public DDddwMailCategoryFixed()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
            return RetrieveCore<DddwMailCategoryFixed>(new List<DddwMailCategoryFixed>(DddwMailCategoryFixed.GetAllDddwMailCategoryFixed()));
		}
	}
}
