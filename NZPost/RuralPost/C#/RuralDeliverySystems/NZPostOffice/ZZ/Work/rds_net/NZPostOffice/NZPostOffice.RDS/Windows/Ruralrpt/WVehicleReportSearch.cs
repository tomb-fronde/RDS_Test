using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WVehicleReportSearch : WGenericReportSearch
    {
        public WVehicleReportSearch()
        {
            InitializeComponent();

            //jlwang:
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            //jlwang:end
        }

        public virtual string wf_getparms()
        {
            string sRegion;
            string sOutlet;
            string sRenGroup;
            string sContract;
            string sParm = string.Empty;
            string sTemp = string.Empty;
            int? lRegion;
            int? lOutlet;
            int? lRenGroup;
            int lContract;
            int lRow;
            int lcount;

            int sqlCode = -1;
            string sqlErrText = string.Empty;
            // get region, outlet codes
            lRegion = dw_criteria.GetItem<ReportGenericOutletCriteriawithrgct>(0).RegionId;
            lOutlet = dw_criteria.GetItem<ReportGenericOutletCriteriawithrgct>(0).OutletId;
            lRenGroup = dw_criteria.GetItem<ReportGenericOutletCriteriawithrgct>(0).RgCode;
            // get region, outlet description
            if (lRegion == null)
            {
                sParm = "All Regions";
            }
            else
            {
                //SELECT region.rgn_name  INTO :sParm FROM region  WHERE region.region_id = :lRegion;
                sParm = RDSDataService.GetRegionValue(lRegion, ref sqlCode, ref sqlErrText);
            }
            if (lOutlet == null)
            {
                sParm += "\r\nAll Outlets";
            }
            else
            {
                //SELECT outlet.o_name  INTO :sTemp  FROM outlet  WHERE outlet.outlet_id = :lOutlet;
                sTemp = RDSDataService.GetOutletValue(lOutlet);
                sParm += "\r\n" + sTemp;
            }
            if (lRenGroup == null || lRenGroup == -(1))
            {
                sParm += "\r\nAll Renewal Groups";
            }
            else
            {
                //SELECT rg_description INTO :sTemp  FROM renewal_group WHERE rg_code= :lRengroup;
                sTemp = RDSDataService.GetRenewalGroupValue(lRenGroup, ref sqlCode, ref sqlErrText);
                sParm += "\r\n" + sTemp;
            }
            return sParm;
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            string sTitle = string.Empty;
            int? ldebug;
            dw_criteria.AcceptText();
            StaticVariables.gnv_app.of_get_parameters().longparm = dw_criteria.GetItem<ReportGenericOutletCriteriawithrgct>(0).RegionId.GetValueOrDefault();
            StaticVariables.gnv_app.of_get_parameters().integerparm = dw_criteria.GetItem<ReportGenericOutletCriteriawithrgct>(0).OutletId.GetValueOrDefault();
            StaticVariables.gnv_app.of_get_parameters().renewalgroupparm = dw_criteria.GetItem<ReportGenericOutletCriteriawithrgct>(0).RgCode.GetValueOrDefault();
            StaticVariables.gnv_app.of_get_parameters().contracttypeparm = dw_criteria.GetItem<ReportGenericOutletCriteriawithrgct>(0).CtKey.GetValueOrDefault();
            ldebug = StaticVariables.gnv_app.of_get_parameters().renewalgroupparm;

            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().longparm))
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().integerparm))
            {
                StaticVariables.gnv_app.of_get_parameters().integerparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().renewalgroupparm))
            {
                StaticVariables.gnv_app.of_get_parameters().renewalgroupparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().contracttypeparm))
            {
                StaticVariables.gnv_app.of_get_parameters().contracttypeparm = 0;
            }
            sTitle = dw_criteria.GetControlByName("st_report").Text;// Describe("st_report.text");

            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_get_parameters().stringparm = "r_vehicle_age";
            //OpenSheetWithParm(w_generic_report_reg_outlet_preview, sTitle, w_main_mdi, 0, original!);
            StaticMessage.PowerObjectParm = sTitle;
            WGenericReportRegOutletPreview w_generic_report_reg_outlet_preview = new WGenericReportRegOutletPreview();
            w_generic_report_reg_outlet_preview.MdiParent = StaticVariables.MainMDI;
            w_generic_report_reg_outlet_preview.Show();
        }
    }
}