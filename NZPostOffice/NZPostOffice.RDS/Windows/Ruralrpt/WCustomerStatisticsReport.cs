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
    public partial class WCustomerStatisticsReport : WGenericReportPreview
    {
        public WCustomerStatisticsReport()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            string DWfilter;
            Cursor.Current = Cursors.WaitCursor;
            dw_report.DataObject = (DataUserControl)StaticVariables.gnv_app.of_get_parameters().dwparm;
            // dw_report.settransobject(StaticVariables.sqlca);
            dw_report.DataObject = new DCustOccupationStat();
            this.Text = StaticMessage.StringParm;
            //dw_report.Retrieve(StaticVariables.gnv_app.of_get_parameters().regionparm, StaticVariables.gnv_app.of_get_parameters().outletparm, StaticVariables.gnv_app.of_get_parameters().contracttypeparm, StaticVariables.gnv_app.of_get_parameters().privacyparm);
            dw_report.Retrieve(new object[] { StaticVariables.gnv_app.of_get_parameters().regionparm, StaticVariables.gnv_app.of_get_parameters().outletparm, StaticVariables.gnv_app.of_get_parameters().contracttypeparm, StaticVariables.gnv_app.of_get_parameters().privacyparm });
            if (StaticMessage.IntegerParm > 0)
            {
                //?dw_report.Modify("DataWindow.trailer.1.Height=0");
            }
        }

        public override void show()
        {
            //?base.show();
            //?  dw_report.modify("datawindow.print.preview=yes");
        }
    }
}