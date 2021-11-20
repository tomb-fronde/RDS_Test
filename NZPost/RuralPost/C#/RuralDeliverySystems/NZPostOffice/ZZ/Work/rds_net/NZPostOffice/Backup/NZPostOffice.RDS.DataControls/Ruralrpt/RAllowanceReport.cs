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
    public partial class RAllowanceReport : Metex.Windows.DataUserControl
    {
        public RAllowanceReport()
        {
            InitializeComponent();
        }

        public int Retrieve(int? inRegionId, int? inRgCode, int? inCtKey)
        {
            DataTable subTable = new NZPostOffice.RDS.DataControls.Report.AllowanceDetailDataSet(NZPostOffice.RDS.Entity.Ruralrpt.AllowanceDetail.GetAllAllowanceDetail(inRegionId, inRgCode, inCtKey));
            this.report.Subreports["RERAllowanceDetail.rpt"].SetDataSource(subTable);
            //return RetrieveCore<AllowanceReport>(new List<AllowanceReport>(AllowanceReport.GetAllAllowanceReport()));

            this.viewer.RefreshReport();

            return 0;
        }
    }
}
