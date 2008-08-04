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
	public partial class DPieceRateImportInvalidDate : Metex.Windows.DataUserControl
	{
		public DPieceRateImportInvalidDate()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			//?prt_key.AssignDropdownType<DddwPieceRates>();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<PieceRateImportInvalidDate>(new List<PieceRateImportInvalidDate>
				(PieceRateImportInvalidDate.GetAllPieceRateImportInvalidDate()));
		}

        public int Retrieve(Metex.Core.EntityBindingList<PieceRateImportInvalidDate> dw_invalid_List)
        {
            return RetrieveCore<PieceRateImportInvalidDate>(dw_invalid_List);
        }

        public int Retrieve(List<PieceRateImportInvalidDate> dw_invalid_List)
        {
            return RetrieveCore<PieceRateImportInvalidDate>(dw_invalid_List);
        }
	}
}
