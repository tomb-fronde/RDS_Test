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
	public partial class DDddwFixedAssetType : Metex.Windows.DataUserControl
	{
		public DDddwFixedAssetType()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
            int ll_return;
            ll_return =  RetrieveCore<DddwFixedAssetType>(DddwFixedAssetType.GetAllDddwFixedAssetType());
            this.SortString = "fat_description A";
            this.Sort<DddwFixedAssetType>();
            return ll_return;
		}
	}
}
