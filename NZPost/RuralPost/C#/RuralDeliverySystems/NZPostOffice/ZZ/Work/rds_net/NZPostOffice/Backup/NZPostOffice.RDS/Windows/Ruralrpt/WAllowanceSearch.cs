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

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WAllowanceSearch : WGenericReportSearch
    {
        public WAllowanceSearch()
        {
            InitializeComponent();

            this.dw_criteria.DataObject = new DReportAllowanceCriteria();
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            //? _menu.SetFunctionalPart();
            //?_toolbar.SetFunctionalPart();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //  TJB  SR4596  April 2005  - New
            DataUserControl dwChild;
            dw_criteria.AcceptText();
            dwChild = dw_criteria.GetChild("region_id");
            dwChild.Reset();
        }

        public virtual string wf_getparms()
        {
            string ls_Parm = string.Empty;
            string ls_Temp = string.Empty;
            int? ll_regionId;
            int? ll_rgCode;
            int? ll_ctKey;
            ll_regionId = dw_criteria.GetItem<ReportAllowanceCriteria>(0).RegionId;
            ll_rgCode = dw_criteria.GetItem<ReportAllowanceCriteria>(0).RgCode;
            ll_ctKey = dw_criteria.GetItem<ReportAllowanceCriteria>(0).CtKey;
            // get region description
            if (ll_regionId == null)
            {
                ls_Parm = "All Regions";
            }
            else
            {
                // SELECT rgn_name  INTO :ls_Temp  FROM region  WHERE region_id = :ll_regionId;
                ls_Temp = RDSDataService.GetRegion(ll_regionId);
                ls_Parm = ls_Temp + " Region";
            }
            // get renewal group description
            if (ll_rgCode == null)
            {
                ls_Parm += "\rAll Renewal Groups";
            }
            else
            {
                // SELECT rg_description INTO :ls_Temp FROM renewal_group WHERE rg_code = :ll_rgCode;
                ls_Temp = RDSDataService.GetRenewalGroup(ll_rgCode);
                ls_Parm += "~" + ls_Temp;
            }
            // get contract type description
            if (ll_ctKey == null)
            {
                ls_Parm += "\rAll Contract Types";
            }
            else
            {
                // SELECT contract_type  INTO :ls_Temp  FROM contract_type  WHERE ct_key = :ll_ctKey;
                ls_Temp = RDSDataService.GetContractType(ll_ctKey);
                ls_Parm += "~" + ls_Temp;
            }
            return ls_Parm;
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            WAllowanceReport wNewReport;
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_get_parameters().miscstringparm = wf_getparms();
            StaticVariables.gnv_app.of_get_parameters().integerparm = dw_criteria.GetItem<ReportAllowanceCriteria>(0).RegionId;
            StaticVariables.gnv_app.of_get_parameters().longparm = dw_criteria.GetItem<ReportAllowanceCriteria>(0).RgCode;
            StaticVariables.gnv_app.of_get_parameters().intparm = dw_criteria.GetItem<ReportAllowanceCriteria>(0).CtKey;
            // OpenSheet(wNewReport, w_main_mdi, 0, original);
            OpenSheet<WAllowanceReport>(StaticVariables.MainMDI);
        }
    }
}