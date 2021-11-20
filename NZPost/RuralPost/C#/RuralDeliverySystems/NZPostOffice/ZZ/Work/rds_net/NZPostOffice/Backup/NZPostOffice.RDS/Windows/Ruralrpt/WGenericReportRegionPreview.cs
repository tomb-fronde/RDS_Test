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
    public partial class WGenericReportRegionPreview : WGenericReportPreview
    {
        public WGenericReportRegionPreview()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //  TJB  SR4647  June 2005
            //  Add boolean parameter to outlet label retrieval
            //  Boolean indicates whether to use physical address field or not
            string ls_dataobject;
            ls_dataobject = StaticVariables.gnv_app.of_get_parameters().stringparm;
          //?  dw_report = ls_dataobject;
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = ls_dataobject;
            if (TestExpr == "r_outlet_label")
            {
                if (StaticVariables.gnv_app.of_get_parameters().booleanparm)
                {
                   // dw_report.Retrieve(StaticVariables.gnv_app.of_get_parameters().longparm, 1);
                    dw_report.Retrieve(new object[] { StaticVariables.gnv_app.of_get_parameters().longparm, 1 });
                }
                else
                {
                    //dw_report.Retrieve(StaticVariables.gnv_app.of_get_parameters().longparm, 0);
                    dw_report.Retrieve(new object[] { StaticVariables.gnv_app.of_get_parameters().longparm, 0 });
                }
            }
            else
            {
               //dw_report.Retrieve(StaticVariables.gnv_app.of_get_parameters().longparm);
                dw_report.Retrieve(new object[] { StaticVariables.gnv_app.of_get_parameters().longparm });
            }
        }
    }
}