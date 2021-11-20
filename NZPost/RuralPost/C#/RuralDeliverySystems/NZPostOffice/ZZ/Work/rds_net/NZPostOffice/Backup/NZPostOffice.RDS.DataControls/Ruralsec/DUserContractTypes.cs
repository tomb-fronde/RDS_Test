using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralsec;
//?//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralsec
{
	public partial class DUserContractTypes : Metex.Windows.DataUserControl
	{
		public DUserContractTypes()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_userid )
        {
            return RetrieveCore<UserContractTypes>(new List<UserContractTypes>(UserContractTypes.GetAllUserContractTypes(al_userid)));
		}
	}
}
