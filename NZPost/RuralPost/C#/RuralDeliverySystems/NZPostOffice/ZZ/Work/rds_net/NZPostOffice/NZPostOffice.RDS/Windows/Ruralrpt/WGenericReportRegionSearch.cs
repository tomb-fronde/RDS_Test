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
    public partial class WGenericReportRegionSearch : WGenericReportSearch
    {
        public WGenericReportRegionSearch()
        {
            InitializeComponent();

            this.dw_criteria.DataObject = new DReportGenericCriteriaWithRegion();
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //  TJB  SR4647  June 2005
            //  If this has been called for doing the outlet labels,
            //  make the 'use physical addresses' checkbox visible.
            //  Otherwise ensure it isn't visible.
            isDataWindow = StaticVariables.gnv_app.of_get_parameters().stringparm;
            if (isDataWindow == "r_outlet_label")
            {
                cbx_phy_address.Visible = true;
            }
            else
            {
                cbx_phy_address.Visible = false;
            }
            // DataControlBuilder dwChild
            // long lNull
            // 
            //  lNull = null
            // isDataWindow = gnv_App.of_Get_Parameters ( ).StringParm
            // 
            // dw_Criteria.Modify ( "st_report.text='" + Message.StringParm + "'")
            // 
            // dw_Criteria.GetChild ( "region_id", dwChild)
            // dwChild.Retrieve ( )
            // dwChild.InsertRow ( 1)
            // dwChild.SetItem ( 1, "region_id", lNull)
            // dwChild.SetItem ( 1, "rgn_name", "<All Regions>")
            // 
            // dw_Criteria.GetChild ( "region_id_ro", dwChild)
            // dwChild.Retrieve ( )
            // dwChild.InsertRow ( 1)
            // dwChild.SetItem ( 1, "region_id", lNull)
            // dwChild.SetItem ( 1, "rgn_name", "<All Regions>")
            // 
            // dw_Criteria.InsertRow ( 0)
            // 
            // dw_Results.SetRowFocusIndicator ( FocusRect!)
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            //  TJB  SR4647  June 2005
            //  Added checkbox and use of BooleanParm
            string sTitle;
            WGenericReportRegionPreview wNewReport;
            dw_criteria.AcceptText();
            StaticVariables.gnv_app.of_get_parameters().longparm = dw_criteria.GetItem<ReportGenericCriteriaWithRegion>(0).RegionId;
            StaticVariables.gnv_app.of_get_parameters().booleanparm = cbx_phy_address.Checked;
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().longparm))
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = 0;
            }
            sTitle = dw_criteria.GetControlByName("st_report").Text;
            StaticVariables.gnv_app.of_get_parameters().stringparm = isDataWindow;
            Cursor.Current = Cursors.WaitCursor;
            //OpenSheetWithParm(wNewReport, sTitle, w_main_mdi, 0, original);
            StaticMessage.PowerObjectParm = sTitle;
            WGenericReportRegionPreview w_generic_report_region_preview = new WGenericReportRegionPreview();
            w_generic_report_region_preview.MdiParent = StaticVariables.MainMDI;
            w_generic_report_region_preview.Show();
        }
    }
}