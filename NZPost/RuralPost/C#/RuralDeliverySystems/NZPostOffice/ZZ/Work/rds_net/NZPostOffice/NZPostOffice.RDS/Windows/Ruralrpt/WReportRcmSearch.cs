using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WReportRcmSearch : WGenericReportSearch
    {
        public WReportRcmSearch()
        {
            InitializeComponent();

            //jlwang:
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            //jlwang:end
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            st_label.Text = "w_report_rcm_search";
            // DataControlBuilder dwChild
            // long lNull
            // 
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
            // dw_Criteria.GetChild ( "ct_key", dwChild)
            // dwChild.Retrieve ( )
            // dwChild.InsertRow ( 1)
            // dwChild.SetItem ( 1, "ct_key", lNull)
            // dwChild.SetItem ( 1, "contract_type", "<All Types>")
            // 
            // 
            // dw_Criteria.InsertRow ( 0)
            // 
            // dw_Results.SetRowFocusIndicator ( FocusRect!)
            // 
            // dw_Criteria.GetChild ( "rg_code", dwChild)
            // dwChild.Retrieve ( )
            // dwChild.InsertRow ( 1)
            // dwChild.SetItem ( 1, "rg_code", lNull)
            // dwChild.SetItem ( 1, "rg_description", "<All Renewal Groups>")
            // dw_criteria.object.rg_code.protect=0
            // dw_criteria.object.rg_code.tabsequence=99
            // 
            // dw_criteria.DataControl["region_id"].Focus()
            // dw_criteria.setItem ( 1,"ct_key",1)
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
            int? lContractType;
            int lRow;
            int lcount;

            int sqlCode = -1;
            string sqlErrText = string.Empty;
            // get region, outlet codes
            lRegion = dw_criteria.GetItem<ReportRcmCriteria>(0).RegionId;
            lOutlet = dw_criteria.GetItem<ReportRcmCriteria>(0).OutletId;
            lRenGroup = dw_criteria.GetItem<ReportRcmCriteria>(0).RgCode;
            lContractType = dw_criteria.GetItem<ReportRcmCriteria>(0).CtKey;
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
            if (lRenGroup == null)
            {
                sParm += "\r\nAll Renewal Groups";
            }
            else
            {
                //SELECT renewal_group.rg_description  INTO :sTemp  FROM renewal_group  WHERE renewal_group.rg_code = :lRenGroup;
                sTemp = RDSDataService.GetRenewalGroupValue(lRenGroup, ref sqlCode, ref sqlErrText);
                sParm += "\r\n" + sTemp;
            }
            // May 1999
            if (lContractType == null)
            {
                sParm += "\r\nAll Contract Types";
            }
            else
            {
                //SELECT contract_type.contract_type  INTO :sTemp  FROM contract_type  WHERE contract_type.ct_key = :lContractType   ;
                sTemp = RDSDataService.GetContractTypeValue(lContractType);
                sParm += "\r\n" + sTemp;
            }
            return sParm;
        }

        #region Events
        public override void dw_criteria_itemchanged(object sender, System.EventArgs e)
        {
            string sOutlet = string.Empty;
            int? lOutletId = null;
            int lActionCode = 0;
            if (dw_criteria.GetColumnName() == "outlet_picklist")
            {
                wf_getoutlet();
            }
            else if (dw_criteria.GetColumnName() == "o_name")
            {
                sOutlet = dw_criteria.GetControlByName(dw_criteria.GetColumnName()).Text;//dw_criteria.GetText()
                if (!(StaticVariables.gnv_app.of_isempty(sOutlet)))
                {
                    if (sOutlet == "<All Outlets>")
                    {
                        lOutletId = null;
                    }
                    else
                    {
                        int sqlCode = -1;
                        //select outlet_id into :lOutletId from outlet where o_name = :sOutlet;
                        lOutletId = RDSDataService.GetOutletValue2(sOutlet, ref sqlCode);
                        if (sqlCode != 0) //(StaticVariables.sqlca.SQLCode != 0) 
                        {
                            lOutletId = null;
                            dw_criteria.SetValue(0, "o_name", "<All Outlets>");
                            lActionCode = 2;
                        }
                    }
                }
                else
                {
                    lOutletId = null;
                    dw_criteria.SetValue(0, "o_name", "<All Outlets>");
                    lActionCode = 2;
                }
                dw_criteria.SetValue(dw_criteria.GetRow(), "outlet_id", lOutletId);
            }
            return;//? lActionCode;
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            string sTitle = string.Empty;
            dw_criteria.AcceptText();

            StaticVariables.gnv_app.of_get_parameters().regionparm = dw_criteria.GetItem<ReportRcmCriteria>(0).RegionId.GetValueOrDefault();//, "region_id");
            StaticVariables.gnv_app.of_get_parameters().outletparm = dw_criteria.GetItem<ReportRcmCriteria>(0).OutletId.GetValueOrDefault();//, "outlet_id");
            StaticVariables.gnv_app.of_get_parameters().renewalgroupparm = dw_criteria.GetItem<ReportRcmCriteria>(0).RgCode.GetValueOrDefault();//, "rg_code");
            StaticVariables.gnv_app.of_get_parameters().contracttypeparm = dw_criteria.GetItem<ReportRcmCriteria>(0).CtKey.GetValueOrDefault();//, "ct_key");
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().regionparm))
            {
                StaticVariables.gnv_app.of_get_parameters().regionparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().outletparm))
            {
                StaticVariables.gnv_app.of_get_parameters().outletparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().renewalgroupparm))
            {
                StaticVariables.gnv_app.of_get_parameters().renewalgroupparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().contracttypeparm))
            {
                StaticVariables.gnv_app.of_get_parameters().contracttypeparm = 0;
            }
            sTitle = dw_criteria.GetControlByName("st_report").Text;

            StaticVariables.gnv_app.of_get_parameters().stringparm = isDataWindow;
            StaticMessage.StringParm = sTitle;

            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_get_parameters().miscstringparm = wf_getparms();
            //OpenSheetWithParm(w_report_rcm_preview, sTitle, w_main_mdi, 0, original!);
            StaticMessage.PowerObjectParm = sTitle;
            WReportRcmPreview w_report_rcm_preview = new WReportRcmPreview();
            w_report_rcm_preview.MdiParent = StaticVariables.MainMDI;
            w_report_rcm_preview.Show();
        }
        #endregion
    }
}