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
    public partial class WEclDataImportExceptionReport : WReportAncestor
    { 
        #region Define
        public int? il_region_Id;

        public int? il_rg_code;

        public int? il_ct_key;

        #endregion

        public WEclDataImportExceptionReport()
        {
            InitializeComponent();

            //this.dw_report.DataObject = new NZPostOffice.RDS.DataControls.Ruralrpt.REclDataImportExceptionTest();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            DataUserControl dwDetail;
            Cursor.Current = Cursors.WaitCursor;
            il_region_Id = StaticVariables.gnv_app.of_get_parameters().integerparm;
            il_rg_code = StaticVariables.gnv_app.of_get_parameters().longparm;
            il_ct_key = StaticVariables.gnv_app.of_get_parameters().intparm;
            dw_report.Retrieve(new object[] { il_region_Id, il_rg_code, il_ct_key });
        }
    }
}