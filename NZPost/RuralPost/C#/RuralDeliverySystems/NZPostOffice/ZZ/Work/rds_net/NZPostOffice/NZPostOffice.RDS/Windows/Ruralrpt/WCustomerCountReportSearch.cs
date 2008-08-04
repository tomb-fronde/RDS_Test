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
using NZPostOffice.DataControls;
using NZPostOffice.Entity;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WCustomerCountReportSearch : WGenericReportSearch
    {
        public WCustomerCountReportSearch()
        {
            InitializeComponent();

            //jlwang:moved from IC
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            //jlwang;end
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            Metex.Windows.DataUserControl lds_user_Contract_Types;
            int ll_Row;
            int? lNull;
            DataUserControl dwChild;
            lNull = null;
            dwChild = dw_criteria.GetChild("rg_code");
            ((DDddwRenewalGroups)dwChild).Retrieve();
            dw_criteria.GetItem<CustCountcriteria>(0).RgCode = -(1);
            // ct keys
            lds_user_Contract_Types = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_contract_types();
            dwChild = dw_criteria.GetChild("ct_key");
            ((DDddwContractTypes)dwChild).Retrieve();
            if (lds_user_Contract_Types.RowCount == StaticVariables.gnv_app.of_gettotalcontracttypes())
            {
                dwChild.InsertItem<DddwContractTypes>(0);
                dwChild.GetItem<DddwContractTypes>(0).CtKey = lNull;
                dwChild.GetItem<DddwContractTypes>(0).ContractType = "<All Contract Types>";
                dw_criteria.GetItem<DddwContractTypes>(0).CtKey = lNull;
            }
            //ll_Row = dwChild.Find("ct_key=1" ).Lenth;)
            ll_Row = dwChild.Find("ct_key", dwChild.GetItem<DddwContractTypes>(0).CtKey.ToString());
            if (ll_Row > 0)
            {
                dw_criteria.GetItem<DddwContractTypes>(0).CtKey = 1;
            }
        }

        public virtual string wf_getparms()
        {
            string sRegion;
            string sOutlet;
            string sRenGroup;
            string sContract;
            string sParm = string.Empty;
            string sTemp;
            int lRegion;
            int lOutlet;
            int lRenGroup;
            int lContract;
            int lRow;
            int lcount;
            // get region, outlet codes
            StaticVariables.gnv_app.of_get_parameters().integerparm = dw_criteria.GetItem<CustCountcriteria>(0).RegionId;// Convert.ToInt32(dw_criteria.GetItem<CustCountcriteria>(0).RegionId);
            StaticVariables.gnv_app.of_get_parameters().longparm = dw_criteria.GetItem<CustCountcriteria>(0).OutletId;// Convert.ToInt32(dw_criteria.GetItem<CustCountcriteria>(0).OutletId);
            StaticVariables.gnv_app.of_get_parameters().contracttypeparm = dw_criteria.GetItem<CustCountcriteria>(0).CtKey;// Convert.ToInt32(dw_criteria.GetItem<CustCountcriteria>(0).CtKey);
            return sParm;
        }

        #region Events
        public override void pb_open_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string sTitle;
            dw_criteria.AcceptText();
            StaticVariables.gnv_app.of_get_parameters().longparm = dw_criteria.GetItem<CustCountcriteria>(0).RegionId;// Convert.ToInt32(dw_criteria.GetItem<CustCountcriteria>(0).RegionId);
            StaticVariables.gnv_app.of_get_parameters().integerparm = dw_criteria.GetItem<CustCountcriteria>(0).OutletId;// Convert.ToInt32(dw_criteria.GetItem<CustCountcriteria>(0).OutletId);
            StaticVariables.gnv_app.of_get_parameters().contracttypeparm = dw_criteria.GetItem<CustCountcriteria>(0).CtKey;// Convert.ToInt32(dw_criteria.GetItem<CustCountcriteria>(0).CtKey);
            StaticVariables.gnv_app.of_get_parameters().renewalgroupparm = dw_criteria.GetItem<CustCountcriteria>(0).RgCode;// Convert.ToInt32(dw_criteria.GetItem<CustCountcriteria>(0).RgCode);

            //comment by hhuang ,if the value is null ,it will be convert to 0,it seems not right all.
            //if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().longparm))
            //{
            //    StaticVariables.gnv_app.of_get_parameters().longparm = 0;
            //}
            //if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().integerparm))
            //{
            //    StaticVariables.gnv_app.of_get_parameters().integerparm = 0;
            //}
            //if (StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().contracttypeparm))
            //{
            //    StaticVariables.gnv_app.of_get_parameters().contracttypeparm = 0;
            //}

            // sTitle = dw_criteria.Describe("st_report.text");
            sTitle = dw_criteria.GetControlByName("st_report").Text;
            StaticVariables.gnv_app.of_get_parameters().stringparm = isDataWindow;
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_get_parameters().miscstringparm = wf_getparms();
            // OpenSheetWithParm(w_customer_count_report, sTitle, w_main_mdi, 0, original);
            StaticMessage.StringParm = sTitle;
            OpenSheet<WCustomerCountReport>(StaticVariables.MainMDI);
        }

        public virtual void cb_export_clicked(object sender, EventArgs e)
        {
            //   TJB  SR4673  Feb 2006
            string ls_title;
            int? ll_region;
            int? ll_outlet;
            int? ll_ct_key;
            int? ll_rg_code;
            int ll_exportcount;
            DialogResult ll_response;
            Cursor.Current = Cursors.WaitCursor;
            dw_criteria.AcceptText();
            ls_title = "Kiwimail Count Export";
            ll_region = dw_criteria.GetItem<CustCountcriteria>(0).RegionId;
            ll_outlet = dw_criteria.GetItem<CustCountcriteria>(0).OutletId;
            ll_ct_key = dw_criteria.GetItem<CustCountcriteria>(0).CtKey;
            ll_rg_code = dw_criteria.GetItem<CustCountcriteria>(0).RgCode;
            //  Populate the export datawindow
            ((DCustCountExport)dw_export.DataObject).Retrieve(ll_region, ll_outlet, ll_ct_key, ll_rg_code);
            dw_export.of_SetUpdateable(false);
            //  Do row count and ask user if they want to export
            ll_exportcount = dw_export.RowCount;
            ll_response = MessageBox.Show(ll_exportcount.ToString() + " customer records found.\nDo you wish to export?", ls_title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ll_response == DialogResult.Yes)
            {
                //  Do export
                if (dw_export.SaveAs("", "excel5") == 1)//if (dw_export.saveas("", excel5, true) == 1) 
                {
                    MessageBox.Show("Kiwimail Count data exported successfully", ls_title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kiwimail Count data export failed", ls_title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        #endregion
    }
}
