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
using CrystalDecisions.CrystalReports.Engine;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WGenericReportRegOutletPreview : WGenericReportPreview
    {
        private const string DEFAULT_ASSEMBLY = "NZPostOffice.RDS.DataControls";
        private const string DEFAULT_VERSION = "1.0.0.0";

        public WGenericReportRegOutletPreview()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //dw_report.DataObject = StaticVariables.gnv_app.of_get_parameters().stringparm;
            string ls_reportname = StaticVariables.gnv_app.of_get_parameters().stringparm;
            //?dw_report.SetDataObject(DEFAULT_ASSEMBLY, DEFAULT_VERSION, StaticFunctions.migrateName(ls_reportname));

            //?dw_report.settransobject(StaticVariables.sqlca);
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = StaticVariables.gnv_app.of_get_parameters().stringparm;
            if (TestExpr == "r_vehicle_age")
            {
                this.Text = "Vehicle Age Report";
                dw_report.DataObject = new RVehicleAge();
                //? dw_report.GetControlByName("stParms").Text = "\'" + StaticVariables.gnv_app.of_get_parameters().miscstringparm + "\'";
                // dw_report.Retrieve(StaticVariables.gnv_app.of_get_parameters().longparm, StaticVariables.gnv_app.of_get_parameters().integerparm, StaticVariables.gnv_app.of_get_parameters().renewalgroupparm, StaticVariables.gnv_app.of_get_parameters().contracttypeparm);
                ((RVehicleAge)dw_report.DataObject).Retrieve(StaticVariables.gnv_app.of_get_parameters().longparm, StaticVariables.gnv_app.of_get_parameters().integerparm, StaticVariables.gnv_app.of_get_parameters().renewalgroupparm, StaticVariables.gnv_app.of_get_parameters().contracttypeparm);
            }
            else if (TestExpr == "r_vehicle_perf")
            {
                this.Text = "Vehicle Summary";
                dw_report.DataObject = new RVehiclePerf();
                //dw_report.GetControlByName("stParms").Text = "\'" + StaticVariables.gnv_app.of_get_parameters().miscstringparm + "\'";
                // dw_report.Retrieve(StaticVariables.gnv_app.of_get_parameters().longparm, StaticVariables.gnv_app.of_get_parameters().integerparm, StaticVariables.gnv_app.of_get_parameters().renewalgroupparm, StaticVariables.gnv_app.of_get_parameters().contracttypeparm);

                //!dw_report.Retrieve(new object[] { StaticVariables.gnv_app.of_get_parameters().longparm, StaticVariables.gnv_app.of_get_parameters().integerparm, 
                //!StaticVariables.gnv_app.of_get_parameters().renewalgroupparm, StaticVariables.gnv_app.of_get_parameters().contracttypeparm });
                //replaced with the below direct call 
                ((RVehiclePerf)dw_report.DataObject).Retrieve(StaticVariables.gnv_app.of_get_parameters().longparm, 
                        StaticVariables.gnv_app.of_get_parameters().integerparm, StaticVariables.gnv_app.of_get_parameters().renewalgroupparm, 
                    StaticVariables.gnv_app.of_get_parameters().contracttypeparm);

            }
            else
            {
                // dw_report.Retrieve(StaticVariables.gnv_app.of_get_parameters().longparm, StaticVariables.gnv_app.of_get_parameters().integerparm);
                dw_report.Retrieve(new object[] { StaticVariables.gnv_app.of_get_parameters().longparm, StaticVariables.gnv_app.of_get_parameters().integerparm });
            }
        }

        public override void ue_report()
        {
            //  Override ancestor script
        }

        public override void dw_report_retrieveend(object sender, EventArgs e)
        {
            if (w_print_abort != null)
            {
                this.Close();
            }
        }

        public virtual void dw_report_dberror()
        {
            return;//?1;
        }
    }
}
