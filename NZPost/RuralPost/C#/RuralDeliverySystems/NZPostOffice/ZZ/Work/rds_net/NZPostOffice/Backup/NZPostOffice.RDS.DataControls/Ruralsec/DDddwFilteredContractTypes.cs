using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralsec;

namespace NZPostOffice.RDS.DataControls.Ruralsec
{
	public partial class DDddwFilteredContractTypes : Metex.Windows.DataUserControl
	{
		public DDddwFilteredContractTypes()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_ui_id )
		{
			return RetrieveCore<DddwFilteredContractTypes>(new List<DddwFilteredContractTypes>
                (DddwFilteredContractTypes.GetAllDddwFilteredContractTypes(al_ui_id)));
		}
	}
}
