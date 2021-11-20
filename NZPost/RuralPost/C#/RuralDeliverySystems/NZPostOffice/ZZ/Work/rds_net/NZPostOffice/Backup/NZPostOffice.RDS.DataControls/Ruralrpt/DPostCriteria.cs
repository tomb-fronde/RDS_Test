using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DPostCriteria : Metex.Windows.DataUserControl
	{
		public DPostCriteria()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<PostCriteria>(new List<PostCriteria>
				(PostCriteria.GetAllPostCriteria(  )));
		}
	}
}
