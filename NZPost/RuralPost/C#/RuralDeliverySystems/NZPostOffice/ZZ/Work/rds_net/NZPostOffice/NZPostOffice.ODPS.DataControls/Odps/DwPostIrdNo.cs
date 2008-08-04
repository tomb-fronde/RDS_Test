using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
	public partial class DwPostIrdNo : Metex.Windows.DataUserControl
	{
		public DwPostIrdNo()
		{
			InitializeComponent();
		}

		public int Retrieve( DateTime? edate )
        {
			return RetrieveCore<PostIrdNo>(PostIrdNo.GetAllPostIrdNo(edate));
		}
	}
}
