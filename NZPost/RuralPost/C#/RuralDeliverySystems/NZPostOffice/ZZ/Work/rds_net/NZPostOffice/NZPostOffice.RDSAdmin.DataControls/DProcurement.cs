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
	public partial class DProcurement : Metex.Windows.DataUserControl
	{
		public DProcurement()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
			return RetrieveCore<Procurement>(new List<Procurement>
				(Procurement.GetAllProcurement(  )));
		}
	}
}
