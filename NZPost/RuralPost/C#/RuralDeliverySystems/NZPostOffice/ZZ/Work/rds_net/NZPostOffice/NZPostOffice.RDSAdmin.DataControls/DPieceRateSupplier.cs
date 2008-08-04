using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	public partial class DPieceRateSupplier : Metex.Windows.DataUserControl
	{
		public DPieceRateSupplier()
		{
			InitializeComponent();
            this.SortString = "prs_description A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<PieceRateSupplier>(new List<PieceRateSupplier>
                (PieceRateSupplier.GetAllPieceRateSupplier()));
            if(this.SortString != "")
                this.Sort<PieceRateSupplier>();
            return ret;
		}
	}
}
