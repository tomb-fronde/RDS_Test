using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;
//!using NZPostOffice.RDSAdmin.DataControls.EpDropdowns;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	public partial class DDddwPieceRateSuppliers : Metex.Windows.DataUserControl
	{
		public DDddwPieceRateSuppliers()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
            return RetrieveCore<PieceRateSuppliers>(new List<PieceRateSuppliers>(PieceRateSuppliers.GetAllDddwPieceRateSuppliers()));
		}
	}
}
