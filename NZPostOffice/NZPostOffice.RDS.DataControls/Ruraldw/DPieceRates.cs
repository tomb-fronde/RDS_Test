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
	public partial class DPieceRates : Metex.Windows.DataUserControl
	{
		public DPieceRates()
		{
			InitializeComponent();
		}

		public int Retrieve( DateTime? in_Date )
		{
			return RetrieveCore<PieceRates>(new List<PieceRates>
				(PieceRates.GetAllPieceRates( in_Date )));
		}
	}
}
