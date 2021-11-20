using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Metex.Windows;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WPieceRateReport : WGenericReportPreview
    {
        private DataUserControl dwResults;

        public WPieceRateReport()
        {
            InitializeComponent();

            dw_report.DataObject = new RPieceRateReport();
        }

        //added 
        WPieceRateSearch w_piece_rate_search = new WPieceRateSearch();

        public override void pfc_preopen()
        {
            //?base.pfc_preopen();
            Cursor.Current = Cursors.WaitCursor;
            int? lRegion;
            int? lOutlet;
            DateTime? dReportMonth;
            Dictionary<int, int?> lContracts = new Dictionary<int, int?>();// IntArray lContracts = new IntArray();
            int lRow = 0;
            int lRowCount;
            int lSequence;
            int lUpperBound = 0;
            //?dw_report.Modify("DataWindow.Print.Preview=Yes");
            lRegion = StaticVariables.gnv_app.of_get_parameters().regionIdPram;//, "region_id");
            lOutlet = StaticVariables.gnv_app.of_get_parameters().outletIdParm;//, "outlet_id");
            dReportMonth = StaticVariables.gnv_app.of_get_parameters().monthyearParm;//, "monthyear").Date;
            if (lRegion == null)
            {
                lRegion = 0;
            }
            if (lOutlet == null)
            {
                lOutlet = 0;
            }
            if (dReportMonth == null)
            {
                dReportMonth = System.Convert.ToDateTime(System.DateTime.Today.Year + "," + System.DateTime.Today.Month + ", 1");// Year(Today()), Month(Today()), 1);
            }
            // dReportMonth = StaticMethods.RelativeDate( dReportMonth, 40)
            // dReportMonth = StaticMethods.RelativeDate( dReportMonth, 0 - Day ( dReportMonth))
            dwResults = StaticVariables.gnv_app.of_get_parameters().resultdwparm;
            lRow = GetSelectedRow(0);
            if (lRow >= 0)
            {
                RPieceRateReport dw = new RPieceRateReport();
                dw.UDPrMonth = dReportMonth;
                if (dwResults.GetItem<ReportGenericResults>(lRow).ContractNo == 0)
                {
                    lRowCount = dwResults.RowCount;
                    List<int> lContracts1 = new List<int>();
                    for (int i = 0; i < lRowCount; i++)//! initialize array
                    {
                        lContracts1.Add(0);
                    }

                    for (lRow = lRowCount; lRow >= 2; lRow -= 1)
                    {                       
                        lContracts1[lRowCount - 1] = dwResults.GetItem<ReportGenericResults>(lRow-1).ContractNo.GetValueOrDefault();                        
                    }
                    if (lContracts1.Count > 0)
                    {
                        string contractNo = string.Empty;
                        for (int i = 0; i < lContracts1.Count; i++)
                        {
                            if(i==0)
                            {
                                contractNo += "" + lContracts1[0];
                                continue;
                            }
                            contractNo += ", " + lContracts1[i];
                        }

                        ((NZPostOffice.RDS.DataControls.Ruralrpt.RPieceRateReport)dw_report.DataObject).Retrieve(contractNo, lRegion, lOutlet, dReportMonth);
                    }
                }
                else
                {
                    while (lRow >= 0)
                    {
                        lUpperBound++;
                        lContracts[lUpperBound] = dwResults.GetItem<ReportGenericResults>(lRow).ContractNo;
                        //comment by hhuang
                        //((NZPostOffice.RDS.DataControls.Ruralrpt.RPieceRateReport)dw_report.DataObject).Retrieve(dwResults.GetItem<ReportGenericResults>(lRow).ContractNo, lRegion, lOutlet, dReportMonth);
                        lRow = GetSelectedRow(lRow + 1);
                    }
                    string contractNo = "";
                    Dictionary<int, int?>.ValueCollection valColl = lContracts.Values;
                    foreach (int? var in valColl)
                    {
                        contractNo += var.GetValueOrDefault().ToString() + ",";
                    }
                    if (!string.IsNullOrEmpty(contractNo))
                    {
                        contractNo = contractNo.Substring(0, contractNo.Length - 1);
                    }
                    ((NZPostOffice.RDS.DataControls.Ruralrpt.RPieceRateReport)dw_report.DataObject).Retrieve(contractNo, lRegion, lOutlet, dReportMonth);
                }
            }
            // dw_report.Modify("stParms.text=\'" + StaticVariables.gnv_app.of_get_parameters().miscstringparm + '\'');
            //dw_report.GetControlByName("stParms").Text = "\'" + StaticVariables.gnv_app.of_get_parameters().miscstringparm + "\'";
        }

        public int GetSelectedRow(int row) //added by ygu
        {
            if (dwResults.GetControlByName("grid") == null || row < 0 || row > dwResults.RowCount || ((DataEntityGrid)dwResults.GetControlByName("grid")).RowCount <= 0)
            {
                return -1;
            }

            for (int i = row; i < dwResults.RowCount; i++)
            {
                if (((DataEntityGrid)dwResults.GetControlByName("grid")).Rows[i].Selected)
                    return i;
            }
            return -1;
        }
    }
}
