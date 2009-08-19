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
            this.dw_report.DataObject = new RRcmStatNestedReport();

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

            // TJB  RD7_0043  Aug 2009
            // Broke Retrieve parameters out primarily to see the values 
            int? pRegion = StaticVariables.gnv_app.of_get_parameters().regionparm;
            int? pOutlet = StaticVariables.gnv_app.of_get_parameters().outletparm;
            int? pRenewalgroup = StaticVariables.gnv_app.of_get_parameters().renewalgroupparm;
            int? pContracttype = StaticVariables.gnv_app.of_get_parameters().contracttypeparm;
            int rc = ((RRcmStatNestedReport)dw_report.DataObject).Retrieve( pRegion, pOutlet, pRenewalgroup, pContracttype);
            //((RRcmStatNestedReport)dw_report.DataObject).Retrieve(StaticVariables.gnv_app.of_get_parameters().regionparm, StaticVariables.gnv_app.of_get_parameters().outletparm, StaticVariables.gnv_app.of_get_parameters().renewalgroupparm, StaticVariables.gnv_app.of_get_parameters().contracttypeparm);

            Cursor.Current = Cursors.Default;

            // TJB  RD7_0043  Aug2009
            // Fixed format/diaplay of retrieve time
            // Added error message
            TimeSpan ts = DateTime.Now - tnow;
            int ts_seconds = ((ts.Hours * 60) + ts.Minutes) * 60 + ts.Seconds;
            st_ret.Text = "Total Retrieve time: " + ts_seconds.ToString() + " seconds.";
            if (rc < 0)
                MessageBox.Show("Error retrieving data for report (probably timed-out).\n"
                                  + st_ret.Text
                                , "Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
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