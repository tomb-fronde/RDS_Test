using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
	public partial class DwOdpsOwnerdrivercontract : Metex.Windows.DataUserControl
	{
		public DwOdpsOwnerdrivercontract()
		{
			InitializeComponent();
		}

		public int Retrieve( int? in_ContractNo, int? in_ContractSeq, int? in_ContractorNo )
        {
			return RetrieveCore<OdpsOwnerdrivercontract>(OdpsOwnerdrivercontract.GetAllOdpsOwnerdrivercontract(in_ContractNo, in_ContractSeq, in_ContractorNo));
		}
	}
}
