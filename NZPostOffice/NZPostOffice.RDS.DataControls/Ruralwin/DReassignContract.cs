using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  RPCR_105  May-2016: NEW
    // Datawindow to display the list of contract numbers fetched by (Entity) ReassignContract

	public partial class DReassignContract : Metex.Windows.DataUserControl
	{
		public DReassignContract()
		{
			InitializeComponent();
		}

		public int Retrieve(string inPostCode, int? inContractNo )
		{
            return RetrieveCore<ReassignContract>(ReassignContract.GetAllReassignContract(inPostCode, inContractNo));
		}
	}
}
