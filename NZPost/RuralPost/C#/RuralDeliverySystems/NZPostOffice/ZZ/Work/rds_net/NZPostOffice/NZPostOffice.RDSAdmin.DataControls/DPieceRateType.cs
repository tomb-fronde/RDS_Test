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
	public partial class DPieceRateType : Metex.Windows.DataUserControl
	{
		public DPieceRateType()
		{
			InitializeComponent();
			InitializeDropdown();
            this.SortString = "prs_key A,prt_code A";
		}

		private void InitializeDropdown()
		{
            prs_key.AssignDropdownType<PieceRateSuppliers>("PrsKey", "PrsDescription");
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<PieceRateType>(new List<PieceRateType>
                (PieceRateType.GetAllPieceRateType()));
            if(this.SortString != "")
                this.Sort<PieceRateType>();
            return ret;
		}
	}
}
