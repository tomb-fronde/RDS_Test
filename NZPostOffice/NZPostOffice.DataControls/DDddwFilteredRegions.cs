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
	public partial class DDddwFilteredRegions : Metex.Windows.DataUserControl
	{
		public DDddwFilteredRegions()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
			return RetrieveCore<FilteredRegions>( new List<FilteredRegions>(FilteredRegions.GetAllDddwFilteredRegions()));
		}
	}
}
