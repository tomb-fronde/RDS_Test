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
    // TJB  RPCR_060  Mar-2014: NEW

	public partial class DHsType : Metex.Windows.DataUserControl

	{
		public DHsType()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<HSType>(new List<HSType>
                (HSType.GetAllHSType()));
            if(this.SortString != "")
                this.Sort<HSType>();
            return ret;
		}
	}
}
