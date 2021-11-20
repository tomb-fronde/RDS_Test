using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.Entity;
//using NZPostOffice.RDSAdmin.DataControls.EpDropdowns;

namespace NZPostOffice.DataControls
{
	public partial class DUserTest : Metex.Windows.DataUserControl
	{
		public DUserTest()
		{
			InitializeComponent();
		}

		public int Retrieve( string as_username )
		{
			return RetrieveCore<UserTest>( new List<UserTest>(UserTest.GetAllUserTest(as_username)));
		}
	}
}
