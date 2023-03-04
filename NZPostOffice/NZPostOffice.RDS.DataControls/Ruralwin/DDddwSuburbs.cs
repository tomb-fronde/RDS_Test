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
	public partial class DDddwSuburbs : Metex.Windows.DataUserControl
	{
		public DDddwSuburbs()
		{
			InitializeComponent();
		}

		public override int Retrieve()
        {
			return RetrieveCore<DddwSuburbs>(DddwSuburbs.GetAllDddwSuburbs());
		}
	}
}
