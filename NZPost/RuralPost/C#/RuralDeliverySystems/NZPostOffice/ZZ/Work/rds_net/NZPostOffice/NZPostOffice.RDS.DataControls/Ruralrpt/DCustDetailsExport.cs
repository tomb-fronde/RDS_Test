using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DCustDetailsExport : Metex.Windows.DataUserControl
	{
		public DCustDetailsExport()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<CustDetailsExport>(new List<CustDetailsExport>
				(CustDetailsExport.GetAllCustDetailsExport(  )));
		}
	}
}
