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
	public partial class DMailCategory : Metex.Windows.DataUserControl
	{
		public DMailCategory()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
		}

		public override int Retrieve(  )
		{
			return RetrieveCore<MailCategory>(new List<MailCategory>
				(MailCategory.GetAllMailCategory(  )));
		}
	}
}
