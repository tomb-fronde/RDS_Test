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
	public partial class DDddwRoadSuffix : Metex.Windows.DataUserControl
	{
		public DDddwRoadSuffix()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
            List<DddwRoadSuffix> sourceList = new List<DddwRoadSuffix>(DddwRoadSuffix.GetAllDddwRoadSuffix());

            //pp! adding an empty row in beginning of dropdown
            DddwRoadSuffix emptyItem = new DddwRoadSuffix();
            emptyItem.RsId = -100;
            emptyItem.RsName = string.Empty;
            sourceList.Insert(0, emptyItem);

            return RetrieveCore<DddwRoadSuffix>(sourceList);
		}
	}
}
