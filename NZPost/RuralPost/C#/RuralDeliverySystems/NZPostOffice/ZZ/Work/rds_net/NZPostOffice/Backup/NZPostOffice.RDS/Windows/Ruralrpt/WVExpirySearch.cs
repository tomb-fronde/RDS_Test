using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WVExpirySearch : WGenericReportSearch
    {
        public WVExpirySearch()
        {
            InitializeComponent();
            dw_criteria.DataObject = new DVehicleExpCriteria();
            dw_results.DataObject = new DReportGenericResults();

            //jlwang:
            dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_criteria_constructor);
            //jlwang:end
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            this.rb_region_clicked(null, null);
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
            lRegion = dw_criteria.GetItem<VehicleExpCriteria>(0).RegionId;
            lOutlet = dw_criteria.GetItem<VehicleExpCriteria>(0).OutletId;
            lRenGroup = dw_criteria.GetItem<VehicleExpCriteria>(0).RgCode;
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

        public override void dw_criteria_constructor()
        {
            //?base.constructor();
            dw_criteria.GetControlByName("rg_code").TabIndex = 0;
            dw_criteria.GetControlByName("region_id").TabIndex = 10;
            //?dw_criteria.(7)DataControl["region_id"].BackColor =\'16777215\'");
            //?dw_criteria.(7)DataControl["rg_code"].BackColor =\'79741120\'");
        }

        #region Events
        public override void pb_open_clicked(object sender, EventArgs e)
        {
            string sTitle;
            int ldebug;

            int sqlCode = -1;
            string sqlErrText = string.Empty;
            dw_criteria.InsertItem<VehicleExpCriteria>(0);
            dw_criteria.AcceptText();
            //  gnv_App.of_Get_Parameters ( ).IntegerParm 	= dw_Criteria.GetItemNumber ( 1, "outlet_id")
            //  gnv_App.of_Get_Parameters ( ).renewalgroupparm = dw_Criteria.GetItemNumber ( 1, "rg_code")
            //  gnv_App.of_Get_Parameters ( ).contracttypeparm  = dw_Criteria.GetItemNumber ( 1, "ct_key")
            //  ldebug=gnv_App.of_Get_Parameters ( ).renewalgroupparm
            // if f_nEmpty ( gnv_App.of_Get_Parameters ( ).LongParm) then gnv_App.of_Get_Parameters ( ).LongParm = 0
            // if f_nEmpty ( gnv_App.of_Get_Parameters ( ).IntegerParm) then gnv_App.of_Get_Parameters ( ).IntegerParm = 0
            // if f_nEmpty ( gnv_App.of_Get_Parameters ( ).renewalgroupparm) then gnv_App.of_Get_Parameters ( ).renewalgroupparm = 0
            // if f_nEmpty ( gnv_App.of_Get_Parameters ( ).contracttypeparm) then gnv_App.of_Get_Parameters ( ).contracttypeparm = 0

            //?sTitle = dw_criteria.GetControlByName("st_report").Text;//Describe("st_report.text");

            Cursor.Current = Cursors.WaitCursor;
            //  gnv_App.of_Get_Parameters ( ).StringParm = 'r_vehicle_expiry_report' 
            //  see which kind of search parameter to kick of the report with
            if (ii_report_type == 1)
            {
                int? li_region_id;
                li_region_id = dw_criteria.GetItem<VehicleExpCriteria>(0).RegionId;// "region_id");
                StaticVariables.gnv_app.of_get_parameters().longparm = li_region_id.GetValueOrDefault();
                StaticVariables.gnv_app.of_get_parameters().integerparm = 1;
                //  get the region name :
                string ls_region = string.Empty;
                if (li_region_id > 0)
                {
                    //SELECT rgn_name INTO :ls_region FROM region WHERE region.region_id = :li_region_id USING SQLCA;
                    ls_region = RDSDataService.GetRegionValue(li_region_id, ref sqlCode, ref sqlErrText);
                    if (sqlCode < 0)
                    {
                        MessageBox.Show(sqlErrText, "Error in database query", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    ls_region = "All Regions";
                }
                StaticVariables.gnv_app.of_get_parameters().stringparm = "Region: " + ls_region;
            }
            else if (ii_report_type == 2)
            {
                int? li_renew_id;
                li_renew_id = dw_criteria.GetItem<VehicleExpCriteria>(0).RgCode;//, "rg_code");
                StaticVariables.gnv_app.of_get_parameters().longparm = li_renew_id.GetValueOrDefault();
                StaticVariables.gnv_app.of_get_parameters().integerparm = 2;
                //  get the region name :
                string ls_renew = string.Empty;
                if (li_renew_id > 0)
                {
                    // SELECT rg_description INTO :ls_renew FROM renewal_group WHERE renewal_group.rg_code = :li_renew_id  USING SQLCA;
                    ls_renew = RDSDataService.GetRenewalGroupValue(li_renew_id, ref sqlCode, ref sqlErrText);
                    if (sqlCode < 0)
                    {
                        MessageBox.Show(sqlErrText, "Error in database query", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    ls_renew = "All Groups";
                }
                //StaticMessage.StringParm = "Renewal Group : " + ls_renew; // 
                StaticVariables.gnv_app.of_get_parameters().stringparm = "Renewal Group : " + ls_renew;
            }
            //OpenSheetWithParm(w_vehicle_expiry_report, parent, w_main_mdi, 0, original!);
            //? StaticMessage.PowerObjectParm = parent;
            WVehicleExpiryReport w_vehicle_expiry_report = new WVehicleExpiryReport();
            w_vehicle_expiry_report.MdiParent = StaticVariables.MainMDI;
            w_vehicle_expiry_report.Show();
        }

        public virtual void rb_region_clicked(object sender, EventArgs e)
        {
            dw_criteria.GetControlByName("rg_code").TabIndex = 0;
            dw_criteria.GetControlByName("region_id").TabIndex = 10;
            dw_criteria.DataObject.GetControlByName("rg_code").Enabled = false;
            dw_criteria.DataObject.GetControlByName("region_id").Enabled = true;

            //? dw_criteria.(7)DataControl["region_id"].BackColor =\'16777215\'");
            //? dw_criteria.(7)DataControl["rg_code"].BackColor =\'79741120\'");
            ii_report_type = 1;
        }

        public virtual void rb_renewal_clicked(object sender, EventArgs e)
        {
            dw_criteria.GetControlByName("region_id").TabIndex = 0;
            dw_criteria.GetControlByName("rg_code").TabIndex = 20;
            dw_criteria.DataObject.GetControlByName("rg_code").Enabled = true;
            dw_criteria.DataObject.GetControlByName("region_id").Enabled = false;
            //? dw_criteria.(7)DataControl["rg_code"].BackColor =\'16777215\'");
            //? dw_criteria.(7)DataControl["region_id"].BackColor =\'79741120\'");
            ii_report_type = 2;
        }
        #endregion
    }
}
