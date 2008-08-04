using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WOwnerDriverReportPreview : WGenericReportPreview
    {
        public WOwnerDriverReportPreview()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            Dictionary<int, int?> lContractList = new Dictionary<int, int?>();// IntArray lContractList = new IntArray();
            int lPos;
            int lCtr = 0;
            string DebugString;
            string sContractFlag;
            int? ll_region;
            int? ll_outlet;
            int? ll_contractType;
            int? ll_renewalGroup;
            string ls_contractor;
            string ls_contractList = string.Empty;

            if (StaticVariables.gnv_app.of_get_parameters().regionparm == 0)
            {
                StaticVariables.gnv_app.of_get_parameters().regionparm = null;
            }
            if (StaticVariables.gnv_app.of_get_parameters().outletparm == 0)
            {
                StaticVariables.gnv_app.of_get_parameters().outletparm = null;
            }
            if (StaticVariables.gnv_app.of_get_parameters().contractorparm != null && StaticVariables.gnv_app.of_get_parameters().contractorparm.Length == 0)
            {
                StaticVariables.gnv_app.of_get_parameters().contractorparm = null;
            }
            if (StaticVariables.gnv_app.of_get_parameters().contracttypeparm == 0)
            {
                StaticVariables.gnv_app.of_get_parameters().contracttypeparm = null;
            }
            if (StaticVariables.gnv_app.of_get_parameters().renewalgroupparm == 0)
            {
                StaticVariables.gnv_app.of_get_parameters().renewalgroupparm = null;
            }
            ls_contractList = StaticVariables.gnv_app.of_get_parameters().miscstringparm;

            /*  ------------------------ Debugging ------------------------ //
            DebugString = gnv_App.of_Get_Parameters ( ).MiscStringParm 
            MessageBox.Show (   & 'Contract list:\n' + ls_contractList ,  'w_owner_driver_report_preview.pfc_preopen' )
            // -----------------------------------------------------------  */
            if (StaticMessage.BooleanParm) // (StaticVariables.gnv_app.of_get_parameters().booleanparm)
            {
                lContractList[1] = -(9);
                ls_contractList = "0000";
                sContractFlag = "N";
            }
            else
            {
                sContractFlag = "Y";
                // parse miscstringparm
                while (ls_contractList.Length > 0)
                {
                    lCtr++;
                    lPos = ls_contractList.IndexOf(',');// Pos(ls_contractList, ',');
                    if (lPos > 0)
                    {
                        lContractList[lCtr] = System.Convert.ToInt32(ls_contractList.Substring(0, lPos));//Left(ls_contractList, lPos));
                    }
                    else
                    {
                        lContractList[lCtr] = System.Convert.ToInt32(ls_contractList);
                        break;
                    }
                    // debug
                    ls_contractList = ls_contractList.Substring(lPos);// TextUtil.Right(ls_contractList, ls_contractList.Len() - lPos);
                    DebugString = ls_contractList;
                }
            }

            ll_region = StaticVariables.gnv_app.of_get_parameters().regionparm;
            ls_contractor = StaticVariables.gnv_app.of_get_parameters().contractorparm;
            ll_contractType = StaticVariables.gnv_app.of_get_parameters().contracttypeparm;
            ll_renewalGroup = StaticVariables.gnv_app.of_get_parameters().renewalgroupparm;
            ll_outlet = StaticVariables.gnv_app.of_get_parameters().outletparm;
            //?dw_report.Retrieve(ll_region, ls_contractor, ll_contractType, ll_renewalGroup, ll_outlet, lContractList, sContractFlag);

            // dw_Report.Retrieve ( gnv_App.of_Get_Parameters ( ).RegionParm,  gnv_App.of_Get_Parameters ( ).ContractorParm,  gnv_App.of_Get_Parameters ( ).ContractTypeParm,  gnv_App.of_Get_Parameters ( ).RenewalGroupParm, gnv_App.of_Get_Parameters ( ).OutletParm, lContractList, 	sContractFlag)
        }
    }
}