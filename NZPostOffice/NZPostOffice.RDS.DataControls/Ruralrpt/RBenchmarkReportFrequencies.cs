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
	public partial class RBenchmarkReportFrequencies : Metex.Windows.DataUserControl
	{
		public RBenchmarkReportFrequencies()
		{
			InitializeComponent();
		}

        private int ai_contractNo = 0;
		public int Retrieve( int? contract_no )
        {
            ai_contractNo = contract_no.GetValueOrDefault();
            int ret = RetrieveCore<BenchmarkReportFrequencies>(new List<BenchmarkReportFrequencies>(BenchmarkReportFrequencies.GetAllBenchmarkReportFrequencies(contract_no)));
            this.viewer.RefreshReport();
            return ret;
		}
	}
}
