using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DCustListFreq : Metex.Windows.DataUserControl
	{
		public DCustListFreq()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			freq_list.AssignDropdownType<DFrequencyList>();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<CustListFreq>(new List<CustListFreq>
				(CustListFreq.GetAllCustListFreq(  )));
		}
	}
}
