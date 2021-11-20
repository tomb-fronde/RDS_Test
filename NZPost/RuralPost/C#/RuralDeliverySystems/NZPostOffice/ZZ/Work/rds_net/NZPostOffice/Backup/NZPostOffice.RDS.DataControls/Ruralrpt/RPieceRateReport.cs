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
	public partial class RPieceRateReport : Metex.Windows.DataUserControl
	{
  		public RPieceRateReport()
		{
			InitializeComponent();
		}

        private string u_stparms = string.Empty;
        //private int? u_lContract = 0;
        private string u_lContract = string.Empty;
        private int? u_lRegion = 0;
        private int? u_lOutlet = 0;
        private DateTime? u_dPrMonth = DateTime.MinValue;
        public DateTime? UDPrMonth
        {
            set
            {
                u_dPrMonth = value;
            }
        }
		//public int Retrieve( int? lContract, int? lRegion, int? lOutlet, DateTime? dPrMonth )
        public int Retrieve(string lContract, int? lRegion, int? lOutlet, DateTime? dPrMonth)
        {
            u_lContract = lContract;
            u_lRegion = lRegion.GetValueOrDefault();
            u_lOutlet = lOutlet.GetValueOrDefault();
            u_dPrMonth = dPrMonth.GetValueOrDefault();
            int ret = 0;

            try
            {
                ret = RetrieveCore<PieceRateReport>(new List<PieceRateReport>(
                    PieceRateReport.GetAllPieceRateReport(lContract, lRegion, lOutlet, dPrMonth)));
            }catch(Exception error){}

            viewer.RefreshReport();
            return ret;
		}
	}
}
