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
	public partial class DwRunningSheetHeader : Metex.Windows.DataUserControl
	{
		public DwRunningSheetHeader()
		{
			InitializeComponent();
		}

		public int Retrieve( int? incontract, int? insfkey, string indeldays )
		{
			return RetrieveCore<RunningSheetHeader>(new List<RunningSheetHeader>
				(RunningSheetHeader.GetAllRunningSheetHeader(incontract, insfkey, indeldays )));
		}

        public void Print()
        {
            //this.viewer.RefreshReport();

            DwRunningSheetHeader_RetrieveEnd(null, null);

            this.viewer.PrintReport();
        }
	}
}
