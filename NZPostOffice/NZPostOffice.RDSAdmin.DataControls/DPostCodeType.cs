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
	public partial class DPostCodeType : Metex.Windows.DataUserControl
	{
		public DPostCodeType()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
			return RetrieveCore<PostCodeType>(new List<PostCodeType>
                (PostCodeType.GetAllPostCodeType()));
		}
	}
}
