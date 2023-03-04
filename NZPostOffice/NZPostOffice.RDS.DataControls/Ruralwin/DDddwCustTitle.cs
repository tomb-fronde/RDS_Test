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
	public partial class DDddwCustTitle : Metex.Windows.DataUserControl
	{
		public DDddwCustTitle()
		{
			InitializeComponent();
		}

		public override int Retrieve()
        {
            return RetrieveCore<DddwCustTitle>(new List<DddwCustTitle>(DddwCustTitle.GetAllDddwCustTitle()));
		}
	}
}
