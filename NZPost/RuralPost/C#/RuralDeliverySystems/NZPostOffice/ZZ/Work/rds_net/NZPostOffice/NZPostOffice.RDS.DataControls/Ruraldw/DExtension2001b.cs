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
	public partial class DExtension2001b : Metex.Windows.DataUserControl
	{
		public DExtension2001b()
		{
			InitializeComponent();
		}

		public int Retrieve( int? in_contract )
		{
			return RetrieveCore<Extension2001b>(new List<Extension2001b>
				(Extension2001b.GetAllExtension2001b( in_contract )));
		}
	}
}
