using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WVehicleExpiryReport : WGenericReportPreview
    {
        public WVehicleExpiryReport()
        {
            InitializeComponent();

            //jlwang:
            dw_report.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_report_constructor);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            // long ll_id
            // integer li_report_type
            // 
            // ll_id = gnv_App.of_Get_Parameters ( ).LongParm
            // li_report_type = gnv_App.of_Get_Parameters ( ).IntegerParm
            // 
            // // set the correct datawindow and do retrieve
            // 	dw_Report.of_setupdateable ( false)
            // 	dw_Report.Modify ( "DataWindow.Print.Preview=Yes")
            // 	dw_report.Retrieve(new object[]{ll_id})
            // 
            // 	dw_report.Object.st_header_text.text = gnv_App.of_Get_Parameters ( ).StringParm
            //  TWC - 13/03/2003 
            //  Initial version
            DateTime tnow = DateTime.Now;
            Cursor.Current = Cursors.WaitCursor;
            //  the type of report this will be decided by li_report_type
            //  town = by town 	contract = by contract
            string ls_header;
            int? ll_id;
            int? li_report_type;
            ll_id = StaticVariables.gnv_app.of_get_parameters().longparm;
            ls_header = StaticVariables.gnv_app.of_get_parameters().stringparm;
            li_report_type = StaticVariables.gnv_app.of_get_parameters().integerparm;
            //  set the correct datawindow and do retrieve

            //p! using same report and data window, different retrieve/fetch methods used as the fields
            //p!RVehExpRenewReport and RVehExpRenewReport are identical
            bool expiryRecords = false;
            if (li_report_type == 1)
            {
                //!dw_report.DataObject = new RVehExpRegReport();// DwGroupDetails(r_veh_exp_reg_report);
                expiryRecords = true;
                dw_report.DataObject = new RVehExpRenewReport(expiryRecords);
            }
            else if (li_report_type == 2)
            {
                //  set to be of type renewal
                dw_report.DataObject = new RVehExpRenewReport();// DwGroupDetails(r_veh_exp_renew_report);
                expiryRecords = false;
            }

            ((RVehExpRenewReport)dw_report.DataObject).ChangeHeaderText(ls_header);//! change the text box of header before retrieving

            //?dw_report.Modify("DataWindow.Print.Preview=Yes");
            ((RVehExpRenewReport)dw_report.DataObject).Retrieve(ll_id, expiryRecords);
            //  do modify to introduce the string for the contract details
            //!dw_report.Object.st_header_text.text = ls_header;
            //? dw_report.GetControlByName("st_header_text").Text = ls_header;
            //?SetMicroHelp("Retrieve time: " + String(SecondsAfter(tnow, Now())) + "second ( s)");
        }

        public virtual void dw_report_constructor()
        {
            dw_report.of_SetUpdateable(false);
        }
    }
}