using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public partial class WEclExceptionReportTest : WMaster
    {
        public WEclExceptionReportTest()
        {
            InitializeComponent();
            wf_open();
        }

        public void wf_open()
        {
            string ls_msg;
            base.open();
            WEclDataImport lw_parent = (WEclDataImport)StaticMessage.PowerObjectParm;
            int n = lw_parent.ecl_import_error_list.Count;
            ls_msg = "Ticket No              Part   Error";
            for (int i = 0; i < n; i++ )
            {
                ls_msg = ls_msg + "\n"
                         + lw_parent.ecl_import_error_list[i].EclTicketNo + "  "
                         + lw_parent.ecl_import_error_list[i].EclTicketPart  + "    "
                         + lw_parent.ecl_import_error_list[i].ErrorMsgText;
            }
            MessageBox.Show(ls_msg,"ECL Data Import Exception Report");
        }

        private void cb_cancel_Click(object sender, EventArgs e)
        {
            StaticVariables.gnv_app.of_get_parameters().stringparm = "Bye Bye";
            this.Close();
        }
    }
}