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
    public partial class WGenericReportRegOutletSearch : WGenericReportSearch
    {
        public WGenericReportRegOutletSearch()
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
            string sParm;
            string sTemp;
            int? lRegion;
            int? lOutlet;
            int? lRenGroup;
            int lContract;
            int lRow;
            int lcount;
            // get region, outlet codes
            lRegion = dw_criteria.GetItem<ReportGenericOutletCriteriawithrg>(0).RegionId;
            lOutlet = dw_criteria.GetItem<ReportGenericOutletCriteriawithrg>(0).OutletId;
            lRenGroup = dw_criteria.GetItem<ReportGenericOutletCriteriawithrg>(0).RgCode;
            // get region, outlet description
            if (lRegion == null)
            {
                sParm = "All Regions";
            }
            else
            {
                // SELECT region.rgn_name INTO :sParm FROM region  WHERE region.region_id = :lRegion;
                sParm = RDSDataService.GetRegion(lRegion);
            }
            if (lOutlet == null)
            {
                sParm += "\r\nAll Outlets";
            }
            else
            {
                //  SELECT outlet.o_name  INTO :sTemp  FROM outlet  WHERE outlet.outlet_id = :lOutlet;
                sTemp = RDSDataService.GetOutletId(lOutlet);
                sParm += "\r\n" + sTemp;
            }
            if (lRenGroup == null || lRenGroup == -(1))
            {
                sParm += "\r\nAll Renewal Groups";
            }
            else
            {
                // SELECT rg_description  INTO :sTemp  FROM renewal_group  WHERE rg_code= :lRengroup;
                sTemp = Convert.ToString(RDSDataService.GetRenewalGroup(lRenGroup));
                sParm += "\r\n" + sTemp;
            }
            return sParm;
        }

        #region Events
        public override void pb_open_clicked(object sender, EventArgs e)
        {
            string sTitle;
            int? ldebug;
            dw_criteria.AcceptText();
            StaticVariables.gnv_app.of_get_parameters().longparm = dw_criteria.GetItem<ReportGenericOutletCriteriawithrg>(0).RegionId;
            StaticVariables.gnv_app.of_get_parameters().integerparm = dw_criteria.GetItem<ReportGenericOutletCriteriawithrg>(0).OutletId;
            StaticVariables.gnv_app.of_get_parameters().contracttypeparm = dw_criteria.GetItem<ReportGenericOutletCriteriawithrg>(0).CtKey;
            StaticVariables.gnv_app.of_get_parameters().renewalgroupparm = dw_criteria.GetItem<ReportGenericOutletCriteriawithrg>(0).RgCode;
            ldebug = StaticVariables.gnv_app.of_get_parameters().renewalgroupparm;
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().longparm))
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().integerparm))
            {
                StaticVariables.gnv_app.of_get_parameters().integerparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().contracttypeparm))
            {
                StaticVariables.gnv_app.of_get_parameters().contracttypeparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().renewalgroupparm))
            {
                StaticVariables.gnv_app.of_get_parameters().renewalgroupparm = 0;
            }
            sTitle = dw_criteria.GetControlByName("st_report").Text;
            StaticVariables.gnv_app.of_get_parameters().stringparm = isDataWindow;
            StaticMessage.StringParm = sTitle;
            Cursor.Current = Cursors.WaitCursor;
            if (StaticVariables.gnv_app.of_get_parameters().stringparm == "r_vehicle_perf")
            {
                StaticVariables.gnv_app.of_get_parameters().miscstringparm = wf_getparms();
            }
            // OpenSheetWithParm(w_generic_report_reg_outlet_preview, sTitle, w_main_mdi, 0, original);
            StaticMessage.PowerObjectParm = sTitle;
            WGenericReportRegOutletPreview w_generic_report_reg_outlet_preview = new WGenericReportRegOutletPreview();
            w_generic_report_reg_outlet_preview.MdiParent = StaticVariables.MainMDI;
            w_generic_report_reg_outlet_preview.Show();
        }

        public override void dw_criteria_clicked(object sender, EventArgs e)
        {
            base.dw_criteria_clicked(sender, e);
        }

        #endregion

        //public override void pfc_preopen()
        //{
        //    base.pfc_preopen();
        //    st_label.Text = "w_generic_report_reg_outlet_search";
        //}
    }
}