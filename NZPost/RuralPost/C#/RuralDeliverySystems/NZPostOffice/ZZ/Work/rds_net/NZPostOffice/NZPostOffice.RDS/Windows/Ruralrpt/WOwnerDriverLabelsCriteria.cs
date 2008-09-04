using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WOwnerDriverLabelsCriteria : WGenericReportSearch
    {
        public WOwnerDriverLabelsCriteria()
        {
            InitializeComponent();

            dw_criteria.DataObject = new DOwnerDriverReportCriteria();
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dw_results.DataObject = new DReportGenericResults();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            // DataControlBuilder dwChild
            // long lNull
            // 
            // 
            //  lNull = null
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
            // dw_Criteria.GetChild ( "rg_code", dwChild)
            // dwChild.Retrieve ( )
            // dwChild.InsertRow ( 1)
            // dwChild.SetItem ( 1, "rg_code", lNull)
            // dwChild.SetItem ( 1, "rg_description", "<All Renewal Groups>")
            // 
            // 
            // dw_Criteria.InsertRow ( 0)
            // dw_Results.SetRowFocusIndicator ( FocusRect!)
            // 
            // dw_Criteria.SetItem ( 1, 'ct_key',1)
        }

        #region Events
        public override void dw_criteria_itemchanged(object sender, System.EventArgs e)
        {
            //  Do Nothing
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            int lCTKey;
            int? lnull;
            string sTitle;
            lnull = null;
            //WOwnerDriverReportPreview wNewReport=new WOwnerDriverReportPreview();
            dw_criteria.AcceptText();

            StaticVariables.gnv_app.of_get_parameters().booleanparm = true;
            StaticVariables.gnv_app.of_get_parameters().regionparm = dw_criteria.GetItem<OwnerDriverReportCriteria>(0).RegionId;
            StaticVariables.gnv_app.of_get_parameters().contractorparm = dw_criteria.GetItem<OwnerDriverReportCriteria>(0).Ownerdriver;
            StaticVariables.gnv_app.of_get_parameters().contracttypeparm = dw_criteria.GetItem<OwnerDriverReportCriteria>(0).CtKey;
            StaticVariables.gnv_app.of_get_parameters().renewalgroupparm = dw_criteria.GetItem<OwnerDriverReportCriteria>(0).RgCode;
            StaticVariables.gnv_app.of_get_parameters().outletparm = null;

            Cursor.Current = Cursors.WaitCursor;
            OpenSheet<WOwnerDriverReportPreview>(StaticVariables.MainMDI);//OpenSheetWithParm(wNewReport, sTitle, w_main_mdi, 0, original!);
        }
        #endregion
    }
}