using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DOutValList : Metex.Windows.DataUserControl
	{
		public DOutValList()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
            int ret = RetrieveCore<OutValList>(new List<OutValList>(OutValList.GetAllOutValList()));
            this.SortString = "region A,list_printed A,contract_no A";
            this.Sort<OutValList>();
            return ret;
		}
	}
}
