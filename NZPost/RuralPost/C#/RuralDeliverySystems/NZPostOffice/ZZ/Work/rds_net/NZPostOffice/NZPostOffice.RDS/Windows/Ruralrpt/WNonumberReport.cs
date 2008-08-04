using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WNonumberReport : WReportAncestor
    {
        public WNonumberReport()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //  TWC - 10/03/2003 
            //  Initial version
            DateTime tnow;
            tnow = DateTime.Now;//Now();
            Cursor.Current = Cursors.WaitCursor;
            //  the type of report this will be decided by li_report_type
            //  town = by town 	contract = by contract
            string ls_contract_title;
            int ll_id;
            int li_report_type;
            ll_id = StaticVariables.gnv_app.of_get_parameters().longparm.GetValueOrDefault();
            ls_contract_title = StaticVariables.gnv_app.of_get_parameters().stringparm;
            li_report_type = StaticVariables.gnv_app.of_get_parameters().integerparm.GetValueOrDefault();
            //  set the correct datawindow and do retrieve
            if (li_report_type == 1)
            {
                dw_report.DataObject = new RPsNonumberTown();
                dw_report.of_SetUpdateable(false);
                //?dw_report.Modify("DataWindow.Print.Preview=Yes");
                dw_report.Retrieve(new object[] { ll_id });
                //?dw_report.GetControlByName("st_report").Text = dw_report.GetControlByName("st_report").Text + ls_contract_title;
            }
            else if (li_report_type == 2)
            {
                //  set to be of type contract
                dw_report.DataObject = new RPsNonumberCon();
                //?dw_report.Modify("DataWindow.Print.Preview=Yes");
                dw_report.Retrieve(new object[] { ll_id });
                //  do modify to introduce the string for the contract details
                dw_report.GetControlByName("st_contract_text").Text = ls_contract_title;
            }
            //?SetMicroHelp("Retrieve time: " + String(SecondsAfter(tnow, Now())) + "second ( s)");
        }

        public virtual void dw_report_constructor()
        {
            dw_report.of_SetUpdateable(false);
        }
    }
}