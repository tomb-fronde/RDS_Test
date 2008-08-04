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
	public partial class DDddwRoadType : Metex.Windows.DataUserControl
	{
		public DDddwRoadType()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
		{
            List<DddwRoadType> sourceList = new List<DddwRoadType>(DddwRoadType.GetAllDddwRoadType());
            //! add an empty item at top of dropdown
            DddwRoadType emptyItem = new DddwRoadType();
            emptyItem.RtId = -100;
            emptyItem.RtName = string.Empty;
            sourceList.Insert(0, emptyItem);

            return RetrieveCore<DddwRoadType>(new List<DddwRoadType>(sourceList));
		}
	}
}
