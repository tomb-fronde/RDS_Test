using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	public partial class DFixedAssetType : Metex.Windows.DataUserControl
	{
		public DFixedAssetType()
		{
			InitializeComponent();
            this.SortString = "fat_description A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<FixedAssetType>(new List<FixedAssetType>
				(FixedAssetType.GetAllFixedAssetType(  )));
            if(this.SortString != "")
                this.Sort<FixedAssetType>();
            return ret;
		}
	}
}
