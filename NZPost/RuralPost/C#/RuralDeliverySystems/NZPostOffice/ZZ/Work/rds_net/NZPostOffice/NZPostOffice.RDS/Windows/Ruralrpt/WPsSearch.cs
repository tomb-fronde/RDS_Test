using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Metex.Windows;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WPsSearch : WGenericReportSearch
    {
        public WPsSearch()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            DataUserControl dwChild;
            int? lNull;
            lNull = null;
            isDataWindow = StaticVariables.gnv_app.of_get_parameters().stringparm;
            dw_criteria.GetControlByName("st_report").Text = "\'" + StaticMessage.StringParm + "\'";
            dwChild = dw_criteria.GetChild("region_id");
            dwChild.Retrieve();
            //?dwChild.InsertRow(1);
            dwChild.SetValue(0, "region_id", lNull);
            dwChild.SetValue(0, "rgn_name", "<All Regions>");
            dwChild = dw_criteria.GetChild("region_id_ro");
            dwChild.Retrieve();
            //?dwChild.InsertRow(1);
            dwChild.SetValue(0, "region_id", lNull);
            dwChild.SetValue(0, "rgn_name", "<All Regions>");
            dw_criteria.InsertItem<PsReportCriteria>(0);
            //?dw_results.SetRowFocusIndicator(focusrect!);
            StaticVariables.gnv_app.of_get_parameters().miscstringparm = wf_getparms();

            // if g_Security.Access_Groups[3] <= 2 then
            // 	dw_Criteria.Modify ( "region_id.visible=0")
            // 	dw_Criteria.Modify ( "region_id_ro.visible=1")
            // end if
            // 
            // if not isnull ( g_Security.Region_Id) then
            // 	dw_Criteria.SetItem ( 1, "region_id", g_Security.Region_Id)
            // end if
        }

        public virtual string wf_getparms()
        {
            string sRegion;
            string sParm = string.Empty;
            string sTemp;
            string sMonth;
            int? lRegion;
            int lRow;
            int lcount;

            int sqlCode = -1;
            string sqlErrText = string.Empty;
            // get region, date
            lRegion = dw_criteria.GetItem<PsReportCriteria>(0).RegionId;
            sMonth = string.Format("mmm yy", dw_criteria.GetItem<PsReportCriteria>(0).ReportDate);
            // get region, outlet, renewal group description
            if (lRegion == null)
            {
                sParm = "All Regions";
            }
            else
            {
                //SELECT region.rgn_name  INTO :sParm FROM region  WHERE region.region_id = :lRegion;
                sParm = RDSDataService.GetRegionValue(lRegion, ref sqlCode, ref sqlErrText);
            }
            if (sMonth == null)
            {
                sParm += "\r\nDate not specified";
            }
            else
            {
                sParm += "\r\n" + sMonth;
            }
            return sParm;
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            string sTitle;
            WPsReportPreview wNewReport;
            dw_criteria.AcceptText();
            StaticVariables.gnv_app.of_get_parameters().longparm = (int)dw_criteria.GetValue(0, "region_id");
            StaticVariables.gnv_app.of_get_parameters().dateparm = (DateTime)dw_criteria.GetValue(0, "report_date");

            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().longparm))
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = 0;
            }
            sTitle = dw_criteria.GetControlByName("st_report").Text;
            StaticVariables.gnv_app.of_get_parameters().stringparm = isDataWindow;
            StaticVariables.gnv_app.of_get_parameters().miscstringparm = wf_getparms();

            Cursor.Current = Cursors.WaitCursor;
            //OpenSheetWithParm(wNewReport, sTitle, w_main_mdi, 0, original!);
            StaticMessage.PowerObjectParm = sTitle;
            WPsReportPreview w_ps_report_preview = new WPsReportPreview();
            w_ps_report_preview.MdiParent = StaticVariables.MainMDI;
            w_ps_report_preview.Show();
        }
    }
}