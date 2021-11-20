using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Report;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    public partial class RRcmStatNestedReport : Metex.Windows.DataUserControl
    {
        public RRcmStatNestedReport()
        {
            InitializeComponent();
        }

        public int Retrieve(int? inRegion, int? inOutlet, int? inRengroup, int? inContractType)
        {
            int ret = 0;//RetrieveCore<RcmStatNestedReport>(new List<RcmStatNestedReport>(RcmStatNestedReport.GetAllRcmStatNestedReport()));

            try   //p! attempt to remove "no error" exception from Crystal Reports
            {
                DataTable table2 = new RcmStatisticalReportDataSet(RcmStatisticalReport.GetAllRcmStatisticalReport(inRegion, inOutlet, inRengroup, inContractType));
                this.reRRcmStatNestedReport.Subreports["RERRcmStatisticalReport.rpt"].SetDataSource(table2);

                //!(this.reRRcmStatNestedReport.Subreports["RERRcmStatisticalReport.rpt"].ReportDefinition.ReportObjects["CrossTab1"] as
                //!    CrystalDecisions.CrystalReports.Engine.CrossTabObject)

                this.viewer.RefreshReport();
            }
                // TJB  RD7_0043 Aug2009
                // Added set return code on error (was empty)
            catch(Exception e)
            {
                ret = -1;
            }
            return ret;
        }
    }
}
