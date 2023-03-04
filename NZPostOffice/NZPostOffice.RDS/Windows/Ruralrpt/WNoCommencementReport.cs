using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WNoCommencementReport : WGenericReportPreview
    {
        public WNoCommencementReport()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            DateTime tm;
            tm = DateTime.Now;
            //?dw_report.Modify("DataWindow.Print.Preview=Yes");
            int lRow;
            int lRowCount;
            int lContract;
            int lSequence;
            int lregion;
            Metex.Windows.DataUserControl dwResults;
            int ll_days;
            bool lb_privacy_override = false;
            lregion = System.Convert.ToInt32(StaticMessage.DoubleParm);
            ll_days = StaticVariables.gnv_app.of_get_parameters().longparm.GetValueOrDefault();
            dw_report.Reset();
            dw_report.ResumeLayout(false);
            //?if (!(IsValid(w_print_abort)))
            //{
            //    OpenWithParm(w_print_abort, this);
            //}
            //  Get the privacy override flag 
            lb_privacy_override = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_privacyoverride();
            if ((lb_privacy_override == null) || lb_privacy_override == false)
            {
                ((RNoCommencement)dw_report.DataObject).Retrieve(ll_days, lregion, "N");
            }
            else
            {
                ((RNoCommencement)dw_report.DataObject).Retrieve(ll_days, lregion, "Y");
            }
            //?SetMicroHelp("Retrieve time: " + String(SecondsAfter(tm, Now())));
        }
    }
}