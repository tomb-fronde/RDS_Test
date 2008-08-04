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
	public partial class DComponentlist : Metex.Windows.DataUserControl
	{
		public DComponentlist()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
			return RetrieveCore<Componentlist>(new List<Componentlist>
                (Componentlist.GetAllComponentlist()));
		}
	}
}
