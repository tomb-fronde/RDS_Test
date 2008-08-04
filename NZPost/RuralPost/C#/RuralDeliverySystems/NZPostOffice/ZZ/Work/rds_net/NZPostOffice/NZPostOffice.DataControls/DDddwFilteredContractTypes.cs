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
	public partial class DDddwFilteredContractTypes : Metex.Windows.DataUserControl
	{
		public DDddwFilteredContractTypes()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_ui_id )
		{
			return RetrieveCore<FilteredContractTypes>( new List<FilteredContractTypes>(FilteredContractTypes.GetAllDddwFilteredContractTypes(al_ui_id)));
		}
	}
}
