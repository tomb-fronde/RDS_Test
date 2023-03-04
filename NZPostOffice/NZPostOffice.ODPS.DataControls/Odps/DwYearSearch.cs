using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
	public partial class DwYearSearch : Metex.Windows.DataUserControl
	{
		public DwYearSearch()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
			return RetrieveCore<YearSearch>(YearSearch.GetAllYearSearch());
		}
	}
}
