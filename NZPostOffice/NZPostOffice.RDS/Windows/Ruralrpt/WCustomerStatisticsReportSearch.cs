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
    public partial class WCustomerStatisticsReportSearch : WGenericReportSearch
    {  
        public string isDesc = String.Empty;

        public WCustomerStatisticsReportSearch()
        {
            InitializeComponent();

            this.dw_list.DataObject = new DOccupationlist();
            dw_list.DataObject.BorderStyle = BorderStyle.Fixed3D;
            this.dw_criteria.DataObject = new DReportCustomerStatisticsCriteria();
            dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwang;moved from IC
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            //jlwang:end
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            DataUserControl dwChild;
            int lNull;
            bool lb_privacy_override = false;
            //  Check if user has the ability to override privacy flag
            lb_privacy_override = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_privacyoverride();
            if (lb_privacy_override == null || lb_privacy_override == false)
            {
                //  set the privacy checkbox to 'No' and disable the field
                cbx_privacy.Checked = false;
                cbx_privacy.Enabled = false;
            }
            else
            {
                //  allow user to choose the privacy settings
                cbx_privacy.Checked = true;
            }
            // set up the list
            //?  dw_list.DataObject = StaticVariables.gnv_app.of_get_parameters().miscstringparm;
            //? dw_list.SettransObject(StaticVariables.sqlca);
            if (StaticVariables.gnv_app.of_get_parameters().miscstringparm == "d_occupationlist")
            {
                ((DOccupationlist)dw_list.DataObject).Retrieve();
                isDesc = "occupation";
            }
            else
            {
                dw_list.DataObject = new DInterestlist();
                ((DInterestlist)dw_list.DataObject).Retrieve();
                isDesc = "interest";
            }
            ((DataEntityGrid)dw_list.GetControlByName("grid")).MultiSelect = false;
            dw_criteria.GetControlByName("region_id").Focus();
            if (dw_list.DataObject is DOccupationlist)
            {
                dw_list.InsertItem<Occupationlist>(0);
                dw_list.GetItem<Occupationlist>(0).Id = 0;
                dw_list.GetItem<Occupationlist>(0).Description = "<Any>";
                dw_list.GetItem<Occupationlist>(0).MarkClean();
            }
            if (dw_list.DataObject is DInterestlist)
            {
                dw_list.InsertItem<Interestlist>(0);
                dw_list.GetItem<Interestlist>(0).Id = 0;
                dw_list.GetItem<Interestlist>(0).Description = "<Any>";
                dw_list.DataObject.BorderStyle = BorderStyle.Fixed3D;
                dw_list.GetItem<Interestlist>(0).MarkClean();
            }
            ((DataEntityGrid)dw_list.GetControlByName("grid")).MultiSelect = true;
            dw_list.SelectRow(1, true);// SelectRow(0, true);
            cbx_privacy.Visible = true;
            cbx_privacy.BringToFront();
            cbx_privacy.Enabled = true;
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
            int lRenGroup;
            int lContract;
            int? lContractType;
            int lRow;
            int lcount;
            // get region, outlet codes
            lRegion = dw_criteria.GetItem<ReportCustomerStatisticsCriteria>(0).RegionId;
            lOutlet = dw_criteria.GetItem<ReportCustomerStatisticsCriteria>(0).OutletId;
            // lRenGroup = dw_criteria.getitemnumber ( 1,"rg_code")
            lContractType = dw_criteria.GetItem<ReportCustomerStatisticsCriteria>(0).CtKey;
            // get region, outlet description
            if (lRegion == null)
            {
                sParm = "All Regions";
            }
            else
            {
                /* SELECT region.rgn_name INTO :sParm FROM region WHERE region.region_id = :lRegion;*/
                sParm = RDSDataService.GetRegion(lRegion);
            }
            if (lOutlet == null)
            {
                sParm += "\r\nAll Outlets";
            }
            else
            {
                /* SELECT outlet.o_name INTO :sTemp FROM outlet WHERE outlet.outlet_id = :lOutlet;*/
                sTemp = RDSDataService.GetOutletId(lOutlet);
                sParm += "\r\n" + sTemp;
            }
            // if isnull ( lRengroup) then 
            // 	sParm+='\r\nAll Renewal Groups'
            // else
            // 	SELECT renewal_group.rg_description  
            // 	INTO	:sTemp  
            // 	FROM renewal_group  
            // 	WHERE renewal_group.rg_code = :lRenGroup   ;
            // 	sParm+='\r\n'+sTemp
            // end if
            // May 1999
            if (lContractType == null)
            {
                sParm += "\r\nAll Contract Types";
            }
            else
            {
                /* SELECT contract_type.contract_type INTO :sTemp FROM contract_type WHERE contract_type.ct_key = :lContractType;*/
                sTemp = RDSDataService.GetCtKey(lContractType);
                sParm += "\r\n" + sTemp;
            }
            return sParm;
        }
   
        public virtual void dw_list_constructor()
        {
            //? base.constructor();
            dw_list.of_SetUpdateable(false);
            dw_list.of_SetRowSelect(true);
            //?inv_rowselect.of_SetStyle(1);
        }

        #region Events
        public override void dw_criteria_itemchanged(object sender, EventArgs e)
        {
            //? base.itemchanged();
            string sOutlet;
            int? lOutletId;
            int lActionCode = 0;
            int SQLCode = 0;
            if (dw_criteria.GetColumnName() == "outlet_picklist")
            {
                wf_getoutlet();
            }
            else if (dw_criteria.GetColumnName() == "o_name")
            {
                sOutlet = dw_criteria.GetControlByName(dw_criteria.GetColumnName()).Text; //dw_criteria.GetText();
                if (!(StaticVariables.gnv_app.of_isempty(sOutlet)))
                {
                    if (sOutlet == "<All Outlets>")
                    {
                        lOutletId = null;
                    }
                    else
                    {
                        /* select outlet_id into :lOutletId from outlet where o_name = :sOutlet;*/
                        lOutletId = RDSDataService.GetOutlet(sOutlet, ref SQLCode);
                        if (SQLCode != 0)
                        {
                            lOutletId = null;
                            dw_criteria.GetItem<ReportCustomerStatisticsCriteria>(0).OName = "<All Outlets>";
                            lActionCode = 2;
                        }
                    }
                }
                else
                {
                    lOutletId = null;
                    dw_criteria.GetItem<ReportCustomerStatisticsCriteria>(0).OName = "<All Outlets>";
                    lActionCode = 2;
                }
                dw_criteria.GetItem<ReportCustomerStatisticsCriteria>(dw_criteria.GetRow()).OutletId = lOutletId;
            }
            return; //lActionCode;
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            string sTitle;
            int lRow;
            int? lID;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            Cursor.Current = Cursors.WaitCursor;
            dw_criteria.AcceptText();
            StaticVariables.gnv_app.of_get_parameters().regionparm = Convert.ToInt32(dw_criteria.GetItem<ReportCustomerStatisticsCriteria>(0).RegionId);
            StaticVariables.gnv_app.of_get_parameters().outletparm = Convert.ToInt32(dw_criteria.GetItem<ReportCustomerStatisticsCriteria>(0).OutletId);
            // gnv_App.of_Get_Parameters ( ).renewalgroupParm = dw_Criteria.GetItemNumber ( 1, "rg_code")
            StaticVariables.gnv_app.of_get_parameters().contracttypeparm = Convert.ToInt32(dw_criteria.GetItem<ReportCustomerStatisticsCriteria>(0).CtKey);
            // Privacy checkbox
            if (cbx_privacy.Checked == true)
            {
                StaticVariables.gnv_app.of_get_parameters().privacyparm = 1;
            }
            else
            {
                StaticVariables.gnv_app.of_get_parameters().privacyparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().regionparm))
            {
                StaticVariables.gnv_app.of_get_parameters().regionparm = 0;
            }
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().outletparm))
            {
                StaticVariables.gnv_app.of_get_parameters().outletparm = 0;
            }
            // if f_nEmpty ( gnv_App.of_Get_Parameters ( ).renewalgroupParm) then gnv_App.of_Get_Parameters ( ).renewalgroupParm = 0
            if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().contracttypeparm))
            {
                StaticVariables.gnv_app.of_get_parameters().contracttypeparm = 0;
            }
            sTitle = dw_criteria.GetControlByName("st_report").Text;
            StaticVariables.gnv_app.of_get_parameters().stringparm = isDataWindow;
            StaticMessage.StringParm = sTitle;
            StaticVariables.gnv_app.of_get_parameters().miscstringparm = wf_getparms();
            // write selection
            // delete from t_custstat;
            RDSDataService.DeleteTCuststat(ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                //? ROLLBACK;
                MessageBox.Show(SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lRow = dw_list.GetSelectedRow(0);
            if (lRow == 0)
            {
                MessageBox.Show("Please select an " + isDesc, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dw_list.DataObject is DOccupationlist)
            {
                while (lRow > 0)
                {
                    lID = dw_list.GetItem<Occupationlist>(lRow).Id;
                    //insert into t_custstat ( id) values  ( :lID);
                    RDSDataService.InsertTCuststat(lID, ref SQLCode, ref SQLErrText);
                    if (SQLCode == -(1))
                    {
                        //? ROLLBACK;
                        MessageBox.Show(SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    dw_list.SelectRow(lRow, false);
                    lRow = dw_list.GetSelectedRow(lRow + 1);
                }
            }
            if (dw_list.DataObject is DInterestlist)
            {
                while (lRow > 0)
                {
                    lID = dw_list.GetItem<Interestlist>(lRow).Id;
                    //insert into t_custstat ( id) values  ( :lID);
                    RDSDataService.InsertTCuststat(lID, ref SQLCode, ref SQLErrText);
                    if (SQLCode == -(1))
                    {
                        //? ROLLBACK;
                        MessageBox.Show(SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    dw_list.SelectRow(lRow, false);
                    lRow = dw_list.GetSelectedRow(lRow + 1);
                }
            }
            //? COMMIT;
            // OpenSheetWithParm(w_customer_statistics_report, sTitle, w_main_mdi, 0, original);
            StaticMessage.StringParm = sTitle;
            OpenSheet<WCustomerStatisticsReport>(StaticVariables.MainMDI);
        }
        #endregion
    }
}