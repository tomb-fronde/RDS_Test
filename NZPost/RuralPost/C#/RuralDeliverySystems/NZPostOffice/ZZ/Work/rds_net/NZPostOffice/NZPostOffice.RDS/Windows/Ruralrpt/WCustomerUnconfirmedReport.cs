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
    public partial class WCustomerUnconfirmedReport : WGenericReportPreview
    {
        public WCustomerUnconfirmedReport()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            Cursor.Current = Cursors.WaitCursor;
            //? dw_report.settransobject(StaticVariables.sqlca);
            dw_report.DataObject = new DCustCountUnconfirmed();
            this.Text = "Unconfirmed Customer Count Report";
            int? l1;
            int? l2;
            int? l3;
            l1 = StaticVariables.gnv_app.of_get_parameters().regionparm;
            l2 = StaticVariables.gnv_app.of_get_parameters().outletparm;
            l3 = StaticVariables.gnv_app.of_get_parameters().longparm;
            ((DCustCountUnconfirmed)dw_report.DataObject).Retrieve(StaticVariables.gnv_app.of_get_parameters().regionparm, StaticVariables.gnv_app.of_get_parameters().outletparm, StaticVariables.gnv_app.of_get_parameters().longparm, StaticVariables.gnv_app.of_get_parameters().dateparm);
            if ((StaticVariables.gnv_app.of_get_parameters().dateparm == null))
            {
                StaticVariables.gnv_app.of_get_parameters().dateparm = DateTime.Today;
            }
            dw_report.GetControlByName("asof").Text = "As of " + StaticVariables.gnv_app.of_get_parameters().dateparm.GetValueOrDefault().ToString("dd/MM/yyyy");//dw_report.Object.asof.Text = "As of " + StaticVariables.gnv_app.of_get_parameters(ToString().dateparm, "dd/mm/yyyy");
        }
    }
}