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
	public partial class DArticalType : Metex.Windows.DataUserControl
	{
		public DArticalType()
		{
			InitializeComponent();
            this.SortString = "at_description A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<ArticalType>(new List<ArticalType>
				(ArticalType.GetAllArticalType(  )));
            if(this.SortString != "")
                this.Sort<ArticalType>();
            return ret;
		}
	}
}
