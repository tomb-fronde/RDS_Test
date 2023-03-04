using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralsec;

namespace NZPostOffice.RDS.DataControls.Ruralsec
{
	public partial class DDddwFilteredRegions : Metex.Windows.DataUserControl
	{
		public DDddwFilteredRegions()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<DddwFilteredRegions>(new List<DddwFilteredRegions>
				(DddwFilteredRegions.GetAllDddwFilteredRegions(  )));
		}
	}
}
