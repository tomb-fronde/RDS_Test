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
	public partial class DContractMailtown : Metex.Windows.DataUserControl
	{
		public DContractMailtown()
		{
			InitializeComponent();
		}

		public override int Retrieve() {
			return RetrieveCore<ContractMailtown>(ContractMailtown.GetAllContractMailtown());
		}
	}
}
