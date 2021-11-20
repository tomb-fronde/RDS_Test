using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralmailmerge;

namespace NZPostOffice.RDS.DataControls.Ruralmailmerge
{
	public partial class DSelectProcurements : Metex.Windows.DataUserControl
	{
		public DSelectProcurements()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<SelectProcurements>(new List<SelectProcurements>
				(SelectProcurements.GetAllSelectProcurements(  )));
		}
	}
}
