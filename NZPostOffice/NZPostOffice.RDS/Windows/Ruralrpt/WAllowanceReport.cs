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

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WAllowanceReport : WReportAncestor//WGenericReportPreview
    { 
        #region Define
        public int? il_region_Id;

        public int? il_rg_code;

        public int? il_ct_key;

        #endregion

        public WAllowanceReport()
        {
            InitializeComponent();

            this.dw_report.DataObject = new RAllowanceReport();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //  TJB  SR4596  April 2005  - New
            DataUserControl dwDetail;
            //WAllowanceSearch w = new WAllowanceSearch();
            Cursor.Current = Cursors.WaitCursor;
            //? dw_report.Modify("DataWindow.Print.Preview=Yes");
            //il_region_Id = w.dw_criteria.GetItem<ReportAllowanceCriteria>(0).RegionId;
            //il_rg_code = w.dw_criteria.GetItem<ReportAllowanceCriteria>(0).RgCode;
            //il_ct_key = w.dw_criteria.GetItem<ReportAllowanceCriteria>(0).CtKey;
            il_region_Id = StaticVariables.gnv_app.of_get_parameters().integerparm;
            il_rg_code = StaticVariables.gnv_app.of_get_parameters().longparm;
            il_ct_key = StaticVariables.gnv_app.of_get_parameters().intparm;
            // ?           dw_report.GetControlByName("stParms").Text = "\'" + StaticVariables.gnv_app.of_get_parameters().miscstringparm + "\'";
            // dw_report.Retrieve(il_region_Id, il_rg_code, il_ct_key);
            dw_report.Retrieve(new object[] { il_region_Id, il_rg_code, il_ct_key });
            //dw_report.Retrieve();
            //?            ((RAllowanceReport)dw_report.DataObject).Retrieve();
        }
    }
}