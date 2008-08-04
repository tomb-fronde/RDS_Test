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
	public partial class DPieceRateImport : Metex.Windows.DataUserControl
	{
		public DPieceRateImport()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
            prt_key.AssignDropdownType<DddwPieceRates>("PrtKey", "PrtDescription");
		}

		public override int Retrieve( )
		{
			return RetrieveCore<PieceRateImport>(new List<PieceRateImport>
				(PieceRateImport.GetAllPieceRateImport(  )));
		}

        public int Retrieve(Metex.Core.EntityBindingList<PieceRateImport> dw_1_List)
        {
            return RetrieveCore<PieceRateImport>(dw_1_List);
        }
	}
}
