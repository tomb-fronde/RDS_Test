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
    public partial class WReportRcmPreview : WGenericReportPreview
    {
        public WReportRcmPreview()
        {
            InitializeComponent();
            this.SizeChanged += new EventHandler(WReportRcmPreview_SizeChanged);
        }

        public override void pfc_preopen()
        {
            //?base.pfc_preopen();
            DateTime tnow = DateTime.Now;
            Cursor.Current = Cursors.WaitCursor;
            this.Text = StaticMessage.StringParm;
            //?dw_report.Modify("DataWindow.Print.Preview=Yes");
            //dw_report.GetControlByName("stParms").Text = "\'" + StaticVariables.gnv_app.of_get_parameters().miscstringparm + "\'";
            ((RRcmStatNestedReport)dw_report.DataObject).Retrieve(StaticVariables.gnv_app.of_get_parameters().regionparm, StaticVariables.gnv_app.of_get_parameters().outletparm, StaticVariables.gnv_app.of_get_parameters().renewalgroupparm, StaticVariables.gnv_app.of_get_parameters().contracttypeparm);

            TimeSpan ts = DateTime.Now - tnow;
            st_ret.Text = "Total Retrieve time: " /*String(SecondsAfter(tnow, Now()))*/+ ts.Seconds + " second ( s)";
        }

        public virtual void retrieverow()
        {
            // 
        }  
        
        public virtual void WReportRcmPreview_SizeChanged(object sender, EventArgs args)
        {
            st_ret.Top = st_label.Top;
        }
    }
}