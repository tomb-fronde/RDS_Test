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
    // TJB  RPCR_054  July-2013 (in designer)
    // Changed alignment of prt_key header (to MiddleLeft; was unspecified)

	public partial class DPieceRateImport : Metex.Windows.DataUserControl
	{
		public DPieceRateImport()
		{
			InitializeComponent();
			//InitializeDropdown();
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            
            base.OnHandleCreated(e);
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
