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
    public partial class WCustomerCountReport : WGenericReportPreview
    {
        public WCustomerCountReport()
        {
            InitializeComponent();

            this.dw_report.DataObject = new DCustCount();
        }

        public override void ue_abort()
        {
            this.Close();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            Cursor.Current = Cursors.WaitCursor;
            //?  dw_report.settransobject(StaticVariables.sqlca);
            this.Text = "Customer Count Report";
            //?dw_report.Modify("DataWindow.Print.Preview=Yes");
            //dw_report.Retrieve(StaticMessage.IntegerParm, StaticMessage.IntegerParm, StaticVariables.gnv_app.of_get_parameters().contracttypeparm, StaticVariables.gnv_app.of_get_parameters().renewalgroupparm);
            //dw_report.Retrieve(new object[] { StaticMessage.LongParm, StaticMessage.IntegerParm,
            dw_report.Retrieve(new object[] {StaticVariables.gnv_app.of_get_parameters().integerparm,
                StaticVariables.gnv_app.of_get_parameters().longparm, 
                StaticVariables.gnv_app.of_get_parameters().contracttypeparm, 
                StaticVariables.gnv_app.of_get_parameters().renewalgroupparm });
            //dw_report.Retrieve(new object[] { 6, null, 9, -1 });

            if (StaticVariables.gnv_app.of_get_parameters().longparm > 0)
            {
                //?dw_report.Modify("DataWindow.trailer.1.Height=0");
            }

            this.st_label.Visible = false;
        }
    }
}