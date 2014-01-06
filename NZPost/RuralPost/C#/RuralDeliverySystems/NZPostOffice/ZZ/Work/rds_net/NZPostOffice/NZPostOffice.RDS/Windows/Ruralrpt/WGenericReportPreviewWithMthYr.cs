using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralsec;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    // TJB  RPCR_057  Jan-2014: NEW
    // For displaying ScheduleB reports with as-of date

    public partial class WGenericReportPreviewWithMthYr : WGenericReportPreview
    {
        private const string DEFAULT_ASSEMBLY = "NZPostOffice.RDS.DataControls";
        private const string DEFAULT_VERSION = "1.0.0.0";

        public WGenericReportPreviewWithMthYr()
        {
            InitializeComponent();
        }

        public override void ue_report()
        {
            int lRow = -1;
            int lRowCount;
            int lContract;
            int lSequence;
            int nSwitch = 0;
            //DataUserControl dwResults;
            URdsDw dwResults;
            DateTime? dReportMonth;
            dReportMonth = StaticVariables.gnv_app.of_get_parameters().monthyearParm;
            StaticVariables.gnv_app.of_get_parameters().dateparm = dReportMonth;
            //? dw_report = StaticVariables.gnv_app.of_get_parameters().stringparm;
            if (StaticVariables.gnv_app.of_get_parameters().stringparm.Length == 0)
            {
                return;
            }

            //dwResults.DataObject = (DataUserControl)StaticVariables.gnv_app.of_get_parameters().dwparm;
            //dwResults = StaticVariables.gnv_app.of_get_parameters().dwparm;
            dwResults = (URdsDw)StaticVariables.window;
            if (dwResults == null)
            {
                return;
            }

            string ls_reportname = StaticVariables.gnv_app.of_get_parameters().stringparm;
            dw_report.SetDataObject(DEFAULT_ASSEMBLY, DEFAULT_VERSION, StaticFunctions.migrateName(ls_reportname));

            // TJB  RD7_0043  Aug2009
            // Added
            string migratedName = StaticFunctions.migrateName(ls_reportname);
            //if (StaticFunctions.migrateName(ls_reportname) == "RContractSummary")
            if (migratedName == "RContractSummary")
                dw_report.DataObject = new RContractSummary();
            // TJB  RPCR_057  Jan2014
            else if (migratedName == "RSchedulebSingleContract")
                dw_report.DataObject = new RSchedulebSingleContract();

            dw_report.Reset();
            lRow = dwResults.GetSelectedRow(0);
            if (lRow >= 0)
            {
                if (dwResults.GetValue<int>(lRow, "contract_no") == 0)
                {
                    lRowCount = dwResults.RowCount;
                    for (lRow = 1; lRow <= lRowCount; lRow++)
                    {
                        lContract = dwResults.GetValue<int>(lRow, "contract_no");
                        lSequence = dwResults.GetValue<int>(lRow, "con_active_Sequence");
                        if (lContract > 0)
                        {
                            // dw_report.Retrieve(lContract, lSequence, StaticVariables.gnv_app.of_get_parameters().dateparm);
                            //dw_report.Retrieve(new object[] { lContract, lSequence, StaticVariables.gnv_app.of_get_parameters().dateparm });
                            // TJB  RPCR_057  Jan2014
                            if (migratedName == "RContractSummary")
                                dw_report.Retrieve(new object[] { lContract, lSequence, dReportMonth });
                            else if (migratedName == "RSchedulebSingleContract")
                                dw_report.Retrieve(new object[] { lContract, lSequence });
                        }
                    }
                }
                else
                {
                    while (lRow > 0)
                    {
                        lContract = dwResults.GetValue<int>(lRow, "contract_no");
                        lSequence = dwResults.GetValue<int>(lRow, "con_active_Sequence");
                        // dw_report.Retrieve(lContract, lSequence, StaticVariables.gnv_app.of_get_parameters().dateparm);
                        //dw_report.Retrieve(new object[] { lContract, lSequence, StaticVariables.gnv_app.of_get_parameters().dateparm });
                        // TJB  RD7_0043  Aug2009
                        if (nSwitch == 0)
                        {
                            dw_report.Retrieve(new object[] { lContract, lSequence, dReportMonth });
                            nSwitch++;
                        }
                        else
                        {
                            dw_report.Reset();
                            dw_report.Retrieve(new object[] { lContract, lSequence, dReportMonth });
                        }
                        lRow = dwResults.GetSelectedRow(lRow + 1);
                    }
                }
            }
        }

        public virtual void dw_report_dberror()
        {
            return;
        }
    }
}
