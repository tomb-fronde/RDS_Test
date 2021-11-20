using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RPsCustListAny : Metex.Windows.DataUserControl
	{
		public RPsCustListAny()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
            return RetrieveCore<PsCustListAny>(new List<PsCustListAny>(PsCustListAny.GetAllPsCustListAny()));
		}
	}
}
