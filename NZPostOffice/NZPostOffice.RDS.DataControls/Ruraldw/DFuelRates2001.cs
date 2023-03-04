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
	public partial class DFuelRates2001 : Metex.Windows.DataUserControl
	{
		public DFuelRates2001()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inRgCode, DateTime? in_Date )
		{
			int ll_return =  RetrieveCore<FuelRates2001>(new List<FuelRates2001>
				(FuelRates2001.GetAllFuelRates2001(inRgCode, in_Date)));
            this.SortString = "ft_description A";
            this.Sort<FuelRates2001>();
            return ll_return;
		}
	}
}
