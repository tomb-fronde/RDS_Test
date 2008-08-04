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
    public partial class DAddFixedAsset : Metex.Windows.DataUserControl
	{
		public DAddFixedAsset()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			fat_id.AssignDropdownType<DDddwFixedAssetType>();
		}

		public int Retrieve( int? contract_no )
		{
			return RetrieveCore<AddFixedAsset>(new List<AddFixedAsset>
				(AddFixedAsset.GetAllAddFixedAsset( contract_no )));
		}
	}
}
