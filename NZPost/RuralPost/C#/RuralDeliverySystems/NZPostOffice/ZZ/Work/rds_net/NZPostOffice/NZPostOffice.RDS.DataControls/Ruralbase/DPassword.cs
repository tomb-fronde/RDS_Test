using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralbase;

namespace NZPostOffice.RDS.DataControls.Ruralbase
{
	public partial class DPassword : Metex.Windows.DataUserControl
	{
		public DPassword()
		{
			InitializeComponent();
		}

		public override int Retrieve() {
			return RetrieveCore<Password>(Password.GetAllPassword());
		}
	}
}
