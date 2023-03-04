using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.Entity;

namespace NZPostOffice.DataControls
{
	public partial class DUserContractTypes : Metex.Windows.DataUserControl
	{
		public DUserContractTypes()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_userid )
		{
			return RetrieveCore<UserContractTypes>(new List<UserContractTypes>
                (UserContractTypes.GetAllUserContractTypes(al_userid)));
		}
	}
}
