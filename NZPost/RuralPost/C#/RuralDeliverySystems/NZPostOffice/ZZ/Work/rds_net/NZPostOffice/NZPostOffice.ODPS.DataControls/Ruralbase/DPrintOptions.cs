using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Ruralbase;
//?using NZPostOffice.ODPS.DataControls.EpDropdowns;

namespace NZPostOffice.ODPS.DataControls.Ruralbase
{
	public partial class DPrintOptions : Metex.Windows.DataUserControl
	{
		public DPrintOptions()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
    		return RetrieveCore<PrintOptions>(PrintOptions.GetAllPrintOptions());
		}
	}
}
