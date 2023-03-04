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
	public partial class DPieceRateBreakdown : Metex.Windows.DataUserControl
	{
		public DPieceRateBreakdown()
		{
			InitializeComponent();
		}

		public int Retrieve( int? in_Contract, int? in_Supplier, DateTime? in_Date )
		{
            int? total1 = 0;
            decimal? total2 = 0;
            List<PieceRateBreakdown> pieRst = new List<PieceRateBreakdown>(PieceRateBreakdown.GetAllPieceRateBreakdown(in_Contract, in_Supplier, in_Date));
            foreach(PieceRateBreakdown pie in pieRst)
            {
                if (pie.PrdQuantity != null)
                    total1 += pie.PrdQuantity;
                if (pie.PrRate != null)
                    total2 += pie.PrRate;
            }
            compute_1.Text = string.Format("{0:#,##0}",total1);
            compute_2.Text = string.Format("{0:#,##0.00}", total2);
			return RetrieveCore<PieceRateBreakdown>(new List<PieceRateBreakdown>
				(PieceRateBreakdown.GetAllPieceRateBreakdown(in_Contract, in_Supplier, in_Date)));
		}
	}
}
