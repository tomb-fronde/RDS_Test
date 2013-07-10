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
    // TJB  RPCR_054  June-2013: NEW
    // List piece rate types for DDW for WAddPieceRateType

	public partial class DDddwPieceRateTypes : Metex.Windows.DataUserControl
	{
		public DDddwPieceRateTypes()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
            return RetrieveCore<DddwPieceRateTypes>(DddwPieceRateTypes.GetAllDddwPieceRateTypes());
		}
	}
}
