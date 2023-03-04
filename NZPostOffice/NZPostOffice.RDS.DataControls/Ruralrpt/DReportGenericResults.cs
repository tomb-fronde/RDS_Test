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
	public partial class DReportGenericResults : Metex.Windows.DataUserControl
	{
		public DReportGenericResults()
		{
			InitializeComponent();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender, e);
            }
        }

		public int Retrieve( int? inRegion, int? inOutlet, int? inRGCode, int? inSFKey, int? inCTKey )
        {
            return RetrieveCore<ReportGenericResults>(new List<ReportGenericResults>(ReportGenericResults.GetAllReportGenericResults(inRegion, inOutlet, inRGCode, inSFKey, inCTKey)));
		}

        public event EventHandler CellDoubleClick;
	}
}
