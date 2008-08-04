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
    public partial class WDetailedCustomerListing : WReportAncestor
    {
        public bool ibPrintedOnParm;

        public WDetailedCustomerListing()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            DateTime tnow;
            tnow = DateTime.Now;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            Cursor.Current = Cursors.WaitCursor;
            int lCustId;
            string sSQLStatement;
            int lCount = 1;
            //? dw_report.Modify("DataWindow.Print.Preview=Yes");
            string ls_Temp;
            ls_Temp = StaticVariables.gnv_app.of_get_parameters().miscstringparm;
            //dw_report.GetControlByName("stParms").Text = "\'" + StaticVariables.gnv_app.of_get_parameters().miscstringparm + "\'";

            if (StaticVariables.gnv_app.of_get_parameters().integerparm < 1)
            {
                //dw_report.GetControlByName("r_recipients").Visible = false;
            }
            ibPrintedOnParm = Convert.ToBoolean(StaticVariables.gnv_app.of_get_parameters().printedonparm);
            //execute immediate "delete from report_temp";
            RDSDataService.DeleteReportTemp(ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                //?ROLLBACK;
                MessageBox.Show("Warning: Unable to delete from temporary table", this.Text);
                return;
            }
            sSQLStatement = StaticVariables.gnv_app.of_get_parameters().stringparm;
            sSQLStatement = "insert into report_temp " + sSQLStatement;
            //? Clipboard(sSQLStatement);
            //? execute immediate :sSQLStatement ;
            RDSDataService.ExecuteSqlString(sSQLStatement, ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                //? ROLLBACK;
                MessageBox.Show("Warning: Unable to insert into temporary table", this.Text);
                return;
            }
            ((RDetailedCustomerListing)dw_report.DataObject).Retrieve();
            //?  COMMIT;
            //? SetMicroHelp("Retrieve time: " + String(SecondsAfter(tnow, Now())) + "second ( s)");
            //  TJB Release 6.8.7 fixup
            //  Add -3 value to select detailed report title
            if (StaticVariables.gnv_app.of_get_parameters().longparm == -(2))
            {
                //dw_report.GetControlByName("st_title").Text = "\'Customer Listing by Day of the Week\'";
                TextObject obj = ((RDetailedCustomerListing)dw_report.DataObject).ReportDocument.ReportDefinition.ReportObjects["Text3"] as TextObject;
                obj.Text = "Customer Listing by Day of the Week";
            }
            else if (StaticVariables.gnv_app.of_get_parameters().longparm == -(3))
            {
                //dw_report.GetControlByName("st_title").Text = "\'Customer Listing by Delivery Frequency\'";
                TextObject obj = ((RDetailedCustomerListing)dw_report.DataObject).ReportDocument.ReportDefinition.ReportObjects["Text3"] as TextObject;
                obj.Text = "Customer Listing by Delivery Frequency";
            }
            else
            {
                //dw_report.GetControlByName("st_title").Text = "\'Customer Listing by Delivery Days\'";
                TextObject obj = ((RDetailedCustomerListing)dw_report.DataObject).ReportDocument.ReportDefinition.ReportObjects["Text3"] as TextObject;
                obj.Text = "Customer Listing by Delivery Days";
            }
            ((RDetailedCustomerListing)dw_report.DataObject).RefreshReport();
        }

        public virtual void printend()
        {
            //?base.printend();
            Cursor.Current = Cursors.WaitCursor;
            int i;
            int SQLCode = 0;
            int lcust = 0;
            if (ibPrintedOnParm)
            {
                for (i = 0; i < dw_report.RowCount; i++)
                {
                    //? lcust = dw_report.getitemnumber(i, "cust_id");
                    // UPDATE rds_customer SET printedon = today(*)  WHERE customer.cust_id =  :lcust ;
                    RDSDataService.UpdateCustId(lcust, ref SQLCode);
                    if (SQLCode == -(1))
                    {
                        //? ROLLBACK;
                        MessageBox.Show("Cannot update customer printed date", "Date Printed");
                        return;
                    }
                }
                //?  COMMIT;
            }
        }
    }
}