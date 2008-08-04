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
	public partial class DwReportCriteriaFinancial : Metex.Windows.DataUserControl
	{
		public DwReportCriteriaFinancial()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
        {
			return RetrieveCore<ReportCriteriaFinancial>(ReportCriteriaFinancial.GetAllReportCriteriaFinancial());
		}
	}
}
