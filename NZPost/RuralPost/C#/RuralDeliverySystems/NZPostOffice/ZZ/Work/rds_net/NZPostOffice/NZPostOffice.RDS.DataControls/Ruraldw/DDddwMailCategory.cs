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
    public partial class DDddwMailCategory : Metex.Windows.DataUserControl
	{
		public DDddwMailCategory()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
		}

		public int Retrieve( string in_Business, string in_Residential, string in_Farmer )
		{
			return RetrieveCore<DddwMailCategory>(new List<DddwMailCategory>
				(DddwMailCategory.GetAllDddwMailCategory( in_Business, in_Residential, in_Farmer )));
		}
	}
}
