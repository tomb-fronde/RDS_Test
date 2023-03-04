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
	public partial class DColdef : Metex.Windows.DataUserControl
	{
		public DColdef()
		{
			InitializeComponent();
		}

		public int Retrieve( string inTable, string inCreator )
		{
			return RetrieveCore<Coldef>(new List<Coldef>
				(Coldef.GetAllColdef( inTable, inCreator )));
		}
	}
}
