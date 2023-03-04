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
	public partial class DQsContractList : Metex.Windows.DataUserControl
	{
		public DQsContractList()
		{
			InitializeComponent();
		}

		public int Retrieve( int? supplierno, string suppliername )
		{
			return RetrieveCore<QsContractList>(new List<QsContractList>
				(QsContractList.GetAllQsContractList( supplierno, suppliername )));
		}
	}
}
