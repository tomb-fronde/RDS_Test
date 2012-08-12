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
	public partial class DPieceRates2001 : Metex.Windows.DataUserControl
	{
        // TJB 12-Aug-2012
        // Changed pr_rate from 3 decimals to 5

		public DPieceRates2001()
		{
			InitializeComponent();
		}

		public int Retrieve( int? inRgCode, DateTime? in_Date )
		{
			int ll_return =  RetrieveCore<PieceRates2001>(new List<PieceRates2001>
				(PieceRates2001.GetAllPieceRates2001( inRgCode, in_Date )));
            this.SortString = "prt_description A";
            this.Sort<PieceRates2001>();
            return ll_return;
		}
	}
}
